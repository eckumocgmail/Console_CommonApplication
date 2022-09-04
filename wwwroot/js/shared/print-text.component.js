var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let PrintTextDirective = class PrintTextDirective {
    constructor($scope, $element, $attrs, $injector) {
        this.text = "";
        this.text = $attrs['printText'];
        this.timeout = $attrs['timeout'] || 50;
        this.node = $element[0];
    }
    $onInit() {
        for (let i = 0; i < this.text.length; i++) {
            setTimeout(() => {
                this.node.innerHTML += this.text[i];
            }, (i + 1) * this.timeout);
        }
    }
    $onDestroy() {
    }
};
PrintTextDirective = __decorate([
    Component({
        selector: 'printText',
        restrict: 'A'
    })
], PrintTextDirective);
