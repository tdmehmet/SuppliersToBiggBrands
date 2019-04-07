using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuppliersToBiggBrands.Config;
using Microsoft.EntityFrameworkCore;
using SuppliersToBiggBrands.Services;
using log4net;
using log4net.Config;
using System.Reflection;
using System;
using SuppliersToBiggBrands.Services.BiggBrands;
using SuppliersToBiggBrands.Repositories.BiggBrands;
using SuppliersToBiggBrands.Services.ExternalServices;
using SuppliersToBiggBrands.Repositories.ExternalRepositories;
using SuppliersToBiggBrands.AppModels;
using SuppliersToBiggBrands.Services.ExternalServices.PoloExchange;

namespace SuppliersToBiggBrands
{
    class Program
    {


        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(@".\Properties\log4net.properties"));
            ILog log = LogManager.GetLogger(typeof(Program));
            try {
                ServiceCollection services = new ServiceCollection();
                IConfiguration configuration = ConfigureBuilder();
                ConfigureServices(configuration, services);
                ServiceProvider serviceProvider = services.BuildServiceProvider();

                serviceProvider.GetService<StartUp>().Run(configuration);
            }catch(Exception e) {
                LogException(log, e);
            }
        }

        static IConfiguration ConfigureBuilder() {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@".\Properties\db.properties")
                .AddJsonFile(@".\Properties\app.properties")
                .Build();
        }

        static void ConfigureServices(IConfiguration configuration, ServiceCollection services)
        {

            services.Configure<AppConfiguration>(configuration.GetSection("AppConfiguration"));

            services.AddDbContext<BiggBrandsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BiggBrandsContext")));

            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUrlRecordService, UrlRecordService>();
            services.AddTransient<IPictureService, PictureService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IManufacturerService, ManufacturerService>();
            services.AddTransient<IPoloExchangeService, PoloExchangeService>();
            services.AddTransient<IProductManufacturerMappingService, ProductManufacturerMappingService>();
            services.AddTransient<IProductPictureMappingService, ProductPictureMappingService>();
            services.AddTransient<IProductCategoryMappingService, ProductCategoryMappingService>();
            services.AddTransient<ITaxCategoryService, TaxCategoryService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<IProductWarehouseInventoryService, ProductWarehouseInventoryService>();

            services.AddTransient<IPoloExchangeRepository, PoloExchangeRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ITaxCategoryRepository, TaxCategoryRepository>();
            services.AddTransient<IUrlRecordRepository, UrlRecordRepository>();
            services.AddTransient<ISettingRepository, SettingRepository>();
            services.AddTransient<IPictureRepository, PictureRepository>();
            services.AddTransient<IProductPictureMappingRepository, ProductPictureMappingRepository>();
            services.AddTransient<CategoryRepository, CategoryRepository>();
            services.AddTransient<IProductCategoryMappingRepository, ProductCategoryMappingRepository>();
            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<IProductManufacturerMappingRepository, ProductManufacturerMappingRepository>();
            services.AddTransient<IProductManufacturerMappingRepository, ProductManufacturerMappingRepository>();
            services.AddTransient<IProductWarehouseInventoryRepository, ProductWarehouseInventoryRepository>();
            services.AddTransient<StartUp>();

        }

        private static void LogException(ILog log, Exception appException)
        {
            log.Error("***********************************************************************************************");

            log.Error("EXCEPTION SOURCE             : " + appException.Source);
            log.Error("EXCEPTION TARGETSITE         : " + appException.TargetSite);
            log.Error("EXCEPTION MESSAGE            : " + appException.Message);
            log.Error("EXCEPTION INNER EXCEPTION    : " + appException.InnerException);
            log.Error("EXCEPTION STACKTRACE         : " + appException.StackTrace);
            log.Error("EXCEPTION HELP LINK          : " + appException.HelpLink);
            log.Error("EXCEPTION HRESULT            : " + appException.HResult);
            log.Error("***********************************************************************************************");
        }
    }
}
