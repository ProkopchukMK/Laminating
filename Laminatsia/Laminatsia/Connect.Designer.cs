namespace Laminatsia
{
    partial class Connect
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
            this.groupBoxConnecting = new System.Windows.Forms.GroupBox();
            this.labelListDB = new System.Windows.Forms.Label();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.comboBoxLilstDbIPServer = new System.Windows.Forms.ComboBox();
            this.buttonConnectToIPServer = new System.Windows.Forms.Button();
            this.maskedTextBoxIPServer = new System.Windows.Forms.MaskedTextBox();
            this.labelWriteIPServer = new System.Windows.Forms.Label();
            this.buttonTestConnectingToServer = new System.Windows.Forms.Button();
            this.tabControlConnect = new System.Windows.Forms.TabControl();
            this.tabPageIP = new System.Windows.Forms.TabPage();
            this.tabPageFromList = new System.Windows.Forms.TabPage();
            this.groupBoxSelectServerName = new System.Windows.Forms.GroupBox();
            this.progressBarConnectToDB = new System.Windows.Forms.ProgressBar();
            this.buttonSaveConfogServerName = new System.Windows.Forms.Button();
            this.buttonConnectToServerName = new System.Windows.Forms.Button();
            this.comboBoxListServerName = new System.Windows.Forms.ComboBox();
            this.labelDBName = new System.Windows.Forms.Label();
            this.comboBoxListDataBase = new System.Windows.Forms.ComboBox();
            this.labelServerName = new System.Windows.Forms.Label();
            this.tabPageCreateDataBase = new System.Windows.Forms.TabPage();
            this.groupBoxCreateDataBase = new System.Windows.Forms.GroupBox();
            this.buttonTestConnToCreateDB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateDB = new System.Windows.Forms.Button();
            this.maskedTextBoxIpServerCreateDB = new System.Windows.Forms.MaskedTextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonSearchServers = new System.Windows.Forms.Button();
            this.groupBoxConnecting.SuspendLayout();
            this.tabControlConnect.SuspendLayout();
            this.tabPageIP.SuspendLayout();
            this.tabPageFromList.SuspendLayout();
            this.groupBoxSelectServerName.SuspendLayout();
            this.tabPageCreateDataBase.SuspendLayout();
            this.groupBoxCreateDataBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConnecting
            // 
            this.groupBoxConnecting.Controls.Add(this.labelListDB);
            this.groupBoxConnecting.Controls.Add(this.buttonSaveConfig);
            this.groupBoxConnecting.Controls.Add(this.comboBoxLilstDbIPServer);
            this.groupBoxConnecting.Controls.Add(this.buttonConnectToIPServer);
            this.groupBoxConnecting.Controls.Add(this.maskedTextBoxIPServer);
            this.groupBoxConnecting.Controls.Add(this.labelWriteIPServer);
            this.groupBoxConnecting.Controls.Add(this.buttonTestConnectingToServer);
            this.groupBoxConnecting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxConnecting.Location = new System.Drawing.Point(18, 11);
            this.groupBoxConnecting.Name = "groupBoxConnecting";
            this.groupBoxConnecting.Size = new System.Drawing.Size(472, 289);
            this.groupBoxConnecting.TabIndex = 3;
            this.groupBoxConnecting.TabStop = false;
            this.groupBoxConnecting.Text = "Підключення по IP сервера";
            // 
            // labelListDB
            // 
            this.labelListDB.AutoSize = true;
            this.labelListDB.Location = new System.Drawing.Point(51, 123);
            this.labelListDB.Name = "labelListDB";
            this.labelListDB.Size = new System.Drawing.Size(142, 20);
            this.labelListDB.TabIndex = 12;
            this.labelListDB.Text = "Список баз даних";
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Enabled = false;
            this.buttonSaveConfig.Location = new System.Drawing.Point(262, 212);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(140, 39);
            this.buttonSaveConfig.TabIndex = 9;
            this.buttonSaveConfig.Text = "Зберегти";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            this.buttonSaveConfig.Click += new System.EventHandler(this.ButtonSaveConfig_Click);
            // 
            // comboBoxLilstDbIPServer
            // 
            this.comboBoxLilstDbIPServer.DropDownHeight = 200;
            this.comboBoxLilstDbIPServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLilstDbIPServer.Enabled = false;
            this.comboBoxLilstDbIPServer.FormattingEnabled = true;
            this.comboBoxLilstDbIPServer.IntegralHeight = false;
            this.comboBoxLilstDbIPServer.ItemHeight = 20;
            this.comboBoxLilstDbIPServer.Location = new System.Drawing.Point(34, 158);
            this.comboBoxLilstDbIPServer.Name = "comboBoxLilstDbIPServer";
            this.comboBoxLilstDbIPServer.Size = new System.Drawing.Size(187, 28);
            this.comboBoxLilstDbIPServer.TabIndex = 10;
            this.comboBoxLilstDbIPServer.SelectedIndexChanged += new System.EventHandler(this.comboBoxLilstDbIPServer_SelectedIndexChanged);
            // 
            // buttonConnectToIPServer
            // 
            this.buttonConnectToIPServer.Enabled = false;
            this.buttonConnectToIPServer.Location = new System.Drawing.Point(55, 212);
            this.buttonConnectToIPServer.Name = "buttonConnectToIPServer";
            this.buttonConnectToIPServer.Size = new System.Drawing.Size(140, 39);
            this.buttonConnectToIPServer.TabIndex = 9;
            this.buttonConnectToIPServer.Text = "Підключитися";
            this.buttonConnectToIPServer.UseVisualStyleBackColor = true;
            this.buttonConnectToIPServer.Click += new System.EventHandler(this.ButtonConnectToIPServer_Click);
            // 
            // maskedTextBoxIPServer
            // 
            this.maskedTextBoxIPServer.Location = new System.Drawing.Point(34, 76);
            this.maskedTextBoxIPServer.Name = "maskedTextBoxIPServer";
            this.maskedTextBoxIPServer.Size = new System.Drawing.Size(187, 26);
            this.maskedTextBoxIPServer.TabIndex = 8;
            this.maskedTextBoxIPServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelWriteIPServer
            // 
            this.labelWriteIPServer.AutoSize = true;
            this.labelWriteIPServer.Location = new System.Drawing.Point(81, 39);
            this.labelWriteIPServer.Name = "labelWriteIPServer";
            this.labelWriteIPServer.Size = new System.Drawing.Size(90, 20);
            this.labelWriteIPServer.TabIndex = 4;
            this.labelWriteIPServer.Text = "IP сервера";
            // 
            // buttonTestConnectingToServer
            // 
            this.buttonTestConnectingToServer.Location = new System.Drawing.Point(262, 76);
            this.buttonTestConnectingToServer.Name = "buttonTestConnectingToServer";
            this.buttonTestConnectingToServer.Size = new System.Drawing.Size(98, 26);
            this.buttonTestConnectingToServer.TabIndex = 3;
            this.buttonTestConnectingToServer.Text = "Тест";
            this.buttonTestConnectingToServer.UseVisualStyleBackColor = true;
            this.buttonTestConnectingToServer.Click += new System.EventHandler(this.ButtonTestConnectingToServer_Click);
            // 
            // tabControlConnect
            // 
            this.tabControlConnect.Controls.Add(this.tabPageIP);
            this.tabControlConnect.Controls.Add(this.tabPageFromList);
            this.tabControlConnect.Controls.Add(this.tabPageCreateDataBase);
            this.tabControlConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlConnect.Location = new System.Drawing.Point(12, 12);
            this.tabControlConnect.Name = "tabControlConnect";
            this.tabControlConnect.SelectedIndex = 0;
            this.tabControlConnect.Size = new System.Drawing.Size(513, 342);
            this.tabControlConnect.TabIndex = 10;
            this.tabControlConnect.SelectedIndexChanged += new System.EventHandler(this.TabControlConnect_SelectedIndexChanged);
            // 
            // tabPageIP
            // 
            this.tabPageIP.Controls.Add(this.groupBoxConnecting);
            this.tabPageIP.Location = new System.Drawing.Point(4, 25);
            this.tabPageIP.Name = "tabPageIP";
            this.tabPageIP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIP.Size = new System.Drawing.Size(505, 313);
            this.tabPageIP.TabIndex = 0;
            this.tabPageIP.Text = "По IP адресу";
            this.tabPageIP.UseVisualStyleBackColor = true;
            // 
            // tabPageFromList
            // 
            this.tabPageFromList.Controls.Add(this.groupBoxSelectServerName);
            this.tabPageFromList.Location = new System.Drawing.Point(4, 25);
            this.tabPageFromList.Name = "tabPageFromList";
            this.tabPageFromList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFromList.Size = new System.Drawing.Size(505, 313);
            this.tabPageFromList.TabIndex = 1;
            this.tabPageFromList.Text = "Вибрати з списку";
            this.tabPageFromList.UseVisualStyleBackColor = true;
            // 
            // groupBoxSelectServerName
            // 
            this.groupBoxSelectServerName.Controls.Add(this.buttonSearchServers);
            this.groupBoxSelectServerName.Controls.Add(this.progressBarConnectToDB);
            this.groupBoxSelectServerName.Controls.Add(this.buttonSaveConfogServerName);
            this.groupBoxSelectServerName.Controls.Add(this.buttonConnectToServerName);
            this.groupBoxSelectServerName.Controls.Add(this.comboBoxListServerName);
            this.groupBoxSelectServerName.Controls.Add(this.labelDBName);
            this.groupBoxSelectServerName.Controls.Add(this.comboBoxListDataBase);
            this.groupBoxSelectServerName.Controls.Add(this.labelServerName);
            this.groupBoxSelectServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSelectServerName.Location = new System.Drawing.Point(16, 16);
            this.groupBoxSelectServerName.Name = "groupBoxSelectServerName";
            this.groupBoxSelectServerName.Size = new System.Drawing.Size(473, 281);
            this.groupBoxSelectServerName.TabIndex = 13;
            this.groupBoxSelectServerName.TabStop = false;
            this.groupBoxSelectServerName.Text = "Вибрати з відкритих мережевих серверів";
            // 
            // progressBarConnectToDB
            // 
            this.progressBarConnectToDB.Location = new System.Drawing.Point(13, 35);
            this.progressBarConnectToDB.Name = "progressBarConnectToDB";
            this.progressBarConnectToDB.Size = new System.Drawing.Size(448, 23);
            this.progressBarConnectToDB.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarConnectToDB.TabIndex = 14;
            this.progressBarConnectToDB.Value = 10;
            this.progressBarConnectToDB.Visible = false;
            // 
            // buttonSaveConfogServerName
            // 
            this.buttonSaveConfogServerName.Enabled = false;
            this.buttonSaveConfogServerName.Location = new System.Drawing.Point(262, 212);
            this.buttonSaveConfogServerName.Name = "buttonSaveConfogServerName";
            this.buttonSaveConfogServerName.Size = new System.Drawing.Size(140, 40);
            this.buttonSaveConfogServerName.TabIndex = 13;
            this.buttonSaveConfogServerName.Text = "Зберегти";
            this.buttonSaveConfogServerName.UseVisualStyleBackColor = true;
            this.buttonSaveConfogServerName.Click += new System.EventHandler(this.ButtonSaveConfogServerName_Click);
            // 
            // buttonConnectToServerName
            // 
            this.buttonConnectToServerName.Enabled = false;
            this.buttonConnectToServerName.Location = new System.Drawing.Point(55, 212);
            this.buttonConnectToServerName.Name = "buttonConnectToServerName";
            this.buttonConnectToServerName.Size = new System.Drawing.Size(140, 40);
            this.buttonConnectToServerName.TabIndex = 12;
            this.buttonConnectToServerName.Text = "Підключитися";
            this.buttonConnectToServerName.UseVisualStyleBackColor = true;
            this.buttonConnectToServerName.Click += new System.EventHandler(this.ButtonConnectToServerName_Click);
            // 
            // comboBoxListServerName
            // 
            this.comboBoxListServerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListServerName.FormattingEnabled = true;
            this.comboBoxListServerName.Location = new System.Drawing.Point(13, 151);
            this.comboBoxListServerName.Name = "comboBoxListServerName";
            this.comboBoxListServerName.Size = new System.Drawing.Size(212, 28);
            this.comboBoxListServerName.TabIndex = 8;
            this.comboBoxListServerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxListServerName_SelectedIndexChanged);
            // 
            // labelDBName
            // 
            this.labelDBName.AutoSize = true;
            this.labelDBName.Location = new System.Drawing.Point(294, 128);
            this.labelDBName.Name = "labelDBName";
            this.labelDBName.Size = new System.Drawing.Size(95, 20);
            this.labelDBName.TabIndex = 11;
            this.labelDBName.Text = "База даних";
            // 
            // comboBoxListDataBase
            // 
            this.comboBoxListDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListDataBase.Enabled = false;
            this.comboBoxListDataBase.FormattingEnabled = true;
            this.comboBoxListDataBase.Location = new System.Drawing.Point(249, 151);
            this.comboBoxListDataBase.Name = "comboBoxListDataBase";
            this.comboBoxListDataBase.Size = new System.Drawing.Size(212, 28);
            this.comboBoxListDataBase.TabIndex = 9;
            this.comboBoxListDataBase.SelectedIndexChanged += new System.EventHandler(this.comboBoxListDataBase_SelectedIndexChanged);
            // 
            // labelServerName
            // 
            this.labelServerName.AutoSize = true;
            this.labelServerName.Location = new System.Drawing.Point(66, 128);
            this.labelServerName.Name = "labelServerName";
            this.labelServerName.Size = new System.Drawing.Size(101, 20);
            this.labelServerName.TabIndex = 10;
            this.labelServerName.Text = "Server Name";
            // 
            // tabPageCreateDataBase
            // 
            this.tabPageCreateDataBase.Controls.Add(this.groupBoxCreateDataBase);
            this.tabPageCreateDataBase.Location = new System.Drawing.Point(4, 25);
            this.tabPageCreateDataBase.Name = "tabPageCreateDataBase";
            this.tabPageCreateDataBase.Size = new System.Drawing.Size(505, 313);
            this.tabPageCreateDataBase.TabIndex = 2;
            this.tabPageCreateDataBase.Text = "Створити базу даних";
            this.tabPageCreateDataBase.UseVisualStyleBackColor = true;
            // 
            // groupBoxCreateDataBase
            // 
            this.groupBoxCreateDataBase.Controls.Add(this.buttonTestConnToCreateDB);
            this.groupBoxCreateDataBase.Controls.Add(this.label1);
            this.groupBoxCreateDataBase.Controls.Add(this.buttonCreateDB);
            this.groupBoxCreateDataBase.Controls.Add(this.maskedTextBoxIpServerCreateDB);
            this.groupBoxCreateDataBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCreateDataBase.Location = new System.Drawing.Point(15, 12);
            this.groupBoxCreateDataBase.Name = "groupBoxCreateDataBase";
            this.groupBoxCreateDataBase.Size = new System.Drawing.Size(473, 284);
            this.groupBoxCreateDataBase.TabIndex = 4;
            this.groupBoxCreateDataBase.TabStop = false;
            this.groupBoxCreateDataBase.Text = "Створити нову базу даних ";
            // 
            // buttonTestConnToCreateDB
            // 
            this.buttonTestConnToCreateDB.Location = new System.Drawing.Point(262, 71);
            this.buttonTestConnToCreateDB.Name = "buttonTestConnToCreateDB";
            this.buttonTestConnToCreateDB.Size = new System.Drawing.Size(89, 26);
            this.buttonTestConnToCreateDB.TabIndex = 1;
            this.buttonTestConnToCreateDB.Text = "Тест";
            this.buttonTestConnToCreateDB.UseVisualStyleBackColor = true;
            this.buttonTestConnToCreateDB.Click += new System.EventHandler(this.ButtonTestConnToCreateDB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP сервера";
            // 
            // buttonCreateDB
            // 
            this.buttonCreateDB.Enabled = false;
            this.buttonCreateDB.Location = new System.Drawing.Point(63, 132);
            this.buttonCreateDB.Name = "buttonCreateDB";
            this.buttonCreateDB.Size = new System.Drawing.Size(116, 38);
            this.buttonCreateDB.TabIndex = 0;
            this.buttonCreateDB.Text = "Створити";
            this.buttonCreateDB.UseVisualStyleBackColor = true;
            this.buttonCreateDB.Click += new System.EventHandler(this.ButtonCreateDB_Click);
            // 
            // maskedTextBoxIpServerCreateDB
            // 
            this.maskedTextBoxIpServerCreateDB.Location = new System.Drawing.Point(46, 71);
            this.maskedTextBoxIpServerCreateDB.Name = "maskedTextBoxIpServerCreateDB";
            this.maskedTextBoxIpServerCreateDB.Size = new System.Drawing.Size(159, 26);
            this.maskedTextBoxIpServerCreateDB.TabIndex = 2;
            this.maskedTextBoxIpServerCreateDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // buttonSearchServers
            // 
            this.buttonSearchServers.Location = new System.Drawing.Point(13, 83);
            this.buttonSearchServers.Name = "buttonSearchServers";
            this.buttonSearchServers.Size = new System.Drawing.Size(154, 31);
            this.buttonSearchServers.TabIndex = 15;
            this.buttonSearchServers.Text = "Пошук серверів";
            this.buttonSearchServers.UseVisualStyleBackColor = true;
            this.buttonSearchServers.Click += new System.EventHandler(this.buttonSearchServers_Click);
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 367);
            this.Controls.Add(this.tabControlConnect);
            this.Name = "Connect";
            this.Text = "Connect";
            this.groupBoxConnecting.ResumeLayout(false);
            this.groupBoxConnecting.PerformLayout();
            this.tabControlConnect.ResumeLayout(false);
            this.tabPageIP.ResumeLayout(false);
            this.tabPageFromList.ResumeLayout(false);
            this.groupBoxSelectServerName.ResumeLayout(false);
            this.groupBoxSelectServerName.PerformLayout();
            this.tabPageCreateDataBase.ResumeLayout(false);
            this.groupBoxCreateDataBase.ResumeLayout(false);
            this.groupBoxCreateDataBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxConnecting;
        private System.Windows.Forms.Button buttonTestConnectingToServer;
        private System.Windows.Forms.Label labelWriteIPServer;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxIPServer;
        private System.Windows.Forms.Label labelListDB;
        private System.Windows.Forms.Button buttonSaveConfig;
        private System.Windows.Forms.ComboBox comboBoxLilstDbIPServer;
        private System.Windows.Forms.Button buttonConnectToIPServer;
        private System.Windows.Forms.TabControl tabControlConnect;
        private System.Windows.Forms.TabPage tabPageIP;
        private System.Windows.Forms.TabPage tabPageFromList;
        private System.Windows.Forms.GroupBox groupBoxSelectServerName;
        private System.Windows.Forms.Button buttonSaveConfogServerName;
        private System.Windows.Forms.Button buttonConnectToServerName;
        private System.Windows.Forms.ComboBox comboBoxListServerName;
        private System.Windows.Forms.Label labelDBName;
        private System.Windows.Forms.ComboBox comboBoxListDataBase;
        private System.Windows.Forms.Label labelServerName;
        private System.Windows.Forms.TabPage tabPageCreateDataBase;
        private System.Windows.Forms.GroupBox groupBoxCreateDataBase;
        private System.Windows.Forms.Button buttonTestConnToCreateDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateDB;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxIpServerCreateDB;
        private System.Windows.Forms.ProgressBar progressBarConnectToDB;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonSearchServers;
    }
}