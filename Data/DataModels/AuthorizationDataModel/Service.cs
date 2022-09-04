using ApplicationDb.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public interface IService
{
    int LoginCount { get; set; }
    ServiceCertificate ServiceCertificate { get; set; }
    string Url { get; set; }
    Task DoCheck(long timeout);
}


/// <summary>
/// Обьект модели пользователя сеансов
/// </summary>
[Label("Микрослужба")]
[Icon("build")]
public class Service : ActiveObject, DoCheck, IService
{


    [InputHidden(true)]
    [Label("Учетная запись")]
    public virtual ServiceCertificate ServiceCertificate { get; set; }



    [InputUrl]
    [Label("")]
    public string Url { get; set; }

    [Label("Кол-во посещений")]
    public int LoginCount { get; set; }


    public async Task DoCheck(long timeout)
    {
        await Task.CompletedTask;
    }
}
 