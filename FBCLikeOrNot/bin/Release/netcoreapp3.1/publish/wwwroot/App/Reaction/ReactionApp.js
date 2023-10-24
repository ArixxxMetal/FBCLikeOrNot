
var app = angular.module("ReactionApp", []);

app.controller("ReactionController", function ($scope, $http) {


    angular.element(document).ready(function () {

        GetAllReactions()
    });

    $scope.service_name = "";
    $scope.device_name = "";
    $scope.current_question_assigned_length = 0;
    $scope.counter_questions = $scope.current_question_assigned_length + 1;

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
        

        try {
            // Get a reference to the element
            var flipCardElement = $("#myFlipCard");


            // Toggle the class to add it back
            flipCardElement.toggleClass("slide_left_animation");

        } catch {
            console.error("An error occurred:", error.message);
        }
        
        SetReaction($('#device_id').html(), _reaction.idreaction);
    }

    //$scope.ChangeQuestionReaction = function () {
    //    debugger
    //    let max_length = $scope.QuestionAssignedList.length - 1;
    //    let current_length = 0;

    //    current_length = $scope.current_question_assigned_length + 1;

    //    if ($scope.current_question_assigned_length == max_length) {

    //        $scope.current_question_assigned_length = 0;

    //        $scope.QuestionTitle = $scope.QuestionAssignedList[0].descriptionquestion;

    //        Swal.fire({
    //            position: 'center',
    //            width: 600,
    //            icon: 'success',
    //            title: 'Muchas Gracias Por Participar!',
    //            imageUrl: '/img/Reactions/blink_reaction.gif',
    //            imageWidth: 300,
    //            showConfirmButton: false,
    //            timer: 1500,
    //        })
    //    }
    //    else {

    //        $scope.QuestionTitle = $scope.QuestionAssignedList[current_length].descriptionquestion;

    //        $scope.current_question_assigned_length = $scope.current_question_assigned_length + 1;
    //    }

    //}

    function ChangeQuestionReaction() {
        
        let max_length = $scope.QuestionAssignedList.length - 1;
        let current_length = 0;

        current_length = $scope.current_question_assigned_length + 1;
        //$scope.counter_questions = $scope.counter_questions + 1
        try {
            
            if ($scope.current_question_assigned_length == max_length) {

                Swal.fire({
                    position: 'center',
                    width: 600,
                    icon: 'success',
                    title: 'Muchas Gracias Por Participar!',
                    imageUrl: '/img/Reactions/blink_reaction.gif',
                    imageWidth: 300,
                    showConfirmButton: false,
                    timer: 1500,
                })

                $scope.current_question_assigned_length = 0;
                $scope.counter_questions = $scope.current_question_assigned_length + 1;
                $scope.QuestionTitle = $scope.QuestionAssignedList[0].descriptionquestion;

            }
            else {

                $scope.QuestionTitle = $scope.QuestionAssignedList[current_length].descriptionquestion;
                $scope.current_question_assigned_length = $scope.current_question_assigned_length + 1;
                $scope.counter_questions = $scope.counter_questions + 1
            }

        } catch {
            
            console.error("An error occurred:", error.message);
        }

         setTimeout(function () {

            $("#myFlipCard").removeClass("slide_left_animation");

         }, 1000);

    }

    function GetAllReactions() {
        // Call Fields validation 

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Reaction/GetAllReactions",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: {}
        }).then(function (response) {
            
            $scope.ReactionList = response.data;
            //console.log($scope.ReactionList);         

        }, function errorCallBack(response) {
            console.error("Error to get data");
            console.log(response.data);
        })
        // end httpRequest
    }

    function GetQuestionsByServiceId(service_id) {
        
        var Questions_Parameter = {
            PARAM_SERVICE_ID: parseInt(service_id)
        }
        // start httpRequest 
        $http({
            method: "POST",
            url: "/Question/GetQuestionsById",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Questions_Parameter
        }).then(function (response) {

            let current_length = $scope.current_question_assigned_length;

            $scope.QuestionAssignedList = response.data;
            console.log($scope.QuestionAssignedList);
            $scope.QuestionTitle = $scope.QuestionAssignedList[current_length].descriptionquestion;

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest
    }

    function SetReaction(iddevice, idreaction) {

        let current_length = $scope.current_question_assigned_length;
        let id_log_question = $scope.QuestionAssignedList[current_length].id;

        Data = {
            PARAM_DEVICE_ID: parseInt(iddevice),
            PARAM_REACTION_ID: idreaction,
            PARAM_QUESTION_LOG_ID: parseInt(id_log_question)
        }

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Reaction/SetReaction",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Data
        }).then(function (response) {

            $scope.QuestionDevice = response.data;

            if (response.data[0].was_done == true) {
                ChangeQuestionReaction();
            }
            else {
                console.log(response.data);
                let error_response = response.data;

                Swal.fire({
                    position: 'center',
                    width: 600,
                    icon: 'success',
                    title: error_response,
                    showConfirmButton: false,
                    timer: 1500,
                })
            }

        }, function errorCallBack(response) {
            console.error("Error to get data");
            console.log(response.data);
        })
        // end httpRequest

    }


    function refreshAt(hours, minutes, seconds) {
        var now = new Date();
        var then = new Date();

        if (now.getHours() > hours ||
            (now.getHours() == hours && now.getMinutes() > minutes) ||
            now.getHours() == hours && now.getMinutes() == minutes && now.getSeconds() >= seconds) {
            then.setDate(now.getDate() + 1);
        }
        then.setHours(hours);
        then.setMinutes(minutes);
        then.setSeconds(seconds);

        var timeout = (then.getTime() - now.getTime());
        setTimeout(function () { window.location.reload(true); }, timeout);
    }

    refreshAt(6, 26, 0);
    refreshAt(7, 26, 0);
    refreshAt(8, 26, 0);
    refreshAt(9, 26, 0);
    refreshAt(10, 26, 0);
    refreshAt(11, 26, 0);
    refreshAt(12, 26, 0);
    refreshAt(13, 26, 0);
    refreshAt(14, 26, 0);
    refreshAt(15, 26, 0);
    refreshAt(16, 26, 0);
    refreshAt(17, 26, 0);
    refreshAt(18, 26, 0);

    setTimeout(GetQuestionsByServiceId($('#service_id').html()), 1000);
});
