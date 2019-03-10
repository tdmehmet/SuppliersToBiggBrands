using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public interface ISettingService
    {
        Setting FindSettingByName(string settingName);
        decimal FindTaxCategoryFactorBySettingName(string settingName);
    }
}
