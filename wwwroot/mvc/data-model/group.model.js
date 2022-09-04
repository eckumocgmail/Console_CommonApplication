var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, type, IsCollection, ForeignProperty, EntityLabel, Label, InputHidden, Navigation, SearchTerms } from './../asp-types.const';
let Group = class Group {
    constructor() {
        this.Name = null;
        this.People = [];
        this.ID = 0;
        this.type = 'ApplicationDb.Entities.Group';
    }
};
__decorate([
    ForeignProperty('PeopleID'),
    IsCollection('True'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('PeopleID')
], Group.prototype, "People", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Group.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Group.prototype, "type", void 0);
Group = __decorate([
    EntityLabel('Группа'),
    SearchTerms('Name')
], Group);
export { Group };
