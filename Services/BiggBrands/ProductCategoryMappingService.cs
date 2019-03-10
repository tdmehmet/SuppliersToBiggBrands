using System;
using System.Collections.Generic;
using SuppliersToBiggBrands.Repositories.BiggBrands;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public class ProductCategoryMappingService : IProductCategoryMappingService
    {
        private readonly IProductCategoryMappingRepository _thyMenaProductCategoryMappingRepository;

        public ProductCategoryMappingService(
                                      IProductCategoryMappingRepository thyMenaProductCategoryMappingRepository
                                     )
        {
            _thyMenaProductCategoryMappingRepository = thyMenaProductCategoryMappingRepository;
        }

        public List<ProductCategoryMapping> FindAllProductCategoryMappings()
        {
            return _thyMenaProductCategoryMappingRepository.FindAllProductCategoryMappings();
        }

        public ProductCategoryMapping SaveProductCategoryMapping(ProductCategoryMapping productCategoryMapping)
        {
            ProductCategoryMapping savedProductCategoryMapping = _thyMenaProductCategoryMappingRepository.Add(productCategoryMapping);
            _thyMenaProductCategoryMappingRepository.Save();
            return savedProductCategoryMapping;
        }
    }
}
