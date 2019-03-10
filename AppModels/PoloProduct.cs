
using System.Xml;
using System.Xml.Serialization;

namespace SuppliersToBiggBrands.AppModels
{
    public class PoloProduct
    {
        [XmlElement("ÜrünKodu")]
        public string ProductCode { get; set; }
        [XmlElement("Product_id")]
        public string ProductId { get; set; }
        [XmlElement("ÜrünAdı")]
        public string Name { get; set; }
        [XmlElement("mainCategory")]
        public string MainCategory { get; set; }
        [XmlElement("mainCategory_id")]
        public string MainCategoryId { get; set; }
        [XmlElement("category")]
        public string Category { get; set; }
        [XmlElement("category_id")]
        public string CategoryId { get; set; }
        [XmlElement("subCategory")]
        public string SubCategory { get; set; }
        [XmlElement("subCategory_id")]
        public string SubCategoryId { get; set; }
        [XmlElement("ListeFiyatı")]
        public string Price { get; set; }
        [XmlElement("AlışFiyatı")]
        public string BuyingPrice { get; set; }
        [XmlElement("ParaBirimi")]
        public string CurrencyType { get; set; }
        [XmlElement("Kdv")]
        public string Tax { get; set; }
        [XmlElement("StokAdeti")]
        public string Stock { get; set; }
        [XmlElement("Marka")]
        public string Brand { get; set; }
        [XmlElement("Image1")]
        public string Image1 { get; set; }
        [XmlElement("Image2")]
        public string Image2 { get; set; }
        [XmlElement("Image3")]
        public string Image3 { get; set; }
        [XmlElement("Image4")]
        public string Image4 { get; set; }
        [XmlElement("Image5")]
        public string Image5 { get; set; }
        [XmlElement("Özellik")]
        public string Description { get; set; }
    }
}
