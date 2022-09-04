var $progress = window['$progress'] = {
    stop: function () {
        if (!document.getElementById('content-pane')) {
            throw new Error('');
        }
        document.getElementById('content-pane').hidden = false;
        document.getElementById('progress-pane').hidden = true;
    },
    start: function () {
        console.log('start');
        document.getElementById('content-pane').hidden = true;
        document.getElementById('progress-pane').hidden = false;
    }
};
