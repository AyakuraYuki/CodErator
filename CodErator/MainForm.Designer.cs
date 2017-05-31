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
            this.radioDatabaseSQLServer = new System.Windows.Forms.RadioButton();
            this.radioDatabaseMySQL = new System.Windows.Forms.RadioButton();
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
            this.connectInfoTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableList = new System.Windows.Forms.ListBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxConnectInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxConnectInfo
            // 
            this.groupBoxConnectInfo.Controls.Add(this.radioDatabaseSQLServer);
            this.groupBoxConnectInfo.Controls.Add(this.radioDatabaseMySQL);
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
            // radioDatabaseSQLServer
            // 
            this.radioDatabaseSQLServer.AutoSize = true;
            this.radioDatabaseSQLServer.Enabled = false;
            this.radioDatabaseSQLServer.Location = new System.Drawing.Point(158, 153);
            this.radioDatabaseSQLServer.Name = "radioDatabaseSQLServer";
            this.radioDatabaseSQLServer.Size = new System.Drawing.Size(107, 24);
            this.radioDatabaseSQLServer.TabIndex = 11;
            this.radioDatabaseSQLServer.TabStop = true;
            this.radioDatabaseSQLServer.Text = "SQL Server";
            this.radioDatabaseSQLServer.UseVisualStyleBackColor = true;
            this.radioDatabaseSQLServer.CheckedChanged += new System.EventHandler(this.radioDatabase_CheckedChanged);
            // 
            // radioDatabaseMySQL
            // 
            this.radioDatabaseMySQL.AutoSize = true;
            this.radioDatabaseMySQL.Location = new System.Drawing.Point(76, 153);
            this.radioDatabaseMySQL.Name = "radioDatabaseMySQL";
            this.radioDatabaseMySQL.Size = new System.Drawing.Size(79, 24);
            this.radioDatabaseMySQL.TabIndex = 10;
            this.radioDatabaseMySQL.TabStop = true;
            this.radioDatabaseMySQL.Text = "MySQL";
            this.radioDatabaseMySQL.UseVisualStyleBackColor = true;
            this.radioDatabaseMySQL.CheckedChanged += new System.EventHandler(this.radioDatabase_CheckedChanged);
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(76, 122);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '●';
            this.textPass.Size = new System.Drawing.Size(160, 27);
            this.textPass.TabIndex = 9;
            this.textPass.Leave += new System.EventHandler(this.textPass_Leave);
            this.textPass.MouseEnter += new System.EventHandler(this.text_MouseEnter);
            this.textPass.MouseLeave += new System.EventHandler(this.text_MouseLeave);
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(76, 92);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(160, 27);
            this.textUser.TabIndex = 8;
            this.textUser.Leave += new System.EventHandler(this.textUser_Leave);
            this.textUser.MouseEnter += new System.EventHandler(this.text_MouseEnter);
            this.textUser.MouseLeave += new System.EventHandler(this.text_MouseLeave);
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(76, 62);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(160, 27);
            this.textPort.TabIndex = 7;
            this.textPort.Leave += new System.EventHandler(this.textPort_Leave);
            this.textPort.MouseEnter += new System.EventHandler(this.text_MouseEnter);
            this.textPort.MouseLeave += new System.EventHandler(this.text_MouseLeave);
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(76, 32);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(160, 27);
            this.textIP.TabIndex = 6;
            this.textIP.Leave += new System.EventHandler(this.textIP_Leave);
            this.textIP.MouseEnter += new System.EventHandler(this.text_MouseEnter);
            this.textIP.MouseLeave += new System.EventHandler(this.text_MouseLeave);
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
            // connectInfoTip
            // 
            this.connectInfoTip.AutoPopDelay = 3000;
            this.connectInfoTip.InitialDelay = 500;
            this.connectInfoTip.ReshowDelay = 500;
            this.connectInfoTip.ShowAlways = true;
            // 
            // tableList
            // 
            this.tableList.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tableList.FormattingEnabled = true;
            this.tableList.ItemHeight = 19;
            this.tableList.Location = new System.Drawing.Point(12, 250);
            this.tableList.Name = "tableList";
            this.tableList.Size = new System.Drawing.Size(271, 422);
            this.tableList.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
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
            this.ResumeLayout(false);

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
        private System.Windows.Forms.RadioButton radioDatabaseSQLServer;
        private System.Windows.Forms.RadioButton radioDatabaseMySQL;
        private System.Windows.Forms.ToolTip connectInfoTip;
        private System.Windows.Forms.ListBox tableList;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}