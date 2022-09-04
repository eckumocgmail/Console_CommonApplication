var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let JITComponent = class JITComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $compile, $rootScope) {
        super($scope, $element, $attrs, $injector);
        this.template = '{{$id}}';
        this.$compile = $compile;
        window['jit'] = this;
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
        const ctrl = this;
        $scope.html = '';
        $rootScope.$on('selected', (evt, message) => {
            console.log('selected', message);
            let tag = window['app'].components.find(p => p.constructor.name == message.type).options.selector;
            const ids = splitCapitalizaId(tag);
            tag = ids.reduce((s1, s2) => { return s1 + '-' + s2; });
            const xml = '<' + tag + '></' + tag + '>';
            $scope.html += xml;
            ctrl.update();
        });
    }
    update() {
        console.log('update');
        const pnode = document.createElement('div');
        pnode.innerHTML = this.$scope.html || '';
        this.$element[0].appendChild(pnode);
        this.$compile(pnode)(this.$scope);
        this.$compile(this.template)(this.$scope.$new());
    }
    $onChanges() {
        Object.assign(this.$scope, this.ctrl);
        this.update();
    }
};
JITComponent = __decorate([
    Component({
        selector: 'jit',
        input: ['model', 'template'],
        template: ``
    })
], JITComponent);
let SubmitComponent = class SubmitComponent {
    constructor($scope, $element, $attrs, $http) {
        $element[0].addEventListener('click', function () {
            console.log('clicked');
            let p = $element[0];
            while (p != document.body && p.tagName != 'FORM') {
                p = p.parentElement;
            }
            console.log(p.outerHTML);
            $http({
                url: 'https://localhost:44355/MyGroups/Create',
                method: 'post',
                params: p
            }).then(console.log);
        });
    }
};
SubmitComponent = __decorate([
    Component({
        selector: 'submit',
        template: `<div ng-transclude></div>     
    `
    })
], SubmitComponent);
