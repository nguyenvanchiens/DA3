(function (app){

    app.controller('newListCtrl', newListCtrl);

    newListCtrl.$inject = ['$scope', 'apiService', 'notificationService','commonService'];

    function newListCtrl($scope, apiService, notificationService,commonService) {

        $scope.getNews = getNews;
        $scope.news = [];
        function getNews() {
            apiService.get('api/news/getall', null, function (result) {
                $scope.news = result.data;
            }, function () {
                    notificationService.displayInfo("load loi");
            });
        }

        getNews();

    }

})(angular.module('fasfood.news'));