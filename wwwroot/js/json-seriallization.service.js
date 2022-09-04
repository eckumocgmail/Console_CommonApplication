var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

if (!window['JsonSeriallization']) {

let JsonSeriallization = class JsonSeriallization {
    constructor() { }
    seriallize(target) {
        return JSON.stringify(target, function (k, v) {
            if (typeof (v) == 'function') {
                return v.toString();
            }
            else {
                return v;
            }
        });
    }
    deseriallize(json) {
        return JSON.parse(json, function (k, v) {
            if (typeof (v) == 'string') {
                if (v && v.startsWith('function')) {
                    return eval('(function(){ return ' + v + '; })()');
                }
                else {
                    return v;
                }
            }
            else {
                return v;
            }
        });
    }
};
JsonSeriallization = __decorate([
    Service({
        name: '$jsonSeriallization'
    })
], JsonSeriallization);
    window['$jsonSeriallization'] = new JsonSeriallization();

}

