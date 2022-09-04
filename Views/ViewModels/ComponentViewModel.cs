using ApplicationDb.Entities;
 
using Microsoft.EntityFrameworkCore.Metadata;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



public class ComponentViewModel: ViewItem
{
    
    [JsonIgnore()]
    public IEnumerable<INavigation> Navigation { get; set; }
    public object Item { get; set; }
    public string ActivePropertyName { get; set; }


    

    public bool IsCollection { get; set; } = false;
    public object Active 
    { 
        get
        {
            if(ActivePropertyName == null)
            {
                ActivePropertyName = Navigation.First().Name;
            }
            return (Item==null || ActivePropertyName==null)? null:
                    new ReflectionService().GetValue(Item, ActivePropertyName );
        }
    }

    public bool SetActive(string Name)
    {
        ActivePropertyName = Name;
        Changed = true;
        IsCollection = Typing.IsCollectionType(Item.GetType());        
        return true;
    }
      


    public ComponentViewModel() : this(new UserApi())
    {
        Changed = false;
    }


    public ComponentViewModel(object item)
    {
        
        Item = item;
        Navigation = GetNavigation(Item.GetType());
        ActivePropertyName = Navigation.First().Name;
        Changed = false;
    }

    private IEnumerable<INavigation> GetNavigation(Type type)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}

