var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Label, InputHidden, Key } from './../asp-types.const';
export class ValidationModel {
    constructor() {
        this.ValidationName = null;
        this.JavaScript = null;
        this.ID = 0;
        this.type = 'NetCoreConstructorAngular.Areas.DevFace.Model.ValidationModel';
    }
}
__decorate([
    Key(''),
    Label('Идентификатор')
], ValidationModel.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], ValidationModel.prototype, "type", void 0);
