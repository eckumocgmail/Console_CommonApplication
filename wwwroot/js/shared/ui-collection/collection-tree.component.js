var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let CollectionTreeComponent = class CollectionTreeComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $mdDialog) {
        super($scope, $element, $attrs, $injector);
        this.title = 'Новый элемент';
        this.level = 1;
        this.item = {};
        this.children = {};
        this.$scope = $scope;
        $scope.model = {};
    }
    $onInit() {
    }
    $onChanges(changes) {
        console.log(changes);
        Object.assign(this.$scope, this.ctrl);
    }
};
CollectionTreeComponent = __decorate([
    Component({
        selector: 'collectionTree',
        transclude: true,
        input: ['item', 'level', 'title', 'children'],
        template: `
 
        <div>       
            <div ng-if="level==1"  style="padding-left: 20px; padding-top: 20px;">
                <h2>{{ Item.Label }}</h2>
                <search></search>
            </div>
            <div ng-if="level!=1" style="padding-left: 10px;">
                <md-list ng-cloak> 
                    <md-list-item class="noright">
                    <img class="md-avatar" ng-if="item.Image" ng-src="{{ item.Image }}"/>            
                    <md-checkbox ng-if="item.Selectable" class="md-primary" 
                                 ng-model="item.Selected"></md-checkbox>                     
                    <p>{{ item.Label }}</p>
                    <i class="material-icons md-secondary md-hue-3" > account_tree </i>
                    <md-icon class="md-secondary"  aria-label="Chat"></md-icon>
                    </md-list-item>
                </md-list>
 
                <collection-tree ng-repeat="pchild in item.children" 
                                 item="pchild.item" title="'asd'" 
                                 level="level+1" children="pchild.children" >   
                </collection-tree>
            </div>
        </div>
    `
    })
], CollectionTreeComponent);
