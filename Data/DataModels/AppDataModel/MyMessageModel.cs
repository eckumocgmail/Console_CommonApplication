using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class MyMessageProperty 
{
    public string Name { get; set; }
    public string Type { get; set; }
    public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
    public bool IsCollection { get; 
        set; }
}



[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class MyMessageModel
{
    public string Name { get; set; }
    public List<MyMessageProperty> Properties { get; set; }
    public MyMessageProperty GetProperty(string name)
    {
        return (from p in Properties where p.Name == name select p).FirstOrDefault();
    }

    public MyMessageModel(Type type)
    {
        try
        {
            this.Name = type.Name;
            this.Properties = new List<MyMessageProperty>();
            foreach (var property in type.GetProperties())
            {
                string TypeName = property.PropertyType.Name;
                bool IsCollection = false;

                if (property.PropertyType.Name.StartsWith("List"))
                {
                    IsCollection = true;
                    string text = property.PropertyType.AssemblyQualifiedName;
                    text = text.Substring(text.IndexOf("[[") + 2);
                    text = text.Substring(0, text.IndexOf(","));
                    TypeName = text.Substring(text.LastIndexOf(".") + 1);
                    //Api.Utils.Info(property.Name + " " +text);
                }
                this.Properties.Add(new MyMessageProperty {
                    Name = property.Name,
                    IsCollection = IsCollection,
                    Type = TypeName,
                    Attributes = Utils.ForProperty(type, property.Name)
                });
            }
        }
        catch (Exception ex)
        {
            Api.Utils.Info(ex);
        }
    }
}



