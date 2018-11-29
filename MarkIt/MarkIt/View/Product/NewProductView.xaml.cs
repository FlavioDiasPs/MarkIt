using MarkIt.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarkIt.View.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewProductView : ContentPage
    {
        public static ProductViewModel ProductVM { get; set; }
        public NewProductView ()
		{
			InitializeComponent ();
		}
	}
}