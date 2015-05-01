using Shoppingcart.Services.Facades;
using Shoppingcart.Services.Messages;
using Shoppingcart.Services.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoppingcart.Controllers.Controllers
{
    public class ProductCatalogBaseController:Controller
    {
        private readonly IProductCatalogService _productCatalogService;
        public ProductCatalogBaseController(IProductCatalogService productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }
        public IEnumerable<CategoryView> GetCategories()
        {
            GetAllCategoriesResponse response = _productCatalogService.GetAllCategories();
            return response.Categories;
        }
    }
}
