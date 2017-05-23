using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodErator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void radioDatabase_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked)
            {
                return;
            }
            switch (((RadioButton)sender).Text.ToString())
            {
                case "MySQL":
                    SQLConnectHelper.Database = "mysql";
                    break;
                case "SQL Server":
                    SQLConnectHelper.Database = "sqlserver";
                    break;
                default:
                    SQLConnectHelper.Database = string.Empty;
                    break;
            }
        }
    }
}
