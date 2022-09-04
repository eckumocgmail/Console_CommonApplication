var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, type, IsCollection, ForeignProperty, EntityIcon, EntityLabel, Label, InputHidden, Navigation } from './../asp-types.const';
let Message = class Message {
    constructor() {
        this.FromUser = null;
        this.ToUser = null;
        this.Subject = null;
        this.Created = new Date();
        this.Text = null;
        this.ID = 0;
        this.type = 'ApplicationModel.DataModel.Message';
    }
};
__decorate([
    ForeignProperty('FromUserID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('FromUserID')
], Message.prototype, "FromUser", void 0);
__decorate([
    ForeignProperty('ToUserID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ToUserID')
], Message.prototype, "ToUser", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Message.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Message.prototype, "type", void 0);
Message = __decorate([
    EntityLabel('Сообщение'),
    EntityIcon('message')
], Message);
export { Message };
