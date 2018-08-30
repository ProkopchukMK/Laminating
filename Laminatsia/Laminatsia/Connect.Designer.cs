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
            this.textBoxIPServer = new System.Windows.Forms.TextBox();
            this.comboBoxListServerName = new System.Windows.Forms.ComboBox();
            this.comboBoxListDataBase = new System.Windows.Forms.ComboBox();
            this.groupBoxConnecting = new System.Windows.Forms.GroupBox();
            this.buttonTestConnectingToServer = new System.Windows.Forms.Button();
            this.labelWriteIPServer = new System.Windows.Forms.Label();
            this.labelServerName = new System.Windows.Forms.Label();
            this.labelDBName = new System.Windows.Forms.Label();
            this.labelOr = new System.Windows.Forms.Label();
            this.groupBoxConnecting.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxIPServer
            // 
            this.textBoxIPServer.Location = new System.Drawing.Point(18, 56);
            this.textBoxIPServer.Name = "textBoxIPServer";
            this.textBoxIPServer.Size = new System.Drawing.Size(212, 26);
            this.textBoxIPServer.TabIndex = 0;
            // 
            // comboBoxListServerName
            // 
            this.comboBoxListServerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListServerName.FormattingEnabled = true;
            this.comboBoxListServerName.Location = new System.Drawing.Point(279, 54);
            this.comboBoxListServerName.Name = "comboBoxListServerName";
            this.comboBoxListServerName.Size = new System.Drawing.Size(212, 28);
            this.comboBoxListServerName.TabIndex = 1;
            // 
            // comboBoxListDataBase
            // 
            this.comboBoxListDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListDataBase.FormattingEnabled = true;
            this.comboBoxListDataBase.Location = new System.Drawing.Point(18, 189);
            this.comboBoxListDataBase.Name = "comboBoxListDataBase";
            this.comboBoxListDataBase.Size = new System.Drawing.Size(212, 28);
            this.comboBoxListDataBase.TabIndex = 2;
            // 
            // groupBoxConnecting
            // 
            this.groupBoxConnecting.Controls.Add(this.labelOr);
            this.groupBoxConnecting.Controls.Add(this.labelDBName);
            this.groupBoxConnecting.Controls.Add(this.labelServerName);
            this.groupBoxConnecting.Controls.Add(this.labelWriteIPServer);
            this.groupBoxConnecting.Controls.Add(this.buttonTestConnectingToServer);
            this.groupBoxConnecting.Controls.Add(this.comboBoxListServerName);
            this.groupBoxConnecting.Controls.Add(this.comboBoxListDataBase);
            this.groupBoxConnecting.Controls.Add(this.textBoxIPServer);
            this.groupBoxConnecting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxConnecting.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnecting.Name = "groupBoxConnecting";
            this.groupBoxConnecting.Size = new System.Drawing.Size(509, 348);
            this.groupBoxConnecting.TabIndex = 3;
            this.groupBoxConnecting.TabStop = false;
            this.groupBoxConnecting.Text = "Підключення до бази даних";
            // 
            // buttonTestConnectingToServer
            // 
            this.buttonTestConnectingToServer.Location = new System.Drawing.Point(61, 108);
            this.buttonTestConnectingToServer.Name = "buttonTestConnectingToServer";
            this.buttonTestConnectingToServer.Size = new System.Drawing.Size(98, 26);
            this.buttonTestConnectingToServer.TabIndex = 3;
            this.buttonTestConnectingToServer.Text = "Тест";
            this.buttonTestConnectingToServer.UseVisualStyleBackColor = true;
            this.buttonTestConnectingToServer.Click += new System.EventHandler(this.buttonTestConnectingToServer_Click);
            // 
            // labelWriteIPServer
            // 
            this.labelWriteIPServer.AutoSize = true;
            this.labelWriteIPServer.Location = new System.Drawing.Point(85, 31);
            this.labelWriteIPServer.Name = "labelWriteIPServer";
            this.labelWriteIPServer.Size = new System.Drawing.Size(90, 20);
            this.labelWriteIPServer.TabIndex = 4;
            this.labelWriteIPServer.Text = "IP сервера";
            // 
            // labelServerName
            // 
            this.labelServerName.AutoSize = true;
            this.labelServerName.Location = new System.Drawing.Point(332, 31);
            this.labelServerName.Name = "labelServerName";
            this.labelServerName.Size = new System.Drawing.Size(101, 20);
            this.labelServerName.TabIndex = 5;
            this.labelServerName.Text = "Server Name";
            // 
            // labelDBName
            // 
            this.labelDBName.AutoSize = true;
            this.labelDBName.Location = new System.Drawing.Point(57, 156);
            this.labelDBName.Name = "labelDBName";
            this.labelDBName.Size = new System.Drawing.Size(95, 20);
            this.labelDBName.TabIndex = 6;
            this.labelDBName.Text = "База даних";
            // 
            // labelOr
            // 
            this.labelOr.AutoSize = true;
            this.labelOr.Location = new System.Drawing.Point(236, 59);
            this.labelOr.Name = "labelOr";
            this.labelOr.Size = new System.Drawing.Size(36, 20);
            this.labelOr.TabIndex = 7;
            this.labelOr.Text = "або";
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 369);
            this.Controls.Add(this.groupBoxConnecting);
            this.Name = "Connect";
            this.Text = "Connect";
            this.groupBoxConnecting.ResumeLayout(false);
            this.groupBoxConnecting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIPServer;
        private System.Windows.Forms.ComboBox comboBoxListServerName;
        private System.Windows.Forms.ComboBox comboBoxListDataBase;
        private System.Windows.Forms.GroupBox groupBoxConnecting;
        private System.Windows.Forms.Button buttonTestConnectingToServer;
        private System.Windows.Forms.Label labelWriteIPServer;
        private System.Windows.Forms.Label labelServerName;
        private System.Windows.Forms.Label labelDBName;
        private System.Windows.Forms.Label labelOr;
    }
}