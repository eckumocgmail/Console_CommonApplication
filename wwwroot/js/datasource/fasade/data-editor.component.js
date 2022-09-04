var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let DataEditorComponent = class DataEditorComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $applicationDbContext) {
        super($scope, $element, $attrs, $injector);
        this.$applicationDbContext = $applicationDbContext;
    }
    $onChanges(changes) {
        console.log('$onChanges');
        const ctrl = this;
        Object.assign(this.$scope, this.ctrl);
        this.controller = this.$applicationDbContext[this.entity];
        this.controller.List().then((resp) => {
            ctrl.dataset = resp;
        });
    }
};
DataEditorComponent = __decorate([
    Component({
        selector: 'dataEditor',
        template: `<div ng-tranclude>{{ dataset }}</div>`,
        transclude: true,
        input: ['entity']
    })
], DataEditorComponent);
