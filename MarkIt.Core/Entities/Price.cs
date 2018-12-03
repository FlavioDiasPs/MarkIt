using Dapper.Contrib.Extensions;
using System;

namespace MarkIt.Core.Entities
{
    [Table("[Price]")]
    public class Price : Base.EntityBase
    {
        public decimal Value { get; set; }
        public Market Market { get; set; }
        public Product Product { get; set; }
        public DateTime Data { get; set; }
    }
}