using System.Collections.Generic;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public interface ICategoryService
    {
        List<Category> FindAllCategories();
        void InsertOrUpdateCategoryProductMapping(Product product, int? categoryId);
    }
}
