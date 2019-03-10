using System;
using System.Collections.Generic;
using SuppliersToBiggBrands.Config;
using SuppliersToBiggBrands.BiggBrands;
using System.Linq;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public class ProductPictureMappingRepository : GenericRepository<ProductPictureMapping>, IProductPictureMappingRepository
    {

        public ProductPictureMappingRepository(BiggBrandsContext biggBrandsContext) : base(biggBrandsContext)
        {

        }

        public List<ProductPictureMapping> FindAllProductPictureMappingsByProductId(int productId)
        {
            return this._entities.ProductPictureMapping.Where(productPictureMapping => 
                                                       productPictureMapping.ProductId == productId).ToList();
        }
    }
}
