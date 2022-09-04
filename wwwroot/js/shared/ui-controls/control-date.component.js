var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ControlDateComponent = class ControlDateComponent {
    constructor($scope, $element, $attrs) {
        this.ctrl = this;
        this.$scope = null;
        this.$element = null;
        this.$attrs = null;
        this.date = null;
        this.minDate = null;
        this.maxDate = null;
        this.label = 'Введите дату';
        $element[0].$ctrl = this;
        Object.assign(this, {
            $scope: $scope,
            $element: $element,
            $attrs: $attrs
        });
    }
    onDateChanged() {
        this.$scope.$emit('changed', this.date);
    }
    $onInit() {
        console.log('$onInit', this);
        this.$scope.change = function () {
            this.$onScopeChanged();
        };
    }
    $onChanges() {
        Object.assign(this.$scope, this.ctrl);
        console.log(this);
    }
    $onScopeChanged() {
    }
};
ControlDateComponent = __decorate([
    Component({
        selector: 'controlDate',
        input: ['minDate', 'maxDate', 'date'],
        output: ['changed'],
        template: ` 
        <md-content layout-padding layout-margin>
            <md-datepicker ng-model="ctrl.date" 
                           md-open-on-focus
                           md-min-date="ctrl.minDate"
                           md-max-date="ctrl.maxDate"
                           ng-change="ctrl.onDateChanged()"
                           md-placeholder="{{label}}">
            </md-datepicker>
            {{ctrl.myDate | date:shortDate}}
        </md-content>
`
    })
], ControlDateComponent);
