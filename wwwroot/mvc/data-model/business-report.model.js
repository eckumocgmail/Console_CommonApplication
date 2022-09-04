var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { EntityLabel, Label, InputHidden, InputMultilineText, RusText, NotNullNotEmpty, UniqValidation, SearchTerms, NotMapped, Key } from './../asp-types.const';
let BusinessReport = class BusinessReport {
    constructor() {
        this.Description = null;
        this.Xml = null;
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'DAL.Business.BusinessReport';
    }
};
__decorate([
    NotNullNotEmpty('Необходимо описать функиональность'),
    InputMultilineText(''),
    Label('Описание отчёта')
], BusinessReport.prototype, "Description", void 0);
__decorate([
    NotNullNotEmpty('Необходимо загрузить XML-документ'),
    InputMultilineText(''),
    Label('XML схема отчёта')
], BusinessReport.prototype, "Xml", void 0);
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessReport.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessReport.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessReport.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], BusinessReport.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], BusinessReport.prototype, "type", void 0);
BusinessReport = __decorate([
    EntityLabel('Отчёт'),
    SearchTerms('Name,Description')
], BusinessReport);
export { BusinessReport };
