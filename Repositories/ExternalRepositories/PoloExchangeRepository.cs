using System.Collections.Generic;
using SuppliersToBiggBrands.Utils;
using SuppliersToBiggBrands.AppModels;
using System.Xml.Serialization;
using System.Net;
using System.IO;

namespace SuppliersToBiggBrands.Repositories.ExternalRepositories
{
    public class PoloExchangeRepository : IPoloExchangeRepository
    {

        public PoloExchangeRepository()
        {
        }

        public List<PoloProduct> FindAllProducts() {
            return ((PoloProductList)(new XmlSerializer(typeof(PoloProductList)))
                .Deserialize(new StringReader(new WebClient().DownloadString(Constants.POLO_EXCHANGE_URL)))).PoloProducts;
        }
    }
}
