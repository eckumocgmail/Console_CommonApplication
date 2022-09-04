using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

 


/// <summary>
/// Вспомогательные методы работы с протоколом
/// </summary>
public class HttpUtils
{

    /// <summary>
    /// Возвращает признак запроса частичного представления
    /// </summary>
    /// <param name="context">контекст представления</param>
    /// <returns>признак запроса частичного представления</returns>
    public static bool IsPartialRequest( ViewContext context )
    {            
        return context.HttpContext.Request.Headers.ContainsKey("Partial");
    }
}
 
