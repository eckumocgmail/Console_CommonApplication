using System;
using System.Collections.Generic;
using System.Linq;
 
public class DataSearch
{
    public static HashSet<string> GetKeywords(IEnumerable<object> items, string entity, string query)
    {
        HashSet<string> keywords = new HashSet<string>();
        List<string> terms = ConstraintsFactory.GetSearchTerms(entity);
        foreach (var p in items.ToList())
        {
            foreach (string term in terms)
            {
                object val = ReflectionService.GetValueFor(p, term);
                if (val != null)
                {
                    foreach (string s in val.ToString().Split(" "))
                    {
                        keywords.Add(s);
                    }
                }
            }
        }
        return keywords;
    }

    public static HashSet<object> Search(IEnumerable<object> items, string entity, string query)
    {
        HashSet<object> results = new HashSet<object>();
        List<string> terms = ConstraintsFactory.GetSearchTerms(entity);
        Func<object, bool> verify = Expressions.ArePropertiesContainsText<object>(terms, query);

        foreach (var p in items.ToList())
        {
            if (verify(p))
            {
                results.Add(p);
            }
        }
        return results;
    }
}
 