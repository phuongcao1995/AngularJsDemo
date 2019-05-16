(function () {
    var app = angular.module('App');
    // service - use $http for http requests, $q for promises
    app.factory('commonService', ['$http', '$q', '$rootScope', function ($http, $q, $rootScope) {
        var service = {
            StartLoading: StartLoading,
            EndLoading: EndLoading
        };
        return service;

        function StartLoading() {
            $rootScope.loading = true;
        }
        function EndLoading() {
            $rootScope.loading = false;
        }
    }]);
})();