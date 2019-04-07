using SuppliersToBiggBrands.Repositories.ExternalRepositories;
using System.Collections.Generic;
using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.ExternalServices
{
    public abstract class GenericService
    {
        public static List<Product> products;
        public static List<Manufacturer> manufacturers;
        public static List<ProductManufacturerMapping> productManufacturerMappings;
        public static List<Picture> pictures;
        public static List<ProductPictureMapping> productPictureMappings;
        public static List<Category> categories;
        public static List<ProductCategoryMapping> productCategoryMappings;
        public static List<ProductWarehouseInventory> productWarehouseInventories;
        public static List<UrlRecord> urlRecords;
        public static List<TaxCategory> taxCategories;
        public static List<Product> productsToUpdate;
        public static List<ProductWarehouseInventory> productWarehouseInventoriesToInsert;
        public static List<ProductWarehouseInventory> productWarehouseInventoriesToUpdate;
        public static List<UrlRecord> urlsToInsert;
        public static List<UrlRecord> urlsToUpdate;
        public static List<ProductManufacturerMapping> productManufacturerMappingsToInsert;
    }
}
