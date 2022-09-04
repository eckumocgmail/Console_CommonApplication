public class TypeAttributesExtensionTest : TestingElement
{

 

    public override System.Collections.Generic.List<string> OnTest()
    {
        Utils.ForType(typeof(MyValidatableObject));
        Messages.Add("Реализована функция получения атрибутов для типов"); return Messages;
    }
}
