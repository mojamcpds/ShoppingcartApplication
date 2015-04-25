
using Shoppingcart.Infrastructure.Domain;
using System;
using System.Collections.Generic;

namespace Shoppingcart.Models
{
    public class Product : BaseEntity<int>, IAggregateRoot
    {

        public string Name
        {
            get { return ProductTitle.ProductName; }
        }

        public Decimal Price
        {
            get { return ProductTitle.Price; }
        }
        public Brand Brand
        {
            get { return ProductTitle.Brand; }
        }
        public Colour Colour
        {
            get { return ProductTitle.Colour; }
        }

        public Category Category
        {
            get { return ProductTitle.Category; }
        }
        public Nullable<int> SizeId { get; set; }
        public int ProductTitleId { get; set; }
    
        public virtual ProductTitle ProductTitle { get; set; }
        public virtual Size Size { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
