using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Services.Viewmodels
{
    public class ProductView
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public IEnumerable<ProductSizeOption> Products { get; set; }
    }
}
