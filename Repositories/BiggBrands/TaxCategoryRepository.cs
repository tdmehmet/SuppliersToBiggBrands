using System;
using SuppliersToBiggBrands.Config;
using SuppliersToBiggBrands.BiggBrands;
using System.Linq;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public class TaxCategoryRepository : GenericRepository<TaxCategory>, ITaxCategoryRepository
    {
        public TaxCategoryRepository(BiggBrandsContext biggBrandsContext) : base(biggBrandsContext)
        {
        }

        public TaxCategory FindTaxCategoryByName(string name) {
            return this._entities.TaxCategory.Where(taxCategory => taxCategory.Name == name).FirstOrDefault();
        }
    }
}
