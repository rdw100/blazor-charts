using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;

namespace Blazor.Charts.ChartJs.JsInterOp.Data
{
    public class pChart
    {
        public List<pData> GetData
        {
            get
            {
                return new List<pData> {
                    new pData { Length=5, p10 = 2, p50 = 8, p90 = 12 },
                    new pData { Length=5, p10 = 4, p50 = 10, p90 = 15 },
                    new pData { Length=5, p10 = 6, p50 = 13, p90 = 18 }
                };
            }
        }

        public pData[] GetListData {
            get
            {
                List<Cols> cols = new List<Cols>
                {
                    new Cols {id = "length", label="Length", type = "number"},
                    new Cols {id = "p10", label="P10", type = "number"},
                    new Cols {id = "p50", label="P50", type = "number"},
                    new Cols {id = "p90", label="P90", type = "number"}
                };

                List<pData> data = new List<pData> {
                    new pData { Length=5, p10 = 2, p50 = 8, p90 = 12 },
                    new pData { Length=5, p10 = 4, p50 = 10, p90 = 15 },
                    new pData { Length=5, p10 = 6, p50 = 13, p90 = 18 }
                };

                var array = cols.ToArray();
               
                var newArray = data.ToArray();
                var colArray = cols.Select(x => x.id).ToArray();

                return data.ToArray();
            }
        }

        public object[] GetDataTable()
        {
            // Step 2: here we create a DataTable.
            // ... We add 4 columns, each with a Type.
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("Length", typeof(int));
            table.Columns.Add("P10", typeof(int));
            table.Columns.Add("P50", typeof(int));
            table.Columns.Add("P90", typeof(int));

            // Step 3: here we add rows.
            table.Rows.Add(5, 2, 8, 12);
            table.Rows.Add(7, 4, 10, 15);
            table.Rows.Add(9, 6, 12, 18);
            table.Rows.Add(11, 8, 14, 20);
            return table.AsEnumerable().ToArray();
        }

        public string OnGetChartData()
        {
            //List<Sales> t = new List<Sales>
            //{
            //    new Sales
            //    {
            //        Year = "2004",
            //        Sale = 1000,
            //        Expense = 400
            //    },
            //    new Sales
            //    {
            //        Year = "2005",
            //        Sale = 1170,
            //        Expense = 460
            //    },
            //    new Sales
            //    {
            //        Year = "2006",
            //        Sale = 660,
            //        Expense = 2200
            //    }
            //};

            //return JsonConvert.SerializeObject(t);
            //return JsonSerializer.Serialize(t);
            var chart = new Chart
            {
                cols = new object[]
                {
                    new { id = "task", label = "Task", type = "string" },
                    new { id = "hours", label = "Hours per Day", type = "number" }
                },
                rows = new object[]
                {
                    new { c = new object[] { new { v = "Work" }, new { v = 11 } } },
                    new { c = new object[] { new { v = "Eat" }, new { v = 6 } } },
                    new { c = new object[] { new { v = "Commute" }, new { v = 12 } } },
                    new { c = new object[] { new { v = "Watch TV" }, new { v = 5 } } },
                    new { c = new object[] { new { v = "Sleep" }, new { v = 16 } } }
                }
            };

            string jsonString = JsonSerializer.Serialize(chart.rows);
            
            return jsonString;
        }

        public string GetChartData()
        {
            var chart = new Chart
            {
                cols = new object[]
                {
                    new { id = "year", label = "Year", type = "string" },
                    new { id = "sales", label = "Sales", type = "number" },
                    new { id = "expenses", label = "Expenses", type = "number" }
                },
                rows = new object[]
                {
                    new { c = new object[] { new { v = "2014" }, new { v = 1000 }, new { v = 400 } } },
                    new { c = new object[] { new { v = "2015" }, new { v = 1170 }, new { v = 460 } } },
                    new { c = new object[] { new { v = "2016" }, new { v = 660 }, new { v = 1120 } } },
                    new { c = new object[] { new { v = "2017" }, new { v = 1030 }, new { v = 540 } } }
                }
            };

            string jsonString = JsonSerializer.Serialize(chart);

            return jsonString;
        }

        public string GetLineChartData()
        {

            var chart = new LineChart
            {
                cols = new Cols[]
                {
                    new Cols { id = "year", label = "Year", type = "string" },
                    new Cols { id = "sales", label = "Sales", type = "number" },
                    new Cols { id = "expenses", label = "Expenses", type = "number" }
                },
                rows = new Rows[]
                {
                    new Rows { Year = "2014", Expense = 1000, Sale = 400 },
                    new Rows { Year = "2015", Expense = 1170, Sale = 460 },
                    new Rows { Year = "2016", Expense = 660, Sale = 1120 },
                    new Rows { Year = "2017", Expense = 1030, Sale = 540 }
                    //new { c = new object[] { new { v = "2014" }, new { v = 1000 }, new { v = 400 } } },
                    //new { c = new object[] { new { v = "2015" }, new { v = 1170 }, new { v = 460 } } },
                    //new { c = new object[] { new { v = "2016" }, new { v = 660 }, new { v = 1120 } } },
                    //new { c = new object[] { new { v = "2017" }, new { v = 1030 }, new { v = 540 } } }
                }
            };

            //var myLabels = new object[]
            //{
            //    new { label = "lengthincm", type = "number"},
            //    new { label = "Score", type = "number"},
            //    new { label = "97th", type = "number"},
            //    new { label = "85th", type = "number"},
            //    new { label = "50th", type = "number"},
            //    new { label = "15th", type = "number"},
            //    new { label = "3rd", type = "number"}
            //};

            //var data 

            //$.each(data, function(i, item) {
            //    dataArray.push([item.lengthincm, item.score, item.p97, item.p85, item.p50, item.p15, item.p3]);
            //});

            string jsonString = JsonSerializer.Serialize(chart);

            return jsonString;
        }

        public DataItem[] GetPlotData() 
        { 
            var row =  new DataItem[] {
                new DataItem
                {
                    X = 2.75,
                    Y = 50
                },
                new DataItem
                {
                    X = 5.5,
                    Y = 60
                },
                new DataItem
                {
                    X = 7,
                    Y = 70
                },
                new DataItem
                {
                    X = 9,
                    Y = 80
                },
                new DataItem
                {
                    X = 11,
                    Y = 90
                },
                new DataItem
                {
                    X = 12.5,
                    Y = 100
                },
                new DataItem
                {
                    X = 15,
                    Y = 110
                }
            };
            return row;
        }
    }


    public class Chart
    {
        public object[] cols { get; set; }
        public object[] rows { get; set; }
    }

    public class DataItem
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Sales
    {
        public string Year { set; get; }
        public int Sale { set; get; }
        public int Expense { set; get; }
    }

    public class LineChart
    {
        public Cols[] cols { get; set; }
        public Rows[] rows { get; set; }
    }

    public class Cols
    {
        public string id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
    }

    public class Rows
    {
        public string Year { set; get; }
        public int Sale { set; get; }
        public int Expense { set; get; }
    }
}