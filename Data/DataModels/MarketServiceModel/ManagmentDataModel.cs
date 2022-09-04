using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class ManagmentDataModel : BaseDbContext, IManagmentDataModel
{
    public ManagmentDataModel() { }
    public ManagmentDataModel(DbContextOptions<ManagmentDataModel> options) : base(options)
    {

    }
    protected override void InitDbSets()
    {
    }
 
    /// <summary>
    /// Создание структуры данных
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
     



        //uniq constraint
        builder.Entity<Managment.DataModel.Department>()
               .HasIndex(u => u.Name)
               .IsUnique();

        //uniq constraint
        builder.Entity<Position>()
               .HasIndex(u => u.Name)
               .IsUnique();


        //uniq constraint
        builder.Entity<Employee>()
               .HasIndex(u => new { u.FirstName, u.SurName, u.LastName, u.Birthday })
               .IsUnique();


        //uniq constraint
        builder.Entity<EmployeeExpirience>()
               .HasIndex(u => new { u.EmployeeID, u.SkillID, u.Begin })
               .IsUnique();


        //uniq constraint
        builder.Entity<PositionStats>()
               .HasIndex(u => new { u.RateActivatedDate, u.PositionID })
               .IsUnique();

        //uniq constraint
        builder.Entity<Skill>()
               .HasIndex(u => new { u.Name })
               .IsUnique();



        //uniq constraint
        builder.Entity<StaffsTable>()
               .HasIndex(u => new { u.DepartmentID, u.PositionID, u.StaffActivatedDate })
               .IsUnique();



        //uniq constraint
        builder.Entity<PaymentPersonal>()
               .HasIndex(u => new { u.PositionID })
               .IsUnique();


        //uniq constraint
        builder.Entity<TimeSheet>()
               .HasIndex(u => new { u.BeginTime, u.EndTime, u.EmployeeID })
               .IsUnique();

    }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
            optionsBuilder.UseInMemoryDatabase(nameof(AppDbContext));
            
            /*optionsBuilder.UseSqlServer(
                @"Server=KEST;Database=" + nameof(AuthorizationDataModel) +
                @";Trusted_Connection=True;MultipleActiveResultSets=true;"
            );*/
    }



    public DbSet<ManagmentLocation> Locations { get; set; }
    public DbSet<TimePoint> Calendars { get; set; }
    public DbSet<BaseOrganization> Organizations { get; set; }
    public DbSet<Managment.DataModel.Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeExpirience> EmployeeExpirience { get; set; }
    public DbSet<PositionStats> PositionStats { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<PositionFunction> PositionFunctions { get; set; }
    public DbSet<FunctionSkills> FunctionSkills { get; set; }
    public DbSet<SalaryReport> SalaryReports { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<StaffsTable> Staffs { get; set; }
    public DbSet<PaymentPersonal> TariffRates { get; set; }
    public DbSet<TimeSheet> TimeSheets { get; set; }
}