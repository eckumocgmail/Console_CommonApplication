var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let MaterialFormComponent = class MaterialFormComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $compile) {
        super($scope, $element, $attrs, $injector);
        alert(1);
        $scope.user = {
            title: 'Developer',
            email: 'ipsum@lorem.com',
            firstName: '',
            lastName: '',
            company: 'Google',
            address: '1600 Amphitheatre Pkwy',
            city: 'Mountain View',
            state: 'CA',
            biography: 'Loves kittens, snowboarding, and can type at 130 WPM.\n\nAnd rumor has it she bouldered up Castle Craig!',
            postalCode: '94043'
        };
        $scope.states = ('AL AK AZ AR CA CO CT DE FL GA HI ID IL IN IA KS KY LA ME MD MA MI MN MS ' +
            'MO MT NE NV NH NJ NM NY NC ND OH OK OR PA RI SC SD TN TX UT VT VA WA WV WI ' +
            'WY').split(' ').map(function (state) {
            return { abbrev: state };
        });
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
};
MaterialFormComponent = __decorate([
    Component({
        selector: 'materialForm',
        template: `
        <div layout="column" ng-cloak class="md-inline-form">

          <md-content md-theme="docs-dark" layout-gt-sm="row" layout-padding>
            <div>
              <md-input-container>
                <label>Title</label>
                <input ng-model="user.title">
              </md-input-container>

              <md-input-container>
                <label>Email</label>
                <input ng-model="user.email" type="email">
              </md-input-container>
            </div>
          </md-content>

          <md-content layout-padding>
            <div>
              <form name="userForm">

                <div layout-gt-xs="row">
                  <md-input-container class="md-block" flex-gt-xs>
                    <label>Company (Disabled)</label>
                    <input ng-model="user.company" disabled>
                  </md-input-container>

                  <md-input-container>
                    <label>Enter date</label>
                    <md-datepicker ng-model="user.submissionDate" aria-label="Enter date"></md-datepicker>
                  </md-input-container>
                </div>

                <div layout-gt-sm="row">
                  <md-input-container class="md-block" flex-gt-sm>
                    <label>First name</label>
                    <input ng-model="user.firstName">
                  </md-input-container>

                  <md-input-container class="md-block" flex-gt-sm>
                    <label>Long Last Name That Will Be Truncated And 3 Dots (Ellipsis) Will Appear At The End</label>
                    <input ng-model="theMax">
                  </md-input-container>
                </div>

                <md-input-container class="md-block">
                  <label>Address</label>
                  <input ng-model="user.address">
                </md-input-container>

                <md-input-container md-no-float class="md-block">
                  <input ng-model="user.address2" placeholder="Address 2" aria-label="Address 2">
                </md-input-container>

                <div layout-gt-sm="row">
                  <md-input-container class="md-block" flex-gt-sm>
                    <label>City</label>
                    <input ng-model="user.city">
                  </md-input-container>

                  <md-input-container class="md-block" flex-gt-sm>
                    <label>State</label>
                    <md-select ng-model="user.state">
                      <md-option ng-repeat="state in states" value="{{state.abbrev}}">
                        {{state.abbrev}}
                      </md-option>
                    </md-select>
                  </md-input-container>

                  <md-input-container class="md-block" flex-gt-sm>
                    <label>Postal Code</label>
                    <input name="postalCode" ng-model="user.postalCode" placeholder="12345"
                           required ng-pattern="/^[0-9]{5}$/" md-maxlength="5">

                    <div ng-messages="userForm.postalCode.$error" role="alert" multiple>
                      <div ng-message="required" class="my-message">You must supply a postal code.</div>
                      <div ng-message="pattern" class="my-message">That doesn't look like a valid postal
                        code.
                      </div>
                      <div ng-message="md-maxlength" class="my-message">
                        Don't use the long version silly...we don't need to be that specific...
                      </div>
                    </div>
                  </md-input-container>
                </div>

                <md-input-container class="md-block">
                  <label>Biography</label>
                  <textarea ng-model="user.biography" md-maxlength="150" rows="5" md-select-on-focus></textarea>
                </md-input-container>

              </form>
            </div>
          </md-content>

        </div>        
    `,
        input: ['active']
    })
], MaterialFormComponent);
let MaterialIconFormComponent = class MaterialIconFormComponent extends XmlDocumentBuilder {
    constructor($scope, $element, $attrs, $injector, $compile) {
        super($scope, $element, $attrs, $injector);
        $scope.user = {
            name: 'John Doe',
            email: '',
            phone: '',
            address: 'Mountain View, CA',
            donation: 19.99
        };
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
};
MaterialIconFormComponent = __decorate([
    Component({
        selector: 'materialIconForm',
        template: `
    <style>
 
.inputdemoIcons {
  /*
.right-icon {
  position: absolute;
  top: 4px;
  right: 2px;
  left: auto;
  margin-top: 0;
}
*/ }
  .inputdemoIcons .inputIconDemo {
    min-height: 48px; }
  .inputdemoIcons md-input-container:not(.md-input-invalid) > md-icon.email {
    color: green; }
  .inputdemoIcons md-input-container:not(.md-input-invalid) > md-icon.name {
    color: dodgerblue; }
  .inputdemoIcons md-input-container.md-input-invalid > md-icon.email,
  .inputdemoIcons md-input-container.md-input-invalid > md-icon.name {
    color: red; }
    </style>
        <div layout="column" layout-padding ng-cloak>

          <br/>
          <md-content class="md-no-momentum">
            <md-input-container class="md-icon-float md-block">
              <!-- Use floating label instead of placeholder -->
              <label>Name</label>
              <md-icon class="name">person</md-icon>
              <input ng-model="user.name" type="text">
            </md-input-container>

            <md-input-container md-no-float class="md-block">
              <md-icon>phone</md-icon>
              <input ng-model="user.phone" type="text" placeholder="Phone Number" aria-label="Phone Number">
            </md-input-container>

            <md-input-container class="md-block">
              <!-- Use floating placeholder instead of label -->
              <md-icon class="email">email</md-icon>
              <input ng-model="user.email" type="email" placeholder="Email (required)" ng-required="true"
                     aria-label="Email (required)">
            </md-input-container>

            <md-input-container md-no-float class="md-block">
              <input ng-model="user.address" type="text" placeholder="Address" aria-label="Address">
              <md-icon style="display:inline-block;">place</md-icon>
            </md-input-container>

            <md-input-container class="md-icon-float md-icon-right md-block">
              <label>Donation Amount</label>
              <md-icon>card</md-icon>
              <input ng-model="user.donation" type="number" step="0.01">
              <md-icon>euro</md-icon>
            </md-input-container>

          </md-content>

        </div>
    `,
        input: ['active']
    })
], MaterialIconFormComponent);
