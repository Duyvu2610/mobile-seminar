using eCommerce.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCommerce.Model
{
    public class categoriesViewModel : INotifyPropertyChanged
    {
        readonly IList<FeaturedBrands> source1;
        public ObservableCollection<FeaturedBrands> featuredItemPreview { get; private set; }

        readonly IList<ItemsPreview> source;
        public ObservableCollection<ItemsPreview> itemPreview { get; private set; }
        private readonly CategoryApi _categoryApi;
        public ICommand FeaturedTapCommand { get; set; }
        public ICommand ItemTapCommand { get; set; }

        public categoriesViewModel()
        {
            _categoryApi = new CategoryApi();
            source = new List<ItemsPreview>();
            source1 = new List<FeaturedBrands>();
            CreateFeaturedItemCollection();
            GetListByIdCategory();
            ItemTapCommand = new Command<ItemsPreview>(items =>
            {
                // Assuming ItemsPreview has an Id property
                //cái này là gán cứng cái id là 1 đk
                //bth nó khác nó lấy id ra nè
                Console.WriteLine(items.Id);
                long itemId = items.Id;
                // Call the method to get the list by category ID
                GetListByIdCategory();
                // Navigate to ProductPage with the itemId
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ProductPage(itemId));
            });
            
            FeaturedTapCommand = new Command<FeaturedBrands>(brand =>
            {
                string selBrand = brand.brand;
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new BrandPage(selBrand)));
            });
        }

        async void GetListByIdCategory()
        {
            long x =1;
            source.Clear();
            var items = await _categoryApi.GetItemsByCategoryId(x);
            foreach (var item in items)
            {
                source.Add(new ItemsPreview { Id = item.id, ImageUrl = item.imageUrl, Name = item.name, brand = item.brand, price = item.price });
            }
            itemPreview = new ObservableCollection<ItemsPreview>(source);
            OnPropertyChanged(nameof(itemPreview));
            Console.WriteLine("da goi");
        }

        void CreateFeaturedItemCollection()
        {
            source1.Add(new FeaturedBrands
            {
                ImageUrl = "Icon_Apple",
                brand = "Apple Inc",
                details = "5693 Products"
            });
            source1.Add(new FeaturedBrands
            {
                ImageUrl = "beats",
                brand = "Beats",
                details = "1124 Products"
            });
            source1.Add(new FeaturedBrands
            {
                ImageUrl = "Icon_Bo",
                brand = "B&o",
                details = "5693 Products"
            });

            featuredItemPreview = new ObservableCollection<FeaturedBrands>(source1);
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