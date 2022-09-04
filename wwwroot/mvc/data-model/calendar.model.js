var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { EntityLabel, Label, InputHidden, Key } from './../asp-types.const';
let Calendar = class Calendar {
    constructor() {
        this.Day = 0;
        this.Week = 0;
        this.Month = 0;
        this.Quarter = 0;
        this.Year = 0;
        this.Timestamp = 0;
        this.ID = 0;
        this.type = 'ApplicationDb.Entities.Calendar';
    }
};
__decorate([
    Label('День')
], Calendar.prototype, "Day", void 0);
__decorate([
    Label('Неделя')
], Calendar.prototype, "Week", void 0);
__decorate([
    Label('Месяц')
], Calendar.prototype, "Month", void 0);
__decorate([
    Label('Квартал')
], Calendar.prototype, "Quarter", void 0);
__decorate([
    Label('Год')
], Calendar.prototype, "Year", void 0);
__decorate([
    Label('Unix-время')
], Calendar.prototype, "Timestamp", void 0);
__decorate([
    Key(''),
    Label('Идентификатор')
], Calendar.prototype, "ID", void 0);
__decorate([
    InputHidden("True")
], Calendar.prototype, "type", void 0);
Calendar = __decorate([
    EntityLabel('Дата предоставления отчёта')
], Calendar);
export { Calendar };
