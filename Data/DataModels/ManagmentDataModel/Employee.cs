﻿
using NetCoreConstructorAngular.Data.DataAttributes.AttributeControls;


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Сведения о сотрудниках организации, его должности, подразделении и трудовым договором. 
/// </summary>
[Label("Сотрудник")]
[SearchTerms("SurName,FirstName,LastName")]
public class Employee : DictionaryTable 
{




    [Required(ErrorMessage = "Введите фамилию сотрудника")]
    [MaxLength(40)]
    [Label("Фамилия сотрудника")]
    [InputRusText("Фамилию нужно записывать исп. кириллицу")]
    [InputText()]
    public string SurName { get; set; } = "";


    [Required(ErrorMessage = "Введите имя сотрудника")]
    [MaxLength(40)]
    [Label("Имя")]
    [InputRusText("Имя нужно записывать исп. кириллицу")]
    [InputText()]
    public string FirstName { get; set; } = "";


    [Required(ErrorMessage = "Введите отчество сотрудника")]
    [MaxLength(40)]
    [Label("Отчество")]
    [InputRusText("Отчество нужно записывать исп. кириллицу")]
    [InputText()]
    public string LastName { get; set; } = "";


    [Required(ErrorMessage = "Введите дату рождения сотрудника")]
    [MaxLength(40)]
    [Column(TypeName = "date")]
    [Label("Дата рождения")]
    [InputDate()]
    public DateTime Birthday { get; set; } = DateTime.Now;


    [Required(ErrorMessage = "Введите номер телефона сотрудника")]
    [MaxLength(40)]
    [Label("Номер телефона")]
    [InputPhone()]
    public string Tel { get; set; } = "";




    [Label("Подразделение")]
    [InputNumber("Department,Name")]
    [SelectDataDictionary("Department,Name")]
    public int DepartmentID { get; set; } = 1;

    [Label("Подразделение")]
    [InputHidden(true)]
    public virtual Managment.DataModel.Department Department { get; set; }


    [Label("Должность")]
    [SelectDataDictionary("Position,Name")]
    public int PositionID { get; set; } = 1;

    [Label("Должность")]
    public virtual Position Position { get; set; }


    [Label("ФИО")]
    public override string Name
    {
        get
        {
            return SurName + " " + FirstName + " " + LastName;
        }
    }

    [Label("Резюме")]

    public override string Description
    {
        get
        {
            return SurName + " " + FirstName + " " + LastName;
        }
    }




    public Employee()
    {
        Expiriences = new List<EmployeeExpirience>();
        Description = "{{SurName}} {{FirstName}} {{LastName}}";
        Name = "{{SurName}} {{FirstName}} {{LastName}}";
    }


    public List<EmployeeExpirience> Expiriences { get; set; } = new List<EmployeeExpirience>();


}
