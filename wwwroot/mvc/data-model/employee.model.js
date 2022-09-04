var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, NotMapped, Column, type, IsCollection, ForeignProperty, Required, MaxLength, JsonIgnore, EntityLabel, Label, InputDate, InputHidden, InputPhone, InputText, RusText, Navigation, SelectDataDictionary, SearchTerms } from './../asp-types.const';
let Employee = class Employee {
    constructor() {
        this.SurName = null;
        this.FirstName = null;
        this.LastName = null;
        this.Birthday = new Date();
        this.Tel = null;
        this.DepartmentID = 0;
        this.Department = null;
        this.PositionID = 0;
        this.Position = null;
        this.Name = null;
        this.Description = null;
        this.Expiriences = [];
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'Managment.DataModel.Employee';
    }
};
__decorate([
    Required(''),
    MaxLength('40'),
    Label('Фамилия сотрудника'),
    RusText('Фамилию нужно записывать исп. кириллицу'),
    InputText('')
], Employee.prototype, "SurName", void 0);
__decorate([
    Required(''),
    MaxLength('40'),
    Label('Имя'),
    RusText('Имя нужно записывать исп. кириллицу'),
    InputText('')
], Employee.prototype, "FirstName", void 0);
__decorate([
    Required(''),
    MaxLength('40'),
    Label('Отчество'),
    RusText('Отчество нужно записывать исп. кириллицу'),
    InputText('')
], Employee.prototype, "LastName", void 0);
__decorate([
    Required(''),
    MaxLength('40'),
    Column(''),
    Label('Дата рождения'),
    InputDate('Необходимо ввести дату')
], Employee.prototype, "Birthday", void 0);
__decorate([
    Required(''),
    MaxLength('40'),
    Label('Номер телефона'),
    InputPhone('')
], Employee.prototype, "Tel", void 0);
__decorate([
    Label('Подразделение'),
    SelectDataDictionary('Department,Name')
], Employee.prototype, "DepartmentID", void 0);
__decorate([
    Label('Подразделение'),
    ForeignProperty('DepartmentID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('DepartmentID')
], Employee.prototype, "Department", void 0);
__decorate([
    Label('Должность'),
    SelectDataDictionary('Position,Name')
], Employee.prototype, "PositionID", void 0);
__decorate([
    Label('Должность'),
    ForeignProperty('PositionID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('PositionID')
], Employee.prototype, "Position", void 0);
__decorate([
    Label('ФИО')
], Employee.prototype, "Name", void 0);
__decorate([
    Label('Резюме')
], Employee.prototype, "Description", void 0);
__decorate([
    ForeignProperty('ExpiriencesID'),
    IsCollection('True'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ExpiriencesID')
], Employee.prototype, "Expiriences", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True'),
    JsonIgnore('')
], Employee.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True'),
    JsonIgnore('')
], Employee.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Employee.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Employee.prototype, "type", void 0);
Employee = __decorate([
    EntityLabel('Сотрудник'),
    SearchTerms('SurName,FirstName,LastName')
], Employee);
export { Employee };
