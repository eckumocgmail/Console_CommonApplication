var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ControlMenuComponent = class ControlMenuComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector) {
        super($scope, $element, $attrs, $injector);
        this.label = 'menu';
        this.icon = 'home';
        this.href = '';
        this.onclick = function () {
            console.log(this.label);
        };
        this.menuitems = [];
        $scope.$onClick = (menuitem) => {
            console.log(menuitem);
            if (menuitem.onclick) {
                menuitem.onclick();
            }
            else if (menuitem.href) {
                $scope.$emit('href', menuitem.href);
                document.location.href = menuitem.href;
            }
            else {
                $scope.$emit('click', menuitem);
            }
        };
    }
};
ControlMenuComponent = __decorate([
    Component({
        selector: 'controlMenu',
        input: ['label', 'icon', 'href', 'menuitems'],
        transclude: true,
        template: `
    <md-menu>
 
        <md-button aria-label="Open menu with custom trigger" ng-mouseenter="$mdMenu.open()">
            <i class="material-icons">{{icon}}</i>
            <text ng-if="label">{{ label }}</text>
            <div ng-transclude></div>
        </md-button>
        <md-menu-content width="4" ng-mouseleave="$mdMenu.close()">
            <md-menu-item ng-repeat="menuitem in menuitems">
                <md-button ng-click="$onClick(menuitem)">
                    <i ng-if="menuitem.icon" class="material-icons">{{menuitem.icon}}</i>
                    <a>{{ menuitem.label }}</a>
                </md-button>
            </md-menu-item>
        </md-menu-content>
    </md-menu>
    `
    })
], ControlMenuComponent);
