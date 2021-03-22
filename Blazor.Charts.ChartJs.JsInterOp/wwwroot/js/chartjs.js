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
    google.charts.load("current", { "packages": ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {

        var data = google.visualization.arrayToDataTable([
            ['Year', 'Sales', 'Expenses'],
            ['2004', 1000, 400],
            ['2005', 1170, 460],
            ['2006', 660, 1120],
            ['2007', 1030, 540]
        ]);

        var options = {
            title: 'Company Performance',
            curveType: 'function',
            legend: { position: 'bottom' }
        };

        var chart = new google.visualization.LineChart(document.getElementById("curve_chart"));

        chart.draw(data, options);
    }
};
