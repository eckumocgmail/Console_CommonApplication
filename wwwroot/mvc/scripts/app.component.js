var App;
(function (App) {
    App.angular = window['angular'];
    class AppComponent extends App.angular.module {
        constructor() {
            super('YourApp', ['ngMaterial', 'ngMessages']);
            this['controller']("YourController", ($scope, $mdDialog) => {
                window['$mdDialog'] = $mdDialog;
                window['$createDialogService']($mdDialog);
            });
        }
    }
    App.AppComponent = AppComponent;
})(App || (App = {}));
