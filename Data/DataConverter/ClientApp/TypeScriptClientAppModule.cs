using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ApplicationCore.Converter.ClientApp
{
    public class TypeScriptClientAppModule: TypeScriptProject        
    {
        private NgApp app;
        private Dictionary<string, TypeScriptClientAppModule> imports;
        /*private Dictionary<string, string> exports;
        private Dictionary<string, string> components;
        private Dictionary<string, string> providers;
        private Dictionary<string, string> directives;
        private Dictionary<string, string> pipes;*/


        protected TypeScriptClientAppModule():base()
        {
            this.imports = new Dictionary<string, TypeScriptClientAppModule>();
        }


        public TypeScriptClientAppModule( string dir, NgApp app ) :base( dir )
        {
            this.app = app;
            /*this.imports = new Dictionary<string, AppModule>();
            this.exports = new Dictionary<string, string>();
            this.providers = new Dictionary<string, string>();
            this.components = new Dictionary<string, string>();
            this.directives = new Dictionary<string, string>();
            this.pipes = new Dictionary<string, string>();*/

            this.import();
        }


        public Dictionary<string, string> GetImportedNames()
        {
            Dictionary<string, string> importedNames = new Dictionary<string, string>();
            this.ForChild((TypeScriptClientAppModule mod)=> {
                importedNames = Concat(importedNames, mod.names);
            });
            Console.WriteLine(JObject.FromObject(importedNames));
            return importedNames;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public override int Replace(string oldName, string newName)
        {
            int result = base.Replace(oldName, newName);
            foreach (TypeScriptClientAppModule child in this.imports.Values)
            {
                result += child.Replace(oldName, newName);
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void ForChild( Action<TypeScriptClientAppModule> action )
        {
            action( this );
            foreach( var pair in this.imports)
            {
                pair.Value.ForChild( action );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void PatchImports()
        {
            this.PatchImports( this.app.names );
            foreach( TypeScriptClientAppModule child in this.imports.Values)
            {
                child.PatchImports();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        public void import( TypeScriptClientAppModule module )
        {
            this.imports[this.GetFileShortName(module.dir)] = module;            
        }


        /// <summary>
        /// 
        /// </summary>
        protected void import()
        {            
            foreach (string dir in System.IO.Directory.GetDirectories(this.dir))
            {
                TypeScriptClientAppModule childModule = new TypeScriptClientAppModule(dir, this.app );
                this.import( childModule );
            }
        }
    }
}
