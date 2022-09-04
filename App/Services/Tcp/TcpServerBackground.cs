using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

public class TcpServerBackground
{
    public IDictionary<int, TcpMessageServer> Endpoints { get; set; } =
        new ConcurrentDictionary<int, TcpMessageServer>();

    public event EventHandler<DataRequestMessage> OnMessageRequest = (sender, evt) => {
        sender.Info(evt);
    };

    public int OpenSocket(Func<DataRequestMessage, DataResponseMessage> handler)
    {
        int port;
        do
        {
            port = GetRandomInt(1000) + 13000;
            if (IsFreePort(port))
            {
                Endpoints[port] = new TcpMessageServer(handler);
                break;
            }
        }while (true);
        return port;        
    }

    private int GetRandomInt(int v)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }

    private bool IsFreePort(int port)
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}

