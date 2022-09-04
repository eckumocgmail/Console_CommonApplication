var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

window['ChartDialogService'] = class ChartDialogService {
    constructor( $jsonSeriallization) {
        
        this.$jsonSeriallization = $jsonSeriallization;
    }
    popup(model) {
        console.log('\n\n $chartDialog.popup() <=\n', model, '\n\n\n');
        if (typeof (model) == 'string') {
            model = this.$jsonSeriallization.deseriallize(model);
        }
        if (!model.hashcode)
            alert('Не определено обязательное свойсво hashcode у аргумента model');
        this.$dialog.popupMvc({
            view: `<div id="view-` + model.hashcode + `"> Привет бро, сейчас покажу тебе что происходит </div>`,
            model: model,
            ctrl: {
                $onInit() {
                    setTimeout(() => {
                        window['Highcharts'].chart(document.getElementById("view-" + model.hashcode), model);
                    }, 2000);
                }
            }
        });
    }
};
ChartDialogService = __decorate([
    Service({
        name: '$chartDialog'
    })
], ChartDialogService);
window['AppDialogService'] = window['$dialog'] = class AppDialogService {
    constructor($mdDialog, $mdToast, $help, $jsonSeriallization) {
        this.$toast = this.createToaster($mdToast);
        this.$jsonSeriallization = $jsonSeriallization;
        this.$mdDialog = $mdDialog;
        window['$mdDialog'] = $mdDialog;
        window['$dialog'] = this;
        $help.forEach({
            createEntityFrontDialog: function (title, entity, complete) {
                if (typeof (complete) == 'string' && complete.startsWith('function')) {
                    complete = eval('(function(){ return ' + complete + '; })()');
                }
                return window['inputDialog'](title, eval('new ' + entity + '()'), {
                    ok: function ok(scope) {
                        console.log(scope);
                        if (complete)
                            complete(scope);
                    }
                });
            },
            master(models) {
                let current = 0;
                const pDialog = $mdDialog.show({
                    template: `
                        <md-dialog  > 
                          <md-dialog-content   > 	                     
                            <div class="front-pane" style="padding: 20px; height: 100%;">
                                {{isValid}}
                                <http-request url="url" ></http-request>
                            </div> 
                          </md-dialog-content> 
                          <md-dialog-actions> 
                            <md-button ng-click="cancel()" class="md-primary"> назад </md-button> 
                                {{isValid}}
                            <md-button ng-click="ok()" ng-disabled="!isValid" class="md-primary"> вперед  </md-button> 
                          </md-dialog-actions> 
                        </md-dialog>
                    `,
                    controller: function ($scope, $element) {
                        const ctrl = this;
                        window['app'].scopes[$scope.$id] = $scope;
                        $element[0].addEventListener('input', function (evt) {
                            console.log(evt);
                            function ensureInnerElementsIsValide(pnode) {
                                let hasInvalids = false;
                                function broadcast(p, fx) {
                                    if (p) {
                                        fx(p);
                                        if (p.childNodes && p.childNodes.length > 0) {
                                            for (let i = 0; i < p.childNodes.length; i++) {
                                                ensureInnerElementsIsValide(p.childNodes[i]);
                                            }
                                        }
                                    }
                                }
                                broadcast(pnode, (p) => {
                                    if (p instanceof HTMLElement) {
                                        if (p.classList.contains('is-invalid')) {
                                            console.warn(p);
                                            hasInvalids = true;
                                        }
                                    }
                                });
                                return hasInvalids;
                            }
                            $scope.isValid = ensureInnerElementsIsValide($element[0]);
                            console.log($scope.isValid);
                            $scope.$apply();
                        });
                        $scope.isValid = false;
                        $scope.models = models;
                        $scope.oninput = function (message) {
                            alert('oninput ' + message);
                        };
                        $scope.args = {
                            Bindings: {}
                        };
                        $scope.url = '/MasterDialog/' + models[current] + "";
                        $scope.current = current;
                        $scope.ok = function () {
                            console.log(current);
                            if ((++current) == models.length) {
                                $mdDialog.hide();
                            }
                            else {
                            }
                        };
                    }
                });
            },
            popup(template) {
                const pDialog = $mdDialog.show({
                    template: `
                        <md-dialog  style="width: 100%;"> 
                          <md-dialog-content  style="width: 100%; padding: 20px;"> 	                     
                            <div class="front-pane" style="padding: 20px; min-width: 800px; min-height: 600px;">` + template + `</div> 
                          </md-dialog-content> 
                          <md-dialog-actions> 
                            <md-button ng-click="ctrl.ok()" class="md-primary"> готово </md-button> 
                            <md-button ng-click="ctrl.cancel()" class="md-primary"> отмена </md-button> 
                          </md-dialog-actions> 
                        </md-dialog>
                    `,
                    controller: function () {
                        const ctrl = this;
                        ctrl.ok = function () {
                            template.hide();
                        };
                    }
                });
                return pDialog;
            },
            createEntityDialog: function (title, entity, complete) {
                if (typeof (complete) == 'string' && complete.startsWith('function')) {
                    complete = eval('(function(){ return ' + complete + '; })()');
                }
                var parentEl = window['angular'].element(document.body);
                $mdDialog.show({
                    parent: parentEl,
                    template: '<md-dialog aria-label="List dialog">' +
                        '  <md-dialog-content style="width: 600px;">' +
                        '   <div class="front-pane" style="padding: 20px;"><http-request url="' + "'/DatabaseEditor/" + entity + "/Create?Compile='" + '"></http-request></div>' +
                        '  </md-dialog-content>' +
                        '  <md-dialog-actions>' +
                        '    <md-button ng-click="ctrl.closeDialog()" class="md-primary">' +
                        '      Close Dialog' +
                        '    </md-button>' +
                        '  </md-dialog-actions>' +
                        '</md-dialog>',
                    locals: {
                        items: []
                    },
                    controller: DialogController,
                    controllerAs: 'ctrl'
                });
                function DialogController($mdDialog) {
                    this.closeDialog = function () {
                        $mdDialog.hide();
                    };
                }
            },
            inputDialog: function (title, properties, actions) {
                var data = properties;
                const dialog = $mdDialog.show({
                    controller: function ($scope, $mdPanel) {
                        const ctrl = this;
                        $scope.properties = properties;
                        $scope.onClick = (fx) => {
                            fx($scope);
                            $mdDialog.hide();
                        };
                        $scope.actions = actions;
                        ctrl.$onInit = function () {
                            var panelRef;
                            function showPanel($event) {
                                var panelPosition = $mdPanel.newPanelPosition()
                                    .absolute()
                                    .top('50%')
                                    .left('50%');
                                var panelAnimation = $mdPanel.newPanelAnimation()
                                    .targetEvent($event)
                                    .defaultAnimation('md-panel-animate-fly')
                                    .closeTo('.show-button');
                                var config = {
                                    attachTo: window['angular'].element('md-dialog-content'),
                                    controller: DialogController,
                                    controllerAs: 'ctrl',
                                    position: panelPosition,
                                    animation: panelAnimation,
                                    targetEvent: $event,
                                    templateUrl: 'dialog-template.html',
                                    clickOutsideToClose: true,
                                    escapeToClose: true,
                                    focusOnOpen: true
                                };
                                $mdPanel.open(config)
                                    .then(function (result) {
                                    console.log('dialog', result);
                                    panelRef = result;
                                });
                            }
                            function DialogController($mdDialog, MdPanelRef) {
                                this.closeDialog = function () {
                                    $mdDialog.hide();
                                };
                            }
                        };
                    },
                    controllerAs: 'ctrl',
                    parent: window['angular'].element(document.body),
                    locals: {},
                    template: `
                        <md-dialog style="width: 100%;"> 
                          <md-dialog-content style="width: 100%;" > 
 
                             <input-form properties="properties"></input-form>
                          </md-dialog-content> 
                          <md-dialog-actions> 
                            <md-button ng-repeat="(key,value) in actions" 
                                       ng-click="onClick(value)">{{key}}</md-button> 
                          </md-dialog-actions> 
                        </md-dialog>
                    `
                });
                return new Promise(function (resolve, reject) {
                    dialog.then((dialogResult) => {
                        resolve(data);
                    }, reject);
                });
            },
            infoDialog: function (title, text, button) {
                let alert = $mdDialog.alert({
                    title: title,
                    textContent: text,
                    ok: button
                });
                $mdDialog
                    .show(alert)
                    .finally(function () {
                    alert = undefined;
                });
            },
            remoteDialog: function (title, url) {
                var parentEl = window['angular'].element(document.body);
                $mdDialog.show({
                    parent: parentEl,
                    template: '<md-dialog aria-label="List dialog">' +
                        '  <md-dialog-content>' +
                        '   <div class="front-pane" style="padding: 20px;"><http-request url="' + "'" + url + "'" + '"></http-request></div>' +
                        '  </md-dialog-content>' +
                        '  <md-dialog-actions>' +
                        '    <md-button ng-click="ctrl.closeDialog()" class="md-primary">' +
                        '      Close Dialog' +
                        '    </md-button>' +
                        '  </md-dialog-actions>' +
                        '</md-dialog>',
                    locals: {
                        items: []
                    },
                    controller: DialogController,
                    controllerAs: 'ctrl'
                });
                function DialogController($mdDialog) {
                    this.closeDialog = function () {
                        $mdDialog.hide();
                    };
                }
            }
        }, (k, v) => {
            window[k] = v;
        });
    }
    createToaster($mdToast) {
        return function (text) {
            return new Promise(function (resolve, reject) {
                $mdToast.show($mdToast.simple()
                    .textContent(text)
                    .hideDelay(3000))
                    .then(function () {
                    resolve();
                }).catch(function () {
                    reject();
                });
            });
        };
    }
    hard(pnode, getResult) {
    }
    input(callback, options) {
        var confirm = this.$mdDialog.prompt()
            .title(options.title)
            .textContent(options.text)
            .placeholder(options.placeholder || '')
            .initialValue(options.value || '')
            .required(options.required || true)
            .ok('������')
            .cancel('������');
        this.$mdDialog.show(confirm).then(function (result) {
            callback(result);
        }, function () {
        });
    }
    popupMvc(component) {
        console.log('$dialog.popup() <= ', component);
        if (typeof (component) == 'string') {
            component = this.$jsonSeriallization.deseriallize(component);
        }
        if (!component)
            alert('Не определён аргумент component');
        if (!component.model)
            alert('Не определено свойство model в аргументе component');
        if (!component.view)
            alert('Не определено свойство view в аргументе component');
        if (!component.ctrl)
            alert('Не определено свойство ctrl в аргументе component');
        return this.$mdDialog.show({
            controller: function ($scope, $mdDialog) {
                Object.assign($scope, component.model);
                const ctrl = Object.assign(this, component.ctrl);
                this.closeDialog = function () {
                    $mdDialog.hide();
                };
            },
            controllerAs: 'ctrl',
            parent: window['angular'].element(document.body),
            locals: component.model,
            template: '<md-dialog>' +
                '  <md-dialog-content style="width: 600px;">' +
                `     <div style="padding: 20px;">` + component.view + '</div>' +
                '  </md-dialog-content>' +
                '  <md-dialog-actions>' +
                '    <md-button ng-repeat="(key,value) in actions" ng-click="value(this)">{{key}}</md-button>' +
                '  </md-dialog-actions>' +
                '</md-dialog>'
        });
    }
    selectListDialog(controller) {
        this.$mdDialog.show({
            controller: function ($scope, $mdDialog) {
                const ctrl = this;
                this.$onInit = () => {
                    controller.$onInit().then((model) => {
                        $scope.ctrl = Object.assign(model, ctrl);
                    });
                };
                this.$postLink = () => { };
                this.$onUpdate = () => { };
                this.$onDestroy = () => { };
                this.closeDialog = function () {
                    $mdDialog.hide();
                };
            },
            controllerAs: 'ctrl',
            parent: window['angular'].element(document.body),
            locals: { items: ["test", "test"] },
            template: '<md-dialog aria-label="List dialog">' +
                '  <md-dialog-content>' +
                '    <md-list>{{ctrl.items}}' +
                '      <md-list-item ng-repeat="item in items">' +
                '       <p>Number {{item}}</p>' +
                '      ' +
                '    </md-list-item></md-list>' +
                '  </md-dialog-content>' +
                '  <md-dialog-actions>' +
                '    <md-button ng-click="ctrl.closeDialog()" class="md-primary">' +
                '      Close Dialog' +
                '    </md-button>' +
                '  </md-dialog-actions>' +
                '</md-dialog>'
        });
    }
    selectEntity(entityRepository) {
        this.$mdDialog.show({
            controller: function ($scope, $mdDialog) {
                const ctrl = this;
                this.$onInit = () => {
                    entityRepository.List().then((resp) => {
                        if (resp.data && resp.data.Status == 'Success') {
                            $scope.evall = eval;
                            $scope.items = resp.data.Result;
                            $scope.bindings = resp.data.Bindings;
                        }
                    });
                };
                this.$postLink = () => { };
                this.$onUpdate = () => { };
                this.$onDestroy = () => { };
                this.closeDialog = function () {
                    $mdDialog.hide();
                };
            },
            controllerAs: 'ctrl',
            parent: window['angular'].element(document.body),
            locals: { items: ["test", "test"] },
            template: '<md-dialog aria-label="List dialog">' +
                '  <md-dialog-content>' +
                '    <md-list>{{bindings}}{{$app}}' +
                '      <md-list-item ng-repeat="item in items">' +
                '       <p> {{  item[bindings["Title"]] }} </p>' +
                '    </md-list-item></md-list>' +
                '  </md-dialog-content>' +
                '  <md-dialog-actions>' +
                '    <md-button ng-click="ctrl.closeDialog()" class="md-primary">' +
                '      Close Dialog' +
                '    </md-button>' +
                '  </md-dialog-actions>' +
                '</md-dialog>'
        });
    }
};
AppDialogService = __decorate([
    Service({
        name: '$dialog'
    })
], AppDialogService);
