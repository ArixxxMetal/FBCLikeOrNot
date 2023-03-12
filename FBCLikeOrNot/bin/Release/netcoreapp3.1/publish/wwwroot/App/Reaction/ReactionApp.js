
var app = angular.module("ReactionApp", []);

app.controller("ReactionController", function ($scope, $http) {


    angular.element(document).ready(function () {

        GetAllReactions()
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
            console.log($scope.ReactionList);
            //GetQuestion()

        }, function errorCallBack(response) {
            console.error("Error get data");
            console.log(response.data);
        })
        // end httpRequest
    }

    function SetReaction(iddevice, idreaction) {
        // Call Fields validation 
        
        Data = {
            PARAM_DEVICE_ID: parseInt(iddevice),
            PARAM_REACTION_ID: idreaction
        }
        // start httpRequest 
        $http({
            method: "POST",
            url: "/Reaction/SetReaction",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Data
        }).then(function (response) {
            debugger
            $scope.QuestionDevice = response.data;
            console.log($scope.QuestionDevice);

            if (response.data[0].was_done == true) {
                Swal.fire({
                    position: 'top',
                    icon: 'success',
                    title: 'Muchas Gracias Por participar! ;)',
                    showConfirmButton: false,
                    timer: 1000
                })

                //const Toast = Swal.mixin({
                //    toast: true,
                //    position: 'top',
                //    showConfirmButton: false,
                //    timer: 3000,
                //    timerProgressBar: true,
                //    didOpen: (toast) => {
                //        toast.addEventListener('mouseenter', Swal.stopTimer)
                //        toast.addEventListener('mouseleave', Swal.resumeTimer)
                //    }
                //})

                //Toast.fire({
                //    icon: 'success',
                //    title: 'Muchas Gracias Por participar! ;)'
                //})
            }
            else {

            }

        }, function errorCallBack(response) {
            console.error("Error get data");
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

    refreshAt(10, 26, 0);
    refreshAt(10, 26, 10);
    refreshAt(10, 26, 20);
    refreshAt(10, 26, 30);
});