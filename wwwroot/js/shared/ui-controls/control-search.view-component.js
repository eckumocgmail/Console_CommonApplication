var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ControlSearchViewComponent = class ControlSearchViewComponent {
    constructor($scope, $element, $attrs, $http) {
        this.ctrl = this;
        this.query = '';
        this.href = '';
        this.$scope = null;
        this.$element = null;
        this.$attrs = null;
        this.$http = null;
        this.date = null;
        this.minDate = null;
        this.maxDate = null;
        this.label = 'Введите дату';
        console.log('search', $scope);
        Object.assign($scope, this);
        Object.assign(this, {
            $scope: $scope,
            $element: $element,
            $attrs: $attrs,
            $http: $http
        });
    }
    $onInit() {
        console.log('$onInit', this);
        this.$scope.change = function () {
            this.$onScopeChanged();
        };
        const ctrl = this;
        console.log('search query' + this.$scope.query);
        if (!this.$scope.query)
            this.$scope.query = '';
        this.$scope.search = function () {
        };
        this.$scope.onClick = function () {
            alert(ctrl.href + '/Search?query=' + ctrl.query);
        };
        this.$element[0].onkeypress = function (evt) {
            console.log(evt);
            if (evt.key == 'Enter') {
                ctrl.$scope.search(ctrl.$scope.query);
            }
        };
        this.$element[0].oninput = function (evt) {
            ctrl.$http({
                url: ctrl.$attrs.href + '/OnInput',
                params: {
                    query: evt.target.value
                }
            }).then((resp) => {
                console.log(resp.data);
                ctrl.$scope.options = resp.data;
            });
        };
    }
    onDateChanged() {
        this.$scope.$emit('changed', this.date);
    }
    $onChanges() {
        Object.assign(this.$scope, this.ctrl);
        console.log(this);
    }
    $onScopeChanged() {
    }
};
ControlSearchViewComponent = __decorate([
    Component({
        selector: 'search',
        input: ['query', 'href'],
        template: `
        <div style="width: 100%; padding: 10px;
                    display: flex; flex-direction: row; flex-wrap: nowrap; 
                    align-items: baseline; j
                    ustify-content: baseline; ">

            <input class="form-control" list="inputSearchOptions-{{$id}}" type="text"    
                   ng-model="query"
                    placeholder="Поиск" aria-label="Search" autofocus="true"
                    style="top: 0px; left: 0px; width: 100%;">

            <button class="btn btn-primary my-2 my-sm-0" type="submit" ng-click="onClick()"> поиск </button>
       
            <datalist id="inputSearchOptions-{{$id}}">    
                <option>test</option>
                <option ng-repeat="option in options" value="{{ option }}"> 
                    {{ option }}
                </option>                
            </datalist>
        </div>
    `
    })
], ControlSearchViewComponent);
