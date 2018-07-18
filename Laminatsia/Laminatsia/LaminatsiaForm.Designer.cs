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
            this.Managers = new System.Windows.Forms.TabPage();
            this.Tehnologers = new System.Windows.Forms.TabPage();
            this.AddToDB = new System.Windows.Forms.TabPage();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxDealer = new System.Windows.Forms.TextBox();
            this.textBoxProfile = new System.Windows.Forms.TextBox();
            this.textBoxColour = new System.Windows.Forms.TextBox();
            this.Add_NewCity = new System.Windows.Forms.Button();
            this.Add_NewDealer = new System.Windows.Forms.Button();
            this.Add_NewProfile = new System.Windows.Forms.Button();
            this.Add_NewColour = new System.Windows.Forms.Button();
            this.LabelCity = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MenuTabControl.SuspendLayout();
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
            this.MenuTabControl.Size = new System.Drawing.Size(963, 682);
            this.MenuTabControl.TabIndex = 0;
            // 
            // Laminaters
            // 
            this.Laminaters.Location = new System.Drawing.Point(4, 22);
            this.Laminaters.Name = "Laminaters";
            this.Laminaters.Padding = new System.Windows.Forms.Padding(3);
            this.Laminaters.Size = new System.Drawing.Size(955, 656);
            this.Laminaters.TabIndex = 0;
            this.Laminaters.Text = "Ламінація";
            this.Laminaters.UseVisualStyleBackColor = true;
            // 
            // Managers
            // 
            this.Managers.Location = new System.Drawing.Point(4, 22);
            this.Managers.Name = "Managers";
            this.Managers.Padding = new System.Windows.Forms.Padding(3);
            this.Managers.Size = new System.Drawing.Size(955, 656);
            this.Managers.TabIndex = 1;
            this.Managers.Text = "Менеджери";
            this.Managers.UseVisualStyleBackColor = true;
            // 
            // Tehnologers
            // 
            this.Tehnologers.Location = new System.Drawing.Point(4, 22);
            this.Tehnologers.Name = "Tehnologers";
            this.Tehnologers.Size = new System.Drawing.Size(955, 656);
            this.Tehnologers.TabIndex = 2;
            this.Tehnologers.Text = "Технологи";
            this.Tehnologers.UseVisualStyleBackColor = true;
            // 
            // AddToDB
            // 
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
            this.AddToDB.Size = new System.Drawing.Size(955, 656);
            this.AddToDB.TabIndex = 3;
            this.AddToDB.Text = "Додати";
            this.AddToDB.UseVisualStyleBackColor = true;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(108, 37);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(147, 20);
            this.textBoxCity.TabIndex = 0;
            // 
            // textBoxDealer
            // 
            this.textBoxDealer.Location = new System.Drawing.Point(108, 86);
            this.textBoxDealer.Name = "textBoxDealer";
            this.textBoxDealer.Size = new System.Drawing.Size(147, 20);
            this.textBoxDealer.TabIndex = 1;
            // 
            // textBoxProfile
            // 
            this.textBoxProfile.Location = new System.Drawing.Point(108, 133);
            this.textBoxProfile.Name = "textBoxProfile";
            this.textBoxProfile.Size = new System.Drawing.Size(147, 20);
            this.textBoxProfile.TabIndex = 2;
            // 
            // textBoxColour
            // 
            this.textBoxColour.Location = new System.Drawing.Point(108, 173);
            this.textBoxColour.Name = "textBoxColour";
            this.textBoxColour.Size = new System.Drawing.Size(147, 20);
            this.textBoxColour.TabIndex = 3;
            // 
            // Add_NewCity
            // 
            this.Add_NewCity.Location = new System.Drawing.Point(280, 33);
            this.Add_NewCity.Name = "Add_NewCity";
            this.Add_NewCity.Size = new System.Drawing.Size(75, 23);
            this.Add_NewCity.TabIndex = 4;
            this.Add_NewCity.Text = "Додати";
            this.Add_NewCity.UseVisualStyleBackColor = true;
            this.Add_NewCity.Click += new System.EventHandler(this.Add_NewCity_Click);
            // 
            // Add_NewDealer
            // 
            this.Add_NewDealer.Location = new System.Drawing.Point(280, 82);
            this.Add_NewDealer.Name = "Add_NewDealer";
            this.Add_NewDealer.Size = new System.Drawing.Size(75, 23);
            this.Add_NewDealer.TabIndex = 5;
            this.Add_NewDealer.Text = "Додати";
            this.Add_NewDealer.UseVisualStyleBackColor = true;
            // 
            // Add_NewProfile
            // 
            this.Add_NewProfile.Location = new System.Drawing.Point(280, 129);
            this.Add_NewProfile.Name = "Add_NewProfile";
            this.Add_NewProfile.Size = new System.Drawing.Size(75, 23);
            this.Add_NewProfile.TabIndex = 6;
            this.Add_NewProfile.Text = "Додати";
            this.Add_NewProfile.UseVisualStyleBackColor = true;
            // 
            // Add_NewColour
            // 
            this.Add_NewColour.Location = new System.Drawing.Point(280, 169);
            this.Add_NewColour.Name = "Add_NewColour";
            this.Add_NewColour.Size = new System.Drawing.Size(75, 23);
            this.Add_NewColour.TabIndex = 7;
            this.Add_NewColour.Text = "Додати";
            this.Add_NewColour.UseVisualStyleBackColor = true;
            // 
            // LabelCity
            // 
            this.LabelCity.AutoSize = true;
            this.LabelCity.Location = new System.Drawing.Point(28, 44);
            this.LabelCity.Name = "LabelCity";
            this.LabelCity.Size = new System.Drawing.Size(35, 13);
            this.LabelCity.TabIndex = 8;
            this.LabelCity.Text = "Місто";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Дилера";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Профіль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Колір";
            // 
            // LaminatsiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 682);
            this.Controls.Add(this.MenuTabControl);
            this.Name = "LaminatsiaForm";
            this.Text = "Ламінація";
            this.Load += new System.EventHandler(this.LaminatsiaForm_Load);
            this.MenuTabControl.ResumeLayout(false);
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
    }
}