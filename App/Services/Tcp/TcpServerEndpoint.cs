using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class TcpServerEndpoint
{

    public static TcpServerEndpoint Run(string addr, int port)
    {
        TcpServerEndpoint endpoint = new TcpServerEndpoint(addr, port);
        endpoint.Start();
        return endpoint;
    }


    private string addr = "127.0.0.1";
    protected int port;

    public TcpServerEndpoint(string addr= "127.0.0.1", int port=13000)
    {
        this.addr = addr;
        this.port = port;
    }

    public void Start()
    {        
        TcpListener server = null;
        try
        {                                                         
            server = new TcpListener(IPAddress.Parse(this.addr), this.port);                    
            server.Start();
                    
            Byte[] bytes = new Byte[256];
            String data = null;                    
            while (true)
            {                                                                       
                TcpClient client = server.AcceptTcpClient();
                
                data = null;                        
                NetworkStream stream = client.GetStream();
                int i;                        
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {                            
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);                                                        
                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);                            
                    stream.Write(msg, 0, msg.Length);                            
                }                       
                client.Close();
            }
        }
        catch (SocketException e)
        {
            System.Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {                    
            server.Stop();
        }

        System.Console.WriteLine("\nHit enter to continue...");
        System.Console.Read();          
    }

    
}
 