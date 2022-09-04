
using Microsoft.AspNetCore.Razor.TagHelpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewTags
{
     
    public class InputControllerTagHelper : TagHelper
    {

        /// <summary>
        /// URL-адрес представления
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Хэш-код модели компонента представления
        /// </summary>
        public int ID { get; set; }

      


        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public InputControllerTagHelper(): base()
        {
            Api.Utils.Info($"[{GetType().Name}][{GetHashCode()}]: "+"Created");
        }


        /// <summary>
        /// Метод вывода разметки
        /// </summary>
        /// <param name="context">контекст вспомогательной функции тега</param>
        /// <param name="output">поток вывода</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {             
            try
            {
                output.TagName = "div";
                output.Attributes.SetAttribute(
                    "oninput",
                    "https("+"{url:"+$"'{URL}'"+ ", method: 'put', params: { Source: "+ID+ ", Property: event.target.name, Value: event.data||event.target.value } }).then(console.log)"
                );                
            }
            catch (Exception ex)
            {                
                output.Content.SetHtmlContent($"<div class='alert alert-danger'>{ex.GetType().Name}: {ex.Message}</div>");
            } 

        }
    }
}
