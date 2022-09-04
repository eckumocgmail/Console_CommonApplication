var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ReportsService = class ReportsService {
    constructor($client) {
        this.$active = false;
        this.$client = $client;
    }
    $create(report, resolve) {
        const ctrl = this;
        this.$client.$connection.invoke('CreateReport', report).then((response) => {
            console.log('CreateReport complete: ', response);
            resolve(response);
        });
    }
    $update(report, resolve) {
        const ctrl = this;
        this.$client.$connection.invoke('UpdateReport', report).then((response) => {
            console.log('UpdateReport complete: ', response);
            resolve(response);
        });
    }
    $find(id, resolve) {
        const ctrl = this;
        this.$client.$connection.invoke('FindReport', id).then((response) => {
            console.log('FindReport complete: ', response);
            resolve(response);
        });
    }
    $delete(id, resolve) {
        const ctrl = this;
        this.$client.$connection.invoke('DeleteReport', id).then((response) => {
            console.log('DeleteReport complete: ', response);
            resolve(response);
        });
    }
    $list(resolve) {
        this.$client.$connection.invoke('ListReport', '').then((response) => {
            console.log('CreateReport complete: ', response);
            resolve(response);
        });
    }
};
ReportsService = __decorate([
    Service({
        name: '$reports'
    })
], ReportsService);
