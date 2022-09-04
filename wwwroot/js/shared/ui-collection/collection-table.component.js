var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let CollectionTableComponent = class CollectionTableComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $mdDialog) {
        super($scope, $element, $attrs, $injector);
        this.listitems = [];
        this.keywords = [];
        this.binding = {
            label: 'id',
            image: 'id'
        };
        const ctrl = this;
        $scope.append = function (item) {
            $scope.$emit('selected', {
                type: item.label,
                value: item.checked
            });
        };
        $scope.$on('input', function (k, v) {
            ctrl.keywords = [];
            for (let i = 0; i < ctrl.listitems.length; i++) {
                const item = ctrl.listitems[i];
                item.hidden = v.target.value && item.label.toLowerCase().indexOf(v.target.value.toLowerCase()) == -1 ? true : false;
                if (!item.hidden) {
                    ctrl.keywords.push(item.label);
                }
            }
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
CollectionTableComponent = __decorate([
    Component({
        selector: 'jsList',
        input: ['title', 'dataset', 'binding'],
        template: `    

    <div style="padding: 20px;">
        <div >
            <h2>{{title}}</h2>
            <input-search ></input-search>
        </div>
         
        <md-list ng-cloak> 
            <md-list-item ng-repeat="listitem in listitems" 
                          ng-hide="listitem.hidden"
                        class="noright">
                <img alt="{{ listitem.data[binding['label']] }}" 
                        ng-src="{{ listitem.data[binding['image']] }}" 
                        ng-if="listitem.data[binding['image']]"
                        class="md-avatar" />
                <md-checkbox class="md-primary" 
                             ng-model="listitem.data[binding['checked']]"
                             ng-change="append(listitem)">
                </md-checkbox>
                <p>{{ listitem.label }}</p>

                <i class="material-icons md-secondary md-hue-3" >
                 
                </i>
                <md-icon class="md-secondary"  aria-label="Chat"></md-icon>
            </md-list-item>
        </md-list>    
    </div>    
`
    })
], CollectionTableComponent);
