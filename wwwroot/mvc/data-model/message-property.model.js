var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, EntityIcon, EntityLabel, HelpMessage, Label, InputHidden, NotNullNotEmpty, EngText, RusText, SelectDictionary } from './../asp-types.const';
let MessageProperty = class MessageProperty {
    constructor() {
        this.Label = null;
        this.Name = null;
        this.Order = 0;
        this.Help = null;
        this.Required = false;
        this.Unique = false;
        this.Index = false;
        this.AttributeID = 0;
        this.MessageProtocolID = 0;
        this.ID = 0;
        this.type = 'MessageProperty';
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
    Label('Протокол сообщения'),
    SelectDictionary('MessageProtocol,Name'),
    NotNullNotEmpty('Необходимо выбрать протокол')
], MessageProperty.prototype, "MessageProtocolID", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], MessageProperty.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], MessageProperty.prototype, "type", void 0);
MessageProperty = __decorate([
    EntityIcon('message'),
    EntityLabel('Поле сообщения')
], MessageProperty);
export { MessageProperty };
