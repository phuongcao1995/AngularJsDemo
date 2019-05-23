(function () {
    var app = angular.module("App", ['ngCookies']);
    app.controller('AccountController', ['$scope', 'commonService', 'accountService', function ($scope, commonService, accountService) {
        accountService.ClearCredentials();
        init();

        function init() {
            $scope.AccountValid = true;
        }
        $scope.Login = function (user) {
            $scope.dataLoading = true;
            commonService.StartLoading();
            accountService.Login(user).then(function (response) {
                if (response.status === 1) {
                        accountService.SetCredentials(user.Email, user.Password);
                        window.location.href = "/Admin/Home/Index";
                } else {
                    $scope.AccountValid = false;
                    $scope.dataLoading = false;
                }
                commonService.EndLoading();
            });
        };

    }]);
})();