using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class HierDictionary: HierDictionary<Action>
{

}




/// <summary>
/// Иерархическое преждставление набора данных
/// </summary>
/// <typeparam name="T"></typeparam>
public class HierDictionary<T>: DictionaryTable where T : class
{

    [Label("Корневой каталог")]        
    [InputHidden(true)]
    [NotInput("")]
    public int? ParentID { get; set; }



    [InputHidden(true)]
    [NotInput("")]
    [JsonIgnore()]
    public virtual T Parent { get; set; }


   

    /// <summary>
    /// Путь к узлу
    /// </summary>
    /// <returns></returns>
    public List<HierDictionary<T>> GetPath()
    {
        var path = new List<HierDictionary<T>>();
        path.Add(this);
        object p = Parent;            
        if(p != null)
        {            
            path.AddRange(((HierDictionary<T>)p).GetPath());
        }
        return path;
    }


    



}
 