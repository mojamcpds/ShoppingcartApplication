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
    public static class CategoryMapper
    {
        public static IEnumerable<CategoryView> ConvertToCategoryViews(
        this IEnumerable<Category> categories)
        {
            return Mapper.Map<IEnumerable<Category>,
            IEnumerable<CategoryView>>(categories);
        }
    }
}
