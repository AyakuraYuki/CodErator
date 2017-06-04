using CodErator.CustomException;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CodErator.DBHelper.MySQL
{
	class MySQLHelper : IDisposable
	{
		private DBConnectHelper dbConnectHelper;
		private MySqlConnection connection;
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
		private DataTable GetDataTable(MySqlCommand command)
		{
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

			return dataTable;
		}

		/// <summary>
		/// 获取目标数据库内存在的全部表，用集合保存，对接界面的ListBox.Items
		/// </summary>
		/// <returns></returns>
		public List<string> GetTableList()
		{
			OpenConnection();
			MySqlCommand command = connection.CreateCommand();
			command.Parameters.Add(new MySqlParameter("@TABLE_SCHEMA", dbConnectHelper.Schema));
			command.CommandText =
				"select TABLE_NAME " +
				"from information_schema.TABLES " +
				"where TABLE_SCHEMA = @TABLE_SCHEMA";
			DataTable dataTable = GetDataTable(command);

			List<string> tableList = new List<string>();
			for (int i = 0; i < dataTable.Rows.Count; i++)
				tableList.Add(dataTable.Rows[i]["TABLE_NAME"].ToString());

			CloseConnection();
			return tableList;
		}

		/// <summary>
		/// 获取目标数据表的字段元素，用DataTable保存，仅查询有用数据
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public DataTable GetTableColumns(string tableName)
		{
			OpenConnection();
			MySqlCommand command = connection.CreateCommand();
			command.Parameters.Add("@TABLE_SCHEMA", MySqlDbType.VarChar).Value = dbConnectHelper.Schema;
			command.Parameters.Add("@TABLE_NAME", MySqlDbType.VarChar).Value = tableName;
			command.CommandText =
				"select " +
				"COLUMN_NAME, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, " +
				"CHARACTER_SET_NAME, COLUMN_TYPE, COLUMN_COMMENT " +
				"from information_schema.COLUMNS " +
				"where TABLE_SCHEMA = @TABLE_SCHEMA and TABLE_NAME = @TABLE_NAME";

			DataTable dataTable = GetDataTable(command);

			CloseConnection();
			return dataTable;
		}

		public void Dispose()
		{
			reader.Close();
			connection.Close();
		}
	}
}
