using System;
using System.Collections.Generic;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public interface IProductManufacturerMappingService
    {
        List<ProductManufacturerMapping> FindAllProductManufacturerMappings();
        void AddProductManufacturerMapping(ProductManufacturerMapping productManufacturerMapping);
    }
}
