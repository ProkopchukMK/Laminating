using Laminatsia.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Laminatsia
{
    public partial class LaminatsiaForm : Form
    {
        int curentColumn;
        private DealerDTO dealerDTO = new DealerDTO();
        private ColourDTO colourDTO = new ColourDTO();
        private ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
        private ProfileDTO profileDTO = new ProfileDTO();
        private UsersDTO users = new UsersDTO();

        private List<string> listProfile = new List<string>();
        private List<string> listCity = new List<string>();
        private List<string> listColour = new List<string>();

        private void LaminatsiaForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
        }
        public LaminatsiaForm()
        {
            InitializeComponent();
            FillAllComponentManagersTab();
            FillAllComponentAddRemoveTab();
            FillAllComponentLaminatsiaTab();
        }
        private void MenuTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MenuTabControl.SelectedIndex == 0)
            {
                //  MessageBox.Show("Ламінація");
                CleareAllComponentLaminatsiaTab();
                FillAllComponentLaminatsiaTab();
            }
            else if (MenuTabControl.SelectedIndex == 1)
            {
                // MessageBox.Show("Менеджери Технологи");
                CleareAllComponentManagersTab();
                FillAllComponentManagersTab();
            }
            else if (MenuTabControl.SelectedIndex == 2)
            {
                //  MessageBox.Show("Додавання");
                CleareAllComponentAddRemoveTab();
                FillAllComponentAddRemoveTab();
            }
        }


        private void FillGridView(List<ColourGoodsDTO> enterList, DataGridView dataGridView)
        {
            if (enterList == null)
            {
                List<ColourGoodsDTO> listColourGoodsDTO = colourGoodsDTO.GetListColourGoods();
                for (int i = 0; i < listColourGoodsDTO.Count; i++)
                {
                    string statusProfile = listColourGoodsDTO[i].StatusProfile == true ? "ГОТОВИЙ" : "НЕ ГОТОВИЙ";
                    string statusGoods = listColourGoodsDTO[i].StatusGoods == true ? "В РОБОТІ" : "НЕ В РОБОТІ";

                    dataGridView.Rows.Add(listColourGoodsDTO[i].ID, listColourGoodsDTO[i].DateComing.Date, listColourGoodsDTO[i].Profile,
                        listColourGoodsDTO[i].City, listColourGoodsDTO[i].Dealer, listColourGoodsDTO[i].Notes, listColourGoodsDTO[i].Counts,
                         listColourGoodsDTO[i].Colour, listColourGoodsDTO[i].DateToWork.Date, statusProfile, listColourGoodsDTO[i].DateReady.Date, statusGoods);
                }
            }
            else
            {
                enterList = enterList.OrderByDescending(x => x.DateComing).ToList();
                for (int i = 0; i < enterList.Count; i++)
                {
                    string statusProfile = enterList[i].StatusProfile == true ? "ГОТОВИЙ" : "НЕ ГОТОВИЙ";
                    string statusGoods = enterList[i].StatusGoods == true ? "В РОБОТІ" : "НЕ В РОБОТІ";

                    dataGridView.Rows.Add(enterList[i].ID, enterList[i].DateComing.Date, enterList[i].Profile,
                        enterList[i].City, enterList[i].Dealer, enterList[i].Notes, enterList[i].Counts,
                        enterList[i].Colour, enterList[i].DateToWork.Date, statusProfile, enterList[i].DateReady.Date, statusGoods);

                }
            }
        }
        #region   ВКЛАДКА   Додати\Видалити   
        //потрібно ввести спочатку місто а потім дилера
        private void ComboxAddCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAddDealer.Enabled = true;
        }
        //додати нового диллера до бази даних
        private void Add_NewDealer_Click(object sender, EventArgs e)
        {
            string addDealer = textBoxAddDealer.Text.Trim();
            if (сomboBoxAddCityDealer.SelectedItem != null)
            {
                if (addDealer != "")
                {
                    string message = dealerDTO.AddDealer(сomboBoxAddCityDealer.Text, addDealer);
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Потрібно написати назву Дилера!");
                }
            }
            else
            {
                MessageBox.Show("Потрібно вибрати Місто!");
            }
            this.CleareAllComponentAddRemoveTab();
            this.FillAllComponentAddRemoveTab();
        }
        //додати новий профіль до бази даних
        private void ButtonAddCity_Click(object sender, EventArgs e)
        {
            if (textBoxAddCity.Text.Trim() != "")
            {
                string message = dealerDTO.AddCity(textBoxAddCity.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Міста!");
            }
            this.CleareAllComponentAddRemoveTab();
            this.FillAllComponentAddRemoveTab();
        }
        private void Add_NewProfile_Click(object sender, EventArgs e)
        {
            if (textBoxAddProfile.Text.Trim() != "")
            {
                string message = profileDTO.AddProfile(textBoxAddProfile.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Профіля!");
            }
            this.CleareAllComponentAddRemoveTab();
            this.FillAllComponentAddRemoveTab();
        }
        //додати новий колір до бази даних
        private void Add_NewColour_Click(object sender, EventArgs e)
        {
            if (textBoxAddColour.Text.Trim() != "")
            {
                ColourDTO newColour = new ColourDTO();
                string message = newColour.AddColour(textBoxAddColour.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Кольору!");
            }
            this.CleareAllComponentAddRemoveTab();
            this.FillAllComponentAddRemoveTab();
        }
        private void FillAllComponentAddRemoveTab()
        {
            listProfile = profileDTO.GetListProfile();
            listColour = colourDTO.GetListColour();
            listCity = dealerDTO.GetListCity();

            var arrayCity = listCity.ToArray();
            var arrayProfile = listProfile.ToArray();
            var arrayColour = listColour.ToArray();

            сomboBoxAddCityDealer.Items.AddRange(arrayCity);
            comboBoxRemoveCity.Items.AddRange(arrayCity);
            //comboBoxRemoveDealer.Items.AddRange(dealerDTO.GetListDealer().ToArray());              заповнюється відповідно до вибраного міста
            comboBoxRemoveDealer.Enabled = false;
            comboBoxRemoveProfile.Items.AddRange(arrayProfile);
            comboBoxRemoveColour.Items.AddRange(listColour.ToArray());
        }
        private void CleareAllComponentAddRemoveTab()
        {
            //очищення вкладки додати\видалити(додати нове знчення)
            сomboBoxAddCityDealer.Items.Clear();
            textBoxAddDealer.Text = "";
            textBoxAddDealer.Enabled = false;
            textBoxAddProfile.Text = "";
            textBoxAddColour.Text = "";
            textBoxAddCity.Text = "";

            comboBoxRemoveCity.Items.Clear();
            comboBoxRemoveDealer.Items.Clear();
            comboBoxRemoveProfile.Items.Clear();
            comboBoxRemoveColour.Items.Clear();
            dataGridViewManagers.Rows.Clear();

        }
        #region Видалення інформації з бази данних
        private void ComboBoxRemoveCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRemoveDealer.Items.Clear();
            string removeCityName = comboBoxRemoveCity.SelectedItem.ToString();
            var listDealerByCity = dealerDTO.GetListDealerByCity(removeCityName).ToArray();

            if (listDealerByCity.Length == 0)
            {

            }
            else
            {
                comboBoxRemoveDealer.Enabled = true;
                comboBoxRemoveDealer.Items.AddRange(listDealerByCity);
            }
        }
        private void ButtonRemoveDealer_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveCity.SelectedItem != null)
            {
                var listDealer = dealerDTO.GetListDealerByCity(comboBoxRemoveCity.SelectedItem.ToString());
                if (listDealer.Count > 0 && comboBoxRemoveDealer.SelectedItem != null)
                {
                    string messageToRemove = "Дійсно видалити Дилера " + comboBoxRemoveCity.SelectedItem.ToString() + " - " + comboBoxRemoveDealer.SelectedItem.ToString() + " ?";
                    string caption = "Видалення з бази данних!";
                    DialogResult result = MessageBox.Show(messageToRemove, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string message = dealerDTO.RemoveDealer(comboBoxRemoveCity.SelectedItem.ToString(), comboBoxRemoveDealer.SelectedItem.ToString());
                        MessageBox.Show(message);
                        this.CleareAllComponentAddRemoveTab();
                        this.FillAllComponentAddRemoveTab();
                        comboBoxRemoveDealer.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ви відмінили операцію видалення!");
                    }
                }
                else if (listDealer.Count == 0 && comboBoxRemoveDealer.SelectedItem == null)
                {
                    string messageToRemove = "Дійсно видалити Місто " + comboBoxRemoveCity.SelectedItem.ToString() + " ?";
                    string caption = "Видалення з бази данних!";
                    DialogResult result = MessageBox.Show(messageToRemove, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string message = dealerDTO.RemoveDealer(comboBoxRemoveCity.SelectedItem.ToString(), null);
                        MessageBox.Show(message);
                        this.CleareAllComponentAddRemoveTab();
                        this.FillAllComponentAddRemoveTab();
                        comboBoxRemoveDealer.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ви відмінили операцію видалення!");
                    }
                }
                else
                {
                    MessageBox.Show("Потрібно вибрати Дилера!");
                }

            }
            else
            {
                MessageBox.Show("Потрібно вибрати Місто!");
            }
            this.CleareAllComponentAddRemoveTab();
            this.FillAllComponentAddRemoveTab();
        }
        private void ButtonRemoveProfile_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveProfile.SelectedItem != null)
            {
                string messageToRemove = "Дійсно видалити профіль " + comboBoxRemoveProfile.SelectedItem.ToString() + " ?";
                string caption = "Видалення з бази данних!";
                DialogResult result = MessageBox.Show(messageToRemove, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ProfileDTO removeProfile = new ProfileDTO();
                    string message = removeProfile.RemoveProfile(comboBoxRemoveProfile.SelectedItem.ToString());
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Ви відмінили операцію видалення!");
                }
            }
            else
            {
                MessageBox.Show("Потрібно вибрати назву Профілю!");
            }
            this.CleareAllComponentAddRemoveTab();
            this.FillAllComponentAddRemoveTab();
        }
        private void ButtonRemoveColour_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveColour.SelectedItem != null)
            {
                string messageToRemove = "Дійсно видалити колір " + comboBoxRemoveColour.SelectedItem.ToString() + " ?";
                string caption = "Видалення з бази данних!";
                DialogResult result = MessageBox.Show(messageToRemove, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ColourDTO removeColour = new ColourDTO();
                    string message = removeColour.RemoveColour(comboBoxRemoveColour.SelectedItem.ToString());
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Ви відмінили операцію видалення!");
                }
            }
            else
            {
                MessageBox.Show("Потрібно вибрати назву Кольру!");
            }
            this.CleareAllComponentAddRemoveTab();
            this.FillAllComponentAddRemoveTab();
        }
        private void СomboxAddCity_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxAddDealer.Enabled = true;
        }
        private void СomboxAddCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAddDealer.Enabled = true;
        }
        //ведення значення
        private void TextBoxAddCity_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("uk"));
        }
        //встановлення розкладки по дефолту
        private void SetKeyboardLayout(InputLanguage layout)
        {
            InputLanguage.CurrentInputLanguage = layout;
        }
        public static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                {
                    return lang;
                }
            }
            return null;
        }
        #endregion
        #endregion

        #region   ВКЛАДКА   Ламінація
        //додати нове замовлення до бази даних
        private void SaveColourGoods_Click(object sender, EventArgs e)
        {
            if (ComboBoxProfile.SelectedItem != null)
            {
                if (ComboBoxCity.SelectedItem != null)
                {
                    if (ComboBoxDealer.SelectedItem != null)
                    {
                        if (textBoxCounts.Text != "" && textBoxCounts.Text.Trim() != "0")
                        {
                            if (int.Parse(textBoxCounts.Text) < Byte.MaxValue)
                            {
                                if (comboBoxColour.SelectedItem != null)
                                {
                                    if (comboBoxStatusProfile.SelectedItem != null)
                                    {
                                        DateTime dateComing = dateTimePickerDateComing.Value;
                                        string profile = ComboBoxProfile.SelectedItem.ToString();
                                        string city = ComboBoxCity.SelectedItem.ToString();
                                        string dealer = ComboBoxDealer.SelectedItem.ToString();
                                        string notes = richTextBoxNotes.Text;
                                        byte counts = Byte.Parse(textBoxCounts.Text.TrimStart(new Char[] { '0' }));
                                        string colour = comboBoxColour.SelectedItem.ToString();
                                        DateTime dateToWork = dateTimePickerDateToWork.Value;
                                        bool statusProfile = comboBoxStatusProfile.SelectedIndex == 0 ? false : true;
                                        DateTime dateReady = dateTimePickerDateReady.Value;
                                        ColourGoodsDTO colourGoods = new ColourGoodsDTO();
                                        string message = colourGoods.AddColourGoods(dateComing, profile, city, dealer, notes, counts, colour, dateToWork, statusProfile, dateReady);
                                        MessageBox.Show(message);
                                        this.CleareAllComponentLaminatsiaTab();
                                        this.FillAllComponentLaminatsiaTab();
                                    }
                                    else { MessageBox.Show("Ви не вказали Статус профілю!"); }
                                }
                                else { MessageBox.Show("Ви не вказали Колір профілю!"); }
                            }
                            else { MessageBox.Show("Кількість виробів в замовленні не може перевищувати 255!"); }
                        }
                        else { MessageBox.Show("Ви не вказали Кількість виробів!"); textBoxCounts.Text = ""; }
                    }
                    else { MessageBox.Show("Ви не вказали Дилера!"); }
                }
                else { MessageBox.Show("Ви не вказали Місто!"); }
            }
            else { MessageBox.Show("Ви не вказали профіль!"); }
        }
        //введення поля Counts (кількості конструкцій)
        private void TextBoxCounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        //фільтрування диллерів по місту
        private void ComboxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxDealer.Items.Clear();
            DealerDTO dealerDTO = new DealerDTO();
            string cityName = ComboBoxCity.SelectedItem.ToString();
            var listDealerByCity = dealerDTO.GetListDealerByCity(cityName).ToArray();
            ComboBoxDealer.Enabled = true;
            ComboBoxDealer.Items.AddRange(listDealerByCity);
        }
        //змінення розміру вікна нотатків
        private void RichTextBoxNotes_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            var richTextBoxNotes = (RichTextBox)sender;
            if (e.NewRectangle.Height > 26)
            {
                richTextBoxNotes.Height = e.NewRectangle.Height;
            }
            else
            {
                richTextBoxNotes.Height = 26;
            }
        }

        #region Заповнення всіх елементів у вкладці Ламінація
        //заповнення грідвью у вкладці ламінація
        private void FillGridViewLaminatsiaTab(List<ColourGoodsDTO> enterList)
        {
            FillGridView(enterList, dataGridViewLaminatsia);
        }
        //заповнення всіх компонентів у вкладці ламінація
        private void FillAllComponentLaminatsiaTab()
        {
            listProfile = profileDTO.GetListProfile();
            listColour = colourDTO.GetListColour();
            listCity = dealerDTO.GetListCity();

            var arrayCity = listCity.ToArray();
            var arrayProfile = listProfile.ToArray();
            var arrayColour = listColour.ToArray();

            ComboBoxProfile.Items.AddRange(listProfile.ToArray());
            ComboBoxCity.Items.AddRange(arrayCity);
            //comboBoxDealer.Items.AddRange(dealerDTO.GetListDealer().ToArray());                   заповнюється відповідно до вибраного міста
            ComboBoxDealer.Enabled = false;
            comboBoxColour.Items.AddRange(listColour.ToArray());
            comboBoxStatusProfile.Items.AddRange(new object[] { "ГОТОВИЙ", "НЕ ГОТОВИЙ" });
            FillGridViewLaminatsiaTab(null);
        }
        //очищення всіх компонентів у вкладці ламінація
        private void CleareAllComponentLaminatsiaTab()
        {
            dateTimePickerDateComing.Value = DateTime.Now;
            ComboBoxProfile.Items.Clear();
            ComboBoxCity.Items.Clear();
            ComboBoxDealer.Items.Clear();
            richTextBoxNotes.Text = "";
            textBoxCounts.Text = "";
            comboBoxColour.Items.Clear();
            dateTimePickerDateToWork.Value = DateTime.Now;
            comboBoxStatusProfile.Items.Clear();
            dateTimePickerDateReady.Value = DateTime.Now;
            dataGridViewLaminatsia.Rows.Clear();
        }
        #endregion
        //sorted gridview
        private void DataGridViewLaminatsia_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridViewLaminatsia.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dataGridViewLaminatsia.SortedColumn;
            ListSortDirection direction;
            if (oldColumn != null)
            {
                if (oldColumn == newColumn && dataGridViewLaminatsia.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }
            dataGridViewLaminatsia.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
        }
        private void DataGridViewLaminatsia_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridViewLaminatsia.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        #region Update Ламінації
        private void DataGridViewLaminatsia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewLaminatsia.CurrentCell.ColumnIndex != 0)
            {
                dataGridViewLaminatsia.ReadOnly = false;
                dataGridViewLaminatsia.EditingControlShowing -= DataGridViewLaminatsia_EditingControlShowing;
                dataGridViewLaminatsia.EditingControlShowing += DataGridViewLaminatsia_EditingControlShowing;
            }
            else
            {
                dataGridViewLaminatsia.ReadOnly = true;
            }
        }
        private void DataGridViewLaminatsia_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dataGridViewLaminatsia.ReadOnly = false;
            if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 1) // дата замовлення
            {
                curentColumn = 1;
                DateTimePicker dateTimePickerComing = e.Control as DateTimePicker;
                dateTimePickerComing.ValueChanged -= LastLaminatsiaColumnComboSelectionChanged;
                dateTimePickerComing.ValueChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 2) // профіль
            {
                curentColumn = 2;
                ComboBox comboBoxProfile = e.Control as ComboBox;
                comboBoxProfile.SelectedIndexChanged -= LastLaminatsiaColumnComboSelectionChanged;
                comboBoxProfile.SelectedIndexChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 3) // місто
            {
                curentColumn = 3;
                ComboBox comboBoxCity = e.Control as ComboBox;
                comboBoxCity.SelectedIndexChanged -= LastLaminatsiaColumnComboSelectionChanged;
                comboBoxCity.SelectedIndexChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 4) // дилер
            {
                curentColumn = 4;
                ComboBox comboBoxDealer = e.Control as ComboBox;
                comboBoxDealer.SelectedIndexChanged -= LastLaminatsiaColumnComboSelectionChanged;
                comboBoxDealer.SelectedIndexChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 5) // примітки
            {
                curentColumn = 5;
                RichTextBox richTextBoxNotes = e.Control as RichTextBox;
                richTextBoxNotes.TextChanged -= LastLaminatsiaColumnComboSelectionChanged;
                richTextBoxNotes.TextChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 6) // кількість
            {
                curentColumn = 6;
                TextBox textBoxCount = e.Control as TextBox;
                textBoxCount.TextChanged -= LastLaminatsiaColumnComboSelectionChanged;
                textBoxCount.TextChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 7) // колір
            {
                curentColumn = 7;
                ComboBox comboBoxColour = e.Control as ComboBox;
                comboBoxColour.SelectedIndexChanged -= LastLaminatsiaColumnComboSelectionChanged;
                comboBoxColour.SelectedIndexChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 8) // дата в роботу
            {
                curentColumn = 8;
                DateTimePicker datetimeToWork = e.Control as DateTimePicker;
                datetimeToWork.ValueChanged -= LastLaminatsiaColumnComboSelectionChanged;
                datetimeToWork.ValueChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 9) // статус профілю
            {
                curentColumn = 9;
                ComboBox comboBoxStatusProfile = e.Control as ComboBox;
                comboBoxStatusProfile.SelectedIndexChanged -= LastLaminatsiaColumnComboSelectionChanged;
                comboBoxStatusProfile.SelectedIndexChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 10) // дата готовності
            {
                curentColumn = 10;
                DateTimePicker datetimePickerDateReady = e.Control as DateTimePicker;
                datetimePickerDateReady.ValueChanged -= LastLaminatsiaColumnComboSelectionChanged;
                datetimePickerDateReady.ValueChanged += LastLaminatsiaColumnComboSelectionChanged;
            }
            else if (dataGridViewLaminatsia.CurrentCell.ColumnIndex == 0) // поле ID яке змінювати на можливо
            {
                MessageBox.Show("Це поле змінити не можна!");
            }
        }
        private void LastLaminatsiaColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var currentcell = dataGridViewLaminatsia.CurrentCellAddress;
            int id = (int)dataGridViewLaminatsia.Rows[currentcell.Y].Cells[0].Value;
            if (curentColumn == 1)
            {
                // обробити інфу
            }
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            string editStatusProfile = sendingCB.EditingControlFormattedValue.ToString();
            string messageToRemove = "Дійсно змінити інформацію про статус профіля?";
            string caption = "Змінити інформацію в базі данних!";
            DialogResult result = MessageBox.Show(messageToRemove, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (colourGoodsDTO.Update(id, editStatusProfile))
                {
                    MessageBox.Show("Зміни збережені до бази даних!");
                }
                else
                {
                    MessageBox.Show("Зміни не збережено до бази даних!");
                }
            }
            else
            {
                MessageBox.Show("Ви відмінили редагування!");
            }
        }
        #endregion
        #endregion
        #region ВКЛАДКА МЕНЕДЖЕРИ ТЕХНОЛОГИ
        //sorted gridview
        private void DataGridViewManagers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridViewManagers.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dataGridViewManagers.SortedColumn;
            ListSortDirection direction;
            if (oldColumn != null)
            {
                if (oldColumn == newColumn && dataGridViewManagers.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }
            dataGridViewManagers.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
        }
        private void DataGridViewManagers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridViewManagers.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        //заповнення комбобокса дилерів за містом
        private void ComboBoxFilterCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFilterDealer.Items.Clear();
            string filterCityName = comboBoxFilterCity.SelectedItem.ToString();
            var listDealerByCity = dealerDTO.GetListDealerByCity(filterCityName).ToArray();
            comboBoxFilterDealer.Enabled = true;
            comboBoxFilterDealer.Items.AddRange(listDealerByCity);
        }

        #region Фільтри        
        private void ButtonSetFilter_Click(object sender, EventArgs e)
        {
            SetFilter();
        }
        private void SetFilter()
        {
            List<ColourGoodsDTO> filteredList = new List<ColourGoodsDTO>();
            bool? filterStatusGoods = null;
            bool? filterStatusProfile = null;
            if (comboBoxFilterStatusGoods.SelectedItem == null)
            {
                filterStatusGoods = null;
            }
            else if (comboBoxFilterStatusGoods.SelectedItem.ToString() == "В РОБОТІ")
            {
                filterStatusGoods = true;
            }
            else if (comboBoxFilterStatusGoods.SelectedItem.ToString() == "НЕ В РОБОТІ")
            {
                filterStatusGoods = false;
            }
            if (comboBoxFilterStatusProfile.SelectedItem == null)
            {
                filterStatusProfile = null;
            }
            else if (comboBoxFilterStatusProfile.SelectedItem.ToString() == "ГОТОВИЙ")
            {
                filterStatusProfile = true;
            }
            else if (comboBoxFilterStatusProfile.SelectedItem.ToString() == "НЕ ГОТОВИЙ")
            {
                filterStatusProfile = false;
            }

            filteredList = colourGoodsDTO.FilterList(
                checkBoxFilterDateComing.Checked, dateTimePickerFilterDateComing1.Value, dateTimePickerFilterDateComing2.Value, // true
                comboBoxFilterProfile.SelectedItem, comboBoxFilterCity.SelectedItem, comboBoxFilterDealer.SelectedItem, comboBoxFilterColour.SelectedItem,
        checkBoxFilterDateToWork.Checked, dateTimePickerFilterDataToWork1.Value, dateTimePickerFilterDataToWork2.Value, // true
        filterStatusProfile,
        checkBoxFilterDateToReady.Checked, dateTimePickerFilterDateReady1.Value, dateTimePickerFilterDateReady2.Value, // true
        filterStatusGoods);
            filteredList = filteredList.OrderByDescending(x => x.DateComing).ToList();
            dataGridViewManagers.Rows.Clear();
            this.FillGridViewManagers(filteredList);
        }
        #region DateTimePickerFilterDate
        // відсікає помилку коли вибраний не вірний діапазон дат, коли перша дата більша за другу. два датапікера висят на циї івентах
        private void DateTimePickerFilterDateComing2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTimeNow = new DateTime();
            if (CompareDate(dateTimePickerFilterDateComing2.Value.Date, dateTimePickerFilterDateComing1.Value.Date, out dateTimeNow))
            {
                dateTimePickerFilterDateComing2.Value = dateTimeNow;
                dateTimePickerFilterDateComing1.Value = dateTimeNow;
            }
        }
        private void DateTimePickerFilterDataToWork2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTimeNow = new DateTime();
            if (CompareDate(dateTimePickerFilterDataToWork2.Value.Date, dateTimePickerFilterDataToWork1.Value.Date, out dateTimeNow))
            {
                dateTimePickerFilterDataToWork2.Value = dateTimeNow;
                dateTimePickerFilterDataToWork1.Value = dateTimeNow;
            }
        }
        private void DateTimePickerFilterDateReady2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTimeNow = new DateTime();
            if (CompareDate(dateTimePickerFilterDateReady2.Value.Date, dateTimePickerFilterDateReady1.Value.Date, out dateTimeNow))
            {
                dateTimePickerFilterDateReady2.Value = dateTimeNow;
                dateTimePickerFilterDateReady1.Value = dateTimeNow;
            }
        }
        private bool CompareDate(DateTime dateTime2, DateTime dateTime1, out DateTime dateTimeNow)
        {
            if (dateTime2.Date < dateTime1.Date)
            {
                MessageBox.Show("Не вірно вказано діапазон дат!");
                dateTimeNow = DateTime.Now.Date;
                return true;
            }
            else
            {
                dateTimeNow = DateTime.Now.Date;
                return false;
            }
        }
        #endregion

        #region чек бокси дат
        private void CheckBoxFilterDateToWork_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFilterDateToWork.Checked == true)
            {
                dateTimePickerFilterDataToWork1.Enabled = true;
                dateTimePickerFilterDataToWork2.Enabled = true;
            }
            else
            {
                dateTimePickerFilterDataToWork1.Enabled = false;
                dateTimePickerFilterDataToWork2.Enabled = false;
            }
        }
        private void CheckBoxFilterDateComing_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFilterDateComing.Checked == true)
            {
                dateTimePickerFilterDateComing1.Enabled = true;
                dateTimePickerFilterDateComing2.Enabled = true;
            }
            else
            {
                dateTimePickerFilterDateComing1.Enabled = false;
                dateTimePickerFilterDateComing2.Enabled = false;
            }
        }
        private void CheckBoxFilterDateToReady_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFilterDateToReady.Checked == true)
            {
                dateTimePickerFilterDateReady1.Enabled = true;
                dateTimePickerFilterDateReady2.Enabled = true;
            }
            else
            {
                dateTimePickerFilterDateReady1.Enabled = false;
                dateTimePickerFilterDateReady2.Enabled = false;
            }
        }
        #endregion              
        private void ButtonResetFilter_Click(object sender, EventArgs e)
        {
            var dateTimeNow = DateTime.Now;
            dateTimePickerFilterDateComing1.Value = dateTimeNow;
            dateTimePickerFilterDateComing2.Value = dateTimeNow;
            comboBoxFilterProfile.Items.Clear();
            comboBoxFilterCity.Items.Clear();
            comboBoxFilterDealer.Items.Clear();
            comboBoxFilterColour.Items.Clear();
            dateTimePickerFilterDataToWork1.Value = dateTimeNow;
            dateTimePickerFilterDataToWork2.Value = dateTimeNow;
            comboBoxFilterStatusProfile.Items.Clear();
            dateTimePickerFilterDateReady1.Value = dateTimeNow;
            dateTimePickerFilterDateReady2.Value = dateTimeNow;
            comboBoxFilterStatusGoods.Items.Clear();

            checkBoxFilterDateComing.Checked = false;
            checkBoxFilterDateToReady.Checked = false;
            checkBoxFilterDateToWork.Checked = false;

            comboBoxFilterProfile.Items.AddRange(listProfile.ToArray());
            comboBoxFilterCity.Items.AddRange(listCity.ToArray());
            comboBoxFilterColour.Items.AddRange(listColour.ToArray());
            comboBoxFilterStatusProfile.Items.AddRange(new object[] { "ГОТОВИЙ", "НЕ ГОТОВИЙ" });
            comboBoxFilterStatusGoods.Items.AddRange(new object[] { "В РОБОТІ", "НЕ В РОБОТІ" });
            this.dataGridViewManagers.Rows.Clear();
            this.FillGridViewManagers(null);
        }
        #endregion        

        #region Update для технологів
        private void DataGridViewManagers_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dataGridViewManagers.ReadOnly = false;
            if (dataGridViewManagers.CurrentCell.ColumnIndex == 11)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var currentcell = dataGridViewManagers.CurrentCellAddress;
            int id = (int)dataGridViewManagers.Rows[currentcell.Y].Cells[0].Value;
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            string editStatusGoods = sendingCB.EditingControlFormattedValue.ToString();
            string messageToRemove = "Дійсно змінити інформацію про статус профіля?";
            string caption = "Змінити інформацію в базі данних!";
            DialogResult result = MessageBox.Show(messageToRemove, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (colourGoodsDTO.Update(id, editStatusGoods))
                {
                    MessageBox.Show("Зміни збережені до бази даних!");
                }
                else
                {
                    MessageBox.Show("Зміни не збережено до бази даних!");
                }
            }
            else
            {
                MessageBox.Show("Ви відмінили редагування!");
            }
        }

        private void DataGridViewManagers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewManagers.CurrentCell.ColumnIndex == 11)
            {
                dataGridViewManagers.ReadOnly = false;
                dataGridViewManagers.CurrentCell.ReadOnly = false;
                dataGridViewManagers.EditingControlShowing -= DataGridViewManagers_EditingControlShowing;
                dataGridViewManagers.EditingControlShowing += DataGridViewManagers_EditingControlShowing;
            }
            else
            {
                dataGridViewManagers.ReadOnly = true;
            }
        }
        #endregion

        #region Заповнення всіх елементів у вкладці Менеджери Технологи
        private void FillGridViewManagers(List<ColourGoodsDTO> enterList)
        {
            FillGridView(enterList, dataGridViewManagers);
        }
        private void FillAllComponentManagersTab()
        {
            listProfile = profileDTO.GetListProfile();
            listColour = colourDTO.GetListColour();
            listCity = dealerDTO.GetListCity();

            var arrayCity = listCity.ToArray();
            var arrayProfile = listProfile.ToArray();
            var arrayColour = listColour.ToArray();
            comboBoxFilterProfile.Items.AddRange(arrayProfile);
            comboBoxFilterCity.Items.AddRange(arrayCity);
            //дилери заповнюються від міста
            comboBoxFilterColour.Items.AddRange(arrayColour);
            comboBoxFilterStatusProfile.Items.AddRange(new object[] { "ГОТОВИЙ", "НЕ ГОТОВИЙ" });
            comboBoxFilterStatusGoods.Items.AddRange(new object[] { "В РОБОТІ", "НЕ В РОБОТІ" });
            FillGridViewManagers(null);
        }
        private void CleareAllComponentManagersTab()
        {
            comboBoxFilterProfile.Items.Clear();
            comboBoxFilterCity.Items.Clear();
            comboBoxFilterDealer.Items.Clear();
            comboBoxFilterColour.Items.Clear();
            comboBoxFilterStatusProfile.Items.Clear();
            comboBoxFilterStatusGoods.Items.Clear();

            dataGridViewManagers.Rows.Clear();
        }
        #endregion

        #endregion

        private void ButtonFindByID_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxID.Text, out int id))
            {
                if (FindByID(dataGridViewLaminatsia, id) == null)
                {
                    MessageBox.Show("Немає замовлення за " + id + " номером!");
                    textBoxID.Clear();
                }
                else
                {
                    dataGridViewLaminatsia.Rows.Clear();
                    FillGridViewLaminatsiaTab(new List<ColourGoodsDTO> { FindByID(dataGridViewLaminatsia, id) });
                    textBoxID.Clear();
                }
            }
            else
            {
                MessageBox.Show("Не вірний номер замовлення!");
            }
        }
        private ColourGoodsDTO FindByID(DataGridView dataGridView, int id)
        {
            return colourGoodsDTO.GetColourGoodsByID(id);
        }

        private void TextBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void TextBoxTehnologFindByID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void ButtonTehnologFindByID_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxTehnologFindByID.Text, out int id))
            {
                if (FindByID(dataGridViewManagers, id) == null)
                {
                    MessageBox.Show("Немає замовлення за " + id + " номером!");
                    textBoxTehnologFindByID.Clear();
                }
                else
                {
                    dataGridViewManagers.Rows.Clear();
                    FillGridViewManagers(new List<ColourGoodsDTO> { FindByID(dataGridViewManagers, id) });
                    textBoxTehnologFindByID.Clear();
                }
            }
            else
            {
                MessageBox.Show("Не вірний номер замовлення!");
            }
        }
    }

    #region datagridview datetemipickercolumn

    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn() : base(new CalendarCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarCell : DataGridViewTextBoxCell
    {

        public CalendarCell()
            : base()
        {
            // Use the short date format.
            this.Style.Format = "d";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;
            // Use the default row value when Value property is null.
            if (this.Value == null)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }
            else
            {
                ctl.Value = (DateTime)this.Value;
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses.
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return DateTime.Now;
            }
        }
    }

    class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Short;
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToShortDateString();
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        // This will throw an exception of the string is 
                        // null, empty, or not in the format of a date.
                        this.Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        // In the case of an exception, just use the 
                        // default value so we're not left with a null
                        // value.
                        this.Value = DateTime.Now.Date;
                    }
                }
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
    #endregion
}
