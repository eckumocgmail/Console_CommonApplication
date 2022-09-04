var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, NotMapped, Table, type, IsCollection, ForeignProperty, JsonIgnore, EntityLabel, Label, InputHidden, NotNullNotEmpty, RusText, UniqValidation, Navigation, SearchTerms } from './../asp-types.const';
let Department = class Department {
    constructor() {
        this.Employees = [];
        this.Name = null;
        this.Description = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'Managment.DataModel.Department';
    }
};
__decorate([
    Label('Сотрудники'),
    ForeignProperty('EmployeesID'),
    IsCollection('True'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('EmployeesID')
], Department.prototype, "Employees", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], Department.prototype, "Name", void 0);
__decorate([
    Label('Описание'),
    NotNullNotEmpty('Необходимо указать описание')
], Department.prototype, "Description", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True'),
    JsonIgnore('')
], Department.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True'),
    JsonIgnore('')
], Department.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Department.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Department.prototype, "type", void 0);
Department = __decorate([
    Table('Department'),
    EntityLabel('Подразделение'),
    SearchTerms('Name,Description')
], Department);
export { Department };
