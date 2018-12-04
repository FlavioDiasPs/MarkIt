using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MarkIt.Model
{
    public class Product
    {
        public Product()
        {
            Prices = new List<Price>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public decimal BestPrice { get; set; }
        public string BestPriceMarket { get; set; }

        public List<Price> Prices { get; set; }
    }}
