using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCommerce.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class BrandPage : TabbedPage
    {

        private readonly ItemApi _itemApi;
        public ObservableCollection<ItemsPreview> itemsBestselling { get; private set; }

        public BrandPage(String name)
        {
            _itemApi = new ItemApi();
            InitializeComponent();

            title.Text = name;
            if (name.Equals("Recommended"))
            {
                
                LoadRecommmedItems();
            }
            else {
                
                LoadBestSellingItems();
            }

            
        }
        private async void LoadRecommmedItems()
        {
            try
            {

                List<ItemsPreview> recommendItems = await _itemApi.GetItemsRecommend();


                this.ItemsSource = new MainClass[]
                {

            new MainClass("All", recommendItems)
                };
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Unable to load best-selling items.", "OK");
            }
        }
        private async void LoadBestSellingItems()
        {
            try
            {
               
                List<ItemsPreview> bestSellingItems = await _itemApi.GetItemBestSellingg();

                
                this.ItemsSource = new MainClass[]
                {
          
            new MainClass("All", bestSellingItems)
                };
            }
            catch (Exception ex)
            {
                
                await DisplayAlert("Error", "Unable to load best-selling items.", "OK");
            }
        }

        class MainClass
        {
            public MainClass(string name, IList<ItemsPreview> list)
            {
                this.Name = name;
                this.list = list;
            }

            public string Name { private set; get; }
            public IList<ItemsPreview> list { private set; get; }

            public override string ToString()
            {
                return Name;
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
       

        async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            // Lấy item được chọn
            var selectedItem = e.CurrentSelection.FirstOrDefault() as ItemsPreview;

            if (selectedItem != null)
            {
                // Truyền id vào ProductPage
                await Navigation.PushModalAsync(new ProductPage(selectedItem.Id));
            }
        }


    }
}