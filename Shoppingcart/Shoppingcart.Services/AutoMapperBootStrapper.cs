using AutoMapper;
using Shoppingcart.Models;
using Shoppingcart.Services.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoppingcart.Infrastructure.Helpers;

namespace Shoppingcart.Services
{
    public class AutoMapperBootStrapper
    {

        public static void ConfigureAutoMapper()
        {
           
            // Product Title and Product
            Mapper.CreateMap<ProductTitle, ProductSummaryView>().ForMember(x => x.Name, p => p.MapFrom(y => y.ProductName));
            Mapper.CreateMap<ProductTitle, ProductView>().ForMember(x => x.Name, p => p.MapFrom(y => y.ProductName));
            Mapper.CreateMap<Product, ProductSummaryView>();
            Mapper.CreateMap<Product, ProductSizeOption>();
            // Category
            Mapper.CreateMap<Category, CategoryView>();

            // IProductAttribute
            Mapper.CreateMap<IProductAttribute, Refinement>();
            
            // Global Money Formatter
            Mapper.AddFormatter<MoneyFormatter>();
        }
    }
    public class MoneyFormatter : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            if (context.SourceValue is decimal)
            {
                decimal money = (decimal)context.SourceValue;
                return money.FormatMoney();
            }
            return context.SourceValue.ToString();
        }
    }
}
