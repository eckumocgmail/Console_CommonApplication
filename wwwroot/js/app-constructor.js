var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
class ContentPane {
    hide() {
        throw new Error("Method not implemented.");
    }
}
let WindowService = class WindowService extends DOMRect {
    constructor() {
        super(...arguments);
        this.windows = [];
        this.active = null;
    }
    hideAll() {
        this.windows.forEach(this.hide);
    }
    hide(window) {
        window.hide();
    }
    open(text) {
    }
};
WindowService = __decorate([
    Service({
        name: '$hWindow'
    })
], WindowService);
let ConstructorCtrl = class ConstructorCtrl {
    constructor($hWindow) {
        this.behaviour = {
            click(evt) {
                console.log(evt);
            }
        };
        window['$hWindow'] = $hWindow;
    }
    $onInit() {
        const ctrl = this;
        Object.getOwnPropertyNames(this.behaviour).forEach(name => {
            window.addEventListener(name, ctrl.behaviour[name]);
        });
    }
    $onDestroy() {
        const ctrl = this;
        Object.getOwnPropertyNames(this.behaviour).forEach(name => {
            window.removeEventListener(name, ctrl.behaviour[name]);
        });
    }
};
ConstructorCtrl = __decorate([
    Controller({})
], ConstructorCtrl);
