var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { type, Navigation, IsCollection, ForeignProperty, EntityLabel, Label, InputHidden, RusText, NotNullNotEmpty, UniqValidation, NotMapped, Key } from './../asp-types.const';
let BusinessProcess = class BusinessProcess {
    constructor() {
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'DAL.Business.BusinessProcess';
    }
};
__decorate([
    Label('Корневой каталог'),
    InputHidden('True')
], BusinessProcess.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    ForeignProperty('ParentID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ParentID')
], BusinessProcess.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessProcess.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessProcess.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessProcess.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], BusinessProcess.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], BusinessProcess.prototype, "type", void 0);
BusinessProcess = __decorate([
    EntityLabel('Бизнес процесс')
], BusinessProcess);
export { BusinessProcess };
