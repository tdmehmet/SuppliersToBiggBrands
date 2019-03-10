using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface ITaxCategoryRepository : IGenericRepository<TaxCategory>
    {
        TaxCategory FindTaxCategoryByName(string name);
    }
}
