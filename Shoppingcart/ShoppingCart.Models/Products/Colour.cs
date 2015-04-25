using Shoppingcart.Infrastructure.Domain;
using Shoppingcart.Models;
using System;
using System.Collections.Generic;

namespace Shoppingcart.Models
{
    public class Colour: BaseEntity<int>,  IProductAttribute
    {
        public Colour()
        {
            this.ProductTitles = new HashSet<ProductTitle>();
        }
        public string Name { get; set; }
    
        public virtual ICollection<ProductTitle> ProductTitles { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
