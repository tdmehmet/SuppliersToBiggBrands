using SuppliersToBiggBrands.BiggBrands;
using System.Collections.Generic;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface IProductPictureMappingRepository : IGenericRepository<ProductPictureMapping>
    {
        List<ProductPictureMapping> FindAllProductPictureMappingsByProductId(int productId);
    }
}
