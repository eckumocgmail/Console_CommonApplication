var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let RetranslatorService = class RetranslatorService {
    constructor() {
    }
    bindEvents($scope, events) {
        const keys = Object.getOwnPropertyNames(events);
        for (let i = 0; i < keys.length; i++) {
            const key = keys[i];
            if (typeof (events[key]) == 'function') {
                $scope.$on(keys[i], function (type, message) {
                    events[key](type, message);
                });
            }
        }
    }
    bindRoot($scope) {
        this.bindEvents($scope, {
            'validate': function (type, message) {
                $scope.$broadcast(type, message);
            },
            'init': function (type, message) {
                console.log('init');
            },
            'destroy': function (type, message) {
                console.log('destroy');
            },
            'selected': function (type, message) {
            },
            'href': function (type, message) {
            }
        });
    }
};
RetranslatorService = __decorate([
    Service({
        name: '$retranslator'
    })
], RetranslatorService);
function AppCtrl($scope, $interpolate, $compile, $injector, $mdPanel, $mdDialog, $mdSidenav, $dialog, $retranslator, $client, $input, $help, $focus, $invoke, $applicationDbContext,   $cssConverter) {
    window['$chartDialog'] = $chartDialog;
    $retranslator.bindRoot($scope);
    $scope.url = '/index.html';
    $scope.window = window;
    $scope.interpolate = (exp) => {
        return $interpolate('{{' + exp + '}}');
    };
    $scope.$mdSidenav = $mdSidenav;
    $scope.comp = function (bindings) {
        return function (data) {
            const res = {};
            const names = Object.getOwnPropertyNames(bindings);
            for (let i = 0; i < names.length; i++) {
                res[names[i]] = $scope.interpolate(bindings[names[i]])(data);
            }
            return res;
        };
    };
    $scope.messages = [];
    $scope.entities = Object.getOwnPropertyNames($applicationDbContext).filter(p => !p.startsWith('$'));
    $scope.viewItem = function (data) {
        return {
            data: data
        };
    };
    $scope.Object = Object;
    $scope.$updater = (modelid) => {
        const id = modelid;
        return function (response) {
            try {
                this.$http({
                    method: 'get',
                    url: '/View/Update?modelId=' + id
                }).catch((e, status) => {
                    console.error(e);
                    console.error(e.status + ' ' + e.statusText);
                    alert(e.status + ' ' + e.statusText + ' ' + JSON.stringify(e));
                }).then((resp) => {
                    if (!resp) {
                        return;
                    }
                    let container = document.getElementById('view-' + id);
                    while (container.childNodes.length > 0)
                        container.removeChild(container.childNodes[0]);
                    let pnode = document.createElement('div');
                    pnode.innerHTML = resp.data;
                    container.appendChild(pnode);
                    function forScripts(p, action) {
                        if (p.tagName == 'SCRIPT') {
                            action(p);
                        }
                        else {
                            if (p.childNodes) {
                                for (let i = 0; i < p.childNodes.length; i++) {
                                    forScripts(p.childNodes[i], action);
                                }
                            }
                        }
                    }
                    forScripts(pnode, (p) => {
                        const scriptNode = document.createElement('script');
                        scriptNode.innerHTML = p.innerHTML;
                        document.body.appendChild(scriptNode);
                    });
                    window['$app'].$compile(pnode)(window['$app'].$scope);
                });
            }
            catch (e) {
                console.error(e);
            }
        };
    };
    $scope.$select = (query) => { return document.querySelector(query); };
    $scope.$trace = (evt) => { console.log(evt); };
    $scope.$injector = $injector;
    $scope['$injector'] = $injector;
    window['$injector'] = $injector;
    $scope['$interpolate'] = $interpolate;
    window['$interpolate'] = $interpolate;
    $scope.app = window['app'];
    $scope.$fasade = $applicationDbContext;
    $scope.$app = window['$app'] = {
        $progress: window['$progress'],
        evalFunction: function (js) {
            console.log(js);
            return eval('(function(){ return ' + js + ';})()');
        },
        $dialog: $dialog,
        $mdPanel: $mdPanel,
        $mdDialog: $mdDialog,
        $cssConverter: $cssConverter,
        $client: $client,
        $input: (id, evt, model, skipHandle) => {
            if (!model) {
                throw new Error('Аргумент model не определён');
            }
            $input.$input(id, evt, model, skipHandle);
        },
        $invoke: $invoke,
        $help: $help,
        $mouseout: (modelid) => { $focus.$mouseout(modelid); },
        $mouseover: (modelid) => { $focus.$mouseover(modelid); },
        $scope: $scope,
        $compile: $compile,
        $applicationDbContext: $applicationDbContext,
        $update(id) {
            return function (response) {
                if (response.status == 200) {
                    $scope.$broadCast('update', {
                        key: id,
                        value: response.data
                    });
                }
                else {
                    alert('Error: ' + response.status + ' ' + response.statausText);
                }
            };
        }
    };
    $scope.$onError = function (err) {
        $scope.messages.push({
            type: 'error',
            text: JSON.stringify(err)
        });
    };
    Object.assign($scope, $scope.$app);
    window['csharp'] = Object.assign({}, $scope);
    function splitCapitalizaId(id) {
        let message = '';
        const upper = id.toUpperCase();
        for (let i = 0; i < id.length; i++) {
            if (i != 0 && id.charCodeAt(i) === upper.charCodeAt(i)) {
                message += ' ';
            }
            message += id[i].toLowerCase();
        }
        const arr = message.split(' ');
        return arr;
    }
    if (window['$progress'])
        window['$progress'].stop();
}
