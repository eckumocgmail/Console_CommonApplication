using Data.RepositoryPattern;

using DataCommon.DatabaseMetadata;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static EFDbModel;


/// <summary>
/// Сущности и операции
/// </summary>
public class EFDbModel: DbContext
{


    public DbSet<BusinessEvents> Events { get; set; } 








    
}



/// <summary>
/// 
/// </summary>
public class ServiceMetadata
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Queue { get; set; }
    public string Counter { get; set; }
}



public class UserCustomer
{
    public int ID { get; set; }
    public string Name { get; set; }
}


public class UserEmployee
{
    public int ID { get; set; }
    public string Name { get; set; }
}


/// <summary>
/// 
/// </summary>
public class BusinessEvents : ProcedureMetadata
{
    public int ID { get; set; }
    public int UserCustomerID { get; set; }
    public int UserEmployeeID { get; set; }
}

public class EventsEntityRepository : EntityRepository<BusinessEvents>
{

    public override DbSet<BusinessEvents> GetDbSet(DbContext context) => ((EFDbModel)_context).Events;
    public EventsEntityRepository(EFDbModel context) : base(context)
    {
    }

    
}



public class EntityFasadeUnit : TestingUnit
{
    public EntityFasadeUnit()
    {
        using (var db = new EFDbModel())
        {
            db.Database.EnsureCreated();
            var repository = new EventsEntityRepository(db);
            repository.Post(new BusinessEvents()            
            {
                ProcedureName="asd"

            });
        }

    }
}