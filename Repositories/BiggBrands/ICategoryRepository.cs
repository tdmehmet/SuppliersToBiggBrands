using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category FindCategoryByName(string categoryName);
        Category FindCategoryById(int categoryId);
    }
}
