var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { type, Navigation, IsCollection, ForeignProperty, EntityLabel, Label, InputDateTime, InputHidden, NotNullNotEmpty, InputFile, Key } from './../asp-types.const';
let FileResource = class FileResource {
    constructor() {
        this.CatalogID = 0;
        this.Catalog = null;
        this.Mime = null;
        this.Name = null;
        this.Data = null;
        this.Changed = new Date();
        this.ID = 0;
        this.type = 'ApplicationCommon.CommonResources.FileResource';
    }
};
__decorate([
    Label('Каталог')
], FileResource.prototype, "CatalogID", void 0);
__decorate([
    ForeignProperty('CatalogID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('CatalogID')
], FileResource.prototype, "Catalog", void 0);
__decorate([
    NotNullNotEmpty('Необходимо ввести задать тип ресурса (MimeType)')
], FileResource.prototype, "Mime", void 0);
__decorate([
    NotNullNotEmpty('Необходимо указать наименование ресурса')
], FileResource.prototype, "Name", void 0);
__decorate([
    InputFile('*.*'),
    NotNullNotEmpty('Необходимо ввести бинарные данные ресурса')
], FileResource.prototype, "Data", void 0);
__decorate([
    InputDateTime(''),
    NotNullNotEmpty('Необходимо указать время создания ресурса')
], FileResource.prototype, "Changed", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], FileResource.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], FileResource.prototype, "type", void 0);
FileResource = __decorate([
    EntityLabel('Файловый ресурс')
], FileResource);
export { FileResource };
