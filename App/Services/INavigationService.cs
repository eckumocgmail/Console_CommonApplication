using Microsoft.AspNetCore.Mvc;


/// <summary>
/// Функции навигации по доменной области
/// </summary>
public interface INavigationService
{
  

    /// <summary>
    /// Создание компонента навигации по текущей области
    /// </summary>        
    /// <returns>меню навигации</returns>
    public ILink GetNavMenu();

    public void Navigate(string Route);


    public string GetState();
    public string GetIndex();
    public string GetNotFound();


}
