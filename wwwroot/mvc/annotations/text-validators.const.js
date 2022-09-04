export const textLengthValidators = {
    length: function (min, max) {
        if (min < 1) {
            throw new Error('минимальная длина строки не может быть меньше одного символа');
        }
        else if (max <= min) {
            throw new Error('максимальное количество сиволов в строке должно быт меньше минимального');
        }
        else if (max > 255) {
            throw new Error('максимальная длина строки не может быть больше 255 символов');
        }
        else {
            return function (target, prop) {
                textLengthValidators.minLength(min)(target, prop);
                textLengthValidators.maxLength(max)(target, prop);
            };
        }
    },
    minLength: function (length, message) {
        if (length < 1) {
            throw new Error('минимальная длина строки не может быть меньше одного символа');
        }
        else {
            return function (target, prop) {
                if (!target.__descriptor__) {
                    target.__descriptor__ = {};
                }
                if (!target.__descriptor__[prop]) {
                    target.__descriptor__[prop] = { validators: [] };
                }
                target.__descriptor__[prop].validators.push(function (value) {
                    if (!value || value.length < length) {
                        if (message) {
                            throw new Error(message);
                        }
                        else {
                            throw new Error('длина свойства ' + prop + ' должна быть не меньше ' + length + ' символов');
                        }
                    }
                });
            };
        }
    },
    maxLength: function (length, message) {
        if (length < 1) {
            throw new Error('максимальная длина строки не может быть меньше одного символа');
        }
        else if (length > 255) {
            throw new Error('максимальная длина строки не может быть больше 255 символов');
        }
        else {
            return function (target, prop) {
                if (!target.__descriptor__) {
                    target.__descriptor__ = {};
                }
                if (!target.__descriptor__[prop]) {
                    target.__descriptor__[prop] = { validators: [] };
                }
                if (!target.__descriptor__[prop].validators) {
                    target.__descriptor__[prop].validators = [];
                }
                target.__descriptor__[prop].validators.push(function (value) {
                    if (value && value.length > length) {
                        if (message) {
                            throw new Error(message);
                        }
                        else {
                            throw new Error('длина свойства ' + prop + ' должна быть не больше ' + length + ' символов');
                        }
                    }
                });
            };
        }
    }
};
function extend(a, b) {
    var ab = {};
    Object.getOwnPropertyNames(a).forEach(name => { ab[name] = a[name]; });
    Object.getOwnPropertyNames(b).forEach(name => { ab[name] = b[name]; });
    return ab;
}
export const textValidators = extend({
    email: function (message) {
        const regexp = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return this.regexp(regexp, message || 'Значение не отвечает правилам именования электронных адресов');
    },
    rus: function (message) {
        const regexp = /^[а-яА-ЯёЁ]+$/;
        return this.regexp(regexp, message || 'Значение должно быть определено сиволами кириллицы');
    },
    eng: function (message) {
        const regexp = /^[a-zA-Z]+$/;
        return this.regexp(regexp, message || 'Значение должно быть определено сиволами кириллицы');
    },
    url: function (message) {
        const regexp = /^(ftp|http|https):\/\/[^ "]+$/;
        const firstStepValidation = this.regexp(regexp, message || 'Значение не отвечает правилам именования URL');
        return function (target, prop) {
            if (!target.__descriptor__) {
                target.__descriptor__ = {};
            }
            if (!target.__descriptor__[prop]) {
                target.__descriptor__[prop] = { validators: [] };
            }
            if (!target.__descriptor__[prop].validators) {
                target.__descriptor__[prop].validators = [];
            }
            target.__descriptor__[prop].validators.push(function (value) {
                const expression = new RegExp(regexp);
                if (!expression.test(value)) {
                    throw new Error(message || 'Значение не отвечает правилам именования электронных адресов');
                }
                else {
                }
            });
        };
    },
    regexp: function (regexp, message) {
        const expression = new RegExp(regexp);
        if (!regexp) {
            throw new Error('регулярное выражение не задано');
        }
        else {
            return function (target, prop) {
                if (!target.__descriptor__) {
                    target.__descriptor__ = {};
                }
                if (!target.__descriptor__[prop]) {
                    target.__descriptor__[prop] = { validators: [] };
                }
                if (!target.__descriptor__[prop].validators) {
                    target.__descriptor__[prop].validators = [];
                }
                target.__descriptor__[prop].validators.push(function (value) {
                    if (!expression.test(value)) {
                        if (message) {
                            throw new Error(message);
                        }
                        else {
                            throw new Error('значение не отвечает правилам ввода');
                        }
                    }
                });
            };
        }
    },
}, textLengthValidators);
