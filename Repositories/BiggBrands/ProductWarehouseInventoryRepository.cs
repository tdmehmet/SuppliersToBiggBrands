using SuppliersToBiggBrands.BiggBrands;
using SuppliersToBiggBrands.Config;
using SuppliersToBiggBrands.Repositories.BiggBrands;
using System.Linq;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public class ProductWarehouseInventoryRepository : GenericRepository<ProductWarehouseInventory>, IProductWarehouseInventoryRepository
    {
        public ProductWarehouseInventoryRepository(BiggBrandsContext biggBrandsProductDBContext) : base(biggBrandsProductDBContext)
        {
        }

        public ProductWarehouseInventory FindProductWarehouseInventoryByProductIdWarehouseId(int productId, int warehouseId)
        {
            return _entities.ProductWarehouseInventory.Where(pwi => pwi.ProductId == productId && 
                        pwi.WarehouseId == warehouseId).FirstOrDefault();
        }
    }
}
