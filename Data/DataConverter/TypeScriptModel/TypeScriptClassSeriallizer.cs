using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

 
public class TypeScriptClassSeriallizer: ModelConverter
{


    public string ToTypeScript(Type type)
    {
        var model = base.ToTypeScriptModel(type);
        model.Name = type.GetTypeName();
        return ToTypeScript(model);
    }

    public string ToTypeScript(TypeScriptClassModel model)
    {
        string ts = @$"class {model.Name}" + "{\n";
        foreach(var pair in model.Properties)
        {
            ts += ToTypeScript(pair.Value);
        }
        foreach (var pair in model.Methods)
        {
            ts += ToTypeScript(pair.Value);
        }
        ts += "}";
        return ts;
    }


    /**
        *             ts += $"\t\tlet pars = this.toHttpParams({tsParamMap});\n";
        ts += $"\t\treturn this.http.get('{actionModel.Path}',pars);\n";
        */
    public string ToTypeScript(TypeScriptActionModel model)
    {
        string ts = "\n";
            
        string tsName = TextNaming.ToCamelStyle(model.Name);
        string tsParamDeclaration = "";
        string tsParamMap = "{\n";
        foreach (var key in model.Parameters.Keys)
        {
            tsParamDeclaration += key + ",";
            tsParamMap += $"\t\t\t{key}: {key},\n";
        }
        if (tsParamMap.EndsWith(",\n"))
        {
            tsParamMap = tsParamMap.Substring(0, tsParamMap.Length - 2);
        }
        tsParamMap += "\n\t\t} ";
        if (tsParamDeclaration.EndsWith(","))
        {
            tsParamDeclaration = tsParamDeclaration.Substring(0, tsParamDeclaration.Length - 1);
        }
        ts += $"\tpublic {tsName}( {tsParamDeclaration} )" + "{\n";
        ts += model.Implementation;
        ts += "\t}\n\n";
        return ts;
    }

    public string ToTypeScript(TypeScriptPropertyModel model)
    {
        string ts = "\t" + model.Name+":"+model.Type+";\n";
        return ts;
    }
}
 