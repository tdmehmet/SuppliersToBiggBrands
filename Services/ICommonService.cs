using SuppliersToBiggBrands.AppModels;

namespace SuppliersToBiggBrands.Services
{
    public interface ICommonService
    {
        void TransferProductsFromPoloExchangeRepository(AppConfiguration appConfiguration);
    }
}
