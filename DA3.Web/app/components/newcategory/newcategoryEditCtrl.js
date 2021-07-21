(function (app)
{

    app.controller('newcategoryEditCtrl', newcategoryEditCtrl);

    newcategoryEditCtrl.$inject = ['$scope', 'apiService', '$state', 'commonService', '$stateParams','notificationService']

    function newcategoryEditCtrl($scope, apiService, $state, commonService, $stateParams, notificationService) {

        $scope.newCategory = {
            CreatedDate: new Date(),
            ModifiedDate: new Date(),
            Status: true

        }

        $scope.loadNewcategory = loadNewcategory;

        $scope.getAlias = getAlias;

        $scope.EditeNewCategory = EditeNewCategory;

       

        function getAlias() {
            $scope.newCategory.MetaTitle = commonService.getTitle($scope.newCategory.Name);
        }

        function loadNewcategory() {
            apiService.get('api/newcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.newCategory = result.data;
            }, function (error) {
                    console.log(error);
            });
        }
        function EditeNewCategory() {
            debugger
            apiService.put('api/newcategory/update', $scope.newCategory, function (result) {

                notificationService.displayInfo('Update thành công ', result.data.Name);

                $state.go('newcategories');

            }, function (error) {
                console.log(error);
            })
        }
        getAlias();

        loadNewcategory();
    }

})(angular.module('fasfood.newcategories'))