function getArgumentNames ( code ) {
    const js = code.toString();
    const i1 = js.indexOf('(');
    const i2 = js.indexOf(')');
    return js.substring(i1 + 1, i2).split(',').map(name => name.trim());
}

(function () {
    class AppRoot {
        $bootstrap() {
           
            console.log('$bootstrap();');

            //const html = document.head.parentElement;
            //html.setAttribute('ng-app', window['app'].appName);
            //html.setAttribute('ng-controller', window['app'].appName + 'Ctrl');


            if (!angular)
                alert('AngularJS not defined');
            const deps = window['app'].modules.concat(window['app'].deps.concat(this.$build()));
            const appName = window['app'].appName;
            console.log(deps);
           

            window['app'].app = angular.module(appName, deps, () => {
                console.log(appName+" loaded");
            });
      
            window['app'].app.controller('AppCtrl', AppCtrl);
            window['app'].app.config(function ($mdThemingProvider) {
                $mdThemingProvider.theme('default')
                    .primaryPalette('indigo')
                    .warnPalette('red')
                    .backgroundPalette('grey')
                    .accentPalette('orange');
            });
            console.log('appName=' + appName);
           
        }
        $build() {
            console.log('$build();');
            const shared = window['angular'].module('shared', window['app'].modules);
            const mapped = ['shared'];
            for (let i = 0; i < window['app'].controllers.length; i++) {
                const ctrlName = window['app'].controllers[i].constructor.name;
                console.log(ctrlName);

                shared.controller(ctrlName, window['app'].controllers[i].constructor);
            }
            for (let i = 0; i < window['app'].services.length; i++) {
                const ctrlName = window['app'].services[i].options.name;
                console.log(ctrlName);

                shared.service(ctrlName, window['app'].services[i].constructor);
            }
            for (let i = 0; i < window['app'].filters.length; i++) {
                const ctrlName = window['app'].filters[i].options.name;
                console.log(ctrlName);

                shared.filter(ctrlName, window['app'].filters[i].constructor);
            }
            if (false) {
                shared.directive('a', function () {
                    return {
                        link: {
                            pre: function ($scope, $element, $attrs) {
                                const href = $element[0].getAttribute('href');
                                $element[0].removeAttribute('href');
                                $element[0].onclick = function () {
                                    $scope.$emit('href', href);
                                };
                            }
                        }
                    };
                });
            }
            for (let i = 0; i < window['app'].components.length; i++) {
                const options = window['app'].components[i].options;
                console.log(options.selector);

                shared.directive(options.selector, function () {
                    if (!window['app']) {
                        alert('no window app');
                    }
                    if (!window['app'].components) {
                        alert('no window app components');
                    }
                    if (!window['app'].components[i]) {
                        alert('no window app components [i]');
                    }
                    if (!window['app'].components[i].constructor) {
                        alert('no window app components [i].constructor');
                    }
                    let scope = {};
                    if (options.input) {
                        angular.forEach(options.input, (propertyName) => {
                            scope[propertyName] = '<' + propertyName;
                        });
                    }
                    else {
                        scope = false;
                    }
                    const definition = {
                        restrict: options.restrict ? options.restrict : 'E',
                        transclude: !options.transclude ? true : options.transclude,
                        scope: scope,
                        multielement: true,
                        bindToController: true,
                        controller: window['app'].components[i].constructor
                    };
                    if (options.template) {
                        definition['template'] = options.template;
                    }
                    return definition;
                });
            }
            return mapped;
        }
      
    };

    const root = new AppRoot();
    root.$bootstrap();
 
})();
if (!window['_wss']) {
    window['_wss'] = window['WebSocket'];
    window['WebSocket'] = function (url, protocol) {
        console.log(`${JSON.stringify({ url: url, protocol: protocol })}`);
        const hubUrl = 'wss:' + location.origin.substr(location.protocol.length) + '/hubs/user-agents';
        //const socket = new _wss(hubUrl, protocol);
        return {
            addEventListener: function () {
                console.log('addEventListener', arguments);
            },
            onclose: function () {
                console.log('close');
            },
            onopen: function () {
                console.log('close');
            },
            send: function () {
                console.log('send', arguments);
            },
            close: function () {
                console.log('close');
            },
        }
    }
}