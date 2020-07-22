using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JSON_READER
{
    class Test
    {
        public static string file;
        public static DataTable DataTableFromTextFile(string location, char delimiter = '|')
        {
            DataTable result;
            location = file;

            string[] LineArray = File.ReadAllLines(location);
            result = FromDataTable(LineArray, delimiter);
            return result;
        }

        private static DataTable FromDataTable(string[] LineArray, char delimiter)
        {
            DataTable table = new DataTable();

            AddColumnToTable(LineArray, delimiter, ref table);
            AddRowToTable(LineArray, delimiter, ref table);
            return table;
        }

        private static void AddRowToTable(string[] valueCollection, char delimiter, ref DataTable table)
        {
            for (int i = 1; i < valueCollection.Length; i++)
            {
                string[] values = valueCollection[i].Split(delimiter);
                DataRow dr = table.NewRow();
                for (int j = 0; j < values.Length; j++)
                {
                    dr[j] = values[j];
                }
                table.Rows.Add(dr);
            }
        }

        private static void AddColumnToTable(string[] columnCollection, char delimiter, ref DataTable table)
        {
            string[] columns = columnCollection[0].Split(delimiter);
            foreach (string columnName in columns)
            {
                DataColumn dc = new DataColumn(columnName, typeof(string));
                table.Columns.Add(dc);
            }
        }
    }
}
