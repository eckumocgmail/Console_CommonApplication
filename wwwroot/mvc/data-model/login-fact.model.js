var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, type, IsCollection, ForeignProperty, JsonIgnore, EntityLabel, Label, SystemEntity, InputHidden, Navigation } from './../asp-types.const';
let LoginFact = class LoginFact {
    constructor() {
        this.UserID = 0;
        this.User = null;
        this.ID = 0;
        this.type = 'ApplicationDb.Entities.LoginFact';
    }
};
__decorate([
    Label('Пользователь')
], LoginFact.prototype, "UserID", void 0);
__decorate([
    JsonIgnore(''),
    ForeignProperty('UserID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('UserID')
], LoginFact.prototype, "User", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], LoginFact.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], LoginFact.prototype, "type", void 0);
LoginFact = __decorate([
    EntityLabel('Событие авторизации'),
    SystemEntity('')
], LoginFact);
export { LoginFact };
