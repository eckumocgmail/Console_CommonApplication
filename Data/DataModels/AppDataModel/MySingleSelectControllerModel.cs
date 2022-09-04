using System;
using System.Collections.Generic;

[Icon("")]
[Label("")]
[Description("Контроллер предназначен для .")]
public class MySingleSelectControllerModel<T>: MyControllerModel
{
    public MySingleSelectControllerModel(
                string viewItemTemplate, 
                T[] items, 
                Action<T> OnSelected)
    {
    }
}