using System.Collections.Generic;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities
{
    public class Category : BaseEntity
    {
        public ICollection<Product> Products { get; set; }
    }
}