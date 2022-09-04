var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { type, Navigation, IsCollection, ForeignProperty, EntityLabel, Label, InputHidden, RusText, NotNullNotEmpty, UniqValidation, SearchTerms, NotMapped, Key } from './../asp-types.const';
let BusinessIndicator = class BusinessIndicator {
    constructor() {
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'DAL.Business.BusinessIndicator';
    }
};
__decorate([
    Label('Корневой каталог'),
    InputHidden('True')
], BusinessIndicator.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    ForeignProperty('ParentID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ParentID')
], BusinessIndicator.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessIndicator.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessIndicator.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessIndicator.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], BusinessIndicator.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], BusinessIndicator.prototype, "type", void 0);
BusinessIndicator = __decorate([
    EntityLabel('Бизнес показатель'),
    SearchTerms('Name')
], BusinessIndicator);
export { BusinessIndicator };
