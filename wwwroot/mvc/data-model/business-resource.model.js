var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { type, Navigation, IsCollection, ForeignProperty, EntityLabel, Label, InputHidden, RusText, NotNullNotEmpty, UniqValidation, SearchTerms, NotMapped, Key } from './../asp-types.const';
let BusinessResource = class BusinessResource {
    constructor() {
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'BusinessResource';
    }
};
__decorate([
    Label('Корневой каталог'),
    InputHidden('True')
], BusinessResource.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    ForeignProperty('ParentID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ParentID')
], BusinessResource.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessResource.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessResource.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessResource.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], BusinessResource.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], BusinessResource.prototype, "type", void 0);
BusinessResource = __decorate([
    EntityLabel('Ресурсы предприятия'),
    SearchTerms('Name')
], BusinessResource);
export { BusinessResource };
