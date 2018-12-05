using MarkIt.App_Code;
using MarkIt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MarkIt.View.Product
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailView : ContentPage
    {
        public static ProductViewModel ProductVM { get; set; }
        public ProductDetailView ()
		{
			InitializeComponent();

            BindingContext = new ProductDetailsViewModel();

            //MapProduct = ProductDetailViewModel.Map;

            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(-23.573783, -46.623438),
                Label = "Fiap",
                Address = "Av. Lins de Vasconcelos, 1264, Aclimação",
                Id = "Fiap",
                Localizacao = "https://www.fiap.com.br/"
            };


            MapProduct.PinCustomizados = new List<CustomPin> { pin };
            MapProduct.Pins.Add(pin);



            MapProduct.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(-23.573783, -46.623438), Distance.FromMiles(1.0)));

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}