var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ActionLinkComponent = class ActionLinkComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector) {
        super($scope, $element, $attrs, $injector);
        this.innerHTML = '';
        this.href = '';
        this.ctrl = this;
        this.active = false;
        const innerHTML = $element[0].outerHTML;
        const href = $element[0].getAttribute('href');
        Object.assign($scope, {
            innerHTML: innerHTML,
            href: href,
            activate() {
            }
        });
    }
    static preLink($scope, $element, $attrs, $injector) {
        const innerHTML = $element[0].outerHTML;
        const href = $element[0].getAttribute('href');
        console.log(href, innerHTML);
    }
    $onInit() {
        this.$scope.$emit({
            event: 'init',
            source: this
        });
    }
    $onDestroy() {
        this.$scope.$emit({
            event: 'destroy',
            source: this
        });
    }
    $onChanges(changes) {
        console.log('$onChanges');
        Object.assign(this.$scope, this.ctrl);
    }
};
ActionLinkComponent = __decorate([
    Component({
        selector: 'aasa',
        template: '',
        input: ['active']
    })
], ActionLinkComponent);
