
var app = angular.module("ServiceApp", []);

app.controller("ServiceController", function ($scope, $http) {


    angular.element(document).ready(function () {

        GetAllServices();
        GetAllQuestions();
    });

    $scope.ServiceName = "";
    $scope.CreateBy = "";

    $scope.Access = function () {
        LoginAccess()
    }


    $scope.SelectQuestion = function () {
        debugger
        $scope.selected_description_question = $scope.dropdown_question;
    }

    $scope.ShowAddNewServiceModal = function () {
        $scope.add_description_question = "";
        $scope.add_service_name = "";
        $scope.add_create_by = "";

        $('#js_CreateService').modal('show');
    }

    $scope.ShowUpdateModal = function (_service) {
        $scope.update_service_id = _service.idservice;
        $scope.update_description_question = _service.descriptionquestion;
        $scope.update_service_name = _service.nameservice;
        $scope.update_create_by = _service.createbyservice;

        $('#js_UpdateService').modal('show');
    }

    $scope.ShowSetQuestionModal = function (_service) {
        $scope.set_question_service_id = _service.idservice;
        //.set_question_description_question = _service.descriptionquestion;
        //$scope.set_question_service_name = _service.nameservice;
        //$scope.set_question_create_by = _service.createbyservice;

        $('#js_SetQuestion').modal('show');
    }

    $scope.AddNewService = function () {
        AddService()
    }

    $scope.UpdateCurrentService = function () {
        UpdateService()
    }
    
    $scope.AssignQuestion = function () {
        SetQuestion()
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
            debugger
            $scope.ServiceList = response.data;
            console.table($scope.ServiceList);

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
            debugger
            $scope.QuestionList = response.data;
            console.table($scope.QuestionList);

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest

    }

    function AddService() {
        // Call Fields validation 
        if ($("#js_CreateServiceForm").valid()) {
            var Data = {
                PARAM_SERVICE_NAME: $scope.add_service_name,
                PARAM_SERVICE_QUESTION: $scope.add_description_question,
                PARAM_CREATE_BY: $scope.add_create_by
            }

        // start httpRequest 
            $http({
                method: "POST",
                url: "/Service/AddService",
                headers: { 'Content-Type': 'application/json;charset=utf-8' },
                data: Data
            }).then(function (response) {
                debugger
                $scope.ServiceResponse = response.data;
                console.table($scope.ServiceResponse);
                GetAllServices();
                GetAllQuestions();
                if (response.data[0].was_done == true) {
                    Swal.fire({
                        position: 'top',
                        icon: 'success',
                        title: 'Informacion Guardada',
                        showConfirmButton: false,
                        timer: 1000
                    })

                }
                else {

                }

            }, function errorCallBack(response) {
                console.error("Error updating database");
                console.log(response.data);
            })
            // end httpRequest
        }

    }

    function UpdateService() {
        // Call Fields validation 
        if ($("#js_UpdateServiceForm").valid()) {
            var Data = {
                PARAM_SERVICE_ID: $scope.update_service_id,
                PARAM_SERVICE_NAME: $scope.add_service_name,
                PARAM_EDIT_BY: ""
            }

            // start httpRequest 
            $http({
                method: "POST",
                url: "/Service/UpdateService",
                headers: { 'Content-Type': 'application/json;charset=utf-8' },
                data: Data
            }).then(function (response) {
                debugger
                $scope.ServiceResponse = response.data;
                console.table($scope.ServiceResponse);
                GetAllServices();
                GetAllQuestions();

                if (response.data[0].was_done == true) {
                    Swal.fire({
                        position: 'top',
                        icon: 'success',
                        title: 'Informacion Guardada',
                        showConfirmButton: false,
                        timer: 1000
                    })

                }
                else {

                }

            }, function errorCallBack(response) {
                console.error("Error updating database");
                console.log(response.data);
            })
            // end httpRequest

        }
    }

    function SetQuestion() {
        // Call Fields validation 
        Data = {
            PARAM_SERVICE_ID: $scope.set_question_service_id,
            PARAM_DESCRIPTION_QUESTION: $scope.selected_description_question,
            PARAM_CREATE_BY: ""
        }
        // start httpRequest 
        $http({
            method: "POST",
            url: "/Service/SetQuestionService",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Data
        }).then(function (response) {
            debugger
            $scope.QuestionDevice = response.data;
            console.log($scope.QuestionDevice);

            GetAllServices();
            GetAllQuestions();
            if (response.data[0].was_done == true) {
                Swal.fire({
                    position: 'top',
                    icon: 'success',
                    title: 'Informacion Guardada',
                    showConfirmButton: false,
                    timer: 1000
                })

            }
            else {

            }

        }, function errorCallBack(response) {
            console.error("Error get data");
            console.log(response.data);
        })
        // end httpRequest

    }
});

$(document).ready(function () {

    // Add Fields validation over Register new Cutter form
    $("#js_CreateServiceForm").validate({
        rules: {
            jv_name_service_add: { required: true, maxlength: 50 },
            jv_create_by_add: { required: true, maxlength: 50 },
            jv_description_question_add: { required: true, maxlength: 50 },
        }
    })

    $("#js_UpdateServiceForm").validate({
        rules: {
            jv_name_service_update: { required: true, maxlength: 50 },
            jv_create_by_update: { required: true, maxlength: 50 },
            jv_description_question_update: { required: true, maxlength: 50 },
        }
    })

    $("#js_SetQuestionForm").validate({
        rules: {
            jv_description_question: { required: true, maxlength: 100 },
        }
    })
})