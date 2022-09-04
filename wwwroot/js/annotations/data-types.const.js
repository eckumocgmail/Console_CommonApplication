const dataTypes = {
    number: function (floating = true, min, max) {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'number' };
            if (min)
                numberValidators.max(min)(target, prop);
            if (max)
                numberValidators.max(max)(target, prop);
        };
    },
    date: function (format) {
        return function (target, prop) {
            target[prop] = new Date();
            description(target, prop).input = { type: 'primitive', input: 'date', format };
        };
    },
    string: function (lang, length) {
        return function (target, prop) {
            description(target, prop).input = { type: 'primitive', input: 'text' };
            switch (lang) {
                case 'ru': textValidators.rus()(target, prop);
                case 'eng': textValidators.eng()(target, prop);
                default: break;
            }
        };
    },
};
