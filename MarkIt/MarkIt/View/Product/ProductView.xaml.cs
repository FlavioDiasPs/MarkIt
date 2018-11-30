using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MarkIt.View.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductView : ContentPage
    {
        public ProductView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(() => App.ProductVM.LoadProducts());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    SearchByName.Text = result.Text;
                });
            };
        }
    }
}