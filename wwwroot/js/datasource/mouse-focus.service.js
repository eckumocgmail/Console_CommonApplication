var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let MouseFocuseService = class MouseFocuseService {
    constructor($client) {
        this.$client = $client;
    }
    $mouseover(modelid) {
        const mouseOverEvent = {
            Source: modelid
        };
        console.log(modelid, mouseOverEvent);
        if (this.$client.$connection && this.$client.$connection.state == 'Connected') {
            this.$client.$connection.invoke('OnMouseOver', JSON.stringify(mouseOverEvent)).then(this.$ensureCompletedCallback(modelid));
        }
    }
    $mouseout(modelid) {
        const mouseOverEvent = {
            Source: modelid
        };
        console.log(modelid, mouseOverEvent);
        if (this.$client.$connection && this.$client.$connection.state == 'Connected') {
            this.$client.$connection.invoke('OnMouseOut', JSON.stringify(mouseOverEvent)).then(this.$ensureCompletedCallback(modelid));
        }
    }
    $ensureCompletedCallback(modelid) {
        const ctrl = this;
        return function (resp) {
            const message = JSON.parse(resp);
            if (message.Status == 'Error') {
                window.document.location.href = '/Account/Login';
            }
            else {
                resp.Result == modelid;
            }
        };
    }
};
MouseFocuseService = __decorate([
    Service({
        name: '$focus'
    })
], MouseFocuseService);
