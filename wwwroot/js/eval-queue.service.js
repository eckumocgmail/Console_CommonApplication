if (!window['AsyncExecutor'])
window['AsyncExecutor'] = class AsyncExecutor {
    constructor() {
        this.stack = {};
    }
    put(fx) {
        let p = null;
        this.stack[p = this.generateKey()] = fx;
        return p;
    }
    take(key) {
        let p = this.stack[key];
        delete this.stack[key];
        return p;
    }
    generateKey() {
        let key = this.next();
        while (this.stack[key]) {
            key = this.next();
        }
        return key;
    }
    next() {
        let key = '';
        for (let i = 0; i < 10; i++) {
            key += Math.random() * 10;
        }
        return key;
    }
}
if (!window['EvalQueueService'])
    window['EvalQueueService']=class EvalQueueService {
   
    constructor() {
        this.sequence = [];
    }
    start() {
        while (this.sequence.length > 0) {
            this.sequence.shift();
        }
    }
    push(fx) {
        const isEmpty = this.sequence.length == 0;
        this.sequence.push(fx);
        if (isEmpty) {
            this.start();
        }
    }
}
if (!window['$queue'])
    var $queue = window['$queue'] = new EvalQueueService();
