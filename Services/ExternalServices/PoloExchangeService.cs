using SuppliersToBiggBrands.Repositories.ExternalRepositories;
using System.Collections.Generic;
using SuppliersToBiggBrands.AppModels;

namespace SuppliersToBiggBrands.Services.ExternalServices
{
    public class PoloExchangeService : IPoloExchangeService
    {
        private readonly IPoloExchangeRepository _poloExchangeRepository;

        public PoloExchangeService(IPoloExchangeRepository poloExchangeRepository)
        {
            _poloExchangeRepository = poloExchangeRepository;
        }

        public List<PoloProduct> FindAllProducts()
        {
            return _poloExchangeRepository.FindAllProducts();
        }
    }
}
