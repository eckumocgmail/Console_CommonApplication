if (!window['input'])
    throw new Error('Не определён контекст ввода input');
//Combobox, Control, SelectControl, SelectControlWithoutValidation, ClassDescription, Description, SystemEntity, Units, UncluteredIndex, ManyToMany, ModelCreating, OneToMany, OneToOne, ZeroOrOne, InputNumber
function JsonIgnore(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('UniqValidation', description, target.constructor.name, property);
    };
}
function UniqValidation(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('UniqValidation', description, target.constructor.name, property);
    };
}
function ManyToMany(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputCustom', description, target.constructor.name, property);
    };
}
function InputCustom(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputCustom', description, target.constructor.name, property);
    };
}
function InputDuration(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputDuration', description, target.constructor.name, property);
    };
}
function InputPostalCode(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputPostalCode', description, target.constructor.name, property);
    };
}
function InputXml(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputXml', description, target.constructor.name, property);
    };
}
/**
 * Сохранение маркеров свойств в контекст ввода
 * @param annotation - имя функции посредника атрибута
 * @param args - аргументы вызова функции
 * @param type - класс определяющий свойства
 * @param property - имя свойства
 */
function markProperty(annotation, args, type, property) {
    var input = window['input'];
    if (!input[type]) {
        input[type] = {};
    }
    if (!input[type][property]) {
        input[type][property] = {};
    }
    input[type][property][annotation] = args;
}
/**
 * Маркеры моделей
 **/
if (!window['spec']) {
    throw new Error('spec not defined');
}
/**
 * Сохранение маркеров модели данных
 * @param annotation - имя функции посредника атрибута
 * @param args - аргументы вызова функции
 * @param type - класс определяющий свойства
 */
function markModel(annotation, args, type) {
    var spec = window['spec'];
    if (!spec[type]) {
        spec[type] = {};
    }
    spec[type][annotation] = args;
}
function Index(expr, text) {
    var description = arguments;
    return function (constructor) {
        markModel('Index', description, constructor['name']);
    };
}
function DataType(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('DataType', description, target.constructor.name, property);
    };
}
function SelectDataDictionary(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('SelectDataDictionary', description, target.constructor.name, property);
    };
}
function Navigation(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Navigation', description, target.constructor.name, property);
    };
}
function ForeignProperty(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('propertyName', description, target.constructor.name, property);
    };
}
function IsCollection(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('isCollection', description, target.constructor.name, property);
    };
}
function SearchTerms(fields) {
    var description = arguments;
    return function (constructor) {
        markModel('TextSearch', description, constructor['name']);
    };
}
function TextSearch(fields) {
    var description = arguments;
    return function (constructor) {
        markModel('TextSearch', description, constructor['name']);
    };
}
function EntityLabel(expr, text) {
    var description = arguments;
    return function (constructor) {
        markModel('EntityLabel', description, constructor['name']);
    };
}
function EntityIcon(expr, text) {
    var description = arguments;
    return function (constructor) {
        markModel('EntityIcon', description, constructor['name']);
    };
}
function InputFile(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputFile', description, target.constructor.name, property);
    };
}
function InputIcon(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputIcon', description, target.constructor.name, property);
    };
}
function ForeignKey(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('ForeignKey', description, target.constructor.name, property);
    };
}
function InputColor(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputColor', description, target.constructor.name, property);
    };
}
function EngText(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('EngText', description, target.constructor.name, property);
    };
}
function Embedded(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Embedded', description, target.constructor.name, property);
    };
}
function Nullable(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Nullable', description, target.constructor.name, property);
    };
}
function SelectControl(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('SelectControl', description, target.constructor.name, property);
    };
}
function ControlImage(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('ControlImage', description, target.constructor.name, property);
    };
}
function DateFormat(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('DateFormat', description, target.constructor.name, property);
    };
}
function Details(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Details', description, target.constructor.name, property);
    };
}
function HelpMessage(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('HelpMessage', description, target.constructor.name, property);
    };
}
function Match(expr, text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Match', description, target.constructor.name, property);
    };
}
function UrlValidation(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('UrlValidation', description, target.constructor.name, property);
    };
}
function InputImageAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('UrlValidation', description, target.constructor.name, property);
    };
}
function Select(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Select', description, target.constructor.name, property);
    };
}
function Day(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Day', description, target.constructor.name, property);
    };
}
//TODO
function InputBinaryAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputBinaryAttribute', description, target.constructor.name, property);
    };
}
function InputMonthAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputMonthAttribute', description, target.constructor.name, property);
    };
}
function InputPasswordAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputPasswordAttribute', description, target.constructor.name, property);
    };
}
function InputPhoneAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputPhoneAttribute', description, target.constructor.name, property);
    };
}
function Rus(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Rus', description, target.constructor.name, property);
    };
}
function Eng(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Eng', description, target.constructor.name, property);
    };
}
function InputUrlAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputUrlAttribute', description, target.constructor.name, property);
    };
}
function Week(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Week', description, target.constructor.name, property);
    };
}
function Year(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Year', description, target.constructor.name, property);
    };
}
function Required(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Required', description, target.constructor.name, property);
    };
}
function BindProperty(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('BindProperty', description, target.constructor.name, property);
    };
}
/**
 * @param text Сообщение в случае отрицательной првоверки
 */
function NotNullNotEmpty(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('NotNullNotEmpty', description, target.constructor.name, property);
    };
}
function NotMapped(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('NotMapped', description, target.constructor.name, property);
    };
}
function NotInput(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('NotInput', description, target.constructor.name, property);
    };
}
/**
 * Идентификатор не вводится пользователем, поэтому устанавливается метка для скрытия элемента отображения и ввода
 * @param text
 */
function Key(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Key', description, target.constructor.name, property);
    };
}
function RusTextAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('RusTextAttribute', description, target.constructor.name, property);
    };
}
function InputDateTimeAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputDateTimeAttribute', description, target.constructor.name, property);
    };
}
function InputDateAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputDateAttribute', description, target.constructor.name, property);
    };
}
function RequiredAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('RequiredAttribute', description, target.constructor.name, property);
    };
}
function NotMappedAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('NotMappedAttribute', description, target.constructor.name, property);
    };
}
function BindPropertyAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('BindPropertyAttribute', description, target.constructor.name, property);
    };
}
function TextLengthAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('TextLengthAttribute', description, target.constructor.name, property);
    };
}
function InputMultilineTextAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputMultilineTextAttribute', description, target.constructor.name, property);
    };
}
function LabelAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('LabelAttribute', description, target.constructor.name, property);
    };
}
function NotNullNotEmptyAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('NotNullNotEmptyAttribute', description, target.constructor.name, property);
    };
}
function KeyAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('KeyAttribute', description, target.constructor.name, property);
    };
}
function CollectionType(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('CollectionType', description, target.constructor.name, property);
    };
}
function Label(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Label', description, target.constructor.name, property);
    };
}
function Icon(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Icon', description, target.constructor.name, property);
    };
}
function InputHiddenAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputHiddenAttribute', description, target.constructor.name, property);
    };
}
function Help(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Help', description, target.constructor.name, property);
    };
}
function Format(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Format', description, target.constructor.name, property);
    };
}
function InputEmailAttribute(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputEmailAttribute', description, target.constructor.name, property);
    };
}
function Len(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Len', description, target.constructor.name, property);
    };
}
function QR(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('QR', description, target.constructor.name, property);
    };
}
function InputType(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputType', description, target.constructor.name, property);
    };
}
function Editable(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('Editable', description, target.constructor.name, property);
    };
}
function RusText(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('RusText', description, target.constructor.name, property);
    };
}
function InputDate(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputDate', description, target.constructor.name, property);
    };
}
function InputMonth(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputMonth', description, target.constructor.name, property);
    };
}
function InputWeek(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputWeek', description, target.constructor.name, property);
    };
}
function InputYear(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputYear', description, target.constructor.name, property);
    };
}
function InputDateTime(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputDateTime', description, target.constructor.name, property);
    };
}
function TextLength(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('TextLength', description, target.constructor.name, property);
    };
}
function InputMultilineText(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputMultilineText', description, target.constructor.name, property);
    };
}
function InputHidden(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputHidden', description, target.constructor.name, property);
    };
}
function InputEmail(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputEmail', description, target.constructor.name, property);
    };
}
function InputImage(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputImage', description, target.constructor.name, property);
    };
}
//TODO
function InputBinary(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputBinary', description, target.constructor.name, property);
    };
}
function InputPassword(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputPassword', description, target.constructor.name, property);
    };
}
function InputPhone(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputPhone', description, target.constructor.name, property);
    };
}
function InputUrl(text) {
    var description = arguments;
    return function (target, property) {
        markProperty('InputUrl', description, target.constructor.name, property);
    };
}
//# sourceMappingURL=asp-types.const.js.map