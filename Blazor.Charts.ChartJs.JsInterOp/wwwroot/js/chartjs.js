window.drawChart = (data) => {
    google.charts.load('current', { 'packages': ['line'] });
    google.setOnLoadCallback(drawGoogleChart);
    function drawGoogleChart() {
        var jData = new google.visualization.DataTable(data);

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
