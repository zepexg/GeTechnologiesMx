using Entity.Interface;
using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public abstract class BaseEntity { }
    public class Entity<T> : BaseEntity, IEntity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }
    }
}
