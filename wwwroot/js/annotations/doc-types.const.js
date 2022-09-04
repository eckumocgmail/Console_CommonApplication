const fileTypes = {
    pdf: function (maxsize) {
        return controlTypes.file(['application/pdf'], maxsize);
    },
    xls: function (maxsize) {
        return controlTypes.file(['application/xls'], maxsize);
    },
    xlsx: function (maxsize) {
        return controlTypes.file(['application/xlsx'], maxsize);
    },
    doc: function (maxsize) {
        return controlTypes.file(['application/doc'], maxsize);
    },
    docx: function (maxsize) {
        return controlTypes.file(['application/docx'], maxsize);
    }
};
