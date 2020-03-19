using System.Collections;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Бренд
    /// </summary>
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        
        /// <summary>
        /// Список товаров данного бренда
        /// </summary>
        public virtual ICollection Products { get; set; }
    }
}
