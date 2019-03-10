using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SuppliersToBiggBrands.AppModels
{
    [XmlRoot("Products")]
    public class PoloProductList
    {
        [XmlElement("Product")]
        public List<PoloProduct> PoloProducts { get; set; }
    }
}
