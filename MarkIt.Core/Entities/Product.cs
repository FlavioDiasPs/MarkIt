namespace MarkIt.Core.Entities 
{
    public class Product : Base.EntityBase
    {        
        public string Name { get; set; }
        public double Price { get; set; }
        public Price _Price { get; set; }

        public override string ToString()
        {
            return $"{Name}, {_Price?.Valor.ToString()}";
        }
    }    
}
