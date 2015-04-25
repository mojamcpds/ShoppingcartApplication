using Shoppingcart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Services.Viewmodels.Products
{
    public static class IProductAttributeMapper
    {
        public static RefinementGroup ConvertToRefinementGroup(
                                this IEnumerable<IProductAttribute> productAttributes,
                                RefinementGroupings refinementGroupType)
        {
            RefinementGroup refinementGroup = new RefinementGroup()
            {
                Name = refinementGroupType.ToString(),
                GroupId = (int)refinementGroupType
            };

            refinementGroup.Refinements = from p in productAttributes
                                          select new Refinement
                                          {
                                              Id = p.Id,
                                              Name = p.Name
                                          };
            return refinementGroup;
        }
    }
}
