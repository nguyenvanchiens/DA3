/// <reference path="../../../assets/admin/libs/angularjs.js" />

(function () {
    angular.module('fasfood.news', ['fasfood.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('news', {
            url: '/newcategories',
            templateUrl: "/app/components/newcategory/newcategoryListView.html",
            controller: "newcategoryListCtrl"
        });
        $urlRouterProvider.otherwise('/Admin');
    }
})();