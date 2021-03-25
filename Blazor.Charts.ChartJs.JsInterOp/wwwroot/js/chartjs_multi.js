window.drawChart = (data) => {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawGoogleChart);
    function drawGoogleChart() {
        //var jsonData = $.ajax({
        //    url: "/Index?handler=ChartData",
        //    dataType: "json",
        //    async: false
        //}).responseText;

        var jsondata = new google.visualization.DataTable(data);
        //// creates a new, empty DataTable and then populates it manually
        //var jsondata = google.visualization.arrayToDataTable([
        //    ['Task', 'Hours per Day'],
        //    ['Work', 11],
        //    ['Eat', 2],
        //    ['Commute', 2],
        //    ['Watch TV', 2],
        //    ['Sleep', 7]
        //]);

        //// Use object notation to explicitly specify the data type.
        //var data = google.visualization.arrayToDataTable([
        //    [{ label: 'Year', id: 'year' },
        //      { label: 'Sales', id: 'Sales', type: 'number' }, 
        //      { label: 'Expenses', id: 'Expenses', type: 'number' }],
        //    ['2014', 1000, 400],
        //    ['2015', 1170, 460],
        //    ['2016', 660, 1120],
        //    ['2017', 1030, 540]]);

        //// Demonstrates instantiating and populating a DataTable with a literal string
        //var data = new google.visualization.DataTable(
        //    {
        //        cols: [{ id: 'task', label: 'Employee Name', type: 'string' },
        //        { id: 'hours', label: 'Hours', type: 'number' }],
        //        rows: [{ c: [{ v: 'Mike' }, { v: 4 }] },
        //        { c: [{ v: 'Bob' }, { v: 5 }] },
        //        { c: [{ v: 'Alice' }, { v: 7 }] },
        //        { c: [{ v: 'Frank' }, { v: 11 }] },
        //        { c: [{ v: 'Floyd' }, { v: 13 }] },
        //        { c: [{ v: 'Fritz' }, { v: 6 }] }
        //        ]
        //    }
        //)

        var options = {
            title: 'My Daily Activities',
            is3D: true,
        };

        var chart = new google.visualization.PieChart(document.getElementById("piechart"));
        chart.draw(jsondata, options);
        var chart = new google.visualization.LineChart(document.getElementById("curve_chart"));
        chart.draw(jsondata, options);

        var chart = new google.charts.Line(document.getElementById('line_top_x'));
        chart.draw(data, google.charts.Line.convertOptions(options));
    }
};