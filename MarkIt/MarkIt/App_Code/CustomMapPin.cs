using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MarkIt.App_Code
{
    public class CustomMapPin : Map
    {
        public List<CustomPin> PinCustomizados { get; set; }
    }
    public class CustomPin : Pin
    {
        public string Localizacao { get; set; }
    }
}
