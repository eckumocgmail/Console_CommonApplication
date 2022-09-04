var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ElementsPaleteComponent = class ElementsPaleteComponent {
    constructor($scope) {
        $scope.app = window['app'];
        $scope.componentsList = window['app'].components.map(c => {
            return {
                label: 'Component ' + c.constructor.name
            };
        });
    }
};
ElementsPaleteComponent = __decorate([
    Component({
        selector: 'elementsPalete',
        template: `
          <div style="padding: 20px;">
        <div >
            <h2>{{title}}</h2>
            <input-search ></input-search>
        </div>
         
        <md-list ng-cloak> 
            <md-list-item ng-repeat="listitem in componentsList" 
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
], ElementsPaleteComponent);
