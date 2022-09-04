var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { EntityLabel, Label, InputHidden, Key } from './../asp-types.const';
let ClientConnection = class ClientConnection {
    constructor() {
        this.IP = null;
        this.Banned = false;
        this.Actions = 0;
        this.ID = 0;
        this.type = 'ApplicationCommon.CommonResources.ClientConnection';
    }
};
__decorate([
    Label('IP адрес')
], ClientConnection.prototype, "IP", void 0);
__decorate([
    Label('Блокировка')
], ClientConnection.prototype, "Banned", void 0);
__decorate([
    Label('КОл-ао нарушений')
], ClientConnection.prototype, "Actions", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], ClientConnection.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], ClientConnection.prototype, "type", void 0);
ClientConnection = __decorate([
    EntityLabel('Статистика сетевых атак')
], ClientConnection);
export { ClientConnection };
