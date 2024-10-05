using eCommerce.Model;
using Rg.Plugins.Popup.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCommerce.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class categoriesPage : ContentPage
    {
        private categoriesViewModel _categoriesViewModel;
        public categoriesPage(long id)
        {
            InitializeComponent();
            _categoriesViewModel = new categoriesViewModel();
            BindingContext = _categoriesViewModel;

            LoadData(id);

        }

        private async void LoadData(long categoryId)
        {
            await _categoriesViewModel.GetListByIdCategory(categoryId);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
           
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Filter());
        }
    }
}