using System.Collections.Generic;


/// <summary>
/// Модель параметра вызова метода или процедуры или функции.
/// ПО этой модели приложение-клиент создаёт поле для ввода информации
/// на форме выполнения операции.
/// </summary>
[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class MyParameterDeclarationModel: DictionaryTable
{
 
    public string Type { get; set; }
    public bool IsOptional { get; set; }
    public int Position { get; set; }
    public object DefValue { get; set; }
    public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
}
