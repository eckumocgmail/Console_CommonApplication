using ApplicationCore.Converter.Models;
using DataConverter.Generators;
using System;
using System.Collections.Generic;

public class ModelConverter: PropertyConverter
{

    public TypeScriptClassModel ToTypeScriptModel( Type type )
    {
        var model = new TypeScriptClassModel();
        model.Constructor = new TypeScriptConstructorModel()
        {
            Parameters = new Dictionary<string, MyParameterDeclarationModel>() {
                { "hashcode", new MyParameterDeclarationModel(){
                    Name="hashcode",
                    IsOptional = false,
                    Type = "number"
                } },
                { "json", new MyParameterDeclarationModel(){
                    Name="json",
                    IsOptional = true,
                    Type = "string"
                } },
            }
        };
        model.Constructor.Implementation += "\t\tthis.hashcode = hashcode;\n";
        model.Constructor.Implementation += "\t\tif(json)Object.assign(this,JSON.parse(json));\n";
        try
        {
            try
            {
                foreach (var property in type.GetOwnPropertyNames())
                {
                    this.Info(property);
                    TypeScriptPropertyModel tsprop = ToTypeScriptModel(type.GetProperty(property));
                    model.AddProperty(tsprop);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при формировании свойств типа TypeScript. ", ex);
            }

            try
            {
                foreach (var method in type.GetOwnMethodNames())
                {
                    this.Info(method);
                    if (method.StartsWith("remove_") == true || method.StartsWith("add_") == true || method.StartsWith("get_") == true || method.StartsWith("set_") == true)
                        continue;
                    TypeScriptActionModel tsaction = ToTypeScriptModel(type.GetMethod(method));
                    model.AddMethod(tsaction);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при формировании методов типа TypeScript. ", ex);
            }
        }catch (Exception ex)
        {
            this.Error(ex);
            return model;
        }
        return model;
    }



    public TypeScriptActionModel ToTypeScriptModel(System.Reflection.MethodInfo method)
    {
        TypeScriptActionModel action = new TypeScriptActionModel();
        action.Name = TextNaming.ToCamelStyle(method.Name);
        string tsParamMap = "\t\tconst pars = {\n";
            
            
        foreach (var parameter in method.GetParameters())
        {
            var par = new MyParameterDeclarationModel();
            par.Type = GetTypeScriptDataType(parameter.ParameterType);
            par.Name = TextNaming.ToCamelStyle(parameter.Name);
            par.IsOptional = par.IsOptional;
            action.Parameters[par.Name] = par;

            tsParamMap += $"\t\t\t{TextNaming.ToCamelStyle(parameter.Name)}: {TextNaming.ToCamelStyle(parameter.Name)},\n";
        }
        if (tsParamMap.EndsWith(",\n"))
        {
            tsParamMap = tsParamMap.Substring(0, tsParamMap.Length - 2);
        }
        tsParamMap += "\n\t\t}\n";
        action.Implementation = tsParamMap;
        action.Implementation += "\t\t" + "return window['$app'].$invoke.$method(''+this.hashcode, '" + method.Name + "',{Name: '@nav.Name'});\n";
        return action;
    }



    public TypeScriptPropertyModel ToTypeScriptModel(System.Reflection.PropertyInfo property)
    {
        return new TypeScriptPropertyModel()
        {
            Name = TextNaming.ToCamelStyle(property.Name),
            Type = GetTypeScriptDataType(property.PropertyType),
            IsOptional = false
                
        };
    }
}
