var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
if (!window['input'])
    throw new Error('Не определён контекст ввода input');
function InverseProperty(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InverseProperty', description, target.constructor.name, property);
    };
}
function JsonIgnore(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('UniqValidation', description, target.constructor.name, property);
    };
}
function UniqValidation(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('UniqValidation', description, target.constructor.name, property);
    };
}
function ManyToMany(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputCustom', description, target.constructor.name, property);
    };
}
Label;
function Combobox(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputCustom', description, target.constructor.name, property);
    };
}
function InputCustom(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputCustom', description, target.constructor.name, property);
    };
}
function InputDuration(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputDuration', description, target.constructor.name, property);
    };
}
function InputPostalCode(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputPostalCode', description, target.constructor.name, property);
    };
}
function InputXml(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputXml', description, target.constructor.name, property);
    };
}
function markProperty(annotation, args, type, property) {
    let input = window['input'];
    if (!input[type]) {
        input[type] = {};
    }
    if (!input[type][property]) {
        input[type][property] = {};
    }
    input[type][property][annotation] = args;
}
if (!window['spec']) {
    throw new Error('spec not defined');
}
function markModel(annotation, args, type) {
    const spec = window['spec'];
    if (!spec[type]) {
        spec[type] = {};
    }
    spec[type][annotation] = args;
}
function SystemEntity(expr, text) {
    const description = arguments;
    return function (constructor) {
        markModel('SystemEntity', description, constructor['name']);
    };
}
function Index(expr, text) {
    const description = arguments;
    return function (constructor) {
        markModel('Index', description, constructor['name']);
    };
}
function DataType(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('DataType', description, target.constructor.name, property);
    };
}
function SelectDictionary(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('SelectDataDictionary', description, target.constructor.name, property);
    };
}
function Navigation(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Navigation', description, target.constructor.name, property);
    };
}
function ForeignProperty(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('propertyName', description, target.constructor.name, property);
    };
}
function IsCollection(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('isCollection', description, target.constructor.name, property);
    };
}
function SearchTerms(fields) {
    const description = arguments;
    return function (constructor) {
        markModel('TextSearch', description, constructor['name']);
    };
}
function TextSearch(fields) {
    const description = arguments;
    return function (constructor) {
        markModel('TextSearch', description, constructor['name']);
    };
}
function EntityLabel(expr, text) {
    const description = arguments;
    return function (constructor) {
        markModel('EntityLabel', description, constructor['name']);
    };
}
function EntityIcon(expr, text) {
    const description = arguments;
    return function (constructor) {
        markModel('EntityIcon', description, constructor['name']);
    };
}
function InputFile(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputFile', description, target.constructor.name, property);
    };
}
function InputIcon(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputIcon', description, target.constructor.name, property);
    };
}
function ForeignKey(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('ForeignKey', description, target.constructor.name, property);
    };
}
function InputColor(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputColor', description, target.constructor.name, property);
    };
}
function EngText(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('EngText', description, target.constructor.name, property);
    };
}
function Embedded(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Embedded', description, target.constructor.name, property);
    };
}
function Nullable(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Nullable', description, target.constructor.name, property);
    };
}
function SelectControl(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('SelectControl', description, target.constructor.name, property);
    };
}
function ControlImage(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('ControlImage', description, target.constructor.name, property);
    };
}
function DateFormat(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('DateFormat', description, target.constructor.name, property);
    };
}
function Details(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Details', description, target.constructor.name, property);
    };
}
function Description(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Details', description, target.constructor.name, property);
    };
}
function HelpMessage(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('HelpMessage', description, target.constructor.name, property);
    };
}
function Match(expr, text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Match', description, target.constructor.name, property);
    };
}
function UrlValidation(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('UrlValidation', description, target.constructor.name, property);
    };
}
function InputImageAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('UrlValidation', description, target.constructor.name, property);
    };
}
function Select(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Select', description, target.constructor.name, property);
    };
}
function Day(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Day', description, target.constructor.name, property);
    };
}
function InputBinaryAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputBinaryAttribute', description, target.constructor.name, property);
    };
}
function InputMonthAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputMonthAttribute', description, target.constructor.name, property);
    };
}
function InputPasswordAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputPasswordAttribute', description, target.constructor.name, property);
    };
}
function InputPhoneAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputPhoneAttribute', description, target.constructor.name, property);
    };
}
function Rus(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Rus', description, target.constructor.name, property);
    };
}
function Eng(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Eng', description, target.constructor.name, property);
    };
}
function InputUrlAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputUrlAttribute', description, target.constructor.name, property);
    };
}
function Week(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Week', description, target.constructor.name, property);
    };
}
function Year(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Year', description, target.constructor.name, property);
    };
}
function Required(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Required', description, target.constructor.name, property);
    };
}
function BindProperty(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('BindProperty', description, target.constructor.name, property);
    };
}
function NotNullNotEmpty(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('NotNullNotEmpty', description, target.constructor.name, property);
    };
}
function NotMapped(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('NotMapped', description, target.constructor.name, property);
    };
}
function NotInput(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('NotInput', description, target.constructor.name, property);
    };
}
function Key(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Key', description, target.constructor.name, property);
    };
}
function RusTextAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('RusTextAttribute', description, target.constructor.name, property);
    };
}
function InputDateTimeAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputDateTimeAttribute', description, target.constructor.name, property);
    };
}
function InputDateAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputDateAttribute', description, target.constructor.name, property);
    };
}
function RequiredAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('RequiredAttribute', description, target.constructor.name, property);
    };
}
function NotMappedAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('NotMappedAttribute', description, target.constructor.name, property);
    };
}
function BindPropertyAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('BindPropertyAttribute', description, target.constructor.name, property);
    };
}
function TextLengthAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('TextLengthAttribute', description, target.constructor.name, property);
    };
}
function InputMultilineTextAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputMultilineTextAttribute', description, target.constructor.name, property);
    };
}
function LabelAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('LabelAttribute', description, target.constructor.name, property);
    };
}
function NotNullNotEmptyAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('NotNullNotEmptyAttribute', description, target.constructor.name, property);
    };
}
function KeyAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('KeyAttribute', description, target.constructor.name, property);
    };
}
function CollectionType(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('CollectionType', description, target.constructor.name, property);
    };
}
function Label(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Label', description, target.constructor.name, property);
    };
}
function Icon(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Icon', description, target.constructor.name, property);
    };
}
function InputHiddenAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputHiddenAttribute', description, target.constructor.name, property);
    };
}
function Help(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Help', description, target.constructor.name, property);
    };
}
function Format(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Format', description, target.constructor.name, property);
    };
}
function InputEmailAttribute(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputEmailAttribute', description, target.constructor.name, property);
    };
}
function Len(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Len', description, target.constructor.name, property);
    };
}
function QR(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('QR', description, target.constructor.name, property);
    };
}
function InputType(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputType', description, target.constructor.name, property);
    };
}
function Editable(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('Editable', description, target.constructor.name, property);
    };
}
function RusText(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('RusText', description, target.constructor.name, property);
    };
}
function InputDate(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputDate', description, target.constructor.name, property);
    };
}
function InputMonth(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputMonth', description, target.constructor.name, property);
    };
}
function InputWeek(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputWeek', description, target.constructor.name, property);
    };
}
function InputYear(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputYear', description, target.constructor.name, property);
    };
}
function InputDateTime(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputDateTime', description, target.constructor.name, property);
    };
}
function TextLength(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('TextLength', description, target.constructor.name, property);
    };
}
function InputMultilineText(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputMultilineText', description, target.constructor.name, property);
    };
}
function InputHidden(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputHidden', description, target.constructor.name, property);
    };
}
function InputEmail(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputEmail', description, target.constructor.name, property);
    };
}
function InputImage(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputImage', description, target.constructor.name, property);
    };
}
function InputBinary(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputBinary', description, target.constructor.name, property);
    };
}
function InputPassword(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputPassword', description, target.constructor.name, property);
    };
}
function InputPhone(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputPhone', description, target.constructor.name, property);
    };
}
function InputUrl(text) {
    const description = arguments;
    return function (target, property) {
        markProperty('InputUrl', description, target.constructor.name, property);
    };
}
let FileCatalog = class FileCatalog {
    constructor() {
        this.Files = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], FileCatalog.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], FileCatalog.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], FileCatalog.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], FileCatalog.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], FileCatalog.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], FileCatalog.prototype, "ID", void 0);
FileCatalog = __decorate([
    EntityLabel('Файловый каталог'),
    SystemEntity('')
], FileCatalog);
let FileResource = class FileResource {
    constructor() {
        this.CatalogID = 0;
        this.Catalog = null;
        this.Mime = null;
        this.Name = null;
        this.Data = null;
        this.Changed = new Date();
        this.ID = 0;
    }
};
__decorate([
    Label('Каталог')
], FileResource.prototype, "CatalogID", void 0);
__decorate([
    NotNullNotEmpty('Необходимо ввести задать тип ресурса (MimeType)')
], FileResource.prototype, "Mime", void 0);
__decorate([
    NotNullNotEmpty('Необходимо указать наименование ресурса')
], FileResource.prototype, "Name", void 0);
__decorate([
    InputFile('*.*'),
    NotNullNotEmpty('Необходимо ввести бинарные данные ресурса')
], FileResource.prototype, "Data", void 0);
__decorate([
    InputDateTime(''),
    NotNullNotEmpty('Необходимо указать время создания ресурса')
], FileResource.prototype, "Changed", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], FileResource.prototype, "ID", void 0);
FileResource = __decorate([
    EntityLabel('Файловый ресурс'),
    SystemEntity('')
], FileResource);
let Account = class Account {
    constructor() {
        this.Email = null;
        this.Activated = null;
        this.ActivationKey = null;
        this.Hash = null;
        this.RFID = null;
        this.ID = 0;
    }
};
__decorate([
    InputEmail('Электронный адрес задан некорректно'),
    Label('Электронный адрес'),
    NotNullNotEmpty('Не указан электронный адрес'),
    Icon('email'),
    UniqValidation('Этот адрес электронной почты уже зарегистрирован')
], Account.prototype, "Email", void 0);
__decorate([
    InputDate(''),
    InputHidden('True'),
    NotInput('Свойство Activated не вводится пользователем, оно устанавливается системой после ввода ключа активации')
], Account.prototype, "Activated", void 0);
__decorate([
    InputHidden('True'),
    NotInput('Свойство ActivationKey не вводится пользователем, оно устанавливается системой перед созданием сообщения на эл. почту пользорвателя с инструкциями по активации')
], Account.prototype, "ActivationKey", void 0);
__decorate([
    Label('Хэш-ключ'),
    InputHidden('True'),
    NotInput('Свойство Hash не вводится пользователем, оно устанавливается системой при регистрации')
], Account.prototype, "Hash", void 0);
__decorate([
    Label('Радио метка'),
    InputHidden('True'),
    NotInput('Свойство RFID не вводится пользователем, оно устанавливается системой при регистрации служебного билета')
], Account.prototype, "RFID", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Account.prototype, "ID", void 0);
Account = __decorate([
    EntityLabel('Учетная запись'),
    EntityIcon('account_box')
], Account);
let Calendar = class Calendar {
    constructor() {
        this.Day = 0;
        this.Week = 0;
        this.Month = 0;
        this.Quarter = 0;
        this.Year = 0;
        this.Timestamp = 0;
        this.ID = 0;
    }
};
__decorate([
    Label('День')
], Calendar.prototype, "Day", void 0);
__decorate([
    Label('Неделя')
], Calendar.prototype, "Week", void 0);
__decorate([
    Label('Месяц')
], Calendar.prototype, "Month", void 0);
__decorate([
    Label('Квартал')
], Calendar.prototype, "Quarter", void 0);
__decorate([
    Label('Год')
], Calendar.prototype, "Year", void 0);
__decorate([
    Label('Unix-время')
], Calendar.prototype, "Timestamp", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Calendar.prototype, "ID", void 0);
Calendar = __decorate([
    EntityLabel('Дата предоставления отчёта'),
    SystemEntity('')
], Calendar);
let Group = class Group {
    constructor() {
        this.Name = null;
        this.Description = null;
        this.BusinessProcessID = null;
        this.BusinessProcess = null;
        this.People = null;
        this.MessageProtocols = null;
        this.BusinessFunctions = null;
        this.GroupsBusinessFunctions = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование')
], Group.prototype, "Name", void 0);
__decorate([
    Label('Подробнее'),
    NotNullNotEmpty('Необходимо ввести подробное описание'),
    InputMultilineText(''),
    TextLength('Длина описания должна составлять меньше чем 512 символов')
], Group.prototype, "Description", void 0);
__decorate([
    Label('Бизнес-процесс'),
    Combobox('BusinessProcess,Name')
], Group.prototype, "BusinessProcessID", void 0);
__decorate([
    Label('Бизнес-процесс')
], Group.prototype, "BusinessProcess", void 0);
__decorate([
    NotMapped(''),
    JsonIgnore('')
], Group.prototype, "People", void 0);
__decorate([
    NotMapped(''),
    JsonIgnore('')
], Group.prototype, "MessageProtocols", void 0);
__decorate([
    NotMapped(''),
    JsonIgnore('')
], Group.prototype, "BusinessFunctions", void 0);
__decorate([
    ManyToMany('BusinessFunctions'),
    JsonIgnore('')
], Group.prototype, "GroupsBusinessFunctions", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], Group.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], Group.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Group.prototype, "ID", void 0);
Group = __decorate([
    EntityLabel('Группа пользователей')
], Group);
let GroupMessage = class GroupMessage {
    constructor() {
        this.GroupID = 0;
        this.Group = null;
        this.FromUser = null;
        this.ToUser = null;
        this.Created = new Date();
        this.Subject = null;
        this.Text = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Источник'),
    NotInput('Свойство FromUser не вводится пользователем, оно устанавливается системой перед созданием сообщения на эл. почту пользорвателя с инструкциями по активации'),
    JsonIgnore('')
], GroupMessage.prototype, "FromUser", void 0);
__decorate([
    JsonIgnore('')
], GroupMessage.prototype, "ToUser", void 0);
__decorate([
    Label('Создано'),
    InputHidden('')
], GroupMessage.prototype, "Created", void 0);
__decorate([
    Label('Тема'),
    NotNullNotEmpty('Необходимо указать тему сообщения')
], GroupMessage.prototype, "Subject", void 0);
__decorate([
    Label('Текст сообщения'),
    InputMultilineText(''),
    NotNullNotEmpty('Необходимо ввести текст сообщения')
], GroupMessage.prototype, "Text", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], GroupMessage.prototype, "ID", void 0);
GroupMessage = __decorate([
    EntityLabel('Сообщения в группе')
], GroupMessage);
let ImageResource = class ImageResource {
    constructor() {
        this.Name = null;
        this.Mime = null;
        this.Data = null;
        this.Created = new Date();
        this.ID = 0;
    }
};
__decorate([
    NotNullNotEmpty('Необходимо указать наименование ресурса'),
    Label('Наименование')
], ImageResource.prototype, "Name", void 0);
__decorate([
    Label('Тип файла'),
    InputHidden(''),
    NotNullNotEmpty('Необходимо ввести задать тип ресурса (MimeType)')
], ImageResource.prototype, "Mime", void 0);
__decorate([
    Label('Файл'),
    InputFile('')
], ImageResource.prototype, "Data", void 0);
__decorate([
    Label('Дата загрузки'),
    InputDateTime(''),
    NotInput(''),
    NotNullNotEmpty('Необходимо указать время создания ресурса')
], ImageResource.prototype, "Created", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], ImageResource.prototype, "ID", void 0);
ImageResource = __decorate([
    SystemEntity('')
], ImageResource);
let LoginFact = class LoginFact {
    constructor() {
        this.UserID = 0;
        this.User = null;
        this.Created = new Date();
        this.CalendarID = 0;
        this.Calendar = null;
        this.ID = 0;
    }
};
__decorate([
    JsonIgnore('')
], LoginFact.prototype, "User", void 0);
__decorate([
    NotNullNotEmpty('Необходимо указать дату'),
    InputDateTime('')
], LoginFact.prototype, "Created", void 0);
__decorate([
    Label('Календарь')
], LoginFact.prototype, "CalendarID", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], LoginFact.prototype, "ID", void 0);
LoginFact = __decorate([
    EntityLabel('Факт авторизации пользователя'),
    SystemEntity('')
], LoginFact);
let Message = class Message {
    constructor() {
        this.FromUser = null;
        this.ToUser = null;
        this.Created = new Date();
        this.Subject = null;
        this.Text = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Источник'),
    NotInput('Свойство FromUser не вводится пользователем, оно устанавливается системой перед созданием сообщения на эл. почту пользорвателя с инструкциями по активации'),
    JsonIgnore('')
], Message.prototype, "FromUser", void 0);
__decorate([
    JsonIgnore('')
], Message.prototype, "ToUser", void 0);
__decorate([
    Label('Создано'),
    InputHidden('')
], Message.prototype, "Created", void 0);
__decorate([
    Label('Тема'),
    NotNullNotEmpty('Необходимо указать тему сообщения')
], Message.prototype, "Subject", void 0);
__decorate([
    Label('Текст сообщения'),
    InputMultilineText(''),
    NotNullNotEmpty('Необходимо ввести текст сообщения')
], Message.prototype, "Text", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Message.prototype, "ID", void 0);
Message = __decorate([
    EntityLabel('Сообщение'),
    EntityIcon('drafts'),
    SearchTerms('Subject,Text')
], Message);
let News = class News {
    constructor() {
        this.Title = null;
        this.Time = new Date();
        this.ImageID = null;
        this.Image = null;
        this.Href = null;
        this.Description = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Заголовок'),
    NotNullNotEmpty('Необходимо указать заголовок сообщения')
], News.prototype, "Title", void 0);
__decorate([
    Label('Время'),
    InputDateTime('')
], News.prototype, "Time", void 0);
__decorate([
    Label('Изображение')
], News.prototype, "ImageID", void 0);
__decorate([
    Label('URL'),
    InputUrl('Значение не является URL адресом ресурса')
], News.prototype, "Href", void 0);
__decorate([
    Label('Описание'),
    NotNullNotEmpty('Необходимо ввести описание'),
    InputMultilineText('')
], News.prototype, "Description", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], News.prototype, "ID", void 0);
News = __decorate([
    EntityLabel('Сообщение об изменениях')
], News);
let Person = class Person {
    constructor() {
        this.SurName = null;
        this.FirstName = null;
        this.LastName = null;
        this.Birthday = null;
        this.Tel = null;
        this.Data = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Фамилия'),
    NotNullNotEmpty('Не указана фамилия пользователя'),
    RusText('Записывайте фамилию кирилицей'),
    Icon('person')
], Person.prototype, "SurName", void 0);
__decorate([
    Label('Имя'),
    NotNullNotEmpty('Не указано имя пользователя'),
    RusText('Записывайте имя кирилицей'),
    Icon('person')
], Person.prototype, "FirstName", void 0);
__decorate([
    Label('Отчество'),
    NotNullNotEmpty('Не указано отчество пользователя'),
    RusText('Записывайте отчество кирилицей'),
    Icon('person')
], Person.prototype, "LastName", void 0);
__decorate([
    Label('Дата рождения'),
    InputDate(''),
    NotNullNotEmpty('Не указана дата рождения пользователя'),
    Icon('person')
], Person.prototype, "Birthday", void 0);
__decorate([
    InputPhone('Номер телефона указан неверно'),
    UniqValidation('Этот номер телефона уже зарегистрирован'),
    Label('Номер телефона'),
    NotNullNotEmpty('Не указана номер телефона'),
    Icon('phone')
], Person.prototype, "Tel", void 0);
__decorate([
    Label('Файл'),
    InputImage(''),
    Icon('add_a_photo')
], Person.prototype, "Data", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Person.prototype, "ID", void 0);
Person = __decorate([
    EntityLabel('Личные данные'),
    Index('System.Collections.ObjectModel.ReadOnlyCollection`1[System.Reflection.CustomAttributeTypedArgument]')
], Person);
let Resource = class Resource {
    constructor() {
        this.Name = null;
        this.Mime = null;
        this.Data = null;
        this.Created = new Date();
        this.ID = 0;
    }
};
__decorate([
    NotNullNotEmpty('Необходимо указать наименование ресурса'),
    Label('Наименование')
], Resource.prototype, "Name", void 0);
__decorate([
    Label('Тип файла'),
    SelectControl('{{GetMimeTypes()}}'),
    NotNullNotEmpty('Необходимо ввести задать тип ресурса (MimeType)')
], Resource.prototype, "Mime", void 0);
__decorate([
    Label('Файл'),
    InputFile('')
], Resource.prototype, "Data", void 0);
__decorate([
    Label('Дата загрузки'),
    InputDateTime(''),
    NotInput(''),
    NotNullNotEmpty('Необходимо указать время создания ресурса')
], Resource.prototype, "Created", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Resource.prototype, "ID", void 0);
Resource = __decorate([
    EntityLabel('Бинарные данные')
], Resource);
let Settings = class Settings {
    constructor() {
        this.ColorTheme = null;
        this.PublicOperations = null;
        this.SendNewsToEmail = null;
        this.ShowHelp = null;
        this.EvaluateMe = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Цветовая схема'),
    SelectControl('Light,Dark,Blue,Modern')
], Settings.prototype, "ColorTheme", void 0);
__decorate([
    Label('Публиковать мои действия')
], Settings.prototype, "PublicOperations", void 0);
__decorate([
    Label('Передавать сообщения на электронную почту')
], Settings.prototype, "SendNewsToEmail", void 0);
__decorate([
    Label('Показывать справочную информацию в интерактивном режиме')
], Settings.prototype, "ShowHelp", void 0);
__decorate([
    Label('Оценивать мои способности работы с системой')
], Settings.prototype, "EvaluateMe", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Settings.prototype, "ID", void 0);
Settings = __decorate([
    EntityLabel('Настройки')
], Settings);
let User = class User {
    constructor() {
        this.AccountID = 0;
        this.Account = null;
        this.RoleID = 0;
        this.Role = null;
        this.SettingsID = 0;
        this.Settings = null;
        this.PersonID = 0;
        this.Person = null;
        this.Groups = null;
        this.UserGroupsID = 0;
        this.UserGroups = null;
        this.LoginCount = 0;
        this.Inbox = null;
        this.Outbox = null;
        this.BusinessFunctions = null;
        this.LastActive = 0;
        this.IsActive = null;
        this.SecretKey = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Учетная запись')
], User.prototype, "AccountID", void 0);
__decorate([
    InputHidden('True'),
    Label('Учетная запись')
], User.prototype, "Account", void 0);
__decorate([
    Label('Роль')
], User.prototype, "RoleID", void 0);
__decorate([
    InputHidden('True'),
    Label('Роль')
], User.prototype, "Role", void 0);
__decorate([
    Label('Настройки')
], User.prototype, "SettingsID", void 0);
__decorate([
    Label('Настройки')
], User.prototype, "Settings", void 0);
__decorate([
    Label('Личная инф.')
], User.prototype, "PersonID", void 0);
__decorate([
    Label('Личная инф.')
], User.prototype, "Person", void 0);
__decorate([
    NotMapped(''),
    Label('Группы')
], User.prototype, "Groups", void 0);
__decorate([
    Label('Группы'),
    NotMapped('')
], User.prototype, "UserGroupsID", void 0);
__decorate([
    Label('Группы'),
    ManyToMany('Groups'),
    InputHidden('True')
], User.prototype, "UserGroups", void 0);
__decorate([
    Label('Кол-во посещений')
], User.prototype, "LoginCount", void 0);
__decorate([
    Label('Входящие сообщения'),
    InverseProperty('ToUser')
], User.prototype, "Inbox", void 0);
__decorate([
    Label('Исходящие сообщения'),
    InverseProperty('FromUser')
], User.prototype, "Outbox", void 0);
__decorate([
    NotMapped(''),
    Label('Выполняемые функции')
], User.prototype, "BusinessFunctions", void 0);
__decorate([
    Label('Последнее посещение')
], User.prototype, "LastActive", void 0);
__decorate([
    Label('Онлайн')
], User.prototype, "IsActive", void 0);
__decorate([
    Label('Секретный ключ')
], User.prototype, "SecretKey", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], User.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], User.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], User.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], User.prototype, "ID", void 0);
User = __decorate([
    EntityLabel('Пользователь'),
    EntityIcon('build')
], User);
let UserGroups = class UserGroups {
    constructor() {
        this.UserID = 0;
        this.User = null;
        this.GroupID = 0;
        this.Group = null;
        this.ID = 0;
    }
};
__decorate([
    JsonIgnore('')
], UserGroups.prototype, "User", void 0);
__decorate([
    JsonIgnore('')
], UserGroups.prototype, "Group", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], UserGroups.prototype, "ID", void 0);
UserGroups = __decorate([
    EntityLabel('Много ко многим')
], UserGroups);
let BusinessDataset = class BusinessDataset {
    constructor() {
        this.DatasourceID = 0;
        this.Datasource = null;
        this.Expression = null;
        this.Description = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Источник данных'),
    NotNullNotEmpty('Необходимо выбрать источник'),
    Combobox('BusinessDatasource,Name')
], BusinessDataset.prototype, "DatasourceID", void 0);
__decorate([
    Label('Источник данных')
], BusinessDataset.prototype, "Datasource", void 0);
__decorate([
    Label('Скрипт'),
    NotNullNotEmpty('Введите скрипт'),
    InputMultilineText('')
], BusinessDataset.prototype, "Expression", void 0);
__decorate([
    Label('Краткое описание'),
    NotNullNotEmpty('Необходимо ввести краткое описание'),
    InputMultilineText('')
], BusinessDataset.prototype, "Description", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], BusinessDataset.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], BusinessDataset.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessDataset.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessDataset.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessDataset.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], BusinessDataset.prototype, "ID", void 0);
BusinessDataset = __decorate([
    EntityLabel('Набор данных'),
    SearchTerms('Name,Description')
], BusinessDataset);
let BusinessDatasource = class BusinessDatasource {
    constructor() {
        this.ConnectionString = null;
        this.Datasets = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Строка подключения'),
    NotNullNotEmpty('Необходимо задать строку подключения')
], BusinessDatasource.prototype, "ConnectionString", void 0);
__decorate([
    Label('Наборы данных')
], BusinessDatasource.prototype, "Datasets", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], BusinessDatasource.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], BusinessDatasource.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessDatasource.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessDatasource.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessDatasource.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], BusinessDatasource.prototype, "ID", void 0);
BusinessDatasource = __decorate([
    EntityLabel('Источник данных')
], BusinessDatasource);
let BusinessFunction = class BusinessFunction {
    constructor() {
        this.SubFunctions = null;
        this.GroupsBusinessFunctions = null;
        this.BusinessResource = null;
        this.BusinessLogic = null;
        this.Input = null;
        this.Output = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    NotMapped('')
], BusinessFunction.prototype, "SubFunctions", void 0);
__decorate([
    ManyToMany('BusinessFunctions')
], BusinessFunction.prototype, "GroupsBusinessFunctions", void 0);
__decorate([
    InverseProperty('To')
], BusinessFunction.prototype, "Input", void 0);
__decorate([
    InverseProperty('From')
], BusinessFunction.prototype, "Output", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], BusinessFunction.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], BusinessFunction.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessFunction.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessFunction.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessFunction.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], BusinessFunction.prototype, "ID", void 0);
BusinessFunction = __decorate([
    EntityLabel('Бизнес функция'),
    SearchTerms('Name')
], BusinessFunction);
let BusinessIndicator = class BusinessIndicator {
    constructor() {
        this.Unit = null;
        this.Description = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Единицы измерения'),
    NotNullNotEmpty('Укажите единицы измерения')
], BusinessIndicator.prototype, "Unit", void 0);
__decorate([
    NotNullNotEmpty('Наобходимо ввести описание')
], BusinessIndicator.prototype, "Description", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], BusinessIndicator.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], BusinessIndicator.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessIndicator.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessIndicator.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessIndicator.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], BusinessIndicator.prototype, "ID", void 0);
BusinessIndicator = __decorate([
    EntityLabel('Бизнес показатель'),
    SearchTerms('Name')
], BusinessIndicator);
class BusinessLogic {
    constructor() {
        this.Input = null;
        this.Output = null;
        this.Error = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
}
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], BusinessLogic.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], BusinessLogic.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessLogic.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessLogic.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessLogic.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], BusinessLogic.prototype, "ID", void 0);
let BusinessReport = class BusinessReport {
    constructor() {
        this.BusinessDatasources = null;
        this.BusinessDatasets = null;
        this.Description = null;
        this.Xml = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Источники данных')
], BusinessReport.prototype, "BusinessDatasources", void 0);
__decorate([
    Label('Наборы данных'),
    NotMapped('')
], BusinessReport.prototype, "BusinessDatasets", void 0);
__decorate([
    NotNullNotEmpty('Необходимо описать функиональность'),
    InputMultilineText(''),
    Label('Описание отчёта')
], BusinessReport.prototype, "Description", void 0);
__decorate([
    NotNullNotEmpty('Необходимо загрузить XML-документ'),
    InputMultilineText(''),
    Label('XML схема отчёта')
], BusinessReport.prototype, "Xml", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], BusinessReport.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], BusinessReport.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessReport.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessReport.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessReport.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], BusinessReport.prototype, "ID", void 0);
BusinessReport = __decorate([
    EntityLabel('Отчёт'),
    SearchTerms('Name,Description')
], BusinessReport);
let BusinessResource = class BusinessResource {
    constructor() {
        this.DevID = null;
        this.Dev = null;
        this.ParentID = null;
        this.Parent = null;
        this.Description = null;
        this.Code = null;
        this.LastActive = 0;
        this.IsActive = null;
        this.SecretKey = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Разработчик'),
    InputHidden('True')
], BusinessResource.prototype, "DevID", void 0);
__decorate([
    Label('Разработчик')
], BusinessResource.prototype, "Dev", void 0);
__decorate([
    Label('Корневой каталог'),
    SelectDictionary('GetType().Name,Name')
], BusinessResource.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True')
], BusinessResource.prototype, "Parent", void 0);
__decorate([
    Label('Подробнее')
], BusinessResource.prototype, "Description", void 0);
__decorate([
    NotNullNotEmpty(''),
    UniqValidation('')
], BusinessResource.prototype, "Code", void 0);
__decorate([
    Label('Последнее посещение')
], BusinessResource.prototype, "LastActive", void 0);
__decorate([
    Label('Онлайн')
], BusinessResource.prototype, "IsActive", void 0);
__decorate([
    Label('Секретный ключ')
], BusinessResource.prototype, "SecretKey", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessResource.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessResource.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessResource.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], BusinessResource.prototype, "ID", void 0);
BusinessResource = __decorate([
    EntityLabel('Ресурсы предприятия'),
    SearchTerms('Name')
], BusinessResource);
let Dev = class Dev {
    constructor() {
        this.UserID = 0;
        this.User = null;
        this.BusinessProcesses = null;
        this.BusinessReports = null;
        this.BusinessDatasources = null;
        this.BusinessDatasets = null;
        this.BusinessIndicators = null;
        this.BusinessFunctions = null;
        this.BusinessResources = null;
        this.MessageProtocols = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Бизнес процессы')
], Dev.prototype, "BusinessProcesses", void 0);
__decorate([
    Label('Отчёты')
], Dev.prototype, "BusinessReports", void 0);
__decorate([
    Label('Источники данных')
], Dev.prototype, "BusinessDatasources", void 0);
__decorate([
    Label('Наборы данных')
], Dev.prototype, "BusinessDatasets", void 0);
__decorate([
    Label('Показатели')
], Dev.prototype, "BusinessIndicators", void 0);
__decorate([
    Label('Бизнес функции')
], Dev.prototype, "BusinessFunctions", void 0);
__decorate([
    Label('Ресурсы')
], Dev.prototype, "BusinessResources", void 0);
__decorate([
    Label('Информационные характеристики сообщений')
], Dev.prototype, "MessageProtocols", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Dev.prototype, "ID", void 0);
Dev = __decorate([
    EntityLabel('Разработчик')
], Dev);
let Granularity = class Granularity {
    constructor() {
        this.Code = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    UniqValidation('')
], Granularity.prototype, "Code", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], Granularity.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], Granularity.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], Granularity.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Granularity.prototype, "ID", void 0);
Granularity = __decorate([
    EntityLabel('Паралельность(периодичность)'),
    SystemEntity('')
], Granularity);
let GroupsBusinessFunctions = class GroupsBusinessFunctions {
    constructor() {
        this.GroupID = 0;
        this.Group = null;
        this.BusinessFunctionID = 0;
        this.BusinessFunction = null;
        this.ID = 0;
    }
};
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], GroupsBusinessFunctions.prototype, "ID", void 0);
GroupsBusinessFunctions = __decorate([
    SystemEntity(''),
    EntityLabel('Функции рабочей группы')
], GroupsBusinessFunctions);
let MessageAttribute = class MessageAttribute {
    constructor() {
        this.Name = null;
        this.IsSystem = null;
        this.Icon = null;
        this.CSharpType = null;
        this.SQLType = null;
        this.InputType = null;
        this.Description = null;
        this.Validations = null;
        this.SqlServerDataType = null;
        this.MySQLDataType = null;
        this.PostgreDataType = null;
        this.OracleDataType = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    RusText('Используйте символы русского алфавита')
], MessageAttribute.prototype, "Name", void 0);
__decorate([
    Label('Системный'),
    HelpMessage('С системными данными работают информационные ресурсы, пользователи не учавствуют в обмене')
], MessageAttribute.prototype, "IsSystem", void 0);
__decorate([
    Label('Иконка'),
    InputIcon('')
], MessageAttribute.prototype, "Icon", void 0);
__decorate([
    Label('Тип данных'),
    NotNullNotEmpty('Обязатльно укажите тип данных'),
    SelectControl('{{GetDataTypes()}}')
], MessageAttribute.prototype, "CSharpType", void 0);
__decorate([
    Label('Тип данных'),
    NotNullNotEmpty('Обязатльно укажите тип данных')
], MessageAttribute.prototype, "SQLType", void 0);
__decorate([
    Label('Тип ввода'),
    NotNullNotEmpty('Обязатльно укажите тип ввода'),
    SelectControl('{{GetInputTypes()}}')
], MessageAttribute.prototype, "InputType", void 0);
__decorate([
    Label('Краткое описание'),
    NotNullNotEmpty('Кратко опишите атррибут')
], MessageAttribute.prototype, "Description", void 0);
__decorate([
    Label('Методы проверки'),
    NotMapped('')
], MessageAttribute.prototype, "Validations", void 0);
__decorate([
    Label('Тип данных SQL Server')
], MessageAttribute.prototype, "SqlServerDataType", void 0);
__decorate([
    Label('Тип данных MySQL')
], MessageAttribute.prototype, "MySQLDataType", void 0);
__decorate([
    Label('Тип данных Postgre')
], MessageAttribute.prototype, "PostgreDataType", void 0);
__decorate([
    Label('Тип данных Oracle')
], MessageAttribute.prototype, "OracleDataType", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], MessageAttribute.prototype, "ID", void 0);
MessageAttribute = __decorate([
    EntityLabel('Атрибут сообщения')
], MessageAttribute);
let MessageProperty = class MessageProperty {
    constructor() {
        this.Label = null;
        this.Name = null;
        this.Order = 0;
        this.Help = null;
        this.Required = null;
        this.Unique = null;
        this.Index = null;
        this.AttributeID = 0;
        this.Attribute = null;
        this.MessageProtocolID = 0;
        this.MessageProtocol = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Надпись'),
    HelpMessage('Надпись располагается рядом над элементом ввода'),
    NotNullNotEmpty('Введите '),
    RusText('Используйте русскую кирилицу для надписи поля ввода')
], MessageProperty.prototype, "Label", void 0);
__decorate([
    Label('Имя в наборе данных'),
    HelpMessage('Имя свойства сообщения является идентификатором в наборе данных'),
    NotNullNotEmpty('Введите имя свойства сообщения'),
    EngText('Используйте латиницу для имени свойства сообщения')
], MessageProperty.prototype, "Name", void 0);
__decorate([
    Label('Порядковый номер')
], MessageProperty.prototype, "Order", void 0);
__decorate([
    Label('Подпись'),
    RusText('Используйте русскую кирилицу')
], MessageProperty.prototype, "Help", void 0);
__decorate([
    Label('Обязательное')
], MessageProperty.prototype, "Required", void 0);
__decorate([
    Label('Уникальное')
], MessageProperty.prototype, "Unique", void 0);
__decorate([
    Label('Создание индекса'),
    HelpMessage('Индексируемые поля являются ключами для поиска')
], MessageProperty.prototype, "Index", void 0);
__decorate([
    Label('Атрибут'),
    SelectDictionary('MessageAttribute,Name'),
    NotNullNotEmpty('Необходимо выбрать атрибут')
], MessageProperty.prototype, "AttributeID", void 0);
__decorate([
    Label('Атрибут'),
    JsonIgnore(''),
    NotInput('Свойство Attribute не вводится пользователем, оно устанавливается в соответвии с внешним ключом AttributeID')
], MessageProperty.prototype, "Attribute", void 0);
__decorate([
    Label('Протокол сообщения'),
    SelectDictionary('MessageProtocol,Name'),
    NotNullNotEmpty('Необходимо выбрать протокол')
], MessageProperty.prototype, "MessageProtocolID", void 0);
__decorate([
    Label('Протокол сообщения'),
    JsonIgnore(''),
    NotInput('Свойство MessageProtocol не вводится пользователем, оно устанавливается в соответвии с внешним ключом MessageProtocolID')
], MessageProperty.prototype, "MessageProtocol", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], MessageProperty.prototype, "ID", void 0);
MessageProperty = __decorate([
    EntityIcon('message'),
    EntityLabel('Поле сообщения')
], MessageProperty);
let MessageProtocol = class MessageProtocol {
    constructor() {
        this.FromID = null;
        this.From = null;
        this.FromBusinessFunctionID = null;
        this.ToBusinessFunctionID = null;
        this.ToID = null;
        this.To = null;
        this.Properties = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Источник'),
    SelectDictionary('BusinessFunction,Name')
], MessageProtocol.prototype, "FromID", void 0);
__decorate([
    Label('Приёмник'),
    SelectDictionary('BusinessFunction,Name')
], MessageProtocol.prototype, "ToID", void 0);
__decorate([
    Label('Свойства')
], MessageProtocol.prototype, "Properties", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], MessageProtocol.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], MessageProtocol.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], MessageProtocol.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], MessageProtocol.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], MessageProtocol.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], MessageProtocol.prototype, "ID", void 0);
MessageProtocol = __decorate([
    EntityIcon('message'),
    EntityLabel('Информационные характеристики сообщений')
], MessageProtocol);
let DataInput = class DataInput {
    constructor() {
        this.IndicatorID = 0;
        this.DatasetID = 0;
        this.GranularityID = 0;
        this.TargetObjectID = 0;
        this.BeginDate = new Date();
        this.ID = 0;
    }
};
__decorate([
    NotNullNotEmpty('Показатель является обязательным полем'),
    Combobox('BusinessIndicator,Name')
], DataInput.prototype, "IndicatorID", void 0);
__decorate([
    NotNullNotEmpty('Набор данных является обязательным полем'),
    Combobox('BusinessDataset,Name')
], DataInput.prototype, "DatasetID", void 0);
__decorate([
    NotNullNotEmpty('Периодичность является обязательным полем'),
    SelectDictionary('Granularity,Name')
], DataInput.prototype, "GranularityID", void 0);
__decorate([
    NotNullNotEmpty('Обьект мониторинга является обязательным полем'),
    SelectDictionary('TargetObject,Name')
], DataInput.prototype, "TargetObjectID", void 0);
__decorate([
    NotNullNotEmpty('Начало периода'),
    InputDate('')
], DataInput.prototype, "BeginDate", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], DataInput.prototype, "ID", void 0);
DataInput = __decorate([
    EntityLabel('Входящая информация')
], DataInput);
let DatasetIndicators = class DatasetIndicators {
    constructor() {
        this.IsNegative = null;
        this.ID = 0;
    }
};
__decorate([
    Label('Отрицательные черты характера воздействия')
], DatasetIndicators.prototype, "IsNegative", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], DatasetIndicators.prototype, "ID", void 0);
DatasetIndicators = __decorate([
    EntityLabel('Показатели набора данных'),
    SystemEntity('')
], DatasetIndicators);
let TargetObject = class TargetObject {
    constructor() {
        this.TargetObjectDatasets = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
};
__decorate([
    ManyToMany('Datasets')
], TargetObject.prototype, "TargetObjectDatasets", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], TargetObject.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], TargetObject.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], TargetObject.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], TargetObject.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], TargetObject.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], TargetObject.prototype, "ID", void 0);
TargetObject = __decorate([
    EntityLabel('Целевые обьекты оценки')
], TargetObject);
let TargetObjectDatasets = class TargetObjectDatasets {
    constructor() {
        this.TargetObjectID = 0;
        this.DatasetID = 0;
        this.ID = 0;
    }
};
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], TargetObjectDatasets.prototype, "ID", void 0);
TargetObjectDatasets = __decorate([
    EntityLabel('Связанные наборы')
], TargetObjectDatasets);
class BusinessProcess {
    constructor() {
        this.InputID = 0;
        this.Input = null;
        this.OutputID = 0;
        this.Output = null;
        this.BusinessFunctions = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
}
__decorate([
    Combobox('MessageProtocol,Name'),
    NotMapped('')
], BusinessProcess.prototype, "InputID", void 0);
__decorate([
    NotMapped('')
], BusinessProcess.prototype, "Input", void 0);
__decorate([
    NotMapped(''),
    Combobox('MessageProtocol,Name')
], BusinessProcess.prototype, "OutputID", void 0);
__decorate([
    NotMapped('')
], BusinessProcess.prototype, "Output", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True'),
    NotInput('')
], BusinessProcess.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    NotInput(''),
    JsonIgnore('')
], BusinessProcess.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessProcess.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessProcess.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessProcess.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], BusinessProcess.prototype, "ID", void 0);
let ValidationModel = class ValidationModel {
    constructor() {
        this.ValidationName = null;
        this.JavaScript = null;
        this.ID = 0;
    }
};
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], ValidationModel.prototype, "ID", void 0);
ValidationModel = __decorate([
    EntityLabel('Проверка достоверности данных')
], ValidationModel);
