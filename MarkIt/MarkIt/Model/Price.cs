namespace MarkIt.Model
{
    public class Price
    {
        public decimal Value { get; set; }
        public Market Market { get; set; }
        public Product Product { get; set; }
    }
}