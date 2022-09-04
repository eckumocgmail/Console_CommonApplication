var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Key, EntityLabel, Label, InputHidden } from './../asp-types.const';
let UserGroups = class UserGroups {
    constructor() {
        this.GroupID = 0;
        this.UserID = 0;
        this.ID = 0;
        this.type = 'ApplicationDb.Entities.UserGroups';
    }
};
__decorate([
    Key(''),
    Label('Идентификатор'),
    InputHidden('True')
], UserGroups.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], UserGroups.prototype, "type", void 0);
UserGroups = __decorate([
    EntityLabel('Группы пользователя')
], UserGroups);
export { UserGroups };
