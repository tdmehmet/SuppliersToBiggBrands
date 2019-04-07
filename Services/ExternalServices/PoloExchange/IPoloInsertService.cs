using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.BiggBrands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuppliersToBiggBrands.Services.ExternalServices.PoloExchange
{
    public interface IPoloExchangeService
    {
        List<PoloProduct> FindAllProducts();
    }
}
