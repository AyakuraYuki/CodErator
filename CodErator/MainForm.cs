using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodErator
{
    public partial class MainForm : Form
    {
        private SQLConnectHelper connector;

        public MainForm()
        {
            InitializeComponent();
            connector = SQLConnectHelper.Instance;
            connectInfoTip.SetToolTip(radioDatabaseMySQL, "连接到MySQL");
            connectInfoTip.SetToolTip(radioDatabaseSQLServer, "连接到SQL Server");
        }

        #region 控件悬停提示
        private void text_MouseEnter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Equals(textIP))
                connectInfoTip.Show("输入需要连接的数据库IP地址", textIP);
            if (((TextBox)sender).Equals(textPort))
                connectInfoTip.SetToolTip(textPort, "输入需要连接到的端口号，端口范围0 - 65536。");
            if (((TextBox)sender).Equals(textUser))
                connectInfoTip.SetToolTip(textUser, "数据库连接用户名");
            if (((TextBox)sender).Equals(textPass))
                connectInfoTip.SetToolTip(textPass, "数据库连接密码");
        }

        private void text_MouseLeave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Equals(textIP))
                connectInfoTip.Hide(textIP);
            if (((TextBox)sender).Equals(textPort))
                connectInfoTip.Hide(textPort);
            if (((TextBox)sender).Equals(textUser))
                connectInfoTip.Hide(textUser);
            if (((TextBox)sender).Equals(textPass))
                connectInfoTip.Hide(textPass);
        }
        #endregion

        #region 数据库连接
        private void textIP_Leave(object sender, EventArgs e)
        {
            // ((25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\.){3}(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)
            string reg = "((25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]?\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]?\\d)";
            Regex regex = new Regex(reg);
            if ("localhost".Equals(textIP.Text))
            {
                connector.IP = textIP.Text;
                errorProvider.Clear();
            }
            else if (!regex.IsMatch(textIP.Text))
            {
                connector.IP = string.Empty;
                errorProvider.SetError(textIP,
                    "IP地址输入不符合规范\n" +
                    "允许的输入为 x.x.x.x 或 localhost，IP各段范围是0 - 255。");
            }
            else
            {
                connector.IP = textIP.Text;
                errorProvider.Clear();
            }
        }

        private void textPort_Leave(object sender, EventArgs e)
        {
            uint port = 0;

            try
            {
                port = Convert.ToUInt32(textPort.Text);
            }
            catch (FormatException)
            {
                errorProvider.SetError(textPort,
                    "检测到不正确的输入\n" +
                    "请确保端口号输入的内容只是数字！");
                return;
            }

            if (port > 65536)
            {
                errorProvider.SetError(textPort, "端口号范围0 - 65536。");
            }
            else
            {
                errorProvider.Clear();
                connector.Port = port;
            }
        }

        private void textUser_Leave(object sender, EventArgs e)
        {
            connector.User = textUser.Text;
        }

        private void textPass_Leave(object sender, EventArgs e)
        {
            connector.Pass = textPass.Text;
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
                    connector.Database = "mysql";
                    break;
                case "SQL Server":
                    connector.Database = "sqlserver";
                    break;
                default:
                    connector.Database = string.Empty;
                    break;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
