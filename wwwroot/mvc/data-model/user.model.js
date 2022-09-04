var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, NotMapped, Table, type, IsCollection, ForeignProperty, InverseProperty, ManyToMany, EntityIcon, EntityLabel, Label, InputHidden, Navigation } from './../asp-types.const';
let User = class User {
    constructor() {
        this.AccountID = 0;
        this.Account = null;
        this.RoleID = 0;
        this.Role = null;
        this.SettingsID = 0;
        this.Settings = null;
        this.PersonID = 0;
        this.Person = null;
        this.Groups = [];
        this.UserGroupsID = 0;
        this.UserGroups = [];
        this.LoginCount = 0;
        this.Inbox = [];
        this.Outbox = [];
        this.LastActiveTime = new Date();
        this.IsActive = false;
        this.SecretKey = null;
        this.ID = 0;
        this.type = 'ApplicationDb.Entities.User';
    }
};
__decorate([
    Label('Учетная запись')
], User.prototype, "AccountID", void 0);
__decorate([
    InputHidden('True'),
    Label('Учетная запись'),
    ForeignProperty('AccountID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('AccountID')
], User.prototype, "Account", void 0);
__decorate([
    Label('Роль')
], User.prototype, "RoleID", void 0);
__decorate([
    InputHidden('True'),
    Label('Роль'),
    ForeignProperty('RoleID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('RoleID')
], User.prototype, "Role", void 0);
__decorate([
    Label('Настройки')
], User.prototype, "SettingsID", void 0);
__decorate([
    Label('Настройки'),
    ForeignProperty('SettingsID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('SettingsID')
], User.prototype, "Settings", void 0);
__decorate([
    Label('Личная инф.')
], User.prototype, "PersonID", void 0);
__decorate([
    Label('Личная инф.'),
    ForeignProperty('PersonID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('PersonID')
], User.prototype, "Person", void 0);
__decorate([
    NotMapped(''),
    Label('Группы')
], User.prototype, "Groups", void 0);
__decorate([
    Label('Группы'),
    NotMapped('')
], User.prototype, "UserGroupsID", void 0);
__decorate([
    Label('Группы'),
    ManyToMany('Groups'),
    InputHidden('True'),
    ForeignProperty('UserGroupsID'),
    IsCollection('True'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('UserGroupsID')
], User.prototype, "UserGroups", void 0);
__decorate([
    Label('Кол-во посещений')
], User.prototype, "LoginCount", void 0);
__decorate([
    Label('Входящие сообщения'),
    InverseProperty('ToUser'),
    ForeignProperty('InboxID'),
    IsCollection('True'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('InboxID')
], User.prototype, "Inbox", void 0);
__decorate([
    Label('Исходящие сообщения'),
    InverseProperty('FromUser'),
    ForeignProperty('OutboxID'),
    IsCollection('True'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('OutboxID')
], User.prototype, "Outbox", void 0);
__decorate([
    Label('Последнее посещение')
], User.prototype, "LastActiveTime", void 0);
__decorate([
    Label('Онлайн')
], User.prototype, "IsActive", void 0);
__decorate([
    Label('Секретный ключ')
], User.prototype, "SecretKey", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], User.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], User.prototype, "type", void 0);
User = __decorate([
    EntityLabel('Пользователь'),
    EntityIcon('build'),
    Table('Users')
], User);
export { User };
