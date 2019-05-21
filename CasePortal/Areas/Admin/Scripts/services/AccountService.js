(function () {
    var app = angular.module('App');
    app.factory('accountService', ['$http', '$q', function ($http, $q) {
        var service = {
            Login: Login
        };
        return service;

        function Login(user) {
            var $def = $q.defer();
            $http.post('/Admin/Account/Login', { user: user }).then(function (response) {
                $def.resolve(response.data);
            }, function () {
                $def.reject('Error getting roles');
            });
            return $def.promise;
        }
    }]);
})();