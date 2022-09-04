var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { EntityLabel, Label, InputHidden, RusText, NotNullNotEmpty, UniqValidation, NotMapped, Key } from './../asp-types.const';
let BusinessLogic = class BusinessLogic {
    constructor() {
        this.Name = null;
        this.Item = null;
        this.Value = null;
        this.ID = 0;
        this.type = 'DAL.Business.BusinessLogic';
    }
};
__decorate([
    Label('Наименование'),
    NotNullNotEmpty('Необходимо указать наименование'),
    UniqValidation('Имя должно иметь уникальное значение'),
    RusText('Используйте русский имена')
], BusinessLogic.prototype, "Name", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessLogic.prototype, "Item", void 0);
__decorate([
    NotMapped(''),
    InputHidden('True')
], BusinessLogic.prototype, "Value", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], BusinessLogic.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], BusinessLogic.prototype, "type", void 0);
BusinessLogic = __decorate([
    EntityLabel('Бизнес логика')
], BusinessLogic);
export { BusinessLogic };
