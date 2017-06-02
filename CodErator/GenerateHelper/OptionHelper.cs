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
        private bool isJava;
        private bool isCSharp;
        private bool hasEntity;
        private bool hasDao;
        private bool hasService;
        private string outputPath;
        private List<string> selectedTables;

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

        public bool IsJava
        {
            get => isJava;
            set => isJava = value;
        }

        public bool IsCSharp
        {
            get => isCSharp;
            set => isCSharp = value;
        }

        public bool HasEntity
        {
            get => hasEntity;
            set => hasEntity = value;
        }

        public bool HasDao
        {
            get => hasDao;
            set => hasDao = value;
        }

        public bool HasService
        {
            get => hasService;
            set => hasService = value;
        }

        public string OutputPath
        {
            get => outputPath;
            set => outputPath = value;
        }

        public List<string> SelectedTables
        {
            get => selectedTables;
            set => selectedTables = value;
        }
    }
}
