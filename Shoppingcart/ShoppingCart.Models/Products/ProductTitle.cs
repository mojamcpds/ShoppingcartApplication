using Shoppingcart.Infrastructure.Domain;
using System;
using System.Collections.Generic;

namespace Shoppingcart.Models
{
    public class ProductTitle : BaseEntity<int>, IAggregateRoot
    {
        public ProductTitle()
        {
            this.Products = new HashSet<Product>();
        }
    
        public string ProductName { get; set; }
        public int ColourId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Colour Colour { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
