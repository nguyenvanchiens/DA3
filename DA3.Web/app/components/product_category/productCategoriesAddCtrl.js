(function (app) {

    app.controller('productCategoriesAddCtrl', productCategoriesAddCtrl);

    productCategoriesAddCtrl.$inject = ['$scope', 'apiService', '$state', 'notificationService','commonService'];

    function productCategoriesAddCtrl($scope, apiService, $state, notificationService, commonService) {

        $scope.AddProductCategory = AddProductCategory;
        $scope.getAlias = getAlias;
        $scope.ckeditorOptions =
        {
            language: 'vi',
            height:'200px'
        };
        
        $scope.productCategory = {
            CreatedDate: new Date(),
            CreatedBy: '',
            ModifiedDate: new Date(),
            ModifiedBy: '',
            Status: true
            
        }
        function getAlias() {
            $scope.productCategory.Alias = commonService.getTitle($scope.productCategory.Name);
        }

        function AddProductCategory() {
            debugger
            apiService.post('api/productcategory/create', $scope.productCategory,
                function (result) {
                    notificationService.displayInfo("Thêm mới " + result.data.Name+" thành công")
                    $state.go('productCategories');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.' + error);
                });
        }       
    }


})(angular.module('fasfood.productCategories'));