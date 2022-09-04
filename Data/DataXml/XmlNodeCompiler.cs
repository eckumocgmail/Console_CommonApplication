
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

public class XmlNodeCompiler
{
    private readonly IComponentFactory _componentFactory;
    private ReportItem root;

    public XmlNodeCompiler():this(new ComponentFactory())
    {
    }

    public XmlNodeCompiler( IComponentFactory componentFactory ) {

        _componentFactory = componentFactory;
    }


    public TypeNode<ComponentModel> Compile(string xml)
    {
        using (var reader = new StringReader(xml))
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(reader);
    

            // получим корневой элемент
            XmlNode pnode = xDoc.DocumentElement;
            return Compile(pnode, null, true);
        }
    }


    public TypeNode<ComponentModel> Compile(XmlNode pnode, TypeNode<ComponentModel> parent, bool isRoot)
    {
        if (isRoot == false)
        {
            if (pnode == null)
            {
                throw new ArgumentException("pnode");
            }
            if (parent == null)
            {
                throw new ArgumentException("parent");
            }
        }
        TypeNode<ComponentModel> compiled = null;
        if (pnode != null)
        {
            if (isRoot)
            {
                root = null;
            }
            InputParams inputParams = ParseCompileParams(pnode);
            ComponentModel parentComponent = parent != null ? parent.Item: null;
            object targetComponent = _componentFactory.Create(inputParams, parentComponent, root);
            ComponentModel CurrentComponent =   new ComponentModel() { 
                Input = inputParams,
                Target = targetComponent
            };
            compiled = new TypeNode<ComponentModel>(pnode.GetHashCode() + "", CurrentComponent, parent);
            if (isRoot)
            {
                root = (ReportItem)CurrentComponent.Target;
            }
            for (int i = 0; i < pnode.ChildNodes.Count; i++)
            {
                XmlNode node = pnode.ChildNodes.Item(i);
                //compiled.Append();
                Compile(node, compiled, false);
            }
        }

        return compiled;
    }



    private InputParams ParseCompileParams(XmlNode pnode)
    {

        string tag = pnode.Name;
        string log = pnode.Name;
        var attrs = new Dictionary<string, string>();
        if (pnode.Attributes != null)
        {
            for (int i = 0; i < pnode.Attributes.Count; i++)
            {
                attrs[TextNaming.ToCapitalStyle(pnode.Attributes.Item(i).Name)] = pnode.Attributes.Item(i).Value;
                log += " " + pnode.Attributes.Item(i).Name + "=" + pnode.Attributes.Item(i).Value;
            }
        }
        string text = "";
        if (pnode.ChildNodes.Count == 0)
        {
            text = pnode.InnerText;
        }
        return new InputParams()
        {
            Tag = tag,
            Attrs = attrs,
            Text = text
        };
    }

}
