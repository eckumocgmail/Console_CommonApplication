using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TypeDescription: FromAttributes
{


    public class MemberDescription: FromAttributes
    {
        public string Name { get; set; }
        public string Icon { get; set; } = "home";
        public string Label { get; set; } = "";
        public string Description { get; set; } = "";
        public string HelpMessage { get; set; } = "";

        public MemberDescription(Type t, string name)
        {
            if (t.IsMethod(name))
                Init(t, t.GetMethods().FirstOrDefault(m => m.Name == name));
            else if (t.IsProperty(name))
                Init(t, t.GetProperties().FirstOrDefault(m => m.Name == name));
        }
    }



    public string Name { get; set; }
    public string EntityIcon { get; set; } = "home";
    public string EntityLabel { get; set; } = "";
    public string HelpMessage { get; set; } = "";
    public string ClassDescription { get; set; } = "";


    public Dictionary<string, MemberDescription> PropertiesDictionary { get; set; } = new Dictionary<string, MemberDescription>();
    public Dictionary<string, MemberDescription> ActionsDictionary { get; set; } = new Dictionary<string, MemberDescription>();


    public TypeDescription( Type type )
    {
        Init(type);
        Name = type.Name;
        type.GetOwnPropertyNames().ToList().ForEach(name =>
            PropertiesDictionary[name] = new MemberDescription(type, name)
        );
        type.GetOwnPropertyNames().ToList().ForEach(name =>
            ActionsDictionary[name] = new MemberDescription(type, name)
        );
    }
}