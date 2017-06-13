using MySql.Data.MySqlClient;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodErator.GenerateHelper
{
	public class TemplateMethod
	{
		private static OptionHelper optionHelper;

		static TemplateMethod()
		{
			optionHelper = OptionHelper.Instance;
		}

		public static string GetDataType(string dataType)
		{
			dataType = dataType.ToUpper();
			switch (dataType)
			{
				// number
				case "TINYINT": return "int";
				case "SMALLINT": return "int";
				case "MEDIUMINT": return "int";
				case "INT": return "int";
				case "BIGINT": return "uint";
				case "FLOAT": return "float";
				case "DOUBLE": return "double";
				case "DECIMAL": return "double";

				// date
				case "DATE": return "String";
				case "TIME": return "String";
				case "YEAR": return "String";
				case "DATETIME": return "String";
				case "TIMESTAMP": return "String";

				// string
				case "CHAR": return "String";
				case "VARCHAR": return "String";
				case "TINYBLOB": return "Blob";
				case "TINYTEXT": return "String";
				case "BLOB": return "Blob";
				case "TEXT": return "String";
				case "MEDIUMBLOB": return "Blob";
				case "MEDIUMTEXT": return "String";
				case "LONGBLOB": return "Blob";
				case "LONGTEXT": return "String";

				default: return "Object";
			}
		}

		public static string ToTitleCase(string text)
		{
			return (text.Substring(0, 1).ToUpper() + text.Substring(1));
		}

		public static void SetExtension(string extension)
		{
			optionHelper.Extension = extension;
		}
	}
}
