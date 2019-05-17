(function () {
    var app = angular.module('App');
    app.factory('incidentTypeService', ['$http', '$q', function ($http, $q) {
        var service = {
            GetAllIncidentType: GetAllIncidentType
        };
        return service;
        function GetAllIncidentType() {
            var $def = $q.defer();
            $http.get('/IncidentType/GetAllIncidentType').then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });

            return $def.promise;

        }
    }]);
})();