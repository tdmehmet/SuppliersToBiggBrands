using System;
using System.Linq;
using System.Collections.Generic;
using log4net;
using SuppliersToBiggBrands.Services.ExternalServices;
using SuppliersToBiggBrands.Services.BiggBrands;
using SuppliersToBiggBrands.Utils;
using SuppliersToBiggBrands.BiggBrands;
using SuppliersToBiggBrands.AppModels;

namespace SuppliersToBiggBrands.Services
{
    public class CommonService : ICommonService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CommonService));

        private readonly IProductService _productService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IPictureService _pictureService;
        private readonly IProductPictureMappingService _productPictureMappingService;
        private readonly ICategoryService _categoryService;
        private readonly IProductCategoryMappingService _productCategoryMappingService;
        private readonly ITaxCategoryService _taxCategoryService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductManufacturerMappingService _productManufacturerMappingService;
        private readonly ISettingService _settingService;
        private readonly IPoloExchangeService _poloExchangeService;
        private readonly IProductWarehouseInventoryService _biggBrandsProductWarehouseInventoryService;

        public CommonService(
            IProductService productService,
            IUrlRecordService urlRecordService,
            IPictureService pictureService,
            ICategoryService categoryService,
            ITaxCategoryService taxCategoryService,
            IManufacturerService manufacturerService,
            IPoloExchangeService thyMenaSettingService,
            IProductManufacturerMappingService productManufacturerMappingService,
            IProductPictureMappingService productPictureMappingService,
            IProductCategoryMappingService productCategoryMappingService,
            ISettingService settingService,
            IPoloExchangeService poloExchangeService,
            IProductWarehouseInventoryService biggBrandsProductWarehouseInventoryService
            )
        {
            _productService = productService;
            _urlRecordService = urlRecordService;
            _pictureService = pictureService;
            _productPictureMappingService = productPictureMappingService;
            _categoryService = categoryService;
            _productCategoryMappingService = productCategoryMappingService;
            _taxCategoryService = taxCategoryService;
            _manufacturerService = manufacturerService;
            _productManufacturerMappingService = productManufacturerMappingService;
            _settingService = settingService;
            _poloExchangeService = poloExchangeService;
            _biggBrandsProductWarehouseInventoryService = biggBrandsProductWarehouseInventoryService;
        }

        public void TransferProductsFromPoloExchangeRepository(AppConfiguration appConfiguration)
        {
            log.Info("Getting List of Products from Polo Products");
            List<PoloProduct> poloProducts = _poloExchangeService.FindAllProducts();
            log.Info("List of Products from Polo Products are Gathered");

            log.Info("Getting List of Products from Nop DB");
            List<Product> products = _productService.FindAllProducts();
            log.Info("List of Products from Nop DB are Gathered");

            log.Info("Getting List of Manufacturers from Nop DB");
            List<Manufacturer> manufacturers = _manufacturerService.FindAllManufacturers();
            log.Info("List of Manufacturers from Nop DB are Gathered");

            log.Info("Getting List of ProductManufacturerMappings from Nop DB");
            List<ProductManufacturerMapping> productManufacturerMappings =
                _productManufacturerMappingService.FindAllProductManufacturerMappings();
            log.Info("List of ProductManufacturerMappings from Nop DB are Gathered");

            log.Info("Getting List of Pictures from Nop DB");
            List<Picture> pictures = _pictureService.FindAllPictures();
            log.Info("List of Pictures from Nop DB are Gathered");

            log.Info("Getting List of ProductPictureMappings from Nop DB");
            List<ProductPictureMapping> productPictureMappings =
                _productPictureMappingService.FindAllProductPictureMappings();
            log.Info("List of ProductPictureMappings from Nop DB are Gathered");

            log.Info("Getting List of Categories from Nop DB");
            List<Category> categories = _categoryService.FindAllCategories();
            log.Info("List of Categories from Nop DB are Gathered");

            log.Info("Getting List of ProductCategoryMappings from Nop DB");
            List<ProductCategoryMapping> productCategoryMappings = _productCategoryMappingService.FindAllProductCategoryMappings();
            log.Info("List of ProductCategoryMappings from Nop DB are Gathered");

            log.Info("Getting List of Product Warehouse Inventories from Nop DB");
            List<ProductWarehouseInventory> productWarehouseInventories = _biggBrandsProductWarehouseInventoryService.FindAllProductWarehouseInventories();
            log.Info("List of Product Warehouse Inventories from Nop DB are Gathered");

            log.Info("Getting List of URLRecords from Nop DB");
            List<UrlRecord> urlRecords = _urlRecordService.FindAllUrlRecords();
            log.Info("List of URLRecords from Nop DB are Gathered");

            log.Info("Getting List of TaxCategories from Nop DB");
            List<TaxCategory> taxCategories =
                _taxCategoryService.FindAllTaxCategories();
            log.Info("List of TaxCategories from Nop DB are Gathered");


            log.Info("Generating Products List for Update");
            List<Product> productsToUpdate = new List<Product>();
            log.Info("Generating Product Warehouse Inventory List for Insert");
            List<ProductWarehouseInventory> productWarehouseInventoriesToInsert = new List<ProductWarehouseInventory>();
            log.Info("Generating Product Warehouse Inventory List for Update");
            List<ProductWarehouseInventory> productWarehouseInventoriesToUpdate = new List<ProductWarehouseInventory>();
            log.Info("Generating URL List for Insert");
            List<UrlRecord> urlsToInsert = new List<UrlRecord>();
            log.Info("Generating URL List for Update");
            List<UrlRecord> urlsToUpdate = new List<UrlRecord>();
            log.Info("Generating Product ProductManufacturer Mapping List To Insert");
            List<ProductManufacturerMapping> productManufacturerMappingsToInsert = new List<ProductManufacturerMapping>();

            foreach (PoloProduct poloProduct in poloProducts)
            {

                AppProduct appProduct = ProductUtil.ConvertSMReportToAppProduct(poloProduct);

                decimal taxID = appProduct.TaxID ?? 0;
                

                Product product = products.Where(p => p.Sku == appProduct.LogoKodu).FirstOrDefault();
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

                Manufacturer manufacturer = manufacturers.Where(m => m.Name == appProduct.Marka).FirstOrDefault();
                if (manufacturer == null)
                {
                    log.Info("Manufacturer " + appProduct.Marka + " is Being Inserted");
                    manufacturer = ManufacturerUtil.CreateManufacturerByBrand(appProduct.Marka);
                    manufacturer = _manufacturerService.AddManuFacturer(manufacturer);
                    manufacturers = _manufacturerService.FindAllManufacturers();
                }

                List<ProductManufacturerMapping> productManufacturerMappingList = productManufacturerMappings
                    .Where(pmm => pmm.ManufacturerId == manufacturer.Id && pmm.ProductId == product.Id)
                    .ToList();

                product.ProductManufacturerMapping = ProductManufacturerMappingUtil
                    .CreateProductManufacturerMappingList(product, manufacturer, productManufacturerMappingList);

                

                List<ProductPictureMapping> productPicutreMappingList = productPictureMappings.Where(ppm => ppm.ProductId == product.Id).ToList();

                product.ProductPictureMapping = ProductPictureMappingUtil
                    .GenerateProductPictureMappings(appProduct.Resim1, pictures, product, productPicutreMappingList);


                product.ProductCategoryMapping = ProductCategoryMappingUtil.GenerateProductCategoryMappings(categories,
                    appProduct.CategoryID,
                    product,
                    productCategoryMappings);

                urlsToUpdate.AddRange(ProductUtil.FindUrlRecordsForProductToUpdate(product, urlRecords));
                urlsToInsert.AddRange(ProductUtil.FindUrlRecordsForProductToSave(product, urlRecords));
                
                UrlRecord manufacturerUrlRecord = ManufacturerUtil.GetManufacturerUrlRecordForUpdate(urlRecords, manufacturer.Id, appProduct.Marka, urlsToUpdate);
                if (manufacturerUrlRecord != null) {
                    urlsToUpdate.Add(manufacturerUrlRecord);
                }else
                {
                    manufacturerUrlRecord = ManufacturerUtil.GetManufacturerUrlRecordForInsert(urlRecords, manufacturer.Id, appProduct.Marka, urlsToInsert);
                    if(manufacturerUrlRecord != null) { 
                        urlsToInsert.Add(manufacturerUrlRecord);
                    }
                }


                ProductWarehouseInventory productWarehouseInventory = ProductWarehouseInventoryUtil
                    .GenerateProductWarehouseInventoryForUpdate(product.Id, appConfiguration.WarehouseID, appProduct.Stok, productWarehouseInventories);
                if (productWarehouseInventory == null)
                {
                    productWarehouseInventory = ProductWarehouseInventoryUtil
                        .GenerateProductWarehouseInventoryForInsert(product.Id, appConfiguration.WarehouseID, appProduct.Stok);
                    productWarehouseInventories.Add(productWarehouseInventory);
                    productWarehouseInventoriesToInsert.Add(productWarehouseInventory);
                }
                else
                {
                    productWarehouseInventoriesToUpdate.Add(productWarehouseInventory);
                }

                Category category = categories.Where(c => c.Id == product.ProductCategoryMapping.FirstOrDefault().CategoryId).FirstOrDefault();
                UrlRecord categoryUrlRecord = CategoryUtil.GetCategoryUrlRecordForUpdate(urlRecords, category, urlsToUpdate);
                if (categoryUrlRecord != null)
                {
                    urlsToUpdate.Add(categoryUrlRecord);
                }
                else
                {
                    categoryUrlRecord = CategoryUtil.GetCategoryUrlRecordForInsert(urlRecords, category, urlsToInsert);
                    if (categoryUrlRecord != null)
                    {
                        urlsToInsert.Add(categoryUrlRecord);
                    }
                }
                productsToUpdate.Add(product);
            }
            log.Info("Updating Products");
            _productService.UpdateProductRange(productsToUpdate);
            log.Info("Saving Url Records");
            _urlRecordService.SaveURLRecords(urlsToInsert);
            log.Info("Updating Url Records");
            _urlRecordService.UpdateURLRecords(urlsToUpdate);
            log.Info("Saving Product Warehouse Inventories");
            _biggBrandsProductWarehouseInventoryService.InsertProductWarehouseInventories(productWarehouseInventoriesToInsert);
            log.Info("Updating Product Warehouse Inventories");
            _biggBrandsProductWarehouseInventoryService.UpdateProductWarehouseInventories(productWarehouseInventoriesToUpdate);
        }

    }
}
