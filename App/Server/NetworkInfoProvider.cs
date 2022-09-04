using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


public class NetworkInfoProvider
{
    public static void TraceConnections()
    {
        TraceTcpIp4Connections();

    }

    public static void TraceUdpConnections()
    {
        foreach (var udpi in IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners())
        {
            Console.WriteLine($"{udpi.Address.MapToIPv4().ToString()}:{udpi.Port}  ");
        }
    }

    public static void TraceTcpIp4Connections()
    {
        foreach (TcpConnectionInformation tcpi in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections())
        {
            Console.WriteLine($"{tcpi.RemoteEndPoint.Address.MapToIPv4().ToString()}:{tcpi.RemoteEndPoint.Port}   <=>   {tcpi.LocalEndPoint.Address.MapToIPv4().ToString()}:{tcpi.LocalEndPoint.Port}");
        }
    }

    public static void TraceTcpIp6Connections()
    {
        foreach (TcpConnectionInformation tcpi in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections())
        {
            Console.WriteLine($"{tcpi.RemoteEndPoint.Address.MapToIPv6().ToString()}:{tcpi.RemoteEndPoint.Port}   <=>   {tcpi.LocalEndPoint.Address.MapToIPv6().ToString()}:{tcpi.LocalEndPoint.Port}");
        }
    }

    public static bool IsFreePort(int port) =>
        IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections().Select(con => con.LocalEndPoint.Port).Contains(port) ? false : true;

    public static int GetFreePort()
    {
        int port = Randomizing.GetRandomInt(11000, 15000);
        do
        {
            port = Randomizing.GetRandomInt(11000, 15000);
        }while(IsFreePort(port)==false);
        return port;
    }

}
