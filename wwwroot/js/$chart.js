function $chartDialog(model) {
    const script = document.createElement('script');    
    script.innerHTML = `
        (function(){
            const p = document.createElement('div');
            document.body.appendChild(p);
            p.id="view-`+ model.hashcode +`";            
        })();
    `;
    document.body.appendChild(script);
    Highcharts.chart(document.getElementById("view-" + model.hashcode), model);
    const p = popup(pnode.outerHTML);
    p.then((dialogModel) => {
        console.log(dialogModel);
    });
    return p;
}

HTMLElement.prototype.chart = function () {
    try {
        Highcharts.chart(this, JSON.parse(this.innerHTML));
    } catch (e) {
        alert('HTMLElement.prototype.chart exception: '+e);
    }
};















function TitleController() { }
(function () {
    const angular = window['angular'];
    let GetPropertiesType = () => { };
    let GetCShapModel = () => { };
    let NameSpace = window['NameSpace'] = {
        ts: [],
        cs: []
    };
    



    /**
         * Определение типа по данным
         * @param {any} model
         * @param {any} typeName
         */
    function GetTypeScriptType(model, typeName) {
        if (!model)
            return 'any';
        if (model instanceof Array) {
            let result = null;
            let i = 0;
            while (i < model.length) {
                let pType = GetTypeScriptType(model[i], typeName + 'Item')
                if (pType.startsWith('Nullable') == false && pType.startsWith('string')==false) {
                    pType = 'Nullable<' + pType + '>';
                }
                if (pType != 'undefined' && typeof(pType)!='undefined') {
                    //alert('['+pType + '] ' + (pType == 'undefined'));
                    result = 'Array<' + pType + '>';
                    return result;
                }
                i++;
            }
            return 'Array<any>'
        } else if (model instanceof Date) {
            return 'date';
        } else if (typeof (model) == 'number') {
            return 'number';
        } else if (typeof (model) == 'function') {
            return 'function';
        } else if (typeof (model) == 'string') {
            return 'string';
        } else {
            if (model) {
                GetPropertiesType(model, typeName);
                return typeName;
            } else {
                return 'any';
            }

        }
    }

    window['GetTypeScriptType'] = GetTypeScriptType;

    /**
     * Приведение идентификатора к правилу c#
     * @param {any} ids
     */
    function toCapitalStyle(ids) {
        let cap = '';
        for (let i = 0; i < ids.length; i++) {
            cap += ids[i].substr(0,1).toUpperCase() + ids[i].substr(1);
        }
        return cap;
    }

 
    GetPropertiesType = function (model, typeName) {        
        let textBefore = '';
        let res = '\ntype ' + typeName+'= {\n';
        const names = Object.getOwnPropertyNames(model);
        names.forEach(p => {
            const nextTypeName = typeName + p.substr(0,1).toUpperCase()+p.substr(1);
            const realType = GetTypeScriptType(model[p], nextTypeName)
            res += '\t' + p + ': ' + realType + ',\n';
            if (realType == nextTypeName) {
                textBefore += GetPropertiesType(model[p], nextTypeName)+'\n';
            }
            
        });
        NameSpace.ts.push({
            type: typeName,
            code: res
        });
        return textBefore + res + '}\n';

    }







    function GetDefaultValue( realType, defaultValue ) {
        if (realType == "float" || realType == "Nullable<float>") {
            return defaultValue ? defaultValue.toString()+'f' : defaultValue;
        } else if (realType == "string") {
            let textValue = defaultValue.toString().replaceAll('"', "'");
            if (textValue.indexOf('"') != -1) {
                let p = 0;
            }
            return "\"" + textValue + "\"";
        } else if (realType == "DateTime") {
            return "\"" + defaultValue.toString() + "\"";
        } else if (realType == "Action") {
            return "()=>{}";
            //return "\"" + defaultValue.toString() + "\"";
        } else if (realType.indexOf("List") != -1) {

            ///** " + realType + " **/
            let arrayValues = "";
            const elementType = realType.substr(
                realType.indexOf('<') + 1,
                realType.lastIndexOf('>') - realType.indexOf('<')-1);
            for (let i = 0; i < defaultValue.length; i++) {
                arrayValues += GetDefaultValue(elementType,defaultValue[i])+",";
            }
            if (arrayValues.endsWith(',')) {
                arrayValues = arrayValues.substr(0, arrayValues.length - 1);
            }
            arrayValues += "";
            return "new " + realType + "{" + arrayValues+"}";
        } else if (realType == "object") {
            return defaultValue ? "\"" + defaultValue.toString() + "\"" : "null";
        } else {
            if (realType.indexOf('Nullable') == -1) {
                return "new " + realType + "()";
            } else {
                return "new " + realType.substr(realType.indexOf('<') + 1, realType.indexOf('>') - realType.indexOf('<')) + "()";
            }
                
        }
    }




    /**
     * Определение типа по данным
     * @param {any} model
     * @param {any} typeName
     * @test
     * 
     * GetCShapType([
            null, null, null, null, null, 6, 11, 32, 110, 235,
            369, 640, 1005, 1436, 2063, 3057, 4618, 6444, 9822, 15468,
            20434, 24126, 27387, 29459, 31056, 31982, 32040, 31233, 29224, 27342,
            26662, 26956, 27912, 28999, 28965, 27826, 25579, 25722, 24826, 24605,
            24304, 23464, 23708, 24099, 24357, 24237, 24401, 24344, 23586, 22380,
            21004, 17287, 14747, 13076, 12555, 12144, 11009, 10950, 10871, 10824,
            10577, 10527, 10475, 10421, 10358, 10295, 10104, 9914, 9620, 9326,
            5113, 5113, 4954, 4804, 4761, 4717, 4368, 4018
        ],'')
     */
    window['GetCShapType'] = function GetCShapType(model, typeName) {
        if (!model)
            return 'object';
        if (model instanceof Array) {
            let result = null;
            let i = 0;
            while (i < model.length) {
                let pType = GetCShapType(model[i], typeName + 'Item')
                if (pType.startsWith('Nullable') == false && IsNotNullable(pType)) {
                    pType = 'Nullable<' + pType + '>';
                }
                if (pType.indexOf('List') != -1) {
                    let p = 0;
                }
                if (pType != 'undefined' && typeof (pType) != 'undefined') {
                    //alert('[' + pType + '] ' + (pType == 'undefined'));
                    result = 'List<' + pType+'>';
                    return result;
                }
                i++;
            }
            return 'List<object>'
        } else if (model instanceof Date) {
            return 'DateTime';
        } else if (typeof (model) == 'number') {
            return 'float';
        } else if (typeof (model) == 'function') {
            return 'Action';
        } else if (typeof (model) == 'string') {
            return 'string';
        } else {
            if (model) {
                GetCShapModel(model, typeName);
                return typeName;
            } else {
                return 'object';
            }

        }
    }

    /**
     * 
     */
    GetCShapModel = function (model, typeName) {        
        let textBefore = '';
        let res = '\npublic class ' + typeName + ': PaneItem {\n';
        res += '\n\tpublic ' + typeName + '():base(){\n';
        const names = Object.getOwnPropertyNames(model);
        let init = "";
        let properties = "";
        names.forEach(p => {
            const nextTypeName = typeName + p.substr(0, 1).toUpperCase() + p.substr(1);
            const realType = GetCShapType(model[p], nextTypeName);
            const propertyName = toCapitalStyle(p.split('-'));
            const inputType = GetInputType(realType);
            init += "\t\t" + propertyName + '=' + GetDefaultValue(realType, model[p])+";\n";
            if (inputType)
                properties += '\t' + '[Input' + inputType + '("' + p + '")]\n';

            if (realType == 'Action' || realType == 'function') {
                properties += '\n\t' + '[JsonIgnore()]';
                properties += '\n\t' + '[JsonProperty("' + p + '")]\n';

            } else {
                properties += '\n\t' + '[JsonProperty("' + p + '")]\n';
            }
            
            //const parametrizedTypeOfAccessors = 
            properties += '\t' + 'public ' + realType + ' ' + propertyName + '{ get; set; }';//' { get=>Get<' + realType + '>("' + propertyName + '"); set=>Set<' + realType + '>("' + propertyName +'",value); }\n';
            if (realType == nextTypeName) {
                textBefore += GetCShapModel(model[p], nextTypeName) + '\n';
            }
        });
        res += init;
        res += '\n\t}\n\n';
        res += properties;
        if (NameSpace.cs.find((p) => { return p.type == typeName; }) == null) {
            NameSpace.cs.push({
                type: typeName,
                code: res
            });
        }
        

        return textBefore + res + '}\n';

    }



    function IsNotNullable(pType) {
        if ([ 'float', 'DateTime'].indexOf(pType) != -1) {
            return true;
        } else {
            return false;
        }
    }

    


    /**
     * Сопоставление типов модели с типами ввода      
     * @param {any} csharpType
     */
    function GetInputType(csharpType) {

        //array
        if (csharpType.indexOf('List') != -1)
            return null;

        //others
        switch (csharpType) {
            case 'string': return 'Text';
            case 'float': return 'Number';
            case 'DateTime': return 'Date';
            case 'Action': return null;
            case 'object': return null;
        }
        return null;
    }




    /**
     * Генератор моделей диаграммы     
     * Генератор моделей диаграммы     
     */
    if (!window['$chart']) {
        window['$chart'] = {

       
            /**
             * Создание диаграммы
             * @param {any} type
             */
            $updater(modelid) {

               
                return function (id, model) {
                 

                    let req = new XMLHttpRequest();
                    let url = '/HighchartsGenerator/OnInit?type=' + modelid;
                    req.open('post', url, false);
                    
 
                    req.send( );

                    if (req.readyState == 4) {
                        if (req.status != 200) {
                            console.error('Ошибка при выполнении запроса: ' + url);
                            alert('Ошибка при выполнении запроса: ' + url);
                            throw new Error('Ошибка при выполнении запроса: ' + url);
                        } else {
                            const responseText = req.responseText;
                            console.log(responseText);
                            let viewComponentModel = JSON.parse(responseText);
                            return Highcharts.chart(id, viewComponentModel);
                        }
                    }

                    
                }
                return Highcharts.chart(id, model);
            },

            /**
             * Создание диаграммы
             * @param {any} type
             */
            $generator(type) {

                const CSTypeName = 'Highchart' + toCapitalStyle(type.split('-'));
                return function (id, model) {
                    window['model'] = model;
                    if (arguments.length < 2) {
                        model = id;
                        id = 'container';
                    }

                    console.log('Исходные данные: ');
                    console.log(model);

                    console.log('\n Тип: ');
                    const scriptType = GetPropertiesType(model, CSTypeName);
                    console.log(scriptType);

                    const modelType = GetCShapModel(model, CSTypeName);
                    console.log(modelType);

                    let req = new XMLHttpRequest();
                    let url = '/Highcharts/OnInit?type=' + type;
                    req.open('post', url, true);
                    req.onreadystatechange = function () {
                        if (req.readyState == 4) {
                            if (req.status != 200) {
                                console.error('Ошибка при выполнении запроса: ' + url);
                                alert('Ошибка при выполнении запроса: ' + url);
                            } else {
                                req = new XMLHttpRequest();
                                url = '/Highcharts/OnUpdate?type=' + CSTypeName;
                                return;
                                if (!confirm('Проверить?'))
                                    return;
                                req.open('post', url, true);
                                req.onreadystatechange = function () {
                                    if (req.readyState == 4) {
                                        if (req.status != 200) {
                                            console.error('Ошибка при выполнении запроса: ' + url);
                                        } else {
                                            const viewComponentModel = JSON.parse(req.responseText);
                                            Highcharts.chart(id, model);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    NameSpace.ns = CSTypeName;
                    req.send(JSON.stringify(NameSpace));



                    return Highcharts.chart(id, model);
                }
            },


          
        }
    }
})();


