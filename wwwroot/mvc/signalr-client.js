export const signalR = window['signalR'];
export class AppClientService {
    constructor(url) {
        this.$connection = null;
        const self = this;
        this.connect(url);
    }
    info(message) {
        const name = this.constructor['name'];
        console.log('[' + name + ']: ' + message);
    }
    error(error) {
        const name = this.constructor['name'];
        console.error('[' + name + ']:', error);
    }
    start() {
        this.$connection.start()
            .then(this.onConnectionOpenedCallback())
            .catch(this.onConnectionErrorCallback());
    }
    ;
    connect(url) {
        const ctrl = this;
        ctrl.info('соединение: ' + url);
        const connection = new signalR.HubConnectionBuilder()
            .withUrl(url)
            .build();
        connection.serverTimeoutInMilliseconds = 10000000;
        ctrl.$connection = connection;
        connection.onclose(ctrl.onConnectionClosedCallback());
        ctrl.start();
    }
    onConnectionOpenedCallback() {
        const ctrl = this;
        return function () {
            ctrl.info('соединение установлено');
        };
    }
    onConnectionClosedCallback() {
        const ctrl = this;
        return function () {
            ctrl.info('соединение разорвано');
            ctrl.start();
        };
    }
    onConnectionErrorCallback() {
        const ctrl = this;
        return function (error) {
            ctrl.error(error);
        };
    }
}
