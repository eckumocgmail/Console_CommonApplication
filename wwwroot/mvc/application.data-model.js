var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
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
var Calendar = /** @class */ (function () {
    function Calendar() {
        this.Day = 0;
        this.Week = 0;
        this.Month = 0;
        this.Quarter = 0;
        this.Year = 0;
        this.Timestamp = 0;
        this.ID = 0;
    }
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
    return Calendar;
}());
var Group = /** @class */ (function () {
    function Group() {
        this.Name = null;
        this.People = null;
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Group.prototype, "ID", void 0);
    return Group;
}());
var GroupMessage = /** @class */ (function () {
    function GroupMessage() {
        this.GroupID = 0;
        this.Group = null;
        this.FromUser = null;
        this.ToUser = null;
        this.Subject = null;
        this.Created = new Date();
        this.Text = null;
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], GroupMessage.prototype, "ID", void 0);
    GroupMessage = __decorate([
        EntityLabel('Сообщения в группе')
    ], GroupMessage);
    return GroupMessage;
}());
var ImageResource = /** @class */ (function () {
    function ImageResource() {
        this.Name = null;
        this.Mime = null;
        this.Data = null;
        this.Created = new Date();
        this.ID = 0;
    }
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
    return ImageResource;
}());
var LoginFact = /** @class */ (function () {
    function LoginFact() {
        this.UserID = 0;
        this.User = null;
        this.Created = new Date();
        this.CalendarID = 0;
        this.Calendar = null;
        this.ID = 0;
    }
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
    return LoginFact;
}());
var Resource = /** @class */ (function () {
    function Resource() {
        this.Name = null;
        this.Mime = null;
        this.Data = null;
        this.Created = new Date();
        this.ID = 0;
    }
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
    return Resource;
}());
var User = /** @class */ (function () {
    function User() {
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
        this.LastActiveTime = new Date();
        this.IsActive = null;
        this.SecretKey = null;
        this.ID = 0;
    }
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
        Label('Последнее посещение')
    ], User.prototype, "LastActiveTime", void 0);
    __decorate([
        Label('Онлайн')
    ], User.prototype, "IsActive", void 0);
    __decorate([
        Label('Секретный ключ')
    ], User.prototype, "SecretKey", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], User.prototype, "ID", void 0);
    User = __decorate([
        Table('Users')
    ], User);
    return User;
}());
var UserGroups = /** @class */ (function () {
    function UserGroups() {
        this.GroupID = 0;
        this.UserID = 0;
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], UserGroups.prototype, "ID", void 0);
    return UserGroups;
}());
var Account = /** @class */ (function () {
    function Account() {
        this.Email = null;
        this.Activated = null;
        this.ActivationKey = null;
        this.Hash = null;
        this.RFID = null;
        this.ID = 0;
    }
    __decorate([
        InputEmail('Электронный адрес задан некорректно'),
        Label('Электронный адрес'),
        NotNullNotEmpty('Не указан электронный адрес'),
        Icon('email'),
        UniqValidation('Этот адрес электронной почты уже зарегистрирован')
    ], Account.prototype, "Email", void 0);
    __decorate([
        InputDate('Необходимо ввести дату'),
        InputHidden('True'),
        NotInput('Свойство Activated не вводится пользователем, оно устанавливается системой после ввода ключа активации'),
        Column('')
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
    return Account;
}());
var Message = /** @class */ (function () {
    function Message() {
        this.FromUser = null;
        this.ToUser = null;
        this.Subject = null;
        this.Created = new Date();
        this.Text = null;
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Message.prototype, "ID", void 0);
    return Message;
}());
var Person = /** @class */ (function () {
    function Person() {
        this.SurName = null;
        this.FirstName = null;
        this.LastName = null;
        this.Birthday = null;
        this.Tel = null;
        this.Data = null;
        this.ID = 0;
    }
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
        InputDate('Необходимо ввести дату'),
        NotNullNotEmpty('Не указана дата рождения пользователя'),
        Icon('person'),
        Column('')
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
        Icon('add_a_photo'),
        NotMapped('')
    ], Person.prototype, "Data", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Person.prototype, "ID", void 0);
    Person = __decorate([
        EntityLabel('Личные данные')
    ], Person);
    return Person;
}());
var Settings = /** @class */ (function () {
    function Settings() {
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Settings.prototype, "ID", void 0);
    return Settings;
}());
var BusinessFunction = /** @class */ (function () {
    function BusinessFunction() {
        this.Name = null;
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], BusinessFunction.prototype, "ID", void 0);
    return BusinessFunction;
}());
var FunctionSkills = /** @class */ (function () {
    function FunctionSkills() {
        this.PositionFunctionID = 0;
        this.SkillID = 0;
        this.PositionFunction = null;
        this.Skill = null;
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], FunctionSkills.prototype, "ID", void 0);
    return FunctionSkills;
}());
var PositionFunction = /** @class */ (function () {
    function PositionFunction() {
        this.PositionID = 0;
        this.FunctionSkills = null;
        this.Name = null;
        this.Description = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
    __decorate([
        NotMapped('')
    ], PositionFunction.prototype, "Item", void 0);
    __decorate([
        NotMapped('')
    ], PositionFunction.prototype, "Value", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], PositionFunction.prototype, "ID", void 0);
    return PositionFunction;
}());
var SalaryReport = /** @class */ (function () {
    function SalaryReport() {
        this.Department = null;
        this.DepartmentID = 0;
        this.BeginDate = new Date();
        this.GranularityID = 0;
        this.Cost = null;
        this.ID = 0;
    }
    __decorate([
        SelectDictionary('Department,DepartmentName')
    ], SalaryReport.prototype, "DepartmentID", void 0);
    __decorate([
        Label('Начало периода')
    ], SalaryReport.prototype, "BeginDate", void 0);
    __decorate([
        InputNumber('Фонд оплаты труда')
    ], SalaryReport.prototype, "Cost", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], SalaryReport.prototype, "ID", void 0);
    return SalaryReport;
}());
var TariffRate = /** @class */ (function () {
    function TariffRate() {
        this.PositionID = 0;
        this.Position = null;
        this.Param = null;
        this.Name = null;
        this.Description = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
    __decorate([
        SelectDictionary('Position,PositionName')
    ], TariffRate.prototype, "PositionID", void 0);
    __decorate([
        IsPositiveNumber('Значение должно быть больше нуля')
    ], TariffRate.prototype, "Param", void 0);
    __decorate([
        NotMapped('')
    ], TariffRate.prototype, "Item", void 0);
    __decorate([
        NotMapped('')
    ], TariffRate.prototype, "Value", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], TariffRate.prototype, "ID", void 0);
    TariffRate = __decorate([
        EntityLabel('Коэффициенты трудового стажа')
    ], TariffRate);
    return TariffRate;
}());
var TimeSheet = /** @class */ (function () {
    function TimeSheet() {
        this.BeginTime = new Date();
        this.EndTime = new Date();
        this.EmployeeID = 0;
        this.Employee = null;
        this.Task = null;
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], TimeSheet.prototype, "ID", void 0);
    return TimeSheet;
}());
var GroupsBusinessFunctions = /** @class */ (function () {
    function GroupsBusinessFunctions() {
        this.GroupID = 0;
        this.Group = null;
        this.BusinessFunctionID = 0;
        this.BusinessFunction = null;
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], GroupsBusinessFunctions.prototype, "ID", void 0);
    GroupsBusinessFunctions = __decorate([
        SystemEntity(''),
        EntityLabel('Функции рабочей группы')
    ], GroupsBusinessFunctions);
    return GroupsBusinessFunctions;
}());
var Skill = /** @class */ (function () {
    function Skill() {
        this.Name = null;
        this.Description = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
    __decorate([
        NotMapped('')
    ], Skill.prototype, "Item", void 0);
    __decorate([
        NotMapped('')
    ], Skill.prototype, "Value", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Skill.prototype, "ID", void 0);
    Skill = __decorate([
        EntityLabel('Профеccиональные навыки')
    ], Skill);
    return Skill;
}());
var Department = /** @class */ (function () {
    function Department() {
        this.DepartmentName = null;
        this.Employees = null;
        this.ID = 0;
    }
    __decorate([
        Required(''),
        StringLength('80'),
        Label('Наименование подразделеня'),
        RusText('Пишите на русском языке')
    ], Department.prototype, "DepartmentName", void 0);
    __decorate([
        Label('Сотрудники')
    ], Department.prototype, "Employees", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Department.prototype, "ID", void 0);
    Department = __decorate([
        Table('Department'),
        EntityLabel('Подразделение'),
        SearchTerms('DepartmentName')
    ], Department);
    return Department;
}());
var Employee = /** @class */ (function () {
    function Employee() {
        this.SurName = null;
        this.FirstName = null;
        this.LastName = null;
        this.Birthday = new Date();
        this.Tel = null;
        this.DepartmentID = 0;
        this.Department = null;
        this.PositionID = 0;
        this.Position = null;
        this.Expiriences = null;
        this.Name = null;
        this.Description = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
    __decorate([
        Required(''),
        MaxLength('40'),
        Label('Фамилия сотрудника'),
        RusText('Фамилию нужно записывать исп. кириллицу')
    ], Employee.prototype, "SurName", void 0);
    __decorate([
        Required(''),
        MaxLength('40'),
        Label('Имя'),
        RusText('Имя нужно записывать исп. кириллицу')
    ], Employee.prototype, "FirstName", void 0);
    __decorate([
        Required(''),
        MaxLength('40'),
        Label('Отчество'),
        RusText('Отчество нужно записывать исп. кириллицу')
    ], Employee.prototype, "LastName", void 0);
    __decorate([
        Required(''),
        MaxLength('40'),
        Column(''),
        Label('Дата рождения')
    ], Employee.prototype, "Birthday", void 0);
    __decorate([
        Required(''),
        MaxLength('40'),
        Label('Номер телефона'),
        InputPhone('')
    ], Employee.prototype, "Tel", void 0);
    __decorate([
        Label('Подразделение'),
        SelectDictionary('Department,DepartmentName')
    ], Employee.prototype, "DepartmentID", void 0);
    __decorate([
        Label('Подразделение')
    ], Employee.prototype, "Department", void 0);
    __decorate([
        Label('Должность'),
        SelectDictionary('Position,PositionName')
    ], Employee.prototype, "PositionID", void 0);
    __decorate([
        Label('Должность')
    ], Employee.prototype, "Position", void 0);
    __decorate([
        NotMapped('')
    ], Employee.prototype, "Item", void 0);
    __decorate([
        NotMapped('')
    ], Employee.prototype, "Value", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Employee.prototype, "ID", void 0);
    Employee = __decorate([
        EntityLabel('Сотрудник')
    ], Employee);
    return Employee;
}());
var EmployeeExpirience = /** @class */ (function () {
    function EmployeeExpirience() {
        this.EmployeeID = 0;
        this.Employee = null;
        this.SkillID = 0;
        this.Skill = null;
        this.Begin = new Date();
        this.Granularity = 0;
        this.Created = new Date();
        this.CalendarID = 0;
        this.Calendar = null;
        this.ID = 0;
    }
    __decorate([
        SelectDictionary('Skill,Name')
    ], EmployeeExpirience.prototype, "SkillID", void 0);
    __decorate([
        Column('')
    ], EmployeeExpirience.prototype, "Begin", void 0);
    __decorate([
        NotNullNotEmpty('Необходимо указать дату'),
        InputDateTime('')
    ], EmployeeExpirience.prototype, "Created", void 0);
    __decorate([
        Label('Календарь')
    ], EmployeeExpirience.prototype, "CalendarID", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], EmployeeExpirience.prototype, "ID", void 0);
    EmployeeExpirience = __decorate([
        EntityLabel('Опыт работы сотрудника')
    ], EmployeeExpirience);
    return EmployeeExpirience;
}());
var Position = /** @class */ (function () {
    function Position() {
        this.PositionName = null;
        this.PositionFunctions = null;
        this.ID = 0;
    }
    __decorate([
        Required(''),
        StringLength('80')
    ], Position.prototype, "PositionName", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Position.prototype, "ID", void 0);
    Position = __decorate([
        Table('Position'),
        SearchTerms('PositionName')
    ], Position);
    return Position;
}());
var Rate = /** @class */ (function () {
    function Rate() {
        this.PositionID = 0;
        this.Position = null;
        this.RateActivatedDate = new Date();
        this.RateSize = 0;
        this.ID = 0;
    }
    __decorate([
        Column('')
    ], Rate.prototype, "RateActivatedDate", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Rate.prototype, "ID", void 0);
    Rate = __decorate([
        Table('Rate')
    ], Rate);
    return Rate;
}());
var Staff = /** @class */ (function () {
    function Staff() {
        this.DepartmentID = 0;
        this.Department = null;
        this.PositionID = 0;
        this.Position = null;
        this.StaffActivatedDate = new Date();
        this.CountOfEmployees = 0;
        this.ID = 0;
    }
    __decorate([
        SelectDictionary('Department,DepartmentName')
    ], Staff.prototype, "DepartmentID", void 0);
    __decorate([
        SelectDictionary('Position,PositionName')
    ], Staff.prototype, "PositionID", void 0);
    __decorate([
        Column('')
    ], Staff.prototype, "StaffActivatedDate", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Staff.prototype, "ID", void 0);
    Staff = __decorate([
        Table('Staff'),
        EntityLabel('Штатное расписание')
    ], Staff);
    return Staff;
}());
var MessageAttribute = /** @class */ (function () {
    function MessageAttribute() {
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
    return MessageAttribute;
}());
var MessageProperty = /** @class */ (function () {
    function MessageProperty() {
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
    return MessageProperty;
}());
var MessageProtocol = /** @class */ (function () {
    function MessageProtocol() {
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
        this.Description = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
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
        NotMapped('')
    ], MessageProtocol.prototype, "Item", void 0);
    __decorate([
        NotMapped('')
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
    return MessageProtocol;
}());
var BusinessDatasource = /** @class */ (function () {
    function BusinessDatasource() {
        this.ConnectionString = null;
        this.ID = 0;
    }
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], BusinessDatasource.prototype, "ID", void 0);
    return BusinessDatasource;
}());
var Role = /** @class */ (function () {
    function Role() {
        this.Code = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Description = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
    }
    __decorate([
        Label('Корневой каталог'),
        InputHidden('True'),
        NotInput('')
    ], Role.prototype, "ParentID", void 0);
    __decorate([
        InputHidden('True'),
        NotInput(''),
        JsonIgnore('')
    ], Role.prototype, "Parent", void 0);
    __decorate([
        NotMapped('')
    ], Role.prototype, "Item", void 0);
    __decorate([
        NotMapped('')
    ], Role.prototype, "Value", void 0);
    __decorate([
        Key(''),
        Label('Идентификатор'),
        InputHidden('True')
    ], Role.prototype, "ID", void 0);
    return Role;
}());
