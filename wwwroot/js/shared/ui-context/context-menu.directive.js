var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ContextMenuAttribute = class ContextMenuAttribute extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $contextMenu) {
        super($scope, $element, $attrs, $injector);
        const ctrl = this;
        $element[0].style.cursor = 'contextmenu';
        $element[0].addEventListener('click', function (evt) {
            $contextMenu.open(evt.clientX + 'px', evt.clientY + 'px', ctrl.contextMenuModel);
        });
    }
    $onChanges() {
        Object.assign(this.$scope, this.ctrl);
    }
};
ContextMenuAttribute = __decorate([
    Component({
        restrict: 'A',
        transclude: true,
        template: '<ng-transclude></ng-transclude>',
        input: ['contextMenuModel'],
        selector: 'contextMenuModel'
    })
], ContextMenuAttribute);
