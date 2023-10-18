
var app = angular.module("ReactionRecordsApp", []);

app.controller("ReactionRecordsController", function ($scope, $http) {

    angular.element(document).ready(function () {

        GetAllServices();
    });

    // Declare a variable to hold the chart object
    var chart;

    $scope.service_name = "";
    $scope.device_name = "";
    $scope.myJson = "";
    $scope.service_id_model = null;
    $scope.device_id_model = null;
    $scope.TotalReactionList = [];

    $scope.GetDeviceList = function () {

        var start_date = moment().subtract(7, 'days');
        var end_date = moment();
        GetReactionRecords(start_date, end_date);
        //GetDevicesByArea();
    }

    $scope.GenerateGraph = function () {
        $scope.TotalReactionList = [];

        var start_date = moment().subtract(7, 'days');
        var end_date = moment();

        GetReactionRecords(start_date, end_date);
    }

    var start = moment().subtract(7, 'days');
    var end = moment();


    function GetReactionRecords(start, end) {
        // Call Fields validation

        $('#reportrange span').html(start.format('DD D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
        console.log("Start: " + start.format('DD-MM-YYYY') + " End: " + end.format('DD-MM-YYYY') + " ")

        $scope.js_startdate = start;
        $scope.js_enddate = end;


        $scope.startdate = start.format('YYYY-MM-DD');
        $scope.enddate = end.format('YYYY-MM-DD');

        Data = {
            PARAM_SERVICE_ID: $scope.service_id_model,
            PARAM_BEGIN_DATE: $scope.startdate,
            PARAM_END_DATE: $scope.enddate
        }

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Reaction/GetReactionRecordByArea",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: JSON.stringify(Data)
        }).then(function (response) {

            $scope.RecordsList = response.data;
            console.log($scope.RecordsList);
            GetDevicesByArea();

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest

    }

    function GetDevicesByArea() {
        // Call Fields validation

        let SERVICE_ID = parseInt($scope.service_id_model);
        Data = {
            PARAM_SERVICE_ID: SERVICE_ID
        }

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Device/GetDevicesByServiceId",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Data
        }).then(function (response) {

            $scope.DeviceList = response.data;
            //console.log($scope.DeviceList);

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest

    }

    function GetAllServices() {
        // Call Fields validation 

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Service/GetServices",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: {}
        }).then(function (response) {

            $scope.ServiceList = response.data;
            //console.log($scope.ServiceList);

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest

    }

    $('#reportrange').daterangepicker({
        startDate: start,
        endDate: end,
        ranges: {
            'Hoy': [moment(), moment()],
            'Ayer': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Ultimos 7 Dias': [moment().subtract(6, 'days'), moment()],
            'Ultimos 30 Dias': [moment().subtract(29, 'days'), moment()],
            'Este Mes': [moment().startOf('month'), moment().endOf('month')],
            'Ultimo Mes': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        }
    }, GetReactionRecords);


});