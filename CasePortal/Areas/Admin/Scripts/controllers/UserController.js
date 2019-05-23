(function () {
    var app = angular.module('App');
    app.controller('UserController', ['$scope', 'commonService', 'userService', 'incidentTypeService', 'districtService', function ($scope, commonService, userService, incidentTypeService, districtService) {
        init();
        function init() {
            commonService.StartLoading();
            userService.GetAllUser().then(ListUser).finally(commonService.EndLoading);
            $scope.itemsPerPage = $("#show-number option:first").val();
            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };
        }

        function ListUser(data) {
            $scope.listUser = data;
        }

        function ListIncidentType(data) {
            $scope.listIncidentType = data;
        }

        function ListDistrict(data) {
            $scope.listDistrict = data;
        }
        function ShowMessage(data) {
            if (data.status === 1) {
                $.notify(data.message, "success");
            } else {
                $.notify(data.message, "error");
            }

        }
        $scope.AddLog = function (log, m) {
            commonService.StartLoading();
            homeService.AddLog(log).then(function (response) {
                ShowMessage(response);
                homeService.GetAllLog().then(ListLog).finally(commonService.EndLoading);
                $(m).modal("hide");
            });
        };

        $scope.OpenModalUpdate = function (log) {
            log.NotificationDate = new Date(log.NotificationDate);
            log.IncidentDate = new Date(log.IncidentDate);
            $scope.log = angular.copy(log);
        };

        $scope.OpenModalDelete = function (log) {
            log.NotificationDate = new Date(log.NotificationDate);
            log.IncidentDate = new Date(log.IncidentDate);
            $scope.log = angular.copy(log);
        };

        $scope.UpdateLog = function (log, m) {
            commonService.StartLoading();
            homeService.UpdateLog(log).then(function (response) {
                ShowMessage(response);
                homeService.GetAllLog().then(ListLog).finally(commonService.EndLoading);
                $(m).modal("hide");
            });
        };

        $scope.DeleteLog = function (log, m) {
            commonService.StartLoading();
            homeService.DeleteLog(log).then(function (response) {
                ShowMessage(response);
                homeService.GetAllLog().then(ListLog).finally(commonService.EndLoading);
                $(m).modal("hide");
            });
        };
        $scope.search = function () {
            commonService.StartLoading();
            console.log($scope.IncidentType);
            var keyword = $scope.keyword;
            var notificationDateStart = $scope.notificationDateStart;
            var notificationDateEnd = $scope.notificationDateEnd;
            var incidentDateStart = $scope.incidentDateStart;
            var incidentDateEnd = $scope.incidentDateEnd;
            var IncidentType = $scope.IncidentType;
            var districtId = $scope.district != null ? $scope.district.Id : null;
            homeService.GetLog(keyword, notificationDateStart, notificationDateEnd, incidentDateStart, incidentDateEnd, IncidentType, districtId).then(ListLog).finally(commonService.EndLoading);
        };

        $scope.reset = function () {
            commonService.StartLoading();
            $scope.keyword = null;
            $scope.notificationDateStart = "";
            $scope.notificationDateEnd = "";
            $scope.incidentDateStart = "";
            $scope.incidentDateEnd = "";
            $scope.IncidentType = null;
            $(".filter-option-inner-inner").text("");
            $scope.district = null;
            homeService.GetAllLog().then(ListLog).finally(commonService.EndLoading);
        };

    }]);
})();