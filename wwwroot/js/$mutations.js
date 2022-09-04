(function () {
    if (!window['$mutations']) {
        window['$mutations'] = function (pnodeOrId, handle) {
            let p = null;
            if (typeof (pnodeOrId) == 'string') {
                p = document.getElementById(pnodeOrId);
            } else if (!(pnodeOrId instanceof HTMLElement)) {
                throw new Error('Аргумент pnodeOrId не является экземпляром типа HTMLElement ');
            } else {
                p = pnodeOrId;
            }

            var handle = null;
            let observer = new MutationObserver(mutationRecords => {
                console.log(mutationRecords); // console.log(изменения)
                if (handle) {
                    handle(mutationRecords);
                }
            });

            // наблюдать за всем, кроме атрибутов
            observer.observe(elem, {
                childList:              true,   // наблюдать за непосредственными детьми
                subtree:                true,   // и более глубокими потомками
                characterDataOldValue:  true    // передавать старое значение в колбэк
            });
            return function (callback) {
                handle = callback;
            }            
        }
    }
})();