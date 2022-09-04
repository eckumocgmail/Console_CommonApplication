const annotations = {
    hint: function (message) {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'url' };
            if (!target.__descriptor__) {
                target.__descriptor__ = {};
            }
            if (!target.__descriptor__[prop]) {
                target.__descriptor__[prop] = { validators: [] };
            }
            if (!target.__descriptor__[prop].validators) {
                target.__descriptor__[prop].validators = [];
            }
            if (!target.__descriptor__[prop].hints) {
                target.__descriptor__[prop].hints = [message];
            }
            else {
                target.__descriptor__[prop].hints.push(message);
            }
        };
    },
    label: function (text) {
        return function (target, prop) {
            description(target, prop).label = text;
        };
    }
};
