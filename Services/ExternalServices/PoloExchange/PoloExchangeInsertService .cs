using System.Linq;
using System.Collections.Generic;
using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.Utils;
using SuppliersToBiggBrands.BiggBrands;
using log4net;
using SuppliersToBiggBrands.Services.BiggBrands;

namespace SuppliersToBiggBrands.Services.ExternalServices.PoloExchange
{
    public class PoloExchangeInsertService : IPoloExchangeInsertService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CommonService));

        private readonly IPoloExchangeService _poloExchangeService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductService _productService;
        private readonly IProductWarehouseInventoryService _productWarehouseInventoryService;
        private readonly IUrlRecordService _urlRecordService;


        public PoloExchangeInsertService(IPoloExchangeService poloExchangeService,
            IProductService productService,
            IManufacturerService manufacturerService,
            IProductWarehouseInventoryService productWarehouseInventoryService,
            IUrlRecordService urlRecordService)
        {
            _poloExchangeService = poloExchangeService;
            _productService = productService;
            _manufacturerService = manufacturerService;
            _productWarehouseInventoryService = productWarehouseInventoryService;
            _urlRecordService = urlRecordService;
        }

        public void InsertPoloExchangeProducts(AppConfiguration appConfiguration)
        {
            List<PoloProduct> poloProducts = _poloExchangeService.FindAllProducts();

            foreach (PoloProduct poloProduct in poloProducts)
            {

                AppProduct appProduct = ProductUtil.ConvertSMReportToAppProduct(poloProduct);

                decimal taxID = appProduct.TaxID ?? 0;


                Product product = GenericService.products.Where(p => p.Sku == appProduct.LogoKodu).FirstOrDefault();
                if (product == null)
                {
                    log.Info("Product LogoCode : " + appProduct.LogoKodu + " is Being Inserted");
                    product = ProductUtil.GenerateProductFromAppProduct(appProduct);
                    product = _productService.AddProduct(product);
                }
                else
                {
                    log.Info("Product LogoCode : " + appProduct.LogoKodu + " is Being Added To Update List");
                    product = ProductUtil.UpdateProductModel(product, appProduct);
                }

                Manufacturer manufacturer = GenericService.manufacturers.Where(m => m.Name == appProduct.Marka).FirstOrDefault();
                if (manufacturer == null)
                {
                    log.Info("Manufacturer " + appProduct.Marka + " is Being Inserted");
                    manufacturer = ManufacturerUtil.CreateManufacturerByBrand(appProduct.Marka);
                    manufacturer = _manufacturerService.AddManuFacturer(manufacturer);
                    GenericService.manufacturers = _manufacturerService.FindAllManufacturers();
                }

                List<ProductManufacturerMapping> productManufacturerMappingList = GenericService.productManufacturerMappings
                    .Where(pmm => pmm.ManufacturerId == manufacturer.Id && pmm.ProductId == product.Id)
                    .ToList();

                product.ProductManufacturerMapping = ProductManufacturerMappingUtil
                    .CreateProductManufacturerMappingList(product, manufacturer, productManufacturerMappingList);



                List<ProductPictureMapping> productPicutreMappingList = GenericService.productPictureMappings.Where(ppm => ppm.ProductId == product.Id).ToList();

                product.ProductPictureMapping = ProductPictureMappingUtil
                    .GenerateProductPictureMappings(appProduct.Resim1, GenericService.pictures, product, productPicutreMappingList);


                product.ProductCategoryMapping = ProductCategoryMappingUtil.GenerateProductCategoryMappings(GenericService.categories,
                    appProduct.CategoryID,
                    product,
                    GenericService.productCategoryMappings);

                GenericService.urlsToUpdate.AddRange(ProductUtil.FindUrlRecordsForProductToUpdate(product, GenericService.urlRecords));
                GenericService.urlsToInsert.AddRange(ProductUtil.FindUrlRecordsForProductToSave(product, GenericService.urlRecords));

                UrlRecord manufacturerUrlRecord = ManufacturerUtil.GetManufacturerUrlRecordForUpdate(GenericService.urlRecords, manufacturer.Id, appProduct.Marka, GenericService.urlsToUpdate);
                if (manufacturerUrlRecord != null)
                {
                    GenericService.urlsToUpdate.Add(manufacturerUrlRecord);
                }
                else
                {
                    manufacturerUrlRecord = ManufacturerUtil.GetManufacturerUrlRecordForInsert(GenericService.urlRecords, manufacturer.Id, appProduct.Marka, GenericService.urlsToInsert);
                    if (manufacturerUrlRecord != null)
                    {
                        GenericService.urlsToInsert.Add(manufacturerUrlRecord);
                    }
                }


                ProductWarehouseInventory productWarehouseInventory = ProductWarehouseInventoryUtil
                    .GenerateProductWarehouseInventoryForUpdate(product.Id, appConfiguration.WarehouseID, appProduct.Stok, GenericService.productWarehouseInventories);
                if (productWarehouseInventory == null)
                {
                    productWarehouseInventory = ProductWarehouseInventoryUtil
                        .GenerateProductWarehouseInventoryForInsert(product.Id, appConfiguration.WarehouseID, appProduct.Stok);
                    GenericService.productWarehouseInventories.Add(productWarehouseInventory);
                    GenericService.productWarehouseInventoriesToInsert.Add(productWarehouseInventory);
                }
                else
                {
                    GenericService.productWarehouseInventoriesToUpdate.Add(productWarehouseInventory);
                }

                Category category = GenericService.categories.Where(c => c.Id == product.ProductCategoryMapping.FirstOrDefault().CategoryId).FirstOrDefault();
                UrlRecord categoryUrlRecord = CategoryUtil.GetCategoryUrlRecordForUpdate(GenericService.urlRecords, category, GenericService.urlsToUpdate);
                if (categoryUrlRecord != null)
                {
                    GenericService.urlsToUpdate.Add(categoryUrlRecord);
                }
                else
                {
                    categoryUrlRecord = CategoryUtil.GetCategoryUrlRecordForInsert(GenericService.urlRecords, category, GenericService.urlsToInsert);
                    if (categoryUrlRecord != null)
                    {
                        GenericService.urlsToInsert.Add(categoryUrlRecord);
                    }
                }
                GenericService.productsToUpdate.Add(product);
            }
            log.Info("Updating Products");
            _productService.UpdateProductRange(GenericService.productsToUpdate);
            log.Info("Saving Url Records");
            _urlRecordService.SaveURLRecords(GenericService.urlsToInsert);
            log.Info("Updating Url Records");
            _urlRecordService.UpdateURLRecords(GenericService.urlsToUpdate);
            log.Info("Saving Product Warehouse Inventories");
            _productWarehouseInventoryService.InsertProductWarehouseInventories(GenericService.productWarehouseInventoriesToInsert);
            log.Info("Updating Product Warehouse Inventories");
            _productWarehouseInventoryService.UpdateProductWarehouseInventories(GenericService.productWarehouseInventoriesToUpdate);
        }

    }
}
