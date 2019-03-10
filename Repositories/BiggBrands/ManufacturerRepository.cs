using SuppliersToBiggBrands.BiggBrands;
using SuppliersToBiggBrands.Config;
using System.Linq;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(BiggBrandsContext biggBrandsContext) : base(biggBrandsContext)
        {
        }

        public Manufacturer FindManufacturerByName(string manufacturerName) {
            return this._entities.Manufacturer.Where(manufacturer => manufacturer.Name == manufacturerName).FirstOrDefault();
        }
    }
}
