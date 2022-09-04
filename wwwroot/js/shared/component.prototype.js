class ComponentPrototype {
    constructor($scope, $element, $attrs, $injector) {
        this.Object = Object;
        this.design = false;
        const ctrl = this;
        Object.assign(this, {
            ctrl: ctrl,
            $scope: $scope,
            $element: $element,
            $attrs: $attrs,
            $injector: $injector
        });
        $scope.ctrl = this;
        $scope.$on(console.log);
    }
    onUpdate(message) {
        console.log(message);
        console.log(message);
        console.log(message);
        console.log(message);
        console.log(message);
    }
    $onInit() {
        this.$scope.$emit({
            event: 'init',
            source: this
        });
    }
    $onDestroy() {
        this.$scope.$emit({
            event: 'destroy',
            source: this
        });
    }
    $onChanges(changes) {
        console.log('$onChanges');
        Object.assign(this.$scope, this.ctrl);
    }
    $trace(evt) {
        console.log(evt);
    }
}
class XmlDocumentBuilder extends ComponentPrototype {
    reset() {
    }
}
class MyPropertyModel extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector) {
        super($scope, $element, $attrs, $injector);
        this.validators = [];
        this.errors = [];
        this.hints = [];
    }
}
