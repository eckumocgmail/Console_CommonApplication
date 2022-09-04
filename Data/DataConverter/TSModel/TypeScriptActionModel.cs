using ApplicationCore.Converter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleReportsDataProvider.Data.DataConverter.TypeScriptModel
{
    public class TypeScriptActionModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, MyParameterDeclarationModel> Parameters { get; set; } = new Dictionary<string, MyParameterDeclarationModel>();
        public string Implementation { get; set; }
    }
}
