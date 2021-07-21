(function (app) {

    app.controller('LoginCtrl', LoginCtrl);
    LoginCtrl.$inject = ['$scope','loginService', '$injector', 'notificationService'];

    function LoginCtrl($scope, loginService, $injector, notificationService) {

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.Login = Login;
        function Login() {
            loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                if (response != null && response.data.error != undefined) {
                    notificationService.displayError("Tài Khoản Mật Khẩu Không Đúng");
                }
                else {
                    var stateService = $injector.get('$state');
                    stateService.go('home');
                    notificationService.displayInfo("Đăng Nhập Thành Công");
                }
            });
        }
    }
})(angular.module('fasfood'))