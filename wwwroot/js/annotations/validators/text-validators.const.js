const textValidators = Object.assign({
    email: function (message) {
        const regexp = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return textValidators.regexp(regexp, message || 'Значение не отвечает правилам именования электронных адресов');
    },
    rus: function (message) {
        const regexp = /^[а-яА-ЯёЁ]+$/;
        return textValidators.regexp(regexp, message || 'Значение должно быть определено сиволами кириллицы');
    },
    eng: function (message) {
        const regexp = /^[a-zA-Z]+$/;
        return textValidators.regexp(regexp, message || 'Значение должно быть определено сиволами кириллицы');
    },
    url: function (message) {
        const regexp = /^(ftp|http|https):\/\/[^ "]+$/;
        const firstStepValidation = textValidators.regexp(regexp, message || 'Значение не отвечает правилам именования URL');
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
