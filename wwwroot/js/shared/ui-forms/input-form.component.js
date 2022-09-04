var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
let InputFormComponent = class InputFormComponent extends ComponentPrototype {
    constructor($scope, $element, $attrs, $injector, $inputForm) {
        super($scope, $element, $attrs, $injector);
        this.title = 'Заполните форму';
        this.editors = {};
        this.inputForm = {
            controls: {}
        };
        this.editable = false;
        this.enabled = false;
        this.complete = false;
        this.validated = null;
        this.names = [];
        this.exclude = [];
        this.actions = {};
        this.messages = {};
        this.errors = {};
        this.properties = {
            username: 'admin',
            password: 'eckumoc'
        };
        window['form'] = this;
        const ctrl = this;
        $scope.$on('input', (evt, message) => {
            ctrl.set(message);
        });
        window['form'] = this;
        this.service = $inputForm;
        this.validated = {
            emit(message) {
                ctrl.$scope.$emit('validated', message);
            },
            broadcast(message) {
                ctrl.$scope.$broadcast('validated', message);
            }
        };
        class Person {
            constructor() {
                this.id = 0.5;
                this.type = 'table';
                this.color = 'green';
                this.editable = false;
            }
        }
        __decorate([
            inputTypes.number(true, 0, 1)
        ], Person.prototype, "id", void 0);
        __decorate([
            controlTypes.selectbox(['table', 'list', 'grid'])
        ], Person.prototype, "type", void 0);
        __decorate([
            controlTypes.radiogoup(['green', 'blue', 'red'])
        ], Person.prototype, "color", void 0);
        __decorate([
            controlTypes.checkbox()
        ], Person.prototype, "editable", void 0);
        this.properties = new Person();
        this.$update();
        Object.assign($scope, this);
    }
    getActionNames() {
        return Object.getOwnPropertyNames(this.actions);
    }
    $onInit() {
        console.log('$onInit', this);
        this.$onChanges();
    }
    $onChanges() {
        Object.assign(this.$scope, this.ctrl);
        console.log(this.$scope);
        try {
            this.$update();
        }
        catch (e) {
            console.error(e);
            alert('form input service $onChanges()' + e);
        }
    }
    extend(ref, proto) {
        let pref = ref;
        while (pref.__proto__.constructor.name !== 'Object') {
            pref = pref.__proto__;
        }
        const temp = pref.__proto__;
        pref.__proto__ = proto;
        proto.__proto__ = temp;
    }
    $update() {
        const ctrl = this;
        this.inputForm.controls = {};
        this.descriptors = {};
        const formGroup = {};
        if (!this.properties) {
            this.names = [];
        }
        else {
            if (!this.properties.__descriptor__) {
                ctrl.extend(this.properties, { __descriptor__: {} });
            }
            console.log(this.properties);
            let names = Object.getOwnPropertyNames(this.properties)
                .filter(key => { return key !== '__descriptor__'; });
            if (ctrl.exclude)
                names = names.filter(n => ctrl.exclude.indexOf(n) === -1);
            for (let i = 0; i < names.length; i++) {
                this.inputForm.controls[names[i]] = {
                    status: 'waiting'
                };
                const name = names[i];
                ctrl.descriptors[name] = Object.assign(this.service.getDescription(this.properties, name), {
                    options: Object.getOwnPropertyDescriptor(this.properties, name),
                    model: this.service.getInputModel(this.properties, name),
                    validators: this.service.getValidators(this.properties, name),
                });
                if (typeof (ctrl.descriptors[name].model) === 'undefined') {
                    const descriptor = inputTypes[name.toLocaleLowerCase()];
                    if (descriptor) {
                        descriptor()(this.properties, name);
                        ctrl.descriptors[name].model = this.service.getInputModel(this.properties, name);
                    }
                }
                if (typeof (ctrl.descriptors[name].model) === 'undefined') {
                    if (typeof (this.properties[name]) === 'undefined') {
                        console.warn('property ' + name + ' not declared its type of input and not define value and name logical not match any types of input');
                    }
                    else {
                        const type = this.service.getType(this.properties, name);
                        let annotationFn = null;
                        if (type) {
                            annotationFn = inputTypes[type] || controlTypes[type] || structureTypes[type];
                        }
                        else {
                            throw new Error('not type for property: [' + name + '] value: ' + this.properties[name]);
                        }
                        if (annotationFn) {
                            annotationFn()(this.properties, name);
                        }
                        else if (typeof (this.properties[name]) === 'object') {
                            if (this.properties[name] instanceof Array) {
                                if (this.properties[name].length > 0) {
                                    if (typeof (this.properties[name][0]) === 'object') {
                                        const prototype = Object.assign({}, this.properties[name][0]);
                                        structureTypes.array(prototype)(this.properties, name);
                                    }
                                    else {
                                        const elementType = this.service.getType(this.properties[name], 0);
                                        structureTypes.arrayOfPrimitive(elementType)(this.properties, name);
                                    }
                                }
                                else {
                                    console.warn('array element type unknown');
                                }
                            }
                            else {
                                structureTypes[typeof (this.properties[name])]()(this.properties, name);
                            }
                        }
                    }
                }
                ctrl.descriptors[name].model = this.service.getInputModel(this.properties, name);
                if (typeof (ctrl.descriptors[name].model) === 'undefined') {
                    this.enabled = false;
                }
                else {
                    if (!ctrl.descriptors[name].validators) {
                        ctrl.descriptors[name].validators = [];
                    }
                    ctrl.descriptors[name].validators.push(function (value) { if (!ctrl.enabled) {
                        throw new Error('editing is disabled');
                    } });
                }
            }
            this.proxy = validators.create(this.properties);
            this.names = names;
            this.enabled = true;
            this.validated.emit(this.validate());
        }
        setTimeout(() => {
            ctrl.refresh();
        }, 100);
    }
    refresh() {
        const ctrl = this;
        this.names.forEach(name => {
            ctrl.set({ target: { name: name, value: ctrl.properties[name] } });
        });
    }
    set(event) {
        console.log(this.properties);
        if (!event || !event.target || !event.target.name) {
            throw new Error('event not define target element with name');
        }
        try {
            this.errors[event.target.name] = [];
            this.properties[event.target.name] =
                this.descriptors[event.target.name].model && this.descriptors[event.target.name].model.type === 'checkbox' ?
                    event.target.checked :
                    event.target.value;
            console.log('emit onstate');
            this.$scope.$emit('onstate', this.properties);
        }
        catch (e) {
            console.log(e);
            this.errors[event.target.name] = this.errors[event.target.name].concat((e && e.message) ? JSON.parse(e.message) : e ? JSON.parse(e) : ('Unknown error while set property: ' + event.target.name));
        }
        finally {
            this.validated.emit(this.validate());
            this.validated.broadcast();
            console.log(this.errors);
            if (this.properties.update) {
                this.properties.update();
            }
            if (event && event.preventDefault)
                event.preventDefault();
            if (event && event.stopPropagation)
                event.stopPropagation();
        }
    }
    validate() {
        const ctrl = this;
        let count = 0;
        this.names.forEach(name => {
            ctrl.errors[name] = [];
            const validators = ctrl.properties.__descriptor__[name].validators;
            if (validators) {
                validators.forEach(validator => {
                    try {
                        validator.bind(ctrl.properties)(ctrl.properties[name]);
                    }
                    catch (e) {
                        ctrl.errors[name].push(e);
                        count++;
                    }
                });
            }
            ctrl.inputForm.controls[name].status = (ctrl.errors[name].length > 0) ? 'INVALID' : 'VALID';
        });
        this.inputForm.status = (count !== 0) ? 'VALID' : 'INVALID';
        return count == 0 ? false : true;
    }
};
InputFormComponent = __decorate([
    Component({
        selector: 'inputForm',
        input: ['properties', 'exclude', 'title'],
        template: ` 
        <div layout="column" layout-padding ng-cloak><br/>
            <div ng-transclude></div>
            <div ng-repeat="name in names" class="input-group">           
                <primitive-input-field  
                    ng-if="descriptors[name].model.type=='primitive'"
                    errors="errors"
                    messages="messages"                   
                    name="name" properties="properties" descriptors="descriptors">
                </primitive-input-field>     
                <control-input-field  
                    ng-if="descriptors[name].model.type=='control'"
                    errors="errors"
                    messages="messages"                   
                    name="name" properties="properties" descriptors="descriptors">
                </control-input-field>     

            </div>    
        </div>
`
    })
], InputFormComponent);
