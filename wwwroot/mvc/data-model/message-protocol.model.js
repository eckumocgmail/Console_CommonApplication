var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, NotMapped, type, IsCollection, ForeignProperty, JsonIgnore, EntityIcon, EntityLabel, Label, InputHidden, NotNullNotEmpty, RusText, UniqValidation, Navigation, SelectDictionary } from './../asp-types.const';
let MessageProtocol = class MessageProtocol {
    constructor() {
        this.FromID = null;
        this.From = null;
        this.ToID = null;
        this.To = null;
        this.Properties = [];
        this.Name = null;
        this.Description = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'MessageProtocol';
    }
};
__decorate([
    Label('Источник'),
    SelectDictionary('BusinessFunction,Name')
], MessageProtocol.prototype, "FromID", void 0);
__decorate([
    ForeignProperty('FromID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('FromID')
], MessageProtocol.prototype, "From", void 0);
__decorate([
    Label('Приёмник'),
    SelectDictionary('BusinessFunction,Name')
], MessageProtocol.prototype, "ToID", void 0);
__decorate([
    ForeignProperty('ToID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ToID')
], MessageProtocol.prototype, "To", void 0);
__decorate([
    Label('Свойства'),
    ForeignProperty('PropertiesID'),
    IsCollection('True'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('PropertiesID')
], MessageProtocol.prototype, "Properties", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], MessageProtocol.prototype, "Name", void 0);
__decorate([
    Label('Описание'),
    NotNullNotEmpty('Необходимо указать описание')
], MessageProtocol.prototype, "Description", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True'),
    JsonIgnore('')
], MessageProtocol.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True'),
    JsonIgnore('')
], MessageProtocol.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], MessageProtocol.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], MessageProtocol.prototype, "type", void 0);
MessageProtocol = __decorate([
    EntityIcon('message'),
    EntityLabel('Информационные характеристики сообщений')
], MessageProtocol);
export { MessageProtocol };
