using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

/// <summary>
/// Исп. этот класс для навигации среди одной области (Areas)
/// Находит контроллеры маркероанные спец. атрибутом , создаёт меню навигации по обьявленным операциям
/// </summary>
 
public abstract class NavigationController<TNavigationModel> : 
                        BaseController
                            where TNavigationModel: NavigationModel
{
        
    protected INavigationService _navigation;

    protected NavigationController(IServiceProvider provider) : base(provider)
    {
    }







    /// <summary>
    /// Возвращает ссылку на меню навигации
    /// </summary>        
    public ILink GetNavMenu()
    {
        return _navigation.GetNavMenu();
    }


    /// <summary>
    /// Навигация согласно маршруту
    /// </summary>
    public void Navigate(string Path)
    {
        _navigation.Navigate(Path);
    }
}
    
