using System;
using System.Collections.Generic;
using SuppliersToBiggBrands.Repositories.BiggBrands;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public class TaxCategoryService : ITaxCategoryService
    {
        private readonly ITaxCategoryRepository _thyMenaTaxCategoryRepository;
        
        public TaxCategoryService(ITaxCategoryRepository thyMenaTaxCategoryRepository
                                     )
        {
            _thyMenaTaxCategoryRepository = thyMenaTaxCategoryRepository;
        }

        public List<TaxCategory> FindAllTaxCategories()
        {
            return _thyMenaTaxCategoryRepository.FindAllItems();
        }

    }
}
