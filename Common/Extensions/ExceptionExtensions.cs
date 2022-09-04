using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static ExceptionExtensions.ExceptionInfo;

public static class ExceptionExtensions
{
    public static IDictionary<string, string> ToDictionaryOfText(this object target)
        => DeserializeObject<Dictionary<string, string>>(SerializeObject(target));




    public static IDictionary<string, string> DeserializeObject<T>(string p)
        => System.Text.Json.JsonSerializer.Deserialize<IDictionary<string, string>>(p);
    public static string SerializeObject(object target)
        => System.Text.Json.JsonSerializer.Serialize(target);

    [Serializable]
    public class MessageException : Exception
    {
        public object Caller { get; set; }  
        public object Action { get; set; }
        public Exception Next { get; set; }
        public IDictionary<string, object> Arguments { get; set; }
    }
    public static MessageException NewMessage(this Exception target, object caller, string nameOfMethod, IDictionary<string,object> arguments=null)
    {
        return new MessageException()
        {
            Next = target,
            Caller = caller,
            Action = nameOfMethod,
            Arguments = arguments
        };
    }

    public static CallInfo GetActionInfo(this object target, IDictionary<string, object> arguments=null, bool completed=false, Exception ex=null)
    {
        if(arguments==null)        
            arguments = new Dictionary<string, object>();
        CallInfo info = null;
        var stack = target.GetInvokeInfo();
        if (stack.Count >= 4)
        {
            info = stack[3];
            info.CallArguments = arguments;
            info.ActionCompleted = completed;
             
            
        }
        else
        {
            info = stack.Last();
            info.CallArguments = arguments;
            info.ActionCompleted = completed;             
        }
        if (ex != null)
        {
            info.TextMessage = ex.Message;
        }
        return info;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="arguments"></param>
    /// <param name="level"></param>
    /// <returns></returns>
    public static CallInfo GetActionInfo(this object target, IDictionary<string, object> arguments, int level)
    {
        CallInfo info = target.GetInvokeInfo()[level];
        info.CallArguments = arguments;
        return info;
    }

    /// <summary>
    /// Возвращает сведения о методах исполняющихся в настоящий момент
    /// </summary>
    public static IList<CallInfo> GetInvokeInfo(this object target)
    {
        string stackTrace = Environment.StackTrace;

        var list = new List<CallInfo>();
        try
        {
            foreach (string line in stackTrace.Split("\n"))
            {
                if (line.IndexOf(":line") == -1)
                    continue;
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

                    string action = line.Substring(0, i - 4);
                    string call = action.Substring(action.IndexOf("at ") + 3);
                    string classAndAction = call.Before("(");
                    action = classAndAction.Substring(classAndAction.LastIndexOf(".") + 1);
                    string className = classAndAction.Substring(0, classAndAction.Length - action.Length - 1);

                    CallInfo info = null;
                    list.Add(info = new CallInfo()
                    {
                        //TextMessage = line,
                        ThreadId = Thread.CurrentThread.ManagedThreadId,
                        TextMessage = "",
                        ClassName = className,
                        ActionName = action,
                        ActionStarted = true,
                        FilePath = "file:///" + line.Substring(i, line.IndexOf(":line") - i).ReplaceAll(@"\", "/"),
                        LineNumber = line.Substring(line.IndexOf(":line") + ":line".Length).Trim().ToInt()
                    });
                    string text = info.FilePath.Substring(0, info.FilePath.LastIndexOf("."));

                    info.FileName = text.Substring(text.LastIndexOf("/") + 1);
                }
            }

            list.Reverse();
        }
        catch (Exception ex)
        {
            target.Error(ex.Message);
            target.Error(ex.StackTrace);
        }


        return list;
    }
    public static ExceptionInfo ToDocument(this Exception target)
    {
        var result = new ExceptionInfo();
        Exception p = target;
        do
        {
            GetStack(p.StackTrace).ForEach<CallInfo>((next) => {
                result.Add(next);
            });
            result.Add(new CallInfo()
            {
                TextMessage = p.Message                
            });
            p = p.InnerException;
        } while (p != null);
        return result;
    }
    public static string ToTextDocument(this Exception target)
    {
        var result = new ExceptionInfo();
        Exception p = target;
        do
        {
            GetStack(p.StackTrace).ForEach<CallInfo>((next) => {
                result.Add(next);
            });
            result.Add(new CallInfo()
            {
                TextMessage = p.Message
            });
            p = p.InnerException;
        } while (p != null);

        return result.ToString();
    }
    public class ExceptionInfo
    {
        public ConcurrentBag<CallInfo> Data { get; set; } = new ConcurrentBag<CallInfo>();

        public void Add(CallInfo callInfo)
        {
            Data.Add(callInfo);
        }

        public override string ToString()
        {
            string text = "";
            foreach (var callInfo in Data)
            {

                text += "\n" + callInfo.TextMessage;
            }
            return text;
        }

        public class CallInfo
        {
            [InputEngText]
            public string ClassName { get; set; }

            [InputEngWord]
            public string ActionName { get; set; }

            [NotNullNotEmpty]
            public IDictionary<string, object> CallArguments { get; set; } = new Dictionary<string, object>();  

            [InputNumber]
            public int ThreadId { get; set; } = Thread.CurrentThread.ManagedThreadId;

            [InputBool]
            public bool ActionCompleted { get; set; } = false;

            [InputBool]
            public bool ActionStarted { get; set; } = true;

            [NotNullNotEmpty]
            [InputText]
            public string FilePath { get; set; }

            [InputNumber]
            [NotNullNotEmpty]
            public int LineNumber { get; set; }

            [NotNullNotEmpty]
            [InputText]
            public string FileName { get; set; }

            [InputText]
            public string TextMessage { get; set; }

            public override string ToString()
            {
                if (String.IsNullOrWhiteSpace(TextMessage))
                {
                    return 
                        $"{(this.ActionCompleted? "Завершено" : "Приступаю")} " +
                        $"{FileName}:{LineNumber}";
                }
                else
                {
                    return 
                        $"{(this.ActionCompleted ? "Завершено" : "Приступаю")} " +
                        $"{FileName}:{LineNumber} => { TextMessage}";
                }
                
            }
        }
  
    }

    private static IEnumerable<CallInfo> GetStack(string stackTrace)
    {

        var list = new List<CallInfo>();
        foreach(string line in stackTrace.Split("\n"))
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
}


