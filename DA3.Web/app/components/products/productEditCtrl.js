(function (app) {
    app.controller('productEditCtrl', productEditCtrl);

    productEditCtrl.$inject = ['$scope', 'apiService', '$state', 'notificationService', 'commonService', '$stateParams'];

    function productEditCtrl($scope, apiService, $state, notificationService, commonService, $stateParams) {
        $scope.moreImage = [];
        $scope.product =
        {
            CreatedDate: new Date(),
            Status: true
        };

        function GetProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {

                $scope.product = result.data;
                $scope.moreImage = JSON.parse(result.data.MoreImage);

            }, function () {
                console.log('k load ra được');
            });
        }
        $scope.EditProduct = EditProduct;
        function EditProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImage);
            apiService.put('api/product/update', $scope.product,
                function (result) {
                    notificationService.displayInfo('update thành công ' + result.data.Name);
                    $state.go('products');
                }, function (erro) {
                    console.log(erro);
                });
        }

        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        $scope.choosemoreImage = choosemoreImage;
       
        function choosemoreImage() {
            debugger
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImage.push(fileUrl);
                });
            }
            finder.popup();
        }

        $scope.ProductCategory;
        function loadProductCategory() {
            apiService.get('api/productcategory/getallParent', null, function (result) {
                $scope.ProductCategory = result.data;
            }, function () {
                console.log('k load ra được');
            });
        }

        loadProductCategory();

        GetProductDetail();

    }
})(angular.module('fasfood.products'));