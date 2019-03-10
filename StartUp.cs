using Microsoft.Extensions.Configuration;
using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.Services;

namespace SuppliersToBiggBrands
{
    public class StartUp
    {
        private readonly ICommonService _commonService;
        public StartUp(ICommonService commonService)
        {
            _commonService = commonService;
        }

        public void Run(IConfiguration configuration) 
        {
            AppConfiguration appConfiguration = new AppConfiguration
            {
                WarehouseID = configuration.GetValue<int>("AppConfiguration:WarehouseID"),
            };
            _commonService.TransferProductsFromPoloExchangeRepository(appConfiguration);
        }
    }
}
