using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface IProductManufacturerMappingRepository : IGenericRepository<ProductManufacturerMapping>
    {
        ProductManufacturerMapping FindByProductId(int productId);
    }
}
