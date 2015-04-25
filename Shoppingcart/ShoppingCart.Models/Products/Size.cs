
using Shoppingcart.Infrastructure.Domain;
using System;
using System.Collections.Generic;

namespace Shoppingcart.Models
{
    public class Size : BaseEntity<int>,  IProductAttribute
    {
        public Size()
        {
            this.Products = new HashSet<Product>();
        }
    
        public string Name { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
