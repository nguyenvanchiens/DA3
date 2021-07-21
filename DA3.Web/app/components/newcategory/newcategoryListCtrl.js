(function (app) {

    app.controller('newcategoryListCtrl', newcategoryListCtrl);

    newcategoryListCtrl.$inject = ['$scope', 'apiService', '$state', 'notificationService', 'commonService', '$ngBootbox'];

    function newcategoryListCtrl($scope, apiService, $state, notificationService, commonService, $ngBootbox) {

        $scope.newcategory = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.pagesCount;
        $scope.Getnewcategory = Getnewcategory;
        $scope.search = search;

        $scope.Delete = Delete;

        function Delete(id) {
            $ngBootbox.confirm('bạn có chắc muốn xóa không').then(function () {

                var config = {
                    params: {
                        id: id
                    }
                }

                apiService.del('api/newcategory/delete', config, function (result) {

                    search();

                }, function (erorr) {
                        console.log(erorr);
                });

            });
        }

        function search() {
            Getnewcategory();
        }


        function Getnewcategory(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 5
                }
            }
            apiService.get('api/newcategory/getall', config, function (result) {

                $scope.newcategory = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;

            }, function (error) {
                console.log(error);
            });
        }
        Getnewcategory();
    }

})(angular.module('fasfood.newcategories'));