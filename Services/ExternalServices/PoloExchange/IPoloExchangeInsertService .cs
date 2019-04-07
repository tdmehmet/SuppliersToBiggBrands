using SuppliersToBiggBrands.AppModels;

namespace SuppliersToBiggBrands.Services.ExternalServices.PoloExchange
{
    public interface IPoloExchangeInsertService
    {
        void InsertPoloExchangeProducts(AppConfiguration appConfiguration);
    }
}
