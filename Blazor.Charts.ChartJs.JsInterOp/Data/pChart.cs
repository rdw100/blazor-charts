using System.Collections.Generic;
using System.Text.Json;
//using System.Data;

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

        //    ['Year', 'Sales', 'Expenses'],
        //    ['2004', 1000, 400],
        //    ['2005', 1170, 460],
        //    ['2006', 660, 1120],
        //    ['2007', 1030, 540]
        //    [{ label: 'Year', id: 'year' },
        //    { label: 'Sales', id: 'Sales', type: 'number' }, // Use object notation to explicitly specify the data type.
        //    { label: 'Expenses', id: 'Expenses', type: 'number' }],
        //    ['2014', 1000, 400],
        //    ['2015', 1170, 460],
        //    ['2016', 660, 1120],
        //    ['2017', 1030, 540]]);

        //['Task', 'Hours per Day'],
        //        ['Work', 11],
        //        ['Eat', 2],
        //        ['Commute', 2],
        //        ['Watch TV', 2],
        //        ['Sleep', 7]

        public byte[] OnGetChartData()
        {
            var chart = new Chart
            {
                cols = new object[]
                {
                    new { id = "topping", type = "string", label = "Topping" },
                    new { id = "slices", type = "number", label = "Slices" }
                },
                rows = new object[]
                {
                    new { c = new object[] { new { v = "Mushrooms" }, new { v = 3 } } },
                    new { c = new object[] { new { v = "Onions" }, new { v = 1 } } },
                    new { c = new object[] { new { v = "Olives" }, new { v = 1 } } },
                    new { c = new object[] { new { v = "Zucchini" }, new { v = 1 } } },
                    new { c = new object[] { new { v = "Pepperoni" }, new { v = 2 } } }
                }
            };


            byte[] jsonString = JsonSerializer.SerializeToUtf8Bytes(chart);

            return jsonString;

            //var pizza = new[]
            //{
            //    new {Name = "Mushrooms", Count = 3},
            //    new {Name = "Onions", Count = 1},
            //    new {Name = "Olives", Count = 1},
            //    new {Name = "Zucchini", Count = 1},
            //    new {Name = "Pepperoni", Count = 2}
            //};

            //var json = pizza.ToGoogleDataTable()
            //        .NewColumn(new Column(ColumnType.String, "Topping"), x => x.Name)
            //        .NewColumn(new Column(ColumnType.Number, "Slices"), x => x.Count)
            //        .Build()
            //        .GetJson();

            //return json;
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
        //public Chart(object[] newCols, object[] newRows)
        //{
        //    cols = newCols;
        //    rows = newRows;
        //}

        public object[] cols { get; set; }
        public object[] rows { get; set; }
    }

    public class DataItem
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}

