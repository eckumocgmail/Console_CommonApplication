var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, EntityIcon, EntityLabel, Icon, Label, InputEmail, InputHidden, NotNullNotEmpty, UniqValidation } from './../asp-types.const';
let Account = class Account {
    constructor() {
        this.Email = null;
        this.ID = 0;
        this.type = 'ApplicationModel.DataModel.Account';
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
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Account.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Account.prototype, "type", void 0);
Account = __decorate([
    EntityLabel('Учетная запись'),
    EntityIcon('account_box')
], Account);
export { Account };
