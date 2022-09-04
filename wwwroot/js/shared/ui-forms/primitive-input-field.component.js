var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let PrimitiveInputFieldComponent = class PrimitiveInputFieldComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $inputForm) {
        super($scope, $element, $attrs, $injector);
        const ctrl = this;
        this.service = $inputForm;
        $element[0].oninput = function (evt) {
            $scope.$emit('input', evt, evt);
        };
        $scope.$on('validated', function (evt) {
            $scope.state = evt.targetScope.ctrl.errors[ctrl.name].length > 0 ? 'INVALID' : 'VALID';
            $scope.$apply();
        });
    }
    $onChanges() {
        Object.assign(this.$scope, this.ctrl);
        if (this.$scope[this.ctrl.name + 'InputFieldForm']) {
            this.$scope[this.ctrl.name + 'InputFieldForm'][this.ctrl.name] = this.$scope.errors;
        }
    }
};
PrimitiveInputFieldComponent = __decorate([
    Component({
        selector: 'primitiveInputField',
        input: ['name', 'properties', 'descriptors', 'errors', 'messages', 'state', 'theme'],
        template: `
    <form name="{{name}}InputFieldForm">
        <md-input-container class="md-block">    
            <div>{{descriptors[name].model.display||name}}</div>
            <md-icon>
                <i class="material-icons">email</i>
            </md-icon>

            <input value="{{properties[name]}}" 
                   class="md-invalid"
                   name="{{name}}"
                   ng-if="descriptors[name].model.input!=='date'"
                   type="{{descriptors[name].model.input}}"
                   placeholder="{{name}}" (required)" ng-required="true"
                   aria-label="{{name}}" (required)">
            <input value="{{service.getInputValue( properties[name], descriptors[name] )}}"
                   name="{{name}}"
                    class="md-invalid"
                   ng-if="descriptors[name].model.input==='date'"
                   type="{{descriptors[name].model.input}}"
                   placeholder="{{name}}" (required)" ng-required="true"
                   aria-label="{{name}}" (required)">
            <div ng-messages="this[name+'InputFieldForm'][name].$error">
                <md-error ng-if="errors[name] && errors[name].length>0">
                    <div ng-repeat="error in errors[name]"> {{ error.message || error }} </div>
                </md-error>
                <md-hint ng-if="messages[name] && messages[name].length>0"         color="accent">
                    <div ng-repeat="hint in messages[name]" color="accent">  {{ hint }} </div>
                </md-hint>
            </div>
        
        </md-input-container>    
    </form>
 
 
    `
    })
], PrimitiveInputFieldComponent);
