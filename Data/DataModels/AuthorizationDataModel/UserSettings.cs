[Label("Настройки")]
public partial class UserSettings : BaseEntity
{

    [Label("Вертикальное позиционирование")]
    [InputBool]
    public bool VertialLayout { get; set; }

    [Label("Включить поведение не требующее действий со стороны пользователя")]
    [InputBool]
    public bool FocusControls { get; set; }

    [Label("Цветовая схема")]
    [InputText]
    //[SelectControl("Light,Dark,Blue,Modern")]
    public string ColorTheme { get; set; }


    [Label("Публиковать мои действия")]
    [InputBool]
    public bool PublicOperations { get; set; }


    [Label("Передавать сообщения на электронную почту")]
    [InputBool]
    public bool SendNewsToEmail { get; set; }


    [Label("Показывать справочную информацию в интерактивном режиме")]
    [InputBool]
    public bool ShowHelp { get; set; }


    [Label("Оценивать мои способности работы с системой")]
    [InputBool]
    public bool EvaluateMe { get; set; }



}