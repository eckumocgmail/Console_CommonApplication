


namespace DataConverter.Generators
{
    public class RepositoryGenerator
    {

        /// <summary>
        /// Метод создания класса TypeScript, реализующего CRUD операции с сущностью
        /// </summary>
        /// <param name="table"> модель данных сущности </param>
        /// <returns> код TypeScript, реализующий CRUD операции над сущностью </returns>
        public string CreateEntityRepository(IDataTable table, string dbContextClassName)
        {
            string header =
                "using System.Linq;\n"+
                "using ApplicationDb;\n using LibsDb; \n" +
                "using LibsDb.LibsEntities;\n" +               
                "using ApplicationDb.Entities;\n" +

            "using Microsoft.AspNetCore.Mvc;\n" +
                "using Microsoft.Extensions.Logging;\n\n\n" +
            "[ApiController]\n" +
                $"[Route(\"api/{TextNaming.ToCapitalStyle(table.TableName)}/[action]\")]\n" +
                $"public class {TextNaming.ToCapitalStyle(table.TableName)}Controller: ControllerBase\n";
            string body = 
                $"\tprivate readonly {dbContextClassName} _db; \n\n\n" +
                $"\tpublic {TextNaming.ToCapitalStyle(table.TableName)}Controller( {dbContextClassName} db )"+ "{\n";            
            body += "\t\t_db=db;\n";
            body += "\t}\n\n";
            body += $"\tpublic void Create( {TextNaming.ToCapitalStyle(table.singlecount_name)} record )";
            body += "\t{\n";
            body += $"\t\t_db.{TextNaming.ToCapitalStyle(table.TableName)}.Add(record);\n";
            body += $"\t\t_db.SaveChanges();\n";
            body += "\t}\n\n";
            body += $"\tpublic void Remove( int id )"+ "{\n";
            body += $"\t\t_db.{TextNaming.ToCapitalStyle(table.TableName)}.Remove(this.Find(id));\n";
            body += $"\t\t_db.SaveChanges();\n";
            body += "\t}\n\n";
            body += $"\tpublic {TextNaming.ToCapitalStyle(table.singlecount_name)} Find( int id )";
            body += "\t{\n";
            body += $"\t\t return _db.{TextNaming.ToCapitalStyle(table.TableName)}.Find(id);\n";
            body += "\t}\n\n";
            body += $"\tpublic System.Collections.Generic.List<{TextNaming.ToCapitalStyle(table.singlecount_name)}> List(   )";
            body += "\t{\n";
            body += $"\t\t return _db.{TextNaming.ToCapitalStyle(table.TableName)}.ToList();\n";
            body += "\t}\n";            
            string classCode = header + "{\n" + body + "\n}";
            return classCode;
        }
    }
}
