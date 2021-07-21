(function (app) {

    app.controller('productCategoriesEditCtrl', productCategoriesEditCtrl);

    productCategoriesEditCtrl.$inject = ['$scope', 'apiService', '$state', 'notificationService','$stateParams','commonService'];

    function productCategoriesEditCtrl($scope, apiService, $state, notificationService, $stateParams,commonService) {

        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.loadProductCategoryDetail = loadProductCategoryDetail;
        $scope.getAlias = getAlias;
        $scope.productCategory = {
            CreatedDate: new Date(),            
            ModifiedDate: new Date(),
            Status: true

        }
        
        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data
            }, function (error) {
                    notificationService.displayInfo(error);
            });
        }
        function getAlias() {
            $scope.productCategory.Alias = commonService.getTitle($scope.productCategory.Name);
        }
        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory,
                function (result) {
                    notificationService.displayInfo("Cập nhật thành công")
                    $state.go('productCategories');
                }, function (error) {
                    console.log(error);
                });
        }
        loadProductCategoryDetail();
    }


})(angular.module('fasfood.productCategories'));