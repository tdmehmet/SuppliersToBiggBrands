using System.Collections.Generic;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public interface IPictureService
    {
        List<Picture> FindAllPictures();
        void InsertOrUpdatePictureProductMapping(Product product, string pictures);
    }
}
