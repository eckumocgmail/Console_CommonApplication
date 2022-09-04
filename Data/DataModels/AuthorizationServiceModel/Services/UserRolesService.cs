﻿using ApplicationDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


public class UserBusinessResourcesService
{
    private AuthorizationDataModel _context;


    public UserBusinessResourcesService(AuthorizationDataModel context)
    {
        _context = context;
    }


    public List<ILink> GetUserBusinessResourceNavigation(string BusinessResourceName)
    {
         
        List<ILink> links = new List<ILink>();
        BusinessResource role = GetBusinessResourceByCode(BusinessResourceName);
        
        Type type = ReflectionService.TypeForShortName(BusinessResourceName);
        IEnumerable<string> TypeNames =_context.GetEntityTypeNames();
        if (type != null && TypeNames.Contains(BusinessResourceName))
        {
            
            foreach ( var nav in _context.GetNavigationPropertiesForType(type))
            {
                if( nav.Name != "User")
                {
                    links.Add(new Link()
                    {
                        Label = AttrsUtils.LabelFor(type, nav.Name),
                        Href = $"/{role.Code}Face/{TextNaming.GetMultiCountName(nav.Name)}/Index"
                    });
                }
                
            }
        }        
        return links;
    }

    public BusinessResource GetBusinessResourceByCode(string roleCode)
    {
        return (from p in _context.BusinessResources where p.Code == roleCode select p).FirstOrDefault();
    }

    public List<string> GetUserBusinessResourceCodes(UserApi  user)
    {
        List<string> codes = new List<string>();
        BusinessResource prole = user.Role;
        while (prole != null)
        {
            codes.Add(prole.Code);
            if (prole.ParentID == null)
            {
                break;
            }
            else
            {
                prole = _context.BusinessResources.Find((int)prole.ParentID);
            }
        }
        return codes;
    }


    /// <summary>
    /// Поиск роли по коду
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public BusinessResource FindBusinessResourceByCode(string code)
    {
        return (from r in _context.BusinessResources where r.Code == code select r).FirstOrDefault();
      
    }


    /// <summary>
    /// Создание новой роли в приложении
    /// </summary>
    /// <param name="name">наименование</param>
    /// <param name="description">описание</param>
    /// <param name="code">код</param>        
    public BusinessResource CreateBusinessResource(string name, string description, string code)
    {
        BusinessResource role = new BusinessResource()
        {
            Name = name,
            Description = description,
            Code = code
        };
        _context.BusinessResources.Add(role);
        _context.SaveChanges();
        return role;
    }
}
