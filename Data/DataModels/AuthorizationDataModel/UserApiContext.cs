using System;
using System.Collections.Concurrent;

public class UserApiContext : IUserAgent
{

    private ConcurrentDictionary<int,object> Items = new ConcurrentDictionary<int,object>();
    private ConcurrentDictionary<Type,object> Services = new ConcurrentDictionary<Type, object>();
   
    public object this[int index]
    {
        get => this.Items.ContainsKey(index) ? Items[index] : null;
        set => this.Items[index] = value;
    }
    public object this[Type index]
    {
        get => this.Services.ContainsKey(index) ? Services[index] : null;
        set => this.Services[index] = value;
    }



    public IUserAgent UserAgent { get; set; }






    public bool InfoDialog(string Title, string Text, string Button)
    {
        return UserAgent.InfoDialog(Title, Text, Button);
    }

    public void ShowHelp(string Text)
    {
        UserAgent.ShowHelp(Text);
    }

    public bool RemoteDialog(string Title, string Url)
    {
        return UserAgent.RemoteDialog(Title, Url);
    }

    public bool ConfirmDialog(string Title, string Text)
    {
        return UserAgent.ConfirmDialog(Title, Text);
    }

    public bool CreateEntityDialog(string Title, string Entity)
    {
        return UserAgent.CreateEntityDialog(Title, Entity);
    }

    public object InputDialog(string Title, object Properties)
    {
        return UserAgent.InputDialog(Title, Properties);
    }

    public string Eval(string js)
    {
        return UserAgent.Eval(js);
    }

    public string HandleEvalResult(Func<object, object> handle, string js)
    {
        return UserAgent.HandleEvalResult(handle, js);
    }

    public string Callback(string action, params string[] args)
    {
        return UserAgent.Callback(action, args);
    }

    public bool AddEventListener(string id, string type, string js)
    {
        return UserAgent.AddEventListener(id, type, js);
    }

    public bool DispatchEvent(string id, string type, object message)
    {
        return UserAgent.DispatchEvent(id, type, message);
    }
}