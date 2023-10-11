
var app = angular.module("DashboardApp", []);

app.controller("DashboardController", function ($scope, $http) {

    angular.element(document).ready(function () {

        GetTotalReactionList()
               
    });

    $scope.service_name = "";
    $scope.device_name = "";
    $scope.myJson = "";
    $scope.TotalReactionList = [];

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
        $scope.TotalReactionList = [];
        // start httpRequest 
        $http({
            method: "POST",
            url: "/Reaction/GetTotalReactions",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: {}
        }).then(function (response) {

            $scope.TotalReactionList = response.data;
            //console.log($scope.TotalReactionList);
            //GetQuestion()

            var areaname = new Array();
            var totalgood = new Array();
            var totalneutral = new Array();
            var totalbad = new Array();

            for (var i = 0; i < response.data.length; i++) {

                areaname.push(response.data[i].nameservice);
                totalgood.push(response.data[i].goodTotalReactions);
                totalneutral.push(response.data[i].neutralTotalReactions);
                totalbad.push(response.data[i].badTotalReactions);

            }

            //GenerateJsonGraph(areaname, totalgood, totalneutral, totalbad)
            GenerateJsonGraphApex(areaname, totalgood, totalneutral, totalbad)

        }, function errorCallBack(response) {
            console.error("Error get data");
            console.log(response.data);
        })
        // end httpRequest
    }

    function GenerateJsonGraphApex(areaname, totalgood, totalneutral, totalbad) {

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
                            text: 'Area (Service)'
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

                var chart = new ApexCharts(
                    document.querySelector("#apexgraph"),
                    options
                );

                chart.render();
            }
        }
    }

    function GenerateJsonGraph(areaname, totalgood, totalneutral, totalbad) {

        $scope.myJson = {
            gui: {
                contextMenu: {
                    button: {
                        visible: 0
                    }
                }
            },
            backgroundColor: "#434343",
            globals: {
                shadow: false,
                fontFamily: "Helvetica"
            },
            type: "area",

            legend: {
                layout: "x4",
                backgroundColor: "transparent",
                borderColor: "transparent",
                marker: {
                    borderRadius: "50px",
                    borderColor: "transparent"
                },
                item: {
                    fontColor: "white"
                }

            },
            scaleX: {
                maxItems: areaname.length,
                transform: {
                    type: 'string'
                },
                zooming: true,
                values: areaname,
                lineColor: "white",
                lineWidth: "1px",
                tick: {
                    lineColor: "white",
                    lineWidth: "1px"
                },
                item: {
                    fontColor: "white"
                },
                guide: {
                    visible: false
                }
            },
            scaleY: {
                lineColor: "white",
                lineWidth: "1px",
                tick: {
                    lineColor: "white",
                    lineWidth: "1px"
                },
                guide: {
                    lineStyle: "solid",
                    lineColor: "#626262"
                },
                item: {
                    fontColor: "white"
                },
            },
            tooltip: {
                visible: false
            },
            crosshairX: {
                scaleLabel: {
                    backgroundColor: "#fff",
                    fontColor: "black"
                },
                plotLabel: {
                    backgroundColor: "#434343",
                    fontColor: "#FFF",
                    _text: "Number of hits : %v"
                }
            },
            plot: {
                lineWidth: "2px",
                aspect: "spline",
                marker: {
                    visible: false
                }
            },
            series: [{
                text: "Good Reactions",
                values: totalgood,
                backgroundColor1: "#4AD8CC",
                backgroundColor2: "#272822",
                lineColor: "#4AD8CC"
            }, {
                text: "Neutral Reactions",
                values: totalneutral,
                backgroundColor1: "#1D8CD9",
                backgroundColor2: "#1D8CD9",
                lineColor: "#1D8CD9"
            }, {
                text: "Bad Reactions",
                values: totalbad,
                backgroundColor1: "#D8CD98",
                backgroundColor2: "#272822",
                lineColor: "#D8CD98"
            }]
        };
    }

    var start = moment().subtract(29, 'days');
    var end = moment();

    function GetTotalReactionListByDate(start, end) {
        $scope.TotalReactionList = [];
        $('#reportrange span').html(start.format('DD D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
        console.log("Start: " + start.format('DD-MM-YYYY') + " End: " + end.format('DD-MM-YYYY') + " ")

        $scope.js_startdate = start;
        $scope.js_enddate = end;

        
        $scope.startdate = start.format('YYYY-MM-DD');
        $scope.enddate = end.format('YYYY-MM-DD');

        Data = {
            PARAM_BEGIN_DATE: $scope.startdate,
            PARAM_END_DATE: $scope.enddate
        }
        $scope.TotalReactionList = "";
        // start httpRequest 
        $http({
            method: "POST",
            url: "/Reaction/GetTotalReactionsByRangeDate",
            headers: { 'Content-Type': 'application/json;charset=utf-8' },
            data: JSON.stringify(Data)
        }).then(function (response) {

            $scope.TotalReactionList = response.data;
            console.log($scope.TotalReactionList);
            //GetQuestion()

            var areaname = new Array();
            var totalgood = new Array();
            var totalneutral = new Array();
            var totalbad = new Array();

            for (var i = 0; i < response.data.length; i++) {

                areaname.push(response.data[i].nameservice);
                totalgood.push(response.data[i].goodTotalReactions);
                totalneutral.push(response.data[i].neutralTotalReactions);
                totalbad.push(response.data[i].badTotalReactions);
            }
            //GenerateJsonGraph(areaname, totalgood, totalneutral, totalbad)
            GenerateJsonGraphApex(areaname, totalgood, totalneutral, totalbad);
            GenerateJsonGraphApex(areaname, totalgood, totalneutral, totalbad);

        }, function errorCallBack(response) {
            console.error("Error get data");
            console.log(response.data);
        })
        // end httpRequest
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

    //GetTotalReactionListByDate(start, end);

});