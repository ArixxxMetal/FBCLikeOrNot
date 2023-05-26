
var app = angular.module("DeviceApp", []);

app.controller("DeviceController", function ($scope, $http) {


    angular.element(document).ready(function () {

        GetAllDevices();
        GetAllServices();
    });

    $scope.NameModel = "";
    $scope.PasswordModel = "";
    $scope.add_service_id = null;

    $scope.Access = function () {
        LoginAccess()
    }

    $scope.ShowAddNewDeviceModal = function () {
        
        $scope.add_service_id = null;
        $scope.add_device_name = "";
        $scope.add_create_by = "";

        $('#js_CreateDevice').modal('show');
    }

    $scope.ShowUpdateModal = function (_device) {
        $scope.update_id_device = _device.iddevice;
        $scope.update_id_service = _device.id_service;
        $scope.update_device_name = _device.namedevice;
        
        $('#js_UpdateDevice').modal('show');
    }

    
    $scope.AddNewDevice = function () {
        AddDevice()
    }

    $scope.UpdateSelectedDevice = function () {
        UpdateDevice()
    }

    function GetAllDevices() {
        // Call Fields validation 

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Device/GetDevicesList",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: {}
        }).then(function (response) {
            
            $scope.DeviceList = response.data;
            console.log($scope.DeviceList);

        }, function errorCallBack(response) {
            console.error("Error get data");
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
            console.error("Error get data");
            console.log(response.data);
        })
        // end httpRequest
    }

    function AddDevice() {
        // Call Fields validation 
        
        Data = {
            PARAM_DEVICE_NAME: $scope.add_device_name,
            PARAM_SERVICE_ID: $scope.add_service_id,
            PARAM_CREATE_BY: "test"
        }

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Device/AddDevice",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Data
        }).then(function (response) {
            
            $scope.AddDeviceResponse = response.data;
            console.log($scope.AddDeviceResponse);
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

            GetAllDevices();
            $('#js_CreateDevice').modal('hide');

        }, function errorCallBack(response) {
            console.error("Error get data");
            console.log(response.data);
        })
        // end httpRequest
    }

    function UpdateDevice() {
        // Call Fields validation 
        
        Data = {
            PARAM_DEVICE_ID: $scope.update_id_device,
            PARAM_DEVICE_NAME: $scope.update_device_name,
            PARAM_SERVICE_ID: $scope.update_id_service,
            PARAM_EDIT_BY: "test"
        }

        // start httpRequest 
        $http({
            method: "POST",
            url: "/Device/UpdateDevice",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: Data
        }).then(function (response) {
            debugger
            $scope.UpdateDeviceResponse = response.data;
            console.log($scope.UpdateDeviceResponse);
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

            GetAllDevices();
            $('#js_UpdateDevice').modal('hide');

        }, function errorCallBack(response) {
            console.error("Error get data");
            console.log(response.data);
        })
        // end httpRequest
 
    }

});