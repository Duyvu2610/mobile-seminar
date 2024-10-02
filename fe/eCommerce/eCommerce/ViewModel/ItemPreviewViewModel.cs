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
    class ItemPreviewViewModel : INotifyPropertyChanged
    {
        readonly IList<ItemsPreview> source;
        public ObservableCollection<ItemsPreview> itemPreview { get; private set; }

        readonly IList<FeaturedBrands> source1;
        public ObservableCollection<FeaturedBrands> featuredItemPreview { get; private set; }

        readonly IList<Category> source2;
        public ObservableCollection<Category> categories { get; private set; }

        public ICommand FeaturedTapCommand { get; set; }
        public ICommand ItemTapCommand { get; set; }
        public ICommand CatTapCommand { get; set; }

        private readonly CategoryApi _categoryApi;
        public ItemPreviewViewModel()
        {
            _categoryApi = new CategoryApi();
            source = new List<ItemsPreview>();
            source1 = new List<FeaturedBrands>();
            source2 = new List<Category>();
            CreateItemCollection();
            CreateFeaturedItemCollection();
            CreateCategoriesCollection();

            ItemTapCommand = new Command<ItemsPreview>(items =>
            {
                // Truyền itemId vào ProductPage
                long itemId = items.Id;  // Giả sử ItemsPreview có thuộc tính Id
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ProductPage(itemId));
            });

            CatTapCommand = new Command<Category>(items =>
            {
                string selcate = items.title;
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new categoriesPage(selcate));
            });

            FeaturedTapCommand = new Command<FeaturedBrands>(brand =>
            {
                string selBrand = brand.brand;
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new BrandPage(selBrand)));
            });
        }

       
        async void CreateCategoriesCollection()
        {
            List<Category> categoriesList = await _categoryApi.GetCategories();

            categories = new ObservableCollection<Category>(categoriesList);
            OnPropertyChanged(nameof(categories));
        }
        void CreateFeaturedItemCollection()
        {
            source1.Add(new FeaturedBrands
            {
                ImageUrl = "Icon_Bo",
                brand = "B&o",
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
                ImageUrl = "Icon_Apple",
                brand = "Apple Inc",
                details = "5693 Products"
            });

            featuredItemPreview = new ObservableCollection<FeaturedBrands>(source1);
        }
        void CreateItemCollection()
        {
            source.Add(new ItemsPreview
            {
                Id = 1,
                ImageUrl = "Image1",
                Name= "BeoPlay Speaker",
                brand= "Bang and Olufsen",
                price= "$755"
            });
            source.Add(new ItemsPreview
            {
                Id = 1,
                ImageUrl = "Image2",
                Name = "Leather Wristwatch",
                brand = "Tag Heuer",
                price = "$450"
            });
            source.Add(new ItemsPreview
            {
                Id = 1,
                ImageUrl = "Image3",
                Name = "Smart Bluetooth Speaker",
                brand = "Google LLC",
                price = "$9000"
            });
            source.Add(new ItemsPreview
            {
                Id = 1,
                ImageUrl = "Image4",
                Name = "Smart Luggage",
                brand = "Smart Inc",
                price = "$1200"
            });
            itemPreview = new ObservableCollection<ItemsPreview>(source);
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
