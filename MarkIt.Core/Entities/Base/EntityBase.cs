using System.ComponentModel.DataAnnotations;

namespace MarkIt.Core.Entities.Base
{
    public abstract class EntityBase
    {
        [Key, Required]
        public int Id { get; set; }
    }
}
