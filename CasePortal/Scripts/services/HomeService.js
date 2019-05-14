(function () {
    var app = angular.module('App');
    // service - use $http for http requests, $q for promises
    app.factory('homeService', ['$http', '$q', function ($http, $q) {
        var service = {
            GetAllLog: GetAllLog,
            GetLog: GetLog
        };
        return service;
        function GetAllLog() {
            var $def = $q.defer();
            $http.get('/Home/GetAllLog').then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }
        function GetLog(keyword, notificationDateStart, notificationDateEnd, incidentDateStart, incidentDateEnd, incidentTypeIds, districtId) {
            var $def = $q.defer();
            $http.get('/Home/GetLog', {
                params: {
                    keyword: keyword,
                    notificationDateStart: notificationDateStart,
                    notificationDateEnd: notificationDateEnd,
                    incidentDateStart: incidentDateStart,
                    incidentDateEnd: incidentDateEnd,
                    incidentTypeIds: incidentTypeIds,
                    districtId: districtId
                }
            }).then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }
    }]);
})();