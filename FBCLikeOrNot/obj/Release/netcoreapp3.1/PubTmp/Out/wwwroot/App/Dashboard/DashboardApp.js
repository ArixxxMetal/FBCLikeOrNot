

var app = angular.module("DashboardApp", []);

app.controller("DashboardController", function ($scope, $http) {


    angular.element(document).ready(function () {

        GetTotalReactionList()
    });

    $scope.service_name = "";
    $scope.device_name = "";

    $scope.Access = function () {
        LoginAccess()
    }

    $scope.ShowAddNewDeviceModal = function () {
        $scope.add_description_question = "";
        $scope.add_service_name = "";
        $scope.add_create_by = "";

        $('#js_CreateDevice').modal('show');
    }

    $scope.ShowUpdateModal = function (_device) {

        $('#js_UpdateDevice').modal('show');
    }

    $scope.SetLogReaction = function (_reaction) {

        SetReaction($('#device_id').html(), _reaction.idreaction)
    }

    function GetTotalReactionList() {
        // Call Fields validation 

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Reaction/GetTotalReactions",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: {}
        }).then(function (response) {

            $scope.TotalReactionList = response.data;
            console.log($scope.TotalReactionList);
            //GetQuestion()

        }, function errorCallBack(response) {
            console.error("Error get data");
            console.log(response.data);
        })
        // end httpRequest
    }

});