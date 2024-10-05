using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eCommerce.Model;

namespace eCommerce.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        double lastScrollIndex;
        double currentScrollIndex;

        private ProductViewModel viewModel;

        public ProductPage(long? itemId)
        {
            InitializeComponent();
            review.HeightRequest = 4 * 90;

            long validItemId = itemId ?? 1;

            viewModel = new ProductViewModel();
            BindingContext = viewModel;

            viewModel.LoadProductDetails(validItemId);
        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            currentScrollIndex = e.ScrollY;
            if (currentScrollIndex > lastScrollIndex)
            {
                footer.IsVisible = false;
            }
            else
            {
                footer.IsVisible = true;
            }
            lastScrollIndex = currentScrollIndex;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Select Size", "Cancel", null, "X", "XL", "XXL");
            size.Text = action;
        }
    }
}
