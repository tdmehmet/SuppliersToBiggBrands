﻿using SuppliersToBiggBrands.BiggBrands;
using System.Collections.Generic;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface IProductCategoryMappingRepository : IGenericRepository<ProductCategoryMapping>
    {
        ProductCategoryMapping FindByProductIdCategoryId(int productId, int categoryId);
        ProductCategoryMapping FindByProductIdNoXmlUpdateIsUpdated(int productId, bool noXmlUpdate, bool isUpdated);
        List<ProductCategoryMapping> FindAllProductCategoryMappings();
    }
}
