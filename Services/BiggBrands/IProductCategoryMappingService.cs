using System;
using System.Collections.Generic;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public interface IProductCategoryMappingService
    {
        List<ProductCategoryMapping> FindAllProductCategoryMappings();
        ProductCategoryMapping SaveProductCategoryMapping(ProductCategoryMapping productCategoryMapping);
    }
}
