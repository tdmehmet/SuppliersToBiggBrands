using System.Linq;
using SuppliersToBiggBrands.Config;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public class PictureRepository : GenericRepository<Picture>, IPictureRepository
    {
        public PictureRepository(BiggBrandsContext biggBrandsContext) : base(biggBrandsContext)
        {
        }

        public Picture FindPictureByResimUrl(string resimUrl) {
            return this._entities.Picture.Where(picture => picture.SeoFilename == resimUrl).FirstOrDefault();
        }
    }
}
