 


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

[Label("Бизнес функция")]
[SearchTerms("Name")]
public class BusinessFunction : BusinessEntity<BusinessFunction>, APIActiveObject, DoCheck
{
    [InverseProperty("To")]
    public virtual MessageProtocol Input { get; set; }

    [InverseProperty("From")]
    public virtual MessageProtocol Output { get; set; }

    public virtual int BusinessResourceID { get; set; }
    public virtual BusinessResource BusinessResource { get; set; }
    public virtual BusinessLogic BusinessLogic { get; set; }


    [NotMapped( )]
    public List<BusinessFunction> SubFunctions { get; set; } = new List<BusinessFunction>();

    [ManyToMany("BusinessFunctions")]
    public virtual List<global::GroupsBusinessFunctions> GroupsBusinessFunctions { get; set; }
    

    public MessageProtocol GetInputProtocol()
    {
        using (var db = new BusinessDataModel())
        {
            return (from p in db.MessageProtocols where p.ToBusinessFunctionID == this.ID select p).FirstOrDefault();
        }
    }

    /// <summary>
    /// Возвращает протокол отчётных форм, определённый как исходящая информация для данной бизнес функции
    /// </summary>
    /// <returns></returns>
    public MessageProtocol ForOutput()
    {
        using (var db = new BusinessDataModel())
        {
            return (from p in db.MessageProtocols where p.FromBusinessFunctionID == this.ID select p).FirstOrDefault();
        }
    }



    /// <summary>
    /// Возвращает протокол отчётных форм, определённый как входящая информация для данной бизнес функции
    /// </summary>
    /// <returns></returns>
    public Form ForInput()
    {
        using (var db = new BusinessDataModel())
        {
            var prot = (from p in db.MessageProtocols where p.ToBusinessFunctionID == this.ID select p).FirstOrDefault();
            return null;
        }
    }



    /// <summary>
    /// Возвращает список всех дочерних функций
    /// </summary>
    /// <returns></returns>
    public List<BusinessFunction> FlatList()
    {
        List<BusinessFunction> functions = new List<BusinessFunction>();
        this.SubFunctions.ForEach(sf => {
            functions.AddRange(sf.FlatList());
        });
        functions.Add(this);
        return functions;
    }
    

    public string GetPath(string separator)
    {        
        BusinessFunction parentHier = Parent;
        return (Parent != null) ? parentHier.GetPath(separator) + separator +
            Name : Name;
    }


    

    public List<BusinessFunction> GetSubfunctions()
    {
        if(SubFunctions == null)
        {
            using(var db = new BusinessDataModel())
            {
                SubFunctions = (from p in db.BusinessFunctions where p.ParentID == ID select p).ToList();
            }
            
        }
        return SubFunctions;
    }

    public RequestMessage ActionEvent(ResponseMessage message)
    {
        throw new System.NotImplementedException();
    }

    public Task<RequestMessage> ActionEventAsync(ResponseMessage message)
    {
        throw new System.NotImplementedException();
    }

    public Task DoCheck(long timeout)
    {
        throw new System.NotImplementedException();
    }
}
 