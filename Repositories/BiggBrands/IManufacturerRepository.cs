using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface IManufacturerRepository : IGenericRepository<Manufacturer>
    {
        Manufacturer FindManufacturerByName(string manufacturerName);
    }
}
