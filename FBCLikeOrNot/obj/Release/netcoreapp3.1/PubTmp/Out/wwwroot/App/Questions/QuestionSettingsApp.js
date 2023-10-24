
var app = angular.module("QuestionSettinngsApp", []);

app.controller("QuestionSettinngsController", function ($scope, $http) {


    angular.element(document).ready(function () {

        GetAllServices();
        GetAllQuestions();
    });

    $scope.service_name = "";
    $scope.device_name = "";
    $scope.service_id = 0;

    $scope.ShowSetQuestionModal = function () {

        $scope.selected_description_question = "";
        $scope.selected_creator_question = "";

        $('#js_SetQuestion').modal('show');
    }

    $scope.AssignQuestion = function () {
        SetQuestion()
    }

    function SetQuestion() {
        // Call Fields validation 
        if ($("#js_SetQuestionForm").valid()) {
            Data = {
                PARAM_SERVICE_ID: 0,
                PARAM_DESCRIPTION_QUESTION: $scope.selected_description_question,
                PARAM_CREATE_BY: $scope.selected_creator_question
            }
            // start httpRequest 
            $http({
                method: "POST",
                url: "/Service/SetQuestionService",
                headers: { 'Content-Type': 'application/json;charset=utf-8' },
                data: Data
            }).then(function (response) {

                $scope.QuestionDevice = response.data;
                console.log($scope.QuestionDevice);

                GetAllQuestions();
                if (response.data[0].was_done == true) {
                    Swal.fire({
                        position: 'top',
                        icon: 'success',
                        title: 'Informacion Guardada',
                        showConfirmButton: false,
                        timer: 1500
                    })

                }
                else {
                    Swal.fire({
                        position: 'top',
                        icon: 'success',
                        title: response.data[0].return_message,
                        showConfirmButton: false,
                        timer: 1500
                    })
                }

            }, function errorCallBack(response) {
                console.error("Error get data");
                console.log(response.data);
            })
            // end httpRequest
        }

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
            console.log($scope.QuestionList);

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest

    }

});

$(document).ready(function () {

    // Add Fields validation over Register new Cutter form

    $("#js_SetQuestionForm").validate({
        rules: {
            jv_description_question: { required: true, maxlength: 150 },
            jv_creator_question: { required: true, maxlength: 100 },
        }
    })
})