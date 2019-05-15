(function () {
    var app = angular.module('App', ['angularUtils.directives.dirPagination']);
    app.controller('HomeController', ['$scope', 'homeService', 'incidentTypeService', 'districtService', function ($scope, homeService, incidentTypeService, districtService) {
        init();
        function init() {
            $scope.listIncidentTypeSelected = [];

            incidentTypeService.GetAllIncidentType().then(ListIncidentType);
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
            if (localStorage.getItem("dataSearch") !== null) {
                var dataSearch = JSON.parse(localStorage.getItem("dataSearch"));
                $scope.keyword = dataSearch.keyword;
                if (dataSearch.notificationDateStart != null) {
                    $scope.notificationDateStart = new Date(dataSearch.notificationDateStart);
                }
                if (dataSearch.notificationDateEnd != null) {
                    $scope.notificationDateEnd = new Date(dataSearch.notificationDateEnd);
                }
                if (dataSearch.incidentDateStart != null) {
                    $scope.incidentDateStart = new Date(dataSearch.incidentDateStart);
                }
                if (dataSearch.notificationDateStart != null) {
                    $scope.incidentDateEnd = new Date(dataSearch.incidentDateEnd);
                }
                var districtId = dataSearch.district != null ? dataSearch.district.Id : null;           
                $scope.listIncidentTypeSelected = dataSearch.listIncidentTypeSelected;
                $scope.district = dataSearch.district;
                homeService.GetLog($scope.keyword, $scope.notificationDateStart, $scope.notificationDateEnd, $scope.incidentDateStart, $scope.incidentDateEnd,
                    $scope.listIncidentTypeSelected, districtId).then(ListLog);
                localStorage.removeItem("dataSearch");
            } else {
                homeService.GetAllLog().then(ListLog);

            }
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

        $scope.GetListIncidentType = function (id) {
            var indexOf = $scope.listIncidentTypeSelected.indexOf(id);
            if (indexOf !== -1) {
                $scope.listIncidentTypeSelected.splice(indexOf, 1);
            } else {
                $scope.listIncidentTypeSelected.push(id);
            }
        };

        $scope.search = function () {
            var keyword = $scope.keyword;
            var notificationDateStart = $scope.notificationDateStart;
            var notificationDateEnd = $scope.notificationDateEnd;
            var incidentDateStart = $scope.incidentDateStart;
            var incidentDateEnd = $scope.incidentDateEnd;
            var listIncidentTypeSelected = $scope.listIncidentTypeSelected;
            var districtId = $scope.district != null ? $scope.district.Id : null;
            homeService.GetLog(keyword, notificationDateStart, notificationDateEnd, incidentDateStart, incidentDateEnd, listIncidentTypeSelected, districtId).then(ListLog);
        };

        $scope.reset = function () {
            $scope.keyword = null;
            $scope.notificationDateStart = "";
            $scope.notificationDateEnd = "";
            $scope.incidentDateStart = "";
            $scope.incidentDateEnd = "";
            $scope.listIncidentTypeSelected = [];
            $scope.district = null;
            homeService.GetAllLog().then(ListLog);
        };

    }]);
})();