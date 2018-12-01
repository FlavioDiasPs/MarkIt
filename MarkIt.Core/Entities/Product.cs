namespace MarkIt.Core.Entities 
{
    public class Product : Base.EntityBase
    {        
        public string Name { get; set; }
        public Price Price { get; set; }
    }
}
