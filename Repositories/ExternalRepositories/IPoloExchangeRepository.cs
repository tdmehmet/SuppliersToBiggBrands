using SuppliersToBiggBrands.AppModels;
using System.Collections.Generic;

namespace SuppliersToBiggBrands.Repositories.ExternalRepositories
{
    public interface IPoloExchangeRepository
    {
        List<PoloProduct> FindAllProducts();
    }
}
