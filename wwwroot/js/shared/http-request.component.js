var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let HttpRequestComponent = class HttpRequestComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $interpolate, $compile) {
        super($scope, $element, $attrs, $injector);
        this.url = '/DatabaseEditor/MessageProtocol/List';
        this.params = {};
        this.headers = {};
        this.options = {};
        this.method = 'get';
        this.model = null;
        this.pnode = document.createElement('div');
        this.$compile = $compile;
        this.$interpolate = $interpolate;
        const ctrl = this;
        $scope.$on('onstate', function (type, message) {
            console.log(message.url);
            $scope.model = Object.assign({}, message);
            Object.assign($scope, $scope.model);
            ctrl.update();
        });
        $scope.ctrl = ctrl;
        ctrl.model = this.copy(this, ['url', 'method']);
    }
    copy(target, properties) {
        const result = {};
        for (let i = 0; i < properties.length; i++) {
            result[properties[i]] = target[properties[i]];
        }
        return result;
    }
    $onInit() {
        const span = document.createElement('span');
        span.appendChild(this.pnode);
        this.$element[0].appendChild(span);
        this.update();
    }
    update() {
        const ctrl = this;
        const req = new XMLHttpRequest();
        req.open(ctrl.$scope.method, ctrl.$scope.url, true);
        req.setRequestHeader('ajax', 'true');
        if (this.headers) {
            Object.getOwnPropertyNames(this.headers).forEach((name) => {
                req.setRequestHeader(name, ctrl.headers[name]);
            });
        }
        req.onreadystatechange = function () {
            if ((ctrl.$scope.readyState = req.readyState) == 4) {
                if (req.status == 200) {
                    ctrl.updateHtml(req.responseText);
                }
                else {
                    ctrl.$scope.responseText = '';
                    ctrl.$scope.pnode.innerHTML = ctrl.$interpolate('<div class="alert alert-danger">{{status}}{{statusText}}</div>')(req);
                }
            }
        };
        req.send();
    }
    updateHtml(responseText) {
        const container = this.$scope.pnode;
        while (container.childNodes.length > 0)
            container.removeChild(container.childNodes[0]);
        let pnode = document.createElement('div');
        pnode.innerHTML = responseText;
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
            container.appendChild(scriptNode);
        });
        this.$compile(pnode)(this.$scope);
        forScripts(pnode, (p) => {
            const scriptNode = document.createElement('script');
            scriptNode.innerHTML = p.innerHTML;
            container.appendChild(scriptNode);
        });
        setTimeout(() => {
            forScripts(pnode, (p) => {
                const scriptNode = document.createElement('script');
                scriptNode.innerHTML = p.innerHTML;
                container.appendChild(scriptNode);
            });
        }, 2500);
    }
};
__decorate([
    structureTypes.object()
], HttpRequestComponent.prototype, "options", void 0);
__decorate([
    controlTypes.selectbox(['get', 'post'])
], HttpRequestComponent.prototype, "method", void 0);
HttpRequestComponent = __decorate([
    Component({
        selector: 'httpRequest',
        transclude: false,
        input: ['url', 'params', 'headers'],
        template: `<div style="width: 640px;"></div>`
    })
], HttpRequestComponent);
