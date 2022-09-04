var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, Column, type, IsCollection, ForeignProperty, EntityLabel, Label, InputDate, InputHidden, InputNumber, NotNullNotEmpty, Navigation, SelectDataDictionary, SearchTerms } from './../asp-types.const';
let EmployeeExpirience = class EmployeeExpirience {
    constructor() {
        this.EmployeeID = 0;
        this.Employee = null;
        this.SkillID = 0;
        this.Skill = null;
        this.Begin = new Date();
        this.Granularity = 0;
        this.ID = 0;
        this.type = 'Managment.DataModel.EmployeeExpirience';
    }
};
__decorate([
    Label('Сотрудник'),
    SelectDataDictionary('Employee,FirstName')
], EmployeeExpirience.prototype, "EmployeeID", void 0);
__decorate([
    ForeignProperty('EmployeeID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('EmployeeID')
], EmployeeExpirience.prototype, "Employee", void 0);
__decorate([
    Label('Навык'),
    SelectDataDictionary('Skill,Name')
], EmployeeExpirience.prototype, "SkillID", void 0);
__decorate([
    ForeignProperty('SkillID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('SkillID')
], EmployeeExpirience.prototype, "Skill", void 0);
__decorate([
    Column(''),
    Label('Дата'),
    NotNullNotEmpty('Дата не может принимать нулевое значение'),
    InputDate('Необходимо ввести дату')
], EmployeeExpirience.prototype, "Begin", void 0);
__decorate([
    Label('Периодичность'),
    InputNumber(''),
    NotNullNotEmpty('Периодичность не может иметь нулевое значение')
], EmployeeExpirience.prototype, "Granularity", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], EmployeeExpirience.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], EmployeeExpirience.prototype, "type", void 0);
EmployeeExpirience = __decorate([
    EntityLabel('Опыт работы сотрудника'),
    SearchTerms('{{Skill.Name}},{{Employee.Name}}')
], EmployeeExpirience);
export { EmployeeExpirience };
