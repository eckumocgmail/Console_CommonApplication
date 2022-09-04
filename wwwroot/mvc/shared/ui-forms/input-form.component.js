






@Component({
    selector: 'inputForm',
    input: ['properties','exclude','title'],
    template: `  {{names}}
        {{ctrl.properties}}
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
class InputFormComponent extends ComponentPrototype {
      
    title = 'Заполните форму';      
    service: any;  
    proxy: any;
    editors: any = {};
    inputForm: any = {
        controls: {
        }
    };
    
    editable = false;
    enabled = false;
    complete = false;
    validated = null;

    names: string[] = [];
    exclude: string[] = [];
    actions: { [property: string]: (message: object) => any } = {};
    messages: { [property: string]: any } = {};
    errors: { [property: string]: any } = {};
    descriptors: any;
  
    properties: any = {
        username: 'admin',
        password: 'eckumoc'
    };


    constructor($scope, $element, $attrs, $injector, $inputForm) {
        super($scope, $element, $attrs, $injector);
        const ctrl = this;       
        $scope.$on('input', (evt,message) => {     
            
            ctrl.set(message);
        });
        window['form'] = this;
        this.service = $inputForm;
        
        this.validated = {
            emit(message) {
                ctrl.$scope.$emit('validated',message);
            },
            broadcast(message) {
                ctrl.$scope.$broadcast('validated',message);
            }
        }
        class Person {

            @inputTypes.number(true,0,1)
            id: number = 0.5;

            @controlTypes.selectbox(['table', 'list', 'grid'])
            type: string = 'table';

            @controlTypes.radiogoup(['green', 'blue', 'red'])
            color: string = 'green';

            @controlTypes.checkbox()
            editable: boolean = false;
             
        }
        this.properties = new Person();
        this.$update();
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
        } catch (e) {
            console.error(e);
            alert('form input service $onChanges()'+e);
        }
        
    }


    // наследование на уровне прототипов
    public extend(ref: any, proto: any) {
        let pref = ref;
        while (pref.__proto__.constructor.name !== 'Object') {
            pref = pref.__proto__;
        }
        const temp = pref.__proto__;
        pref.__proto__ = proto;
        proto.__proto__ = temp;
    }

    /**
     * обновление прототипа редактора
     */
    $update() {

        const ctrl = this;
        this.inputForm.controls = {};
        this.descriptors = {};
        const formGroup = {};
        if (!this.properties) {
            this.names = [];

        } else {
            //console.log( this.properties );
            //console.log( this.properties.__descriptor__ );
            if (!this.properties.__descriptor__) {
                ctrl.extend(this.properties, { __descriptor__: {} });
            }
            console.log(this.properties);

            let names = Object.getOwnPropertyNames(this.properties)
                .filter(key => { return key !== '__descriptor__'; });
            if (ctrl.exclude)
                names = names.filter(n => ctrl.exclude.indexOf(n) === -1)
            //alert(JSON.stringify(this.properties['__descriptor__']));
            for (let i = 0; i < names.length; i++) {

                this.inputForm.controls[names[i]] = {
                    status: 'waiting'
                };
                /**
                 * если тип элемента ввода явно не указан в описании свойств __description__, то
                 * при наличии значения(или ссылки), тип определяется по логическому имени свойства
                 * например 'password: string' будет определен тип ввода password в противном случае
                 * анализиется тип данных,
                 * если значение не определено и нет явных указаний в __description__ то
                 * появляется исключительная ситуация когда ввода данных невозможен
                 */
                const name = names[i];

                ctrl.descriptors[name] = Object.assign(
                    this.service.getDescription(this.properties, name),
                    {
                        options: Object.getOwnPropertyDescriptor(this.properties, name),
                        model: this.service.getInputModel(this.properties, name),
                        validators: this.service.getValidators(this.properties, name),

                    });


                // если тип элемента явно не указан, то определяем по логическому наименованию свойства
                if (typeof (ctrl.descriptors[name].model) === 'undefined') {
                    const descriptor = inputTypes[name.toLocaleLowerCase()];
                    if (descriptor) {
                        descriptor()(this.properties, name);
                        ctrl.descriptors[name].model = this.service.getInputModel(this.properties, name);
                    }
                }

                // определение по данным
                if (typeof (ctrl.descriptors[name].model) === 'undefined') {
                    if (typeof (this.properties[name]) === 'undefined') {
                        console.warn('property ' + name + ' not declared its type of input and not define value and name logical not match any types of input');
                    } else {
                        const type = this.service.getType(this.properties, name);

                        let annotationFn = null;
                        if (type) {
                            annotationFn = inputTypes[type] || controlTypes[type] || structureTypes[type];
                        } else {
                            throw new Error('not type for property: [' + name + '] value: ' + this.properties[name]);
                        }
                        if (annotationFn) {//throw new Error('no annotation function for type: '+type);
                            annotationFn()(this.properties, name);
                        } else if (typeof (this.properties[name]) === 'object') {
                            //alert( 'not annotationFn for '+name+' value: '+this.properties[name]);
                            if (this.properties[name] instanceof Array) {
                                if (this.properties[name].length > 0) {
                                    if (typeof (this.properties[name][0]) === 'object') {
                                        const prototype = Object.assign({}, this.properties[name][0]);
                                        structureTypes.array(prototype)(this.properties, name);
                                    } else {
                                        const elementType = this.service.getType(this.properties[name], 0);
                                        structureTypes.arrayOfPrimitive(elementType)(this.properties, name);
                                    }
                                } else {
                                    console.warn('array element type unknown');
                                }
                            } else {
                                structureTypes[typeof (this.properties[name])]()(this.properties, name);
                            }
                        }
                    }
                }
                // console.log( this.properties );
                ctrl.descriptors[name].model = this.service.getInputModel(this.properties, name);
                if (typeof (ctrl.descriptors[name].model) === 'undefined') {
                    this.enabled = false;
                    //console.log(ctrl.properties );
                    //console.log(ctrl.descriptors[name]);
                    //throw new Error('can not create input elements for property ' + name + '');
                } else {
                    if (!ctrl.descriptors[name].validators) { ctrl.descriptors[name].validators = []; }
                    ctrl.descriptors[name].validators.push(function (value) { if (!ctrl.enabled) { throw new Error('editing is disabled'); } });
                }
                
            }

            this.proxy = validators.create(this.properties);
            //this.createPropertiesForm();
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


    /** метод ввода данных */
    set(event) {

        console.log(this.properties);


        //console.log( event );
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
          

        } catch (e) {
            console.log(e);
            this.errors[event.target.name] = this.errors[event.target.name].concat((e && e.message) ? JSON.parse(e.message) : e ? JSON.parse(e) : ('Unknown error while set property: ' + event.target.name));
            
        } finally {
            
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


    /** выполнение проверки всех свойств */
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
                    } catch (e) {
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



}


 








