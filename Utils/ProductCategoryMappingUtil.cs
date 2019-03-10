using System.Linq;
using System.Collections.Generic;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Utils
{
    public static class ProductCategoryMappingUtil
    {

        public static List<ProductCategoryMapping> GenerateProductCategoryMappings(
            List<Category> categories,
            int? categoryId,
            Product product, 
            List<ProductCategoryMapping> productCategoryMappings)
        {
            List<ProductCategoryMapping> productCategoryMappingList = new List<ProductCategoryMapping>();

            Category category = categories.Where(c => c.Id == (categoryId ?? 0)).FirstOrDefault();
            category = category ?? categories.Where(c => c.Name == "Other").FirstOrDefault();

            ProductCategoryMapping productCategoryMapping = productCategoryMappings
                .Where(pcm => pcm.ProductId == product.Id )
                .FirstOrDefault();
            
            if (productCategoryMapping != null)
            {
                productCategoryMapping.CategoryId = category.Id;
            }
            else
            {
                productCategoryMapping = productCategoryMappings
                    .Where(pcm => pcm.ProductId == product.Id && pcm.CategoryId == category.Id).FirstOrDefault();
                if (productCategoryMapping == null)
                {
                    productCategoryMapping = new ProductCategoryMapping()
                    {
                        ProductId = product.Id,
                        CategoryId = category.Id,
                        IsFeaturedProduct = false,
                        DisplayOrder = 0,
                    };
                }
            }
            productCategoryMappingList.Add(productCategoryMapping);
            return productCategoryMappingList;
        }
    }
}
