using System;
using System.Collections.Generic;
using System.Text;

public class TestAttrs : TestingElement
{

    public class Service
    {
        [Label("Выполнить что-то")]
        public void Todo() { }


        [Label("Проверить выполненое ли что-то")]
        public void Validate() { }
    }
    private void canParseAttributes()
    {
        Console.WriteLine(@"
            public class Service
            {
                [Label(""Выполнить что - то"")]
                void Todo() { }


                [Label(""Проверить выполненое ли что-то"")]
                void Validate()
                { }
            }
        ");
       
                                                Console.WriteLine($"Атрибуты метода: void Todo() => {  AttrsUtils.ForMethod(typeof(Service), "Todo").ToJsonOnScreen()}");
        Console.WriteLine($"Атрибуты метода: void Validate() => {AttrsUtils.ForMethod(typeof(Service), "Validate").ToJsonOnScreen()}");
        if (AttrsUtils.GetActionLabel(new Service().GetType(), "Todo") != "Выполнить что-то")
            throw new Exception("Не правильно считан атрибут Label у метода Todo");
        if (AttrsUtils.GetActionLabel(new Service().GetType(), "Validate") != "Проверить выполненое ли что-то")
            throw new Exception("Не правильно считан атрибут Label у метода Validate");


         
            
    }

    private void canParseInputType()
    {          
        var target = new TestAttributeInputClass();
        foreach(var p in target.GetType().GetProperties())
        {
            string type = AttrsUtils.GetInputType(target.GetType(), p.Name);
            if( p.Name != type && 
                new List<string> { "ID","Description"}.Contains(p.Name)==false)
            {
                throw new Exception($"Тип элемента ввода {type} определён неверно для свойства {p.Name} класса {target.GetType().Name} ");
            }
        }
          
    }
    [Label("Учетная запись")]
    class UserAccount
    {

    }
    private void canParseDisplayNameForModel()
    {
        if (AttrsUtils.LabelFor(new UserAccount()) != "Учетная запись")
        {
            throw new Exception("Атрибут подписи модели не был получен");
        }
        Messages.Add("Реализована возможность задавать подписи к моделям через атрибуты");
    }

    public override List<string> OnTest()
    {

        canParseAttributes();
        canParseInputType();
        canParseDisplayNameForModel();
        return Messages;
    }
}
