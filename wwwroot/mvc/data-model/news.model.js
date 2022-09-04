var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { type, Navigation, IsCollection, ForeignProperty, EntityLabel, Label, InputDateTime, InputHidden, InputMultilineText, InputUrl, NotNullNotEmpty, Key } from './../asp-types.const';
let News = class News {
    constructor() {
        this.Title = null;
        this.Time = new Date();
        this.ImageID = null;
        this.Image = null;
        this.Href = null;
        this.Description = null;
        this.ID = 0;
        this.type = 'ApplicationDb.Entities.News';
    }
};
__decorate([
    Label('Заголовок'),
    NotNullNotEmpty('Необходимо указать заголовок сообщения')
], News.prototype, "Title", void 0);
__decorate([
    Label('Время'),
    InputDateTime('')
], News.prototype, "Time", void 0);
__decorate([
    Label('Изображение')
], News.prototype, "ImageID", void 0);
__decorate([
    ForeignProperty('ImageID'),
    IsCollection('False'),
    type('NetCoreConstructorAngular.Data.DataConverter.Models.MyNavigationOptions'),
    Navigation('ImageID')
], News.prototype, "Image", void 0);
__decorate([
    Label('URL'),
    InputUrl('Значение не является URL адресом ресурса')
], News.prototype, "Href", void 0);
__decorate([
    Label('Описание'),
    NotNullNotEmpty('Необходимо ввести описание'),
    InputMultilineText('')
], News.prototype, "Description", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], News.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], News.prototype, "type", void 0);
News = __decorate([
    EntityLabel('Сооьщение об изменениях')
], News);
export { News };
