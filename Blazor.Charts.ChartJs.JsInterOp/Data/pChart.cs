using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
    }

    public static class DBHelper 
    {
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}

