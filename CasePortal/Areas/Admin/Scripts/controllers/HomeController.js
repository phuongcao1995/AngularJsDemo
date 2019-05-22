(function () {
    var app = angular.module('App', ['angularUtils.directives.dirPagination']);
    app.controller('HomeController', ['$scope', 'commonService', 'homeService', 'incidentTypeService', 'districtService', function ($scope, commonService, homeService, incidentTypeService, districtService) {
        incidentTypeService.GetAllIncidentType().then(ListIncidentType);
        init();
        function init() {
            commonService.StartLoading();
            homeService.GetAllLog().then(ListLog).finally(commonService.EndLoading);
            $scope.listIncidentTypeSelected = [];
            districtService.GetAllDistrict().then(ListDistrict);
            $scope.itemsPerPage = $("#show-number option:first").val();
            $scope.district = null;
            $scope.sort = function (keyname) {
                $scope.listLog.forEach(function (data) {
                    data.IncidentDate = new Date(data.IncidentDate);
                });
                $scope.listLog.forEach(function (data) {
                    data.NotificationDate = new Date(data.NotificationDate);
                });
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            };
        }

        function ListLog(data) {
            $scope.listLog = data;
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

        //$scope.GetListIncidentType = function (id) {
        //    var indexOf = $scope.listIncidentTypeSelected.indexOf(id);
        //    if (indexOf !== -1) {
        //        $scope.listIncidentTypeSelected.splice(indexOf, 1);
        //    } else {
        //        $scope.listIncidentTypeSelected.push(id);
        //    }
        //};
        $scope.OpenModalUpdate = function (log) {
            log.NotificationDate = new Date(log.NotificationDate);
            log.IncidentDate = new Date(log.IncidentDate);
            $scope.log = log;
        };

        $scope.OpenModalDelete = function (log) {
            log.NotificationDate = new Date(log.NotificationDate);
            log.IncidentDate = new Date(log.IncidentDate);
            $scope.log = log;
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