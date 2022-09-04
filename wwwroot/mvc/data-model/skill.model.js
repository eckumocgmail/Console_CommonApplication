var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, NotMapped, type, IsCollection, ForeignProperty, JsonIgnore, EntityLabel, Label, InputHidden, NotNullNotEmpty, RusText, UniqValidation, Navigation, SearchTerms } from './../asp-types.const';
let Skill = class Skill {
    constructor() {
        this.Expirience = [];
        this.Name = null;
        this.Description = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'Managment.DataModel.DataModelManagment.Skill';
    }
};
__decorate([
    ForeignProperty('ExpirienceID'),
    IsCollection('True'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ExpirienceID')
], Skill.prototype, "Expirience", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], Skill.prototype, "Name", void 0);
__decorate([
    Label('Описание'),
    NotNullNotEmpty('Необходимо указать описание')
], Skill.prototype, "Description", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True'),
    JsonIgnore('')
], Skill.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True'),
    JsonIgnore('')
], Skill.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Skill.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Skill.prototype, "type", void 0);
Skill = __decorate([
    EntityLabel('Профеccиональные навыки'),
    SearchTerms('Name,Description')
], Skill);
export { Skill };
