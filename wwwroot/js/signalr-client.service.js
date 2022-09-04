var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ClientService = class ClientService {
    constructor($http) {
        this.$active = false;
        if (!window['$signalrClient']) {
            throw new Error(this.constructor.name + ' не может инициаллизироваться, т.к. необходима ссылка window["$signalrClient"]');
        }
        else {
        }
        this.$http = $http;
        this.$timestamp = this.$time();
        this.$onConnectedCallback();
    }
    get $connection() {
        return window['$signalrClient'].$connection;
    }
    $onConnectedCallback() {
        const ctrl = this;
        this.$active = true;
        return function (resp) {
            console.log('$onConnected: ', ctrl.$connection);
            setTimeout(() => {
                ctrl.$checkout(ctrl.$onChangesCallback());
            }, 550);
        };
    }
    $checkout(resolve) {
        const ctrl = this;
        if (this.$connection && this.$connection.state == 'Connected') {
            this.$connection.invoke('Checkout', this.$time().toString()).then((changes) => {
                resolve(changes);
                if (ctrl.$active) {
                    setTimeout(() => {
                        ctrl.$checkout(resolve);
                    }, 100);
                }
            });
        }
    }
    $onChangesCallback() {
        const ctrl = this;
        return function (changes) {
            for (let i = 0; i < changes.length; i++) {
                console.log(changes[i].name);
                ctrl.$update(changes[i].hash);
            }
        };
    }
    $update(id) {
        let container = document.getElementById('view-' + id);
        if (!container) {
            const ctrl = this;
            if (document.readyState == 'complete') {
                container = document.getElementById('view-' + id);
                if (container) {
                    ctrl.$update(id);
                }
                else {
                    ctrl.$connection.stop();
                    console.warn('Не удалось обновить представление ' + id + ' т.к. не найден узел контейнера.');
                }
            }
            else {
                document.addEventListener('load', () => {
                    ctrl.$update(id);
                });
            }
        }
        else {
            this.$http({
                method: 'get',
                url: '/View/Update?modelId=' + id
            }).then((resp) => {
                while (container.childNodes.length > 0)
                    container.removeChild(container.childNodes[0]);
                let pnode = document.createElement('div');
                pnode.innerHTML = resp.data;
                container.appendChild(pnode);
                window['$app'].$compile(pnode)(window['$app'].$scope);
            });
        }
    }
    $time() {
        return new Date().getTime();
    }
};
ClientService = __decorate([
    Service({
        name: '$client'
    })
], ClientService);
