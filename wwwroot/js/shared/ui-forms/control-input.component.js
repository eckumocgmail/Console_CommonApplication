var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ControlInputField = class ControlInputField extends ComponentPrototype {
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
        console.log(this);
        if (this.$scope[this.ctrl.name + 'InputFieldForm']) {
            this.$scope[this.ctrl.name + 'InputFieldForm'][this.ctrl.name] = this.$scope.errors;
        }
    }
};
ControlInputField = __decorate([
    Component({
        selector: 'controlInputField',
        input: ['name', 'properties', 'descriptors', 'errors', 'messages', 'state', 'theme'],
        template: ` 
    <form name="{{name}}InputFieldForm">
        <md-input-container class="md-block">                
            <div>{{descriptors[name].model.display||name}}</div>
            <md-icon>
                <i class="material-icons">email</i>
            </md-icon>
            
            <md-checkbox #checkbox name="{{name}}" checked="{{properties[name]}}" style="width: 100%;"
                ng-if="descriptors[name].model && descriptors[name].model.type=='control' && descriptors[name].model.input=='checkbox'">
                <label> {{ descriptors[name].label||name }} {{ checkbox.value }} </label>
            </md-checkbox>
                
            <md-select placeholder="{{name}}"
                       ng-if="descriptors[name].model && descriptors[name].model.type=='control' && descriptors[name].model.input=='selectbox'"
                       ng-model="properties[name]"   
                       style="width: 100%;"
                       ng-change="set({target:{ name: name, value: $event.value }})">
                <md-option ng-repeat="option in descriptors[name].model.options"
                           ng-value="option">
                {{ option }}
                </md-option>
            </md-select>

            <md-radio-group ng-model="selected" 
                            style="display: flex; flex-direction: row; flex-wrap: wrap; width: 100%;"
                            ng-if="descriptors[name].model && descriptors[name].model.type=='control' && descriptors[name].model.input=='radiogroup'">
              <md-radio-button  ng-repeat="option in descriptors[name].model.options" ng-value="option" aria-label="{{option}}" style="padding: 10px;">
                {{ option }}
              </md-radio-button>
            </md-radio-group>
            
        </md-input-container>    
    </form>
    `
    })
], ControlInputField);
