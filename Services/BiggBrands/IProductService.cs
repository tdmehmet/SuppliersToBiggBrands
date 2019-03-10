using System;
using System.Collections.Generic;
using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public interface IProductService
    {
        void SetProductsAsUpdatedFalse();
        bool ProductExistsOnDB(AppProduct appProduct);
        Product ConvertAppProductToTHYProduct(AppProduct appProduct);
        Product AddProduct(Product product);
        Product FindProductByLogoCode(string logoCode);
        Product GenerateProductToUpdate(Product product, AppProduct appProduct);
        List<Product> FindAllProducts();
        void UpdateProduct(Product product);
        void UpdateProductRange(List<Product> products);
        void AddProductRange(List<Product> products);
    }
}
