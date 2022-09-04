var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { CollectionType, type, Navigation, IsCollection, ForeignProperty, EntityLabel, Label, InputHidden, RusText, NotNullNotEmpty, UniqValidation, NotMapped, Key } from './../asp-types.const';
let FileCatalog = class FileCatalog {
    constructor() {
        this.Files = [];
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'ApplicationCommon.CommonResources.FileCatalog';
    }
};
__decorate([
    ForeignProperty('FilesID'),
    IsCollection('True'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('FilesID'),
    CollectionType('FileResource')
], FileCatalog.prototype, "Files", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True')
], FileCatalog.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    ForeignProperty('ParentID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ParentID')
], FileCatalog.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], FileCatalog.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], FileCatalog.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], FileCatalog.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], FileCatalog.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], FileCatalog.prototype, "type", void 0);
FileCatalog = __decorate([
    EntityLabel('Файловый каталог')
], FileCatalog);
export { FileCatalog };
