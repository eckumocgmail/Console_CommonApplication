window['app'] = {
    appName: 'AppModel',
    modules: [],
    components: [],
    directives: [],
    services: [],
    scopes: {},
    filters: [],
    controllers: [],
    deps: ['ngMaterial', 'ngMessages', 'ngAnimate' ]
};
function $application() {
    return window['app'];
}
