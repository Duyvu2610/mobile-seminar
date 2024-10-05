using eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCommerce.Model
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly CartApi _cartApi;

        public ICommand AddToCartCommand => new Command<Item>(
            async (cartItem) => await AddItemToCart(cartItem)
        );

        readonly IList<Reviews> source;

        public ObservableCollection<Reviews> itemPreview { get; private set; }

        private Item _selectedItem;

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            source = new List<Reviews>();
            _cartApi = new CartApi();
            CreateItemCollection();
        }

        void CreateItemCollection()
        {
            source.Add(new Reviews
            {
                image = "user1",
                name = "Samuel Smith",
                review = "Wonderful jean, perfect gift for my girl for our anniversary!",
                rating = "1"
            });
            source.Add(new Reviews
            {
                image = "user2",
                name = "Beth Aida",
                review = "I love this, paired it with a nice blouse and all eyes on me.",
                rating = "3"
            });
            itemPreview = new ObservableCollection<Reviews>(source);
        }

        public async void LoadProductDetails(long id)
        {
            var itemApi = new ItemApi();
            var itemDetails = await itemApi.GetItemDetails(id); 
            SelectedItem = itemDetails;
        }

        public async Task<bool> AddItemToCart(Item cartItem)
        {
            CartModel cartModel = new CartModel()
            {
                itemId = cartItem.id,
                quantity = 1,
                price = cartItem.price,
                itemName = cartItem.name,
                itemImg = cartItem.imageUrl
            };

            bool result = false;

            try
            {
                result = await _cartApi.AddToCart(cartModel);

                if (result)
                {
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng thành công!", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Thêm vào giỏ hàng thất bại!", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Đã xảy ra lỗi", ex.Message, "OK");
            }

            return result;
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
