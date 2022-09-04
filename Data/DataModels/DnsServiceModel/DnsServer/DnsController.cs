using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DnsDataModel;
using static System.Text.Json.JsonSerializer;

public class DnsController: Controller
{
    /// <summary>
    /// Считывание бинарных данных в основном блоке сообщения
    /// </summary>
    /// <param name="httpContext"> контекст протокола </param>
    /// <returns></returns>
    public static async Task<byte[]> ReadRequestBody(HttpContext httpContext)
    {
        long? length = httpContext.Request.ContentLength;
        if (length != null)
        {
            byte[] data = new byte[(long)length];
            await httpContext.Request.Body.ReadAsync(data, 0, (int)length);
            string mime = httpContext.Request.ContentType;
            return data;
        }
        return new byte[0];
    }

    public async Task<IEnumerable<DnsDataModel.DnsRecord>> List(
        [FromServices] DnsDataModel dnsDbContext)
        => await dnsDbContext.DnsRecords.ToListAsync();

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ILogger<DnsController> logger,
        [FromServices] DnsDataModel dnsDbContext)
    {                                             
        try
        {
            byte[] message = await ReadRequestBody(HttpContext);
            string json = Encoding.UTF8.GetString(message);
            DnsDataModel.DnsRecord record =
            Deserialize<DnsDataModel.DnsRecord>(json);
            await Task.CompletedTask;
            if (IsTcpIp4Addr(record.IP4) == false)
            {
                return StatusCode(400, "IP-адрес указан неправильно");
            }
            if (IsValidHostName(record.Origin) == false)
            {
                return StatusCode(400, "Не допустимое имя ресурса");
            }
            dnsDbContext.DnsRecords.Add(record);
            await dnsDbContext.SaveChangesAsync();

            string uri = CreateUri(record);
            object resource = CreatePublicLib(record);
            return Created(uri, resource);
        }
        catch (Exception ex)
        {
            this.Error(ex);
            return Redirect("https://www.spb.ru/policy/");
        }                        
    }

         
    private object CreatePublicLib(DnsRecord record)
    {
        return $@"<html><head></head><body>{System.Text.Json.JsonSerializer.Serialize(record)}</body></html>";
    }

    private static string CreateUri(DnsDataModel.DnsRecord record)
    {
        var uriBuilder = new UriBuilder();
        uriBuilder.Scheme = "http";
        uriBuilder.Host = record.Origin;
        uriBuilder.Path = "";
        uriBuilder.Query = "";
        uriBuilder.Fragment = "";
        uriBuilder.UserName = "admin";
        uriBuilder.Password = "sgdf";
        return uriBuilder.ToString();
    }

    /// <summary>
    /// Проверка имени ресурса по правилам:        
    /// 1-не содержит знаков пунктуации, либо содержит 2 разделителя '.'
    /// 2-имена состоят из символов латинского алфавимта длиной от 2 до 10 символов        
    /// </summary>
    private bool IsValidHostName(string origin)
    {
        var words = origin.Split(".");
        if( words.Length!=3 && words.Length != 1)
        {
            return false;
        }
        else
        {
            foreach(var word in words)
            {
                if(word.Length<2 || word.Length > 10)
                {
                    return false;
                }
                else
                {
                    if (IsEngWord(word) == false)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        return true;
    }

    private bool IsEngWord(string word)
    {
        char[] numbers = ("qwertyuiopasdfghjklzxcvbnm".ToUpper()+"qwertyuiopasdfghjklzxcvbnm").ToCharArray();
        foreach (char ch in word.ToCharArray())
        {
            if (numbers.Contains(ch) == false)
                return false;
        }
        return true;
    }

    private bool IsTcpIp4Addr(string IP4)
    {
        var words = IP4.Split(".");
        if (words.Length != 4  )
        {
            return false;
        }
        else
        {
            foreach (var word in words)
            {
                if (word.Length < 1 || word.Length > 3)
                {
                    return false;
                }
                else
                {
                    if (IsNumber(word) == false)
                    {
                        return false;
                    }
                    else
                    {
                        int value = int.Parse(word);
                        if( value>255 )
                        {
                            return false;
                        } 
                        return true;
                    }
                }
            }
        }
        return true;
    }

    private bool IsNumber(string word)
    {
        char[] numbers = "1234567890".ToCharArray();
        foreach(char ch in word.ToCharArray())
        {
            if (numbers.Contains(ch) == false)
                return false;
        }
        return true;
    }
}
