public class ModelBuilderExtensionsTest : TestingElement
{

   
    public void GetEntityContrainstsTest() {
        Messages.Add("Реализована функция считывания ограничений сущности из атрибутов");
    }

    public override System.Collections.Generic.List<string> OnTest()
    {
 
        GetEntityContrainstsTest(); return Messages;
    }
}
