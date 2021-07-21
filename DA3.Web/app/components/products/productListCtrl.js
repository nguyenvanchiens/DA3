(function (app) {
    app.controller('productListCtrl', productListCtrl);
    productListCtrl.$inject = ['$scope', 'apiService', 'notificationService','$ngBootbox'];

    function productListCtrl($scope, apiService, notificationService, $ngBootbox) {

        $scope.product = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProduct = getProduct;
        $scope.keyword = '';
        $scope.search = search;

        function search() {
            getProduct();
        }

        $scope.deleteProduct = deleteProduct;
        function deleteProduct(id) {
            $ngBootbox.confirm('bạn có muốn xóa không').then(function () {

                var config = {
                    params: {
                        id: id
                    }
                }

                apiService.del('api/product/delete', config, function () {
                    notificationService.displayInfo('Đã xóa thành công');
                    search();
                }, function () {
                    notificationService.displayInfo('Không xóa được');
                });
            })
        }

        function getProduct(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 5
                }
            }        
            apiService.get('/api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayInfo('không có sản phẩm nào tìm thấy')
                }
                $scope.product = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;

            }, function () {
                console.log('Load productcategory failed.');
                $scope.loading = false;

            });
        }
       
        $scope.getProduct();
    }
})(angular.module('fasfood.products'));