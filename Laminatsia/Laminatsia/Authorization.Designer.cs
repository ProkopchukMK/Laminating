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
            this.textBoxLogin.Location = new System.Drawing.Point(157, 56);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(238, 23);
            this.textBoxLogin.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(158, 99);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(237, 23);
            this.textBoxPassword.TabIndex = 1;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(36, 56);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(101, 17);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Введіть логін :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Введіть пароль:";
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Location = new System.Drawing.Point(157, 207);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(109, 42);
            this.buttonLogIn.TabIndex = 5;
            this.buttonLogIn.Text = "Вхід";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.ButtonLogIn_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(272, 207);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(123, 42);
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
            this.groupBoxAuthorization.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAuthorization.Name = "groupBoxAuthorization";
            this.groupBoxAuthorization.Size = new System.Drawing.Size(419, 274);
            this.groupBoxAuthorization.TabIndex = 0;
            this.groupBoxAuthorization.TabStop = false;
            this.groupBoxAuthorization.Text = "Введення даних користувача";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(36, 142);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(105, 17);
            this.labelRole.TabIndex = 0;
            this.labelRole.Text = "Права доступу";
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(158, 142);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(237, 24);
            this.comboBoxRole.TabIndex = 3;
            // 
            // checkBoxSaveUserInfo
            // 
            this.checkBoxSaveUserInfo.AutoSize = true;
            this.checkBoxSaveUserInfo.Location = new System.Drawing.Point(158, 175);
            this.checkBoxSaveUserInfo.Name = "checkBoxSaveUserInfo";
            this.checkBoxSaveUserInfo.Size = new System.Drawing.Size(237, 21);
            this.checkBoxSaveUserInfo.TabIndex = 4;
            this.checkBoxSaveUserInfo.Text = "Запам\'ятати цього користувача";
            this.checkBoxSaveUserInfo.UseVisualStyleBackColor = true;
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 298);
            this.Controls.Add(this.groupBoxAuthorization);
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