using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using NetCoreConstructorAngular.Data.DataAttributes;

using static Api.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace UserAuthorization.DataAttributes.AttributeDisplay { }

public class AttrsUtils
{
    public static object BindingsFor(string entity)
    {
        return BindingsFor(ReflectionService.TypeForName(entity));
    }


    





    public static object BindingsFor(Type type)
    {
        var attrs = GetEntityContrainsts(type);
        return attrs;

    }


    /// <summary>
    /// Возвращает значение атрибута установленного для типа обьекта
    /// </summary>
    /// <param name="target"></param>
    /// <param name="attrName"></param>
    /// <returns></returns>
    public static string GetTypeAttrValue(object target, string attrName)
    {
        var attrs = GetEntityContrainsts(target.GetType());
        if( attrs.ContainsKey(attrName)==false)
        {
            return null;
        }
        else
        {
            return attrs[attrName];
        }
    }

    /// <summary>
    /// Возвращает значение атрибута установленного для типа обьекта
    /// </summary>
    /// <param name="target"></param>
    /// <param name="attrName"></param>
    /// <returns></returns>
    public static string GetRequiredTypeAttrValue(object target, string attrName)
    {
        var attrs = GetEntityContrainsts(target.GetType());
        if (attrs.ContainsKey(attrName) == false)
        {
            throw new Exception($"Тип {target.GetType().Name} должен содержать атрибут {attrName}.");
        }
        else
        {
            return attrs[attrName];
        }
    }

    /// <summary>
    /// Возвращаент имя свойства помеченного заданным атриюбутом
    /// </summary>
    /// <param name="target"></param>
    /// <param name="nameOfInputTypeAttribute"></param>
    /// <returns></returns>
    public static object GetValueMarkedByAttribute(object target, string nameOfInputTypeAttribute ){
        return AttrsUtils.ForAllPropertiesInType(target.GetType()).Where(p=>p.Value.ContainsKey(nameOfInputTypeAttribute)).Select(p=>p.Key).Single();

    }
    public static List<string> GetSearchTerms(string entity)
    {
        Type entityType = ReflectionService.TypeForShortName(entity);
        List<string> terms = AttrsUtils.SearchTermsForType(entityType);
        return terms;
    }

    
    public static bool HasInputImage(Type type)
    {
        string prop = GetInputImagePropertyName(type);
        if( prop == null)
        {
            foreach (var nav in type.GetProperties().Where(p => p.PropertyType.IsPrimitive==false))
            {
                if(TypesExtensions.IsCollectionType(nav.GetType()) == false)
                {
                    prop = GetInputImagePropertyName(nav.GetType());
                    if (prop != null)
                    {
                        break;
                    }
                }
            }
        }
        return prop == null ? false : true;
    }

    public static string GetInputImageUrlExpression()
    {     
        return @"/api/Resource/Image?entity={{GetType().Name}}&id={{ID}}";
    }
    
    public static string GetInputImageUrl(object target)
    {
        string prop = GetInputImagePropertyName(target.GetType());
        if (prop != null)
        {
            string entity = target.GetType().Name;
            int id = int.Parse(ReflectionService.GetValueFor(target, "ID").ToString());
            return $"/api/Resource/Image?entity={entity}&id={id}";
        }
        else 
        {
            foreach (var nav in GetNavigation(target.GetType()))
            {
                if (TypesExtensions.IsCollectionType(nav.GetType()) == false)
                {
                    prop = GetInputImagePropertyName(nav.GetType());
                    if (prop != null)
                    {
                        target = ReflectionService.GetValueFor(target, nav.Name);
                        if(target != null)
                        {
                            string entity = target.GetType().Name;
                            int id = int.Parse(ReflectionService.GetValueFor(target, "ID").ToString());
                            return $"/api/Resource/Image?entity={entity}&id={id}";
                        }
                        else
                        {
                            return $"/api/Resource/Image";
                        }
                        
                    }
                }
            }
        }
        throw new Exception("Не удалось найти изображение");

    }

    private static IEnumerable<INavigation> GetNavigation(Type type)
    {
        throw new NotImplementedException($"{typeof(AttrsUtils).GetTypeName()}");
    }

    public static string ForHelp(object target)
    {
        return GetTypeAttrValue(target, nameof(HelpAttribute));
    }

    public static string ForDescription(object target)
    {
        return GetTypeAttrValue(target, nameof(DescriptionAttribute));
    }
    
    

    public static string GetInputImagePropertyName(Type type)
    {
        return GetInputImagePropertyName(ForAllPropertiesInType(type));
    }

    public static string GetInputImagePropertyName(Dictionary<string, Dictionary<string, string>> attrs)
    {
        foreach(var p in attrs)
        {
            if (attrs[p.Key].ContainsKey(nameof(InputImageAttribute)))
            {
                return p.Key;
            }
        }
        return null;
    }

    public static bool IsManyToManyRelation(Type type, string propertyName) {
        return AttrsUtils.ForProperty(type, propertyName).ContainsKey(nameof(ManyToMany));
    }
    public static bool HasManyToManyRelation(Type type, string propertyName) {
        return AttrsUtils.ForProperty(type, propertyName).ContainsKey(nameof(ManyToMany));
    }
    
    

    public static List<string> GetVisibleProperties(Type type)
    {
        List<string> props = new List<string>();
        foreach (string propertyName in ReflectionService.GetPropertyNames(type))
        {
            if( IsVisible(type,propertyName))
            {
                props.Add(propertyName);
            }
        }
        return props;
    }


    public static string[] GetCollectionTypePropertyNames(Type type, string propName)
    {
        return (from p in new List<PropertyInfo>(GetCollectionTypeProperties(type, propName)) select p.Name).ToArray();
    }
    public static PropertyInfo[] GetCollectionTypeProperties(Type type, string propName)
    {
        return ReflectionService.TypeForShortName(GetCollectionType(type, propName)).GetProperties();
    }
    public static Type GetCollectionSystemType(Type type, string propName)
    {
        return ReflectionService.TypeForShortName(GetCollectionType(type, propName));
    }

    public static Dictionary<string,string> ForExtendedTypes(Type controllerType)
    {
        var res = new Dictionary<string, string>();
        Type p = controllerType;
        while (p != typeof(Controller) && p != null)
        {
            res.AddRange<string>(AttrsUtils.GetEntityContrainsts(p));
            p = p.BaseType;
        }
        return res;
    }

    public static bool IsCollectionType(Type type, string propName)
    {
        var property = type.GetProperty(propName);
        string TypeName = property.PropertyType.Name;          
        bool res = property.PropertyType.Name.StartsWith("List");
        if( res == false )
        {
            Type p = property.PropertyType;
            while (p != typeof(Object) && p != null)
            {
                if((from pinterface in new List<Type>(p.GetInterfaces()) where pinterface.Name.StartsWith("ICollection") select p).Count() > 0)
                {
                    return true;
                }
                p = p.BaseType;
            }
        }
        return res;
    }

    public static bool IsInput(Type type, string name)
    {
        return IsInput(ForProperty(type, name));
    }
    public static bool IsInput(Dictionary<string, string> attrs)
    {
        return attrs.ContainsKey(nameof(NotInputAttribute)) ? false : true;
    }

    public static string GetCollectionType(Type type, string propName)
    {
        var property = type.GetProperty(propName);
        string TypeName = property.PropertyType.Name;
     
        if (property.PropertyType.Name.StartsWith("List"))
        {
            
            string text = property.PropertyType.AssemblyQualifiedName;
            text = text.Substring(text.IndexOf("[[") + 2);
            text = text.Substring(0, text.IndexOf(","));
            TypeName = text.Substring(text.LastIndexOf(".") + 1);
            Api.Utils.Info(property.Name + " " + text);
        }
        return TypeName;
    }

    public static bool IsCollection(Type type, string propName)
    {        
        var property = type.GetProperty(propName);
        string TypeName = property.PropertyType.Name;
        bool IsCollection = false;
        if (property.PropertyType.Name.StartsWith("List"))
        {
            IsCollection = true;
            string text = property.PropertyType.AssemblyQualifiedName;
            text = text.Substring(text.IndexOf("[[") + 2);
            text = text.Substring(0, text.IndexOf(","));
            TypeName = text.Substring(text.LastIndexOf(".") + 1);
            Api.Utils.Info(property.Name + " " + text);
        }
        return IsCollection;
    }


    /// <summary>
    /// Подпись элемента визуализации ассоциированного со заданным свойством 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetInputType(Type type, string name)
    {
        Dictionary<string, string> attrs = AttrsUtils.ForProperty(type, name);
        return GetInputType(attrs);
    }




    /// <summary>
    /// Получение атрибута типа поля ввода
    /// </summary>
    /// <param name="attrs"></param>
    /// <returns></returns>
    public static string GetInputType(Dictionary<string, string> attrs)
    {
        string key = null;
        List<string> keys = new List<string>(attrs.Keys);
        AttributeRegistry.GetInputTypes().ForEach((string name) =>
        {
            if (keys.Contains(name) || keys.Contains(name.Replace("Attribute", "")) || keys.Contains(name+"Attribute") )
            {
                key = name;
            }
        });
        if( key != null )
        {
            return key.Replace("Attribute", "").Replace("Input", "");
        }
        else
        {
            return null;
        }
    }



    



    

    /// <summary>
    /// Получение атрибутов для обьекта
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static Dictionary<string, string> ForObject(object p)
    {
   
        return GetEntityContrainsts(p.GetType());
    }

    public static List<string> SearchTermsForType(Type p)
    {
        List<string> terms = new List<string>();
        Dictionary<string, string> attrs = GetEntityContrainsts(p);
        if( attrs.ContainsKey(nameof(SearchTermsAttribute)))
        {
            terms.AddRange(attrs[nameof(SearchTermsAttribute)].Split(","));
        }
        if (attrs.ContainsKey("SearchTerms"))
        {
            terms.AddRange(attrs["SearchTerms"].Split(", "));
        }
        return terms;
    }

    public static Dictionary<string, string> ForType(string p)
    {
        return GetEntityContrainsts(ReflectionService.TypeForName(p));
    }
    public static bool IsParameterInjectable(string type, string method, string par)
    {
        var info = GetParameter(type,method,par);
        var attrs = GetAttrs(info);
        return attrs.ContainsKey(nameof(ServiceAttribute)) || attrs.ContainsKey(nameof(ServiceAttribute).Replace("Attribute",""));
    }
    public static Dictionary<string, string> GetAttrs(ParameterInfo ppar)
    {
        Dictionary<string, string> attrs = new Dictionary<string, string>();

        foreach (var data in ppar.GetCustomAttributesData())
        {
            string key = data.AttributeType.Name;
            foreach (var arg in data.ConstructorArguments)
            {
                string value = arg.Value.ToString();
                attrs[key] = value;
            }

        }
        return attrs;
    }
    public static Dictionary<string, string> GetAttrs(MethodInfo ppar)
    {
        Dictionary<string, string> attrs = new Dictionary<string, string>();

        foreach (var data in ppar.GetCustomAttributesData())
        {
            string key = data.AttributeType.Name;
            foreach (var arg in data.ConstructorArguments)
            {
                string value = arg.Value.ToString();
                attrs[key] = value;
            }

        }
        return attrs;
    }

    public static Dictionary<string, string> GetAttrs(PropertyInfo ppar)
    {
        Dictionary<string, string> attrs = new Dictionary<string, string>();

        foreach (var data in ppar.GetCustomAttributesData())
        {
            string key = data.AttributeType.Name;
            foreach (var arg in data.ConstructorArguments)
            {
                string value = arg.Value.ToString();
                attrs[key] = value;
            }

        }
        return attrs;
    }
    public static Dictionary<string, string> GetAttrs(FieldInfo ppar)
    {
        Dictionary<string, string> attrs = new Dictionary<string, string>();

        foreach (var data in ppar.GetCustomAttributesData())
        {
            string key = data.AttributeType.Name;
            foreach (var arg in data.ConstructorArguments)
            {
                string value = arg.Value.ToString();
                attrs[key] = value;
            }

        }
        return attrs;
    }

    public static ParameterInfo GetParameter(string type, string method, string par)
    {
        if (type == null)
            throw new ArgumentNullException("Аргумент type не допускает значения null");
        if (method == null)
            throw new ArgumentNullException("Аргумент method не допускает значения null");
        if (par == null)
            throw new ArgumentNullException("Аргумент par не допускает значения null");

        Type ptype = type.ToType();
        ParameterInfo ppar = ptype.GetActionParameters(method).FirstOrDefault(p => p.Name == par);
        return ppar;
    }
    public static Dictionary<string, string> ForParameter(string type, string method, string par)
    {
        if (type == null)
            throw new ArgumentNullException("Аргумент type не допускает значения null");
        if (method == null)
            throw new ArgumentNullException("Аргумент method не допускает значения null");
        if (par == null)
            throw new ArgumentNullException("Аргумент par не допускает значения null");

        Type ptype = type.ToType();
        ParameterInfo ppar = ptype.GetActionParameters(method).FirstOrDefault(p => p.Name==par);

        Dictionary<string, string> attrs = new Dictionary<string, string>();
         
        foreach (var data in ppar.GetCustomAttributesData())
        {
            string key = data.AttributeType.Name;
            foreach (var arg in data.ConstructorArguments)
            {
                string value = arg.Value.ToString();
                attrs[key] = value;
            }

        }
        return attrs;
    }
    
    public static Dictionary<string, string> GetEntityContrainsts(Type p)
    {

        Dictionary<string, string> attrs = new Dictionary<string, string>();
        if (p == null)
        {
            Api.Utils.Info($"Вам слендует передать ссылку на Type в метод Utils.GetEntityContrainsts() вместо null");
            Api.Utils.Info($"{new ArgumentNullException("p")}");
            return attrs;
        }
        foreach (var data in p.GetCustomAttributesData())
        {
            string key = data.AttributeType.Name;
            foreach (var arg in data.ConstructorArguments)
            {
                string value = arg.Value.ToString();
                attrs[key] = value;
            }

        }
        return attrs;
    }

    public static bool IsTrueValue(string v)
    {
        return v.ToLower() == "true";
    }

    public static string HelpFor(Type type, string property)
    {
        Dictionary<string, string> attrs = ForProperty(type, property);
        return attrs.ContainsKey(nameof(HelpAttribute)) ? attrs[nameof(HelpAttribute)] : "";
    }

    public static string HelpFor(Type type )
    {
        Dictionary<string, string> attrs = GetEntityContrainsts(type);
        return attrs.ContainsKey(nameof(HelpAttribute)) ? attrs[nameof(HelpAttribute)] : "";
    }

    /// <summary>
    /// Подпись элемента визуализации ассоциированного со заданным свойством 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string LabelFor(Type model, string name)
    {
        Dictionary<string, string> attrs = AttrsUtils.ForProperty(model, name);
        if (attrs.ContainsKey(nameof(LabelAttribute)) == false)
        {
            return name;
            //throw new Exception($"Для создания надписи с именем поля ввода " +
            //    $"установите атрибут Label на свойство {name} в классе {model.GetType().Name}");
        }
        else
        {
            return attrs[nameof(LabelAttribute)];
        }
    }


    /// <summary>
    /// Получение значения атрибута для текста надписи
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static string LabelFor(Type type)
    {
        Dictionary<string, string> attrs = GetEntityContrainsts(type);

        return
            attrs.ContainsKey("Label") ? attrs["Label"] :
            attrs.ContainsKey("EntityLabel") ? attrs["EntityLabel"] :
            attrs.ContainsKey(nameof(LabelAttribute)) ? attrs[nameof(LabelAttribute)] :
            attrs.ContainsKey(nameof(LabelAttribute)) ? attrs[nameof(LabelAttribute)] : type.Name;
    }



    public static string DescriptionFor(Type type, string property)
    {
        Dictionary<string, string>  attrs = ForProperty(type, property);
        return attrs.ContainsKey(nameof(DescriptionAttribute)) ? attrs[nameof(DescriptionAttribute)] :
            attrs.ContainsKey(nameof(DescriptionAttribute).Replace("Attribute","")) ? attrs[nameof(DescriptionAttribute).Replace("Attribute", "")] : null;
    }

    public static string LabelFor(object p)
    {
        IDictionary<string, string> attrs = null;
        Console.WriteLine(p.GetType().GetInterfaces().Select(i => i.Name).ToJsonOnScreen());
        if (p.IsImplements(typeof(ICollection)))
        {
            attrs = (IDictionary<string, string>)p;
        }
        else
        {
            attrs = ForObject(p);
        }
        
        return attrs.ContainsKey(nameof(LabelAttribute)) ? attrs[nameof(LabelAttribute)] :
            attrs.ContainsKey(nameof(DisplayAttribute)) ? attrs[nameof(DisplayAttribute)] : p.GetType().Name;
    }
    public static string LabelForMethod(object p, string name)
    {
        if (p == null)
            throw new ArgumentNullException("p");
        return AttrsUtils.LabelFor(AttrsUtils.ForMethod(p.GetType(), name));
    }
    public static string DescriptionFor(object p)
    {
        Dictionary<string, string> attrs = ForObject(p);
        return attrs.ContainsKey(nameof(DescriptionAttribute)) ? attrs[nameof(DescriptionAttribute)]: "";
    }

    public static string IconFor(Type type, string property)
    {
        Dictionary<string, string> attrs = ForProperty(type, property);
        return attrs.ContainsKey(nameof(IconAttribute)) ? attrs[nameof(IconAttribute)]: "person";

    }


   

    public static string IconFor(string type)
    {
        return IconFor(ReflectionService.TypeForName(type));
    }



    public static string IconFor(Type type)
    {
        Dictionary<string, string> attrs = GetEntityContrainsts(type);
        return attrs.ContainsKey(nameof(IconAttribute)) ? attrs[nameof(IconAttribute)] : 
            attrs.ContainsKey(nameof(IconAttribute)) ? attrs[nameof(IconAttribute)] :
            null;
    }

    /// <summary>
    /// Проверка флага отображением
    /// </summary>
    /// <param name="type"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    public static bool IsVisible(Type type,string property)
    {
        string hidden = ForPropertyValue(type, typeof(InputHiddenAttribute), property);
        return "True" == hidden ? false : true;
    }


    /// <summary>
    /// Получить значения атрибуf заданного для свойства
    /// </summary>
    /// <param name="type"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    public static string ForPropertyValue(Type type, Type attr, String property)
    {
        if(type == null)
        {
            throw new Exception("Аргумент "+ type+" содержить ссылку на null");
        }
        Dictionary<string, string> attrs = new Dictionary<string, string>();
        if(type==null || type.GetProperty(property) == null)
        {
            throw new Exception("Свойство не найдено либо не задан тип");
        }
        foreach (var data in type.GetProperty(property).CustomAttributes )
        {
            string key = data.AttributeType.Name;
            if(key== attr.Name)
            {
                foreach (var arg in data.ConstructorArguments)
                {
                    string value = arg.Value.ToString();
                    return value;
                }
            }
            

        }
        return null;
    }


    /// <summary>
    /// Получить значения всех атрибутов заданных для свойства
    /// </summary>
    /// <param name="type"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    public static Dictionary<string,string> ForProperty(Type type, String property)
    {
        if(type == null)
        {
            throw new ArgumentNullException();
        }


        Dictionary<string, string> attrs = null;
        PropertyInfo info = null;

        try
        {
            attrs = new Dictionary<string, string>();
            info = type.GetProperty(property);
        }
        catch(AmbiguousMatchException ex)
        {
            Api.Utils.Info(ex.Message);
        }
        
        if( info == null)
        {
            throw new Exception($"Свойство {property} не найдено в обьекте типа {type.Name}");
        }
        var datas = info.GetCustomAttributesData();
        if(datas != null )
            foreach (var data in datas)
            {
            
                string key = data.AttributeType.Name;
                //ParameterInfo[] pars = data.AttributeType.GetConstructors()[0].GetParameters();
                if(data.ConstructorArguments==null || data.ConstructorArguments.Count == 0)
                {
                    attrs[key] = "";
                }
                else
                {
                    foreach (var arg in data.ConstructorArguments)
                    {

                        string value = arg.Value==null? "":arg.Value.ToString();
                        attrs[key] = value;
                    }
                }
            
                //model.Attributes[data.AttributeType] = null;

            }

        if (attrs == null)
        {
            throw new Exception($"Не удалось получить атрибуты свойсва {property} класса {type.Name}");
        }
        return attrs;
    }

    public static string GetActionLabel(Type type, string action)
    {
        var attrs = AttrsUtils.ForMethod(type, action);
        return attrs.ContainsKey(nameof(LabelAttribute))? attrs[nameof(LabelAttribute)] : action;
         
        

   }

    /// <summary>
    /// Получение атрибутов действия
    /// </summary>
    /// <param name="controllerType"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Dictionary<string, string> ForMethod(Type controllerType, string name)
    {
        try
        {
            Dictionary<string, string> attrs = new Dictionary<string, string>();
            var method = controllerType.GetMethods().Where(m => m.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if (method == null)
                throw new ArgumentException("Не правильно задан аргемент: name=" + name);
            foreach (var data in method.GetCustomAttributesData())
            {
                string key = data.AttributeType.Name;
                foreach (var arg in data.ConstructorArguments)
                {
                    string value = arg.Value.ToString();
                    attrs[key] = value;
                }

            }
            return attrs;
        }
        catch (Exception ex)
        {
            Error(ex);
            throw new Exception("Не удалось получить атрибуты для метода "+controllerType.GetNameOfType()+"."+name + "");
        }
    }

    
    /// <summary>
    /// Извлечение метода HTTP из атрибутов
    /// </summary>
    /// <param name="attributes"></param>
    /// <returns></returns>
    public static string ParseHttpMethod(Dictionary<string, string> attributes)
    {
        foreach(var p in attributes)
        {
            switch(p.Key)
            {
                case "HttpPostAttribute":
                    return "GET";              
                case "HttpPutAttribute":
                    return "PUT";
                case "HttpPatchAttribute":
                    return "PATCH";
                case "HttpDeleteAttribute":
                    return "DELETE";
                default: return "GET";
            }
        }
        return "GET"; 
    }




    /// <summary>
    /// Выбор значения атрибута DataType
    /// </summary>
    /// <param name="attributes"></param>
    /// <returns></returns>
    public static string GetDataType(Dictionary<string, string> attributes)
    {
        foreach (var p in attributes)
        {
            switch (p.Key)
            {
                case "DataTypeAttribute":
                    switch (p.Value)
                    {
                        case "0":   return "custom";
                        case "1":   return "datetime";
                        case "2":   return "date";
                        case "3":   return "time";
                        case "4":   return "duration";
                        case "5":   return "phone";
                        case "6":   return "currency";
                        case "7":   return "text";
                        case "8":   return "html";
                        case "9":   return "textarea";
                        case "10":  return "email";
                        case "11":  return "password";
                        case "12":  return "url";
                        case "13":  return "image";
                        case "14":  return "creditCard";
                        case "15":  return "postalCode";
                        case "16":  return "upload";
                        default: throw new Exception("Неизвестный тип данных");
                    }

            }
        }
        return null;
    }

    public static Dictionary<string, Dictionary<string, string>> ForAllPropertiesInType(Type type)
    {
        Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
        foreach(var prop in type.GetProperties())
        {
            Dictionary<string, string> forProperty = AttrsUtils.ForProperty(type, prop.Name);
            result[prop.Name] = forProperty;
        }
        return result;
    }


    public static bool IsUniq(Dictionary<string, string> attributes)
    {
        return attributes.ContainsKey(nameof(UniqValueAttribute));
    }

    public static string GetUniqProperty(Dictionary<string, Dictionary<string, string>> attrs)
    {
        foreach(var p in attrs)
        {
            if( IsUniq(attrs[p.Key]))
            {
                return p.Key;
            }
        }
        return null;
    }

    public static Attribute[] ForPropertyLikeAttrubtes(Type type, string property)
    {
        var attrs =  new List<Attribute>();
        if (type == null)
        {
            throw new ArgumentNullException();
        }


        
        PropertyInfo info = type.GetProperty(property);
        if (info == null)
        {
            throw new Exception($"Свойство {property} не найдено в обьекте типа {type.Name}");
        }
        foreach (var data in info.GetCustomAttributesData())
        {
            string key = data.AttributeType.Name;
            
            if (data.ConstructorArguments == null || data.ConstructorArguments.Count == 0)
            {
                Attribute attr = ReflectionService.Create<Attribute>(key,new object[0]);
                attrs.Add(attr);
            }
            else
            {
                List<object> parameters = new List<object>();
                foreach (CustomAttributeTypedArgument arg in data.ConstructorArguments)
                {
                    parameters.Add(arg.Value);
                }
                Attribute attr = ReflectionService.Create<Attribute>(key, parameters.ToArray());
                attrs.Add(attr);

            }

            //model.Attributes[data.AttributeType] = null;

        }
        return attrs.ToArray();
    }

    public static string ForManyToMany(Type type, string bindingGroup)
    {
        return AttrsUtils.ForProperty(type, bindingGroup)[nameof(ManyToMany)];
    }

    /*public static T ResolvePropertyAttributes<T>(Type type, string propertyName) where T: ViewItem
    {
        ViewItem result = ReflectionService.CreateWithDefaultConstructor<ViewItem>(typeof(T));
        Dictionary<string,string> values = AttrsUtils.ForProperty(type, propertyName);
     
        foreach (var pair in values)
        {
            if( result.HasProperty(pair.Key.Replace("Attribute",""))) { 
                Setter.SetValue(result, pair.Key.Replace("Attribute", ""), pair.Value);
            }
        }
        return (T)result;
    }*/
}

