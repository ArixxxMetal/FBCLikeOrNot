
var app = angular.module("QuestionGraphApp", []);

app.controller("QuestionGraphController", function ($scope, $http) {

    angular.element(document).ready(function () {

        GetAllServices();
    });

    // Declare a variable to hold the chart object
    var chart;

    $scope.service_name = "";
    $scope.device_name = "";
    $scope.myJson = "";
    $scope.service_id_model = null;
    $scope.TotalReactionList = [];

    $scope.DownloadReport = function () {

        //Generate report name by select value
        service_list = $scope.ServiceList;
        const service_id = $scope.service_id_model;
        const service_object = service_list.find(obj => obj.id === service_id);

        // Validate if data was filtered
        var Query = "SELECT * INTO XLSX('" + service_object.nameservice + "-Reacciones Por Preguntas.xlsx',{headers:true}) FROM ?";

        // To download the recor to excel
        alasql(Query, [$scope.TotalReactionList]);

    }
    // End function

    $scope.GenerateGraph = function () {
        $scope.TotalReactionList = [];

        var start_date = moment().subtract(7, 'days');
        var end_date = moment();

        GetTotalReactionListByDate(start_date, end_date);
    }

    var start = moment().subtract(7, 'days');
    var end = moment();

    function GetTotalReactionListByDate(start, end) {

        if ($scope.service_id_model) {

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
                url: "/Reaction/GetQuestionsByAreaGraph",
                headers: { 'Content-Type': 'application/json;charset=utf-8' },
                data: JSON.stringify(Data)
            }).then(function (response) {

                $scope.TotalReactionList = response.data;
                console.log($scope.TotalReactionList);

                var areaname = new Array();
                var totalgood = new Array();
                var totalneutral = new Array();
                var totalbad = new Array();

                for (var i = 0; i < response.data.length; i++) {

                    if (response.data[i].descriptionquestion) {
                        areaname.push(response.data[i].descriptionquestion);
                    }
                    else {
                        areaname.push("NO DATA");
                    }
                    //areaname.push(response.data[i].descriptionquestion);
                    totalgood.push(response.data[i].goodReactions);
                    totalneutral.push(response.data[i].neutralReactions);
                    totalbad.push(response.data[i].badReactions);
                }

                GenerateJsonGraphApex(areaname, totalgood, totalneutral, totalbad);

            }, function errorCallBack(response) {
                console.error("Error get data");
                console.log(response.data);
            })
            // end httpRequest
        }
        else {

            Swal.fire({
                position: 'center',
                width: 600,
                icon: 'success',
                title: 'Servicio Seleccionado No Valido',
                showConfirmButton: false,
                timer: 1500,
            })
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
            console.log($scope.ServiceList);

        }, function errorCallBack(response) {
            console.error("Error getting data");
            console.log(response.data);
        })
        // end httpRequest

    }


    function GenerateJsonGraphApex(areaname, totalgood, totalneutral, totalbad) {
        if (chart) {
            chart.destroy();
        }

        var arr = [totalgood, totalneutral, totalbad];
        var maxRow = arr.map(function (row) { return Math.max.apply(Math, row); });
        var maxvalue = Math.max.apply(null, maxRow);

        //Get max Value for 'Y'
        let i = 0;
        do {
            i = i + 1;
            maxvalue = maxvalue + i;
        } while (maxvalue % 10 === 0);


        //chart.render();
        var apexChart = jQuery(".apexchart-wrapper");
        if (apexChart.length > 0) {
            var colorPalette = ['#00D8B6', '#008FFB', '#FEB019', '#FF4560', '#775DD0']

            // analytics1
            var apexdemo1 = jQuery('#apexgraph')
            if (apexdemo1.length > 0) {
                var options = {
                    chart: {
                        height: 350,
                        type: 'line',
                        shadow: {
                            enabled: true,
                            color: '#000',
                            top: 18,
                            left: 7,
                            blur: 10,
                            opacity: 1
                        },
                        toolbar: {
                            show: false
                        }
                    },
                    colors: ['#20c997', '#ffc107', '#dc3545'],
                    dataLabels: {
                        enabled: true,
                    },
                    stroke: {
                        curve: 'smooth'
                    },
                    series: [{
                        name: "Good",
                        data: totalgood
                    },
                    {
                        name: "Neutral",
                        data: totalneutral
                    },
                    {
                        name: "Bad",
                        data: totalbad
                    }
                    ],
                    grid: {
                        borderColor: '#e7e7e7',
                        row: {
                            colors: ['#f3f3f3', 'transparent'], // takes an array which will be repeated on columns
                            opacity: 0.5
                        },
                    },
                    markers: {

                        size: 6
                    },
                    xaxis: {
                        categories: areaname,
                        title: {
                            text: 'Dispositivo'
                        }
                    },
                    yaxis: {
                        title: {
                            text: 'Total'
                        },
                        min: 0,
                        max: maxvalue
                    },
                    legend: {
                        position: 'top',
                        horizontalAlign: 'right',
                        floating: true,
                        offsetY: -25,
                        offsetX: -5
                    }
                }

                // Initialize the chart and store it in the chart variable
                chart = new ApexCharts(document.querySelector("#apexgraph"), options);
                chart.render();
            }
        }
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
    }, GetTotalReactionListByDate);


});