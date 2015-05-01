using Shoppingcart.Services.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Controllers.ViewModels
{
    public class ProductDetailView : BaseProductCatalogPageView
    {
        public ProductView Product { get; set; }
    }
}
