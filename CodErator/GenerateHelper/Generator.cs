using CodErator.DBHelper.MySQL;
using CodErator.Model;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodErator.GenerateHelper
{
    class Generator
    {
        private static MySQLHelper mysqlHelper;
        private static OptionHelper optionHelper;

        static Generator()
        {
            mysqlHelper = new MySQLHelper();
            optionHelper = OptionHelper.Instance;
        }

        public static void GoGoGo()
        {
            PreparingTable();
        }

        private static Table[] PreparingTable()
        {
            Table[] tables = new Table[optionHelper.SelectedTables.Count];
            for (int i = 0; i < tables.Length; i++)
            {
                tables[i] = new Table();
                tables[i].TableNale = optionHelper.SelectedTables[i];
                DataTable tableInfo = mysqlHelper.GetTableColumns(optionHelper.SelectedTables[i]);
                for (int j = 0; j < tableInfo.Columns.Count; j++)
                {
                    Column c = new Column();
                    c.ColumnName = tableInfo.Rows[j]["COLUMN_NAME"].ToString();
                    c.SetNullable(tableInfo.Rows[j]["IS_NULLABLE"].ToString());
                    c.DataType = tableInfo.Rows[j]["DATA_TYPE"].ToString();
                    c.CharacterMaximumLength = tableInfo.Rows[j]["CHARACTER_MAXIMUM_LENGTH"].ToString();
                    c.CharacterSetName = tableInfo.Rows[j]["CHARACTER_SET_NAME"].ToString();
                    c.ColumnType = tableInfo.Rows[j]["COLUMN_TYPE"].ToString();
                    c.ColumnComment = tableInfo.Rows[j]["COLUMN_COMMENT"].ToString();
                    tables[i].Columns.Add(c);
                }
            }
            return tables;
        }

        private static void OpenTemplate(string templateName)
        {

        }

        private static void FileOutput()
        {

        }
    }
}
