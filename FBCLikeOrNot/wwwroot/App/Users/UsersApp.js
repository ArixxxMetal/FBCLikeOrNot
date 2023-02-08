

var app = angular.module("UserApp", []);

app.controller("UserController", function ($scope, $http) {


    angular.element(document).ready(function () {

        GetAllEmployees();
    });

    $scope.NameModel = "";
    $scope.PasswordModel = "";

    $scope.Access = function () {
        LoginAccess()
    }

    function GetAllEmployees() {
        // Call Fields validation 

        // start httpRequest 
        $http({
            method: "POST",
            url: "/User/GetAllEmployees",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: {}
        }).then(function (response) {
            debugger
            $scope.UserList = response.data;
            console.log($scope.UserList);

        }, function errorCallBack(response) {
            console.error("Error to delete");
            console.log(response.data);
        })
        // end httpRequest

    }
});