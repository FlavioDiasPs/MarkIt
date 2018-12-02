﻿using System.Collections.Generic;

namespace MarkIt.Core.Entities
{
    public class Market : Base.EntityBase
    {
        protected Market()
        { }
        
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        List<Product> Products { get; set; }
    }
}