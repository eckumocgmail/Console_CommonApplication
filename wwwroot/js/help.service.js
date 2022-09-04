var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let HelpService = class HelpService {
    constructor() {
    }
    $show() {
        window['$app'].$scope.$mdSidenav('right').toggle();
    }
    $select(id) {
        const e = document.getElementById(id);
        if (!e) {
            throw new Error('Не найти элемент по запросу: ' + id);
        }
        else {
            return e;
        }
    }
    removeDublicatedValues(array) {
        const set = new Set(array);
        let items = [];
        set.forEach((p) => {
            items.push(p);
        });
        return items;
    }
    toCssStyle(capitalized) {
        const arr = this.splitCapitalizaId(capitalized);
        const styleId = this.concatBySeparator(arr.splice(0, arr.length - 1));
        return styleId;
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
    splitCapitalizaIdStr(id) {
        let str = '';
        this.splitCapitalizaId(id).forEach(id => {
            str += id + ' ';
        });
        return str.trim();
    }
    concatBySeparator(ids) {
        let name = ids[0];
        for (let i = 1; i < ids.length; i++) {
            name += '-' + ids[i];
        }
        return name;
    }
    removeSpaceCharacters(text) {
        while (text.indexOf(' ') != -1) {
            text = text.replace(' ', '');
        }
        return text;
    }
    isNumberString(text) {
        const NUBMERS = '0123456789';
        let ctn = 0;
        for (let i = 0; i < text.length; i++) {
            if (NUBMERS.indexOf(text[i]) == -1) {
                ctn++;
            }
        }
        return ctn;
    }
    equals(x1, x2) {
        if (x1 instanceof Array && x2 instanceof Array) {
            if (x1.length !== x2.length) {
                return false;
            }
            x1 = x1.sort();
            x2 = x2.sort();
            for (let i = 0; i < x1['length']; i++) {
                if (x1 !== x2) {
                    return false;
                }
            }
            return true;
        }
        else {
            throw new Error("merge this type not supported");
        }
    }
    toString(arr, separator) {
        if (!arr) {
            throw new Error('arr is null reference');
        }
        else {
            if (arr.length == 0) {
                throw new Error('arr length = 0');
            }
            else {
                let text = arr[0].toString();
                for (let i = 1; i < arr.length; i++) {
                    text += separator + arr[i].toString();
                }
                return text;
            }
        }
    }
    forEach(subject, action) {
        if (!subject) {
            console.warn('subject is null reference');
        }
        else {
            if (this.isArray(subject)) {
                for (let i = 0; i < subject.length; i++) {
                    action(i, subject[i]);
                }
            }
            else if (this.isObject(subject)) {
                const names = this.names(subject);
                this.forEach(names, (index, value) => {
                    action(names[index], subject[value]);
                });
            }
            else {
                throw new Error('type of argument is not enumerable: ' + subject);
            }
        }
    }
    seal(ref) {
        return Object.seal(ref);
    }
    extend(ref, proto) {
        let pref = ref;
        while (pref['__proto__']['constructor'].name !== 'Object') {
            pref = pref['__proto__'];
        }
        const temp = pref['__proto__'];
        pref['__proto__'] = proto;
        proto['__proto__'] = temp;
    }
    unextend(ref, proto) {
        let pref = ref;
        while (pref['constructor'].name !== 'Object') {
            if (Object.is(pref['__proto__'], proto)) {
                pref['__proto__'] = proto['__proto__'];
                break;
            }
            else {
                pref = pref['__proto__'];
            }
        }
        throw new Error('unextend operation failed');
    }
    extensions(ref) {
        const pextensions = [];
        let pref = ref;
        while (pref && pref['__proto__']['constructor'].name !== 'Object') {
            pextensions.push(pref);
            pref = pref['__proto__'];
        }
        return pextensions;
    }
    timems() {
        const pdate = new Date();
        return (pdate.getHours() * 60 * 60 * 1000) + (pdate.getMinutes() * 60 * 1000) + (pdate.getSeconds() * 1000) + pdate.getMilliseconds();
    }
    indexes(ref) {
        return Object.getOwnPropertyNames(ref);
    }
    keys(ref) {
        const keys = [];
        for (let key in ref) {
            keys.push(key);
        }
        return keys;
    }
    typeOf(value) {
        return typeof (value);
    }
    isDate(value) {
        return value instanceof Date;
    }
    names(ref) {
        return Object.getOwnPropertyNames(ref);
    }
    isFunction(p) {
        return (typeof (p) == 'function');
    }
    isObject(p) {
        return (typeof (p) == 'object');
    }
    isArray(p) {
        return (typeof (p) == 'object') && (p instanceof Array);
    }
    time() {
        let now = new Date();
        let h = now.getHours().toString();
        let m = now.getMinutes().toString();
        let s = now.getSeconds().toString();
        let ms = now.getMilliseconds().toString();
        h = h.length == 1 ? "0" + h : h;
        m = m.length == 1 ? "0" + m : m;
        s = s.length == 1 ? "0" + s : s;
        while (ms.length != 4) {
            ms = "0" + ms;
        }
        return h + ":" + m + ":" + s + "." + ms;
    }
};
HelpService = __decorate([
    Service({
        name: '$help'
    })
], HelpService);
