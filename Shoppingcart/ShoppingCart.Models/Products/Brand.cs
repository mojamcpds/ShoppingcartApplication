using Shoppingcart.Infrastructure.Domain;
using Shoppingcart.Models;
using System;
using System.Collections.Generic;


namespace Shoppingcart.Models
{
    public class Brand : BaseEntity<int>, IProductAttribute
    {
        public Brand()
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
