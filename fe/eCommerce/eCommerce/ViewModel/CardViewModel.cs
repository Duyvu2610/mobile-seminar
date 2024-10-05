using eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCommerce.Model
{
    public class CardViewModel : INotifyPropertyChanged
    {
        private readonly CartApi _cartApi;

        private int _totalAmount;

        public int TotalAmount
        {
            get => _totalAmount;
            set
            {
                if (_totalAmount != value)
                {
                    _totalAmount = value;
                    OnPropertyChanged(nameof(TotalAmount));
                }
            }
        }

        public ObservableCollection<int> totalAmount { get; set; }

        public ObservableCollection<CartModel> itemPreview { get; private set; }

        public ICommand DeleteCommand => new Command<CartModel>(RemoveCart);

        public CardViewModel()
        {
            _cartApi = new CartApi();
            GetCartList();
        }

        void RemoveCart(CartModel cart)
        {
            if (itemPreview.Contains(cart))
            {
                itemPreview.Remove(cart);
            }
        }

        private async void GetCartList()
        {
            List<CartModel> cartModels = await _cartApi.GetCartList();
            itemPreview = new ObservableCollection<CartModel>(cartModels);

            int total = 0;
            foreach (CartModel item in cartModels)
            {
                total += item.price * item.quantity;
            }
            TotalAmount = total;


            OnPropertyChanged(nameof(itemPreview));
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
