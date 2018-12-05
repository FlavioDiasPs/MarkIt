using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace MarkIt.Core.Entities
{
    [Table("[Market]")]
    public class Market : Base.EntityBase
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        List<Price> Prices { get; set; }
    }
}
