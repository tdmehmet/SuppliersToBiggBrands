using System.Collections.Generic;
using log4net;
using SuppliersToBiggBrands.Services.ExternalServices;
using SuppliersToBiggBrands.Services.BiggBrands;
using SuppliersToBiggBrands.BiggBrands;
using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.Services.ExternalServices.PoloExchange;

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
        private readonly IPoloExchangeInsertService _poloExchangeInsertService;
        private readonly IProductWarehouseInventoryService _productWarehouseInventoryService;

        public CommonService(
            IProductService productService,
            IUrlRecordService urlRecordService,
            IPictureService pictureService,
            ICategoryService categoryService,
            ITaxCategoryService taxCategoryService,
            IManufacturerService manufacturerService,
            IProductManufacturerMappingService productManufacturerMappingService,
            IProductPictureMappingService productPictureMappingService,
            IProductCategoryMappingService productCategoryMappingService,
            ISettingService settingService,
            IPoloExchangeInsertService poloExchangeInsertService,
            IProductWarehouseInventoryService productWarehouseInventoryService
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
            _poloExchangeInsertService = poloExchangeInsertService;
            _productWarehouseInventoryService = productWarehouseInventoryService;
        }

        public void TransferProductsFromSuppliers(AppConfiguration appConfiguration)
        {
            log.Info("Getting List of Products from Nop DB");
            GenericService.products = _productService.FindAllProducts();
            log.Info("List of Products from Nop DB are Gathered");

            log.Info("Getting List of Manufacturers from Nop DB");
            GenericService.manufacturers = _manufacturerService.FindAllManufacturers();
            log.Info("List of Manufacturers from Nop DB are Gathered");

            log.Info("Getting List of ProductManufacturerMappings from Nop DB");
            GenericService.productManufacturerMappings =
                _productManufacturerMappingService.FindAllProductManufacturerMappings();
            log.Info("List of ProductManufacturerMappings from Nop DB are Gathered");

            log.Info("Getting List of Pictures from Nop DB");
            GenericService.pictures = _pictureService.FindAllPictures();
            log.Info("List of Pictures from Nop DB are Gathered");

            log.Info("Getting List of ProductPictureMappings from Nop DB");
            GenericService.productPictureMappings =
                _productPictureMappingService.FindAllProductPictureMappings();
            log.Info("List of ProductPictureMappings from Nop DB are Gathered");

            log.Info("Getting List of Categories from Nop DB");
            GenericService.categories = _categoryService.FindAllCategories();
            log.Info("List of Categories from Nop DB are Gathered");

            log.Info("Getting List of ProductCategoryMappings from Nop DB");
            GenericService.productCategoryMappings = _productCategoryMappingService.FindAllProductCategoryMappings();
            log.Info("List of ProductCategoryMappings from Nop DB are Gathered");

            log.Info("Getting List of Product Warehouse Inventories from Nop DB");
            GenericService.productWarehouseInventories = _productWarehouseInventoryService.FindAllProductWarehouseInventories();
            log.Info("List of Product Warehouse Inventories from Nop DB are Gathered");

            log.Info("Getting List of URLRecords from Nop DB");
            GenericService.urlRecords = _urlRecordService.FindAllUrlRecords();
            log.Info("List of URLRecords from Nop DB are Gathered");

            log.Info("Getting List of TaxCategories from Nop DB");
            GenericService.taxCategories =
                _taxCategoryService.FindAllTaxCategories();
            log.Info("List of TaxCategories from Nop DB are Gathered");

            log.Info("Generating Products List for Update");
            GenericService.productsToUpdate = new List<Product>();

            log.Info("Generating Product Warehouse Inventory List for Insert");
            GenericService.productWarehouseInventoriesToInsert = new List<ProductWarehouseInventory>();

            log.Info("Generating Product Warehouse Inventory List for Update");
            GenericService.productWarehouseInventoriesToUpdate = new List<ProductWarehouseInventory>();

            log.Info("Generating URL List for Insert");
            GenericService.urlsToInsert = new List<UrlRecord>();

            log.Info("Generating URL List for Update");
            GenericService.urlsToUpdate = new List<UrlRecord>();

            log.Info("Generating Product ProductManufacturer Mapping List To Insert");
            GenericService.productManufacturerMappingsToInsert = new List<ProductManufacturerMapping>();

            _poloExchangeInsertService.InsertPoloExchangeProducts(appConfiguration);
        }

    }
}
