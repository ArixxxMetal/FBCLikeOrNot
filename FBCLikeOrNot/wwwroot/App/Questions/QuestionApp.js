
var app = angular.module("QuestionApp", []);

app.controller("QuestionController", function ($scope, $http) {


    angular.element(document).ready(function () {

        GetAllServices()
        GetAllQuestions()
    });

    $scope.service_name = "";
    $scope.device_name = "";
    $scope.service_id = 0;

    $scope.ShowQuestionsModal = function (service) {

        $('#largeModal').modal('show');

        $scope.service_id = service.idservice;
        $scope.service_name = service.nameservice;

        GetQuestionsByServiceId($scope.service_id)
    }

    $scope.AssingQuestion = function (question_id) {
        
        SetQuestionsByServiceId($scope.service_id, question_id)
    }

    $scope.RemoveQuestion = function (id_question_log) {

        RemoveQuestionsByServiceId(id_question_log)
    }

    function GetQuestionsByServiceId(service_id) {

        var Questions_Parameter = {
            PARAM_SERVICE_ID: service_id
        }
        // start httpRequest 
        $http({
            method: "POST",
            url: "/Question/GetQuestionsById",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Questions_Parameter
        }).then(function (response) {

            $scope.QuestionAssignedList = response.data;
            //console.log($scope.QuestionAssignedList);

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest
    }

    function SetQuestionsByServiceId(service_id, question_id) {
        
        var Questions_Parameter = {
            PARAM_QUESTION_ID: question_id,
            PARAM_SERVICE_ID: service_id
        }
        // start httpRequest 
        $http({
            method: "POST",
            url: "/Question/SetQuestionById",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Questions_Parameter
        }).then(function (response) {

            $scope.SetQuestionResponse = response.data[0];
            //console.log($scope.QuestionAssignedList);
            GetQuestionsByServiceId($scope.service_id)

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest
    }

    function RemoveQuestionsByServiceId(question_log_id) {
        
        var Questions_Parameter = {
            PARAM_QUESTION_LOG_ID: question_log_id
        }
        // start httpRequest 
        $http({
            method: "POST",
            url: "/Question/DisableQuestionById",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Questions_Parameter
        }).then(function (response) {
            
            $scope.RemoveQuestionResponse = response.data[0];
            //console.log($scope.QuestionAssignedList);
            GetQuestionsByServiceId($scope.service_id)

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
            console.log($scope.ServiceList);

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest

    }

    function GetAllQuestions() {
        // Call Fields validation 

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Service/GetAllQuestions",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: {}
        }).then(function (response) {           
            $scope.QuestionList = response.data;
            console.table($scope.QuestionList);

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest

    }



});