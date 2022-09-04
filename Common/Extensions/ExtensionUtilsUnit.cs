using System;
using System.Collections.Generic;
using System.Linq;

[Label("Модуль: 'Расширения объектов'")]
[Description("Модуль тестирования функций расширения объектов")]
public class ExtensionUtilsUnit : TestingUnit
{
    public ExtensionUtilsUnit(TestingUnit parent) :base(parent)
    {
        Push(new ActionExtensionsTest());
        Push(new AssemblyExtensionsTest());
        Push(new CollectionsExtensionsTest());
        Push(new DbSetExtensionsTest());
        Push(new ModelBuilderExtensionsTest());
        Push(new ObjectCompileExpExtensionsTest());
        Push(new ObjectInputExtensionsTest());
        Push(new ObjectValidateExtensionsTest());
        Push(new TextConvertExtensionsTest());
        Push(new TextCountingExtensionsTest());
        Push(new TextExtensionsTest());
        Push(new TextFactoryExtensionsTest());
        Push(new TextIOExtensionsTest());
        Push(new TextLangExtensionsTest());
        Push(new TextNamingExtensionsTest());
        Push(new TextTypeExtensionsTest());
        Push(new ThrowableExtensionsTest());
        Push(new TypeAttributesExtensionTest());
        Push(new TextFactoryExtensionsTest());
        Push(new ActionExtensionsTest());
        Push(new AssemblyExtensionsTest());
        Push(new CollectionsExtensionsTest());
    }

    
}
