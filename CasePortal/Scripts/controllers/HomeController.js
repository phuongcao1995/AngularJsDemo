(function () {
    // var app = angular.module('App', []);
    var app = angular.module('App', ['angularUtils.directives.dirPagination']);
    app.controller('HomeController', ['$scope', 'homeService', 'incidentTypeService', 'districtService', function ($scope, homeService, incidentTypeService, districtService) {
        init();
        function init() {
            homeService.GetAllLog().then(ListLog, ErrorRecieved);
            incidentTypeService.GetAllIncidentType().then(ListIncidentType, ErrorRecieved);
            districtService.GetAllDistrict().then(ListDistrict, ErrorRecieved);
            $scope.itemsPerPage = $("#show-number option:first").val();
            $scope.listIncidentTypeSelected = [];
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

        function ErrorRecieved() {
            console.log('Error Occured in data service call.');
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
            var districtId = $scope.district !== null ? $scope.district.Id : null;
            homeService.GetLog(keyword, notificationDateStart, notificationDateEnd, incidentDateStart, incidentDateEnd, listIncidentTypeSelected, districtId).then(ListLog, ErrorRecieved);
        };
        $scope.reset = function () {
            $scope.keyword = null;
            $scope.notificationDateStart = "";
            $scope.notificationDateEnd = "";
            $scope.incidentDateStart = "";
            $scope.incidentDateEnd = "";
            $scope.listIncidentTypeSelected = [];
            $scope.district = null;
            homeService.GetAllLog().then(ListLog, ErrorRecieved);
        };
    }]);
})();