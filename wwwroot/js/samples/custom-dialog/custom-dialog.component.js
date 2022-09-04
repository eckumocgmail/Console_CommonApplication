const angular = window['angular'];
angular
    .module('myApp', ['ngMaterial', 'ngMessages', 'material.svgAssetsCache'])
    .config(function ($mdThemingProvider) {
    $mdThemingProvider.theme('default')
        .primaryPalette('yellow')
        .accentPalette('blue');
    $mdThemingProvider.theme('login')
        .primaryPalette('brown')
        .accentPalette('yellow');
})
    .controller('appController', function ($scope, $mdDialog, $log) {
    $scope.showLogin = function (event) {
        $mdDialog.show({
            controller: LoginController,
            templateUrl: 'login.tmpl.html',
            parent: angular.element(document.body),
            targetEvent: event,
            clickOutsideToClose: true
        })
            .then(function (answer) {
            $log.log('Dialog result: ' + answer);
        }, function () {
            $log.log('Dialog Canceled.');
        })
            .catch(function () {
            $log.error('Failed to open Dialog.');
        });
    };
});
function LoginController($scope, $mdDialog, $log) {
    $scope.cancel = function () {
        $mdDialog.hide();
    };
    $scope.login = function () {
        $log.debug("login()...");
        $mdDialog.hide();
    };
    $scope.user = {
        company: 'Google, Inc.',
        email: 'ThomasBurleson@Gmail.com',
        phone: ''
    };
}
;
