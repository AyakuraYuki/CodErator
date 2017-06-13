namespace CodErator
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				if (mysqlHelper != null)
				{
					mysqlHelper.Dispose();
				}

				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.groupBoxConnectInfo = new System.Windows.Forms.GroupBox();
			this.textSchema = new System.Windows.Forms.TextBox();
			this.textPass = new System.Windows.Forms.TextBox();
			this.textUser = new System.Windows.Forms.TextBox();
			this.textPort = new System.Windows.Forms.TextBox();
			this.textIP = new System.Windows.Forms.TextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.labelDatabase = new System.Windows.Forms.Label();
			this.labelPass = new System.Windows.Forms.Label();
			this.labelUser = new System.Windows.Forms.Label();
			this.labelPort = new System.Windows.Forms.Label();
			this.labelIP = new System.Windows.Forms.Label();
			this.infoTip = new System.Windows.Forms.ToolTip(this.components);
			this.tableList = new System.Windows.Forms.ListBox();
			this.templateList = new System.Windows.Forms.ListBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.mySQLHelperBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dgvColumns = new System.Windows.Forms.DataGridView();
			this.labelOutputPath = new System.Windows.Forms.Label();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.textSavePath = new System.Windows.Forms.TextBox();
			this.btnFolderBrowser = new System.Windows.Forms.Button();
			this.btnGoGoGo = new System.Windows.Forms.Button();
			this.btnAddTemplate = new System.Windows.Forms.Button();
			this.btnDelTemplate = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.groupBoxConnectInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mySQLHelperBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxConnectInfo
			// 
			this.groupBoxConnectInfo.Controls.Add(this.textSchema);
			this.groupBoxConnectInfo.Controls.Add(this.textPass);
			this.groupBoxConnectInfo.Controls.Add(this.textUser);
			this.groupBoxConnectInfo.Controls.Add(this.textPort);
			this.groupBoxConnectInfo.Controls.Add(this.textIP);
			this.groupBoxConnectInfo.Controls.Add(this.btnConnect);
			this.groupBoxConnectInfo.Controls.Add(this.labelDatabase);
			this.groupBoxConnectInfo.Controls.Add(this.labelPass);
			this.groupBoxConnectInfo.Controls.Add(this.labelUser);
			this.groupBoxConnectInfo.Controls.Add(this.labelPort);
			this.groupBoxConnectInfo.Controls.Add(this.labelIP);
			this.groupBoxConnectInfo.Location = new System.Drawing.Point(12, 12);
			this.groupBoxConnectInfo.Name = "groupBoxConnectInfo";
			this.groupBoxConnectInfo.Size = new System.Drawing.Size(271, 231);
			this.groupBoxConnectInfo.TabIndex = 0;
			this.groupBoxConnectInfo.TabStop = false;
			this.groupBoxConnectInfo.Text = "连接信息";
			// 
			// textSchema
			// 
			this.textSchema.Location = new System.Drawing.Point(76, 152);
			this.textSchema.Name = "textSchema";
			this.textSchema.Size = new System.Drawing.Size(160, 27);
			this.textSchema.TabIndex = 10;
			this.infoTip.SetToolTip(this.textSchema, "需要访问的数据库名称(schema name)");
			this.textSchema.Leave += new System.EventHandler(this.textSchema_Leave);
			// 
			// textPass
			// 
			this.textPass.Location = new System.Drawing.Point(76, 122);
			this.textPass.Name = "textPass";
			this.textPass.PasswordChar = '●';
			this.textPass.Size = new System.Drawing.Size(160, 27);
			this.textPass.TabIndex = 9;
			this.infoTip.SetToolTip(this.textPass, "数据库连接密码");
			this.textPass.Leave += new System.EventHandler(this.textPass_Leave);
			// 
			// textUser
			// 
			this.textUser.Location = new System.Drawing.Point(76, 92);
			this.textUser.Name = "textUser";
			this.textUser.Size = new System.Drawing.Size(160, 27);
			this.textUser.TabIndex = 8;
			this.infoTip.SetToolTip(this.textUser, "数据库连接用户名");
			this.textUser.Leave += new System.EventHandler(this.textUser_Leave);
			// 
			// textPort
			// 
			this.textPort.Location = new System.Drawing.Point(76, 62);
			this.textPort.Name = "textPort";
			this.textPort.Size = new System.Drawing.Size(160, 27);
			this.textPort.TabIndex = 7;
			this.infoTip.SetToolTip(this.textPort, "输入需要连接到的端口号，端口范围0 - 65536。");
			this.textPort.Leave += new System.EventHandler(this.textPort_Leave);
			// 
			// textIP
			// 
			this.textIP.Location = new System.Drawing.Point(76, 32);
			this.textIP.Name = "textIP";
			this.textIP.Size = new System.Drawing.Size(160, 27);
			this.textIP.TabIndex = 6;
			this.infoTip.SetToolTip(this.textIP, "输入需要连接的数据库IP地址");
			this.textIP.Leave += new System.EventHandler(this.textIP_Leave);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(166, 188);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(99, 37);
			this.btnConnect.TabIndex = 5;
			this.btnConnect.Text = "连接";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// labelDatabase
			// 
			this.labelDatabase.AutoSize = true;
			this.labelDatabase.Location = new System.Drawing.Point(6, 155);
			this.labelDatabase.Name = "labelDatabase";
			this.labelDatabase.Size = new System.Drawing.Size(54, 20);
			this.labelDatabase.TabIndex = 4;
			this.labelDatabase.Text = "数据库";
			// 
			// labelPass
			// 
			this.labelPass.AutoSize = true;
			this.labelPass.Location = new System.Drawing.Point(6, 125);
			this.labelPass.Name = "labelPass";
			this.labelPass.Size = new System.Drawing.Size(55, 20);
			this.labelPass.TabIndex = 3;
			this.labelPass.Text = "密    码";
			// 
			// labelUser
			// 
			this.labelUser.AutoSize = true;
			this.labelUser.Location = new System.Drawing.Point(6, 95);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new System.Drawing.Size(54, 20);
			this.labelUser.TabIndex = 2;
			this.labelUser.Text = "用户名";
			// 
			// labelPort
			// 
			this.labelPort.AutoSize = true;
			this.labelPort.Location = new System.Drawing.Point(6, 65);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new System.Drawing.Size(55, 20);
			this.labelPort.TabIndex = 1;
			this.labelPort.Text = "端    口";
			// 
			// labelIP
			// 
			this.labelIP.AutoSize = true;
			this.labelIP.Location = new System.Drawing.Point(6, 35);
			this.labelIP.Name = "labelIP";
			this.labelIP.Size = new System.Drawing.Size(22, 20);
			this.labelIP.TabIndex = 0;
			this.labelIP.Text = "IP";
			// 
			// infoTip
			// 
			this.infoTip.AutoPopDelay = 3000;
			this.infoTip.InitialDelay = 500;
			this.infoTip.ReshowDelay = 500;
			this.infoTip.ShowAlways = true;
			// 
			// tableList
			// 
			this.tableList.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.tableList.FormattingEnabled = true;
			this.tableList.ItemHeight = 19;
			this.tableList.Location = new System.Drawing.Point(12, 250);
			this.tableList.Name = "tableList";
			this.tableList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.tableList.Size = new System.Drawing.Size(271, 422);
			this.tableList.TabIndex = 1;
			this.infoTip.SetToolTip(this.tableList, "多选以选择需要生成的表");
			this.tableList.SelectedIndexChanged += new System.EventHandler(this.tableList_SelectedIndexChanged);
			// 
			// templateList
			// 
			this.templateList.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.templateList.FormattingEnabled = true;
			this.templateList.ItemHeight = 17;
			this.templateList.Location = new System.Drawing.Point(309, 515);
			this.templateList.Name = "templateList";
			this.templateList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.templateList.Size = new System.Drawing.Size(366, 157);
			this.templateList.TabIndex = 8;
			this.infoTip.SetToolTip(this.templateList, "选择使用的模板文件，列表中的所有项都将被使用");
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.errorProvider.ContainerControl = this;
			this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
			// 
			// dgvColumns
			// 
			this.dgvColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dgvColumns.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvColumns.Location = new System.Drawing.Point(309, 12);
			this.dgvColumns.Name = "dgvColumns";
			this.dgvColumns.ReadOnly = true;
			this.dgvColumns.RowTemplate.Height = 23;
			this.dgvColumns.Size = new System.Drawing.Size(943, 494);
			this.dgvColumns.TabIndex = 0;
			// 
			// labelOutputPath
			// 
			this.labelOutputPath.AutoSize = true;
			this.labelOutputPath.Location = new System.Drawing.Point(815, 523);
			this.labelOutputPath.Name = "labelOutputPath";
			this.labelOutputPath.Size = new System.Drawing.Size(69, 20);
			this.labelOutputPath.TabIndex = 4;
			this.labelOutputPath.Text = "输出位置";
			// 
			// textSavePath
			// 
			this.textSavePath.Font = new System.Drawing.Font("微软雅黑", 9F);
			this.textSavePath.Location = new System.Drawing.Point(819, 553);
			this.textSavePath.Name = "textSavePath";
			this.textSavePath.Size = new System.Drawing.Size(433, 23);
			this.textSavePath.TabIndex = 5;
			// 
			// btnFolderBrowser
			// 
			this.btnFolderBrowser.Location = new System.Drawing.Point(1159, 519);
			this.btnFolderBrowser.Name = "btnFolderBrowser";
			this.btnFolderBrowser.Size = new System.Drawing.Size(93, 28);
			this.btnFolderBrowser.TabIndex = 6;
			this.btnFolderBrowser.Text = "浏览";
			this.btnFolderBrowser.UseVisualStyleBackColor = true;
			this.btnFolderBrowser.Click += new System.EventHandler(this.btnFolderBrowser_Click);
			// 
			// btnGoGoGo
			// 
			this.btnGoGoGo.Location = new System.Drawing.Point(1127, 615);
			this.btnGoGoGo.Name = "btnGoGoGo";
			this.btnGoGoGo.Size = new System.Drawing.Size(125, 57);
			this.btnGoGoGo.TabIndex = 7;
			this.btnGoGoGo.Text = "生成代码";
			this.btnGoGoGo.UseVisualStyleBackColor = true;
			this.btnGoGoGo.Click += new System.EventHandler(this.btnGoGoGo_Click);
			// 
			// btnAddTemplate
			// 
			this.btnAddTemplate.Location = new System.Drawing.Point(681, 598);
			this.btnAddTemplate.Name = "btnAddTemplate";
			this.btnAddTemplate.Size = new System.Drawing.Size(114, 34);
			this.btnAddTemplate.TabIndex = 9;
			this.btnAddTemplate.Text = "添加模板";
			this.btnAddTemplate.UseVisualStyleBackColor = true;
			this.btnAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
			// 
			// btnDelTemplate
			// 
			this.btnDelTemplate.Location = new System.Drawing.Point(681, 638);
			this.btnDelTemplate.Name = "btnDelTemplate";
			this.btnDelTemplate.Size = new System.Drawing.Size(114, 34);
			this.btnDelTemplate.TabIndex = 10;
			this.btnDelTemplate.Text = "删除所选模板";
			this.btnDelTemplate.UseVisualStyleBackColor = true;
			this.btnDelTemplate.Click += new System.EventHandler(this.btnDelTemplate_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Multiselect = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 681);
			this.Controls.Add(this.btnDelTemplate);
			this.Controls.Add(this.btnAddTemplate);
			this.Controls.Add(this.templateList);
			this.Controls.Add(this.btnGoGoGo);
			this.Controls.Add(this.btnFolderBrowser);
			this.Controls.Add(this.textSavePath);
			this.Controls.Add(this.labelOutputPath);
			this.Controls.Add(this.dgvColumns);
			this.Controls.Add(this.tableList);
			this.Controls.Add(this.groupBoxConnectInfo);
			this.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximumSize = new System.Drawing.Size(1920, 1080);
			this.MinimumSize = new System.Drawing.Size(1280, 720);
			this.Name = "MainForm";
			this.Opacity = 0.95D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CodeErator";
			this.groupBoxConnectInfo.ResumeLayout(false);
			this.groupBoxConnectInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mySQLHelperBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxConnectInfo;
		private System.Windows.Forms.Label labelPass;
		private System.Windows.Forms.Label labelUser;
		private System.Windows.Forms.Label labelPort;
		private System.Windows.Forms.Label labelIP;
		private System.Windows.Forms.Label labelDatabase;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.TextBox textPass;
		private System.Windows.Forms.TextBox textUser;
		private System.Windows.Forms.TextBox textPort;
		private System.Windows.Forms.TextBox textIP;
		private System.Windows.Forms.ToolTip infoTip;
		private System.Windows.Forms.ListBox tableList;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.TextBox textSchema;
		private System.Windows.Forms.BindingSource mySQLHelperBindingSource;
		private System.Windows.Forms.DataGridView dgvColumns;
		private System.Windows.Forms.Label labelOutputPath;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.TextBox textSavePath;
		private System.Windows.Forms.Button btnFolderBrowser;
		private System.Windows.Forms.Button btnGoGoGo;
		private System.Windows.Forms.ListBox templateList;
		private System.Windows.Forms.Button btnDelTemplate;
		private System.Windows.Forms.Button btnAddTemplate;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}