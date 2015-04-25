using Shoppingcart.Infrastructure.Domain;
using System;
using System.Collections.Generic;

namespace Shoppingcart.Models
{
    public class Category : BaseEntity<int>, IAggregateRoot, IProductAttribute
    {
        public Category()
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
