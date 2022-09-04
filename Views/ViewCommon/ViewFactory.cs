using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ViewFactory: ViewNode
{ 

    public int Scope { get; set; }

    public object CreateViewModel( string typeName )
    {
        return ReflectionService.CreateWithDefaultConstructor<object>(typeName);
    }


    public void CreateLink(List<string> lists, ViewNode pnode)
    {
        if (lists.Count() >= 1)
        {
            string name = lists.Last();
            lists.RemoveAt(lists.Count() - 1);
            ViewNode node = Find(lists);

            node.Append(name, pnode);
        }
    }



    public string GetHelp() {
        return AttrsUtils.LabelFor(GetType());
    }



    public Form CreateForm( object target, Action<string,object> OnChanged)
    {
        var form = new Form(target);
        form.OnFormFieldValueChanged += (name, value) => {
            try
            {
                OnChanged(name, value);
            }
            catch (Exception ex)
            {
                this.Error("Ошибка при обработки события OnChange", ex);
            }
            return form;
        };
        return form;
    }


}
