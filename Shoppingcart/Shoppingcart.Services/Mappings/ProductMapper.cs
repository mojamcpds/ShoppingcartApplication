using Shoppingcart.Models;
using Shoppingcart.Services.Messages;
using Shoppingcart.Services.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Services.Mappings
{
    public static class ProductMapper
    {
        public static GetProductsByCategoryResponse CreateProductSearchResultFrom(
        this IEnumerable<Product> productsMatchingRefinement,
        GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse productSearchResultView = new GetProductsByCategoryResponse();
            IEnumerable<ProductTitle> productsFound = productsMatchingRefinement.Select(p => p.ProductTitle).Distinct();
            productSearchResultView.SelectedCategory = request.CategoryId;
            productSearchResultView.NumberOfTitlesFound = productsFound.Count();
            productSearchResultView.TotalNumberOfPages = NoOfResultPagesGiven(request.NumberOfResultsPerPage, productSearchResultView.NumberOfTitlesFound);
            productSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(productsFound);
            productSearchResultView.Products = CropProductListToSatisfyGivenIndex(request.Index, request.NumberOfResultsPerPage, productsFound);
            return productSearchResultView;
        }
        private static IEnumerable<ProductSummaryView> CropProductListToSatisfyGivenIndex(int pageIndex, int numberOfResultsPerPage, IEnumerable<ProductTitle> productsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return productsFound.Skip(numToSkip)
                .Take(numberOfResultsPerPage).ConvertToProductViews();
            }
            else
                return productsFound
                .Take(numberOfResultsPerPage).ConvertToProductViews();
        }
        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfTitlesFound)
        {
            if (numberOfTitlesFound < numberOfResultsPerPage)
                return 1;
            else
            {
                return (numberOfTitlesFound / numberOfResultsPerPage) +
                (numberOfTitlesFound % numberOfResultsPerPage);
            }
        }
        private static IList<RefinementGroup> GenerateAvailableProductRefinementsFrom(IEnumerable<ProductTitle> productsFound)
        {
            var brandsRefinementGroup = productsFound
            .Select(p => p.Brand).Distinct().ToList()
            .ConvertAll<IProductAttribute>(b => (IProductAttribute)b)
            .ConvertToRefinementGroup(RefinementGroupings.brand);
            var colorsRefinementGroup = productsFound
            .Select(p => p.Colour).Distinct().ToList()
            .ConvertAll<IProductAttribute>(c => (IProductAttribute)c)
            .ConvertToRefinementGroup(RefinementGroupings.color);
            var sizesRefinementGroup = (from p in productsFound
                                        from si in p.Products
                                        select si.Size).Distinct().ToList()
            .ConvertAll<IProductAttribute>(s => (IProductAttribute)s)
            .ConvertToRefinementGroup(RefinementGroupings.size);
            IList<RefinementGroup> refinementGroups = new List<RefinementGroup>();
            refinementGroups.Add(brandsRefinementGroup);
            refinementGroups.Add(colorsRefinementGroup);
            refinementGroups.Add(sizesRefinementGroup);
            return refinementGroups;
        }
    }
}
