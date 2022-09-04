using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public partial class BaseEntity : MyValidatableObject
{
     
    public BaseEntity(): base()
    {
       
    }

    [Key]
    [Label("Идентификатор")]
    [InputHidden(true)]
    [NotInput]
    public virtual int ID { get; set; }


 







    /*public object this[string prop] => Compile(prop);

    */

    public object Compile(string expression)
    {
        return ObjectCompileExpExtensions.Expression.Compile(expression, this);
    }

    

    public object Get(string prop)
    {
        return ReflectionService.GetValueFor(this, prop);
    }
     
    

    /*public Wizzard ToInputWizzard()
    {
        Wizzard wizard = new Wizzard();
        foreach (INavigation pnav in this.GetNotNullableNavigations())
        {
            var prop = this.GetType().GetProperty(pnav.Name);
            if (prop.GetValue(this) != null)
            {
                continue;
            }
            var propertyType = prop.PropertyType;
            ViewItem next = null;
            if (Typing.IsCollectionType(propertyType))
            {
                if (IsManyToManyRelation(this.GetType(), pnav.Name))
                {

                }
                else
                {



                    //new ListService().CreateForCollection(
                  //      Attrs.LabelFor(this.GetType(), prop.Name),
                  //      prop.GetValue(this),
                  //      prop.PropertyType.Name,
                  //      (ptarget) => {
                  //          return ptarget;
                 //       }
                 //   );
                }
            }
            else
            {
                //next = ReflectionService.CreateWithDefaultConstructor<BaseEntity>(propertyType).ToForm();
                //wizard.SetNextDialog(next);
            }

            //

        }
        wizard.SetNextDialog(this.ToForm());
        return wizard;
    }*/

    private bool IsManyToManyRelation(Type type, string name)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public IList<INavigation> GetNotNullableNavigations()
    {
        var ctrl = this;
        return (from p in GetNavigations() where Typing.IsNullable(ctrl.GetType().GetProperty(p.Name)) == false select p).ToList();
    }




    /// <summary>
    /// Список свойств навигации
    /// </summary>
    /// <returns></returns>
    public IEnumerable<INavigation> GetNavigations()
    {
        return GetNavigation(this.GetType());
    }

    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    [JsonIgnore]
    public IEnumerable<INavigation> Navigations { get; set; }
    private IEnumerable<INavigation> GetNavigation(Type type)
    {
        return this.Navigations;
    }


    /// <summary>
    /// Фильтрация свовойств навигации исп. функцию спецификации
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>

    private List<string> GetQualifiedRelationsWith(Func<Type, bool> filter)
    {
        var ctrl = this;

        Func<INavigation, bool> IsDictionary = (nav) =>
        {
            var propertyType = ctrl.GetType().GetProperty(nav.Name).PropertyType;
            if (Typing.IsCollectionType(propertyType))
            {
                //TODO:
                return false;
            }
            else
            {
                if (filter(propertyType))
                {
                    return true;
                }
                return false;
            }
        };
        return GetNavigation(this.GetType()).Where(nav => IsDictionary(nav)).Select(p => p.Name).ToList();
    }

    public List<string> GetDictionaries()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsDictionaryTable(t);
        });
    }

    public List<string> GetStats()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsStatsTable(t);
        });
    }

    public List<string> GetDailyStats()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsDailyStatsTable(t);
        });
    }

    public List<string> GetWeeklyStats()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsWeeklyStatsTable(t);
        });
    }

    public List<string> GetMonthlyStats()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsStatsTable(t);
        });
    }

    public List<string> GetDimensions()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsDimensionTable(t);
        });
    }

    public List<string> GetFacts()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsFactsTable(t);
        });
    }


    public List<string> GetHiers()
    {
        return GetQualifiedRelationsWith((t) => {
            return Typing.IsHierDictinary(t);
        });
    }


    public string ToText()
    {
        string text = "";
        ReflectionService.GetOwnPropertyNames(this.GetType()).ForEach(p => { text += ReflectionService.GetValueFor(this, p) + " "; });
        return "ID";
    }

    

   


    /// <summary>
    /// Получение списка имён свойств определённых в обьекте
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public string GetLabel()
    {
        object target = this;
        return AttrsUtils.LabelFor(target);
    }


    /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> results = new List<ValidationResult>();
        Dictionary<string, List<string>> errors = Validate();
        foreach(var errorEntry in errors)
        {
            string propertyName = errorEntry.Key;
            List<string> propertyErrors = errorEntry.Value;
            foreach(string propertyError in propertyErrors)
            {
                ValidationResult result = new ValidationResult(propertyError, new List<string>() { propertyName });               
                results.Add(result);
            }
        }        
        return results;
    }
    */

    /// <summary>
    /// Текст надписи, ан-но <label asp-for=""></label>
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public string LabelFor(string Name)
    {
        Dictionary<string, string> attrs = AttrsUtils.ForProperty(this.GetType(), Name);
        if (attrs.ContainsKey(nameof(LabelAttribute)) == false)
        {
            throw new Exception($"Для создания надписи с именем поля ввода " +
                $"установите атрибут Label на свойство {Name} в классе {this.GetType().Name}");
        }
        else
        {
            return attrs[nameof(LabelAttribute)];
        }
    }

  


    /// <summary>
    /// Получение описания определённого через атрибуты
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public string GetDescription()
    {
        BaseEntity target = this;
        return  Utils.DescriptionFor(target);
    }


    /// <summary>
    /// Получение списка имён свойств определённых в обьекте
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public List<string> GetPropertyNames()
    {
        BaseEntity target = this;
        List<string> names = new List<string>();
        foreach (PropertyInfo propertyInfo in target.GetType().GetProperties())
        {
            names.Add(propertyInfo.Name);
        }
        return names;
    }


    /// <summary>
    /// Получение списка имён свойств определённых в обьекте
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public List<string> GetFieldNames()
    {
        BaseEntity target = this;
        List<string> names = new List<string>();
        foreach (var propertyInfo in target.GetType().GetFields())
        {
            names.Add(propertyInfo.Name);
        }
        return names;
    }


   


      

}

