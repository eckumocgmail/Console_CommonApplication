using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class AppRootTransportUnit: TestingElement
{
    public override List<string> OnTest()
    {
        var client = new MessageClient("https://localhost:5001/ResourceHub");
        client.Connect().Wait();

        this.SetInterval(() => {
            client.Request(
                new
                {
                    Time = DateTime.Now
                },
                (messageWithTime) => {
                    Console.WriteLine("Responded message: \n" + (messageWithTime).ToJsonOnScreen());
                }
            ).Wait();
        }, 1000);
        Thread.Sleep(Timeout.Infinite);
        return Messages;
    }
}

