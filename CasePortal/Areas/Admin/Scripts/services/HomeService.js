(function () {
    var app = angular.module('App');
    // service - use $http for http requests, $q for promises
    app.factory('homeService', ['$http', '$q', function ($http, $q) {
        var service = {
            GetAllLog: GetAllLog,
            //GetLog: GetLog,
            //GetLogById: GetLogById,
            //GetMediasByLogId: GetMediasByLogId,
            //GetDocumentsByLogId: GetDocumentsByLogId,
            AddLog: AddLog,
            UpdateLog: UpdateLog,
            DeleteLog: DeleteLog
        };
        return service;
        function GetAllLog() {
            var $def = $q.defer();
            $http.get('/Admin/Home/GetAllLog').then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }

        //function GetLog(keyword, notificationDateStart, notificationDateEnd, incidentDateStart, incidentDateEnd, incidentTypeIds, districtId) {
        //    var $def = $q.defer();
        //    $http.get('/Home/GetLog', {
        //        params: {
        //            keyword: keyword,
        //            notificationDateStart: notificationDateStart,
        //            notificationDateEnd: notificationDateEnd,
        //            incidentDateStart: incidentDateStart,
        //            incidentDateEnd: incidentDateEnd,
        //            incidentTypeIds: incidentTypeIds,
        //            districtId: districtId,

        //        }
        //    }).then(function (response) {
        //        $def.resolve(response.data);
        //    }, function () {
        //        $def.reject('Error getting roles');
        //    });
        //    return $def.promise;
        //}

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

        //function GetLogById(id) {
        //    var $def = $q.defer();
        //    $http.get('/Home/GetLogById', {
        //        params: {
        //            id: id
        //        }
        //    }).then(function (response) {
        //        $def.resolve(response.data);
        //    }, function () {
        //        $def.reject('Error getting roles');
        //    });
        //    return $def.promise;
        //}

        //function GetMediasByLogId(id) {
        //    var $def = $q.defer();
        //    $http.get('/Home/GetMediasByLogId', {
        //        params: {
        //            id: id
        //        }
        //    }).then(function (response) {
        //        $def.resolve(response.data);
        //    }, function () {
        //        $def.reject('Error getting roles');
        //    });
        //    return $def.promise;
        //}
        //function GetDocumentsByLogId(id) {
        //    var $def = $q.defer();
        //    $http.get('/Home/GetDocumentsByLogId', {
        //        params: {
        //            id: id
        //        }
        //    }).then(function (response) {
        //        $def.resolve(response.data);
        //    }, function () {
        //        $def.reject('Error getting roles');
        //    });
        //    return $def.promise;
        //}

    }]);
})();