using System.Collections.Generic;

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
