const controlTypes = {
    icon: function () {
        return function (target, prop) {
            description(target, prop).input = { type: 'control',
                input: 'icon'
            };
        };
    },
    image: function () {
        return controlTypes.file();
    },
    textarea: function () {
        return function (target, prop) {
            description(target, prop).input = { type: 'control', input: 'textarea' };
        };
    },
    boolean: function () {
        return function (target, prop) {
            description(target, prop).input = { type: 'control', input: 'checkbox' };
        };
    },
    checkbox: function () {
        return function (target, prop) {
            description(target, prop).input = { type: 'control', input: 'checkbox' };
        };
    },
    file: function (exts, maxsize) {
        function toCSV(arr) {
            let s = '';
            arr.forEach(item => {
                s += ',' + item;
            });
            return s.substr(1);
        }
        return function (target, prop) {
            description(target, prop).input = { type: 'control', input: 'file', accepts: toCSV(!exts ? ['*.*'] : exts) };
        };
    },
    selectbox: function (options) {
        return function (target, prop) {
            description(target, prop).input = { type: 'control', input: 'selectbox', multiselect: false, options };
        };
    },
    multiselectbox: function (options) {
        return function (target, prop) {
            description(target, prop).input = { type: 'control', input: 'multiselectbox', multiselect: false, options };
        };
    },
    radiogoup: function (options) {
        return function (target, prop) {
            description(target, prop).input = { type: 'control', input: 'radiogroup', options };
        };
    },
    dropbox: function () { throw new Error('unsupported'); }
};
