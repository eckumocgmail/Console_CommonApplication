var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, type, IsCollection, ForeignProperty, EntityLabel, Label, InputHidden, Navigation } from './../asp-types.const';
let GroupMessage = class GroupMessage {
    constructor() {
        this.GroupID = 0;
        this.Group = null;
        this.FromUser = null;
        this.ToUser = null;
        this.Subject = null;
        this.Created = new Date();
        this.Text = null;
        this.ID = 0;
        this.type = 'ApplicationDb.Entities.GroupMessage';
    }
};
__decorate([
    ForeignProperty('GroupID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('GroupID')
], GroupMessage.prototype, "Group", void 0);
__decorate([
    ForeignProperty('FromUserID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('FromUserID')
], GroupMessage.prototype, "FromUser", void 0);
__decorate([
    ForeignProperty('ToUserID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ToUserID')
], GroupMessage.prototype, "ToUser", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], GroupMessage.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], GroupMessage.prototype, "type", void 0);
GroupMessage = __decorate([
    EntityLabel('Сообщения в группе')
], GroupMessage);
export { GroupMessage };
