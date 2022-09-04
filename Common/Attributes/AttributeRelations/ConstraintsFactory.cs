
using System;
using System.Collections.Generic;

public class ConstraintsFactory
{

    public static List<string> SearchTermsForType(Type p)
    {
        List<string> terms = new List<string>();
        Dictionary<string, string> attrs = Utils.ForType(p);
        if (attrs.ContainsKey(nameof(SearchTermsAttribute)))
        {
            terms.AddRange(attrs[nameof(SearchTermsAttribute)].Split(","));
        }
        return terms;
    }

    public static List<string> GetSearchTerms(string entity)
    {
        Type entityType = ReflectionService.TypeForShortName(entity);
        List<string> terms = SearchTermsForType(entityType);
        return terms;
    }
}