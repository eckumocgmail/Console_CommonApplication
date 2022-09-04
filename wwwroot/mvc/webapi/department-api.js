function httpGet(url, resolve,reject) {
    const req = new XMLHttpRequest();
    req.open('get', url, true);
    req.onreadystatechange = function () {
        if (req.readyState == 4) {
            if (req.status != 200) {
                console.error(req.responseText);
                reject(req.responseText);
            } else {
                console.log(req.responseText);
                resolve(req.responseText);
            }
        }
    }
    req.send();
}

let api = {
    GetAll( Entity,callback ) {
        let url = '/api/' + Entity + 'ManagmentApi/' + 'GetAll';
        httpGet(url, callback, alert);
    },
}