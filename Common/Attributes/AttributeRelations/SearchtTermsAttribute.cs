using System;

public class SearchTermsAttribute : ConstraintAttribute
{
    string[] keys {get;set;}
    public SearchTermsAttribute(string exp)
    {
        this.keys = exp.Split(",");
    }
}