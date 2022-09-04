 
if (!window['parse']) {
    window['parse'] = function (form) {
        const data = {};
        function handle(pnode) {
            if (pnode.name) {
                data[pnode.name] = pnode.value;
                if (pnode.name) {
                    data[pnode.name] = (pnode.type && pnode.type == 'checkbox') ? pnode.checked : pnode.value;

                }
            }
            if (pnode.childNodes) {
                for (let i = 0; i < pnode.childNodes.length; i++) {
                    handle(pnode.childNodes[i]);
                }
            }
        }
        handle(form);
        return data;
    }
}

if (!window['parseForIds']) {
    window['parseForIds'] = function (form) {
        const data = {};
        function handle(pnode) {
            if (pnode.name) {
                data[pnode.name] = pnode.id;
            }
            if (pnode.childNodes) {
                for (let i = 0; i < pnode.childNodes.length; i++) {
                    handle(pnode.childNodes[i]);
                }
            }
        }
        handle(form);
        return data;
    }
}


function init(id, json) {
    const $app = window['$app'];
    $app.$ctrl.$init(id, json);
    $app.$scope.$apply();
}

//выполнение зарегистриронной операции через запрос по http
function execute(container, procedure, complete) {
    if (!complete)
        throw new Error('Функция обработки результата выполнения запроса не задана');

    const req = new XMLHttpRequest();
    req.open('POST', '/View/Execute?container=' + container + '&procedure=' + procedure, true);
    req.onreadystatechange = function () {
        if (req.readyState == 4) {
            if (req.status == 200) {
                console.log(req.responseText);
                complete(req.responseText);
            } else {
                //alert(req.status + ": " + req.statusText);
                console.error(req.status + ": " + req.statusText);
            }
        }
    };
    req.send();
}

//выполнение зарегистриронной операции через запрос по http
function request(url, callback ) {

    const req = new XMLHttpRequest();
    req.open('GET', url, true);
    req.onreadystatechange = function () {
        if (callback) {
            callback(req);
        }
    };
    req.send();
}

//выполнение зарегистриронной операции через запрос по http
function todo(code, complete) {
    if (!complete)
        throw new Error('Функция обработки результата выполнения запроса не задана');

    const req = new XMLHttpRequest();
    req.open('POST', '/View/Todo?code='+code, true);
    req.onreadystatechange = function () {
        if (req.readyState == 4) {
            if (req.status == 200) {
                console.log(req.responseText);
                complete(req.responseText);
            } else {
                //alert(req.status + ": " + req.statusText);
                console.error(req.status + ": " + req.statusText);
            }
        }
    };
    req.send();
}


//асинхронное выполнение пост-запроса
function post(url, complete) {
    const req = new XMLHttpRequest();

    req.open('POST', url, true);
    req.onreadystatechange = function () {
        if (req.readyState == 4) {

            if (req.status == 200) {
                complete(req.responseText);
            } else {
                //alert(req.status + ": " + req.statusText);
                console.error(req.status + ": " + req.statusText);
            }
        }
    };
    req.send();
}

//передача события
function publishEvent(event) {
    console.log(event);
    event.preventDefault();
    switch (event.type) {
        case 'input':
            input(event);
            break;
        case 'click':
            click(event);
            break;
    }

}



/**
 * Выполняется по событию клика мыши по элементам с явно указанным атритутом action 
 **/
function click(event) {
    console.log(event.target.outerHTML);
    let paction = event.target;
    while (!paction.getAttribute('action') && paction && paction !== document.body) {
        paction = paction.parentNode;
    }
    if (!paction.getAttribute('action')) {
        console.log('exit');
        return;
    }

    let p = event.target;
    while (!p.id || !(p.id + '').startsWith('view-')) {
        p = p.parentNode;
    }

    const modelId = (p.id + '').substr('view-'.length);
    //console.log(modelId);
    let eventType = event.type;

    url = '/UserPage';
    parameters = {
        modelId: modelId,
        eventType: eventType,
        eventArgs: {
            action: paction.getAttribute('action'),
            params: event.target.getAttribute('params')
        }
    };

    complete = function (response) {
        console.log('changes');
        const changes = JSON.parse(response).Changes;
        for (let i = 0; i < changes.length; i++) {
            const id = 'view-' + changes[i];
            console.log(changes[i]);
            update(id);
        }
    };

    const req = new XMLHttpRequest();
    console.log(url + '?q=' + JSON.stringify(parameters));
    req.open('POST', url + '?q=' + JSON.stringify(parameters), true);
    req.onreadystatechange = function () {
        if (req.readyState == 4) {

            if (req.status == 200) {
                complete(req.responseText);
            } else {
                //alert(req.status + ": " + req.statusText + " " + req.responseText);
                console.error(req.status + ": " + req.statusText + " " + req.responseText);
            }
        }
    };
    req.send();
}


/**
 * Выполняется по событию ввода 
 */
function input(event) {
    let p = event.target;
    while (!p.id || !(p.id + '').startsWith('view-')) {
        p = p.parentNode;
    }

    const modelId = (p.id + '').substr('view-'.length);

    let eventType = event.type;
    let value = null;
    if (event.target.type == 'checkbox') {
        value = event.target.checked;
    } else {
        value = event.target.value;
    }
    url = '/UserPage';
    parameters = {
        modelId: modelId,
        eventType: eventType,
        eventArgs: value
    };
    complete = function (response) {

        const changes = JSON.parse(response).Changes;
        for (let i = 0; i < changes.length; i++) {
            const id = 'view-' + changes[i];
            console.log(changes[i]);
            update(id);
        }
    };
    const req = new XMLHttpRequest();
    req.open('POST', url + '?q=' + JSON.stringify(parameters), true);
    req.onreadystatechange = function () {
        if (req.readyState == 4) {

            if (req.status == 200) {
                complete(req.responseText);
            } else {
                //alert(req.status + ": " + req.statusText);
                console.error(req.status + ": " + req.statusText);
            }
        }
    };
    req.send();
}
</script>