using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodErator.Model
{
    public class Table
    {
        public string TableName { get; set; }

        private List<Column> columns;
        public List<Column> Columns
        {
            get => columns;
            set => columns = value;
        }

        public Table()
        {
            columns = new List<Column>();
        }
    }
}
