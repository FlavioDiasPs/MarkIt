using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}