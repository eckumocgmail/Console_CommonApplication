var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, EntityLabel, Label, InputHidden } from './../asp-types.const';
let Settings = class Settings {
    constructor() {
        this.ID = 0;
        this.type = 'ApplicationModel.DataModel.Settings';
    }
};
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Settings.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Settings.prototype, "type", void 0);
Settings = __decorate([
    EntityLabel('Настройки')
], Settings);
export { Settings };
