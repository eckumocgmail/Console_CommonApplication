
using Microsoft.AspNetCore.Razor.TagHelpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Реализует обращение к представлению сопоставленному URL-адресу
/// </summary>
[ViewTemplate(@"
    <div id='view-{{GetHashCode()}}'></div>
    <script>(function(){
        try {
            let container = document.getElementById('view-{{GetHashCode()}}');

            //удаление дочерних узлов
            while (container.childNodes.length > 0)
                container.removeChild(container.childNodes[0]);

            let req = new XMLHttpRequest();
            req.open('{{Method}}', location.origin + '{{URL}}', true);
            req.setRequestHeader('Partial', 'view-{{GetHashCode()}}');
            req.onreadystatechange = function () {
                if ((req.readyState) == 4) {
                        
                    if (req.status == 200) {

                        //добавление полученного контента
                        let pnode = document.createElement('div');
                        pnode.innerHTML = req.responseText;
                        container.appendChild(pnode);

                        //поиск и компиляция скриптов
                        function forScripts(p, action) {
                            if (p.tagName == 'SCRIPT') {
                                action(p);
                            } else {
                                if (p.childNodes) {
                                    for (let i = 0; i < p.childNodes.length; i++) {
                                        forScripts(p.childNodes[i], action);
                                    }
                                }
                            }
                        }                    
                        forScripts(pnode, (p) => {
                            const scriptNode = document.createElement('script');
                            scriptNode.innerHTML = p.innerHTML;
                            container.appendChild(scriptNode);
                                 
                        });

                    } else {
                        container.innerHTML = '<div class=" + "\"alert alert-danger\">[{{URL}}]" + @"[' + req.status + ']</div> ';                        
                    }
                }
            }
            req.send();
        } catch (e) {
            console.error(e);
            alert(e);
        }
    })();</script>"
)]
public class IncludeTagHelper : InterpolateTagHelper
{

    /// <summary>
    /// URL-адрес представления
    /// </summary>
    public string URL { get; set; }

    /// <summary>
    /// Метод HTTP-запроса
    /// </summary>
    public string Method { get; set; } = "GET";


    /// <summary>
    /// Конструктор по-умолчанию
    /// </summary>
    public IncludeTagHelper(): base()
    {
        Api.Utils.Info($"[{GetType().Name}][{GetHashCode()}]: "+"Created");
    }
}
