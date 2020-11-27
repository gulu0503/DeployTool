namespace DeployTool.WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbOriginalPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbTargetPath = new System.Windows.Forms.TextBox();
            this.tbLastWriteTime = new System.Windows.Forms.TextBox();
            this.tbLastExecuteTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsIgnoreCs = new System.Windows.Forms.CheckBox();
            this.chkIsCompression = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCompressionPassword = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFtpPath = new System.Windows.Forms.TextBox();
            this.tbFtpPassword = new System.Windows.Forms.TextBox();
            this.tbFtpUserName = new System.Windows.Forms.TextBox();
            this.tbFtpUrl = new System.Windows.Forms.TextBox();
            this.chkIsCopyToFtp = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbIgnoreRule = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkIsKeepEmptyDir = new System.Windows.Forms.CheckBox();
            this.chkIsIgnoreConfig = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbPublishFtpPassword = new System.Windows.Forms.TextBox();
            this.tbPublishFtpPath = new System.Windows.Forms.TextBox();
            this.tbPublishFtpUserName = new System.Windows.Forms.TextBox();
            this.tbPublishFtpUrl = new System.Windows.Forms.TextBox();
            this.chkIsPublish = new System.Windows.Forms.CheckBox();
            this.chkIsPublishToDisk = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbDiskPath = new System.Windows.Forms.TextBox();
            this.cboCatalog = new System.Windows.Forms.ComboBox();
            this.cboDeployWork = new System.Windows.Forms.ComboBox();
            this.chkIsBuild = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSlnPath = new System.Windows.Forms.TextBox();
            this.tbMsBuildPath = new System.Windows.Forms.TextBox();
            this.tbBuildConfiguration = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.dgvProject = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProjectPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IgnoreRules = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnOpenExecuteFolder = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOriginalPath
            // 
            this.tbOriginalPath.Location = new System.Drawing.Point(109, 25);
            this.tbOriginalPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbOriginalPath.Name = "tbOriginalPath";
            this.tbOriginalPath.Size = new System.Drawing.Size(222, 25);
            this.tbOriginalPath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 677);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1311, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "執行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExecuteDeploy_Click);
            // 
            // tbTargetPath
            // 
            this.tbTargetPath.Location = new System.Drawing.Point(109, 61);
            this.tbTargetPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbTargetPath.Name = "tbTargetPath";
            this.tbTargetPath.Size = new System.Drawing.Size(222, 25);
            this.tbTargetPath.TabIndex = 0;
            // 
            // tbLastWriteTime
            // 
            this.tbLastWriteTime.Location = new System.Drawing.Point(128, 54);
            this.tbLastWriteTime.Margin = new System.Windows.Forms.Padding(4);
            this.tbLastWriteTime.Name = "tbLastWriteTime";
            this.tbLastWriteTime.Size = new System.Drawing.Size(279, 25);
            this.tbLastWriteTime.TabIndex = 2;
            // 
            // tbLastExecuteTime
            // 
            this.tbLastExecuteTime.Location = new System.Drawing.Point(534, 54);
            this.tbLastExecuteTime.Margin = new System.Windows.Forms.Padding(4);
            this.tbLastExecuteTime.Name = "tbLastExecuteTime";
            this.tbLastExecuteTime.ReadOnly = true;
            this.tbLastExecuteTime.Size = new System.Drawing.Size(246, 25);
            this.tbLastExecuteTime.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "方案位置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "目標位置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "異動起始時間";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "上次執行時間";
            // 
            // chkIsIgnoreCs
            // 
            this.chkIsIgnoreCs.AutoSize = true;
            this.chkIsIgnoreCs.Checked = true;
            this.chkIsIgnoreCs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsIgnoreCs.Location = new System.Drawing.Point(24, 99);
            this.chkIsIgnoreCs.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsIgnoreCs.Name = "chkIsIgnoreCs";
            this.chkIsIgnoreCs.Size = new System.Drawing.Size(136, 19);
            this.chkIsIgnoreCs.TabIndex = 5;
            this.chkIsIgnoreCs.Text = "是否要忽略CS檔";
            this.chkIsIgnoreCs.UseVisualStyleBackColor = true;
            // 
            // chkIsCompression
            // 
            this.chkIsCompression.AutoSize = true;
            this.chkIsCompression.Checked = true;
            this.chkIsCompression.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsCompression.Location = new System.Drawing.Point(915, 67);
            this.chkIsCompression.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsCompression.Name = "chkIsCompression";
            this.chkIsCompression.Size = new System.Drawing.Size(179, 19);
            this.chkIsCompression.TabIndex = 5;
            this.chkIsCompression.Text = "是否要產生壓縮檔(Zip)";
            this.chkIsCompression.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbCompressionPassword);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkIsCopyToFtp);
            this.groupBox1.Location = new System.Drawing.Point(915, 94);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(414, 251);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "壓縮設定";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "密碼";
            // 
            // tbCompressionPassword
            // 
            this.tbCompressionPassword.Location = new System.Drawing.Point(108, 27);
            this.tbCompressionPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbCompressionPassword.Name = "tbCompressionPassword";
            this.tbCompressionPassword.Size = new System.Drawing.Size(290, 25);
            this.tbCompressionPassword.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbFtpPath);
            this.groupBox2.Controls.Add(this.tbFtpPassword);
            this.groupBox2.Controls.Add(this.tbFtpUserName);
            this.groupBox2.Controls.Add(this.tbFtpUrl);
            this.groupBox2.Location = new System.Drawing.Point(35, 94);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(363, 149);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FTP設定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "FTP位置";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 88);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "FTP密碼";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "FTP帳號";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "FTP網址";
            // 
            // tbFtpPath
            // 
            this.tbFtpPath.Location = new System.Drawing.Point(100, 117);
            this.tbFtpPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbFtpPath.Name = "tbFtpPath";
            this.tbFtpPath.Size = new System.Drawing.Size(248, 25);
            this.tbFtpPath.TabIndex = 2;
            // 
            // tbFtpPassword
            // 
            this.tbFtpPassword.Location = new System.Drawing.Point(100, 85);
            this.tbFtpPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbFtpPassword.Name = "tbFtpPassword";
            this.tbFtpPassword.Size = new System.Drawing.Size(248, 25);
            this.tbFtpPassword.TabIndex = 2;
            // 
            // tbFtpUserName
            // 
            this.tbFtpUserName.Location = new System.Drawing.Point(100, 53);
            this.tbFtpUserName.Margin = new System.Windows.Forms.Padding(4);
            this.tbFtpUserName.Name = "tbFtpUserName";
            this.tbFtpUserName.Size = new System.Drawing.Size(248, 25);
            this.tbFtpUserName.TabIndex = 2;
            // 
            // tbFtpUrl
            // 
            this.tbFtpUrl.Location = new System.Drawing.Point(100, 21);
            this.tbFtpUrl.Margin = new System.Windows.Forms.Padding(4);
            this.tbFtpUrl.Name = "tbFtpUrl";
            this.tbFtpUrl.Size = new System.Drawing.Size(248, 25);
            this.tbFtpUrl.TabIndex = 2;
            // 
            // chkIsCopyToFtp
            // 
            this.chkIsCopyToFtp.AutoSize = true;
            this.chkIsCopyToFtp.Checked = true;
            this.chkIsCopyToFtp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsCopyToFtp.Location = new System.Drawing.Point(35, 64);
            this.chkIsCopyToFtp.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsCopyToFtp.Name = "chkIsCopyToFtp";
            this.chkIsCopyToFtp.Size = new System.Drawing.Size(204, 19);
            this.chkIsCopyToFtp.TabIndex = 5;
            this.chkIsCopyToFtp.Text = "是否要將壓縮檔上傳至FTP";
            this.chkIsCopyToFtp.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(457, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "開啟設定檔";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OpenDeployWorkConfig_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(338, 60);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 29);
            this.button3.TabIndex = 7;
            this.button3.Text = "開啟";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OpenTargetPathFolder_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(338, 23);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(49, 29);
            this.button4.TabIndex = 7;
            this.button4.Text = "開啟";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OpenOriginalPathFolder_Click);
            // 
            // tbIgnoreRule
            // 
            this.tbIgnoreRule.Location = new System.Drawing.Point(514, 25);
            this.tbIgnoreRule.Margin = new System.Windows.Forms.Padding(4);
            this.tbIgnoreRule.Multiline = true;
            this.tbIgnoreRule.Name = "tbIgnoreRule";
            this.tbIgnoreRule.Size = new System.Drawing.Size(319, 149);
            this.tbIgnoreRule.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(409, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Ignore Rule";
            // 
            // chkIsKeepEmptyDir
            // 
            this.chkIsKeepEmptyDir.AutoSize = true;
            this.chkIsKeepEmptyDir.Checked = true;
            this.chkIsKeepEmptyDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsKeepEmptyDir.Location = new System.Drawing.Point(24, 155);
            this.chkIsKeepEmptyDir.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsKeepEmptyDir.Name = "chkIsKeepEmptyDir";
            this.chkIsKeepEmptyDir.Size = new System.Drawing.Size(149, 19);
            this.chkIsKeepEmptyDir.TabIndex = 5;
            this.chkIsKeepEmptyDir.Text = "是否保留空資料夾";
            this.chkIsKeepEmptyDir.UseVisualStyleBackColor = true;
            // 
            // chkIsIgnoreConfig
            // 
            this.chkIsIgnoreConfig.AutoSize = true;
            this.chkIsIgnoreConfig.Checked = true;
            this.chkIsIgnoreConfig.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsIgnoreConfig.Location = new System.Drawing.Point(24, 127);
            this.chkIsIgnoreConfig.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsIgnoreConfig.Name = "chkIsIgnoreConfig";
            this.chkIsIgnoreConfig.Size = new System.Drawing.Size(260, 19);
            this.chkIsIgnoreConfig.TabIndex = 5;
            this.chkIsIgnoreConfig.Text = "是否要忽略Web.Config 和 App.config";
            this.chkIsIgnoreConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.tbPublishFtpPassword);
            this.groupBox4.Controls.Add(this.tbPublishFtpPath);
            this.groupBox4.Controls.Add(this.tbPublishFtpUserName);
            this.groupBox4.Controls.Add(this.tbPublishFtpUrl);
            this.groupBox4.Location = new System.Drawing.Point(916, 500);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(413, 169);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FTP設定";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 135);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "FTP位置";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 101);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 15);
            this.label15.TabIndex = 4;
            this.label15.Text = "FTP密碼";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 64);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 15);
            this.label16.TabIndex = 4;
            this.label16.Text = "FTP帳號";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 28);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "FTP網址";
            // 
            // tbPublishFtpPassword
            // 
            this.tbPublishFtpPassword.Location = new System.Drawing.Point(95, 97);
            this.tbPublishFtpPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPublishFtpPassword.Name = "tbPublishFtpPassword";
            this.tbPublishFtpPassword.Size = new System.Drawing.Size(302, 25);
            this.tbPublishFtpPassword.TabIndex = 2;
            // 
            // tbPublishFtpPath
            // 
            this.tbPublishFtpPath.Location = new System.Drawing.Point(95, 132);
            this.tbPublishFtpPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPublishFtpPath.Name = "tbPublishFtpPath";
            this.tbPublishFtpPath.Size = new System.Drawing.Size(302, 25);
            this.tbPublishFtpPath.TabIndex = 2;
            // 
            // tbPublishFtpUserName
            // 
            this.tbPublishFtpUserName.Location = new System.Drawing.Point(95, 61);
            this.tbPublishFtpUserName.Margin = new System.Windows.Forms.Padding(4);
            this.tbPublishFtpUserName.Name = "tbPublishFtpUserName";
            this.tbPublishFtpUserName.Size = new System.Drawing.Size(302, 25);
            this.tbPublishFtpUserName.TabIndex = 2;
            // 
            // tbPublishFtpUrl
            // 
            this.tbPublishFtpUrl.Location = new System.Drawing.Point(95, 25);
            this.tbPublishFtpUrl.Margin = new System.Windows.Forms.Padding(4);
            this.tbPublishFtpUrl.Name = "tbPublishFtpUrl";
            this.tbPublishFtpUrl.Size = new System.Drawing.Size(302, 25);
            this.tbPublishFtpUrl.TabIndex = 2;
            // 
            // chkIsPublish
            // 
            this.chkIsPublish.AutoSize = true;
            this.chkIsPublish.Checked = true;
            this.chkIsPublish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsPublish.Location = new System.Drawing.Point(915, 473);
            this.chkIsPublish.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsPublish.Name = "chkIsPublish";
            this.chkIsPublish.Size = new System.Drawing.Size(159, 19);
            this.chkIsPublish.TabIndex = 5;
            this.chkIsPublish.Text = "是否要利用FTP上版";
            this.chkIsPublish.UseVisualStyleBackColor = true;
            // 
            // chkIsPublishToDisk
            // 
            this.chkIsPublishToDisk.AutoSize = true;
            this.chkIsPublishToDisk.Checked = true;
            this.chkIsPublishToDisk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsPublishToDisk.Location = new System.Drawing.Point(915, 361);
            this.chkIsPublishToDisk.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsPublishToDisk.Name = "chkIsPublishToDisk";
            this.chkIsPublishToDisk.Size = new System.Drawing.Size(179, 19);
            this.chkIsPublishToDisk.TabIndex = 5;
            this.chkIsPublishToDisk.Text = "是否要利用磁碟機上版";
            this.chkIsPublishToDisk.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.tbDiskPath);
            this.groupBox3.Location = new System.Drawing.Point(915, 391);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(415, 65);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "磁碟機設定";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 30);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 15);
            this.label18.TabIndex = 4;
            this.label18.Text = "磁碟機位置";
            // 
            // tbDiskPath
            // 
            this.tbDiskPath.Location = new System.Drawing.Point(107, 25);
            this.tbDiskPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbDiskPath.Name = "tbDiskPath";
            this.tbDiskPath.Size = new System.Drawing.Size(292, 25);
            this.tbDiskPath.TabIndex = 2;
            // 
            // cboCatalog
            // 
            this.cboCatalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCatalog.FormattingEnabled = true;
            this.cboCatalog.Location = new System.Drawing.Point(25, 15);
            this.cboCatalog.Margin = new System.Windows.Forms.Padding(4);
            this.cboCatalog.Name = "cboCatalog";
            this.cboCatalog.Size = new System.Drawing.Size(160, 23);
            this.cboCatalog.TabIndex = 8;
            // 
            // cboDeployWork
            // 
            this.cboDeployWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeployWork.FormattingEnabled = true;
            this.cboDeployWork.Location = new System.Drawing.Point(195, 15);
            this.cboDeployWork.Margin = new System.Windows.Forms.Padding(4);
            this.cboDeployWork.Name = "cboDeployWork";
            this.cboDeployWork.Size = new System.Drawing.Size(141, 23);
            this.cboDeployWork.TabIndex = 8;
            // 
            // chkIsBuild
            // 
            this.chkIsBuild.AutoSize = true;
            this.chkIsBuild.Checked = true;
            this.chkIsBuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsBuild.Location = new System.Drawing.Point(24, 206);
            this.chkIsBuild.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsBuild.Name = "chkIsBuild";
            this.chkIsBuild.Size = new System.Drawing.Size(164, 19);
            this.chkIsBuild.TabIndex = 5;
            this.chkIsBuild.Text = "複製前是否要先編譯";
            this.chkIsBuild.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.tbSlnPath);
            this.groupBox5.Controls.Add(this.tbMsBuildPath);
            this.groupBox5.Controls.Add(this.tbBuildConfiguration);
            this.groupBox5.Location = new System.Drawing.Point(22, 241);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(811, 68);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "編譯設定";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(532, 28);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 15);
            this.label20.TabIndex = 4;
            this.label20.Text = "Sln";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(207, 28);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "MsBuild";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 28);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "組態";
            // 
            // tbSlnPath
            // 
            this.tbSlnPath.Location = new System.Drawing.Point(566, 22);
            this.tbSlnPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbSlnPath.Name = "tbSlnPath";
            this.tbSlnPath.Size = new System.Drawing.Size(226, 25);
            this.tbSlnPath.TabIndex = 2;
            // 
            // tbMsBuildPath
            // 
            this.tbMsBuildPath.Location = new System.Drawing.Point(273, 22);
            this.tbMsBuildPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbMsBuildPath.Name = "tbMsBuildPath";
            this.tbMsBuildPath.Size = new System.Drawing.Size(226, 25);
            this.tbMsBuildPath.TabIndex = 2;
            // 
            // tbBuildConfiguration
            // 
            this.tbBuildConfiguration.Location = new System.Drawing.Point(67, 22);
            this.tbBuildConfiguration.Margin = new System.Windows.Forms.Padding(4);
            this.tbBuildConfiguration.Name = "tbBuildConfiguration";
            this.tbBuildConfiguration.Size = new System.Drawing.Size(127, 25);
            this.tbBuildConfiguration.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(344, 13);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(105, 29);
            this.button6.TabIndex = 7;
            this.button6.Text = "開啟資料夾";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.OpenCatalogFolder_Click);
            // 
            // dgvProject
            // 
            this.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.ProjectPath,
            this.TargetPath,
            this.IgnoreRules});
            this.dgvProject.Location = new System.Drawing.Point(6, 24);
            this.dgvProject.Name = "dgvProject";
            this.dgvProject.RowHeadersWidth = 51;
            this.dgvProject.RowTemplate.Height = 27;
            this.dgvProject.Size = new System.Drawing.Size(844, 201);
            this.dgvProject.TabIndex = 9;
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "";
            this.Selected.MinimumWidth = 6;
            this.Selected.Name = "Selected";
            this.Selected.Width = 50;
            // 
            // ProjectPath
            // 
            this.ProjectPath.DataPropertyName = "ProjectPath";
            this.ProjectPath.HeaderText = "原路徑(相對)";
            this.ProjectPath.MinimumWidth = 6;
            this.ProjectPath.Name = "ProjectPath";
            this.ProjectPath.Width = 210;
            // 
            // TargetPath
            // 
            this.TargetPath.DataPropertyName = "TargetPath";
            this.TargetPath.HeaderText = "目標路徑(相對)";
            this.TargetPath.MinimumWidth = 6;
            this.TargetPath.Name = "TargetPath";
            this.TargetPath.Width = 210;
            // 
            // IgnoreRules
            // 
            this.IgnoreRules.DataPropertyName = "IgnoreRules";
            this.IgnoreRules.HeaderText = "Ignore Rule";
            this.IgnoreRules.MinimumWidth = 6;
            this.IgnoreRules.Name = "IgnoreRules";
            this.IgnoreRules.Width = 310;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Controls.Add(this.tbIgnoreRule);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.chkIsBuild);
            this.groupBox6.Controls.Add(this.tbOriginalPath);
            this.groupBox6.Controls.Add(this.tbTargetPath);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Controls.Add(this.chkIsIgnoreCs);
            this.groupBox6.Controls.Add(this.chkIsKeepEmptyDir);
            this.groupBox6.Controls.Add(this.chkIsIgnoreConfig);
            this.groupBox6.Location = new System.Drawing.Point(20, 94);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(858, 325);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "方案";
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(11, 181);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(839, 10);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dgvProject);
            this.groupBox7.Location = new System.Drawing.Point(20, 432);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(858, 237);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "專案";
            // 
            // btnOpenExecuteFolder
            // 
            this.btnOpenExecuteFolder.Location = new System.Drawing.Point(788, 52);
            this.btnOpenExecuteFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenExecuteFolder.Name = "btnOpenExecuteFolder";
            this.btnOpenExecuteFolder.Size = new System.Drawing.Size(90, 29);
            this.btnOpenExecuteFolder.TabIndex = 7;
            this.btnOpenExecuteFolder.Text = "開啟資料夾";
            this.btnOpenExecuteFolder.UseVisualStyleBackColor = true;
            this.btnOpenExecuteFolder.Click += new System.EventHandler(this.OpenExecuteFolder_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(570, 13);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "儲存設定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1344, 725);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.cboDeployWork);
            this.Controls.Add(this.cboCatalog);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.chkIsPublishToDisk);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnOpenExecuteFolder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbLastExecuteTime);
            this.Controls.Add(this.chkIsPublish);
            this.Controls.Add(this.chkIsCompression);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbLastWriteTime);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOriginalPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbTargetPath;
        private System.Windows.Forms.TextBox tbLastWriteTime;
        private System.Windows.Forms.TextBox tbLastExecuteTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsIgnoreCs;
        private System.Windows.Forms.CheckBox chkIsCompression;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCompressionPassword;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbIgnoreRule;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkIsKeepEmptyDir;
        private System.Windows.Forms.CheckBox chkIsIgnoreConfig;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbPublishFtpPassword;
        private System.Windows.Forms.TextBox tbPublishFtpUserName;
        private System.Windows.Forms.TextBox tbPublishFtpUrl;
        private System.Windows.Forms.CheckBox chkIsPublish;
        private System.Windows.Forms.CheckBox chkIsPublishToDisk;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbDiskPath;
        private System.Windows.Forms.ComboBox cboCatalog;
        private System.Windows.Forms.ComboBox cboDeployWork;
        private System.Windows.Forms.CheckBox chkIsBuild;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbMsBuildPath;
        private System.Windows.Forms.TextBox tbBuildConfiguration;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbSlnPath;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dgvProject;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbFtpPassword;
        private System.Windows.Forms.TextBox tbFtpUserName;
        private System.Windows.Forms.TextBox tbFtpUrl;
        private System.Windows.Forms.CheckBox chkIsCopyToFtp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbFtpPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPublishFtpPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn IgnoreRules;
        private System.Windows.Forms.Button btnOpenExecuteFolder;
        private System.Windows.Forms.Button btnSave;
    }
}