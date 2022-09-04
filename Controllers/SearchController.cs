using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
[Route("[controller]/[action]")]

public class SearchController : ControllerBase
{
    private readonly AuthorizationDataModel _context;


    public SearchController( AuthorizationDataModel context ) {
        _context = context;
    }
       
    /*
    public Dictionary<string, int> GetKeywords(string query)
    {            
        DatabaseManager dbm = _context.GetDatabaseManager();
        return dbm.GetKeywords();
    }


    public Dictionary<string, object> Search(string query)
    {
        DatabaseManager dbm = new DatabaseManager();
        Dictionary<string, object> results = new Dictionary<string, object>();
        try
        {
            dbm.discovery();
            if(string.IsNullOrEmpty(query))
            {
                return dbm.statistics;
            }
            query = query!=null ? query.ToLower(): "";
            foreach (var pair in dbm.fasade)
            {
                string name = pair.Key;
                string pk = dbm.GetMetaData().Tables[pair.Key].pk;
                if (pk == null)
                {
                    throw new Exception("Primary key udefined for table " + name);
                }
                List<string> textColumns = ((TableManager)pair.Value).GetMetadata().GetTextColumns();
                foreach (JObject record in ((TableManager)pair.Value).SelectAll())
                {
                    try
                    {
                        //Console.WriteLine(record);
                        int id = record[pk].Value<int>();
                        int relevation = 0;
                        foreach (string column in textColumns)
                        {
                            if (record[column] != null)
                            {
                                string textValue = record[column].Value<string>();
                                if (String.IsNullOrEmpty(textValue)) continue;
                                int relativeClause = (from word in textValue.Split() where query.Split(" ").Contains(word) select word).Count();
                                relevation += relativeClause;
                            }

                        }
                        if (relevation > 0)
                        {
                            results[name + "/" + id] = relevation;
                            var myList = results.ToList();
                            //myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value!=null?pair2.Value.ToString():""));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        continue;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            results[ex.Message] = 500;
            Console.WriteLine(ex);
        }
        return results; 
    }
    */


}
