var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let LayoutLineComponent = class LayoutLineComponent {
};
LayoutLineComponent = __decorate([
    Component({
        selector: 'layoutLine',
        transclude: {
            left: '?left',
            right: '?right'
        },
        template: `
    <div style="width: 100%; height: 100%; display: -webkit-flex; display: flex; flex-direction: row;">
        <div style="height: 100%;" ng-hidden="!showLeft">
            <div ng-transclude="left"></div>
        </div>
        <div style="width: 100%; height: 100%; display: -webkit-flex; display: flex; flex-direction: column; overflow-y: auto;">
            <div ng-transclude></div>
        </div>
        <div style="height: 100%;" ng-hidden="!showRight">
            <div ng-transclude="right"></div>
        </div>
    </div>
    `
    })
], LayoutLineComponent);
