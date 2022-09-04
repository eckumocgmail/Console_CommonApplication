var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { type, Navigation, IsCollection, ForeignProperty, EntityLabel, Label, InputHidden, RusText, NotNullNotEmpty, UniqValidation, NotMapped, Key } from './../asp-types.const';
let CLRLibrary = class CLRLibrary {
    constructor() {
        this.LibraryID = 0;
        this.Library = null;
        this.ParentID = null;
        this.Parent = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'ApplicationCommon.CommonServices.CommonResources.CLRLibrary';
    }
};
__decorate([
    ForeignProperty('LibraryID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('LibraryID')
], CLRLibrary.prototype, "Library", void 0);
__decorate([
    Label('Корневой каталог'),
    InputHidden('True')
], CLRLibrary.prototype, "ParentID", void 0);
__decorate([
    InputHidden('True'),
    ForeignProperty('ParentID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ParentID')
], CLRLibrary.prototype, "Parent", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], CLRLibrary.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], CLRLibrary.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], CLRLibrary.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], CLRLibrary.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], CLRLibrary.prototype, "type", void 0);
CLRLibrary = __decorate([
    EntityLabel('Исполняемая библиотека')
], CLRLibrary);
export { CLRLibrary };
