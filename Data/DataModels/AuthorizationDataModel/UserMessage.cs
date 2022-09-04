using ApplicationDb.Entities;

using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

[Label("Сообщение")]
[Icon("drafts")]
[SearchTerms(nameof(Subject) + ","+ nameof(Text))]
public class UserMessage : BaseEntity
{
    public UserMessage(): base() { }
 
 
 
     


    [Label("Создано")]
    [InputHidden()]
    public DateTime Created { get; set; } = DateTime.Now;


    [Label("Тема")]
    [NotNullNotEmpty("Необходимо указать тему сообщения")]
    public string Subject { get; set; }


    [Label("Текст сообщения")]
    [InputMultilineText( )]
    [NotNullNotEmpty("Необходимо ввести текст сообщения")]
    public string Text { get; set; }

    public int FromUserID { get; set; }
    public UserApi FromUser { get; set; }
}
 
