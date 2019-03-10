using System;
using System.Collections.Generic;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public interface ITaxCategoryService
    {
        List<TaxCategory> FindAllTaxCategories();        
    }
}
