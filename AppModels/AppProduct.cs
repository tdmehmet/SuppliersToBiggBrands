using System;
using Newtonsoft.Json.Linq;

namespace SuppliersToBiggBrands.AppModels
{
    public class AppProduct
    {



        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string AdminComment { get; set; }
        public int? ProductTemplateId  { get; set; }
        public bool? ShowOnHomePage  { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SeName { get; set; }
        public bool? AllowCustomerReviews  { get; set; }
        public int? ApprovedRatingSum  { get; set; }
        public int? NotApprovedRatingSum  { get; set; }
        public int? ApprovedTotalReviews  { get; set; }
        public int? NotApprovedTotalReviews  { get; set; }
        public bool? Published { get; set; }
        public bool? Deleted { get; set; }
        public string LogoKodu { get; set; }
        public string KatalogKodu { get; set; }
        public int? CategoryID { get; set; }
        public string Marka { get; set; }
        public int? Stok { get; set; }
        public decimal? Fiyat { get; set; }
        public decimal? ProductCost { get; set; }
        public decimal? BuyingPrice { get; set; }
        public decimal? PSF { get; set; }
        public int? Desi { get; set; }
        public bool? Status { get; set; }
        public int? TaxID { get; set; }
        public string Resim1 { get; set; }
        public double? SMPara { get; set; }
        public string SMParaBirim { get; set; }
        public string ProjectName { get; set; }
        public string SabitProjectName { get; set; }
        public string Gtin { get; set; }
        public string StoreCode { get; set; }
        public int TaxCategory { get; set; }
        public decimal PSFIN { get; set; }
        public decimal TLToAEDRate { get; set; }

    }
}
