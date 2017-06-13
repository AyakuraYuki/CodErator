using CodErator.CustomException;
using CodErator.DBHelper.MySQL;
using CodErator.Model;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Data;
using System.IO;

namespace CodErator.GenerateHelper
{
	public class Generator
	{
		private static MySQLHelper mysqlHelper;
		private static OptionHelper optionHelper;

		static Generator()
		{
			mysqlHelper = new MySQLHelper();
			optionHelper = OptionHelper.Instance;
		}

		private static Table[] PreparingTable()
		{
			Table[] tables = new Table[optionHelper.SelectedTables.Count];
			for (int i = 0; i < tables.Length; i++)
			{
				tables[i] = new Table();
				tables[i].TableName = optionHelper.SelectedTables[i];
				DataTable tableInfo = mysqlHelper.GetTableColumns(optionHelper.SelectedTables[i]);
				for (int j = 0; j < tableInfo.Rows.Count; j++)
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

		/// <summary>
		/// 打开模板文件
		/// </summary>
		/// <param name="templateName">模板文件名</param>
		/// <returns></returns>
		private static string OpenTemplate(string templateName)
		{
			string path = templateName;
			return File.ReadAllText(path);
		}

		/// <summary>
		/// 文件保存
		/// </summary>
		/// <param name="path"></param>
		/// <param name="result"></param>
		private static void Save(string folder, string filename, string input, string key)
		{
			byte[] result = System.Text.Encoding.GetEncoding("utf-8").GetBytes(input);
			if (!Directory.Exists(folder))
			{
				Directory.CreateDirectory(folder);
			}
			using (FileStream fileStream = new FileStream(Path.Combine(folder, filename), FileMode.Create))
			{
				for (int i = 0; i < result.Length; i++)
				{
					fileStream.WriteByte(result[i]);
				}
			}
		}

		/// <summary>
		/// 输出到文件
		/// </summary>
		/// <param name="template">模板文本</param>
		/// <param name="table">表数据</param>
		private static void FileOutput(string template, Table table, string key, string filename)
		{
			var model = table;
			string suffix = filename.Substring(filename.LastIndexOf("."));
			string result = string.Empty;
			try
			{
				result = Engine.Razor.RunCompile(template, key + suffix, null, model);
			}
			catch (FormatException e)
			{
				throw new TemplateSyntaxErrorException(
					"模板文件可能有问题，请确保您没有擅自修改，或者修改后没有出现违反Razor Engine语法的问题。\n" +
					"如果是不小心修改了模板文件，您可以到下面的地址重新获取模板文件。\n" +
					"https://github.com/AyakuraYuki/CodErator \n\n" +
					"如果需要自定义模板内容，请参考Razor Engine的语法规范。", e);
			}
			Save(optionHelper.OutputPath, filename, result, key);
		}

		private static void Generating(Table[] tables)
		{
			foreach (Table t in tables)
			{
				// 第一个foreach拿到所有表
				// 接下来会有第二个for用来对每个表生成用户指定模板数量的代码
				// 模板路径全部存放在optionHelper.SelectedTemplates内

				// 待修复
				string template = OpenTemplate("");
				string filename = t.TableName;

				if (optionHelper.Extension.Equals(string.Empty))
				{
					throw new NullExtensionException("模板内是不是忘了定义扩展名了？请在模板中调用TemplateMethod.SetExtension(extension)指定生成代码的文件扩展名！");
				}
				else
				{
					filename += optionHelper.Extension;
				}

				try
				{
					FileOutput(template, t, t.TableName, filename);
				}
				catch (TemplateSyntaxErrorException)
				{
					throw;
				}
			}
		}

		public static void GoGoGo()
		{
			Table[] tables = PreparingTable();
			try
			{
				Generating(tables);
			}
			catch (NullExtensionException) { throw; }
			catch (TemplateSyntaxErrorException) { throw; }
		}
	}
}
