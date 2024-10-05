using eCommerce.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCommerce.Model
{
    public class categoriesViewModel : INotifyPropertyChanged
    {
        readonly IList<FeaturedBrands> source1;

        public ObservableCollection<FeaturedBrands> featuredItemPreview { get; private set; }

        public ObservableCollection<Item> itemPreview { get; private set; }

        private readonly CategoryApi _categoryApi;

        public ICommand FeaturedTapCommand { get; set; }

        public ICommand ItemTapCommand { get; set; }

        public categoriesViewModel()
        {
            _categoryApi = new CategoryApi();
            source1 = new List<FeaturedBrands>();
            CreateFeaturedItemCollection();

            ItemTapCommand = new Command<Item>(items =>
            {
                long itemId = items.id;
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ProductPage(itemId));
            });

            FeaturedTapCommand = new Command<FeaturedBrands>(brand =>
            {
                string selBrand = brand.brand;
                Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new BrandPage(selBrand)));
            });
        }

        public async Task GetListByIdCategory(long categoryId)
        {
            List<Item> items = await _categoryApi.GetItemsByCategoryId(categoryId);
            itemPreview = new ObservableCollection<Item>(items);
            OnPropertyChanged(nameof(itemPreview));
        }

        private void CreateFeaturedItemCollection()
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
