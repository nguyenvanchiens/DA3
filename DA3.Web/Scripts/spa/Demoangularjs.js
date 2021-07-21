/// <reference path="../../Assets/Admin/libs/AngularJS.js" />
var myApp = angular.module('myApp', []);

//cách gọi
myApp.controller('myControllerapp', function ($scope, Validator) {
    $scope.check = function () {
        $scope.message = Validator.checkNumber($scope.num);
    }  
    $scope.num = 1;
    console.log($scope.num);
});
myApp.controller('myController', function ($scope) {
    
});
myApp.controller('myController1', function ($scope) {

});

//cách tạo service trong angularjs
myApp.service('Validator', function ($window) {
    return {
        checkNumber: checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0) {
            return 'this is even';
        }
        else
           return 'this is odd';
    }
});