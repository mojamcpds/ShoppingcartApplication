using AutoMapper;
using Shoppingcart.Models;
using Shoppingcart.Services.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Services.Mappings
{
    public static class IProductAttributeMapper
    {
        public static RefinementGroup ConvertToRefinementGroup(this IEnumerable<IProductAttribute> productAttributes,
        RefinementGroupings refinementGroupType)
        {
            RefinementGroup refinementGroup = new RefinementGroup()
            {
                Name = refinementGroupType.ToString(),
                GroupId = (int)refinementGroupType
            };
            refinementGroup.Refinements =
            Mapper.Map<IEnumerable<IProductAttribute>,
            IEnumerable<Refinement>>(productAttributes);
            return refinementGroup;
        }
    }
}
