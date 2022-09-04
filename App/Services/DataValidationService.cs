using NetCoreConstructorAngular.Data.DataAttributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class DataValidationService
    {

       


        /*public Dictionary<string, List<string>> ValidateModel(string type, string properties)
        {            
            var model = Unpackage(type,properties);            
            return ValidateModel(model);
        }

        public Dictionary<string, List<string>> ValidateModel(object model)
        {
            object target = model;
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            foreach (var property in target.GetType().GetProperties())
            {
                string key = property.Name;
                try
                {
                    var attributes = Attrs.ForProperty(target.GetType(), property.Name);
                    foreach (var data in target.GetType().GetProperty(property.Name).GetCustomAttributesData())
                    {
                        if (data.AttributeType.GetInterfaces().Contains(typeof(MyValidation)))
                        {
                            List<object> args = new List<object>();
                            foreach (var a in data.ConstructorArguments)
                            {
                                args.Add(a.Value);
                            }
                            MyValidation validation =
                                ReflectionService.Create<MyValidation>(data.AttributeType, args.ToArray());
                            string validationResult =
                                validation.Validate(target, property.Name, new ReflectionService().GetValue(target, property.Name));
                            if (validationResult != null)
                            {
                                List<string> errors = result.ContainsKey(property.Name) ?
                                    result[property.Name] :
                                    result[property.Name] = new List<string>();
                                errors.Add(validationResult);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result[key] = new List<string>() { ex.Message };
                }
            }
            return result;
        }*/
    }
