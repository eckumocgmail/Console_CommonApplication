var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, NotMapped, SelectControl, EntityLabel, HelpMessage, Label, InputHidden, InputIcon, NotNullNotEmpty, RusText } from './../asp-types.const';
let MessageAttribute = class MessageAttribute {
    constructor() {
        this.Name = null;
        this.IsSystem = false;
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
        this.type = 'MessageAttribute';
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
__decorate([
    InputHidden("True")
], MessageAttribute.prototype, "type", void 0);
MessageAttribute = __decorate([
    EntityLabel('Атрибут сообщения')
], MessageAttribute);
export { MessageAttribute };
