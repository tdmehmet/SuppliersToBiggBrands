using System;
using System.Linq;
using System.Collections.Generic;
using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Utils
{
    public static class ProductUtil
    {

        public static AppProduct ConvertSMReportToAppProduct(PoloProduct poloProduct)
        {

            double buyingPrice = ConversionUtil.ConvertStringToDoubleNotParsable0(poloProduct.Price);
            decimal buyingPriceDecimalValue = decimal.Parse(buyingPrice.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            return new AppProduct()
            {
                Name = poloProduct.Name?.TrimStart().TrimEnd(),
                ShortDescription = poloProduct.Description?.TrimStart().TrimEnd(),
                FullDescription = poloProduct.Description?.TrimStart().TrimEnd(),
                AdminComment = "",
                ProductTemplateId = 1,
                ShowOnHomePage = false,
                MetaKeywords = String.Empty,
                MetaDescription = String.Empty,
                SeName = String.Empty,
                AllowCustomerReviews = false,
                ApprovedRatingSum = 0,
                NotApprovedRatingSum = 0,
                NotApprovedTotalReviews = 0,
                Published = true,
                Deleted = false,
                LogoKodu = poloProduct.ProductCode?.Replace("-", "").Replace("PX", "PXC").TrimEnd().TrimStart(),
                KatalogKodu = poloProduct.ProductCode?.Replace("-", "").Replace("PX", "PXC").TrimEnd().TrimStart(),
                CategoryID = 325,
                Marka = "Polo Exchange",
                Stok = ConversionUtil.ConvertStringToIntNotParsable0(poloProduct.Stock),
                Fiyat = buyingPriceDecimalValue,
                ProductCost = buyingPriceDecimalValue,
                PSF = buyingPriceDecimalValue,
                Resim1 = GenerateImageString(poloProduct.Image1, poloProduct.Image2, poloProduct.Image3, poloProduct.Image4, poloProduct.Image5),
                Desi = 0,
                Status = true,
                TaxID = 1,
            };
        }

        public static string GenerateImageString(string image1, string image2, string image3, string image4, string image5)
        {
            string imageString = "";
            if(image1 != null)
            {
                imageString = image1;
                if(image2 != null)
                {
                    imageString = imageString + '#' + image2;
                    if(image3 != null)
                    {
                        imageString = imageString + '#' + image3;
                        if(image4 != null)
                        {
                            imageString = imageString + '#' + image4;
                            if(image5 != null)
                            {
                                imageString = imageString + '#' + image5;
                            }
                        }
                    }
                }
            }
            return imageString;
        }

        public static Product GenerateProductFromAppProduct(AppProduct appProduct) {

            return new Product()
            {
                Name = appProduct.Name?.TrimStart().TrimEnd(),
                FullDescription = appProduct.FullDescription?.TrimStart().TrimEnd(),
                ProductTemplateId = appProduct.ProductTemplateId ?? 1,
                VendorId = 0,
                ShowOnHomePage = false,
                AllowCustomerReviews = false,
                ApprovedRatingSum = 0,
                NotApprovedRatingSum = 0,
                ApprovedTotalReviews = 0,
                NotApprovedTotalReviews = 0,
                SubjectToAcl = false,
                LimitedToStores = false,
                Published = appProduct.Status.HasValue && appProduct.Status.Value,
                Deleted = appProduct.Deleted.HasValue && appProduct.Deleted.Value,
                CreatedOnUtc = DateTime.Now,
                UpdatedOnUtc = DateTime.Now,
                ProductTypeId = 5,
                Sku = appProduct.LogoKodu.Trim(),
                ManufacturerPartNumber = appProduct.KatalogKodu?.TrimStart().TrimEnd(),
                IsGiftCard = false,
                GiftCardTypeId = 0,
                RequireOtherProducts = false,
                AutomaticallyAddRequiredProducts = false,
                IsDownload = false,
                DownloadId = 0,
                UnlimitedDownloads = false,
                MaxNumberOfDownloads = 0,
                DownloadExpirationDays = 0,
                DownloadActivationTypeId = 0,
                HasSampleDownload = false,
                SampleDownloadId = 0,
                HasUserAgreement = false,
                IsRecurring = false,
                RecurringCycleLength = 0,
                RecurringCyclePeriodId = 0,
                RecurringTotalCycles = 0,
                IsShipEnabled = true,
                IsFreeShipping = false,
                AdditionalShippingCharge = 0,
                IsTaxExempt = false,
                TaxCategoryId = appProduct.TaxCategory,
                ManageInventoryMethodId = 1,
                StockQuantity = appProduct.Stok ?? 0,
                DisplayStockAvailability = false,
                DisplayStockQuantity = false,
                MinStockQuantity = 0,
                LowStockActivityId = 0,
                NotifyAdminForQuantityBelow = 0,
                BackorderModeId = 0,
                AllowBackInStockSubscriptions = true,
                OrderMinimumQuantity = 1,
                OrderMaximumQuantity = 100,
                AllowedQuantities = "1,2,3,4,5,6,7,8,9,10",
                DisableBuyButton = false,
                DisableWishlistButton = false,
                AvailableForPreOrder = false,
                CallForPrice = false,
                Price = appProduct.Fiyat ?? 0,
                ProductCost = appProduct.Fiyat ?? 0,
                CustomerEntersPrice = false,
                MinimumCustomerEnteredPrice = 0,
                MaximumCustomerEnteredPrice = 0,
                HasTierPrices = false,
                HasDiscountsApplied = false,
                Weight = appProduct.Desi ?? 0,
                Length = 0,
                Width = 0,
                Height = 0,
                VisibleIndividually = true,
                DisplayOrder = 1000,
                DeliveryDateId = 0,
                WarehouseId = 0,
                AllowAddingOnlyExistingAttributeCombinations = false,
                ShipSeparately = false,
                UseMultipleWarehouses = false,
                IsRental = false,
                RentalPriceLength = 0,
                RentalPricePeriodId = 0,
                IsTelecommunicationsOrBroadcastingOrElectronicServices = false,
                ParentGroupedProductId = 0,
                AbroadDesi = 0,
                ParcelDesi = 0,
                ParcelWeight = 0
            };
        }

        public static Product UpdateProductModel(Product product, AppProduct appProduct) {
           /* decimal fiyat = appProduct.Fiyat ?? 0;
            decimal psf = appProduct.PSF ?? 0;
            appProduct.PSFIN = MathUtil.CalculatePSFIN(fiyat, psf, appProduct.TaxID ?? 0);*/
            product.Name = appProduct.Name?.TrimEnd().TrimStart();
            product.ShortDescription = appProduct.ShortDescription?.TrimStart().TrimEnd();
            product.FullDescription = appProduct.FullDescription?.TrimStart().TrimEnd();
            product.UpdatedOnUtc = DateTime.Now;
            product.Deleted = appProduct.Deleted ?? false;
            product.Published = appProduct.Published ?? false;
            product.StockQuantity = product.StockQuantity + appProduct.Stok ?? 0;
            product.Price = appProduct.Fiyat ?? 0;
            product.ProductCost = appProduct.Fiyat ?? 0;
            product.Weight = appProduct.Desi ?? 0;
            product.ProductTemplateId = 2;
            return product;
        }

        public static List<UrlRecord> FindUrlRecordsForProductToUpdate(Product product, List<UrlRecord> allUrlRecords)
        {
            string slug = UrlUtil.ModifyUrl(product.Name);
            List<UrlRecord> urlRecordsList = allUrlRecords.Where(ur => ur.EntityId == product.Id && ur.EntityName == "Product").ToList();
            List<UrlRecord> urlRecordsToUpdate = new List<UrlRecord>();
            if (urlRecordsList != null && urlRecordsList.Count > 0)
            {
                UrlRecord urlRecord = urlRecordsList[0];
                urlRecord.Slug = slug;
                urlRecord.IsActive = true;
                urlRecord.LanguageId = 0;
                urlRecordsToUpdate.Add(urlRecord);
            }
            else
            {
                string tmpSlug = "";
                List<UrlRecord> urlRecords = allUrlRecords
                    .Where(ur => ur.Slug == slug && ur.EntityName == "Product" && ur.EntityId == product.Id).ToList();
                if (urlRecords != null && urlRecords.Count > 0)
                {
                    for (int i = 2; i < 6; i++)
                    {
                        tmpSlug = slug + i.ToString();
                        urlRecords = allUrlRecords.Where(ur =>
                            ur.Slug == tmpSlug && ur.EntityName == "Product" && ur.EntityId == product.Id).ToList();
                        if (urlRecords != null && urlRecords.Count > 0)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                UrlRecord urlRecord = allUrlRecords.Where(ur => ur.Slug == tmpSlug && ur.EntityName == "Product").FirstOrDefault();
                if (urlRecord != null)
                {
                    urlRecord.EntityId = product.Id;
                    urlRecordsToUpdate.Add(urlRecord);
                }
            }
            return urlRecordsToUpdate;
        }

        public static List<UrlRecord> FindUrlRecordsForProductToSave(Product product, List<UrlRecord> allUrlRecords)
        {
            string slug = UrlUtil.ModifyUrl(product.Name);
            List<UrlRecord> urlRecordsList = allUrlRecords.Where(ur => ur.EntityId == product.Id && ur.EntityName == "Product").ToList();
            List<UrlRecord> urlRecordsToSave = new List<UrlRecord>();
            if (urlRecordsList == null || urlRecordsList.Count == 0)
            {
                string tmpSlug = "";
                List<UrlRecord> urlRecords = allUrlRecords
                    .Where(ur => ur.Slug == slug && ur.EntityName == "Product" && ur.EntityId == product.Id).ToList();
                if (urlRecords != null && urlRecords.Count > 0)
                {
                    for (int i = 2; i < 6; i++)
                    {
                        tmpSlug = slug + i.ToString();
                        urlRecords = allUrlRecords.Where(ur => ur.Slug == slug && ur.EntityName == "Product" && ur.EntityId == product.Id).ToList();
                        if (urlRecords != null && urlRecords.Count > 0)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                UrlRecord urlRecord = allUrlRecords.Where(ur => ur.Slug == tmpSlug && ur.EntityName == "Product").FirstOrDefault();
                if (urlRecord == null)
                {
                    urlRecordsToSave.Add(new UrlRecord()
                    {
                        EntityId = product.Id,
                        EntityName = "Product",
                        Slug = string.IsNullOrEmpty(tmpSlug) ? slug : tmpSlug,
                        IsActive = true,
                        LanguageId = 0
                    });
                }

            }
            return urlRecordsToSave;
        }
    }
}
