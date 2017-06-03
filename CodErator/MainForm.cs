using CodErator.CustomException;
using CodErator.DBHelper;
using CodErator.DBHelper.MySQL;
using CodErator.GenerateHelper;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CodErator
{
    public partial class MainForm : Form
    {
        private DBConnectHelper connector;
        private OptionHelper optionHelper;
        private MySQLHelper mysqlHelper;

        public MainForm()
        {
            InitializeComponent();
            connector = DBConnectHelper.Instance;
            optionHelper = OptionHelper.Instance;
        }

        #region 控件悬停提示
        private void text_MouseEnter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Equals(textIP))
                infoTip.SetToolTip(textIP, "输入需要连接的数据库IP地址");
            if (((TextBox)sender).Equals(textPort))
                infoTip.SetToolTip(textPort, "输入需要连接到的端口号，端口范围0 - 65536。");
            if (((TextBox)sender).Equals(textUser))
                infoTip.SetToolTip(textUser, "数据库连接用户名");
            if (((TextBox)sender).Equals(textPass))
                infoTip.SetToolTip(textPass, "数据库连接密码");
            if (((TextBox)sender).Equals(textSchema))
                infoTip.SetToolTip(textSchema, "需要访问的数据库名称(schema name)");
        }

        private void text_MouseLeave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Equals(textIP))
                infoTip.Hide(textIP);
            if (((TextBox)sender).Equals(textPort))
                infoTip.Hide(textPort);
            if (((TextBox)sender).Equals(textUser))
                infoTip.Hide(textUser);
            if (((TextBox)sender).Equals(textPass))
                infoTip.Hide(textPass);
            if (((TextBox)sender).Equals(textSchema))
                infoTip.Hide(textSchema);
        }
        #endregion

        #region 数据库连接
        private void textIP_Leave(object sender, EventArgs e)
        {
            // ((25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\.){3}(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)
            string reg = "((25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]?\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d{2}|[1-9]?\\d)";
            Regex regex = new Regex(reg);
            if ("localhost".Equals(textIP.Text.ToLower()))
            {
                connector.IP = textIP.Text.ToLower();
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

        private void textSchema_Leave(object sender, EventArgs e)
        {
            connector.Schema = textSchema.Text;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            mysqlHelper = new MySQLHelper();
            tableList.Items.Clear();
            try
            {
                tableList.Items.AddRange(mysqlHelper.GetTableList().ToArray());
            }
            catch (DatabaseConnectingException exception)
            {
                MessageBox.Show(exception.Message, "连接到数据库时出现了一个问题。");
                return;
            }
            catch (NoDatabaseSelectedException exception)
            {
                MessageBox.Show(exception.Message, "是不是缺少了什么参数？");
                return;
            }
        }
        #endregion

        #region 代码生成的数据预备，可以查看被生成的字段在数据库中的信息
        private void tableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = mysqlHelper.GetTableColumns(tableList.SelectedItem.ToString());

            dataTable.Columns["COLUMN_NAME"].ColumnName = "列名";
            dataTable.Columns["IS_NULLABLE"].ColumnName = "允许为空";
            dataTable.Columns["DATA_TYPE"].ColumnName = "数据类型";
            dataTable.Columns["CHARACTER_MAXIMUM_LENGTH"].ColumnName = "最大长度";
            dataTable.Columns["CHARACTER_SET_NAME"].ColumnName = "编码集";
            dataTable.Columns["COLUMN_TYPE"].ColumnName = "列数据类型";
            dataTable.Columns["COLUMN_COMMENT"].ColumnName = "备注";

            dgvColumns.DataSource = dataTable;
        }
        #endregion

        #region 生成选项处理，主要功能是获取保存位置
        private void radioButtonCSharp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCSharp.Checked == true)
            {
                checkBoxDao.Enabled = false;
                checkBoxService.Enabled = false;
            }
            else
            {
                checkBoxDao.Enabled = true;
                checkBoxService.Enabled = true;
            }
        }

        private void btnFolderBrowser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textSavePath.Text = folderBrowserDialog.SelectedPath + @"\CodEratorOutput";
            }
        }
        #endregion

        #region 生成操作
        private bool IsReadyToRun()
        {
            if (mysqlHelper == null)
            {
                MessageBox.Show("请先连接到数据库啦！！ヽ(*。>Д<)o゜", "没有连接到数据库");
                return false;
            }
			if (optionHelper.SelectedTables.Count==0)
			{
				MessageBox.Show("先选择至少一张表啦！(╯‵□′)╯•••*～●","没有选表？");
				return false;
			}
            if (!radioButtonJava.Checked && !radioButtonCSharp.Checked)
            {
                MessageBox.Show("一定要选择一个目标语言用于生成(￣▽￣)\"", "没有选择目标语言");
                return false;
            }
            if (!checkBoxEntity.Checked && !checkBoxDao.Checked && !checkBoxService.Checked)
            {
                MessageBox.Show("如果您没有选择生成模板，生成器将不会运行噢ㄟ( ▔, ▔ )ㄏ\n\n停止当前操作，您的代码生成请求已被取消。", "没有选择模板");
                return false;
            }
            if (textSavePath.Text.Equals(string.Empty))
            {
                MessageBox.Show("没有选择生成代码输出的路径的话，您的请求是不会被执行的( *^-^)ρ(*╯^╰)\n\n您的代码生成请求已被取消。", "请选择生成代码保存的位置");
                return false;
            }
            return true;
        }

        // 生成选项信息初始化
        private void SetOptions()
        {
            optionHelper.IsJava = radioButtonJava.Checked;
            optionHelper.IsCSharp = radioButtonCSharp.Checked;
            optionHelper.HasEntity = checkBoxEntity.Checked;
            optionHelper.HasDao = checkBoxDao.Checked;
            optionHelper.HasService = checkBoxService.Checked;
            optionHelper.OutputPath = textSavePath.Text;
            for (int i = 0; i < tableList.SelectedItems.Count; i++)
            {
                optionHelper.SelectedTables.Add(tableList.SelectedItems[i].ToString());
            }
        }

        private void btnGoGoGo_Click(object sender, EventArgs e)
        {
            if (IsReadyToRun())
            {
                SetOptions();
                try
                {
                    Generator.GoGoGo();
                }
                catch (TemplateSyntaxErrorException exception)
                {
                    MessageBox.Show(exception.Message, "模板出了点问题");
                }
                if (Directory.Exists(optionHelper.OutputPath))
                {
                    MessageBox.Show("代码生成完成啦(o゜▽゜)o☆\n\n生成位置再确认一下吧：\n" +
                        optionHelper.OutputPath, "成功！");
                }
                else
                {
                    MessageBox.Show("生成完成之后好像没有发现生成的代码，可能出现了什么问题？\n\n" +
                        "别担心，重新生成一次再把之后出现的异常提示告诉我，我会修理好的（；´д｀）ゞ", "不好！");
                }
            }
            else
                return;
        }
        #endregion
    }
}
