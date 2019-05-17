(function () {
    var app = angular.module('App');
    app.controller('LogDetailController', ['$scope', 'commonService', 'homeService', 'incidentTypeService', 'districtService', function ($scope, commonService,homeService, incidentTypeService, districtService) {
        init();
        function init() {
            commonService.StartLoading();
            var logId = document.getElementById("logId").value;
            homeService.GetLogById(logId).then(LogDetail);
            homeService.GetMediasByLogId(logId).then(ListMedia);
            homeService.GetDocumentsByLogId(logId).then(ListDocument);          
            $scope.listIncidentTypeSelected = [];
            incidentTypeService.GetAllIncidentType().then(ListIncidentType);
            districtService.GetAllDistrict().then(ListDistrict).finally(commonService.EndLoading);

        }

        function LogDetail(data) {
            $scope.logDetail = data;
        }

        function ListIncidentType(data) {
            $scope.listIncidentType = data;
        }

        function ListDistrict(data) {
            $scope.listDistrict = data;
        }

        function ListMedia(data) {
            $scope.listMedia = data;
        }
        function ListDocument(data) {
            $scope.listDocument = data;
        }
        
        $scope.PlayMedia = function (media) {
            $scope.media = media;
            if (media.Type === 1) {
                document.getElementById("myVideo").src = media.Path;
            } else {
                document.getElementById("myAudio").src = media.Path;
            }            
        };

        $scope.GetListIncidentType = function (id) {
            var indexOf = $scope.listIncidentTypeSelected.indexOf(id);
            if (indexOf !== -1) {
                $scope.listIncidentTypeSelected.splice(indexOf, 1);
            } else {
                $scope.listIncidentTypeSelected.push(id);
            }
        };

        $scope.search = function () {  
            commonService.StartLoading();
            var keyword = $scope.keyword;
            var notificationDateStart = $scope.notificationDateStart;
            var notificationDateEnd = $scope.notificationDateEnd;
            var incidentDateStart = $scope.incidentDateStart;
            var incidentDateEnd = $scope.incidentDateEnd;
            var listIncidentTypeSelected = $scope.listIncidentTypeSelected;
            var district = $scope.district; 
            var data = { keyword, notificationDateStart, notificationDateEnd, incidentDateStart, incidentDateEnd, listIncidentTypeSelected, district };
            localStorage.setItem("dataSearch", JSON.stringify(data));
            window.location.href = "/Home/index";
        };
        $scope.reset = function () {
            $scope.keyword = null;
            $scope.notificationDateStart = "";
            $scope.notificationDateEnd = "";
            $scope.incidentDateStart = "";
            $scope.incidentDateEnd = "";
            $scope.listIncidentTypeSelected = [];
            $scope.district = null;
            window.location.href = "/Home/index";
        };
    }]);
})();
