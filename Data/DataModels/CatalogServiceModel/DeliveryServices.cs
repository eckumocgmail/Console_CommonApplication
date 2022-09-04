using Microsoft.EntityFrameworkCore;
using static Newtonsoft.Json.JsonConvert;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DataCommon;
using DataEntities;

/// <summary>
/// Пакет предсназначен для установки системы управления заказом
/// 1) Customer -> отправляет заказ
/// 2) Holder -> выдаёт заказ курьерской службе
/// 3) Transport -> доставляет заказ
/// Думаю следует выделить слой абстрации на 2-ух звенную модель (5 статусов) и 3-ех звенную (6 статусов)
/// 
/// OrderingContext<TCustomer,TOrderItem,THolder>(IOrderingConfiguration){}

/// 
/// </summary>
/// 
/*
public class OrderingContext<TCustomer, TItem, THolder> : IHostingStartup
        where TCustomer : ProductCustomer<TItem>
        where TItem : SaleItem
        where THolder : ProductHolder<TItem>
{
    public IConfiguration Configuration { get; private set; }
    private OrderingContextModel<TCustomer, TItem, THolder> Model { get; set; }

    

    public TOptions Get<TOptions>() where TOptions : class
        => Configuration.Get<TOptions>();

    public void Configure(IWebHostBuilder builder)
        => builder.ConfigureServices(OnConfigureServices);

    private void OnConfigureServices(WebHostBuilderContext ctx, IServiceCollection services)
    {
        this.Configuration = ctx.Configuration;
        this.Model = this.Get<OrderingContextModel<TCustomer, TItem, THolder>>();
        services.AddDbContext<DeliveryDbContext<TCustomer, TItem, THolder>>(options =>
            options.UseInMemoryDatabase(this.Configuration.GetConnectionString(nameof(DeliveryDbContext<TCustomer, TItem, THolder>))));
    }

    public class OrderingContextModel<TTCustomer, TTItem, TTHolder>
        where TTCustomer : ProductCustomer<TItem>
        where TTItem : SaleItem
        where TTHolder : ProductHolder<TItem>
    {
        public string Customer { get; set; } = "ООО СПР";
        public string App { get; set; } = "Модуль управления заказами";
        public string Holder { get; set; } = "eckumoc@gmail.com";
        public string Contents { get; set; } = "D:\\System-Config";
        public string Base { get; set; }

        public string CustomersDictionaryUrl { get; set; } = "https://localhost:5053/Customers/List";
        public string HoldersDictionaryUrl { get; set; } = "https://localhost:5053/Holders/List";         
    }
}





namespace pickpoint_delivery_service
{


    
    
    public interface IOrdersService<TItem> where TItem: SaleItem
    {
        public IEnumerable<SaleOrder<TItem>> GetOrders();
        public IEnumerable<TItem> GetOrderItems(int orderId);
    }



    public interface IEventsService
    {
        public void Publish(string type, object data);
    }



    public class EventsService : IEventsService
    {
        public void Publish(string type, object data)
        {
            SerializeObject($"evnet message: {type}\n" + SerializeObject(data));
        }
    }










}

 */