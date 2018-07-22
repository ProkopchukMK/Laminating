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
            this.components = new System.ComponentModel.Container();
            this.MenuTabControl = new System.Windows.Forms.TabControl();
            this.Laminaters = new System.Windows.Forms.TabPage();
            this.groupBoxCreateNewOrder = new System.Windows.Forms.GroupBox();
            this.dateTimePickerDateComing = new System.Windows.Forms.DateTimePicker();
            this.ComboBoxProfile = new System.Windows.Forms.ComboBox();
            this.SaveColourGoods = new System.Windows.Forms.Button();
            this.labelCounts = new System.Windows.Forms.Label();
            this.labelCity_ID = new System.Windows.Forms.Label();
            this.textBoxCounts = new System.Windows.Forms.TextBox();
            this.dateTimePickerDateToWork = new System.Windows.Forms.DateTimePicker();
            this.labelDateReady = new System.Windows.Forms.Label();
            this.ComboBoxCity = new System.Windows.Forms.ComboBox();
            this.comboBoxStatusProfile = new System.Windows.Forms.ComboBox();
            this.labelColour_ID = new System.Windows.Forms.Label();
            this.labelNotes = new System.Windows.Forms.Label();
            this.labelDealer = new System.Windows.Forms.Label();
            this.LabelDateComming = new System.Windows.Forms.Label();
            this.dateTimePickerDateReady = new System.Windows.Forms.DateTimePicker();
            this.labelStatusProfile = new System.Windows.Forms.Label();
            this.ComboBoxDealer = new System.Windows.Forms.ComboBox();
            this.comboBoxColour = new System.Windows.Forms.ComboBox();
            this.labelDateToWork = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.labelProfile = new System.Windows.Forms.Label();
            this.Managers = new System.Windows.Forms.TabPage();
            this.dataGridViewManagers = new System.Windows.Forms.DataGridView();
            this.Tehnologers = new System.Windows.Forms.TabPage();
            this.comboBoxStatusGoods = new System.Windows.Forms.ComboBox();
            this.labelStatusGoods = new System.Windows.Forms.Label();
            this.AddRemove = new System.Windows.Forms.TabPage();
            this.groupBoxRemove = new System.Windows.Forms.GroupBox();
            this.comboBoxRemoveCity = new System.Windows.Forms.ComboBox();
            this.comboBoxRemoveDealer = new System.Windows.Forms.ComboBox();
            this.labelRemoveColour = new System.Windows.Forms.Label();
            this.comboBoxRemoveProfile = new System.Windows.Forms.ComboBox();
            this.labelRemoveProfile = new System.Windows.Forms.Label();
            this.comboBoxRemoveColour = new System.Windows.Forms.ComboBox();
            this.labelRemoveCity = new System.Windows.Forms.Label();
            this.buttonRemoveDealer = new System.Windows.Forms.Button();
            this.labelRemoveDealer = new System.Windows.Forms.Label();
            this.buttonRemoveColour = new System.Windows.Forms.Button();
            this.buttonRemoveProfile = new System.Windows.Forms.Button();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.textBoxAddDealer = new System.Windows.Forms.TextBox();
            this.textBoxAddProfile = new System.Windows.Forms.TextBox();
            this.textBoxAddColour = new System.Windows.Forms.TextBox();
            this.Add_NewDealer = new System.Windows.Forms.Button();
            this.Add_NewProfile = new System.Windows.Forms.Button();
            this.Add_NewColour = new System.Windows.Forms.Button();
            this.LabelAddCity = new System.Windows.Forms.Label();
            this.labelAddDealer = new System.Windows.Forms.Label();
            this.labelAddProfile = new System.Windows.Forms.Label();
            this.labelAddColour = new System.Windows.Forms.Label();
            this.сomboxAddCity = new System.Windows.Forms.ComboBox();
            this.laminatsiaDataSet = new Laminatsia.LaminatsiaDataSet();
            this.colourGoodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colourGoodsTableAdapter = new Laminatsia.LaminatsiaDataSetTableAdapters.ColourGoodsTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCommingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colourIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateToWorkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusProfileDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dateReadyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusGoodsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuTabControl.SuspendLayout();
            this.Laminaters.SuspendLayout();
            this.groupBoxCreateNewOrder.SuspendLayout();
            this.Managers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).BeginInit();
            this.Tehnologers.SuspendLayout();
            this.AddRemove.SuspendLayout();
            this.groupBoxRemove.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laminatsiaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colourGoodsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuTabControl
            // 
            this.MenuTabControl.Controls.Add(this.Laminaters);
            this.MenuTabControl.Controls.Add(this.Managers);
            this.MenuTabControl.Controls.Add(this.Tehnologers);
            this.MenuTabControl.Controls.Add(this.AddRemove);
            this.MenuTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuTabControl.Location = new System.Drawing.Point(0, 0);
            this.MenuTabControl.Name = "MenuTabControl";
            this.MenuTabControl.SelectedIndex = 0;
            this.MenuTabControl.Size = new System.Drawing.Size(1663, 1006);
            this.MenuTabControl.TabIndex = 11;
            // 
            // Laminaters
            // 
            this.Laminaters.Controls.Add(this.groupBoxCreateNewOrder);
            this.Laminaters.Location = new System.Drawing.Point(4, 25);
            this.Laminaters.Name = "Laminaters";
            this.Laminaters.Padding = new System.Windows.Forms.Padding(3);
            this.Laminaters.Size = new System.Drawing.Size(1655, 977);
            this.Laminaters.TabIndex = 0;
            this.Laminaters.Text = "Ламінація";
            this.Laminaters.UseVisualStyleBackColor = true;
            // 
            // groupBoxCreateNewOrder
            // 
            this.groupBoxCreateNewOrder.Controls.Add(this.dateTimePickerDateComing);
            this.groupBoxCreateNewOrder.Controls.Add(this.ComboBoxProfile);
            this.groupBoxCreateNewOrder.Controls.Add(this.SaveColourGoods);
            this.groupBoxCreateNewOrder.Controls.Add(this.labelCounts);
            this.groupBoxCreateNewOrder.Controls.Add(this.labelCity_ID);
            this.groupBoxCreateNewOrder.Controls.Add(this.textBoxCounts);
            this.groupBoxCreateNewOrder.Controls.Add(this.dateTimePickerDateToWork);
            this.groupBoxCreateNewOrder.Controls.Add(this.labelDateReady);
            this.groupBoxCreateNewOrder.Controls.Add(this.ComboBoxCity);
            this.groupBoxCreateNewOrder.Controls.Add(this.comboBoxStatusProfile);
            this.groupBoxCreateNewOrder.Controls.Add(this.labelColour_ID);
            this.groupBoxCreateNewOrder.Controls.Add(this.labelNotes);
            this.groupBoxCreateNewOrder.Controls.Add(this.labelDealer);
            this.groupBoxCreateNewOrder.Controls.Add(this.LabelDateComming);
            this.groupBoxCreateNewOrder.Controls.Add(this.dateTimePickerDateReady);
            this.groupBoxCreateNewOrder.Controls.Add(this.labelStatusProfile);
            this.groupBoxCreateNewOrder.Controls.Add(this.ComboBoxDealer);
            this.groupBoxCreateNewOrder.Controls.Add(this.comboBoxColour);
            this.groupBoxCreateNewOrder.Controls.Add(this.labelDateToWork);
            this.groupBoxCreateNewOrder.Controls.Add(this.textBoxNotes);
            this.groupBoxCreateNewOrder.Controls.Add(this.labelProfile);
            this.groupBoxCreateNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCreateNewOrder.Location = new System.Drawing.Point(18, 19);
            this.groupBoxCreateNewOrder.Name = "groupBoxCreateNewOrder";
            this.groupBoxCreateNewOrder.Size = new System.Drawing.Size(1552, 132);
            this.groupBoxCreateNewOrder.TabIndex = 29;
            this.groupBoxCreateNewOrder.TabStop = false;
            this.groupBoxCreateNewOrder.Text = "Створити нове замовлення";
            // 
            // dateTimePickerDateComing
            // 
            this.dateTimePickerDateComing.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateComing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateComing.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateComing.Location = new System.Drawing.Point(12, 75);
            this.dateTimePickerDateComing.Name = "dateTimePickerDateComing";
            this.dateTimePickerDateComing.Size = new System.Drawing.Size(102, 26);
            this.dateTimePickerDateComing.TabIndex = 0;
            // 
            // ComboBoxProfile
            // 
            this.ComboBoxProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxProfile.FormattingEnabled = true;
            this.ComboBoxProfile.Location = new System.Drawing.Point(128, 71);
            this.ComboBoxProfile.Name = "ComboBoxProfile";
            this.ComboBoxProfile.Size = new System.Drawing.Size(150, 28);
            this.ComboBoxProfile.TabIndex = 1;
            // 
            // SaveColourGoods
            // 
            this.SaveColourGoods.Location = new System.Drawing.Point(1448, 73);
            this.SaveColourGoods.Name = "SaveColourGoods";
            this.SaveColourGoods.Size = new System.Drawing.Size(98, 28);
            this.SaveColourGoods.TabIndex = 10;
            this.SaveColourGoods.Text = "Створити";
            this.SaveColourGoods.UseVisualStyleBackColor = true;
            this.SaveColourGoods.Click += new System.EventHandler(this.SaveColourGoods_Click);
            // 
            // labelCounts
            // 
            this.labelCounts.AutoSize = true;
            this.labelCounts.Location = new System.Drawing.Point(800, 36);
            this.labelCounts.Name = "labelCounts";
            this.labelCounts.Size = new System.Drawing.Size(60, 20);
            this.labelCounts.TabIndex = 12;
            this.labelCounts.Text = "Counts";
            // 
            // labelCity_ID
            // 
            this.labelCity_ID.AutoSize = true;
            this.labelCity_ID.Location = new System.Drawing.Point(337, 36);
            this.labelCity_ID.Name = "labelCity_ID";
            this.labelCity_ID.Size = new System.Drawing.Size(61, 20);
            this.labelCity_ID.TabIndex = 11;
            this.labelCity_ID.Text = "City_ID";
            // 
            // textBoxCounts
            // 
            this.textBoxCounts.Location = new System.Drawing.Point(823, 74);
            this.textBoxCounts.MaxLength = 3;
            this.textBoxCounts.Name = "textBoxCounts";
            this.textBoxCounts.Size = new System.Drawing.Size(37, 26);
            this.textBoxCounts.TabIndex = 5;
            this.textBoxCounts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxCounts_KeyPress);
            // 
            // dateTimePickerDateToWork
            // 
            this.dateTimePickerDateToWork.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateToWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateToWork.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateToWork.Location = new System.Drawing.Point(1047, 74);
            this.dateTimePickerDateToWork.Name = "dateTimePickerDateToWork";
            this.dateTimePickerDateToWork.Size = new System.Drawing.Size(102, 26);
            this.dateTimePickerDateToWork.TabIndex = 7;
            // 
            // labelDateReady
            // 
            this.labelDateReady.AutoSize = true;
            this.labelDateReady.Location = new System.Drawing.Point(1336, 36);
            this.labelDateReady.Name = "labelDateReady";
            this.labelDateReady.Size = new System.Drawing.Size(90, 20);
            this.labelDateReady.TabIndex = 16;
            this.labelDateReady.Text = "DateReady";
            // 
            // ComboBoxCity
            // 
            this.ComboBoxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCity.FormattingEnabled = true;
            this.ComboBoxCity.Location = new System.Drawing.Point(301, 71);
            this.ComboBoxCity.Name = "ComboBoxCity";
            this.ComboBoxCity.Size = new System.Drawing.Size(150, 28);
            this.ComboBoxCity.TabIndex = 2;
            this.ComboBoxCity.SelectedIndexChanged += new System.EventHandler(this.ComboxCity_SelectedIndexChanged);
            // 
            // comboBoxStatusProfile
            // 
            this.comboBoxStatusProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusProfile.FormattingEnabled = true;
            this.comboBoxStatusProfile.Location = new System.Drawing.Point(1165, 72);
            this.comboBoxStatusProfile.Name = "comboBoxStatusProfile";
            this.comboBoxStatusProfile.Size = new System.Drawing.Size(150, 28);
            this.comboBoxStatusProfile.TabIndex = 8;
            // 
            // labelColour_ID
            // 
            this.labelColour_ID.AutoSize = true;
            this.labelColour_ID.Location = new System.Drawing.Point(910, 36);
            this.labelColour_ID.Name = "labelColour_ID";
            this.labelColour_ID.Size = new System.Drawing.Size(81, 20);
            this.labelColour_ID.TabIndex = 13;
            this.labelColour_ID.Text = "Colour_ID";
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(677, 36);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(51, 20);
            this.labelNotes.TabIndex = 18;
            this.labelNotes.Text = "Notes";
            // 
            // labelDealer
            // 
            this.labelDealer.AutoSize = true;
            this.labelDealer.Location = new System.Drawing.Point(508, 36);
            this.labelDealer.Name = "labelDealer";
            this.labelDealer.Size = new System.Drawing.Size(82, 20);
            this.labelDealer.TabIndex = 10;
            this.labelDealer.Text = "Dealer_ID";
            // 
            // LabelDateComming
            // 
            this.LabelDateComming.AutoSize = true;
            this.LabelDateComming.Location = new System.Drawing.Point(15, 36);
            this.LabelDateComming.Name = "LabelDateComming";
            this.LabelDateComming.Size = new System.Drawing.Size(98, 20);
            this.LabelDateComming.TabIndex = 8;
            this.LabelDateComming.Text = "DateComing";
            // 
            // dateTimePickerDateReady
            // 
            this.dateTimePickerDateReady.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerDateReady.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateReady.Location = new System.Drawing.Point(1340, 75);
            this.dateTimePickerDateReady.Name = "dateTimePickerDateReady";
            this.dateTimePickerDateReady.Size = new System.Drawing.Size(102, 26);
            this.dateTimePickerDateReady.TabIndex = 9;
            // 
            // labelStatusProfile
            // 
            this.labelStatusProfile.AutoSize = true;
            this.labelStatusProfile.Location = new System.Drawing.Point(1188, 36);
            this.labelStatusProfile.Name = "labelStatusProfile";
            this.labelStatusProfile.Size = new System.Drawing.Size(100, 20);
            this.labelStatusProfile.TabIndex = 15;
            this.labelStatusProfile.Text = "StatusProfile";
            // 
            // ComboBoxDealer
            // 
            this.ComboBoxDealer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDealer.FormattingEnabled = true;
            this.ComboBoxDealer.Location = new System.Drawing.Point(474, 72);
            this.ComboBoxDealer.Name = "ComboBoxDealer";
            this.ComboBoxDealer.Size = new System.Drawing.Size(150, 28);
            this.ComboBoxDealer.TabIndex = 3;
            // 
            // comboBoxColour
            // 
            this.comboBoxColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColour.FormattingEnabled = true;
            this.comboBoxColour.Location = new System.Drawing.Point(883, 73);
            this.comboBoxColour.Name = "comboBoxColour";
            this.comboBoxColour.Size = new System.Drawing.Size(150, 28);
            this.comboBoxColour.TabIndex = 6;
            // 
            // labelDateToWork
            // 
            this.labelDateToWork.AutoSize = true;
            this.labelDateToWork.Location = new System.Drawing.Point(1050, 36);
            this.labelDateToWork.Name = "labelDateToWork";
            this.labelDateToWork.Size = new System.Drawing.Size(99, 20);
            this.labelDateToWork.TabIndex = 14;
            this.labelDateToWork.Text = "DateToWork";
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Location = new System.Drawing.Point(645, 75);
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(149, 26);
            this.textBoxNotes.TabIndex = 4;
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Location = new System.Drawing.Point(151, 36);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(79, 20);
            this.labelProfile.TabIndex = 9;
            this.labelProfile.Text = "Profile_ID";
            // 
            // Managers
            // 
            this.Managers.Controls.Add(this.dataGridViewManagers);
            this.Managers.Location = new System.Drawing.Point(4, 25);
            this.Managers.Name = "Managers";
            this.Managers.Padding = new System.Windows.Forms.Padding(3);
            this.Managers.Size = new System.Drawing.Size(1655, 977);
            this.Managers.TabIndex = 1;
            this.Managers.Text = "Менеджери";
            this.Managers.UseVisualStyleBackColor = true;
            // 
            // dataGridViewManagers
            // 
            this.dataGridViewManagers.AutoGenerateColumns = false;
            this.dataGridViewManagers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.dateCommingDataGridViewTextBoxColumn,
            this.profileIDDataGridViewTextBoxColumn,
            this.dealerIDDataGridViewTextBoxColumn,
            this.notesDataGridViewTextBoxColumn,
            this.countsDataGridViewTextBoxColumn,
            this.colourIDDataGridViewTextBoxColumn,
            this.dateToWorkDataGridViewTextBoxColumn,
            this.statusProfileDataGridViewCheckBoxColumn,
            this.dateReadyDataGridViewTextBoxColumn,
            this.statusGoodsDataGridViewCheckBoxColumn});
            this.dataGridViewManagers.DataSource = this.colourGoodsBindingSource;
            this.dataGridViewManagers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewManagers.Location = new System.Drawing.Point(3, 79);
            this.dataGridViewManagers.Name = "dataGridViewManagers";
            this.dataGridViewManagers.Size = new System.Drawing.Size(1649, 895);
            this.dataGridViewManagers.TabIndex = 0;
            // 
            // Tehnologers
            // 
            this.Tehnologers.Controls.Add(this.comboBoxStatusGoods);
            this.Tehnologers.Controls.Add(this.labelStatusGoods);
            this.Tehnologers.Location = new System.Drawing.Point(4, 25);
            this.Tehnologers.Name = "Tehnologers";
            this.Tehnologers.Size = new System.Drawing.Size(1655, 977);
            this.Tehnologers.TabIndex = 2;
            this.Tehnologers.Text = "Технологи";
            this.Tehnologers.UseVisualStyleBackColor = true;
            // 
            // comboBoxStatusGoods
            // 
            this.comboBoxStatusGoods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusGoods.FormattingEnabled = true;
            this.comboBoxStatusGoods.Location = new System.Drawing.Point(1113, 43);
            this.comboBoxStatusGoods.Name = "comboBoxStatusGoods";
            this.comboBoxStatusGoods.Size = new System.Drawing.Size(121, 24);
            this.comboBoxStatusGoods.TabIndex = 30;
            // 
            // labelStatusGoods
            // 
            this.labelStatusGoods.AutoSize = true;
            this.labelStatusGoods.Location = new System.Drawing.Point(1110, 20);
            this.labelStatusGoods.Name = "labelStatusGoods";
            this.labelStatusGoods.Size = new System.Drawing.Size(90, 17);
            this.labelStatusGoods.TabIndex = 29;
            this.labelStatusGoods.Text = "StatusGoods";
            // 
            // AddRemove
            // 
            this.AddRemove.Controls.Add(this.groupBoxRemove);
            this.AddRemove.Controls.Add(this.groupBoxAdd);
            this.AddRemove.Location = new System.Drawing.Point(4, 25);
            this.AddRemove.Name = "AddRemove";
            this.AddRemove.Padding = new System.Windows.Forms.Padding(3);
            this.AddRemove.Size = new System.Drawing.Size(1655, 977);
            this.AddRemove.TabIndex = 3;
            this.AddRemove.Text = "Додати/Видалити";
            this.AddRemove.UseVisualStyleBackColor = true;
            // 
            // groupBoxRemove
            // 
            this.groupBoxRemove.Controls.Add(this.comboBoxRemoveCity);
            this.groupBoxRemove.Controls.Add(this.comboBoxRemoveDealer);
            this.groupBoxRemove.Controls.Add(this.labelRemoveColour);
            this.groupBoxRemove.Controls.Add(this.comboBoxRemoveProfile);
            this.groupBoxRemove.Controls.Add(this.labelRemoveProfile);
            this.groupBoxRemove.Controls.Add(this.comboBoxRemoveColour);
            this.groupBoxRemove.Controls.Add(this.labelRemoveCity);
            this.groupBoxRemove.Controls.Add(this.buttonRemoveDealer);
            this.groupBoxRemove.Controls.Add(this.labelRemoveDealer);
            this.groupBoxRemove.Controls.Add(this.buttonRemoveColour);
            this.groupBoxRemove.Controls.Add(this.buttonRemoveProfile);
            this.groupBoxRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRemove.Location = new System.Drawing.Point(30, 385);
            this.groupBoxRemove.Name = "groupBoxRemove";
            this.groupBoxRemove.Size = new System.Drawing.Size(700, 350);
            this.groupBoxRemove.TabIndex = 29;
            this.groupBoxRemove.TabStop = false;
            this.groupBoxRemove.Text = "Видалити інформацію з бази данних";
            // 
            // comboBoxRemoveCity
            // 
            this.comboBoxRemoveCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRemoveCity.FormattingEnabled = true;
            this.comboBoxRemoveCity.Location = new System.Drawing.Point(119, 91);
            this.comboBoxRemoveCity.Name = "comboBoxRemoveCity";
            this.comboBoxRemoveCity.Size = new System.Drawing.Size(150, 28);
            this.comboBoxRemoveCity.TabIndex = 13;
            this.comboBoxRemoveCity.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRemoveCity_SelectedIndexChanged);
            // 
            // comboBoxRemoveDealer
            // 
            this.comboBoxRemoveDealer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRemoveDealer.Enabled = false;
            this.comboBoxRemoveDealer.FormattingEnabled = true;
            this.comboBoxRemoveDealer.Location = new System.Drawing.Point(291, 90);
            this.comboBoxRemoveDealer.Name = "comboBoxRemoveDealer";
            this.comboBoxRemoveDealer.Size = new System.Drawing.Size(150, 28);
            this.comboBoxRemoveDealer.TabIndex = 14;
            // 
            // labelRemoveColour
            // 
            this.labelRemoveColour.AutoSize = true;
            this.labelRemoveColour.Location = new System.Drawing.Point(42, 264);
            this.labelRemoveColour.Name = "labelRemoveColour";
            this.labelRemoveColour.Size = new System.Drawing.Size(50, 20);
            this.labelRemoveColour.TabIndex = 25;
            this.labelRemoveColour.Text = "Колір";
            // 
            // comboBoxRemoveProfile
            // 
            this.comboBoxRemoveProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRemoveProfile.FormattingEnabled = true;
            this.comboBoxRemoveProfile.Location = new System.Drawing.Point(119, 201);
            this.comboBoxRemoveProfile.Name = "comboBoxRemoveProfile";
            this.comboBoxRemoveProfile.Size = new System.Drawing.Size(150, 28);
            this.comboBoxRemoveProfile.TabIndex = 16;
            // 
            // labelRemoveProfile
            // 
            this.labelRemoveProfile.AutoSize = true;
            this.labelRemoveProfile.Location = new System.Drawing.Point(42, 208);
            this.labelRemoveProfile.Name = "labelRemoveProfile";
            this.labelRemoveProfile.Size = new System.Drawing.Size(76, 20);
            this.labelRemoveProfile.TabIndex = 24;
            this.labelRemoveProfile.Text = "Профіль";
            // 
            // comboBoxRemoveColour
            // 
            this.comboBoxRemoveColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRemoveColour.FormattingEnabled = true;
            this.comboBoxRemoveColour.Location = new System.Drawing.Point(119, 257);
            this.comboBoxRemoveColour.Name = "comboBoxRemoveColour";
            this.comboBoxRemoveColour.Size = new System.Drawing.Size(150, 28);
            this.comboBoxRemoveColour.TabIndex = 17;
            // 
            // labelRemoveCity
            // 
            this.labelRemoveCity.AutoSize = true;
            this.labelRemoveCity.Location = new System.Drawing.Point(150, 52);
            this.labelRemoveCity.Name = "labelRemoveCity";
            this.labelRemoveCity.Size = new System.Drawing.Size(51, 20);
            this.labelRemoveCity.TabIndex = 23;
            this.labelRemoveCity.Text = "Місто";
            // 
            // buttonRemoveDealer
            // 
            this.buttonRemoveDealer.Location = new System.Drawing.Point(464, 88);
            this.buttonRemoveDealer.Name = "buttonRemoveDealer";
            this.buttonRemoveDealer.Size = new System.Drawing.Size(98, 33);
            this.buttonRemoveDealer.TabIndex = 18;
            this.buttonRemoveDealer.Text = "Видалити";
            this.buttonRemoveDealer.UseVisualStyleBackColor = true;
            this.buttonRemoveDealer.Click += new System.EventHandler(this.ButtonRemoveDealer_Click);
            // 
            // labelRemoveDealer
            // 
            this.labelRemoveDealer.AutoSize = true;
            this.labelRemoveDealer.Location = new System.Drawing.Point(335, 52);
            this.labelRemoveDealer.Name = "labelRemoveDealer";
            this.labelRemoveDealer.Size = new System.Drawing.Size(67, 20);
            this.labelRemoveDealer.TabIndex = 22;
            this.labelRemoveDealer.Text = "Дилера";
            // 
            // buttonRemoveColour
            // 
            this.buttonRemoveColour.Location = new System.Drawing.Point(291, 257);
            this.buttonRemoveColour.Name = "buttonRemoveColour";
            this.buttonRemoveColour.Size = new System.Drawing.Size(98, 33);
            this.buttonRemoveColour.TabIndex = 21;
            this.buttonRemoveColour.Text = "Видалити";
            this.buttonRemoveColour.UseVisualStyleBackColor = true;
            this.buttonRemoveColour.Click += new System.EventHandler(this.ButtonRemoveColour_Click);
            // 
            // buttonRemoveProfile
            // 
            this.buttonRemoveProfile.Location = new System.Drawing.Point(291, 198);
            this.buttonRemoveProfile.Name = "buttonRemoveProfile";
            this.buttonRemoveProfile.Size = new System.Drawing.Size(98, 33);
            this.buttonRemoveProfile.TabIndex = 20;
            this.buttonRemoveProfile.Text = "Видалити";
            this.buttonRemoveProfile.UseVisualStyleBackColor = true;
            this.buttonRemoveProfile.Click += new System.EventHandler(this.ButtonRemoveProfile_Click);
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.textBoxAddDealer);
            this.groupBoxAdd.Controls.Add(this.textBoxAddProfile);
            this.groupBoxAdd.Controls.Add(this.textBoxAddColour);
            this.groupBoxAdd.Controls.Add(this.Add_NewDealer);
            this.groupBoxAdd.Controls.Add(this.Add_NewProfile);
            this.groupBoxAdd.Controls.Add(this.Add_NewColour);
            this.groupBoxAdd.Controls.Add(this.LabelAddCity);
            this.groupBoxAdd.Controls.Add(this.labelAddDealer);
            this.groupBoxAdd.Controls.Add(this.labelAddProfile);
            this.groupBoxAdd.Controls.Add(this.labelAddColour);
            this.groupBoxAdd.Controls.Add(this.сomboxAddCity);
            this.groupBoxAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAdd.Location = new System.Drawing.Point(30, 8);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(700, 350);
            this.groupBoxAdd.TabIndex = 28;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "Додати інформацію до бази данних";
            // 
            // textBoxAddDealer
            // 
            this.textBoxAddDealer.Enabled = false;
            this.textBoxAddDealer.Location = new System.Drawing.Point(291, 76);
            this.textBoxAddDealer.Name = "textBoxAddDealer";
            this.textBoxAddDealer.Size = new System.Drawing.Size(150, 26);
            this.textBoxAddDealer.TabIndex = 1;
            // 
            // textBoxAddProfile
            // 
            this.textBoxAddProfile.Location = new System.Drawing.Point(122, 204);
            this.textBoxAddProfile.Name = "textBoxAddProfile";
            this.textBoxAddProfile.Size = new System.Drawing.Size(150, 26);
            this.textBoxAddProfile.TabIndex = 2;
            // 
            // textBoxAddColour
            // 
            this.textBoxAddColour.Location = new System.Drawing.Point(122, 261);
            this.textBoxAddColour.Name = "textBoxAddColour";
            this.textBoxAddColour.Size = new System.Drawing.Size(150, 26);
            this.textBoxAddColour.TabIndex = 3;
            // 
            // Add_NewDealer
            // 
            this.Add_NewDealer.Location = new System.Drawing.Point(464, 75);
            this.Add_NewDealer.Name = "Add_NewDealer";
            this.Add_NewDealer.Size = new System.Drawing.Size(79, 32);
            this.Add_NewDealer.TabIndex = 5;
            this.Add_NewDealer.Text = "Додати";
            this.Add_NewDealer.UseVisualStyleBackColor = true;
            this.Add_NewDealer.Click += new System.EventHandler(this.Add_NewDealer_Click);
            // 
            // Add_NewProfile
            // 
            this.Add_NewProfile.Location = new System.Drawing.Point(294, 199);
            this.Add_NewProfile.Name = "Add_NewProfile";
            this.Add_NewProfile.Size = new System.Drawing.Size(79, 32);
            this.Add_NewProfile.TabIndex = 6;
            this.Add_NewProfile.Text = "Додати";
            this.Add_NewProfile.UseVisualStyleBackColor = true;
            this.Add_NewProfile.Click += new System.EventHandler(this.Add_NewProfile_Click);
            // 
            // Add_NewColour
            // 
            this.Add_NewColour.Location = new System.Drawing.Point(294, 256);
            this.Add_NewColour.Name = "Add_NewColour";
            this.Add_NewColour.Size = new System.Drawing.Size(79, 32);
            this.Add_NewColour.TabIndex = 7;
            this.Add_NewColour.Text = "Додати";
            this.Add_NewColour.UseVisualStyleBackColor = true;
            this.Add_NewColour.Click += new System.EventHandler(this.Add_NewColour_Click);
            // 
            // LabelAddCity
            // 
            this.LabelAddCity.AutoSize = true;
            this.LabelAddCity.Location = new System.Drawing.Point(165, 36);
            this.LabelAddCity.Name = "LabelAddCity";
            this.LabelAddCity.Size = new System.Drawing.Size(51, 20);
            this.LabelAddCity.TabIndex = 8;
            this.LabelAddCity.Text = "Місто";
            // 
            // labelAddDealer
            // 
            this.labelAddDealer.AutoSize = true;
            this.labelAddDealer.Location = new System.Drawing.Point(335, 36);
            this.labelAddDealer.Name = "labelAddDealer";
            this.labelAddDealer.Size = new System.Drawing.Size(67, 20);
            this.labelAddDealer.TabIndex = 9;
            this.labelAddDealer.Text = "Дилера";
            // 
            // labelAddProfile
            // 
            this.labelAddProfile.AutoSize = true;
            this.labelAddProfile.Location = new System.Drawing.Point(42, 204);
            this.labelAddProfile.Name = "labelAddProfile";
            this.labelAddProfile.Size = new System.Drawing.Size(76, 20);
            this.labelAddProfile.TabIndex = 10;
            this.labelAddProfile.Text = "Профіль";
            // 
            // labelAddColour
            // 
            this.labelAddColour.AutoSize = true;
            this.labelAddColour.Location = new System.Drawing.Point(42, 261);
            this.labelAddColour.Name = "labelAddColour";
            this.labelAddColour.Size = new System.Drawing.Size(50, 20);
            this.labelAddColour.TabIndex = 11;
            this.labelAddColour.Text = "Колір";
            // 
            // сomboxAddCity
            // 
            this.сomboxAddCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.сomboxAddCity.FormattingEnabled = true;
            this.сomboxAddCity.Location = new System.Drawing.Point(119, 75);
            this.сomboxAddCity.Name = "сomboxAddCity";
            this.сomboxAddCity.Size = new System.Drawing.Size(150, 28);
            this.сomboxAddCity.TabIndex = 12;
            this.сomboxAddCity.SelectedIndexChanged += new System.EventHandler(this.ComboxAddCity_SelectedIndexChanged);
            // 
            // laminatsiaDataSet
            // 
            this.laminatsiaDataSet.DataSetName = "LaminatsiaDataSet";
            this.laminatsiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // colourGoodsBindingSource
            // 
            this.colourGoodsBindingSource.DataMember = "ColourGoods";
            this.colourGoodsBindingSource.DataSource = this.laminatsiaDataSet;
            // 
            // colourGoodsTableAdapter
            // 
            this.colourGoodsTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateCommingDataGridViewTextBoxColumn
            // 
            this.dateCommingDataGridViewTextBoxColumn.DataPropertyName = "DateComming";
            this.dateCommingDataGridViewTextBoxColumn.HeaderText = "DateComming";
            this.dateCommingDataGridViewTextBoxColumn.Name = "dateCommingDataGridViewTextBoxColumn";
            this.dateCommingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // profileIDDataGridViewTextBoxColumn
            // 
            this.profileIDDataGridViewTextBoxColumn.DataPropertyName = "Profile_ID";
            this.profileIDDataGridViewTextBoxColumn.HeaderText = "Profile_ID";
            this.profileIDDataGridViewTextBoxColumn.Name = "profileIDDataGridViewTextBoxColumn";
            this.profileIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dealerIDDataGridViewTextBoxColumn
            // 
            this.dealerIDDataGridViewTextBoxColumn.DataPropertyName = "Dealer_ID";
            this.dealerIDDataGridViewTextBoxColumn.HeaderText = "Dealer_ID";
            this.dealerIDDataGridViewTextBoxColumn.Name = "dealerIDDataGridViewTextBoxColumn";
            this.dealerIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notesDataGridViewTextBoxColumn
            // 
            this.notesDataGridViewTextBoxColumn.DataPropertyName = "Notes";
            this.notesDataGridViewTextBoxColumn.HeaderText = "Notes";
            this.notesDataGridViewTextBoxColumn.Name = "notesDataGridViewTextBoxColumn";
            this.notesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countsDataGridViewTextBoxColumn
            // 
            this.countsDataGridViewTextBoxColumn.DataPropertyName = "Counts";
            this.countsDataGridViewTextBoxColumn.HeaderText = "Counts";
            this.countsDataGridViewTextBoxColumn.Name = "countsDataGridViewTextBoxColumn";
            this.countsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colourIDDataGridViewTextBoxColumn
            // 
            this.colourIDDataGridViewTextBoxColumn.DataPropertyName = "Colour_ID";
            this.colourIDDataGridViewTextBoxColumn.HeaderText = "Colour_ID";
            this.colourIDDataGridViewTextBoxColumn.Name = "colourIDDataGridViewTextBoxColumn";
            this.colourIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateToWorkDataGridViewTextBoxColumn
            // 
            this.dateToWorkDataGridViewTextBoxColumn.DataPropertyName = "DateToWork";
            this.dateToWorkDataGridViewTextBoxColumn.HeaderText = "DateToWork";
            this.dateToWorkDataGridViewTextBoxColumn.Name = "dateToWorkDataGridViewTextBoxColumn";
            this.dateToWorkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusProfileDataGridViewCheckBoxColumn
            // 
            this.statusProfileDataGridViewCheckBoxColumn.DataPropertyName = "StatusProfile";
            this.statusProfileDataGridViewCheckBoxColumn.HeaderText = "StatusProfile";
            this.statusProfileDataGridViewCheckBoxColumn.Name = "statusProfileDataGridViewCheckBoxColumn";
            this.statusProfileDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dateReadyDataGridViewTextBoxColumn
            // 
            this.dateReadyDataGridViewTextBoxColumn.DataPropertyName = "DateReady";
            this.dateReadyDataGridViewTextBoxColumn.HeaderText = "DateReady";
            this.dateReadyDataGridViewTextBoxColumn.Name = "dateReadyDataGridViewTextBoxColumn";
            this.dateReadyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusGoodsDataGridViewCheckBoxColumn
            // 
            this.statusGoodsDataGridViewCheckBoxColumn.DataPropertyName = "StatusGoods";
            this.statusGoodsDataGridViewCheckBoxColumn.HeaderText = "StatusGoods";
            this.statusGoodsDataGridViewCheckBoxColumn.Name = "statusGoodsDataGridViewCheckBoxColumn";
            this.statusGoodsDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // LaminatsiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1663, 1006);
            this.Controls.Add(this.MenuTabControl);
            this.Name = "LaminatsiaForm";
            this.Text = "Ламінація";
            this.Load += new System.EventHandler(this.LaminatsiaForm_Load);
            this.MenuTabControl.ResumeLayout(false);
            this.Laminaters.ResumeLayout(false);
            this.groupBoxCreateNewOrder.ResumeLayout(false);
            this.groupBoxCreateNewOrder.PerformLayout();
            this.Managers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).EndInit();
            this.Tehnologers.ResumeLayout(false);
            this.Tehnologers.PerformLayout();
            this.AddRemove.ResumeLayout(false);
            this.groupBoxRemove.ResumeLayout(false);
            this.groupBoxRemove.PerformLayout();
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laminatsiaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colourGoodsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MenuTabControl;
        private System.Windows.Forms.TabPage Laminaters;
        private System.Windows.Forms.TabPage Managers;
        private System.Windows.Forms.TabPage Tehnologers;
        private System.Windows.Forms.TabPage AddRemove;
        private System.Windows.Forms.Label labelAddColour;
        private System.Windows.Forms.Label labelAddProfile;
        private System.Windows.Forms.Label labelAddDealer;
        private System.Windows.Forms.Label LabelAddCity;
        private System.Windows.Forms.Button Add_NewColour;
        private System.Windows.Forms.Button Add_NewProfile;
        private System.Windows.Forms.Button Add_NewDealer;
        private System.Windows.Forms.TextBox textBoxAddColour;
        private System.Windows.Forms.TextBox textBoxAddProfile;
        private System.Windows.Forms.TextBox textBoxAddDealer;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateReady;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label labelNotes;
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
        private System.Windows.Forms.ComboBox сomboxAddCity;
        private System.Windows.Forms.ComboBox comboBoxColour;
        private System.Windows.Forms.ComboBox ComboBoxDealer;
        private System.Windows.Forms.ComboBox ComboBoxCity;
        private System.Windows.Forms.ComboBox ComboBoxProfile;
        private System.Windows.Forms.ComboBox comboBoxStatusProfile;
        private System.Windows.Forms.Button SaveColourGoods;
        private System.Windows.Forms.ComboBox comboBoxStatusGoods;
        private System.Windows.Forms.Label labelStatusGoods;
        private System.Windows.Forms.Label labelRemoveColour;
        private System.Windows.Forms.Label labelRemoveProfile;
        private System.Windows.Forms.Label labelRemoveCity;
        private System.Windows.Forms.Label labelRemoveDealer;
        private System.Windows.Forms.Button buttonRemoveColour;
        private System.Windows.Forms.Button buttonRemoveProfile;
        private System.Windows.Forms.Button buttonRemoveDealer;
        private System.Windows.Forms.ComboBox comboBoxRemoveColour;
        private System.Windows.Forms.ComboBox comboBoxRemoveProfile;
        private System.Windows.Forms.ComboBox comboBoxRemoveDealer;
        private System.Windows.Forms.ComboBox comboBoxRemoveCity;
        private System.Windows.Forms.GroupBox groupBoxRemove;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.GroupBox groupBoxCreateNewOrder;
        private System.Windows.Forms.DataGridView dataGridViewManagers;
        private LaminatsiaDataSet laminatsiaDataSet;
        private System.Windows.Forms.BindingSource colourGoodsBindingSource;
        private LaminatsiaDataSetTableAdapters.ColourGoodsTableAdapter colourGoodsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCommingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colourIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateToWorkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusProfileDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateReadyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusGoodsDataGridViewCheckBoxColumn;
    }
}