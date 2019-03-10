using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface IPictureRepository : IGenericRepository<Picture>
    {
        Picture FindPictureByResimUrl(string resimUrl);
    }
}
