//window.drawChart = (data) => {
//    google.load("visualization", "1", { packages: ["orgchart"] });
//    google.setOnLoadCallback(drawGoogleChart);
//    function drawGoogleChart() {
//        var dt = new google.visualization.DataTable();
//        dt.addColumn('string', 'Entity');
//        dt.addColumn('string', 'ParentEntity');
//        dt.addColumn('string', 'ToolTip');
//        for (var i = 0; i < data.length; i++) {
//            var memberId = data[i].memberId.toString();
//            var memberName = data[i].name;
//            var parentId = data[i].parentId != null ? data[i].parentId.toString() : '';
//            dt.addRows([[{
//                v: memberId,
//                f: memberName + '<div><img src = "img/' + memberId + '.png" /></div>'
//            }, parentId, memberName]]);
//        }
//        var chart = new google.visualization.OrgChart(document.getElementById("chart"));
//        chart.draw(dt, { allowHtml: true });
//    }
//};

//window.drawChart = (data) => {
//    google.charts.load('current', { 'packages': ['corechart'] });
//    google.charts.setOnLoadCallback(drawGoogleChart);
//    function drawGoogleChart() {
//        //var jsonData = $.ajax({
//        //    url: "/Index?handler=ChartData",
//        //    dataType: "json",
//        //    async: false
//        //}).responseText;

//        var jsondata = new google.visualization.DataTable(data);

//        //var jsondata = google.visualization.arrayToDataTable([
//        //    ['Task', 'Hours per Day'],
//        //    ['Work', 11],
//        //    ['Eat', 2],
//        //    ['Commute', 2],
//        //    ['Watch TV', 2],
//        //    ['Sleep', 7]
//        //]);

//        //    ['Year', 'Sales', 'Expenses'],
//        //    ['2004', 1000, 400],
//        //    ['2005', 1170, 460],
//        //    ['2006', 660, 1120],
//        //    ['2007', 1030, 540]

//        //var data = google.visualization.arrayToDataTable([
//        //    [{ label: 'Year', id: 'year' },
//        //      { label: 'Sales', id: 'Sales', type: 'number' }, // Use object notation to explicitly specify the data type.
//        //      { label: 'Expenses', id: 'Expenses', type: 'number' }],
//        //    ['2014', 1000, 400],
//        //    ['2015', 1170, 460],
//        //    ['2016', 660, 1120],
//        //    ['2017', 1030, 540]]);

//        //var jsondata = new google.visualization.DataTable(
//        //    {
//        //        cols: [{ id: 'task', label: 'Employee Name', type: 'string' },
//        //        { id: 'hours', label: 'Hours', type: 'number' }],
//        //        rows: [{ c: [{ v: 'Mike' }, { v: 4 }] },
//        //        { c: [{ v: 'Bob' }, { v: 5 }] },
//        //        { c: [{ v: 'Alice' }, { v: 7 }] },
//        //        { c: [{ v: 'Frank' }, { v: 11 }] },
//        //        { c: [{ v: 'Floyd' }, { v: 13 }] },
//        //        { c: [{ v: 'Fritz' }, { v: 6 }] }
//        //        ]
//        //    }
//        //)

//        var options = {
//            title: 'My Daily Activities',
//            is3D: true,
//        };

//        var chart = new google.visualization.PieChart(document.getElementById("piechart"));
//        chart.draw(jsondata, options);
//        var chart = new google.visualization.LineChart(document.getElementById("curve_chart"));
//        chart.draw(jsondata, options);

//        var chart = new google.charts.Line(document.getElementById('line_top_x'));
//        chart.draw(data, google.charts.Line.convertOptions(options));
//    }
//};

window.drawChart = (data) => {
    google.charts.load('current', { 'packages': ['line'] });
    google.setOnLoadCallback(drawGoogleChart);
    function drawGoogleChart() {
        var jData = new google.visualization.DataTable(data);
        //var data = new google.visualization.DataTable();
        //data.addColumn('number', 'Day');
        //data.addColumn('number', 'Guardians of the Galaxy');
        //data.addColumn('number', 'The Avengers');
        //data.addColumn('number', 'Transformers: Age of Extinction');

        //data.addRows([
        //    [1, 37.8, 80.8, 41.8],
        //    [2, 30.9, 69.5, 32.4],
        //    [3, 25.4, 57, 25.7],
        //    [4, 11.7, 18.8, 10.5],
        //    [5, 11.9, 17.6, 10.4],
        //    [6, 8.8, 13.6, 7.7],
        //    [7, 7.6, 12.3, 9.6],
        //    [8, 12.3, 29.2, 10.6],
        //    [9, 16.9, 42.9, 14.8],
        //    [10, 12.8, 30.9, 11.6],
        //    [11, 5.3, 7.9, 4.7],
        //    [12, 6.6, 8.4, 5.2],
        //    [13, 4.8, 6.3, 3.6],
        //    [14, 4.2, 6.2, 3.4]
        //]);

        var options = {
            chart: {
                title: 'Box Office Earnings in First Two Weeks of Opening',
                subtitle: 'in millions of dollars (USD)'
            },
            width: 900,
            height: 500,
            axes: {
                x: {
                    0: { side: 'top' }
                }
            }
        };

        var chart = new google.charts.Line(document.getElementById('line_top_x'));

        chart.draw(jData, google.charts.Line.convertOptions(options));
    }
};
