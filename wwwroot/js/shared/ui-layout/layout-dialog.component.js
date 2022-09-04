var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let LayoutDialogComponent = class LayoutDialogComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $mdDialog) {
        super($scope, $element, $attrs, $injector);
        const angular = window['angular'];
        function DialogController($scope, $mdDialog) {
            this.$onInit = function () {
                setTimeout(() => {
                    document.getElementById('dialogContentBlock').appendChild($element[0].children[0]);
                }, 1000);
            };
            $scope.hide = function () {
                $mdDialog.hide();
            };
            $scope.cancel = function () {
                $mdDialog.cancel();
            };
            $scope.answer = function (answer) {
                $mdDialog.hide(answer);
            };
        }
        $scope.showTabDialog = function (ev) {
            $mdDialog.show({
                controller: DialogController,
                template: `     
                <md-dialog aria-label="Mango (Fruit)">
                    <form>
                        <md-toolbar>
                            <div class="md-toolbar-tools">
                                <h2>Mango (Fruit)</h2>
                                <span flex></span>
                                <md-button class="md-icon-button" ng-click="cancel()">
                                    <md-icon aria-label="Close dialog"></md-icon>
                                </md-button>
                            </div>
                        </md-toolbar>
                        <md-dialog-content style="width: 640px; height: 480px;" >
                            <div id="dialogContentBlock"></div>
                            
                        </md-dialog-content>

                        <md-dialog-actions layout="row">
                            <md-button href="http://en.wikipedia.org/wiki/Mango" target="_blank" md-autofocus>
                                More on Wikipedia
                            </md-button>
                            <span flex></span>
                            <md-button ng-click="answer('not useful')">
                                Not Useful
                            </md-button>
                            <md-button ng-click="answer('useful')" style="margin-right:20px;">
                                Useful
                            </md-button>
                        </md-dialog-actions>
                    </form>
                </md-dialog>
                    `,
                parent: angular.element(document.body),
                targetEvent: ev,
                clickOutsideToClose: true
            }).then(function (answer) {
                $scope.status = 'You said the information was "' + answer + '".';
            }, function () {
                $scope.status = 'You cancelled the dialog.';
            });
        };
    }
};
LayoutDialogComponent = __decorate([
    Component({
        selector: 'layoutDialog',
        transclude: true,
        template: `<div ng-transclude></div>`
    })
], LayoutDialogComponent);
