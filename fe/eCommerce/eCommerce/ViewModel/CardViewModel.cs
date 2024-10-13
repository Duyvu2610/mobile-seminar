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
        public ICommand IncreaseQuantityCommand { get; }
        public ICommand DecreaseQuantityCommand { get; }
        public int quantity { get; set; }
        
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
            IncreaseQuantityCommand = new Command<CartModel>(IncreaseQuantity);
            DecreaseQuantityCommand = new Command<CartModel>(DecreaseQuantity);
        }
        async private void IncreaseQuantity(CartModel cartModel)
        {
            await _cartApi.UpdateCart(cartModel.itemId, cartModel.quantity + 1);
            cartModel.Quantity++;
            CalculateTotalAmount();
            
        }

        async private void DecreaseQuantity(CartModel cartModel)
        {
            if (cartModel.Quantity > 1) 
            {
                await _cartApi.UpdateCart(cartModel.itemId, cartModel.quantity - 1);
                cartModel.Quantity--;
                CalculateTotalAmount();
                
            }
        } 

        async void RemoveCart(CartModel cart)
        {
            if (itemPreview.Contains(cart))
            {
                await _cartApi.RemoveCart(cart.itemId);
                itemPreview.Remove(cart);
                CalculateTotalAmount();
            }
        }

        private async void GetCartList()
        {
            List<CartModel> cartModels = await _cartApi.GetCartList();
            itemPreview = new ObservableCollection<CartModel>(cartModels);
               
            
            CalculateTotalAmount();


            OnPropertyChanged(nameof(itemPreview));
        }
        private void CalculateTotalAmount()
        {
            int total = 0;
            foreach (CartModel item in itemPreview)
            {
                total += item.price * item.quantity;
            }
            TotalAmount = total;
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
