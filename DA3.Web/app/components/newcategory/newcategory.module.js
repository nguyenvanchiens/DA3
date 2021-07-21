/// <reference path="../../../assets/admin/libs/angularjs.js" />

(function () {
    angular.module('fasfood.newcategories', ['fasfood.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('newcategories', {
            url: '/newcategories',
            templateUrl: "/app/components/newcategory/newcategoryListView.html",
            controller: "newcategoryListCtrl"
        }).state('add_newcategory', {
            url: '/add_newcategory',
            templateUrl: "/app/components/newcategory/newcategoryAddView.html",
            controller: "newcategoryAddCtrl"
        }).state('newcategory_edit', {
            url: '/newcategory_edit/:id',
            templateUrl: "/app/components/newcategory/newcategoryEditView.html",
            controller: "newcategoryEditCtrl"
        });
        $urlRouterProvider.otherwise('/Admin');
    }
})();