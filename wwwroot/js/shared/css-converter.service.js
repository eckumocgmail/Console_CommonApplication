var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let CssConverterService = class CssConverterService {
    constructor() {
        this.options = [
            'color', 'width', 'height'
        ];
    }
    toCss(options) {
        let cssText = '';
        const ctrl = this;
        Object.getOwnPropertyNames(options).forEach(name => {
            const value = options[name];
            const cssOpitonsName = ctrl.splitCapitalizaId(name);
            cssText += cssOpitonsName + ':' + value + ';';
        });
    }
    splitCapitalizaId(id) {
        let message = '';
        const upper = id.toUpperCase();
        for (let i = 0; i < id.length; i++) {
            if (i != 0 && id.charCodeAt(i) === upper.charCodeAt(i)) {
                message += ' ';
            }
            message += id[i].toLowerCase();
        }
        const arr = message.split(' ');
        return arr;
    }
};
CssConverterService = __decorate([
    Service({
        name: '$cssConverter'
    })
], CssConverterService);
