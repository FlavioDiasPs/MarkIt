using MarkIt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarkIt.View.Product
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailView : ContentPage
    {
        public static ProductViewModel ProductVM { get; set; }
        public ProductDetailView ()
		{
			InitializeComponent ();
		}
	}
}