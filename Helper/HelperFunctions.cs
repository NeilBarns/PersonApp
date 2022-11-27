using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace PersonApp.Helper
{
    public static class HelperFunctions
    {
        public static HttpClient SetAPIControls()
        {
            HttpClient client = new HttpClient();
            string baseAPIUrl = WebConfigurationManager.AppSettings["webapi"];
            client.BaseAddress = new Uri(baseAPIUrl);

            return client;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        static Random gen = new Random();

        public static DateTime DateRandomizer()
        {
            DateTime start = new DateTime(1994, 1, 1);
            int range = (DateTime.Today - start).Days;
            return DateTime.Today.AddDays(gen.Next(range));
        }

        public static int NumberRandomizer()
        {
            return gen.Next(10, 101);
        }
    }
}