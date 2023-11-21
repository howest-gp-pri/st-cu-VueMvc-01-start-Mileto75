using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities
{
    public class Product : BaseEntity
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
