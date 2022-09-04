var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let LayoutPanelComponent = class LayoutPanelComponent {
    constructor($scope, $mdPanel) {
        function BasicDemoCtrl($mdPanel) {
            this._mdPanel = $mdPanel;
            this.desserts = [
                'Apple Pie',
                'Donut',
                'Fudge',
                'Cupcake',
                'Ice Cream',
                'Tiramisu'
            ];
            this.selected = { favoriteDessert: 'Donut' };
            this.disableParentScroll = false;
        }
        const angular = window['angular'];
        BasicDemoCtrl.prototype.showDialog = function () {
            var position = this._mdPanel.newPanelPosition()
                .absolute()
                .center();
            var config = {
                attachTo: angular.element(document.body),
                controller: function () { },
                controllerAs: 'ctrl',
                disableParentScroll: this.disableParentScroll,
                templateUrl: 'panel.tmpl.html',
                hasBackdrop: true,
                panelClass: 'demo-dialog-example',
                position: position,
                trapFocus: true,
                zIndex: 150,
                clickOutsideToClose: true,
                escapeToClose: true,
                focusOnOpen: true
            };
            this._mdPanel.open(config);
        };
        BasicDemoCtrl.prototype.showMenu = function (ev) {
            var position = this._mdPanel.newPanelPosition()
                .relativeTo('.demo-menu-open-button')
                .addPanelPosition(this._mdPanel.xPosition.ALIGN_START, this._mdPanel.yPosition.BELOW);
            var config = {
                attachTo: angular.element(document.body),
                controller: function () { },
                controllerAs: 'ctrl',
                template: '<div class="demo-menu-example" ' +
                    '     aria-label="Select your favorite dessert." ' +
                    '     role="listbox">' +
                    '  <div class="demo-menu-item" ' +
                    '       ng-class="{selected : dessert == ctrl.favoriteDessert}" ' +
                    '       aria-selected="{{dessert == ctrl.favoriteDessert}}" ' +
                    '       tabindex="-1" ' +
                    '       role="option" ' +
                    '       ng-repeat="dessert in ctrl.desserts" ' +
                    '       ng-click="ctrl.selectDessert(dessert)"' +
                    '       ng-keydown="ctrl.onKeydown($event, dessert)">' +
                    '    {{ dessert }} ' +
                    '  </div>' +
                    '</div>',
                panelClass: 'demo-menu-example',
                position: position,
                locals: {
                    'selected': this.selected,
                    'desserts': this.desserts
                },
                openFrom: ev,
                clickOutsideToClose: true,
                escapeToClose: true,
                focusOnOpen: false,
                zIndex: 2
            };
            this._mdPanel.open(config);
        };
    }
};
LayoutPanelComponent = __decorate([
    Component({
        selector: 'layoutPanel',
        transclude: {
            'header': '?header',
            'nav': '?nav'
        },
        template: `
        <div class="content-box">            
            <column>    
                <top>
                    <md-toolbar>
                        <md-toolbar-tools>
                            <div ng-transclude="header"></div>
                        </<md-toolbar-tools>
                    </md-toolbar>
                    
                </top>
                <line>
                    <left><div ng-transclude="nav"></div></left>
                    <div ng-transclude></div>
                    <right></right>            
                </line>
                <bottom>
                    <div ng-transclude="footer"></div>
                </bottom>        
            </column>
        </div>
    `
    })
], LayoutPanelComponent);
