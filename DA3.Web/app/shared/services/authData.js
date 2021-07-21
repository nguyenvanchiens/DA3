(function (app) {
    'use strict';
    app.factory('authData', authData);

    authData.$inject = [];

    function authData () {
        var authDataFactory = {};

        var authentication = {
            IsAuthenticated: false,
            userName: ""
        };
        authDataFactory.authenticationData = authentication;

        return authDataFactory;
    };
})(angular.module('fasfood.common'));