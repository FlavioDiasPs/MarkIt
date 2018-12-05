using MarkIt.App_Code;
using MarkIt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms.Maps;

namespace MarkIt.ViewModel
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {
        public Product ProductModel { get; set; }
        //public static CustomMapPin Map;

        public ProductDetailViewModel()
        {
            //Map = new CustomMapPin();
            //LoadMap();

        }
        

        //private void LoadMap()
        //{

        //    var pin = new CustomPin
        //    {
        //        Type = PinType.Place,
        //        Position = new Position(-23.573783, -46.623438),
        //        Label = "Fiap",
        //        Address = "Av. Lins de Vasconcelos, 1264, Aclimação",
        //        Id = "Fiap",
        //        Localizacao = "https://www.fiap.com.br/"
        //    };

        //    Map.MoveToRegion(
        //        MapSpan.FromCenterAndRadius(
        //            new Position(-23.573783, -46.623438), Distance.FromMiles(1.0)));

        //    Map.PinCustomizados = new List<CustomPin> { pin };
        //    Map.Pins.Add(pin);
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
