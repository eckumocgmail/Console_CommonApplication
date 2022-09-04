const imageTypes = {
    png: function (maxsize) {
        return controlTypes.file(['image/png'], maxsize);
    },
    jpeg: function (maxsize) {
        return controlTypes.file(['image/jpeg'], maxsize);
    },
    gif: function (maxsize) {
        return controlTypes.file(['image/gif'], maxsize);
    }
};
