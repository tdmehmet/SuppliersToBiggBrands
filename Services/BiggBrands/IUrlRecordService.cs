using System;
using System.Collections.Generic;
using SuppliersToBiggBrands.BiggBrands;

namespace SuppliersToBiggBrands.Services.BiggBrands
{
    public interface IUrlRecordService
    {
        List<UrlRecord> FindAllUrlRecords();
        void SaveURLRecords(List<UrlRecord> urlRecords);
        void UpdateURLRecords(List<UrlRecord> urlRecords);
        void UpdateURLForProduct(Product product);
        UrlRecord GenerateUrlRecordForProduct(Product product);
        List<UrlRecord> FindUrlRecordsForProductToUpdate(Product product);
        List<UrlRecord> FindUrlRecordsForProductToSave(Product product);
    }
}
