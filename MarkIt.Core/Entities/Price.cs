namespace MarkIt.Core.Entities
{
    public class Price : Base.EntityBase
    {
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return $"{Valor}";
        }
    }
}