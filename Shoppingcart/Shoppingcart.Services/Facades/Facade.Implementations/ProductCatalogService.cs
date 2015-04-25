using Shoppingcart.Models;
using Shoppingcart.Repositories.Contracts;
using Shoppingcart.Services.Messages;
using Shoppingcart.Services.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shoppingcart.Services.Viewmodels.Products;
using Shoppingcart.Services.Mappings;
using Shoppingcart.Infrastructure.Helpers;
using Shoppingcart.Services.Querying;

namespace Shoppingcart.Services.Facades
{

    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductTitleRepository _productTitleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductCatalogService(IProductTitleRepository productTitleRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productTitleRepository = productTitleRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }


        private IEnumerable<Product> GetAllProductsMatchingQueryAndSort(GetProductsByCategoryRequest request, Expression<Func<Product, bool>> where)
        {
            IEnumerable<Product> productsMatchingRefinement = _productRepository.GetMany(where);
            switch (request.SortBy)
            {
                case ProductsSortBy.PriceLowToHigh:
                    productsMatchingRefinement = productsMatchingRefinement.OrderBy(p => p.Price);
                    break;
                case ProductsSortBy.PriceHighToLow:
                    productsMatchingRefinement = productsMatchingRefinement.OrderByDescending(p => p.Price);
                    break;
            }
            return productsMatchingRefinement;

        }


        public GetFeaturedProductsResponse GetFeaturedProducts()
        {
            GetFeaturedProductsResponse response = new GetFeaturedProductsResponse();
            response.Products = _productTitleRepository.GetAll().OrderByDescending(x => x.Price).Skip(0).Take(6).ConvertToProductViews();
                        
          
            return response;
        }


        public GetProductsByCategoryResponse GetProductsByCategory(GetProductsByCategoryRequest request)
        {

            GetProductsByCategoryResponse response;

            Expression<Func<Product, bool>> query = ProductSearchRequestQueryGenerator.CreateQuery(request);

            IEnumerable<Product> productsMatchingRefinement = GetAllProductsMatchingQueryAndSort(request, query);

            response = productsMatchingRefinement.CreateProductSearchResultFrom(request);
            response.SelectedCategoryName =  _categoryRepository.GetById(request.CategoryId).Name;

            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new GetProductResponse();

            ProductTitle productTitle = _productTitleRepository.GetById(request.ProductId);

            response.Product = productTitle.ConvertToProductDetailView();

            return response;
        }

        public GetAllCategoriesResponse GetAllCategories()
        {
            GetAllCategoriesResponse response = new GetAllCategoriesResponse();
            IEnumerable<Category> categories = _categoryRepository.GetAll();
            response.Categories = categories.ConvertToCategoryViews();

            return response;
        }


    }
}
