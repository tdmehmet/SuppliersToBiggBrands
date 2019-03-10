using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.BiggBrands;
using System.Collections.Generic;

namespace SuppliersToBiggBrands.Repositories.BiggBrands
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        void SetProductsAsUpdatedFalse();
        bool ProductExistsOnDB(AppProduct appProduct);
        Product FindProductByLogoCode(string logoCode);
        List<Product> FindAllProducts();
    }
}
