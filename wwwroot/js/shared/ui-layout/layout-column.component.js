var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let LayoutColumnComponent = class LayoutColumnComponent {
};
LayoutColumnComponent = __decorate([
    Component({
        selector: 'layoutColumn',
        transclude: {
            top: '?top',
            bottom: '?bottom'
        },
        template: `
    <div style="width: 100%; height: 100%; display: -webkit-flex; display: flex; flex-direction: column;">
        <div style="width: 100%;" ng-hidden="!showTop">
            <div ng-transclude="top"></div>
        </div>
        <div style="width: 100%; height: 100%; overflow-y: auto; display: -webkit-flex; display: flex; flex-direction: column;">
            <div ng-transclude></div>
        </div>
        <div style="width: 100%;" ng-hidden="!showBottom">
            <div ng-transclude="bottom"></div>
        </div>
    </div>
    `
    })
], LayoutColumnComponent);
