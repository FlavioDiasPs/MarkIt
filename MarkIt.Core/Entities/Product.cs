using System.Collections.Generic;

namespace MarkIt.Core.Entities 
{
    public class Product : Base.EntityBase
    {        
        public string Barcode { get; set; }
        public string Name { get; set; }
        public List<Price> Prices { get; set; }
    }
}
