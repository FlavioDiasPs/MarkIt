using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace MarkIt.Core.Entities
{
    [Table("[Product]")]
    public class Product : Base.EntityBase
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public List<Price> Prices { get; set; }
    }
}
