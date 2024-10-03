using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eCommerce.Model;  // Thêm namespace để sử dụng ViewModel

namespace eCommerce.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        double lastScrollIndex;
        double currentScrollIndex;

        private ProductViewModel viewModel;  // Khai báo ViewModel

        public ProductPage(long? itemId)  // Sử dụng kiểu nullable (int?)
        {
            InitializeComponent();
            review.HeightRequest = 4 * 90;

            // Kiểm tra nếu itemId không có thì gán giá trị mặc định là 1
            long validItemId = itemId ?? 1;

            // Khởi tạo ViewModel và truyền BindingContext
            viewModel = new ProductViewModel();
            BindingContext = viewModel;

            // Gọi phương thức để tải chi tiết sản phẩm với itemId hợp lệ
            viewModel.LoadProductDetails(validItemId);
        }

        // Sự kiện cuộn để ẩn/hiện footer
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

        // Sự kiện khi nhấn vào để quay lại trang trước
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        // Sự kiện khi nhấn vào để chọn size
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Select Size", "Cancel", null, "X", "XL", "XXL");
            size.Text = action;
        }
    }
}
