(function (app) {
    app.controller('productcategoryListCtrl', productcategoryListCtrl);

    productcategoryListCtrl.$inject = ['$scope', 'apiService', 'notificationService','$ngBootbox','$filter'];

    function productcategoryListCtrl($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.productCategory = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategory = getProductCategory;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProductCategory = deleteProductCategory;

        $scope.DeleteMultiple = DeleteMultiple;
        function DeleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkProductCategory: JSON.stringify(listId)
                }
            }
            debugger
            apiService.del('api/productcategory/deleteMultiple', config, function (result)
            {
                notificationService.displayInfo('đã xóa ' + result.data + ' bản ghi');
                search();
            }, function (error)
                {
                    notificationService.displayError('lỗi');
            })
        }

        $scope.isAll = false;
        $scope.SelectAll = SelectAll;
        function SelectAll() {
            if ($scope.isAll == false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked!=0) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled','disabled');
            }
        }, true);

        function deleteProductCategory(id) {
            $ngBootbox.confirm('bạn có muốn xóa không').then(function () {

                var config = {
                    params: {
                        id:id
                    }
                }

                apiService.del('api/productcategory/delete', config, function () {
                    notificationService.displayInfo('Đã xóa thành công');
                    search();
                }, function () {
                        notificationService.displayInfo('Không xóa được');
                });
            })
        }

        function getProductCategory(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 5,
                }
            }
            $scope.loading = true;
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayInfo('không có sản phẩm nào tìm thấy')
                }             
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;

            }, function () {
                console.log('Load productcategory failed.');
                $scope.loading = false;

            });
        }
        function search() {
            getProductCategory();
        }

        $scope.getProductCategory();
    }
})(angular.module('fasfood.productCategories'));




