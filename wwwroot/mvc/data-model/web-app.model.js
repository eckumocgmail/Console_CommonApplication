var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { EntityLabel, Label, InputHidden, NotNullNotEmpty, Key } from './../asp-types.const';
let WebApp = class WebApp {
    constructor() {
        this.Name = null;
        this.URL = null;
        this.Hash = null;
        this.LastActive = 0;
        this.IsActive = false;
        this.SecretKey = null;
        this.ID = 0;
        this.type = 'ApplicationDb.Entities.WebApp';
    }
};
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Не указано наименование сервиса')
], WebApp.prototype, "Name", void 0);
__decorate([
    Label('URL-адрес'),
    NotNullNotEmpty('Не указан URL-адрес')
], WebApp.prototype, "URL", void 0);
__decorate([
    Label('Последнее посещение')
], WebApp.prototype, "LastActive", void 0);
__decorate([
    Label('Онлайн')
], WebApp.prototype, "IsActive", void 0);
__decorate([
    Label('Секретный ключ')
], WebApp.prototype, "SecretKey", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], WebApp.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], WebApp.prototype, "type", void 0);
WebApp = __decorate([
    EntityLabel('Приложение')
], WebApp);
export { WebApp };
