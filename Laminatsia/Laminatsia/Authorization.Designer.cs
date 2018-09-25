namespace Laminatsia
{
    partial class Authorization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBoxAuthorization = new System.Windows.Forms.GroupBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.checkBoxSaveUserInfo = new System.Windows.Forms.CheckBox();
            this.groupBoxAuthorization.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(209, 69);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(316, 26);
            this.textBoxLogin.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(211, 122);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(315, 30);
            this.textBoxPassword.TabIndex = 2;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(48, 69);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(134, 20);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Введіть логін :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Введіть пароль:";
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Location = new System.Drawing.Point(209, 255);
            this.buttonLogIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(145, 52);
            this.buttonLogIn.TabIndex = 0;
            this.buttonLogIn.Text = "Вхід";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.ButtonLogIn_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(363, 255);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(164, 52);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Вихід";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // groupBoxAuthorization
            // 
            this.groupBoxAuthorization.Controls.Add(this.labelRole);
            this.groupBoxAuthorization.Controls.Add(this.comboBoxRole);
            this.groupBoxAuthorization.Controls.Add(this.checkBoxSaveUserInfo);
            this.groupBoxAuthorization.Controls.Add(this.buttonExit);
            this.groupBoxAuthorization.Controls.Add(this.textBoxLogin);
            this.groupBoxAuthorization.Controls.Add(this.textBoxPassword);
            this.groupBoxAuthorization.Controls.Add(this.buttonLogIn);
            this.groupBoxAuthorization.Controls.Add(this.labelLogin);
            this.groupBoxAuthorization.Controls.Add(this.label2);
            this.groupBoxAuthorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAuthorization.Location = new System.Drawing.Point(16, 15);
            this.groupBoxAuthorization.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxAuthorization.Name = "groupBoxAuthorization";
            this.groupBoxAuthorization.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxAuthorization.Size = new System.Drawing.Size(559, 337);
            this.groupBoxAuthorization.TabIndex = 0;
            this.groupBoxAuthorization.TabStop = false;
            this.groupBoxAuthorization.Text = "Введення даних користувача";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(48, 175);
            this.labelRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(134, 20);
            this.labelRole.TabIndex = 0;
            this.labelRole.Text = "Права доступу";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(211, 175);
            this.comboBoxRole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(315, 28);
            this.comboBoxRole.TabIndex = 3;
            // 
            // checkBoxSaveUserInfo
            // 
            this.checkBoxSaveUserInfo.AutoSize = true;
            this.checkBoxSaveUserInfo.Location = new System.Drawing.Point(211, 215);
            this.checkBoxSaveUserInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSaveUserInfo.Name = "checkBoxSaveUserInfo";
            this.checkBoxSaveUserInfo.Size = new System.Drawing.Size(303, 24);
            this.checkBoxSaveUserInfo.TabIndex = 4;
            this.checkBoxSaveUserInfo.Text = "Запам\'ятати цього користувача";
            this.checkBoxSaveUserInfo.UseVisualStyleBackColor = true;
            // 
            // Authorization
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(591, 367);
            this.Controls.Add(this.groupBoxAuthorization);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Authorization";
            this.Text = "Авторизація";
            this.groupBoxAuthorization.ResumeLayout(false);
            this.groupBoxAuthorization.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.GroupBox groupBoxAuthorization;
        private System.Windows.Forms.CheckBox checkBoxSaveUserInfo;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label labelRole;
    }
}