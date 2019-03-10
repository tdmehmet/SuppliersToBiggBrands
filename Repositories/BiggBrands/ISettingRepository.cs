using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface ISettingRepository : IGenericRepository<Setting>
    {
        Setting FindSettingByName(string settingName);
    }

    
}
