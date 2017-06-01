using CodErator.CustomException;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

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

        public List<string> GetTableList()
        {
            OpenConnection();

            command = connection.CreateCommand();
            command.CommandText = "show tables from " + dbConnectHelper.Schema;

            try
            {
                reader = command.ExecuteReader();
            }
            catch (MySqlException)
            {
                throw new NoDatabaseSelectedException("没有填写需要查询的数据库名称。");
            }

            List<string> tableList = new List<string>();
            while (reader.Read())
                tableList.Add(reader[0].ToString());

            CloseConnection();
            return tableList;
        }

        public List<object> GetTableColumns(string tableName)
        {
            OpenConnection();

            command = connection.CreateCommand();
            command.CommandText = "show columns from " + dbConnectHelper.Schema + "." + tableName;
            reader = command.ExecuteReader();


            CloseConnection();
            return null;
        }
    }
}
