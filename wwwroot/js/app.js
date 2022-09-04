//$app.$client.$connection.invoke('Recieve',JSON.stringify({ Action: 'eval', Args: {}}))

function ReturnNine(){
    return 9;
}

function respondResult(serialkey, resp) {
    return window['$app']['$client'].$connection.invoke("ReturnEvalResult", JSON.stringify({
        serialkey: serialkey,
        response: resp
    }));
}

window['returnEvalResult'] = function returnEvalResult(serialkey, message) {
    
     
    

    alert('eval: '+message);
    let result = eval(message, window);
    alert('result: '+result);
    if (result) {
        if (result instanceof Promise) {
            alert('result is Promise');
            result.then(
                (resp) => {
                    respondResult(serialkey, resp).then((s) => {
                        alert('respondResult success '+s);
                    });
                },
                (er) => {
                    alert('error: '+er);
                }
            );
        } else {

            alert('result is not Promise');
            respondResult(serialkey, result).then(console.log);
        }
    }
}
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
window['spec'] = {};


// Write your JavaScript code.
(function () {

     
    
    let refresh = null;
    let append = [];
    let debug = false;
    
     
    Object.assign(this, {

        $active: true,

        //регистрация в контейнере
        $append(message) {
            if (!this.$connection) {
                append.push(message);
            } else {
                return this.$connection.invoke('Append', JSON.stringify(message));
            }
        },

        //сборка мусора
        $refresh(message) {
            if (!message) return;
            if (!this.$connection || this.$connection.state != 'Connected') {

                refresh = message;
            } else {

                return this.$connection.invoke('Refresh', JSON.stringify({ Views: message.Views })).then((resp) => {
                    message.oncomplete();
                });
            }
        },

        //установка соединения
        $connect(uri) {
            if (debug)
                console.log('signalr connecting to: ' + uri);
     
            const ctrl = this;
            const signalR = window['signalR'];
            if (location.origin.startsWith('file'))
                uri = location.origin+'/hubs/user-agents';
            const connection = new signalR.HubConnectionBuilder()
                .withUrl(uri)                                
                .build();
            connection.serverTimeoutInMilliseconds = 10000000;
            this.$connection = connection;            
            async function start() {
                try {
                    await connection.start().then(function () {
                        if (debug) console.log('signalr connected to: ' + uri);                        
                        window['$signalrClient'].$onConnectedCallback(connection)();                        
                    }).catch((err) => {
                        alert(err);
                    });
                    if (debug)
                        console.log("SignalR Connected.");
                } catch (err) {
                    console.log(err);                  
                }
            };

            connection.onclose(() => {
                setTimeout(start);                
            });

            // Start the connection.
            start();
            return connection;
        },


        //действие после установки соединения
        $onConnectedCallback(connection) {
            const ctrl = this;
            
            ctrl.$connection = connection;
            ctrl.$connection.on('eval', function (message) {                
                try {
                    console.log('пытаюсь выполнить: ' + message);
                    eval(message, window);
                } catch (er) {
                    console.error(er);
                }
            });
            
 
            console.log(connection);
            $queue.start();
            return function () {
                if (debug)
                    console.log('signalr connectionstate: ' + connection.state);                               
                 
                setTimeout(() => {
                    while (append.length > 0) {
                        const appendOptions = append.shift();
                        ctrl.$append(appendOptions);
                    }
                    if (refresh) {
                        const p = refresh;
                        refresh = null;
                        ctrl.$refresh(refresh);
                    }
                    
                    //ctrl.$checkout(ctrl.$onChangesCallback());
                }, 50);
            };
        },


        //проверка наличия изменений
        $checkout(resolve) {           
            console.log('$checkout begin');
            const ctrl = this;
            if (ctrl.$connection && ctrl.$connection.state == 'Connected') { 
                
                if (ctrl.$active) {
                  
                    try {
                        ctrl.$connection.invoke('Checkout', '' + ctrl.$time().toString())
                            .then((r) => { alert(e); return r;})
                            .then((changes) => {

                                console.log('$checkout responsed');
                                resolve(changes);

                                console.log('$checkout completed');
                                if (ctrl.$active) {
                                    //setTimeout(() => {
                                    //    ctrl.$checkout(resolve);
                                    //}, 128);
                                } else {

                                }
                            }
                        );
                    } catch (e) {
                        alert(e);
                    }
                    
                } else {
                    //setTimeout(() => {
                     //   ctrl.$checkout(resolve);
                   // }, 64);
                }
            }
        },

        //применение изменений
        $onChangesCallback() {
            const ctrl = this;
            return function (json) {                
                let changes = null;
                try {
                    changes = JSON.parse(json);
                } catch (e) {
                    alert('Исключение разбора JSON внутри функции $onChangesCallback' + e.message || e.toString());
                }

                if (debug)
                    console.log('signalr $onChangesCallback(): changes=', changes);
                const names = Object.getOwnPropertyNames(changes);
                for (let i = 0; i < names.length; i++) {                    
                    if (changes[names[i]] && changes[names[i]] != '' && changes[names[i]] != ' ' && changes[names[i]] != '\n' && changes[names[i]] != '\r' && changes[names[i]] != '\t') {
                        if (ctrl.debug) {
                            if (window.confirm('do update view: ' + names[i] + ' ' + changes[names[i]] + '? ')) {
                                ctrl.$update(names[i],changes[names[i]]);
                            }
                        } else {
                            ctrl.$update(names[i], changes[names[i]]);
                        }
                                               
                    }
                    
                }
            };
        },


        //обновление контента
        $update(id, type) {
            if (debug)
                console.log('$update ' + type+' #view-'+id );
            const ctrl = this;
            let container = document.getElementById('view-' + id);
            if (!container) {
                
                if (document.readyState == 'complete') {
                    container = document.getElementById('view-' + id);
                    if (container) {
                        ctrl.$update(id);
                    }
                    else {
                        ctrl.$connection.stop();
                        console.warn('Не удалось обновить представление ' + type + ' т.к. не найден узел контейнера #view-'+id);
                    }
                }
                else {
                    document.addEventListener('load', () => {
                        ctrl.$update(id);
                    });
                }
            }
            else {


                const started = new Date().getTime();
                console.log('$update('+id+','+type+')');
                try {
                    window['$http']({
                        method: 'get',
                        url: '/View/Update?modelId=' + id
                    }).catch((e, status) => {
                        console.error(e);
                        console.error(e.status + ' ' + e.statusText);
                        alert(e.status + ' ' + e.statusText + ' ' + JSON.stringify(e));
                    }).then((resp) => {
                        const completed = new Date().getTime();
                        const timems = completed - started;
                        /*console.log('запрос выполнялся '+timems+' мс \n' + JSON.stringify({
                            method: 'get',
                            url: '/View/Update?modelId=' + id
                        }));*/
                        if (!resp) {
                            alert('Ответное сообщение пустое \n' + JSON.stringify({
                                method: 'get',
                                url: '/View/Update?modelId=' + id
                            }));
                            return;
                        }
                        if (debug)
                            console.log(resp);
                        let doUpdate = false;
                        if (ctrl.debug) {
                            
                                doUpdate = true;
                            
                        } else {
                            doUpdate = true;
                        }
                        if (doUpdate) {

                            //удаление дочерних узлов
                            while (container.childNodes.length > 0)
                                container.removeChild(container.childNodes[0]);

                            //добавление полученного контента
                            let pnode = document.createElement('div');
                            pnode.innerHTML = resp;
                            container.appendChild(pnode);

                            //поиск и компиляция скриптов
                            function forScripts(p, action) {
                                
                                if (p.tagName == 'SCRIPT') {
                                    action(p);
                              
                                } else {
                                    if (p.childNodes) {
                                        for (let i = 0; i < p.childNodes.length; i++) {
                                            forScripts(p.childNodes[i], action);
                                        }
                                    }
                                }
                            }
                            
                            

                            window['$app'].$compile(pnode)(window['$app'].$scope);
                            forScripts(pnode, (p) => {
                                const scriptNode = document.createElement('script');
                                scriptNode.innerHTML = p.innerHTML;                                
                                container.appendChild(scriptNode);
                                 
                            });
                        }
                    });
                } catch (e) {
                    console.error(e);
                }
            }
        },
        $time() {
            return new Date().getTime();
        }
    });


    window['$signalrClient'] = this;   
    this.$timestamp = this.$time();
    setTimeout(() => {
        if (!debug) {
            window['$signalrClient'].$connection = window['$signalrClient'].$connect('/hubs/user-agents');
        } else {
            if (window.confirm('start?')) {
                window['$signalrClient'].$connection = window['$signalrClient'].$connect('/hubs/user-agents');
            }
        }
    }, 100);




    //обновление через глобальный контекст
    window['checkout'] = function () {
        //$signalrClient.$checkout($signalrClient.$onChangesCallback());
        console.log('checkout begin');
        const started = new Date().getTime();
        if (!$signalrClient.$connection ||
             $signalrClient.$connection.state !== 'Connected') {
            return new Promise(function (resolve, reject){
                $queue.push(function () {
                    $signalrClient.$connection.invoke('Checkout', '' + $signalrClient.$time().toString()).then((resp) => {
                        resolve(resp);
                        return resp;
                    });
                });
            });
        }
        
        $signalrClient.$connection.invoke('Checkout', '' + $signalrClient.$time().toString())          
            .then((changes) => {
                
                const commited = new Date().getTime();
                const timems = commited - started;
                console.log('операция checkout выполнялась ' + timems+' мс');
                $signalrClient.$onChangesCallback()(changes);                
                console.log('checkout complete');
        });
    }
})();
