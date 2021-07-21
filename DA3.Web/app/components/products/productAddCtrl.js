(function (app) {
    app.controller('productAddCtrl', productAddCtrl);

    productAddCtrl.$inject = ['$scope', 'apiService', '$state', 'notificationService','commonService'];

    function productAddCtrl($scope, apiService, $state, notificationService, commonService) {
        
        $scope.ckeditorOptions =
        {
            language: 'vi',
            height: '200px'
        };

        //thềm sản phẩm
        $scope.product = {
            CreatedDate: new Date(),
            CreatedBy: '',
            ModifiedDate: new Date(),
            ModifiedBy: '',
            Status: true
        }
        $scope.AddProduct = AddProduct;
        function AddProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImage);
            apiService.post('api/product/create', $scope.product, function () {
                notificationService.displayInfo('oke');
                $state.go('products');
            }, function () {
                    console.log('chua add')
            });
        }


        
        //get ra alias từ Name nhập vào
        $scope.getAlias = getAlias;
        function getAlias() {
            $scope.product.Alias = commonService.getTitle($scope.product.Name);
        }

        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                });
              
            }
            finder.popup();
        }

        $scope.choosemoreImage = choosemoreImage;
         $scope.moreImage = [];
        function choosemoreImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImage.push(fileUrl);
                });
            }
            finder.popup();
        }

        //lấy ra Id danh sách productCategory
        $scope.ProductCategory;
        function getProductCategory() {
            apiService.get('api/productcategory/getallParent', null, function (result) {

                $scope.ProductCategory = result.data;

            }, function () {

            });
        }
        getProductCategory();      
    }

})(angular.module('fasfood.products'));