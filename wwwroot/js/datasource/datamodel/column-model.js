var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
class ColumnModel {
    constructor() {
        this.name = '';
        this.type = 'string';
        this.primary = false;
        this.incremental = false;
        this.unique = false;
        this.nullable = false;
        this.defaults = '';
    }
}
__decorate([
    validators.required(true)
], ColumnModel.prototype, "name", void 0);
__decorate([
    controlTypes.selectbox(Object.getOwnPropertyNames(dataTypes))
], ColumnModel.prototype, "type", void 0);
__decorate([
    inputTypes.text()
], ColumnModel.prototype, "description", void 0);
__decorate([
    annotations.hint("Имя свойства")
], ColumnModel.prototype, "defaults", void 0);
