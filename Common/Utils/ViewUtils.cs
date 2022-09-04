using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ViewUtils
{    
    public static string GetAreaName(Microsoft.AspNetCore.Mvc.Rendering.ViewContext ctx)
    {
        var p = ctx.RouteData.Values["area"];
        return p!=null?p.ToString()+"Controller": "";
    }

    public static string GetControllerName(Microsoft.AspNetCore.Mvc.Rendering.ViewContext ctx)
    {
        return ctx.RouteData.Values["controller"] + "Controller";
    }


    /// <summary>
    /// ��������� �������� � �����������
    /// </summary>
    /// <param name="ctx">�������� �������������</param>
    /// <returns>URL</returns>
    public static string GetControllerPath(Microsoft.AspNetCore.Mvc.Rendering.ViewContext ctx)
    {
        
        var areaRoute = ctx.RouteData.Values["area"];
        if(areaRoute==null || areaRoute.ToString() == "")
        {
            object ctrl = ctx.RouteData.Values["controller"];
            if(ctrl==null)
                ctrl = ctx.RouteData.Values["page"];
            else ctrl = "/" + ctrl;

            return ctrl.ToString();
        }
        else
        {
            object ctrl = ctx.RouteData.Values["controller"];
            if (ctrl == null)
                ctrl = ctx.RouteData.Values["page"];
            else ctrl = "/" + ctrl;
            return $"/{areaRoute.ToString()}" + ctrl;
        }        
    }


    /// <summary>
    /// ������� �������� ����� �������������
    /// </summary>
    /// <param name="ctype">��� �����������</param>
    /// <param name="key">���� � ��������</param>
    /// <returns></returns>
    public static bool IsViewResult(System.Type ctype, string key)
    {
        
        return TypeUtils.IsExtendedFromType(
            new List<MethodInfo>(ctype.GetMethods()).Where(m => m.Name == key).First().ReturnType, typeof(Microsoft.AspNetCore.Mvc.ViewResult));
    }
}