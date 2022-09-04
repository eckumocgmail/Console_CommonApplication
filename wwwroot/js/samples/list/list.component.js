(function () {
    const angular = window['angular'];
    angular.module('MyApp', ['ngMaterial', 'ngMessages', 'material.svgAssetsCache'])
        .config(function ($mdIconProvider) {
        $mdIconProvider
            .iconSet('social', 'img/icons/sets/social-icons.svg', 24)
            .iconSet('device', 'img/icons/sets/device-icons.svg', 24)
            .iconSet('communication', 'img/icons/sets/communication-icons.svg', 24)
            .defaultIconSet('img/icons/sets/core-icons.svg', 24);
    })
        .controller('ListCtrl', function ($scope, $mdDialog) {
        $scope.people = [];
        for (let i = 0; i < 500; i++) {
            $scope.people.push({
                name: 'Janet Perkins' + (i + 1),
                img: 'https://material.angularjs.org/HEAD/img/100-0.jpeg',
                newMessage: true
            });
        }
        $scope.goToPerson = function (person, event) {
            $mdDialog.show($mdDialog.alert()
                .title('Navigating')
                .textContent('Inspect ' + person)
                .ariaLabel('Person inspect demo')
                .ok('Neat!')
                .targetEvent(event));
        };
        $scope.navigateTo = function (to, event) {
            $mdDialog.show($mdDialog.alert()
                .title('Navigating')
                .textContent('Imagine being taken to ' + to)
                .ariaLabel('Navigation demo')
                .ok('Neat!')
                .targetEvent(event));
        };
        $scope.doPrimaryAction = function (event) {
            $mdDialog.show($mdDialog.alert()
                .title('Primary Action')
                .textContent('Primary actions can be used for one click actions')
                .ariaLabel('Primary click demo')
                .ok('Awesome!')
                .targetEvent(event));
        };
        $scope.doSecondaryAction = function (event) {
            $mdDialog.show($mdDialog.alert()
                .title('Secondary Action')
                .textContent('Secondary actions can be used for one click actions')
                .ariaLabel('Secondary click demo')
                .ok('Neat!')
                .targetEvent(event));
        };
    });
})();
