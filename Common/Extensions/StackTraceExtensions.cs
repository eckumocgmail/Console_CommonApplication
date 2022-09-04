using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using static Api.Utils;
using static ExceptionExtensions.ExceptionInfo;

public static class StackTraceExtensions
{

    private static IEnumerable<CallInfo> GetStack(string stackTrace)
    {

        var list = new List<CallInfo>();
        foreach (string line in stackTrace.Split("\n"))
        {
            int i = line.IndexOf(":") - 1;
            int li = line.IndexOf(":line");

            if (!(i >= 0 && li >= 0))
            {
                list.Add(new CallInfo()
                {
                    TextMessage = line
                });

            }
            else
            {
                list.Add(new CallInfo()
                {
                    TextMessage = line,
                    FilePath = "file:///" + line.Substring(i, line.IndexOf(":line") - i).ReplaceAll(@"\", "/"),
                    LineNumber = line.Substring(line.IndexOf(":line") + ":line".Length).Trim().ToInt()
                });
            }

        }
        return list;
    }
    public static PropertyInfo Get<T>(this object target)
    {
        return target.GetType().GetProperties().FirstOrDefault(p => p.PropertyType.GetNameOfType() == typeof(T).GetNameOfType());
    }
    public static string GetNameType(this object target)
    {
        Type targetType = target is Type ? ((Type)target) : target.GetType();
        string result = targetType.GetNameOfType();
        return result;
    }
    public static string GetFileName(this object target)
    {
        return target.GetTypeName().ReplaceAll("<", "").ReplaceAll(">", "").ToKebabStyle() + ".json";

    }
    public static string GetId(this object target)
    {
        return $"[{target.GetType().Name}].[{target.GetHashCode()}]";
    }
    public static void BeforeInvoke(this object target, IDictionary<string, object> arguments)
    {
        WriteLine(target.GetActionInfo(arguments, 3).ToJsonOnScreen());
    }
}