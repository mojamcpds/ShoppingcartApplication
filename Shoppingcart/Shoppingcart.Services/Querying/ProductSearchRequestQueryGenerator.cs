using Shoppingcart.Models;
using Shoppingcart.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Services.Querying
{
    public class ProductSearchRequestQueryGenerator
    {
       
        public static Expression<Func<Product, bool>> CreateQuery(GetProductsByCategoryRequest getProductsByCategoryRequest)
        {
            var predicate = PredicateBuilder.Create<Product>(item => true);

            predicate = x => x.ProductTitle.Category.Id == getProductsByCategoryRequest.CategoryId;

            //Add Filter by BrandId
            if (getProductsByCategoryRequest.BrandIds != null && getProductsByCategoryRequest.BrandIds.Count() > 0)
                predicate = predicate.Or(y => getProductsByCategoryRequest.BrandIds.Contains(y.ProductTitle.Brand.Id));

            //Add Filter by ColorId
            if (getProductsByCategoryRequest.ColorIds != null && getProductsByCategoryRequest.ColorIds.Count() > 0)
                predicate = predicate.And(c => getProductsByCategoryRequest.ColorIds.Contains(c.ProductTitle.Colour.Id));

            //Add Filter by SizeIds
            if (getProductsByCategoryRequest.SizeIds != null && getProductsByCategoryRequest.SizeIds.Count() > 0)
                predicate = predicate.And(s => getProductsByCategoryRequest.SizeIds.Contains(s.Size.Id));

            return predicate;

        }
    }
}
