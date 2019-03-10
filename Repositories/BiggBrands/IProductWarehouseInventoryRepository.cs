
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface IProductWarehouseInventoryRepository : IGenericRepository<ProductWarehouseInventory>
    {
        ProductWarehouseInventory FindProductWarehouseInventoryByProductIdWarehouseId(int productId, int warehouseId);
    }
}
