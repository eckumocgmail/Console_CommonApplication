using ApplicationDb.Entities;


using CoreModel.CoreUtils;

using EnterpriceResourcePlaning;

using Managment.DataModel;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



/// <summary>
/// Наполняет первичными данными базу
/// </summary>
public class DataInitiallizer
{

         
    /// <summary>
    /// Инициаллизация пользовательских прав доступа к функциям приложения
    /// </summary>
    public static void InitBusinessResources()
    {
            
        using (var db = new AppDbContext())
        {
           


            Api.Utils.Info("Инициаллизация пользовательских прав доступа к функциям приложения");
            if(db.BusinessResources.Count() < 3)
            {
                BusinessResource users;
                BusinessResource admins;
                BusinessResource analitics;
                db.BusinessResources.Add(users=new BusinessResource()
                {
                    Name = "Личный кабинет",
                    Code = "User",
                    Description = "Базовый полномочия, которые распостраняются на всех сотрудников"
                });
                db.BusinessResources.Add(analitics=new BusinessResource()
                {
                    Name = "Аналитические материалы",
                    Code = "Analitic",
                    Description = "Бизнес аналитик, исследует системные процессы",
                    Parent = users
                });
                db.BusinessResources.Add(admins = new BusinessResource()
                {
                    Name = "Администрирование функций",
                    Code = "Admin",
                    Description = "Управление отчётными формами, управления ресурсами организации подразделениями, должностями, штатным расписанием.",
                    Parent = analitics
                });
                db.BusinessResources.Add(new BusinessResource()
                {
                    Name = "Разработка",
                    Code = "Developer",
                    Description = "Разработка функциональной модели предприятия.",
                    Parent = admins
                });

                Api.Utils.Info("insert roles");
                db.SaveChanges();

            }
                
        }
    }

    static void ValidateDatabase(MedicalDataModel medical)
    {
           
    }

    static void ValidateDatabase(AnaliticsDataModel analitics)
    {
    }

    static void ValidateDatabase(CustomerDataModel customers)
    {
    }

    static void ValidateDatabase(CommunicationDataModel communiucations)
    {
    }

    static void ValidateDatabase(MarketDataModel market)
    {
    }

    static void ValidateDatabase(ManagmentDataModel managment)
    {
    }



    /// <summary>
    /// Регистрация "Штатного расписания"
    /// </summary>
    public static void InitPositions()
    {
            
        using (var db = new ManagmentDataModel())
        {

            if(db.Positions.Count() == 0){

                Api.Utils.Info("Регистрация Штатного расписания");
                db.Positions.AddRange(

                    new List<string>() { 
                        "Бухгалтер",
                        "Главный бухгалтер", 
                        "Главный логист",
                        "Инженер монтажник",
                        "Логист",
                        "Менеджер по продажам",
                        "Менеджер по сопровождению",

                        "Офис менеджер",
                        "Программист",
                        "Руководитель дивизиона",
                        "Старший программист"}.Select(p => new Position() { Name = p, Description = p })
                );
            }

            db.SaveChanges();
        }
    }

    static void ValidateDatabase(AuthorizationDataModel auth)
    {
    }







    /// <summary>
    /// Регистрация сведений о сотрудниках
    /// </summary>
    public static void InitEmployess()
    {
            
        using (var db = new ManagmentDataModel())
        {
            if (db.Employees.Count() == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    Department dep = db.Departments.GetRandom<Department>();
                    Position pos = db.Positions.GetRandom<Position>();
                    var e = CandidateGenerator.GetEmployees();
                    e.Position = pos;
                    db.Employees.Add(e);
                    dep.Employees.Add(e);


                    Api.Utils.Info("Регистрация сведений о сотруднике... ");
                    db.SaveChanges();
                }
            }
             
                
        }            
    }



    /// <summary>
    /// Регистрация сведений о навыках... 
    /// </summary>
    public static void InitSkills()
    {
            
        using (var db = new ManagmentDataModel())
        {
            if (db.Skills.Count() == 0)
            {
                Api.Utils.Info("Регистрация сведений о навыках... ");
                foreach (string skill in CandidateGenerator.skills)
                {

                    db.Skills.Add(new  Skill() { Name = skill, Description = skill });
                    db.SaveChanges();
                    db.PositionFunctions.Add(new PositionFunction()
                    {
                        Name = "Писать код " + skill,
                        Description = "Писать код " + skill,
                        PositionID = db.Positions.GetRandom<Position>().ID
                    });
                    db.SaveChanges();
                }
            }
        }
    }

        
    /// <summary>
    /// Получение случаного целого числа в диапозоне от нуля до заданного предела
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    private static int GetRandom(int max)
    {
        int res = new Random().Next(max);
        return res == 0 ? 1 : res;
    }



    /// <summary>
    /// Создание штатного расписания
    /// </summary>
    public static void InitStaffs()
    {
            
        using (var db = new ManagmentDataModel())
        {
            if(db.Staffs.Count() == 0)
            {
                Api.Utils.Info("создание штатного расписания()");
                var listOfPositions = db.Positions.ToList();
                foreach (var position in listOfPositions)
                {
                    db.Staffs.Add(new StaffsTable() { 
                        Department = db.Departments.GetRandom<Department>(),
                        PositionID = position.ID,
                        CountOfEmployees = GetRandom(5)
                    });
                        
                }
                db.SaveChanges();
                    
                    
            }
        }
    }



    /// <summary>
    /// Запись данных о коэффициентов трудового стажа
    /// </summary>
    public static void InitRates()
    {
            
        using (var db = new ManagmentDataModel())
        {
            if (db.TariffRates.Count() == 0)
            {
                Api.Utils.Info("Запись данных о коэффициентов трудового стажа");
                var listOfPositions = db.Staffs.Include(s=>s.Position).ToList();
                foreach (var staff in listOfPositions)
                {
                    db.TariffRates.Add(new PaymentPersonal()
                    {                          
                        Name = "Базовая",
                        Description = "Базовая ставка",
                        PositionID = staff.Position.ID                             
                    });

                }
                db.SaveChanges();


            }
        }
    }





    /// <summary>
    /// Запись данных о подразделениях организации
    /// </summary>
    public static void InitDepartments()
    {
            
        using (var db = new ManagmentDataModel())
        {
            if (db.Departments.Count() < 5)
            {
                Api.Utils.Info("запись данных о подразделениях....");
                db.Departments.ToList().ForEach(p => {
                    db.Departments.Remove(p);
                });
                db.SaveChanges();
                db.Add(new Department()
                {
                    Name = "Администрация",
                    Description = "Администрация"

                });
                db.Add(new Department()
                {
                    Name = "Отдел обеспечения",
                    Description = "Отдел обеспечения"
                });
                db.Add(new Department()
                {
                    Name = "Отдел продаж",
                    Description = "Отдел продаж"
                });
                db.Add(new Department()
                {
                    Name = "Отдел развития и разработки",
                    Description = "Отдел развития и разработки"
                });
                db.Add(new Department()
                {
                    Name = "Отдел сопровождения",
                    Description = "Отдел сопровождения"
                });
                db.Add(new Department()
                {
                    Name = "Финансовый отдел",
                    Description = "Финансовый отдел"
                });
            }
            db.SaveChanges();
        }
    }



    /// <summary>
    /// Регистрация сведений о должностных обязанностях
    /// </summary>
    public static void InitFunctions()
    {
            
        using (var db = new ManagmentDataModel())
        {

                 


            if (db.PositionFunctions.Count() == 0)
            {
                Api.Utils.Info("Регистрация сведений о должностных обязанностях ... ");
                var listOfPositions = db.Positions.ToList();
                foreach (var position in listOfPositions)
                {
                        
                    var function = new PositionFunction()
                    {
                        Name = "Программирование",
                        Description = "Программирование"
                    };


                    var skills = new HashSet<Skill>();
                    while (skills.Count() < 3)
                    {
                        var skill = db.Skills.GetRandom<Skill>();
                        skills.Add(skill);
                    }
                    foreach(var skill in skills)
                    {
                        var functionSkill = new FunctionSkills() { 
                            PositionFunction = function,
                            Skill = skill
                        };
                        function.FunctionSkills.Add(functionSkill);
                    }
                    position.PositionFunctions.Add(function);
                    db.SaveChanges();
                }
                    
            }
        }
    }



    /// <summary>
    /// "Регистрация тестовой учетной записи)"
    /// </summary>
    public static void InitBaseAccount()
    {
            
        using (var db = new AuthorizationDataModel())
        {
            DataInitiallizer.InitBusinessResources();

            if (db.Accounts.Where(a => a.Email.ToLower() == "eckumocuk@gmail.com").Any()==false)
            {

                Api.Utils.Info("Регистрация тестовой учетной записи...");
                var role = (from r in db.BusinessResources where r.Code == "Developer" select r).FirstOrDefault();
                var account = new UserAccount("eckumocuk@gmail.com", "eckumocuk@gmail.com");
                account.Activated = DateTime.Now;
                account.ActivationKey = "this is a test";
                var person = new UserPerson()
                {
                    FirstName = "Константин",
                    LastName = "Александрович",
                    SurName = "Батов",
                    Birthday = new DateTime(1970, 1, 1),
                    Tel = "7-777-777-7777"
                };

                var settings = new UserSettings();
                UserApi  user = new UserApi ()
                {
                    Person = person,
                    Account = account,
                    Settings = settings,
                    Role = role,
                    LastActiveTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(),

                    LoginCount = 0,
                    IsActive = false
                };
                db.Persons.Add(person);
                db.Accounts.Add(account);
                db.Settings.Add(settings);
                db.Users.Add(user);
                db.SaveChanges();
            }
             
        }
            
    }




    /// <summary>
    /// Валидация хранилища данных
    /// </summary>
    public static void ValidateDatabase()
    {            
        try
        {
            using (var db = new AppDbContext())
            {                    
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }


            Api.Utils.Info("Инициаллизация минимального набора данных...");
          
            DataInitiallizer.InitBaseAccount();                 
            DataInitiallizer.InitPositions();
            DataInitiallizer.InitDepartments();
            DataInitiallizer.InitStaffs();
            DataInitiallizer.InitRates();
            DataInitiallizer.InitSkills();
            DataInitiallizer.InitFunctions();
            DataInitiallizer.InitEmployess();

            DataInitiallizer.InitEmployessExpirience();

            

        }
        catch (Exception ex)
        {

            /*Exception p = ex;
            while (p != null)
            {
                Api.Utils.Info(p.Message);
                p = p.InnerException;
            }*/

            Api.Utils.Info(ex);
        }
             
    }

    

    private static void InitEmployessExpirience()
    {

        using (var db = new ManagmentDataModel())
        {
                 
            if (db.Employees.Count() == 0 || db.Skills.Count() == 0)
            {
                throw new Exception("Для регистрации опыта работников сначала нужно зарегистрировать самих работников и производственные навыки");
            }
            else
            {                    
                foreach(var e in db.Employees.Include(emp=>emp.Expiriences).ToList())
                {
                    int n = 4;// Randomizing.GetRandomInt(3, 5);
                    for (int i = 0; i < n; i++) {
                        if (e.Expiriences.Count() == 0)
                        {
                            db.EmployeeExpirience.Add(new EmployeeExpirience()
                            {
                                Created = DateTime.Now,
                                SkillID = db.Skills.GetRandom<Skill>().ID,
                                Begin = DateTime.Now.AddYears(-5).AddMonths(Randomizing.GetRandomInt(10, 20)),
                                EmployeeID = e.ID,
                                Granularity = 1
                            });

                            db.SaveChanges();
                        }

                    }
                }
                    


                     
            }
               

        }
            
    }
}





public class CandidateGenerator
{
    public static string[] skills = new string[] {
        "ASP", "Java", "JS", "SQL", "PHP"
    };

    private static string MANS_NAMES_INPUT = "А АаронАбрамАвазАвгустинАвраамАгапАгапитАгатАгафонАдамАдрианАзаматАзатАзизАидАйдарАйратАкакийАкимАланАлександрАлексейАлиАликАлимАлиханАлишерАлмазАльбертАмирАмирамАмиранАнарАнастасийАнатолийАнварАнгелАндрейАнзорАнтонАнфимАрамАристархАркадийАрманАрменАрсенАрсенийАрсланАртёмАртемийАртурАрхипАскарАсланАсханАсхатАхметАшот Б БахрамБенджаминБлезБогданБорисБориславБрониславБулат В ВадимВалентинВалерийВальдемарВарданВасилийВениаминВикторВильгельмВитВиталийВладВладимирВладиславВладленВласВсеволодВячеслав Г ГавриилГамлетГарриГеннадийГенриГенрихГеоргийГерасимГерманГерманнГлебГордейГригорийГустав Д ДавидДавлатДамирДанаДаниилДанилДанисДаниславДаниэльДаниярДарийДауренДемидДемьянДенисДжамалДжанДжеймсДжереми ИеремияДжозефДжонатанДикДинДинарДиноДмитрийДобрыняДоминик Е ЕвгенийЕвдокимЕвсейЕвстахийЕгорЕлисейЕмельянЕремейЕфимЕфрем Ж ЖданЖерарЖигер З ЗакирЗаурЗахарЗенонЗигмундЗиновийЗурабЗуфар И ИбрагимИванИгнатИгнатийИгорьИероним ДжеромИисусИльгизИльнурИльшатИльяИльясИмранИннокентийИраклийИсаакИсаакийИсидорИскандерИсламИсмаилИтан К КазбекКамильКаренКаримКарлКимКирКириллКлаусКлимКонрадКонстантинКореКорнелийКристианКузьма Л ЛаврентийЛадоЛевЛенарЛеонЛеонардЛеонидЛеопольдЛоренсЛукаЛукиллианЛукьянЛюбомирЛюдвигЛюдовикЛюций М МаджидМайклМакарМакарийМаксимМаксимилианМаксудМансурМарМаратМаркМарсельМартин МартынМатвейМахмудМикаМикулаМилославМиронМирославМихаилМоисейМстиславМуратМуслимМухаммедМэтью Н НазарНаильНариманНатанНесторНикНикитаНикодимНиколаНиколайНильсНурлан О ОгюстОлегОливерОрестОрландоОсип ИосифОскарОсманОстапОстин П ПавелПанкратПатрикПедроПерриПётрПлатонПотапПрохор Р РавильРадийРадикРадомирРадославРазильРаильРаифРайанРаймондРамазанРамзесРамизРамильРамонРанельРасимРасулРатиборРатмирРаушанРафаэльРафикРашидРинат РенатРичардРобертРодимРодионРожденРоланРоманРостиславРубенРудольфРусланРустамРэй С СавваСавелийСаидСалаватСаматСамвелСамирСамуилСанжарСаниСаянСвятославСевастьянСемёнСерафимСергейСидорСимбаСоломонСпартакСтаниславСтепанСулейманСултанСурен Т ТагирТаирТайлерТалгатТамазТамерланТарасТахирТигранТимофейТимурТихонТомасТрофим У УинслоуУмарУстин Ф ФазильФаридФархадФёдорФедотФеликсФилиппФлорФомаФредФридрих Х ХабибХакимХаритонХасан Ц ЦезарьЦефасЦецилий СесилЦицерон Ч ЧарльзЧеславЧингиз Ш ШамильШарльШерлок Э ЭдгарЭдуардЭльдарЭмильЭминЭрикЭркюльЭрминЭрнестЭузебио Ю ЮлианЮлийЮнусЮрийЮстинианЮстус Я ЯковЯнЯромирЯрослав";
    private static string WOMANS_NAMES_INPUT = "А АваАвгустаАвгустинаАвдотьяАврораАгапияАгатаАгафьяАглаяАгнияАгундаАдаАделаидаАделинаАдельАдиляАдрианаАзаАзалияАзизаАидаАишаАйАйаруАйгеримАйгульАйлинАйнагульАйнурАйсельАйсунАйсылуАксиньяАланаАлевтинаАлександраАлексияАлёнаАлестаАлинаАлисаАлияАллаАлсуАлтынАльбаАльбинаАльфияАляАмалияАмальАминаАмираАнаитАнастасияАнгелинаАнжелаАнжеликаАнисьяАнитаАннаАнтонинаАнфисаАполлинарияАрабеллаАриаднаАрианаАриандаАринаАрияАсельАсияАстридАсяАфинаАэлитаАяАяна Б БаженаБеатрисБелаБелиндаБелла БэллаБертаБогданаБоженаБьянка В ВалентинаВалерияВандаВанессаВарвараВасилинаВасилисаВенераВераВероникаВестаВетаВикторинаВикторияВиленаВиолаВиолеттаВитаВиталина ВиталияВладаВладанаВладислава Г ГабриэллаГалинаГалияГаянаГаянэГенриеттаГлафираГоарГретаГульзираГульмираГульназГульнараГульшатГюзель Д ДалидаДамираДанаДаниэлаДанияДараДаринаДарьяДаянаДжамиляДженнаДженниферДжессикаДжиневраДианаДильназДильнараДиляДилярамДинаДинараДолоресДоминикаДомнаДомника Е ЕваЕвангелинаЕвгенияЕвдокияЕкатеринаЕленаЕлизаветаЕсенияЕя Ж ЖаклинЖаннаЖансаяЖасминЖозефинаЖоржина З ЗабаваЗаираЗалинаЗамираЗараЗаремаЗаринаЗемфираЗинаидаЗитаЗлатаЗлатославаЗорянаЗояЗульфияЗухра И Иветта ИветаИзабеллаИлинаИллирикаИлонаИльзираИлюзаИнгаИндираИнессаИннаИоаннаИраИрадаИраидаИринаИрмаИскраИя К КамилаКамиллаКараКареКаримаКаринаКаролинаКираКлавдияКлараКонстанцияКораКорнелияКристинаКсения Л ЛадаЛанаЛараЛарисаЛаураЛейлаЛеонаЛераЛесяЛетаЛианаЛидияЛизаЛикаЛилиЛилианаЛилитЛилияЛинаЛиндаЛиораЛираЛияЛолаЛолитаЛораЛуизаЛукерьяЛукияЛунаЛюбаваЛюбовьЛюдмилаЛюсильЛюсьенаЛюцияЛючеЛяйсанЛяля М МавилеМавлюдаМагдаМагдалeнаМадинаМадленМайяМакарияМаликаМараМаргаритаМарианнаМарикаМаринаМарияМариямМартаМарфаМеланияМелиссаМехриМикаМилаМиладаМиланаМиленМиленаМилицаМилославаМинаМираМирославаМирраМихримахМишельМияМоникаМуза Н НадеждаНаиляНаимаНанаНаомиНаргизаНатальяНеллиНеяНикаНикольНинаНинельНоминаНоннаНораНурия О ОдеттаОксанаОктябринаОлесяОливияОльгаОфелия П ПавлинаПамелаПатрицияПаулаПейтонПелагеяПеризатПлатонидаПолинаПрасковья Р РавшанаРадаРазинаРаиляРаисаРаифаРалинаРаминаРаянаРебеккаРегинаРезедаРенаРенатаРианаРианнаРикардаРиммаРинаРитаРогнедаРозаРоксанаРоксоланаРузалияРузаннаРусалинаРусланаРуфинаРуфь С СабинаСабринаСажидаСаидаСалимаСаломеяСальмаСамираСандраСанияСараСатиСаулеСафияСафураСаянаСветланаСевараСеленаСельмаСерафимаСильвияСимонаСнежанаСоняСофьяСтеллаСтефанияСусанна Т ТаисияТамараТамилаТараТатьянаТаяТаянаТеонаТерезаТеяТинаТиффаниТомирисТораТэмми У УльянаУмаУрсулаУстинья Ф ФазиляФаинаФаридаФаризаФатимаФедораФёклаФелиситиФелицияФерузаФизалияФирузаФлораФлорентинаФлоренция ФлоренсФлорианаФредерикаФрида Х ХадияХилариХлояХюррем Ц ЦаганаЦветанаЦецилия СесилияЦиара Сиара Ч ЧелсиЧеславаЧулпан Ш ШакираШарлоттаШахинаШейлаШеллиШерил Э ЭвелинаЭвитаЭлеонораЭлианаЭлизаЭлинаЭллаЭльвинаЭльвираЭльмираЭльнараЭляЭмилиЭмилияЭммаЭнжеЭрикаЭрминаЭсмеральдаЭсмираЭстерЭтельЭтери Ю ЮлианнаЮлияЮнаЮнияЮнона Я ЯдвигаЯнаЯнинаЯринаЯрославаЯсмина";
    private static string MANS_SECONDNAMES_INPUT = "АлексеевичАнатольевичАндреевичАнтоновичАркадьевичАртемовичБедросовичБогдановичБорисовичВалентиновичВалерьевичВасильевичВикторовичВитальевичВладимировичВладиславовичВольфовичВячеславовичГеннадиевичГеоргиевичГригорьевичДаниловичДенисовичДмитриевичЕвгеньевичЕгоровичЕфимовичИвановичИванычИгнатьевичИгоревичИльичИосифовичИсааковичКирилловичКонстантиновичЛеонидовичЛьвовичМаксимовичМатвеевичМихайловичНиколаевичОлеговичПавловичПалычПетровичПлатоновичРобертовичРомановичСанычСевериновичСеменовичСергеевичСтаниславовичСтепановичТарасовичТимофеевичФедоровичФеликсовичФилипповичЭдуардовичЮрьевичЯковлевичЯрославович";
    private static string MANS_SURNAMES_INPUT = "СмирновИвановКузнецовСоколовПоповЛебедевКозловНовиковМорозовПетровВолковСоловьёвВасильевЗайцевПавловСемёновГолубевВиноградовБогдановВоробьёвФёдоровМихайловБеляевТарасовБеловКомаровОрловКиселёвМакаровАндреевКовалёвИльинГусевТитовКузьминКудрявцевБарановКуликовАлексеевСтепановЯковлевСорокинСергеевРомановЗахаровБорисовКоролёвГерасимовПономарёвГригорьевЛазаревМедведевЕршовНикитинСоболевРябовПоляковЦветковДаниловЖуковФроловЖуравлёвНиколаевКрыловМаксимовСидоровОсиповБелоусовФедотовДорофеевЕгоровМатвеевБобровДмитриевКалининАнисимовПетуховАнтоновТимофеевНикифоровВеселовФилипповМарковБольшаковСухановМироновШиряевАлександровКоноваловШестаковКазаковЕфимовДенисовГромовФоминДавыдовМельниковЩербаковБлиновКолесниковКарповАфанасьевВласовМасловИсаковТихоновАксёновГавриловРодионовКотовГорбуновКудряшовБыковЗуевТретьяковСавельевПановРыбаковСуворовАбрамовВороновМухинАрхиповТрофимовМартыновЕмельяновГоршковЧерновОвчинниковСелезнёвПанфиловКопыловМихеевГалкинНазаровЛобановЛукинБеляковПотаповНекрасовХохловЖдановНаумовШиловВоронцовЕрмаковДроздовИгнатьевСавинЛогиновСафоновКапустинКирилловМоисеевЕлисеевКошелевКостинГорбачёвОреховЕфремовИсаевЕвдокимовКалашниковКабановНосковЮдинКулагинЛапинПрохоровНестеровХаритоновАгафоновМуравьёвЛарионовФедосеевЗиминПахомовШубинИгнатовФилатовКрюковРоговКулаковТерентьевМолчановВладимировАртемьевГурьевЗиновьевГришинКононовДементьевСитниковСимоновМишинФадеевКомиссаровМамонтовНосовГуляевШаровУстиновВишняковЕвсеевЛаврентьевБрагинКонстантиновКорниловАвдеевЗыковБирюковШараповНиконовЩукинДьячковОдинцовСазоновЯкушевКрасильниковГордеевСамойловКнязевБеспаловУваровШашковБобылёвДоронинБелозёровРожковСамсоновМясниковЛихачёвБуровСысоевФомичёвРусаковСтрелковГущинТетеринКолобовСубботинФокинБлохинСеливерстовПестовКондратьевСилинМеркушевЛыткинТуров";


    public static List<string> MANS_NAMES = GetManNames();
    public static List<string> MANS_SURNAMES = GetManSurnames();
    public static List<string> MANS_LASTNAMES = GetManLastnames();

    public static Employee GetEmployees()
    {
        int i1 = GetRandom(MANS_NAMES.Count() - 1);
        int i2 = GetRandom(MANS_SURNAMES.Count() - 1);
        int i3 = GetRandom(MANS_LASTNAMES.Count() - 1);
        if (i1 < 0 || i2 < 0 || i3 < 0)
        {
            throw new Exception("Индекс не может быть меньше нуля");
        }
        Api.Utils.Info($"{i1},{i2},{i3}");
        string[] names = MANS_NAMES.ToArray();
        string name = names[i1];
        string[] surnames = MANS_SURNAMES.ToArray();
        string surname = surnames[i2];
        string[] lastnames = MANS_LASTNAMES.ToArray();
        string lastname = lastnames[i3];
        return new Employee()
        {
            FirstName = name,
            SurName = surname,
            LastName = lastname,
            Birthday = new DateTime(DateTime.Now.Year - GetRandom(50), GetRandom(12), GetRandom(28)),
            Tel = $"7-9{GetRandom(9)}{GetRandom(9)}-{GetRandom(9)}{GetRandom(9)}{GetRandom(9)}-{GetRandom(9)}{GetRandom(9)}{GetRandom(9)}{GetRandom(9)}",


        };
    }

    static int GetRandom(int max)
    {
        int res = new Random().Next(max);
        return res == 0 ? 1 : res;
    }

    public static List<string> GetManNames()
    {
        List<string> names = new List<string>();
        foreach (string text in MANS_NAMES_INPUT.Split(" "))
        {
            if (text.Length > 1)
            {
                names.AddRange(new List<string>(TextNaming.SplitName(text)));
            }
        }
        return names;
    }
    public static List<string> GetManLastnames()
    {
        List<string> names = new List<string>();
        foreach (string text in MANS_SECONDNAMES_INPUT.Split(" "))
        {
            if (text.Length > 1)
            {
                names.AddRange(new List<string>(TextNaming.SplitName(text)));
            }
        }
        return names;
    }
    public static List<string> GetManSurnames()
    {
        List<string> names = new List<string>();
        foreach (string text in MANS_SURNAMES_INPUT.Split(" "))
        {
            if (text.Length > 1)
            {
                names.AddRange(new List<string>(TextNaming.SplitName(text)));
            }
        }
        return names;
    }
    public static List<string> GetWomanNames()
    {
        List<string> names = new List<string>();
        foreach (string text in WOMANS_NAMES_INPUT.Split(" "))
        {
            if (text.Length > 1)
            {
                names.AddRange(new List<string>(TextNaming.SplitName(text)));
            }
        }
        return names;
    }
}
namespace EnterpriceResourcePlaning.OrganizationModel { }