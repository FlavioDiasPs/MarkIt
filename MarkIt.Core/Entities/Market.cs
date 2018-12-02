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
        List<Price> Prices { get; set; }
    }
}
