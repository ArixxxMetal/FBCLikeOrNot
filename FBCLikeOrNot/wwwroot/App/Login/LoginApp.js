
var app = angular.module("LoginApp", []);

app.controller("LoginController", function ($scope, $http) {


    angular.element(document).ready(function () {

        //window.location.replace("https://localhost:44341/Grievance/GrievanceSended");

    });

    $scope.NameModel = "";
    $scope.PasswordModel = "";

    $scope.Access = function () {
        LoginAccess()
    }

    function LoginAccess() {
        // Call Fields validation 
   

        var LoginViewModel = {
             user: $scope.NameModel,
             password: $scope.PasswordModel,
         }
         // start httpRequest 
         $http({
             method: "POST",
             url: "/Login/Login",
             headers: { 'Content-Type': 'application/json;charset=utf-8' },
             data: LoginViewModel
         }).then(function (response) {
             debugger
             $scope.responseTest = response.data;

             //window.location.replace($scope.responseTest);

         }, function errorCallBack(response) {
             console.error("Error to delete");
             console.log(response.data);
         })
         // end httpRequest

    }
});