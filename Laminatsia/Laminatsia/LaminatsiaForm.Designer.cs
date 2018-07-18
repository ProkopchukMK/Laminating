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
            this.MenuTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuTabControl
            // 
            this.MenuTabControl.Controls.Add(this.Laminaters);
            this.MenuTabControl.Controls.Add(this.Managers);
            this.MenuTabControl.Controls.Add(this.Tehnologers);
            this.MenuTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTabControl.Location = new System.Drawing.Point(0, 0);
            this.MenuTabControl.Name = "MenuTabControl";
            this.MenuTabControl.SelectedIndex = 0;
            this.MenuTabControl.Size = new System.Drawing.Size(669, 601);
            this.MenuTabControl.TabIndex = 0;
            // 
            // Laminaters
            // 
            this.Laminaters.Location = new System.Drawing.Point(4, 22);
            this.Laminaters.Name = "Laminaters";
            this.Laminaters.Padding = new System.Windows.Forms.Padding(3);
            this.Laminaters.Size = new System.Drawing.Size(661, 575);
            this.Laminaters.TabIndex = 0;
            this.Laminaters.Text = "Ламінація";
            this.Laminaters.UseVisualStyleBackColor = true;
            // 
            // Managers
            // 
            this.Managers.Location = new System.Drawing.Point(4, 22);
            this.Managers.Name = "Managers";
            this.Managers.Padding = new System.Windows.Forms.Padding(3);
            this.Managers.Size = new System.Drawing.Size(648, 562);
            this.Managers.TabIndex = 1;
            this.Managers.Text = "Менеджери";
            this.Managers.UseVisualStyleBackColor = true;
            // 
            // Tehnologers
            // 
            this.Tehnologers.Location = new System.Drawing.Point(4, 22);
            this.Tehnologers.Name = "Tehnologers";
            this.Tehnologers.Size = new System.Drawing.Size(648, 562);
            this.Tehnologers.TabIndex = 2;
            this.Tehnologers.Text = "Технологи";
            this.Tehnologers.UseVisualStyleBackColor = true;
            // 
            // LaminatsiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 601);
            this.Controls.Add(this.MenuTabControl);
            this.Name = "LaminatsiaForm";
            this.Text = "Ламінація";
            this.MenuTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MenuTabControl;
        private System.Windows.Forms.TabPage Laminaters;
        private System.Windows.Forms.TabPage Managers;
        private System.Windows.Forms.TabPage Tehnologers;
    }
}