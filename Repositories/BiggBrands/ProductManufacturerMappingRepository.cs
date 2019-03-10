using System.Linq;
using SuppliersToBiggBrands.Config;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public class ProductManufacturerMappingRepository : GenericRepository<ProductManufacturerMapping>, IProductManufacturerMappingRepository
    {
        public ProductManufacturerMappingRepository(BiggBrandsContext biggBrandsContext) : base(biggBrandsContext)
        {
        }

        public ProductManufacturerMapping FindByProductId(int productId) {
            return this._entities.ProductManufacturerMapping.
                       Where(productManufacturerMapping => productManufacturerMapping.ProductId == productId).FirstOrDefault();
        }
    }
}
