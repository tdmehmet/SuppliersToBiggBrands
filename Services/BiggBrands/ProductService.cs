using System;
using System.Collections.Generic;
using log4net;
using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.Repositories.BiggBrands;
using SuppliersToBiggBrands.BiggBrands;
using SuppliersToBiggBrands.Utils;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _thyMenaProductRepository;
        private readonly ITaxCategoryRepository _thyMenaTaxCategoryRepository;
        private readonly ISettingRepository _thyMenaSettingRepository;
        private static readonly ILog log = LogManager.GetLogger(typeof(CommonService));

        public ProductService(IProductRepository thyMenaProductRepository,
                                     ITaxCategoryRepository thyMenaTaxCategoryRepository,
                                     ISettingRepository thyMenaSettingRepository)
        {
            _thyMenaProductRepository = thyMenaProductRepository;
            _thyMenaTaxCategoryRepository = thyMenaTaxCategoryRepository;
            _thyMenaSettingRepository = thyMenaSettingRepository;
        }

        public void SetProductsAsUpdatedFalse() {
            _thyMenaProductRepository.SetProductsAsUpdatedFalse();
        }

        public void UpdateProductRange(List<Product> products)
        {
            _thyMenaProductRepository.UpdateRange(products);
            _thyMenaProductRepository.Save();
        }

        public bool ProductExistsOnDB(AppProduct appProduct) {
            return _thyMenaProductRepository.ProductExistsOnDB(appProduct);
        }

        public Product ConvertAppProductToTHYProduct(AppProduct appProduct)
        {
            return ProductUtil.GenerateProductFromAppProduct(appProduct);
        }

        public Product AddProduct(Product product) {
            Product insertedProduct = _thyMenaProductRepository.Add(product);
            _thyMenaProductRepository.Save();
            return insertedProduct;
        }

        public void AddProductRange(List<Product> products)
        {
            _thyMenaProductRepository.AddRange(products);
            _thyMenaProductRepository.Save();
        }

        public Product FindProductByLogoCode(string logoCode) {
            return _thyMenaProductRepository.FindProductByLogoCode(logoCode);
        }

        
        public Product GenerateProductToUpdate(Product product, AppProduct appProduct)
        {
            return ProductUtil.UpdateProductModel(product, appProduct);
        }

        public void UpdateProduct(Product product)
        {
            _thyMenaProductRepository.Update(product);
            _thyMenaProductRepository.Save();
        }

        public List<Product> FindAllProducts()
        {
            return _thyMenaProductRepository.FindAllProducts();
        }



    }
}
