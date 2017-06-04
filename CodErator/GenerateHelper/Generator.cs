using CodErator.CustomException;
using CodErator.DBHelper;
using CodErator.DBHelper.MySQL;
using CodErator.Model;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				tables[i].TableNale = optionHelper.SelectedTables[i];
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
			string path = string.Empty;
			if (optionHelper.IsJava)
				path = Path.Combine("Templates/Java", templateName + ".cshtml");
			else if (optionHelper.IsCSharp)
				path = Path.Combine("Templates/CSharp", templateName + ".cshtml");
			else
				return string.Empty;
			return File.ReadAllText(path);
		}

		/// <summary>
		/// 文件保存
		/// </summary>
		/// <param name="path"></param>
		/// <param name="result"></param>
		private static void Save(string folder, string filename, string input, TemplateKey key)
		{
			byte[] result = System.Text.Encoding.GetEncoding("utf-8").GetBytes(input);
			switch (key)
			{
				case TemplateKey.Entity:
					folder += @"\entity";
					break;
				case TemplateKey.Dao:
					folder += @"\dao";
					break;
				case TemplateKey.Service:
					folder += @"\service";
					break;
			}
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
		private static void FileOutput(string template, Table table, TemplateKey key, string filename)
		{
			var model = table;
			string suffix = filename.Substring(filename.LastIndexOf("."));
			string result = string.Empty;
			try
			{
				result = Engine.Razor.RunCompile(template, key.ToString("G") + suffix, null, model);
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

		private static void GenerateEntity(Table[] tables)
		{
			foreach (Table t in tables)
			{
				string template = OpenTemplate("Entity");
				string filename = t.TableNale;
				if (optionHelper.IsJava)
					filename += ".java";
				else if (optionHelper.IsCSharp)
					filename += ".cs";
				try
				{
					FileOutput(template, t, TemplateKey.Entity, filename);
				}
				catch (TemplateSyntaxErrorException)
				{
					throw;
				}
			}
		}

		private static void GenerateDao(Table[] tables)
		{
			foreach (Table t in tables)
			{
				string template = OpenTemplate("Dao");
				string filename = t.TableNale;
				if (optionHelper.IsJava)
					filename += ".java";
				else if (optionHelper.IsCSharp)
					filename += ".cs";
				try
				{
					FileOutput(template, t, TemplateKey.Dao, filename);
				}
				catch (TemplateSyntaxErrorException)
				{
					throw;
				}
			}
		}

		private static void GenerateService(Table[] tables)
		{
			foreach (Table t in tables)
			{
				string template = OpenTemplate("Service");
				string filename = t.TableNale;
				if (optionHelper.IsJava)
					filename += ".java";
				else if (optionHelper.IsCSharp)
					filename += ".cs";
				try
				{
					FileOutput(template, t, TemplateKey.Service, filename);
				}
				catch (TemplateSyntaxErrorException)
				{
					throw;
				}
			}
		}

		private static void Generating(Table[] tables)
		{
			if (optionHelper.HasEntity)
			{
				try
				{
					GenerateEntity(tables);
				}
				catch (TemplateSyntaxErrorException)
				{
					throw;
				}
			}

			if (optionHelper.HasDao)
			{
				try
				{
					GenerateDao(tables);
				}
				catch (TemplateSyntaxErrorException)
				{
					throw;
				}
			}

			if (optionHelper.HasService)
			{
				try
				{
					GenerateService(tables);
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
			catch (TemplateSyntaxErrorException)
			{
				throw;
			}
		}
	}
}
