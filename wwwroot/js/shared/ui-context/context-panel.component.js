var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let ContextPanelComponent = class ContextPanelComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $contextMenu) {
        super($scope, $element, $attrs, $injector);
        this.style = {
            display: 'block',
            position: 'fixed',
            left: '200px',
            top: '200px'
        };
        this.hidden = true;
        this.properties = { id: 1 };
        this.contextMenuPosition = {
            x: '0px',
            y: '0px'
        };
        window['context'] = this;
        ContextMenuComponent.initiallized = true;
        this.$contextMenu = $contextMenu;
    }
    getter() {
        const p = this;
        return function () {
            return p;
        };
    }
    $onChanges() {
        Object.assign(this.$scope, this.ctrl);
    }
    $onDestroy() {
        console.log('destroy');
    }
    onClick() {
    }
    open(x, y, model) {
        this.style.display = 'block';
        this.style.left = x;
        this.style.top = y;
        Object.assign(this.$scope, this.ctrl);
        const p = {};
        this.properties = Object.assign({}, model);
        this.$scope.$apply();
        Object.assign(document.getElementById('mdListContainer').style, this.style);
    }
    close() {
        this.style.display = 'none';
        Object.assign(document.getElementById('mdListContainer').style, this.style);
    }
    $onInit() {
        super.$onInit();
        Object.assign(this.$scope, this.ctrl);
        const ctrl = this;
        this.$contextMenu.component = this.getter();
        document.getElementById('mdListContainer').onmouseleave = function () {
            ctrl.close();
        };
        window['' + this.$element[0].id] = this;
    }
    $onScopeChanged() {
    }
};
ContextPanelComponent.initiallized = false;
ContextPanelComponent = __decorate([
    Component({
        selector: 'contextPanel',
        restrict: 'E',
        transclude: true,
        template: `   
        <div style="z-index: 1;" >   
          
          <div>               
             
            <md-button class="md-raised md-primary">
                <div ng-transclude></div>
            </md-button>
          </div>
        </ul>        
    `
    })
], ContextPanelComponent);
