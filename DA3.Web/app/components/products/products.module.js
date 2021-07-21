/// <reference path="../../../assets/admin/libs/angularjs.js" />

(function () {
    angular.module('fasfood.products', ['fasfood.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: '/products',            
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListCtrl"
        }).state('add_product', {
            url: '/add_product',            
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddCtrl"
        }).state('product_edit', {
            url: '/product_edit/:id',
           
            templateUrl: "/app/components/products/productEditView.html",
            controller: "productEditCtrl"
        });
        $urlRouterProvider.otherwise('/Admin');
    }
})();