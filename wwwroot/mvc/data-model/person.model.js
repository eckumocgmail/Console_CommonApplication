var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, NotMapped, Column, EntityLabel, Icon, Label, InputDate, InputHidden, InputPhone, InputText, InputImage, NotNullNotEmpty, RusText, UniqValidation, SearchTerms } from './../asp-types.const';
let Person = class Person {
    constructor() {
        this.SurName = null;
        this.FirstName = null;
        this.LastName = null;
        this.Birthday = null;
        this.Tel = null;
        this.Data = null;
        this.ID = 0;
        this.type = 'ApplicationModel.DataModel.Person';
    }
};
__decorate([
    Label('Фамилия'),
    NotNullNotEmpty('Не указана фамилия пользователя'),
    RusText('Записывайте фамилию кирилицей'),
    Icon('person'),
    InputText('')
], Person.prototype, "SurName", void 0);
__decorate([
    Label('Имя'),
    NotNullNotEmpty('Не указано имя пользователя'),
    RusText('Записывайте имя кирилицей'),
    Icon('person'),
    InputText('')
], Person.prototype, "FirstName", void 0);
__decorate([
    Label('Отчество'),
    NotNullNotEmpty('Не указано отчество пользователя'),
    RusText('Записывайте отчество кирилицей'),
    Icon('person'),
    InputText('')
], Person.prototype, "LastName", void 0);
__decorate([
    Label('Дата рождения'),
    InputDate('Необходимо ввести дату'),
    NotNullNotEmpty('Не указана дата рождения пользователя'),
    Icon('person'),
    Column('')
], Person.prototype, "Birthday", void 0);
__decorate([
    InputPhone('Номер телефона указан неверно'),
    UniqValidation('Этот номер телефона уже зарегистрирован'),
    Label('Номер телефона'),
    NotNullNotEmpty('Не указана номер телефона'),
    Icon('phone')
], Person.prototype, "Tel", void 0);
__decorate([
    Label('Файл'),
    InputImage(''),
    Icon('add_a_photo'),
    NotMapped('')
], Person.prototype, "Data", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Person.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Person.prototype, "type", void 0);
Person = __decorate([
    EntityLabel('Личные данные'),
    SearchTerms('Name')
], Person);
export { Person };
