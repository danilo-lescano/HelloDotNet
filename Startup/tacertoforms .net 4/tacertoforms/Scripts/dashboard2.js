$(function () {

    'use strict';

    /* ChartJS
     * -------
     * Here we will create a few charts using ChartJS
     */

    // -----------------------
    // - MONTHLY SALES CHART -
    // -----------------------

    // Get context with jQuery - using jQuery's .get() method.
    var salesChartCanvas = $('#salesChart').get(0).getContext('2d');
    // This will get the first returned node in the jQuery collection.
    var salesChart = new Chart(salesChartCanvas);

    var salesChartData = {
        labels: ['Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        datasets: [
            {
                label: 'SESI Maracaju',
                fillColor: 'rgba(0, 192, 239, .8)',
                strokeColor: 'rgba(0, 192, 239, .8)',
                pointColor: 'rgba(0, 192, 239, .8)',
                pointStrokeColor: 'rgba(0, 192, 239, .8)',
                pointHighlightFill: 'rgba(0, 192, 239, .8)',
                pointHighlightStroke: 'rgba(0, 192, 239, .8)',
                data: [65, 59, 80, 81, 56, 55]
            },
            {
                label: 'SESI Corumbá',
                fillColor: 'rgba(221, 75, 57, .8)',
                strokeColor: 'rgba(221, 75, 57, .8)',
                pointColor: 'rgba(221, 75, 57, .8)',
                pointStrokeColor: 'rgba(221, 75, 57, .8)',
                pointHighlightFill: 'rgba(221, 75, 57, .8)',
                pointHighlightStroke: 'rgba(221, 75, 57, .8)',
                data: [28, 48, 40, 80, 86, 80]
            },
            {
                label: 'SESI Dourados',
                fillColor: 'rgba(0, 166, 90, .8)',
                strokeColor: 'rgba(0, 166, 90, .8)',
                pointColor: 'rgba(0, 166, 90, .8)',
                pointStrokeColor: 'rgba(0, 166, 90, .8)',
                pointHighlightFill: 'rgba(0, 166, 90, .8)',
                pointHighlightStroke: 'rgba(0, 166, 90, .8)',
                data: [22, 35, 12, 70, 82, 30]
            },
            {
                label: 'SESI Três Lagoas',
                fillColor: 'rgba(243, 156, 18, .8)',
                strokeColor: 'rgba(243, 156, 18, .8)',
                pointColor: 'rgba(243, 156, 18, .8)',
                pointStrokeColor: 'rgba(243, 156, 18, .8)',
                pointHighlightFill: 'rgba(243, 156, 18, .8)',
                pointHighlightStroke: 'rgba(243, 156, 18, .8)',
                data: [20, 15, 22, 30, 50, 19]
            }

        ]
    };

    var salesChartOptions = {
        // Boolean - If we should show the scale at all
        showScale: true,
        // Boolean - Whether grid lines are shown across the chart
        scaleShowGridLines: false,
        // String - Colour of the grid lines
        scaleGridLineColor: 'rgba(0,0,0,.05)',
        // Number - Width of the grid lines
        scaleGridLineWidth: 1,
        // Boolean - Whether to show horizontal lines (except X axis)
        scaleShowHorizontalLines: true,
        // Boolean - Whether to show vertical lines (except Y axis)
        scaleShowVerticalLines: true,
        // Boolean - Whether the line is curved between points
        bezierCurve: true,
        // Number - Tension of the bezier curve between points
        bezierCurveTension: 0.3,
        // Boolean - Whether to show a dot for each point
        pointDot: false,
        // Number - Radius of each point dot in pixels
        pointDotRadius: 4,
        // Number - Pixel width of point dot stroke
        pointDotStrokeWidth: 1,
        // Number - amount extra to add to the radius to cater for hit detection outside the drawn point
        pointHitDetectionRadius: 20,
        // Boolean - Whether to show a stroke for datasets
        datasetStroke: true,
        // Number - Pixel width of dataset stroke
        datasetStrokeWidth: 2,
        // Boolean - Whether to fill the dataset with a color
        datasetFill: true,
        // String - A legend template
        legendTemplate: '<ul class=\'<%=name.toLowerCase()%>-legend\'><% for (var i=0; i<datasets.length; i++){%><li><span style=\'background-color:<%=datasets[i].lineColor%>\'></span><%=datasets[i].label%></li><%}%></ul>',
        // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
        maintainAspectRatio: true,
        // Boolean - whether to make the chart responsive to window resizing
        responsive: true
    };

    // Create the line chart
    salesChart.Line(salesChartData, salesChartOptions);

});


$(function () { 
    var areaChartCanvas = $('#areaChart').get(0).getContext('2d')    
    var areaChart = new Chart(areaChartCanvas)

    var areaChartData = {
        labels: ['Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        datasets: [
            {
                label: 'SESI Maracaju',
                fillColor: 'rgba(0, 192, 239, .8)',
                strokeColor: 'rgba(0, 192, 239, .8)',
                pointColor: 'rgba(0, 192, 239, .8)',
                pointStrokeColor: '#c1c7d1',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(0, 192, 239, .8)',
                data: [10, 5.12, 7.13, 15.2, 9.15, 8.12]
            },
            {
                label: 'SESI Corumbá',
                fillColor: 'rgba(221, 75, 57, .8)',
                strokeColor: 'rgba(221, 75, 57, .8)',
                pointColor: 'rgba(221, 75, 57, .8)',
                pointStrokeColor: 'rgba(221, 75, 57, .8)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(221, 75, 57, .8)',
                data: [8.2, 5.13, 8.10, 8.15, 11.12, 6.12]
            },
            {
                label: 'SESI Dourados',
                fillColor: 'rgba(0, 166, 90, .8)',
                strokeColor: 'rgba(0, 166, 90, .8)',
                pointColor: 'rgba(0, 166, 90, .8)',
                pointStrokeColor: 'rgba(0, 166, 90, .8)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(0, 166, 90, .8)',
                data: [7.14, 5.47, 10.13, 7.12, 8.15, 10.15]
            },
            {
                label: 'SESI Três Lagoas',
                fillColor: 'rgba(243, 156, 18, .8)',
                strokeColor: 'rgba(243, 156, 18, .8)',
                pointColor: 'rgba(243, 156, 18, .8)',
                pointStrokeColor: 'rgba(243, 156, 18, .8)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(243, 156, 18, .8)',
                data: [8.12, 8.47, 7.67, 5.45, 2.1, 8.15]
            }
        ]
    }
    //Gráfico: Novos alunos na plataforma
    var areaChartData1 = {
        labels: ['Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        datasets: [
            {
                label: 'SESI Maracaju',
                fillColor: 'rgba(0, 192, 239, .8)',
                strokeColor: 'rgba(0, 192, 239, .8)',
                pointColor: 'rgba(0, 192, 239, .8)',
                pointStrokeColor: '#c1c7d1',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(0, 192, 239, .8)',
                data: [10, 15, 7, 30, 20, 10]
            },
            {
                label: 'SESI Corumbá',
                fillColor: 'rgba(221, 75, 57, .8)',
                strokeColor: 'rgba(221, 75, 57, .8)',
                pointColor: 'rgba(221, 75, 57, .8)',
                pointStrokeColor: 'rgba(221, 75, 57, .8)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(221, 75, 57, .8)',
                data: [2, 4, 15, 70, 86, 30]
            },
            {
                label: 'SESI Dourados',
                fillColor: 'rgba(0, 166, 90, .8)',
                strokeColor: 'rgba(0, 166, 90, .8)',
                pointColor: 'rgba(0, 166, 90, .8)',
                pointStrokeColor: 'rgba(0, 166, 90, .8)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(0, 166, 90, .8)',
                data: [8, 5, 18, 44, 86, 45]
            },
            {
                label: 'SESI Três Lagoas',
                fillColor: 'rgba(243, 156, 18, .8)',
                strokeColor: 'rgba(243, 156, 18, .8)',
                pointColor: 'rgba(243, 156, 18, .8)',
                pointStrokeColor: 'rgba(243, 156, 18, .8)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(243, 156, 18, .8)',
                data: [10, 13, 23, 50, 70, 20]
            }
        ]
    };

    var areaChartData3 = {
        labels: ['Português', 'Matemática', 'História', 'Geografia', 'Arte', 'Inglês'],
        datasets: [
            {
                label: 'SESI Maracaju',
                fillColor: 'rgba(0, 192, 239, .8)',
                strokeColor: 'rgba(0, 192, 239, .8)',
                pointColor: 'rgba(0, 192, 239, .8)',
                pointStrokeColor: '#c1c7d1',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(0, 192, 239, .8)',
                data: [8.75, 9.15, 8.10, 7.23, 9.98, 6.12]
            },            
            {
                label: 'SESI Dourados',
                fillColor: 'rgba(221, 75, 57, .8)',
                strokeColor: 'rgba(221, 75, 57, .8)',
                pointColor: 'rgba(221, 75, 57, .8)',
                pointStrokeColor: 'rgba(221, 75, 57, .8)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(221, 75, 57, .8)',
                data: [7.73, 6.73, 7.31, 8.14, 8.95, 10]
            },
            {
                label: 'SESI Corumbá',
                fillColor: 'rgba(221, 75, 57, .8)',
                strokeColor: 'rgba(221, 75, 57, .8)',
                pointColor: 'rgba(221, 75, 57, .8)',
                pointStrokeColor: 'rgba(221, 75, 57, .8)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(221, 75, 57, .8)',
                data: [9.15, 5.12, 9.48, 7.32, 9.54, 9.39]
            },
            {
                label: 'SESI Três Lagoas',
                fillColor: 'rgba(243, 156, 18, .8)',
                strokeColor: 'rgba(243, 156, 18, .8)',
                pointColor: 'rgba(243, 156, 18, .8)',
                pointStrokeColor: 'rgba(243, 156, 18, .8)',
                pointHighlightFill: '#fff',
                pointHighlightStroke: 'rgba(243, 156, 18, .8)',
                data: [6.12, 6.14, 8.02, 6.17, 9.14, 9.89]
            }
        ]
    }

    var areaChartOptions = {
        //Boolean - If we should show the scale at all
        showScale: true,
        //Boolean - Whether grid lines are shown across the chart
        scaleShowGridLines: false,
        //String - Colour of the grid lines
        scaleGridLineColor: 'rgba(0,0,0,.05)',
        //Number - Width of the grid lines
        scaleGridLineWidth: 1,
        //Boolean - Whether to show horizontal lines (except X axis)
        scaleShowHorizontalLines: true,
        //Boolean - Whether to show vertical lines (except Y axis)
        scaleShowVerticalLines: true,
        //Boolean - Whether the line is curved between points
        bezierCurve: true,
        //Number - Tension of the bezier curve between points
        bezierCurveTension: 0.3,
        //Boolean - Whether to show a dot for each point
        pointDot: false,
        //Number - Radius of each point dot in pixels
        pointDotRadius: 4,
        //Number - Pixel width of point dot stroke
        pointDotStrokeWidth: 1,
        //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
        pointHitDetectionRadius: 20,
        //Boolean - Whether to show a stroke for datasets
        datasetStroke: true,
        //Number - Pixel width of dataset stroke
        datasetStrokeWidth: 2,
        //Boolean - Whether to fill the dataset with a color
        datasetFill: true,
        //String - A legend template
        legendTemplate: '<ul class="<%=name.toLowerCase()%>-legend"><% for (var i=0; i<datasets.length; i++){%><li><span style="background-color:<%=datasets[i].lineColor%>"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>',
        //Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
        maintainAspectRatio: true,
        //Boolean - whether to make the chart responsive to window resizing
        responsive: true
    }

    //Create the line chart
    areaChart.Line(areaChartData1, areaChartOptions)

    //-------------
    //- LINE CHART -
    //--------------
    var lineChartCanvas = $('#lineChart').get(0).getContext('2d')
    var lineChart = new Chart(lineChartCanvas)
    var lineChartOptions = areaChartOptions
    lineChartOptions.datasetFill = false
    lineChart.Line(areaChartData, lineChartOptions)

    
    //- BAR CHART -
    //-------------
    var barChartCanvas = $('#barChart').get(0).getContext('2d');
    
    var barChart = new Chart(barChartCanvas)
    var barChartData = areaChartData3
    barChartData.datasets[1].fillColor = '#00a65a'
    barChartData.datasets[1].strokeColor = '#00a65a'
    barChartData.datasets[1].pointColor = '#00a65a'
    var barChartOptions = {
        //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
        scaleBeginAtZero: true,
        //Boolean - Whether grid lines are shown across the chart
        scaleShowGridLines: true,
        //String - Colour of the grid lines
        scaleGridLineColor: 'rgba(0,0,0,.05)',
        //Number - Width of the grid lines
        scaleGridLineWidth: 1,
        //Boolean - Whether to show horizontal lines (except X axis)
        scaleShowHorizontalLines: true,
        //Boolean - Whether to show vertical lines (except Y axis)
        scaleShowVerticalLines: true,
        //Boolean - If there is a stroke on each bar
        barShowStroke: true,
        //Number - Pixel width of the bar stroke
        barStrokeWidth: 2,
        //Number - Spacing between each of the X value sets
        barValueSpacing: 5,
        //Number - Spacing between data sets within X values
        barDatasetSpacing: 1,
        //String - A legend template
        legendTemplate: '<ul class="<%=name.toLowerCase()%>-legend"><% for (var i=0; i<datasets.length; i++){%><li><span style="background-color:<%=datasets[i].fillColor%>"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>',
        //Boolean - whether to make the chart responsive
        responsive: true,
        maintainAspectRatio: true
    }

    barChartOptions.datasetFill = false
    barChart.Bar(barChartData, barChartOptions)
})
