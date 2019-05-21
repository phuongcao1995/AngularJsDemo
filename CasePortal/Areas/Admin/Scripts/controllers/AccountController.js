(function () {
    var app = angular.module("App", []);
    app.controller('AccountController', ['$scope', 'commonService', 'accountService', function ($scope, commonService, accountService) {
        init();
        function init() {
            $scope.AccountValid = true;           
       
        }
        $scope.Login = function (user) {
            commonService.StartLoading();
            accountService.Login(user).then(function (response) {
                if (response.status === 1) {
                    window.location.href = "/Admin/Home/Index";
                } else {
                    $scope.AccountValid = false;  
                }
                commonService.EndLoading();
            });
        };

    }]);
})();