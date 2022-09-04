var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let InvokeProcedureService = class InvokeProcedureService {
    constructor($client) {
        this.$client = $client;
    }
    $procedure(modelid, procedure) {
        const invokationEvent = {
            Source: modelid,
            Action: procedure
        };
        console.log(modelid, invokationEvent);
        this.$client.$connection.invoke('Invoke', JSON.stringify(invokationEvent))
            .then(this.$ensureInvokationCompleted(modelid))
            .then(this.$commitChangesCallback());
    }
    $commitChangesCallback() {
        return function (resp) {
            if (!window['checkout']) {
                throw new Error("Не опроеделена ссылка window[checkout'']");
            }
            else {
                window['checkout']();
            }
            return resp;
        };
    }
    $method(modelid, action, args) {
        const invokationEvent = {
            Source: modelid,
            Action: action,
            Args: args
        };
        console.log(modelid, invokationEvent);
        return this.$client.$connection.invoke('Call', JSON.stringify(invokationEvent)).then(this.$ensureInvokationCompleted(modelid)).then(this.$commitChangesCallback());
    }
    $ensureInvokationCompleted(modelid) {
        const ctrl = this;
        return function (resp) {
            console.log(resp);
            const message = JSON.parse(resp);
            if (message.Status == 'Error') {
                console.error(message);
                const errorTextMessage = 'Что-то прошло не так с вызовом динамической функции: \n' + JSON.stringify(message);
                if (window['notify']) {
                    window['notify'](errorTextMessage, 'danger');
                }
                alert();
            }
            else {
                console.log('Успешное выполнение запроса');
                console.log(resp.Result == modelid);
            }
            return resp;
        };
    }
};
InvokeProcedureService = __decorate([
    Service({
        name: '$invoke'
    })
], InvokeProcedureService);
