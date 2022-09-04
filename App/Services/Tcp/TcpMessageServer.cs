using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TcpMessageServer: IRunnable
{
    private string address;
    private int port;
    private Func<DataRequestMessage, DataResponseMessage> handler;

    public TcpMessageServer( Func<DataRequestMessage, DataResponseMessage> handler, string address="127.0.0.1", int port=13000): base()
    {
        this.address = address;
        this.port = port;
        this.handler = handler;
    }

    public void Run(params string[] args)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public Task RunAsync(params string[] args)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void Add(IRunnable item)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void Clear()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public bool Contains(IRunnable item)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public void CopyTo(IRunnable[] array, int arrayIndex)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public bool Remove(IRunnable item)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    public int Count => throw new NotImplementedException($"{GetType().GetTypeName()}");

    public bool IsReadOnly => throw new NotImplementedException($"{GetType().GetTypeName()}");

    public IEnumerator<IRunnable> GetEnumerator()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

  
}

