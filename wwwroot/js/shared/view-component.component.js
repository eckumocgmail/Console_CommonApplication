var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ViewComponent = class ViewComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector) {
        super($scope, $element, $attrs, $injector);
        this.modelid = 0;
        this.href = '/DatabaseEditor/Person/Create';
    }
    $onInit() {
        super.$onInit();
    }
    $onDestroy() {
        super.$onDestroy();
    }
    $onChanges(changes) {
        super.$onChanges(changes);
    }
    $trace(evt) {
        console.log(evt);
    }
};
ViewComponent = __decorate([
    Component({
        restrict: 'E',
        input: ['modelid'],
        selector: 'viewComponent',
        template: `<div ng-include="href"></div>`
    })
], ViewComponent);
