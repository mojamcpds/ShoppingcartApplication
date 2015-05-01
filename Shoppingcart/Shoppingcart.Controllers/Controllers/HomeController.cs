using Shoppingcart.Controllers.ViewModels;
using Shoppingcart.Services.Facades;
using Shoppingcart.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shoppingcart.Controllers.Controllers
{
    public class HomeController : ProductCatalogBaseController
    {
        private readonly IProductCatalogService _productCatalogService;
        public HomeController(IProductCatalogService productCatalogService)
            : base(productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }
        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();
            GetFeaturedProductsResponse response =
            _productCatalogService.GetFeaturedProducts();
            homePageView.Products = response.Products;
            return View(homePageView);
        }
    }
}
