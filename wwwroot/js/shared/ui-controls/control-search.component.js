var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ControlSearchComponent = class ControlSearchComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $mdDialog) {
        super($scope, $element, $attrs, $injector);
        this.title = 'search';
        this.results = [];
        this.options = [];
        this.binding = {
            label: 'id',
            image: 'id'
        };
        $scope.$on('input', function (k, v) {
            $scope.$apply();
        });
    }
    $onInit() {
        super.$onInit();
        this.$scope.title = 'Components';
    }
    $onChanges() {
        super.$onChanges();
        console.log(this);
    }
};
ControlSearchComponent = __decorate([
    Component({
        selector: 'controlSearch',
        input: ['query', 'options', 'href'],
        template: `
        control search {{$id}} {{options}} {{href}}
        <div style="width: 100%; padding: 10px;
                    display: flex; flex-direction: row; flex-wrap: nowrap; 
                    align-items: baseline; j
                    ustify-content: baseline; ">

            <input class="form-control" list="inputSearchOptions-{{$id}}" type="text"    
                   ng-model="query"
                   placeholder="Поиск" aria-label="Search" autofocus="true"
                   style="top: 0px; left: 0px; width: 100%;">

            <button class="btn btn-primary my-2 my-sm-0" type="submit" ng-click="onClick()"> поиск </button>
                       <b ng-repeat="option in options"  > 
                    {{ option }}
                </b>
            <datalist id="inputSearchOptions-{{$id}}">    
                <option>test</option>
                <option ng-repeat="option in options" value="{{ option }}"> 
                    {{ option }}
                </option>                
            </datalist>
        </div>
    `
    })
], ControlSearchComponent);
