var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let LayoutSidenavComponent = class LayoutSidenavComponent {
    constructor($scope, $element, $attrs, $mdSidenav) {
        this.title = "Свойства";
        this.ctrl = this;
        this.$scope = null;
        this.$element = null;
        this.$attrs = null;
        this.leftOpened = true;
        this.rightOpened = true;
        alert(1);
        const ctrl = this;
        Object.assign(this, {
            $scope: $scope,
            $element: $element,
            $attrs: $attrs,
            $mdSidenav: $mdSidenav
        });
        Object.assign($scope, this);
        $element[0].children[0].onmouseleave = function (evt) {
            if ('left' == evt.target.getAttribute('ng-component-id')) {
                ctrl.closeLeft();
            }
            else if ('right' == evt.target.getAttribute('ng-component-id')) {
                ctrl.closeRight();
            }
        };
        $element[0].$ctrl = this;
        if ($attrs.name) {
            window[$attrs.name + ''] = this;
        }
        const openLeft = buildToggler('left');
        const openRight = buildToggler('right');
        function AndLeftAndRight() {
            openLeft();
            openRight();
        }
        this.ctrl.toggleLeft = AndLeftAndRight;
        this.ctrl.toggleRight = AndLeftAndRight;
        function buildToggler(componentId) {
            return function () {
                $mdSidenav(componentId).toggle();
            };
        }
        $scope.$on('toggleLeft', () => { $scope.toggleLeft(); ctrl.leftOpened = ctrl.leftOpened ? false : true; });
        $scope.$on('toggleRight', () => { $scope.toggleRight(); ctrl.rightOpened = ctrl.rightOpened ? false : true; });
    }
    $onChanges() {
        Object.assign(this.$scope, this.ctrl);
        console.log(this);
    }
};
LayoutSidenavComponent = __decorate([
    Component({
        selector: 'layoutSidenav',
        input: [],
        output: [],
        transclude: {
            left: '?left',
            right: '?right'
        },
        template: ` 
        <div layout="column" style="height: 100%;" ng-cloak>
            <section layout="row" flex>
                <md-sidenav class="md-sidenav-left"
                            md-component-id="left"                            
                            md-disable-backdrop="" 
                            md-whiteframe="4" >
                    <div style="width: 100%; height: 100%;" ng-mouseleave="toggleLeft()&&toggleLeft()">                          
                        <div ng-transclude="left"></div>
                    </div>                                       
                </md-sidenav>
                <md-sidenav class="md-sidenav-right" 
                            md-component-id="right"
                            md-disable-backdrop="" 
                             
                            md-whiteframe="4" >
                    
                    <panel>
                        <md-content>                                                    
                            <div ng-transclude="right"></div>
                        </md-content>  
                    </<panel>         
                </md-sidenav>
                <md-content flex layout-padding >
                    <div layout="column" layout-align="top"  style="width: 100%; heigh: 100%;" >      

                        <div ng-transclude></div>                                
                    </div>
                </md-content>
            </section>
        </div>   
    `
    })
], LayoutSidenavComponent);
