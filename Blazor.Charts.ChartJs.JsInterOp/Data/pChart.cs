using System.Collections.Generic;
using System.Text.Json;

namespace Blazor.Charts.ChartJs.JsInterOp.Data
{
    public class pChart
    {
        public List<pData> getData {
            get
            {
                return new List<pData> {
                    new pData { Length=5, p10 = 2, p50 = 8, p90 = 12 },
                    new pData { Length=5, p10 = 4, p50 = 10, p90 = 15 },
                    new pData { Length=5, p10 = 6, p50 = 13, p90 = 18 }
                };

                //List<pData> data = new List<pData> {
                //    new pData { Length=5, p10 = 2, p50 = 8, p90 = 12 },
                //    new pData { Length=5, p10 = 4, p50 = 10, p90 = 15 },
                //    new pData { Length=5, p10 = 6, p50 = 13, p90 = 18 }
                //};

                //return DBHelper.ConvertToDataTable<pData>(data);
            }
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

            string jsonString = JsonSerializer.Serialize(chart);
            
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
        //public DataTable getDataTable()
        //{
        //    // Create a DataTable.
        //    // ... We add 4 columns, each with a Type.
        //    DataTable table = new DataTable();
        //    table.Columns.Add("Dosage", typeof(int));
        //    table.Columns.Add("Drug", typeof(string));
        //    table.Columns.Add("Diagnosis", typeof(string));
        //    table.Columns.Add("Date", typeof(DateTime));

        //    // Add rows.
        //    table.Rows.Add(25, "Drug A", "Disease A", DateTime.Now);
        //    table.Rows.Add(50, "Drug Z", "Problem Z", DateTime.Now);
        //    table.Rows.Add(10, "Drug Q", "Disorder Q", DateTime.Now);
        //    table.Rows.Add(21, "Medicine A", "Diagnosis A", DateTime.Now);
        //    return table;
        //}
    }

    //public static class DBHelper 
    //{
    //    public static DataTable ConvertToDataTable<T>(IList<T> data)
    //    {
    //        PropertyDescriptorCollection properties =
    //           TypeDescriptor.GetProperties(typeof(T));
    //        DataTable table = new DataTable();
    //        foreach (PropertyDescriptor prop in properties)
    //            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
    //        foreach (T item in data)
    //        {
    //            DataRow row = table.NewRow();
    //            foreach (PropertyDescriptor prop in properties)
    //                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
    //            table.Rows.Add(row);
    //        }
    //        return table;
    //    }
    //}

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
}