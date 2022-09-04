using System;

public interface IJavaScriptApi
{
    string Eval(string js);
    string HandleEvalResult(Func<object, object> handle, string js);
    string Callback(string action, params string[] args);
    bool AddEventListener(string id, string type, string js);
    bool DispatchEvent(string id, string type, object message);
}
