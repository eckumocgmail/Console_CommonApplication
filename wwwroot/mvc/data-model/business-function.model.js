var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, type, IsCollection, ForeignProperty, InverseProperty, Label, InputHidden, Navigation } from './../asp-types.const';
export class BusinessFunction {
    constructor() {
        this.Name = null;
        this.Input = null;
        this.To = null;
        this.ID = 0;
        this.type = 'BusinessFunction';
    }
}
__decorate([
    InverseProperty('From'),
    ForeignProperty('InputID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('InputID')
], BusinessFunction.prototype, "Input", void 0);
__decorate([
    InverseProperty('To'),
    ForeignProperty('ToID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ToID')
], BusinessFunction.prototype, "To", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], BusinessFunction.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], BusinessFunction.prototype, "type", void 0);
