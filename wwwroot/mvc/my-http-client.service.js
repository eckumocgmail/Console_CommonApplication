class MyHttpClient {
    request(opt) {
        function toQueryString(p) {
            let q = '?';
            const names = Object.getOwnPropertyNames(p);
            for (let i = 0; i < names.length; i++) {
                q += names[i] + '=' + p[names[i]] + '&';
            }
            return q;
        }
        return new window['Promise'](function (resolve, reject) {
            const req = new XMLHttpRequest();
            let url = opt.url;
            if (opt.params) {
                url += toQueryString(opt.params);
            }
            req.open(opt.method ? opt.method : 'get', url, true);
            if (opt.headers) {
                for (let i = 0; i < opt.headers.length; i++) {
                    req.setRequestHeader(opt.headers[i].key, opt.headers[i].value);
                }
            }
            req.onreadystatechange = function () {
                function showInfo(text) {
                    text += JSON.stringify(opt) + '\n';
                    text += JSON.stringify({
                        status: req.status,
                        text: req.statusText,
                        type: req.responseType,
                        message: req.responseText
                    }) + '\n';
                    window['notify'](text, 'info');
                    reject(req.responseText);
                }
                function showError(text) {
                    text += JSON.stringify(opt) + '\n';
                    text += JSON.stringify({
                        status: req.status,
                        text: req.statusText,
                        type: req.responseType,
                        message: req.responseText
                    }) + '\n';
                    window['notify'](text, 'danger');
                    reject(req.responseText);
                }
                if (req.readyState == 4) {
                    try {
                        switch (req.status) {
                            case 200: {
                                if (req.getResponseHeader('Content-Type') == 'text/xml') {
                                    let text = null;
                                    if (!req.responseText || req.responseText.length == 0) {
                                        text = "{}";
                                    }
                                    else {
                                        text = req.responseText;
                                    }
                                    const mes = JSON.parse(text);
                                    resolve(mes);
                                }
                                else {
                                    let text = null;
                                    if (!req.responseText || req.responseText.length == 0) {
                                        text = "{}";
                                    }
                                    else {
                                        text = req.responseText;
                                    }
                                    const mes = JSON.parse(text);
                                    resolve(mes.Result);
                                }
                                console.log("HTTP-request success executed");
                                console.log(JSON.stringify(opt));
                                break;
                            }
                            case 300: {
                                showInfo('HTTP-request redirecting');
                                break;
                            }
                            case 400: {
                                showError('HTTP-request redirecting is not correct');
                                break;
                            }
                            case 401: {
                                showError('HTTP-request failed because required authorization');
                                break;
                            }
                            case 403: {
                                showInfo('HTTP-request failed because no permissions for executing');
                                break;
                            }
                            case 404: {
                                showError('HTTP-request failed because resource not founded');
                                break;
                            }
                            case 405: {
                                showError('HTTP-request failed because this method is not allowed');
                                break;
                            }
                            case 500: {
                                showError('HTTP-request failed because server has public error');
                                break;
                            }
                            default: showError('HTTP-request failed because server has public error');
                        }
                    }
                    catch (e) {
                        console.error("Error while handling http-response");
                        console.error(JSON.stringify(opt));
                        console.error(e);
                    }
                }
            };
            try {
                req.send();
            }
            catch (e) {
                console.error("Error while handling http-response");
                console.error(JSON.stringify(opt));
                console.error(e);
            }
        });
    }
    get(url, params) {
        const ctrl = this;
        const promise = ctrl.request({ url: url, method: 'get', params: params });
        promise.then((response) => {
            console.log(response);
            if (response) {
                return response.Result;
            }
            else {
                alert('ERROR: ' + url + '\n' + JSON.stringify(params) + '\n' + JSON.stringify(response));
            }
        }, (err) => {
            if (err instanceof ErrorEvent) {
                alert(err.message);
            }
            else if (err instanceof Error) {
                alert(err.name + ': ' + err.message);
            }
            else {
                alert(err);
            }
            return err;
        });
        promise.catch((err) => {
            if (err instanceof ErrorEvent) {
                alert(err.message);
            }
            else if (err instanceof Error) {
                alert(err.name + ': ' + err.message);
            }
            else {
                alert(err);
            }
            return err;
        });
        return promise;
    }
}
