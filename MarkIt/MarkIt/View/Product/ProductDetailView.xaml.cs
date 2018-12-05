using MarkIt.App_Code;
using MarkIt.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public ProductDetailView()
        {
            InitializeComponent();

            //MapProduct = ProductDetailViewModel.Map;
            LoadMap();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private void LoadMap()
        {

            double firstLongitude = ProductDetailsViewModel.Prices.FirstOrDefault().Market.Longitude;
            double firstLatitude = ProductDetailsViewModel.Prices.FirstOrDefault().Market.Latitude;

            MapProduct.PinCustomizados = new List<CustomPin>();

            foreach (var item in ProductDetailsViewModel.Prices)
            {
                var pin = new CustomPin
                {
                    Type = PinType.Place,
                    Position = new Position(item.Market.Latitude, item.Market.Longitude),
                    Label = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "R$ {0:0.00}", item.Value),
                    Address = $"{item.Market.Name} - {item.Market.Address}, {item.Market.AddressNumber} - {item.Market.District} - {item.Market.City} - {item.Market.State} - {item.Market.Zipcode}",
                    Id = item.Market,
                    //Localizacao = $"{item.Market.Website}"
                };
                MapProduct.PinCustomizados.Add(pin);
                MapProduct.Pins.Add(pin);
            }
            MapProduct.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(firstLatitude, firstLongitude), Distance.FromMiles(1.0)));

        }

    }
}