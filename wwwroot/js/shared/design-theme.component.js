var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let DesignThemeComponent = class DesignThemeComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $cssConverter, $rootScope) {
        super($scope, $element, $attrs, $injector);
        this.css = {};
        this.$cssConverter = $cssConverter;
    }
    update() {
        document.getElementById('scope-' + this.$scope.$id + '').innerHTML = this.$cssConverter.t;
    }
    $onChanges() {
        Object.assign(this.$scope, this.ctrl);
        this.update();
    }
};
DesignThemeComponent = __decorate([
    Component({
        selector: 'design-theme',
        input: ['css'],
        template: `
        <style id="scope-{{$id}}">
        </style>
    `
    })
], DesignThemeComponent);
