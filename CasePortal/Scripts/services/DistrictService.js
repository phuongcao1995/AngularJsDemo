(function () {
    var app = angular.module('App');
    // service - use $http for http requests, $q for promises
    app.factory('districtService', ['$http', '$q', function ($http, $q) {
        var service = {
            GetAllDistrict: GetAllDistrict
        };
        return service;
        function GetAllDistrict() {
            var $def = $q.defer();
            $http.get('/District/GetAllDistrict').then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });

            return $def.promise;

        }
    }]);
})();