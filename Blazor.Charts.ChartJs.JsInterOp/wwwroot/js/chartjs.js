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

window.drawChart = (data) => {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawGoogleChart);
    function drawGoogleChart(data) {
        //var jsonData = $.ajax({
        //    url: "/Index?handler=ChartData",
        //    dataType: "json",
        //    async: false
        //}).responseText;
        //var jsondata = new google.visualization.DataTable(data);
        //var jsondata = new google.visualization.DataTable(data);

            //var jsondata = google.visualization.arrayToDataTable([
            //    ['Task', 'Hours per Day'],
            //    ['Work', 11],
            //    ['Eat', 2],
            //    ['Commute', 2],
            //    ['Watch TV', 2],
            //    ['Sleep', 7]
            //]);
        var jsondata = new google.visualization.DataTable(
            {
                cols: [{ id: 'task', label: 'Employee Name', type: 'string' },
                { id: 'hours', label: 'Hours', type: 'number' }],
                rows: [{ c: [{ v: 'Mike' }, { v: 4 }] },
                { c: [{ v: 'Bob' }, { v: 5 }] },
                { c: [{ v: 'Alice' }, { v: 7 }] },
                { c: [{ v: 'Frank' }, { v: 11 }] },
                { c: [{ v: 'Floyd' }, { v: 13 }] },
                { c: [{ v: 'Fritz' }, { v: 6 }] }
                ]
            }
        )

        var options = {
            title: 'My Daily Activities',
            is3D: true,
        };

        var chart = new google.visualization.PieChart(document.getElementById("piechart"));
        chart.draw(jsondata, options);
        var chart = new google.visualization.LineChart(document.getElementById("curve_chart"));
        chart.draw(jsondata, options);
    }
    //google.charts.load("current", { "packages": ["corechart"] });
    //google.charts.setOnLoadCallback(drawChart);

    //function drawChart(data) {

    //    var data = google.visualization.arrayToDataTable([
    //        [{ label: 'Year', id: 'year' },
    //        { label: 'Sales', id: 'Sales', type: 'number' }, // Use object notation to explicitly specify the data type.
    //        { label: 'Expenses', id: 'Expenses', type: 'number' }],
    //        ['2014', 1000, 400],
    //        ['2015', 1170, 460],
    //        ['2016', 660, 1120],
    //        ['2017', 1030, 540]]);

    //    //var data = google.visualization.arrayToDataTable(data, false);
    //    //var data = google.visualization.arrayToDataTable(data);

    //    var options = {
    //        title: 'Company Performance',
    //        curveType: 'function',
    //        legend: { position: 'bottom' }
    //    };

    //    var chart = new google.visualization.LineChart(document.getElementById("curve_chart"));

    //    chart.draw(data, options);
    //}
};
