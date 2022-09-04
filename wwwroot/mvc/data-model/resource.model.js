var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, SelectControl, EntityLabel, Label, InputHidden, NotNullNotEmpty, InputFile } from './../asp-types.const';
let Resource = class Resource {
    constructor() {
        this.Name = null;
        this.Mime = null;
        this.Data = null;
        this.ID = 0;
        this.type = 'ApplicationDb.Entities.Resource';
    }
};
__decorate([
    NotNullNotEmpty('Необходимо указать наименование ресурса'),
    Label('Наименование')
], Resource.prototype, "Name", void 0);
__decorate([
    Label('Тип файла'),
    SelectControl('{{GetMimeTypes()}}'),
    NotNullNotEmpty('Необходимо ввести задать тип ресурса (MimeType)')
], Resource.prototype, "Mime", void 0);
__decorate([
    Label('Файл'),
    InputFile('')
], Resource.prototype, "Data", void 0);
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], Resource.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Resource.prototype, "type", void 0);
Resource = __decorate([
    EntityLabel('Бинарные данные')
], Resource);
export { Resource };
