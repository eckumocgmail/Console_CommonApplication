using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;


public class XmlDoc
{
    public string Name { get; set; }
    public string Label { get; set; }
    public string Summary { get; set; }
    public string Required { get; set; }
    public string Default { get; set; }
    public string Icon { get; set; }
    public string Editor { get; set; }
    public string Display { get; set; }
}

public class XmlDocParser
{
    private static string DEFAULT_PATH = @"A:\Expirience\NetCore\eckumoc-netcore-mvc-angularjs-material\eckumoc-netcore-mvc-angularjs-material\wwwroot\api.xml";

    public static Dictionary<string, XmlDoc> members = new Dictionary<string, XmlDoc>();


    public static Dictionary<string, XmlDoc> Parse()
    {
        return Parse(DEFAULT_PATH);
    }







    public static Dictionary<string, XmlDoc> Parse(string absolutelyPath )
    {
        
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(absolutelyPath);

        // получим корневой элемент
        XmlElement xRoot = xDoc.DocumentElement;
            
        // обход всех узлов в корневом элементе
        foreach (XmlNode xnode in xRoot.ChildNodes.Item(1))
        {            
            if(xnode.Attributes == null)
            {
                continue;
            }

            ReflectionService reflection = new ReflectionService();
            XmlNode attr = xnode.Attributes.GetNamedItem("name");
            if(attr != null)
            {
                members[attr.Value.Substring(2)] = new XmlDoc() { 
                    Name = attr.Value.Substring(2)
                };
                /*if("ApplicationDb.Entities.Person.SurName"== attr.Value.Substring(2))
                {
                    
                }*/

                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    string key = childnode.Name;
                     
                    
                    string value = childnode.InnerText;
                    if (value != null)
                    {
                        switch (key)
                        {
                            case "summary":
                                members[attr.Value.Substring(2)].Summary = value;
                                break;
                        }
                    }
                       
                  
                }
            }                        
        }
        return members;
    }
}

