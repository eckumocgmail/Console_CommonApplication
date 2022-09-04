export const numberValidators = {
    max: function (maxValue) {
        return function maxLength(target, prop) {
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
                if (value > maxValue) {
                    throw new Error('Значение не должно превышать ' + maxValue);
                }
            });
        };
    },
    min: function (maxValue) {
        return function maxLength(target, prop) {
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
                if (value < maxValue) {
                    throw new Error('Значение не должно превышать ' + maxValue);
                }
            });
        };
    }
};
