
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class MedicalRealmInitiallizer: IDisposable
{
    private AppDbContext db;
    public MedicalRealmInitiallizer(AppDbContext ctx) {
        db = ctx;
    }

    public void Dispose()
    {
        db.Dispose();
    }

    public void Info(object item)
    {
        Console.WriteLine($"[Info][{typeof(MedicalRealmInitiallizer).Name}]: {item}");
    }


    public void InitMedicalPositions()
    {
        Info("Create Position");
        db.ManagmentPositions.Add(new Position()
        {
            Name = "Врач терапевт"
        });
        Info("Create Position");
        db.Add(new Position()
        {
            Name = "Окулист"
        });
        Info("Create Position");

        db.Add(new Position()
        {
            Name = "Невролог"
        });
        db.Add(new Position()
        {
            Name = "Лор"
        });
        db.Add(new Position()
        {
            Name = "Гастринтеролог"
        });
        db.Add(new Position()
        {
            Name = "Гастринтеролог"
        });
        db.Add(new Position()
        {
            Name = "Хирург"
        });
        db.SaveChanges();
    }


    public void ValidateMedicalRealm()
    {
        //InitMedicalPositions();
        //InitMedicalOrganiztions();

    }

    private void InitMedicalOrganiztions()
    { 
        if (db.Organizations.Count() == 0)
        {
            for (int i = 0; i < 255; i++)
            {
                BaseOrganization mo = null;
                db.Add(mo = new BaseOrganization()
                {
                    Name = "Городская поликлиника №" + i
                });
                db.SaveChanges();

                mo.ManagmentDepartments = new List<Managment.DataModel.Department>();
                mo.ManagmentDepartments.Add(CreateMedicalReceptionDepartment());
                mo.ManagmentDepartments.Add(CreateStatisticsDepartment());
                mo.ManagmentDepartments.Add(CreateFinancialDepartment());
                mo.ManagmentDepartments.Add(new Managment.DataModel.Department()
                {
                    Name = "Хозяйственный отдел"
                });
                mo.ManagmentDepartments.Add(HumanResourceDepartment());
                mo.ManagmentDepartments.Add(CreateAdministraqtiveDepartment());
                mo.ManagmentDepartments.Add(CreateMedicalTerapyDepartment());
                mo.ManagmentDepartments.Add(CreateDiagnosticsDepartment());
                mo.ManagmentDepartments.Add(CreateLabDeaprtment());

            }
        }
        db.SaveChanges();



            
    }

    private Managment.DataModel.Department CreateLabDeaprtment()
    {
        var dep = new Managment.DataModel.Department()
        {
            Name = "Биохимичская лаборатория",
            Type = "LabDepartment"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

      

    private Managment.DataModel.Department CreateDiagnosticsDepartment()
    {
        var dep = new Managment.DataModel.Department()
        {
            Name = "Процедурный кабинет"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private Managment.DataModel.Department CreateMedicalTerapyDepartment()
    {
        var dep = new Managment.DataModel.Department()
        {
            Name = "Терапевтическое отделение"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private Managment.DataModel.Department CreateAdministraqtiveDepartment()
    {
        var dep = new Managment.DataModel.Department()
        {
            Name = "Администрация"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private Employee GetManagmentEmployees()
    {
        return new Employee() { 
            
        };
    }

    private Managment.DataModel.Department HumanResourceDepartment()
    {
        var dep = new Managment.DataModel.Department()
        {
            Name = "Отдел кадров"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private Managment.DataModel.Department CreateFinancialDepartment()
    {
        var dep = new Managment.DataModel.Department()
        {
            Name = "Бухгалтерия"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private Managment.DataModel.Department CreateStatisticsDepartment()
    {
        var dep = new Managment.DataModel.Department()
        {
            Name = "Статистика"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }

    private Managment.DataModel.Department CreateMedicalReceptionDepartment()
    {
        var dep = new Managment.DataModel.Department()
        {
            Name = "Регистратура"
        };
        dep.Employees = new List<Employee>();
        dep.Employees.Add(GetManagmentEmployees());
        return dep;
    }
}

