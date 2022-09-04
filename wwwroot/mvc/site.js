if (!window['notify']) {
    window['notify'] = function (text, type) {
        const notifcationsContainer = document.getElementById('notifications-block');
        if (!notifcationsContainer)
            throw new Error("Not found block withid: 'notifications-block' ");
        if (!type)
            type = 'info';
        const e = document.createElement('div');
        e.classList.add('alert');
        e.classList.add('alert-' + type);
        e.innerHTML = text;
        notifcationsContainer.appendChild(e);
    };
    const AppConfigProperties = window['AppConfigProperties'] ={
        hub: location.origin + '/UserAgentsHub'
    };
    const $context = window['$context'] =window['contextmenu'] = {
        open(id) {
            const element = document.getElementById(id);
            if (event && event.preventDefault)
                event.preventDefault();
            const all = document.querySelectorAll('.view-component-menu');
            for (let i = 0; i < all.length; i++) {
                all[i].setAttribute('hidden', 'true');
            }
            if (!element) {
                alert('Элемент контекстного меню не задан');
            }
            else {
                var state = (!event) ? new Object() : event;
                if (!event) {
                    state['clientX'] = 100;
                    state['clientY'] = 100;
                }
                element.style.position = 'fixed';
                element.style.display = 'flex';
                element.style.left = (state['clientX'] - 25) + 'px';
                element.style.top = (state['clientY'] - 25) + 'px';
                element.removeAttribute('hidden');
            }
        },
        close(element) {
            element.style.display = 'none';
            const all = document.querySelectorAll('.view-component-menu');
            for (let i = 0; i < all.length; i++) {
                all[i]['style']['display'] = 'none';
            }
        }
    };
    window['ProgressComponent'] = class ProgressComponent {
        constructor() {
            const progressTemplate = `
                <div class='view'>
                    <div id='when-wait'></div>
                    <div id='when-progress'></div>
                    <div id='when-abort'></div>
                </div>
            `;
            function addProgressEventModel() {
                function setWaitView() {
                    if (document.getElementById('when-progress') &&         document.getElementById('when-wait')) {
                        document.getElementById('when-progress').style.display = 'none';
                        document.getElementById('when-progress').style.height = '0%';
                        document.getElementById('when-progress').style.width = '0%';
                        document.getElementById('when-wait').style.display = 'block';
                        document.getElementById('when-wait').style.height = '100%';
                        document.getElementById('when-wait').style.width = '100%';
                    }
                }
                function setProgressView() {
                    if (document.getElementById('when-progress') && document.getElementById('when-wait')) {
                        document.getElementById('when-wait').style.display = 'none';
                        document.getElementById('when-wait').style.height = '0%';
                        document.getElementById('when-wait').style.width = '0%';
                        document.getElementById('when-progress').style.display = 'block';
                        document.getElementById('when-progress').style.height = '100%';
                        document.getElementById('when-progress').style.width = '100%';
                    }
                }
                window.addEventListener('progress', function (event) {
                    console.log(event.type);
                    setProgressView();
                }, true);
                window.addEventListener('wait', function (event) {
                    setWaitView();
                    console.log(event.type);
                }, true);
                window.onload = function () {
                    setWaitView();
                };
            }
            addProgressEventModel();
        }
    }
    window['SidenavComponent'] = class SidenavComponent {
        constructor() {
            function addSideNavEventModel() {
                var sideLeft = document.getElementById('sideLeft');
                window.addEventListener('side', function () {
                    sideLeft.style.display = sideLeft.style.display == 'none' ?
                        'block' : 'none';
                }, true);
            }
            addSideNavEventModel();
        }
    }
    var apis = window['apis'] = {
        progress: new ProgressComponent(),
        side: new SidenavComponent(),
        notify: {
            info: function (text) { window['notify'](text, 'info'); },
            success: function (text) { window['notify'](text, 'success'); },
            error: function (text) { window['notify'](text, 'danger'); },
            warning: function (text) { window['notify'](text, 'warning'); }
        },
        https: https,
        get contextmenu() { return window['contextmenu']; },
        get dialog() { return window['dialog']; }
    };

}
