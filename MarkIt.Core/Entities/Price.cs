namespace MarkIt.Core.Entities
{
    public class Price : Base.EntityBase
    {
        public decimal Value { get; set; }
        public Market Market { get; set; }
        public Product Product { get; set; }
    }
}