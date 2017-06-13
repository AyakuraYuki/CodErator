using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodErator.GenerateHelper
{
	class OptionHelper
	{
		private static readonly OptionHelper instance = null;
		private string outputPath;
		private string extension;
		private List<string> selectedTables;
		private List<string> selectedTemplates;

		static OptionHelper()
		{
			instance = new OptionHelper();
		}

		private OptionHelper()
		{
			SelectedTables = new List<string>();
		}

		public static OptionHelper Instance
		{
			get => instance;
		}

		public string OutputPath
		{
			get => outputPath;
			set => outputPath = value;
		}

		public string Extension
		{
			get => extension;
			set => extension = value;
		}

		public List<string> SelectedTables
		{
			get => selectedTables;
			set => selectedTables = value;
		}

		public List<string> SelectedTemplates
		{
			get => selectedTemplates;
			set => selectedTemplates = value;
		}
	}
}
