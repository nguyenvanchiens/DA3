(function (app) {

    app.controller('newcategoryAddCtrl', newcategoryAddCtrl);

    newcategoryAddCtrl.$inject = ['$scope', 'apiService', 'notificationService','$state','commonService'];

    function newcategoryAddCtrl($scope, apiService, notificationService, $state,commonService) {

        $scope.newCategory = {
            CreatedDate: new Date(),
            ModifiedDate: new Date(),
            MetaKeywords: "",
            MetaDescriptions:"",
            Status:true,
        }

      

        $scope.AddNewCategory = AddNewCategory;
        function AddNewCategory() {
            apiService.post('api/newcategory/add', $scope.newCategory, function (result) {
                notificationService.displayInfo('Tạo mới thành công' + result.data.Name);
                debugger
                $state.go('newcategories');
            }, function (error) {
                console.log('Lỗi');
            });
        }


        $scope.getAlias = getAlias;
        function getAlias() {
            $scope.newCategory.MetaTitle = commonService.getTitle($scope.newCategory.Name);
        }
    }

})(angular.module('fasfood'));