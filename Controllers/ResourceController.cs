using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApplicationDb;
using ApplicationDb.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


/// <summary>
/// Необходимо уметь получать бинарные данные из ХД
/// Сохранять в ХД
/// Читать бинарные данные( отображать изображения )
/// </summary>
[Route("[controller]/[action]")]
[Route("api/[controller]/[action]")]
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
[ApiController]
public class ResourceController : ControllerBase
{
    private readonly IServiceProvider  _models;
    private readonly AuthorizationDataModel _db;


    /// <summary>
    /// Конструктор 
    /// </summary>
    /// <param name="db"> контекст базы данных </param>
    public ResourceController(AuthorizationDataModel db, IServiceProvider  models) : base()
    {
        _models = models;
        _db = db;
    }

  
    /*/// <summary>
    /// Вывод списка загруженных ресурсов
    /// </summary>       
    public async Task<Dictionary<string, object>> List()
    {
        Dictionary<string, object> resp = new Dictionary<string, object>();
        resp["data"] = await (from r in _db.BinaryResources select r.ID).ToListAsync();
        resp["status"] = "success";
        return resp;
    }


    /// <summary>
    /// Используется вывода изображения
    /// </summary>
    /// <param name="id"> идентификатор ресурса</param>
    /// <returns></returns>
    [Route("/api/Resource/Use/{id:int}")]
    public async Task Use([FromRoute] int id)
    {
        Dictionary<string, object> resp = new Dictionary<string, object>();
        BinaryResource resource = _db.BinaryResources.Find(id);
        if (resource == null)
            return;
        Response.ContentType = resource.Mime;
        byte[] data = resource.Data;
        await Response.Body.WriteAsync(data, 0, data.Length);
        resp["status"] = "success";
    }*/


    /// <summary>
    /// Используется вывода изображения
    /// </summary>
    /// <param name="id"> идентификатор ресурса</param>
    /// <returns></returns>
    [Route("/api/Resource/Image")]
    public async Task Use(string entity, int id)
    {
        if( string.IsNullOrEmpty(entity))
        {
            return;
        }
        var type = ReflectionService.TypeForName(entity);

        if (type == null)
        {
            return;
        }
        string prop = AttrsUtils.GetInputImagePropertyName(type);
        if (prop == null)
        {
            return;
        }

        var record = _db.Find(entity, id);
        if (record == null)
        {
            return;
        }


        var data = ReflectionService.GetValueFor(record, prop);
        byte[] binaryData = (byte[])data;
        if(binaryData != null)
        {
            await Response.Body.WriteAsync(binaryData, 0, binaryData.Length);
        }
            
           
    }



    [HttpPost()]
    public async Task<Dictionary<string, object>> Upload( int modelid, string property )
    {
        Dictionary<string, object> response = new Dictionary<string, object>();
        string resourceName = Request.Headers["Resource-Name"];
        string mimeType = Request.Headers["Mime-Type"];
        FileEntity resource = new FileEntity()
        {
            Name = resourceName,
            Mime = mimeType,
            Created = DateTime.Now
        };
        long? length = this.HttpContext.Request.ContentLength;
        if (length != null)
        {
            resource.Data = new byte[(long)length];
            await this.HttpContext.Request.Body.ReadAsync(resource.Data, 0, (int)length);
        }

        object model = this.FindByHash(modelid);
        Form form = ((Form)model);
        form.Item.GetType().GetProperty(property).SetValue(form.Item, resource.Data);

        response["status"] = "success";
        response["id"] = resource.ID;            
        return response;
    }

    private object FindByHash(int modelid)
    {
        return null;
    }


    //string PhotoUrl = $"https://localhost:44347/Market/Products/PhotoImage/" + productId;
    [HttpPost()]
    public async Task<Dictionary<string, object>> Create()
    {
        Dictionary<string, object> response = new Dictionary<string, object>();
        string resourceName = Request.Headers["Resource-Name"];
        string mimeType = Request.Headers["Mime-Type"];
        FileEntity resource = new FileEntity()
        {
            Name = resourceName,
            Mime = mimeType,
            Created = DateTime.Now
        };
        long? length = this.HttpContext.Request.ContentLength;
        if (length != null)
        {
            resource.Data = new byte[(long)length];
            await this.HttpContext.Request.Body.ReadAsync(resource.Data, 0, (int)length);
        }
        _db.Add(resource);
        await _db.SaveChangesAsync();

        response["statuc"] = "success";
        response["id"] = resource.ID;
        response["url"] = $"/api/{GetType().Name.Replace("Controller", "")}/Use/{resource.ID}";
        return response;
    }
}
