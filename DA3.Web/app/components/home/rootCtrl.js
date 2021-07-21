(function (app) {
    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope', '$state'];

    function rootCtrl($scope, $state) {

        $scope.Logout = Logout;

        function Logout() {
            $state.go('login');
        }

    }
})(angular.module('fasfood'));