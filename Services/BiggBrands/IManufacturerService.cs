using System.Collections.Generic;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public interface IManufacturerService
    {
        Manufacturer AddManuFacturer(Manufacturer manufacturer);
        void InsertOrUpdateProductManufacturerMapping(Product product, string marka);
        List<Manufacturer> FindAllManufacturers();
    }
}
