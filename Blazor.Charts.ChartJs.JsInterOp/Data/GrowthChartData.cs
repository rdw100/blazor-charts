using System.Collections.Generic;
using System.Text.Json;

namespace Blazor.Charts.ChartJs.JsInterOp.Data
{
    public class GrowthChartData
    {
        public string GetChartDataTable()
        {
            List<Col> cols = new List<Col>()
            {
                new Col { id = "lengthincm", label = "Lengthincm", type = "number" },
                new Col { id = "p3", label = "P3", type = "number" },
                new Col { id = "p15", label = "P15", type = "number" },
                new Col { id = "p50", label = "P50", type = "number" },
                new Col { id = "p85", label = "P85", type = "number" },
                new Col { id = "p97", label = "P97", type = "number" },
                new Col { id = "score", label = "Score", type = "number" },
            };

            List<WFL_P> wfl = new List<WFL_P>() {
                new WFL_P(1, 2, 3, 4, 5, 6, 7 ),
                new WFL_P(8, 9, 10, 11, 12, 13, 14 ),
                new WFL_P(15, 16, 17, 18, 19, 20, null ),
                new WFL_P(22, 23, 24, 25, 26, 27, 28 ),
                new WFL_P(29, 30, 31, 32, 33, 34, 35 )
            };

            List<Row> rows = new List<Row>();
            foreach (var item in wfl)
            {
                rows.Add(new Row
                {
                    c = new List<C>()
                    {
                        new C { v = item.Lengthincm },
                        new C { v = item.P3 },
                        new C { v = item.P15 },
                        new C { v = item.P50 },
                        new C { v = item.P85 },
                        new C { v = item.P97 },
                        new C { v = item.Score }
                    }
                });
            }

            // Datatable
            DataTable gChart = new DataTable();
            gChart.cols = cols;
            gChart.rows = rows;

            string sJson = JsonSerializer.Serialize(gChart);
            return sJson;
        }

        public string GetData()
        {
            var chart = new DataTable
            {
                cols = new List<Col>
                {
                    new Col { id = "year", label = "Year", type = "string" },
                    new Col { id = "sales", label = "Sales", type = "number" },
                    new Col { id = "expenses", label = "Expenses", type = "number" }
                },
                rows = new List<Row>
                {
                    new Row
                    {
                        c = new List<C>
                        {
                            new C { v = "2017" },
                            new C { v = 200 },
                            new C { v = 400 }
                        }
                    },
                    new Row
                    {
                        c = new List<C>
                        {
                            new C { v = "2018" },
                            new C { v = 900 },
                            new C { v = 600 }
                        }
                    },
                    new Row 
                    {
                        c = new List<C>
                        {
                            new C { v = "2019" },
                            new C { v = 1000 },
                            new C { v = 400 }
                        }
                    },
                    new Row 
                    {
                        c = new List<C>
                        {
                            new C { v = "2020" },
                            new C { v = 1170 },
                            new C { v = 460 }
                        }
                    },
                    new Row 
                    {
                        c = new List<C>
                        {
                            new C { v = "2021" },
                            new C { v = 660 },
                            new C { v = 1120 }
                        }
                    }
                }
            };

            string jsonString = JsonSerializer.Serialize(chart);

            return jsonString;
        }
    }

    public class DataTable
    {
        public List<Col> cols { get; set; }
        public List<Row> rows { get; set; }
    }

    public class Col
    {
        public string id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
    }

    public class C
    {
        public dynamic v { get; set; }
        //public object f { get; set; }
    }

    public class Row
    {
        public List<C> c { get; set; }
    }

    public class WFL_P
    {
        public WFL_P(decimal lengthincm, decimal p3, decimal p15, decimal p50, decimal p85, decimal p97, decimal? score)
        {
            Lengthincm = lengthincm;
            P3 = p3;
            P15 = p15;
            P50 = p50;
            P85 = p85;
            P97 = p97;
            Score = score;
        }

        public decimal Lengthincm { get; set; }
        public decimal P3 { get; set; }
        public decimal P15 { get; set; }
        public decimal P50 { get; set; }
        public decimal P85 { get; set; }
        public decimal P97 { get; set; }
        public decimal? Score { get; set; }
    }
}
