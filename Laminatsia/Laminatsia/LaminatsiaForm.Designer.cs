namespace Laminatsia
{
    partial class LaminatsiaForm
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
            this.MenuTabControl = new System.Windows.Forms.TabControl();
            this.Laminaters = new System.Windows.Forms.TabPage();
            this.dateTimePickerDateReady = new System.Windows.Forms.DateTimePicker();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.labelStatusGoods = new System.Windows.Forms.Label();
            this.labelDateReady = new System.Windows.Forms.Label();
            this.labelStatusProfile = new System.Windows.Forms.Label();
            this.labelDateToWork = new System.Windows.Forms.Label();
            this.labelColour_ID = new System.Windows.Forms.Label();
            this.labelCounts = new System.Windows.Forms.Label();
            this.labelCity_ID = new System.Windows.Forms.Label();
            this.labelDealer = new System.Windows.Forms.Label();
            this.labelProfile = new System.Windows.Forms.Label();
            this.LabelDateComming = new System.Windows.Forms.Label();
            this.dateTimePickerDateComing = new System.Windows.Forms.DateTimePicker();
            this.textBoxCounts = new System.Windows.Forms.TextBox();
            this.Managers = new System.Windows.Forms.TabPage();
            this.Tehnologers = new System.Windows.Forms.TabPage();
            this.AddToDB = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelCity = new System.Windows.Forms.Label();
            this.Add_NewColour = new System.Windows.Forms.Button();
            this.Add_NewProfile = new System.Windows.Forms.Button();
            this.Add_NewDealer = new System.Windows.Forms.Button();
            this.Add_NewCity = new System.Windows.Forms.Button();
            this.textBoxColour = new System.Windows.Forms.TextBox();
            this.textBoxProfile = new System.Windows.Forms.TextBox();
            this.textBoxDealer = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.dateTimePickerDateToWork = new System.Windows.Forms.DateTimePicker();
            this.ComboxCityDealer = new System.Windows.Forms.ComboBox();
            this.comboBoxProfile = new System.Windows.Forms.ComboBox();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.comboBoxColour = new System.Windows.Forms.ComboBox();
            this.comboBoxStatusProfile = new System.Windows.Forms.ComboBox();
            this.comboBoxStatusGoods = new System.Windows.Forms.ComboBox();
            this.MenuTabControl.SuspendLayout();
            this.Laminaters.SuspendLayout();
            this.AddToDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuTabControl
            // 
            this.MenuTabControl.Controls.Add(this.Laminaters);
            this.MenuTabControl.Controls.Add(this.Managers);
            this.MenuTabControl.Controls.Add(this.Tehnologers);
            this.MenuTabControl.Controls.Add(this.AddToDB);
            this.MenuTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTabControl.Location = new System.Drawing.Point(0, 0);
            this.MenuTabControl.Name = "MenuTabControl";
            this.MenuTabControl.SelectedIndex = 0;
            this.MenuTabControl.Size = new System.Drawing.Size(1284, 1006);
            this.MenuTabControl.TabIndex = 0;
            // 
            // Laminaters
            // 
            this.Laminaters.Controls.Add(this.comboBoxStatusGoods);
            this.Laminaters.Controls.Add(this.comboBoxStatusProfile);
            this.Laminaters.Controls.Add(this.comboBoxColour);
            this.Laminaters.Controls.Add(this.comboBoxDealer);
            this.Laminaters.Controls.Add(this.comboBoxCity);
            this.Laminaters.Controls.Add(this.comboBoxProfile);
            this.Laminaters.Controls.Add(this.dateTimePickerDateToWork);
            this.Laminaters.Controls.Add(this.dateTimePickerDateReady);
            this.Laminaters.Controls.Add(this.textBoxNotes);
            this.Laminaters.Controls.Add(this.labelNotes);
            this.Laminaters.Controls.Add(this.labelStatusGoods);
            this.Laminaters.Controls.Add(this.labelDateReady);
            this.Laminaters.Controls.Add(this.labelStatusProfile);
            this.Laminaters.Controls.Add(this.labelDateToWork);
            this.Laminaters.Controls.Add(this.labelColour_ID);
            this.Laminaters.Controls.Add(this.labelCounts);
            this.Laminaters.Controls.Add(this.labelCity_ID);
            this.Laminaters.Controls.Add(this.labelDealer);
            this.Laminaters.Controls.Add(this.labelProfile);
            this.Laminaters.Controls.Add(this.LabelDateComming);
            this.Laminaters.Controls.Add(this.dateTimePickerDateComing);
            this.Laminaters.Controls.Add(this.textBoxCounts);
            this.Laminaters.Location = new System.Drawing.Point(4, 22);
            this.Laminaters.Name = "Laminaters";
            this.Laminaters.Padding = new System.Windows.Forms.Padding(3);
            this.Laminaters.Size = new System.Drawing.Size(1276, 980);
            this.Laminaters.TabIndex = 0;
            this.Laminaters.Text = "Ламінація";
            this.Laminaters.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDateReady
            // 
            this.dateTimePickerDateReady.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateReady.Location = new System.Drawing.Point(1032, 58);
            this.dateTimePickerDateReady.Name = "dateTimePickerDateReady";
            this.dateTimePickerDateReady.Size = new System.Drawing.Size(78, 20);
            this.dateTimePickerDateReady.TabIndex = 20;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(439, 58);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(149, 20);
            this.textBoxNotes.TabIndex = 19;
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(461, 34);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(35, 13);
            this.labelNotes.TabIndex = 18;
            this.labelNotes.Text = "Notes";
            // 
            // labelStatusGoods
            // 
            this.labelStatusGoods.AutoSize = true;
            this.labelStatusGoods.Location = new System.Drawing.Point(1141, 34);
            this.labelStatusGoods.Name = "labelStatusGoods";
            this.labelStatusGoods.Size = new System.Drawing.Size(68, 13);
            this.labelStatusGoods.TabIndex = 17;
            this.labelStatusGoods.Text = "StatusGoods";
            // 
            // labelDateReady
            // 
            this.labelDateReady.AutoSize = true;
            this.labelDateReady.Location = new System.Drawing.Point(1040, 34);
            this.labelDateReady.Name = "labelDateReady";
            this.labelDateReady.Size = new System.Drawing.Size(61, 13);
            this.labelDateReady.TabIndex = 16;
            this.labelDateReady.Text = "DateReady";
            // 
            // labelStatusProfile
            // 
            this.labelStatusProfile.AutoSize = true;
            this.labelStatusProfile.Location = new System.Drawing.Point(915, 36);
            this.labelStatusProfile.Name = "labelStatusProfile";
            this.labelStatusProfile.Size = new System.Drawing.Size(66, 13);
            this.labelStatusProfile.TabIndex = 15;
            this.labelStatusProfile.Text = "StatusProfile";
            // 
            // labelDateToWork
            // 
            this.labelDateToWork.AutoSize = true;
            this.labelDateToWork.Location = new System.Drawing.Point(799, 36);
            this.labelDateToWork.Name = "labelDateToWork";
            this.labelDateToWork.Size = new System.Drawing.Size(69, 13);
            this.labelDateToWork.TabIndex = 14;
            this.labelDateToWork.Text = "DateToWork";
            // 
            // labelColour_ID
            // 
            this.labelColour_ID.AutoSize = true;
            this.labelColour_ID.Location = new System.Drawing.Point(695, 34);
            this.labelColour_ID.Name = "labelColour_ID";
            this.labelColour_ID.Size = new System.Drawing.Size(54, 13);
            this.labelColour_ID.TabIndex = 13;
            this.labelColour_ID.Text = "Colour_ID";
            // 
            // labelCounts
            // 
            this.labelCounts.AutoSize = true;
            this.labelCounts.Location = new System.Drawing.Point(604, 34);
            this.labelCounts.Name = "labelCounts";
            this.labelCounts.Size = new System.Drawing.Size(40, 13);
            this.labelCounts.TabIndex = 12;
            this.labelCounts.Text = "Counts";
            // 
            // labelCity_ID
            // 
            this.labelCity_ID.AutoSize = true;
            this.labelCity_ID.Location = new System.Drawing.Point(238, 36);
            this.labelCity_ID.Name = "labelCity_ID";
            this.labelCity_ID.Size = new System.Drawing.Size(41, 13);
            this.labelCity_ID.TabIndex = 11;
            this.labelCity_ID.Text = "City_ID";
            // 
            // labelDealer
            // 
            this.labelDealer.AutoSize = true;
            this.labelDealer.Location = new System.Drawing.Point(341, 34);
            this.labelDealer.Name = "labelDealer";
            this.labelDealer.Size = new System.Drawing.Size(55, 13);
            this.labelDealer.TabIndex = 10;
            this.labelDealer.Text = "Dealer_ID";
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Location = new System.Drawing.Point(91, 39);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(53, 13);
            this.labelProfile.TabIndex = 9;
            this.labelProfile.Text = "Profile_ID";
            // 
            // LabelDateComming
            // 
            this.LabelDateComming.AutoSize = true;
            this.LabelDateComming.Location = new System.Drawing.Point(9, 39);
            this.LabelDateComming.Name = "LabelDateComming";
            this.LabelDateComming.Size = new System.Drawing.Size(65, 13);
            this.LabelDateComming.TabIndex = 8;
            this.LabelDateComming.Text = "DateComing";
            // 
            // dateTimePickerDateComing
            // 
            this.dateTimePickerDateComing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateComing.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateComing.Location = new System.Drawing.Point(6, 58);
            this.dateTimePickerDateComing.Name = "dateTimePickerDateComing";
            this.dateTimePickerDateComing.Size = new System.Drawing.Size(76, 20);
            this.dateTimePickerDateComing.TabIndex = 7;
            // 
            // textBoxCounts
            // 
            this.textBoxCounts.Location = new System.Drawing.Point(607, 58);
            this.textBoxCounts.MaxLength = 3;
            this.textBoxCounts.Name = "textBoxCounts";
            this.textBoxCounts.Size = new System.Drawing.Size(37, 20);
            this.textBoxCounts.TabIndex = 3;
            this.textBoxCounts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCounts_KeyPress);
            // 
            // Managers
            // 
            this.Managers.Location = new System.Drawing.Point(4, 22);
            this.Managers.Name = "Managers";
            this.Managers.Padding = new System.Windows.Forms.Padding(3);
            this.Managers.Size = new System.Drawing.Size(1276, 656);
            this.Managers.TabIndex = 1;
            this.Managers.Text = "Менеджери";
            this.Managers.UseVisualStyleBackColor = true;
            // 
            // Tehnologers
            // 
            this.Tehnologers.Location = new System.Drawing.Point(4, 22);
            this.Tehnologers.Name = "Tehnologers";
            this.Tehnologers.Size = new System.Drawing.Size(1276, 656);
            this.Tehnologers.TabIndex = 2;
            this.Tehnologers.Text = "Технологи";
            this.Tehnologers.UseVisualStyleBackColor = true;
            // 
            // AddToDB
            // 
            this.AddToDB.Controls.Add(this.ComboxCityDealer);
            this.AddToDB.Controls.Add(this.label4);
            this.AddToDB.Controls.Add(this.label3);
            this.AddToDB.Controls.Add(this.label2);
            this.AddToDB.Controls.Add(this.LabelCity);
            this.AddToDB.Controls.Add(this.Add_NewColour);
            this.AddToDB.Controls.Add(this.Add_NewProfile);
            this.AddToDB.Controls.Add(this.Add_NewDealer);
            this.AddToDB.Controls.Add(this.Add_NewCity);
            this.AddToDB.Controls.Add(this.textBoxColour);
            this.AddToDB.Controls.Add(this.textBoxProfile);
            this.AddToDB.Controls.Add(this.textBoxDealer);
            this.AddToDB.Controls.Add(this.textBoxCity);
            this.AddToDB.Location = new System.Drawing.Point(4, 22);
            this.AddToDB.Name = "AddToDB";
            this.AddToDB.Padding = new System.Windows.Forms.Padding(3);
            this.AddToDB.Size = new System.Drawing.Size(1276, 980);
            this.AddToDB.TabIndex = 3;
            this.AddToDB.Text = "Додати";
            this.AddToDB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Колір";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Профіль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Дилера";
            // 
            // LabelCity
            // 
            this.LabelCity.AutoSize = true;
            this.LabelCity.Location = new System.Drawing.Point(24, 118);
            this.LabelCity.Name = "LabelCity";
            this.LabelCity.Size = new System.Drawing.Size(35, 13);
            this.LabelCity.TabIndex = 8;
            this.LabelCity.Text = "Місто";
            // 
            // Add_NewColour
            // 
            this.Add_NewColour.Location = new System.Drawing.Point(276, 187);
            this.Add_NewColour.Name = "Add_NewColour";
            this.Add_NewColour.Size = new System.Drawing.Size(75, 23);
            this.Add_NewColour.TabIndex = 7;
            this.Add_NewColour.Text = "Додати";
            this.Add_NewColour.UseVisualStyleBackColor = true;
            this.Add_NewColour.Click += new System.EventHandler(this.Add_NewColour_Click);
            // 
            // Add_NewProfile
            // 
            this.Add_NewProfile.Location = new System.Drawing.Point(276, 147);
            this.Add_NewProfile.Name = "Add_NewProfile";
            this.Add_NewProfile.Size = new System.Drawing.Size(75, 23);
            this.Add_NewProfile.TabIndex = 6;
            this.Add_NewProfile.Text = "Додати";
            this.Add_NewProfile.UseVisualStyleBackColor = true;
            this.Add_NewProfile.Click += new System.EventHandler(this.Add_NewProfile_Click);
            // 
            // Add_NewDealer
            // 
            this.Add_NewDealer.Location = new System.Drawing.Point(449, 40);
            this.Add_NewDealer.Name = "Add_NewDealer";
            this.Add_NewDealer.Size = new System.Drawing.Size(75, 23);
            this.Add_NewDealer.TabIndex = 5;
            this.Add_NewDealer.Text = "Додати";
            this.Add_NewDealer.UseVisualStyleBackColor = true;
            this.Add_NewDealer.Click += new System.EventHandler(this.Add_NewDealer_Click);
            // 
            // Add_NewCity
            // 
            this.Add_NewCity.Location = new System.Drawing.Point(276, 107);
            this.Add_NewCity.Name = "Add_NewCity";
            this.Add_NewCity.Size = new System.Drawing.Size(75, 23);
            this.Add_NewCity.TabIndex = 4;
            this.Add_NewCity.Text = "Додати";
            this.Add_NewCity.UseVisualStyleBackColor = true;
            this.Add_NewCity.Click += new System.EventHandler(this.Add_NewCity_Click);
            // 
            // textBoxColour
            // 
            this.textBoxColour.Location = new System.Drawing.Point(104, 192);
            this.textBoxColour.Name = "textBoxColour";
            this.textBoxColour.Size = new System.Drawing.Size(147, 20);
            this.textBoxColour.TabIndex = 3;
            // 
            // textBoxProfile
            // 
            this.textBoxProfile.Location = new System.Drawing.Point(104, 152);
            this.textBoxProfile.Name = "textBoxProfile";
            this.textBoxProfile.Size = new System.Drawing.Size(147, 20);
            this.textBoxProfile.TabIndex = 2;
            // 
            // textBoxDealer
            // 
            this.textBoxDealer.Location = new System.Drawing.Point(276, 41);
            this.textBoxDealer.Name = "textBoxDealer";
            this.textBoxDealer.Size = new System.Drawing.Size(135, 20);
            this.textBoxDealer.TabIndex = 1;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(104, 111);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(147, 20);
            this.textBoxCity.TabIndex = 0;
            // 
            // dateTimePickerDateToWork
            // 
            this.dateTimePickerDateToWork.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateToWork.Location = new System.Drawing.Point(802, 58);
            this.dateTimePickerDateToWork.Name = "dateTimePickerDateToWork";
            this.dateTimePickerDateToWork.Size = new System.Drawing.Size(75, 20);
            this.dateTimePickerDateToWork.TabIndex = 22;
            // 
            // ComboxCityDealer
            // 
            this.ComboxCityDealer.FormattingEnabled = true;
            this.ComboxCityDealer.Location = new System.Drawing.Point(104, 40);
            this.ComboxCityDealer.Name = "ComboxCityDealer";
            this.ComboxCityDealer.Size = new System.Drawing.Size(147, 21);
            this.ComboxCityDealer.TabIndex = 12;
            this.ComboxCityDealer.Text = "Виберіть місто";
            // 
            // comboBoxProfile
            // 
            this.comboBoxProfile.FormattingEnabled = true;
            this.comboBoxProfile.Location = new System.Drawing.Point(94, 57);
            this.comboBoxProfile.Name = "comboBoxProfile";
            this.comboBoxProfile.Size = new System.Drawing.Size(90, 21);
            this.comboBoxProfile.TabIndex = 23;
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Location = new System.Drawing.Point(204, 57);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(107, 21);
            this.comboBoxCity.TabIndex = 24;
            // 
            // comboBoxDealer
            // 
            this.comboBoxDealer.FormattingEnabled = true;
            this.comboBoxDealer.Location = new System.Drawing.Point(333, 57);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(100, 21);
            this.comboBoxDealer.TabIndex = 25;
            // 
            // comboBoxColour
            // 
            this.comboBoxColour.FormattingEnabled = true;
            this.comboBoxColour.Location = new System.Drawing.Point(675, 57);
            this.comboBoxColour.Name = "comboBoxColour";
            this.comboBoxColour.Size = new System.Drawing.Size(121, 21);
            this.comboBoxColour.TabIndex = 26;
            // 
            // comboBoxStatusProfile
            // 
            this.comboBoxStatusProfile.FormattingEnabled = true;
            this.comboBoxStatusProfile.Location = new System.Drawing.Point(893, 57);
            this.comboBoxStatusProfile.Name = "comboBoxStatusProfile";
            this.comboBoxStatusProfile.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStatusProfile.TabIndex = 27;
            // 
            // comboBoxStatusGoods
            // 
            this.comboBoxStatusGoods.FormattingEnabled = true;
            this.comboBoxStatusGoods.Location = new System.Drawing.Point(1144, 57);
            this.comboBoxStatusGoods.Name = "comboBoxStatusGoods";
            this.comboBoxStatusGoods.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStatusGoods.TabIndex = 28;
            // 
            // LaminatsiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 1006);
            this.Controls.Add(this.MenuTabControl);
            this.Name = "LaminatsiaForm";
            this.Text = "Ламінація";
            this.Load += new System.EventHandler(this.LaminatsiaForm_Load);
            this.MenuTabControl.ResumeLayout(false);
            this.Laminaters.ResumeLayout(false);
            this.Laminaters.PerformLayout();
            this.AddToDB.ResumeLayout(false);
            this.AddToDB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MenuTabControl;
        private System.Windows.Forms.TabPage Laminaters;
        private System.Windows.Forms.TabPage Managers;
        private System.Windows.Forms.TabPage Tehnologers;
        private System.Windows.Forms.TabPage AddToDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelCity;
        private System.Windows.Forms.Button Add_NewColour;
        private System.Windows.Forms.Button Add_NewProfile;
        private System.Windows.Forms.Button Add_NewDealer;
        private System.Windows.Forms.Button Add_NewCity;
        private System.Windows.Forms.TextBox textBoxColour;
        private System.Windows.Forms.TextBox textBoxProfile;
        private System.Windows.Forms.TextBox textBoxDealer;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateReady;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.Label labelStatusGoods;
        private System.Windows.Forms.Label labelDateReady;
        private System.Windows.Forms.Label labelStatusProfile;
        private System.Windows.Forms.Label labelDateToWork;
        private System.Windows.Forms.Label labelColour_ID;
        private System.Windows.Forms.Label labelCounts;
        private System.Windows.Forms.Label labelCity_ID;
        private System.Windows.Forms.Label labelDealer;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.Label LabelDateComming;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateComing;
        private System.Windows.Forms.TextBox textBoxCounts;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateToWork;
        private System.Windows.Forms.ComboBox ComboxCityDealer;
        private System.Windows.Forms.ComboBox comboBoxColour;
        private System.Windows.Forms.ComboBox comboBoxDealer;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.ComboBox comboBoxProfile;
        private System.Windows.Forms.ComboBox comboBoxStatusGoods;
        private System.Windows.Forms.ComboBox comboBoxStatusProfile;
    }
}