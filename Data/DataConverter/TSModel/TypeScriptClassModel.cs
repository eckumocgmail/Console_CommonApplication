using ApplicationCore.Converter.Models;
using System;
using System.Collections.Generic;
using TeleReportsDataProvider.Data.DataConverter.TypeScriptModel;

namespace TeleReportsDataProvider.Data.DataConverter
{
    public class TypeScriptClassModel
    {
        public string Name { get; set; }
        public TypeScriptClassModel Base { get; set; }
        public TypeScriptConstructorModel Constructor { get; set; }

        public Dictionary<string, TypeScriptPropertyModel> Properties { get; set; } = new Dictionary<string, TypeScriptPropertyModel>();
        public Dictionary<string, TypeScriptActionModel> Methods { get; set; } = new Dictionary<string, TypeScriptActionModel>();

        public void AddProperty(TypeScriptPropertyModel tsprop)
        {
            Properties[tsprop.Name] = tsprop;
        }
        public void AddMethod(TypeScriptActionModel tsaction)
        {
            Methods[tsaction.Name] = tsaction;
        }
    }


}
