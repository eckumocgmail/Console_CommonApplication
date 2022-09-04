using Data;

using DataEntities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

using Mvc_Apteka;
using Mvc_Apteka.Entities;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

using Xml;


namespace Data { }
public interface ICrudProductInfoService
{
    Task<MethodResult<IEnumerable<ProductActivity>>> GetHistory();
     
    Task AddOrUpdate(ProductCatalog TargetCatalog);
    Task<bool> AddOrUpdate(ProductInfo info);
    Task<bool> AddOrUpdate(string productName, float productPrice, int productCount);
    void Clear();
    Task<int> Create(ProductInfo ProductInfo);
    bool Equals(ProductInfo ProductInfo, string ProductName, float ProductPrice, float ProductCount);
    Task<ProductCatalog> GetProductCatalog(string ProductCatalogName);
    Task<ProductInfo> GetProductInfo(string ProductName);
    Task<bool> HasProductWithName(string Name);
    Task<IEnumerable<ProductInfo>> ListProducts();
    Task<IEnumerable<ProductInfo>> ProductCountInRange(int min, int max);
    Task<IEnumerable<ProductInfo>> ProductCountInRange(IEnumerable<ProductInfo> products, int min, int max);
    Task<IEnumerable<ProductInfo>> ProductPriceInRange(float min, float max);
    Task<IEnumerable<ProductInfo>> ProductPriceInRange(IEnumerable<ProductInfo> products, float min, float max);
    Task<IEnumerable<ProductInfo>> ProductsSearch(IEnumerable<ProductInfo> products, int minCount, int maxCount, float minPrice, float maxPrice);
    Task<int> Remove(ProductInfo ProductInfo);
    Task<int> Update(ProductInfo ProductInfo);
}


/// <summary>
/// 
/// </summary>
public class InitCatalogService   
{
        


    public async Task<byte[]> GetDataForExport( )
    {
        using (var db = new CatalogDataModel())
        {
            var ctrl = new ProductsJsonController( db);
            return await ctrl.GetDataForExport();
        }
    }


    public int Create(ProductInfo ProductInfo)
    {
        using (var context = new CatalogDataModel())
        {
            context.ProductInfos.Add(ProductInfo);
            return context.SaveChanges();
        }
    }


    public async Task<int> CreateAsync(ProductInfo ProductInfo)
    {
        using (var context = new CatalogDataModel())
        {
            context.ProductInfos.Add(ProductInfo);
            return await context.SaveChangesAsync();
        }
    }

    public async Task<int> Update(ProductInfo ProductInfo)
    {
        using (var context = new CatalogDataModel())
        {
            context.Update(ProductInfo);
            return await context.SaveChangesAsync();
        }
    }

    public static string InputDataXml = @"
<EXPORT>
<LS>
    <MNN>Гуселкумаб</MNN>
    <DATA>
        <NAME>Тремфея 100 мг/мл 1 мл № 1 р-р для подк.введ.(Силаг)</NAME>
        <PRICE>139687.90</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Селексипаг</MNN>
    <DATA>
        <NAME>Апбрави 200 мг №140 табл. п/поб.(Экселла)</NAME>
        <PRICE>490779.80</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Аталурен</MNN>
    <DATA>
        <NAME>ТРАНСЛАРНА, 250 мг (пакетик- саше) 1000 мг х 30 порошок для приема внутрь, (Алмак Фарма)</NAME>
        <PRICE>774401.10</PRICE>
        <COUNT>99999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Агалсидаза альфа</MNN>
    <DATA>
        <NAME>Реплагал 1 мг/мл 3,5 мл № 1 конц. для р-ра д/инф.(Кэнджин БиоФарма)</NAME>
        <PRICE>112027.65</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Атомоксетин</MNN>
    <DATA>
        <NAME>Страттера 40мг №7 капсулы (Лилли дель Карибе)</NAME>
        <PRICE>1755.70</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Инсулин гларгин + Ликсисенатид</MNN>
    <DATA>
        <NAME>Соликва СолоСтар 100ЕД/мл + 50мкг/мл 3 мл № 3 р-р для подк.вв.(Санофи-Авенсис)</NAME>
        <PRICE>4019.40</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Ивакофтор+ Лумакафтор</MNN>
    <DATA>
        <NAME>Оркамби 125 мг + 100 мг таблетки п. п/об № 112  (Вертекс)</NAME>
        <PRICE>885075.52</PRICE>
        <COUNT>99999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Линаглиптин</MNN>
    <DATA>
        <NAME>Тражента 5 мг №30 табл п/поб (Вест-Ворд Колумбус)</NAME>
        <PRICE>1499.96</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Миртазапин</MNN>
    <DATA>
        <NAME>Миртазапин Канон 30 мг № 30 табл п/поб (Канонфарма)</NAME>
        <PRICE>740.30</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Глюкагон</MNN>
    <DATA>
        <NAME>ГлюкоГен ГипоКит 1мг №1 лиоф д/приг р-ра(НовоНордиск АС)</NAME>
        <PRICE>654.20</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Эвоглиптин</MNN>
    <DATA>
        <NAME>Эводин 5 мг №28 табл п/п об (Герофарм)</NAME>
        <PRICE>710.92</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Инсулин деглудек + Инсулин аспарт</MNN>
    <DATA>
        <NAME>Райзодег ФлексТач 100ЕД/мл 3 мл №5 р-р д/пк вв. картридж в шприц-ручке (НовоНордиск)</NAME>
        <PRICE>2370.90</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Иксекизумаб</MNN>
    <DATA>
        <NAME>ТАЛС 80мг/мл 1 мл №1 р-р д/пв (Эли Лилли)</NAME>
        <PRICE>52228.29</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>СУНИТИНИБ</MNN>
    <DATA>
        <NAME>Сунитиниб-нaтив 12,5 мг №30 капсулы (Натива)</NAME>
        <PRICE>39111.95</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Сунитиниб-нaтив 12,5 мг №28 капсулы (Натива)</NAME>
        <PRICE>36667.45</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Фосфолипиды + Глицирризиновая кислота</MNN>
    <DATA>
        <NAME>Фосфоглив форте 65мг+300мг №50 капс(Фармстандарт-Лексредства)</NAME>
        <PRICE>983.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>ДУПИЛУМАБ</MNN>
    <DATA>
        <NAME>Дупиксент 150мг/мл 2 мл №2 р-р д/пв (СанофиВинтроп)</NAME>
        <PRICE>76507.20</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Дупиксент 150мг/мл 2 мл №2 р-р д/пв (СанофиВинтроп)</NAME>
        <PRICE>76507.20</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>НЕТАКИМАБ</MNN>
    <DATA>
        <NAME>Эфлейра 60мг/мл 1 мл №2 р-р д/подк.в/в(Биокад)</NAME>
        <PRICE>19999.98</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Клобазам</MNN>
    <DATA>
        <NAME>Фризиум 10мг №100 табл(Санофи Винтроп Индустрия)</NAME>
        <PRICE>1524.60</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Ипраглифлозин</MNN>
    <DATA>
        <NAME>Суглат 50 мг №30 табл п/поб(Астеллас Фарма)</NAME>
        <PRICE>2328.60</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Суглат 50 мг №30 табл п/поб(Астеллас Фарма)</NAME>
        <PRICE>2271.30</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Суглат 50 мг №30 табл п/поб(Астеллас Фарма)</NAME>
        <PRICE>2271.30</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Суглат 50 мг №30 табл п/поб(Астеллас Фарма)</NAME>
        <PRICE>2271.30</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Карипразин</MNN>
    <DATA>
        <NAME>Реагила 6мг №28 капсулы(Гедеон Рихтер)</NAME>
        <PRICE>3426.08</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Реагила 1,5мг №28 капсулы(Гедеон Рихтер)</NAME>
        <PRICE>3446.80</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Реагила 3мг №28 капсулы(Гедеон Рихтер)</NAME>
        <PRICE>3446.80</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Реагила 4,5мг №28 капсулы(Гедеон Рихтер)</NAME>
        <PRICE>3446.80</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Баклофен</MNN>
    <DATA>
        <NAME>Баклосан 10мг №50 табл(Польфарма)</NAME>
        <PRICE>220.35</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Баклосан 10мг №50 табл(Польфарма)</NAME>
        <PRICE>220.35</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Баклосан 25мг №50 табл/(Польфарма)</NAME>
        <PRICE>410.63</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Баклосан 25мг №50 табл/(Польфарма)</NAME>
        <PRICE>410.63</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Абемациклиб</MNN>
    <DATA>
        <NAME>Зенлистик 200мг №14 табл п/поб(Лилли дель Карибе,Инк)</NAME>
        <PRICE>20029.10</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Зенлистик 200мг №14 табл п/поб(Лилли дель Карибе,Инк)</NAME>
        <PRICE>18208.26</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Зенлистик 200мг №14 табл п/поб(Лилли дель Карибе,Инк)</NAME>
        <PRICE>18181.80</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Илопрост</MNN>
    <DATA>
        <NAME>Вентавис 10мкг/мл 2 мл №30 р-р д/ингаляций(Берлимед С.А.)</NAME>
        <PRICE>44258.50</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Вентавис 10мкг/мл 2 мл №30 р-р д/ингаляций(Берлимед С.А.)</NAME>
        <PRICE>44258.50</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Вентавис 10мкг/мл 2 мл №30 р-р д/ингаляций(Берлимед С.А.)</NAME>
        <PRICE>44258.40</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Мидостаурин</MNN>
    <DATA>
        <NAME>Митикайд 25мг №56 капсулы(Каталент)</NAME>
        <PRICE>200098.64</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Митикайд 25мг №56 капсулы(Каталент)</NAME>
        <PRICE>200098.64</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Сульпирид</MNN>
    <DATA>
        <NAME>Бетамакс 50мг №30 табл п/побол(Гриндекс)</NAME>
        <PRICE>138.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Бетамакс 50мг №30 табл п/побол(Гриндекс)</NAME>
        <PRICE>138.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Бетамакс 200мг №30 табл п/побол(Гриндекс)</NAME>
        <PRICE>235.50</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Бетамакс 200мг №30 табл п/побол(Гриндекс)</NAME>
        <PRICE>235.50</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>ПОМАЛИДОМИД</MNN>
    <DATA>
        <NAME>Иматанго 4 мг № 21 капсулы(Рафарма)</NAME>
        <PRICE>514998.33</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Транексамовая кислота</MNN>
    <DATA>
        <NAME>Транексам 500мг №30 табл р/побол(Обнинская ХФК)</NAME>
        <PRICE>726.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Кодеин + Морфин + Носкапин + Папаверина гидрохлорид + Тебаин</MNN>
    <DATA>
        <NAME>Омнопон 1мл №5 р-р д/подкожн вв(ФГУП 'МЭЗ')</NAME>
        <PRICE>405.87</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Омнопон 1мл №5 р-р д/подкожн вв(ФГУП 'МЭЗ')</NAME>
        <PRICE>392.70</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>

<LS>
    <MNN>Цитарабин</MNN>
    <DATA>
        <NAME>Цитарабин-ЛЭНС 100мг №10 лиофил д/приг р-ра д/инъек(Верофарм)</NAME>
        <PRICE>759.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Дулаглутид</MNN>
    <DATA>
        <NAME>Трулисити 1,5 мг/0,5 мл 0,5мл №4шприц р-р д/подкожн вв(Эли Лилли)</NAME>
        <PRICE>5974.80</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Трулисити 1,5 мг/0,5 мл 0,5мл №4шприц р-р д/подкожн вв(Эли Лилли)</NAME>
        <PRICE>5974.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Трулисити 1,5 мг/0,5 мл 0,5мл №4шприц р-р д/подкожн вв(Эли Лилли)</NAME>
        <PRICE>5334.78</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Медроксипрогестерон</MNN>
    <DATA>
        <NAME>Провера 500мг №30 табл(Пфайзер Италия)</NAME>
        <PRICE>2690.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Провера 500мг №30 табл(Пфайзер Италия)</NAME>
        <PRICE>2540.70</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Провера 500мг №30 табл(Пфайзер Италия)</NAME>
        <PRICE>2540.70</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Сультиам</MNN>
    <DATA>
        <NAME>Осполот 50мг №200 табл п/побол(Деситин)</NAME>
        <PRICE>16764.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>АЛЕКТИНИБ</MNN>
    <DATA>
        <NAME>Алеценза 150мг №224 капсулы(Экселла Гмбх)</NAME>
        <PRICE>209193.60</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Алеценза 150мг №224 капсулы(Экселла Гмбх)</NAME>
        <PRICE>235066.44</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Азатиоприн</MNN>
    <DATA>
        <NAME>Азатиоприн 50 мг №50 табл(Мосхимфармпрепараты)</NAME>
        <PRICE>386.50</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Вориконазол</MNN>
    <DATA>
        <NAME>Вориконазол Канон 200мг №14 табл п/поб(Канонфарма)</NAME>
        <PRICE>11119.64</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Вориконазол Канон 200мг №14 табл п/поб(Канонфарма)</NAME>
        <PRICE>11119.64</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Бифлурин 200 мг №14 табл п/поб(Фармасинтез)</NAME>
        <PRICE>11119.64</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Бифлурин 200 мг №14 табл п/поб(Фармасинтез)</NAME>
        <PRICE>11119.64</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Икодекстрин</MNN>
    <DATA>
        <NAME>Экстранил 7,5% 2000 мл №5 р-р д/перитон(Бакстер)</NAME>
        <PRICE>4228.29</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Экстранил 7,5% 2000 мл №5 р-р д/перитон(Бакстер)</NAME>
        <PRICE>4228.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>БАРИЦИТИНИБ</MNN>
    <DATA>
        <NAME>Олумиант 4мг №28 табл п/поб(Лилли дель Карибе)</NAME>
        <PRICE>44283.96</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Олодатерол + Тиотропия бромид</MNN>
    <DATA>
        <NAME>Спиолто Респимат 2,5мкг+2,5мкг/доза 4 мл №1 р-р д/инг(Берингер Ингельхайм Фарма)</NAME>
        <PRICE>2611.40</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Спиолто Респимат 2,5мкг+2,5мкг/доза 4 мл №1 р-р д/инг(Берингер Ингельхайм Фарма)</NAME>
        <PRICE>2611.40</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
    <DATA>
        <NAME>Спиолто Респимат 2,5мкг+2,5мкг/доза 4 мл №1 р-р д/инг(Берингер Ингельхайм Фарма)</NAME>
        <PRICE>2695.40</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Нусинерсен</MNN>
    <DATA>
        <NAME>Спинраза 2,4 мг/мл 5 мл № 1 р-р для интратекального вв. (Биоген Айдек)</NAME>
        <PRICE>5652559.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
<LS>
    <MNN>Цинакальцет</MNN>
    <DATA>
        <NAME>Цинакальцет-ТЛ 30мг №28 табл п/побл(Р-Фарм)</NAME>
        <PRICE>7448.00</PRICE>
        <COUNT>999999.00</COUNT>
    </DATA>
</LS>
</EXPORT>
    ";
    public async Task InitData( )
    {
        var DrugList = new List<LS>();
 

                                    
        using (var context = new CatalogDataModel())
        using (var stream = new StringReader(InputDataXml))
        {
            DataSet dataset = new DataSet();
            dataset.ReadXml(stream);
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                DrugList.Add(new LS()
                {
                    MNN = row[0].ToString(),
                    LS_Id = int.Parse(row[1].ToString())
                });
            }
            foreach (DataRow row in dataset.Tables[1].Rows)
            {

                int catalogId = int.Parse(row[3].ToString());
                LS catalog = DrugList.Where(x => x.LS_Id == catalogId).FirstOrDefault();
                catalog.Products.Add(new DATA()
                {
                    NAME = row[0].ToString(),
                    COUNT = row[2].ToString(),
                    PRICE = row[1].ToString()
                });
            }



            foreach (LS next in DrugList)
            {
                var ProductCatalog = new ProductCatalog()
                {
                    ProductCatalogName = next.MNN,
                    ProductCatalogNumber = next.LS_Id
                };

                foreach (DATA record in next.Products)
                {
                    int count = (int)Math.Floor(float.Parse(record.COUNT.Replace(".", ",")));
                    float price = float.Parse(record.PRICE.Replace(".", ","));
                    var info = new ProductInfo()
                    {
                        ProductCatalogID = ProductCatalog.ID,
                        ProductName = record.NAME,
                        ProductCount = 0,
                        ProductPrice = 0
                    };
                    await AddOrUpdate(context, info);
                    context.SaveChanges();

                    info.ProductCount = count;
                    info.ProductPrice = price;

                    context.SaveChanges();

                }

                //context.AddOrUpdate(ProductCatalog);
            }
        }
            
 
    }
        

    public List<ProductInfo> GetProducts()
    {
        using (var context = new CatalogDataModel())
        {                
            return context.ProductInfos.ToList();
        }
    }

    public async Task<int> Remove(ProductInfo ProductInfo)
    {
        using (var context = new CatalogDataModel())
        {
            context.Update(ProductInfo);
            return await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<ProductInfo>> ProductsSearch(IEnumerable<ProductInfo> products, int minCount, int maxCount, float minPrice, float maxPrice)
    {
        var productsInCountingRange = await ProductCountInRange(products, minCount, maxCount);
        var productsInPriceRange = await ProductPriceInRange(productsInCountingRange, minPrice, maxPrice);
        return productsInPriceRange;
    }

    public ProductInfo GetProductInfoById(int id)
    {
        using (var db = new CatalogDataModel())
        {
            return db.ProductInfos.Find(id);
        }
    }

    public Task<IEnumerable<ProductInfo>> ProductCountInRange(IEnumerable<ProductInfo> products, int min, int max)
        => Task.FromResult(products.Where(p => p.ProductCount >= min && p.ProductCount <= max));

    public async Task Import(IEnumerable<ProductInfo> products)
    {
        foreach(var product in products)
        {
            await this.AddOrUpdate(product);
        }
    }

    public Task<IEnumerable<ProductInfo>> ProductPriceInRange(IEnumerable<ProductInfo> products, float min, float max)
        => Task.FromResult(products.Where(p => p.ProductPrice >= min && p.ProductPrice <= max));

    public Task<IEnumerable<ProductInfo>> ProductCountInRange(int min, int max)
    {
        using (var context = new CatalogDataModel())
        {
            return this.ProductCountInRange(context.ProductInfos, min, max);
        }
    }

    public Task<IEnumerable<ProductInfo>> ProductPriceInRange(float min, float max)
    {
        using(var db = new CatalogDataModel())
        {
            return this.ProductPriceInRange(db.ProductInfos, min, max);
        }
    }
        
    public Task<bool> HasProductWithName(string Name)
    {
        using (var context = new CatalogDataModel())
        {
            return Task.FromResult(context.ProductInfos.AsNoTracking().Any(p => p.ProductName.ToUpper() == Name.ToUpper()));
        }
    }

    public async Task<ProductCatalog> GetProductCatalog(string ProductCatalogName)
    {
        using (var context = new CatalogDataModel())
        {
            await Task.CompletedTask;
            return context.ProductCatalogs.AsNoTracking().Where(p => p.ProductCatalogName == ProductCatalogName).FirstOrDefault();
        }
    }
    
    public async Task AddOrUpdate( ProductCatalog TargetCatalog)
    {
        using (var context = new CatalogDataModel())
        {
            await AddOrUpdate(context, TargetCatalog);
        }
    }
    public async Task AddOrUpdate(CatalogDataModel context, ProductCatalog TargetCatalog)
    {                       
        var CurrentCatalog = context.ProductCatalogs.AsNoTracking().Where(p => p.ProductCatalogName == TargetCatalog.ProductCatalogName).FirstOrDefault();
        if (CurrentCatalog == null)
        {
            context.ProductCatalogs.Add(TargetCatalog);
            context.SaveChanges();
        }
        else
        {
            var CurrentProducts = context.ProductInfos.Where(p => p.ProductCatalogID == TargetCatalog.ID);
            var TargetProducts = TargetCatalog.Products;

            HashSet<string> CurrentProductNames = CurrentProducts.Select(p => p.ProductName).ToHashSet();
            HashSet<string> TargetProductNames = TargetProducts.Select(p => p.ProductName).ToHashSet();

            HashSet<string> CurrentExpectTarget = new HashSet<string>();
            HashSet<string> TargetExpectCurrent = new HashSet<string>();
            HashSet<string> TargetInspectCurrent = new HashSet<string>();
            foreach (var ProductName in TargetProductNames.Intersect(CurrentProductNames))
                TargetInspectCurrent.Add(ProductName);
            foreach (var ProductName in TargetProductNames.Except(CurrentProductNames))
                TargetExpectCurrent.Add(ProductName);
            foreach (var ProductName in CurrentProductNames.Except(TargetProductNames))
                CurrentExpectTarget.Add(ProductName);


            /// удаляем записи которых нет в текущем наборе
            foreach (var Product in TargetProducts.Where(p => TargetExpectCurrent.Contains(p.ProductName)).ToList())
                context.ProductInfos.Add(Product);
            int ProductsAdded = context.SaveChanges();

            /// удаляем записи которых нет в целевом наборе
            foreach (var Product in CurrentProducts.Where(p => CurrentExpectTarget.Contains(p.ProductName)).ToList())
                context.ProductInfos.Remove(Product);
            int ProductsRemoved = context.SaveChanges();

            int ProductsUpdated = 0;
            /// остальные записи сравниваем и обновляем
            foreach (var Product in CurrentProducts.Where(p => TargetInspectCurrent.Contains(p.ProductName)).ToList())
            {
                var TargetProduct = TargetProducts.Where(p => p.ProductName == Product.ProductName).First();
                if (await this.AddOrUpdate(context, Product.ProductName, TargetProduct.ProductPrice, TargetProduct.ProductCount))
                    ProductsUpdated++;
            }
        }
            

    }

    public ProductInfo GetProductInfo(string ProductName)
    {
        using (var context = new CatalogDataModel())
        {
            return context.ProductInfos.AsNoTracking().Where(p => p.ProductName == ProductName).FirstOrDefault();
        }
    }

    public async Task<ProductInfo> GetProductInfoAsync(string ProductName)
    {
        using (var context = new CatalogDataModel())
        {
            return await context.ProductInfos.AsNoTracking().Where(p => p.ProductName == ProductName).FirstOrDefaultAsync();
        }
        
    }





    public async Task<bool> AddOrUpdate(ProductInfo info)
    {
        using(var db = new CatalogDataModel())
        {
            return await AddOrUpdate(db, info);
        }
    }
    public async Task<bool> AddOrUpdate(CatalogDataModel db, ProductInfo info)        
    {
        return await AddOrUpdate(db, info.ProductName, info.ProductPrice, info.ProductCount);
    }

    public async Task<bool> AddOrUpdate(CatalogDataModel context,  string productName, float productPrice, int productCount)
    {
          
        ProductInfo p = this.GetProductInfo(productName);
        if (p == null)
        {
            context.ProductInfos.Add(new ProductInfo()
            {
                ProductName = productName,
                ProductCount = productCount,
                ProductPrice = productPrice
            });
        }
        else
        {
            if (Equals(p, productName, productPrice, productCount) == false)
            {
                p.ProductName = productName;
                p.ProductCount = productCount;
                p.ProductPrice = productPrice;
            }
        }

        await context.SaveChangesAsync();
        return true;
    
    }

    public bool Equals(ProductInfo ProductInfo, string ProductName, float ProductPrice, float ProductCount)
    =>
        ProductInfo.ProductName != ProductName ? false :
        ProductInfo.ProductPrice != ProductPrice ? false :
        ProductInfo.ProductCount != ProductCount ? false : true;

    public void Clear()
    {
        using (var context = new CatalogDataModel())
        {
            foreach (var act in context.Activities.ToList())
                context.Remove(act);
            foreach (var info in context.ProductInfos.ToList())
                context.Remove(info);
            foreach (var catalog in context.ProductCatalogs.ToList())
                context.Remove(catalog);
            context.SaveChanges();
        }

    }

    public MethodResult<IEnumerable<ProductInfo>> GetProductInfos()
    {
        try
        {
            using (var context = new CatalogDataModel())
            {
                return MethodResult<IEnumerable<ProductInfo>>.OnResult( context.ProductInfos.ToList());
            }

        }catch (Exception ex)
        {
            return MethodResult<IEnumerable<ProductInfo>>.OnError(ex);
        }
    }

    public async Task<IEnumerable<ProductInfo>> GetProductInfosAsync()
    {
        await Task.CompletedTask;
        using (var context = new CatalogDataModel())
            return await context.ProductInfos.ToListAsync();
    }

    public async Task<MethodResult<IEnumerable<ProductActivity>>> GetHistory()
    {
        try
        {
            await Task.CompletedTask;
            using (var context = new CatalogDataModel())
                return MethodResult<IEnumerable<ProductActivity>>.OnResult(context.Activities.ToList());
        }catch (Exception ex)
        {
            return MethodResult<IEnumerable<ProductActivity>>.OnError(ex);
        }
    }

    public void EnsureDatabaseIsCorrect()
    {

            

        using (var db = new CatalogDataModel())
        {
                
            using (var sqlConnection = new SqlConnection(db.GetConnectionString()))
            {
                sqlConnection.Open();

                var cmd = new SqlCommand("CREATE DATABASE db_" + DateTime.Now.Date.DayOfYear, sqlConnection);
                cmd.ExecuteNonQuery();
            }
                db.Database.EnsureDeleted();
        }
        using (var db = new CatalogDataModel())
        {
            db.Database.EnsureCreated();
        }
    }
}



/// <summary>
/// Первичные структуры 
/// </summary>
namespace Xml
{
    /// <summary>
    /// Сведения о лекарственном препарате
    /// </summary>
    public class LS
    {
        public System.String MNN { get; set; }
        public System.Int32 LS_Id { get; set; }

        [XmlIgnore]
        public List<DATA> Products { get; set; } = new List<DATA> { };
    }


    /// <summary>
    /// Продажи лекарств
    /// </summary>
    public class DATA
    {
        public System.String NAME { get; set; }
        public System.String PRICE { get; set; }
        public System.String COUNT { get; set; }
        public System.Int32 LS_Id { get; set; }
    }
}
