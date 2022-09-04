using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class FormControlBuilderUtils
{
    private static List<string> CONTROL_TYPES =
       GetControlTypeAttributes();

    private static List<string> GetControlTypeAttributes()
    {
        if (CONTROL_TYPES == null)
        {
            CONTROL_TYPES = new List<string>();
            GetInputTypeAttributes(typeof(DataInputTypes).Assembly).ToList().ForEach((Type t) => {
                CONTROL_TYPES.Add(t.Name);
            });
        }
        return CONTROL_TYPES;
    }
    private static HashSet<Type> GetInputTypeAttributes(Assembly assembly)
    {
        var resultset = new HashSet<Type>();
        foreach (var type in assembly.GetTypes())
        {
            if (TypeUtils.IsExtendedFrom(type, nameof(ControlAttribute)))
                resultset.Add(type);
        }
        return resultset;
    }

    public static string GetControlType(Type type, string property)
    {
        var attrs = AttrsUtils.ForProperty(type, property);
        return (from p in attrs.Keys where CONTROL_TYPES.Contains(p) select p).FirstOrDefault();
    }
}

