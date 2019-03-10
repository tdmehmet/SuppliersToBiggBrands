using System.Linq;
using SuppliersToBiggBrands.Config;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        public SettingRepository(BiggBrandsContext biggBrandsContext) : base(biggBrandsContext)
        {
        }

        public Setting FindSettingByName(string settingName)
        {
            return this._entities.Setting.Where(setting => setting.Name == settingName).FirstOrDefault();
        }
    }
}
