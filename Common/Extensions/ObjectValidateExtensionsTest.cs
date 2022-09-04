public class ObjectValidateExtensionsTest : TestingElement
{

    public void ValidateTest() {
        new MyValidatableObject().Validate();
        Messages.Add("Реализована функция выполнения проверки свойств в объектах типа MyValidationObject");
    }
    public void EnsureIsValideTest() { }

    public override System.Collections.Generic.List<string> OnTest()
    {
        EnsureIsValideTest();
        ValidateTest(); return Messages;
    }
}
