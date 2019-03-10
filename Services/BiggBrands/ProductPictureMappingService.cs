using System.Collections.Generic;
using SuppliersToBiggBrands.Repositories.BiggBrands;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
	public class ProductPictureMappingService : IProductPictureMappingService
    {
        private readonly IProductPictureMappingRepository _thyMenaProductPictureMappingRepository;
        
        public ProductPictureMappingService(
            IProductPictureMappingRepository thyMenaProductPictureMappingRepository
            )
        {
            _thyMenaProductPictureMappingRepository = thyMenaProductPictureMappingRepository;
        }

        public List<ProductPictureMapping> FindAllProductPictureMappings()
        {
            return _thyMenaProductPictureMappingRepository.FindAllItems();
        }
    }
}
