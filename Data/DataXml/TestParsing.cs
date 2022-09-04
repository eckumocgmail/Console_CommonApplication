 

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

public class TestParsing
{
    static string reportXml = @"A:\Wrk\NetCoreConstructorAngular\NetCoreConstructorAngular\catalog.xml";
    public static void Test( )
    {
        try
        {
            Console.WriteLine(System.Convert.ToDateTime("01.01.2020"));
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(reportXml);

            // получим корневой элемент
        
            XmlNode pnode = xDoc.DocumentElement;
            xDoc.Info(pnode.OuterXml);
            var root = new XmlNodeCompiler().Compile(pnode,null,true);
            var report = new ReportComponent(root);
            report.OnInit();
            //Console.WriteLine(Formating.ToJson(root));


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.ReadLine();
        }
    }

    private static void PrintTypes()
    {
        foreach(Type t in Assembly.GetExecutingAssembly().GetTypes())
        {
            Console.WriteLine(t.Name);
        }
    }

    /// <summary>
    /// Форматирование обьекта в XML
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static string ToXML(object target)
    {
        XmlSerializer formatter = new XmlSerializer(target.GetType());
        using (StringWriter writer = new StringWriter())
        {
            formatter.Serialize(writer, target);
            writer.Flush();
            return writer.ToString();
        }
    }
}

   
 