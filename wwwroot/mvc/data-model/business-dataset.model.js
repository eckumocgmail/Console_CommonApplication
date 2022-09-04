var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { type, Navigation, IsCollection, ForeignProperty, EntityLabel, Label, InputHidden, InputMultilineText, NotInput, RusText, NotNullNotEmpty, UniqValidation, SearchTerms, SelectDataDictionary, NotMapped, Key } from './../asp-types.const';
let BusinessDataset = class BusinessDataset {
    constructor() {
        this.DatasourceID = 0;
        this.Datasource = null;
        this.Expression = null;
        this.Description = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'NetCoreConstructorAngular.Data.DataModels.Business.Model.BusinessDataset';
    }
};
__decorate([
    Label('Источник данных'),
    NotNullNotEmpty('Необходимо выбрать источник'),
    SelectDataDictionary('BusinessDatasource,Name')
], BusinessDataset.prototype, "DatasourceID", void 0);
__decorate([
    NotInput(''),
    ForeignProperty('DatasourceID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('DatasourceID')
], BusinessDataset.prototype, "Datasource", void 0);
__decorate([
    Label('Скрипт'),
    NotNullNotEmpty('Введите скрипт'),
    InputMultilineText('')
], BusinessDataset.prototype, "Expression", void 0);
__decorate([
    Label('Краткое описание'),
    NotNullNotEmpty('Необходимо ввести краткое описание'),
    InputMultilineText('')
], BusinessDataset.prototype, "Description", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessDataset.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessDataset.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessDataset.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], BusinessDataset.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], BusinessDataset.prototype, "type", void 0);
BusinessDataset = __decorate([
    EntityLabel('Набор данных'),
    SearchTerms('Name,Description')
], BusinessDataset);
export { BusinessDataset };
