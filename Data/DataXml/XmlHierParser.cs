using System;
using System.Collections.Generic;
using System.Text;



public class XmlElementModel
{
    public string Tag { get; set; }
    public string ContainerText { get; set; }
    public string InnerText { get; set; }

 
    public List<XmlElementModel> ParseChildren()
    {
        List<XmlElementModel> children = new List<XmlElementModel>();
        string xml = InnerText;
        int startIndex = xml.IndexOf("<");

        //начинающийся текст
        if ( startIndex > 0 )
        {
            var xmlTextNode = new XmlElementModel() {
                Tag = "",
                ContainerText = "",
                InnerText = xml.Substring(0, startIndex)
            };
            children.Add(xmlTextNode);
            xml = xml.Substring(startIndex);
        }

        //значит есть внутренний элеемент
        if(startIndex != -1)
        {

        }


        //завершающий текст
        if (xml.Length > 0)
        {
            var xmlTextNode = new XmlElementModel()
            {
                Tag = "",
                ContainerText = "",
                InnerText = xml
            };
            children.Add(xmlTextNode);
            xml = "";
        }
        return children;
    }
}

public class XmlHierParser
{

    public void Parse(string xml)
    {
    }
    /*public XmlElementModel Parse(XmlElementModel model, string xml)
    {
        var pnode = new XmlElementModel();
            
        int openIndex = xml.IndexOf("<");
        return model;


        /*string elementText = "";
        string innerText = "";
        bool intag = false;
        for (int i = 0; i < xml.Length; i++)
        {
            if(intag == false)
            {
                if (xml[i] == '<')
                {
                    intag = true;
                }
                else
                {

                }

            }
            else
            {
                if( xml[i] == '>')
                {
                    intag = false;
                    elementText = "";
                }
                else
                {
                    elementText += xml[i];
                }
            }
        }


    }*/
}
