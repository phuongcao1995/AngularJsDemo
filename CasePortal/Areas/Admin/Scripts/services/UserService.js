(function () {
    var app = angular.module('App');
    app.factory('userService', ['$http', '$q', function ($http, $q) {
        var service = {
            GetAllUser: GetAllUser,
            GetLog: GetLog,
            AddLog: AddLog,
            UpdateLog: UpdateLog,
            DeleteLog: DeleteLog
        };
        return service;
        function GetAllUser() {
            var $def = $q.defer();
            $http.get('/Admin/User/GetAllUser').then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }

        function GetLog(keyword, notificationDateStart, notificationDateEnd, incidentDateStart, incidentDateEnd, incidentTypeIds, districtId) {
            var $def = $q.defer();
            $http.get('/Admin/Home/GetLog', {
                params: {
                    keyword: keyword,
                    notificationDateStart: notificationDateStart,
                    notificationDateEnd: notificationDateEnd,
                    incidentDateStart: incidentDateStart,
                    incidentDateEnd: incidentDateEnd,
                    incidentTypeIds: incidentTypeIds,
                    districtId: districtId,
                }
            }).then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }

        function AddLog(log) {
            var $def = $q.defer();
            $http.post('/Admin/Home/AddLog', { log: log }).then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }

        function UpdateLog(log) {
            var $def = $q.defer();
            $http.post('/Admin/Home/UpdateLog', { log: log }).then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }

        function DeleteLog(log) {
            var $def = $q.defer();
            $http.post('/Admin/Home/DeleteLog', { log: log }).then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }
    }]);
})();