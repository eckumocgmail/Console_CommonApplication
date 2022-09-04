using DataCommon;

using DataEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
 

using MvcDeliveryAuth.Domains.Medical;


using System.Linq;
/*
namespace MvcDeliveryAuth.Data
{


    /// <summary>
    /// Модуль интеграции сервиса интернет доставки
    /// </summary>
    public class DeliveryModule
    {
        private static ILogger<DeliveryModule> Logger =
           LoggerFactory.Create(options=>options.AddConsole())
               .CreateLogger<DeliveryModule>();

        /// <summary>
        /// Конфигурация базового сервиса продажи телефонов
        /// </summary>        
        public void ConfigureServices(IConfiguration Configuration, IServiceCollection services)
        {
            
            services.AddSingleton<MedicalDbInitializer>();
            services.AddSingleton<DeliveryDbContextInitiallizer>();
       
            //services.AddSingleton<IDeliveryDbContext<PhoneCustomer, PhoneItem, PhoneHolder>, AppDbContext>();
            //services.AddScoped<IDeliveryDbContext<MedicalCustomer, MedicalServices, MedicalStore>, DeliveryDbContext>();
            services.AddScoped< CatalogDataModel>();
            services.AddScoped(typeof(IUnitOfWork<ProductHolder<MedicalServices>>), sp => new UnitOfWork<ProductHolder<MedicalServices>>(sp.GetService<DeliveryDbContext<MedicalCustomer, MedicalServices, MedicalStore>>()));
            services.AddScoped(typeof(IUnitOfWork<ProductItem>), sp => {
                Logger.LogInformation($@"Get({typeof(IUnitOfWork<ProductItem>).GetTypeName()})");
                UnitOfWork<ProductItem> productItemUOW = new UnitOfWork<ProductItem>(
                    sp.GetService<CatalogDataModel>()
                );
                return productItemUOW;
            });
            services.AddSingleton(typeof(IUnitOfWork<ProductImage>), sp => new UnitOfWork<ProductImage>(sp.GetService<DeliveryDbContext<MedicalCustomer, MedicalServices, MedicalStore>>()));
            services.AddSingleton(typeof(IUnitOfWork<ProductsInStock>), sp => new UnitOfWork<ProductsInStock>(sp.GetService<DeliveryDbContext<MedicalCustomer, MedicalServices, MedicalStore>>()));
            services.AddSingleton(typeof(IUnitOfWork<SaleOrder<MedicalServices>>), sp => new UnitOfWork<SaleOrder<MedicalServices>>(sp.GetService<DeliveryDbContext<MedicalCustomer, MedicalServices, MedicalStore>>()));

        }



        /// <summary>
        /// Регистраци бизнес сервисов 
        /// </summary>
        /// <typeparam name="TCustomer">Целевая группа</typeparam>
        /// <typeparam name="TItem">Продаваемая продукция</typeparam>
        /// <typeparam name="THolder">Диллерская компания</typeparam>  
        public static void ConfigureTestServices<TCustomer, TItem, THolder>(IServiceCollection services, IConfiguration config)
                                    where TCustomer :   ProductCustomer<TItem>
                                    where TItem :       SaleItem
                                    where THolder :     ProductHolder<TItem>
         {
            services.AddDbContext<DeliveryDbContext<TCustomer, TItem, THolder>>(options => options.UseInMemoryDatabase(nameof(DeliveryDbContext<TCustomer, TItem, THolder>)));
            services.AddSingleton(typeof(IUnitOfWork<TItem>), sp => new UnitOfWork<SaleItem>(sp.GetService<DeliveryDbContext<TCustomer, TItem, THolder>>()));
            services.AddSingleton(typeof(IUnitOfWork<ProductCustomer<TItem>>), sp => new UnitOfWork<ProductCustomer<TItem>>(sp.GetService<DeliveryDbContext<TCustomer, TItem, THolder>>()));
            services.AddSingleton<IKeywordsParserService, StupidKeywordsParserService>();
        }
    }
} */