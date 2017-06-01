using CodErator.CustomException;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace CodErator.DBHelper.MySQL
{
    class MySQLHelper
    {
        private DBConnectHelper dbConnectHelper;
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public MySQLHelper()
        {
            dbConnectHelper = DBConnectHelper.Instance;
            connection = new MySqlConnection(
                "Server=" + dbConnectHelper.IP + ";" +
                "Port=" + dbConnectHelper.Port + ";" +
                "Database=" + dbConnectHelper.Schema + ";" +
                "Uid=" + dbConnectHelper.User + ";" +
                "Pwd=" + dbConnectHelper.Pass + ";"
                );
        }

        #region 数据库连接开启和关闭
        private void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (MySqlException e)
            {
                string exceptionMessage = string.Empty;
                if (e.Message.Contains(":"))
                    exceptionMessage = e.Message.Substring(e.Message.IndexOf(": ") + 2);
                else
                    exceptionMessage = e.Message;
                throw new DatabaseConnectingException(
                    "连接信息有误，请重新确认连接信息。\n" +
                    "错误的连接信息可能是：\n" +
                    exceptionMessage
                    );
            }
        }

        private void CloseConnection()
        {
            connection.Close();
        }
        #endregion

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="commandText">查询语句</param>
        /// <returns>结果集</returns>
        private DataTable GetDataTable(string commandText)
        {
            OpenConnection();

            command = connection.CreateCommand();
            command.CommandText = commandText;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (MySqlException)
            {
                throw new NoDatabaseSelectedException("没有填写需要查询的数据库名称。");
            }

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            CloseConnection();

            return dataTable;
        }

        /// <summary>
        /// 获取目标数据库内存在的全部表，用集合保存，对接界面的ListBox.Items
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableList()
        {
            DataTable dataTable = GetDataTable(
                "select TABLE_NAME " +
                "from information_schema.TABLES " +
                "where TABLE_SCHEMA = '" + dbConnectHelper.Schema + "'");

            List<string> tableList = new List<string>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
                tableList.Add(dataTable.Rows[i]["TABLE_NAME"].ToString());

            return tableList;
        }

        /// <summary>
        /// 获取目标数据表的字段元素，用DataTable保存，仅查询有用数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTableColumns(string tableName)
        {
            DataTable dataTable = GetDataTable(
                "select " +
                "COLUMN_NAME, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, " +
                "CHARACTER_SET_NAME, COLUMN_TYPE, COLUMN_COMMENT " +
                "from information_schema.COLUMNS " +
                "where TABLE_SCHEMA = '" + dbConnectHelper.Schema + "' " +
                "and TABLE_NAME = '" + tableName + "'");
            return dataTable;
        }
    }
}
