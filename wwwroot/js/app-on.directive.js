var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
function evalFx(js) {
    console.log(js);
    return eval('(function(){ return ' + js + ';})()');
}
let AppOnDirective = class AppOnDirective {
    constructor($scope, $element, $attrs) {
        try {
            const json = $element[0].getAttribute('on');
            const params = JSON.parse(json);
            const names = Object.getOwnPropertyNames(params);
            for (let i = 0; i < names.length; i++) {
                const exp = params[names[i]];
                const fx = evalFx(exp).bind($scope);
                $scope.$on(names[i], function (event, message) {
                    if (event.targetScope.$id !== $scope.$id) {
                        fx(message);
                    }
                });
            }
        }
        catch (e) {
            console.error(e);
        }
    }
};
AppOnDirective = __decorate([
    Component({
        selector: 'on',
        restrict: 'A',
        transclude: true,
        template: '<div ng-transclude></div>'
    })
], AppOnDirective);
