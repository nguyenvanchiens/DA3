
/// <reference path="../../../assets/admin/libs/angularjs.js" />

(function () {
    angular.module('fasfood.productCategories', ['fasfood.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('productCategories', {
            url: '/productCategories',
            templateUrl: "/app/components/product_category/productcategoriesListView.html",
            controller: "productcategoryListCtrl"
        }).state('productCategory-add', {
            url: '/productCategory-add',
            templateUrl: "/app/components/product_category/productcategoriesAddView.html",
            controller: "productCategoriesAddCtrl"
        }).state('productCategory-edit', {
            url: '/productCategory-edit/:id',
            templateUrl: "/app/components/product_category/productcategoriesEditView.html",
            controller: "productCategoriesEditCtrl"
        });
        $urlRouterProvider.otherwise('/Admin');
    }
})();