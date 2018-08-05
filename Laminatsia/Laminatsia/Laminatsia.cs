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
    public partial class Laminatsia : Form
    {
        private DealerDTO dealerDTO = new DealerDTO();
        private ColourDTO colourDTO = new ColourDTO();
        private ProfileDTO profileDTO = new ProfileDTO();
        private UsersDTO users = new UsersDTO();

        private List<string> listProfile = new List<string>();
        private List<string> listCity = new List<string>();
        private List<string> listColour = new List<string>();

        private int editIDEntity;
        public static string UserName { get; private set; }
        private static string Role;

        private void LaminatsiaForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
        }
        public Laminatsia(string userName, string role)
        {
            InitializeComponent();
            FillAllComponentArciveTab();
            comboBoxAddUserRole.Items.AddRange(new String[] { "Ламінація", "Менеджери", "Технологи", "Адміністратори" });
            UserName = userName;
            Role = role;

            if (role == "Ламінація")
            {
                MenuTabControl.TabIndex = 0;
                //MenuTabControl.TabPages.Remove(tabPageLaminaters);
                //MenuTabControl.TabPages.Remove(tabPageManagers);
                //MenuTabControl.TabPages.Remove(tabPageAddRemove);
                //MenuTabControl.TabPages.Remove(tabPageLogs);
                FillAllComponentAddRemoveTab();
                FillAllComponentLaminatsiaTab();
            }
            else if (role == "Технологи")
            {
                MenuTabControl.TabIndex = 1;
                MenuTabControl.TabPages.Remove(tabPageLaminaters);
                //MenuTabControl.TabPages.Remove(tabPageManagers);
                MenuTabControl.TabPages.Remove(tabPageAddRemove);
                //MenuTabControl.TabPages.Remove(tabPageLogs);
                FillAllComponentManagersTab();
            }
            else if (role == "Менеджери")
            {
                MenuTabControl.TabIndex = 2;
                MenuTabControl.TabPages.Remove(tabPageLaminaters);
                //MenuTabControl.TabPages.Remove(tabPageManagers);
                MenuTabControl.TabPages.Remove(tabPageAddRemove);
                //MenuTabControl.TabPages.Remove(tabPageLogs);
                FillAllComponentManagersTab();
            }
            else if (role == "Адміністратори")
            {
                groupBoxAddUser.Visible = true;
            }
        }
        private void MenuTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MenuTabControl.SelectedTab == tabPageLaminaters)
            {
                //  MessageBox.Show("Ламінація");
                CleareAllComponentLaminatsiaTab();
                FillAllComponentLaminatsiaTab();
            }
            else if (MenuTabControl.SelectedTab == tabPageManagers)
            {
                // MessageBox.Show("Менеджери Технологи");
                CleareAllComponentManagersTab();
                FillAllComponentManagersTab();
            }
            else if (MenuTabControl.SelectedTab == tabPageAddRemove)
            {
                //  MessageBox.Show("Додавання");
                CleareAllComponentAddRemoveTab();
                FillAllComponentAddRemoveTab();
            }
            else if (MenuTabControl.SelectedTab == tabPageLogs)
            {
                //  MessageBox.Show("Додавання");
                CleareAllComponentArchiveTab();
                FillAllComponentArciveTab();
            }
        }
        private void FillGridView(List<ColourGoodsDTO> enterList, DataGridView dataGridView)
        {
            DateTime today = DateTime.Now.Date;
            if (enterList == null)
            {
                ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
                List<ColourGoodsDTO> listColourGoodsDTO = colourGoodsDTO.GetListColourGoods();
                for (int i = 0; i < listColourGoodsDTO.Count; i++)
                {
                    string statusProfile = listColourGoodsDTO[i].StatusProfile == true ? "ГОТОВИЙ" : "НЕ ГОТОВИЙ";
                    string statusGoods = listColourGoodsDTO[i].StatusGoods == true ? "В РОБОТІ" : "НЕ В РОБОТІ";

                    dataGridView.Rows.Add(listColourGoodsDTO[i].ID, listColourGoodsDTO[i].DateComing.Date, listColourGoodsDTO[i].Profile,
                        listColourGoodsDTO[i].City, listColourGoodsDTO[i].Dealer, listColourGoodsDTO[i].Notes, listColourGoodsDTO[i].Counts,
                         listColourGoodsDTO[i].Colour, listColourGoodsDTO[i].DateToWork.Date, statusProfile, listColourGoodsDTO[i].DateReady.Date, statusGoods);
                    //позначення кольором дат
                    //якщо статус профіля ГОТОВИЙ та статус виробу В РОБОТІ
                    if (listColourGoodsDTO[i].StatusProfile && listColourGoodsDTO[i].StatusGoods)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    //від ДАТИ В РОБОТУ  до СЬОГОДНІШНЬОЇ ДАТИ залишається менше 3 днів
                    else if ((listColourGoodsDTO[i].DateToWork.Date - today).Days < 3)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    //від ДАТИ В РОБОТУ  до СЬОГОДНІШНЬОЇ ДАТИ залишається менше 7 днів
                    else if ((listColourGoodsDTO[i].DateToWork.Date - today).Days < 7)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    //від ДАТИ В РОБОТУ  до СЬОГОДНІШНЬОЇ ДАТИ залишається менше 10 днів
                    else if ((listColourGoodsDTO[i].DateToWork.Date - today).Days < 10)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    //це замовлення видалено
                    else if ((listColourGoodsDTO[i].DateRemove != null)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    }
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
                    //позначення кольором дат
                    //якщо статус профіля ГОТОВИЙ та статус виробу В РОБОТІ підсвічувати білим
                    if (enterList[i].StatusProfile && enterList[i].StatusGoods)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    //від ДАТИ В РОБОТУ  до СЬОГОДНІШНЬОЇ ДАТИ залишається менше 3 днів то підсвічувати OrangeRed
                    else if ((enterList[i].DateToWork.Date - today).Days < 3)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    //від ДАТИ В РОБОТУ  до СЬОГОДНІШНЬОЇ ДАТИ залишається менше 7 днів то підсвічувати Indigo
                    else if ((enterList[i].DateToWork.Date - today).Days < 7)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    //від ДАТИ В РОБОТУ  до СЬОГОДНІШНЬОЇ ДАТИ залишається менше 10 днів то підсвічувати зеленим
                    else if ((enterList[i].DateToWork.Date - today).Days < 10)
                    {
                        dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
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
        //додати ного користувача
        private void ButtonAddNewUser_Click(object sender, EventArgs e)
        {
            UsersDTO users = new UsersDTO();
            if (textBoxAddNewUser.Text != "")
            {
                if (users.GetUserByName(textBoxAddNewUser.Text) == null)
                {
                    if (textBoxAddUserPassword.Text != "")
                    {
                        if (comboBoxAddUserRole.SelectedItem != null)
                        {
                            users.AddUser(textBoxAddNewUser.Text, textBoxAddUserPassword.Text, comboBoxAddUserRole.SelectedItem.ToString());
                            MessageBox.Show("Користувача додано до бази даних!");
                            textBoxAddNewUser.Text = "";
                            textBoxAddUserPassword.Text = "";
                            comboBoxAddUserRole.SelectedIndex = -1;
                        }
                        else { MessageBox.Show("Виберіть тип доступу користувача!"); }
                    }
                    else { MessageBox.Show("Введіть пароль користувача!"); textBoxAddUserPassword.Text = ""; }
                }
                else { MessageBox.Show("Користувач з таким іменем вже є!"); textBoxAddNewUser.Text = ""; }
            }
            else { MessageBox.Show("Введіть ім'я користувача!"); textBoxAddNewUser.Text = ""; }
        }
        //заповнити всі компоненти вкладки Додати \ Видалити
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
        //очистити всі компоненти вкладки Додати \ Видалити
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
            dataGridViewTehnologes.Rows.Clear();

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
                                        bool statusProfile = comboBoxStatusProfile.SelectedIndex == 0 ? true : false;
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
        //пошук за номером ID
        private void ButtonFindByID_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(textBoxID.Text, out id))
            {
                ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
                colourGoodsDTO = colourGoodsDTO.GetColourGoodsByID(id);
                if (colourGoodsDTO == null)
                {
                    MessageBox.Show("Немає замовлення за " + id + " номером!");
                    textBoxID.Clear();
                }
                else
                {
                    dataGridViewLaminatsia.Rows.Clear();
                    FillGridViewLaminatsiaTab(new List<ColourGoodsDTO> { colourGoodsDTO });
                    textBoxID.Clear();
                }
            }
            else
            {
                MessageBox.Show("Не вірний номер замовлення!");
            }
        }

        private void TextBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        #region Update Ламінації      
        private void ButtonUpdateRowLaminatsia_Click(object sender, EventArgs e)
        {
            ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
            SaveColourGoods.Text = "Зберегти";
            SaveColourGoods.Click -= SaveColourGoods_Click;
            SaveColourGoods.Click += UtdateColourGoods_Click;
            editIDEntity = int.Parse(dataGridViewLaminatsia.CurrentRow.Cells[0].Value.ToString());
            ColourGoodsDTO editColourGoods = colourGoodsDTO.GetColourGoodsByID(editIDEntity);
            dateTimePickerDateComing.Value = editColourGoods.DateComing.Date;
            ComboBoxProfile.SelectedItem = editColourGoods.Profile;
            ComboBoxCity.SelectedItem = editColourGoods.City;
            ComboBoxDealer.SelectedItem = editColourGoods.Dealer;
            richTextBoxNotes.Text = editColourGoods.Notes;
            textBoxCounts.Text = editColourGoods.Counts.ToString();
            comboBoxColour.SelectedItem = editColourGoods.Colour;
            dateTimePickerDateToWork.Value = editColourGoods.DateToWork.Date;
            comboBoxStatusProfile.SelectedIndex = editColourGoods.StatusProfile == true ? 0 : 1;
            dateTimePickerDateReady.Value = editColourGoods.DateReady.Date;
        }
        private void UtdateColourGoods_Click(object sender, EventArgs e)
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
                                        bool statusProfile = comboBoxStatusProfile.SelectedIndex == 0 ? true : false;
                                        DateTime dateReady = dateTimePickerDateReady.Value;
                                        ColourGoodsDTO colourGoods = new ColourGoodsDTO();
                                        var list = colourGoods.UdateColourGoods(editIDEntity, dateComing, profile, city, dealer, notes, counts, colour, dateToWork, statusProfile, dateReady);
                                        MessageBox.Show("Дані оновлено!");

                                        SaveColourGoods.Text = "Створити";
                                        SaveColourGoods.Click -= UtdateColourGoods_Click;
                                        SaveColourGoods.Click += SaveColourGoods_Click;
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
        //змінити статус профілю
        private void DataGridViewLaminatsia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentcell = dataGridViewLaminatsia.CurrentCellAddress;
            if (currentcell.X == 9 && Role == "Ламінація")
            {
                int id = (int)dataGridViewLaminatsia.Rows[currentcell.Y].Cells[0].Value;
                ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
                colourGoodsDTO = colourGoodsDTO.GetColourGoodsByID(id);
                bool editStatusProfile = !colourGoodsDTO.StatusProfile;
                string messageToRemove = "Дійсно змінити інформацію про статус профілю?";
                string caption = "Змінити інформацію в базі данних!";
                DialogResult result = MessageBox.Show(messageToRemove, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (colourGoodsDTO.UpdateStatusProfile(id, editStatusProfile))
                    {
                        MessageBox.Show("Зміни збережені до бази даних!");
                        CleareAllComponentLaminatsiaTab();
                        FillAllComponentLaminatsiaTab();
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
        }
        #endregion

        #endregion

        #region ВКЛАДКА МЕНЕДЖЕРИ ТЕХНОЛОГИ

        #region Заповнення всіх елементів у вкладці Менеджери Технологи
        private void FillGridViewManagers(List<ColourGoodsDTO> enterList)
        {
            FillGridView(enterList, dataGridViewTehnologes);
        }
        private void FillAllComponentManagersTab()
        {
            if(Role == "Ламінація")
            {
                buttonRemoveColourGoods.Visible = true;
            }

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
            comboBoxFilterDealer.Enabled = false;
            comboBoxFilterColour.Items.Clear();
            comboBoxFilterStatusProfile.Items.Clear();
            comboBoxFilterStatusGoods.Items.Clear();

            dataGridViewTehnologes.Rows.Clear();
        }
        #endregion

        #region сортування gridviewManagers
        private void DataGridViewManagers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dataGridViewTehnologes.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dataGridViewTehnologes.SortedColumn;
            ListSortDirection direction;
            if (oldColumn != null)
            {
                if (oldColumn == newColumn && dataGridViewTehnologes.SortOrder == SortOrder.Ascending)
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
            dataGridViewTehnologes.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
        }
        private void DataGridViewManagers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridViewTehnologes.Columns)
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
        #endregion

        #region Фільтри  
        //пошук за ID
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
            int id;
            if (int.TryParse(textBoxTehnologFindByID.Text, out id))
            {
                ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
                colourGoodsDTO = colourGoodsDTO.GetColourGoodsByID(id);
                if (colourGoodsDTO == null)
                {
                    MessageBox.Show("Немає замовлення за " + id + " номером!");
                    textBoxTehnologFindByID.Clear();
                }
                else
                {
                    dataGridViewTehnologes.Rows.Clear();
                    FillGridViewManagers(new List<ColourGoodsDTO> { colourGoodsDTO });
                    textBoxTehnologFindByID.Clear();
                }
            }
            else
            {
                MessageBox.Show("Не вірний номер замовлення!");
            }
        }
        //застосовуємо фільтри
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
            ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
            filteredList = colourGoodsDTO.FilterList(
                    checkBoxFilterDateComing.Checked, dateTimePickerFilterDateComing1.Value, dateTimePickerFilterDateComing2.Value, // true
                    comboBoxFilterProfile.SelectedItem, comboBoxFilterCity.SelectedItem, comboBoxFilterDealer.SelectedItem, comboBoxFilterColour.SelectedItem,
            checkBoxFilterDateToWork.Checked, dateTimePickerFilterDataToWork1.Value, dateTimePickerFilterDataToWork2.Value, // true
            filterStatusProfile,
            checkBoxFilterDateToReady.Checked, dateTimePickerFilterDateReady1.Value, dateTimePickerFilterDateReady2.Value, // true
            filterStatusGoods);
            filteredList = filteredList.OrderByDescending(x => x.DateComing).ToList();
            dataGridViewTehnologes.Rows.Clear();
            this.FillGridViewManagers(filteredList);
        }
        //скидаємо(ресетаємо) всі фільтри
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
            this.dataGridViewTehnologes.Rows.Clear();
            this.FillGridViewManagers(null);
        }

        #region DateTimePickerFilterDate
        // відсікає помилку коли вибраний не вірний діапазон дат, коли перша дата більша за другу. По два датапікера(від та до) висят на цих івентах
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
        //чек бокси дат
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
        #endregion

        #region Update для технологів

        private void DataGridViewManagers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentcell = dataGridViewTehnologes.CurrentCellAddress;
            if (currentcell.X == 11 && Role == "Технологи")
            {
                int id = (int)dataGridViewTehnologes.Rows[currentcell.Y].Cells[0].Value;
                ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
                colourGoodsDTO = colourGoodsDTO.GetColourGoodsByID(id);
                bool editStatusGoods = !colourGoodsDTO.StatusGoods;
                string messageToRemove = "Дійсно змінити інформацію про статус виробу(ів)?";
                string caption = "Змінити інформацію в базі данних!";
                DialogResult result = MessageBox.Show(messageToRemove, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (colourGoodsDTO.UpdateStatusGood(id, editStatusGoods))
                    {
                        MessageBox.Show("Зміни збережені до бази даних!");
                        CleareAllComponentManagersTab();
                        FillAllComponentManagersTab();
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
        }
        #endregion

        #endregion

        #region Архів
        private void FillAllComponentArciveTab()
        {
            ArchiveDTO archiveDTO = new ArchiveDTO();
            List<ArchiveDTO> listArchiveDTO = archiveDTO.GetAllListArchive();
            comboBoxArchiveProfile.Items.AddRange(listArchiveDTO.Select(x => x.Profile).Distinct().ToArray());
            var cityList = listArchiveDTO.Select(x => x.City).Distinct();
            comboBoxArchiveCity.Items.AddRange(cityList.ToArray());
            comboBoxArchiveDealer.Enabled = false;
            comboBoxArchiveColour.Items.AddRange(listArchiveDTO.Select(x => x.Colour).Distinct().ToArray());
            comboBoxArchiveUser.Items.AddRange(listArchiveDTO.Select(x => x.UserName).Distinct().ToArray());
            FillGridViewArchive(null, dataGridViewLogs);
        }
        private void ComboBoxArchiveCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArchiveDTO archiveDTO = new ArchiveDTO();
            List<ArchiveDTO> listArchiveDTO = archiveDTO.GetListArchiveDisting();
            comboBoxArchiveDealer.Items.Clear();
            string cityArchive = comboBoxArchiveCity.SelectedItem.ToString();
            var dealerList = listArchiveDTO.Where(x => x.City == cityArchive).Select(x => x.Dealer).Distinct().ToArray();
            if (dealerList.Length > 0)
            {
                comboBoxArchiveDealer.Enabled = true;
                comboBoxArchiveDealer.Items.AddRange(dealerList);
            }
        }
        //очищення всіх компонентів у вкладці архів операцій
        private void CleareAllComponentArchiveTab()
        {
            comboBoxArchiveProfile.Items.Clear();
            comboBoxArchiveCity.Items.Clear();
            comboBoxArchiveDealer.Items.Clear();
            comboBoxArchiveDealer.Enabled = false;
            comboBoxArchiveColour.Items.Clear();
            comboBoxArchiveUser.Items.Clear();
            dataGridViewLogs.Rows.Clear();
        }
        private void FillGridViewArchive(List<ArchiveDTO> enterList, DataGridView dataGridView)
        {
            DateTime today = DateTime.Now;
            labelDateTimeUpdate.Text = today.ToString();
            if (enterList == null)
            {
                ArchiveDTO archiveDTO = new ArchiveDTO();
                List<ArchiveDTO> listarchiveDTO = archiveDTO.GetListArchiveDisting().OrderByDescending(x => x.DateOperatsia).ToList();
                for (int i = 0; i < listarchiveDTO.Count; i++)
                {
                    string statusProfile = listarchiveDTO[i].StatusProfile == true ? "ГОТОВИЙ" : "НЕ ГОТОВИЙ";
                    string statusGoods = listarchiveDTO[i].StatusGoods == true ? "В РОБОТІ" : "НЕ В РОБОТІ";

                    dataGridView.Rows.Add(listarchiveDTO[i].ID_ColourGoods, listarchiveDTO[i].DateComing.Date, listarchiveDTO[i].Profile,
                        listarchiveDTO[i].City, listarchiveDTO[i].Dealer, listarchiveDTO[i].Notes, listarchiveDTO[i].Counts,
                         listarchiveDTO[i].Colour, listarchiveDTO[i].DateToWork.Date, statusProfile, listarchiveDTO[i].DateReady.Date, statusGoods, listarchiveDTO[i].UserName, listarchiveDTO[i].DateOperatsia, listarchiveDTO[i].Action);
                }
            }
            else
            {
                enterList = enterList.OrderByDescending(x => x.DateOperatsia).ToList();
                for (int i = 0; i < enterList.Count; i++)
                {
                    string statusProfile = enterList[i].StatusProfile == true ? "ГОТОВИЙ" : "НЕ ГОТОВИЙ";
                    string statusGoods = enterList[i].StatusGoods == true ? "В РОБОТІ" : "НЕ В РОБОТІ";

                    dataGridView.Rows.Add(enterList[i].ID_ColourGoods, enterList[i].DateComing.Date, enterList[i].Profile,
                        enterList[i].City, enterList[i].Dealer, enterList[i].Notes, enterList[i].Counts,
                         enterList[i].Colour, enterList[i].DateToWork.Date, statusProfile, enterList[i].DateReady.Date, statusGoods, enterList[i].UserName, enterList[i].DateOperatsia, enterList[i].Action);
                }
            }
        }

        private void ButtonUpdateGridViewArchive_Click(object sender, EventArgs e)
        {
            ArchiveDTO colourGoodsDTO = new ArchiveDTO();
            dataGridViewLogs.Rows.Clear();
            List<ArchiveDTO> listColourGoodsDTO = colourGoodsDTO.GetListArchiveDisting().OrderByDescending(x => x.DateOperatsia).ToList();
            FillGridViewArchive(listColourGoodsDTO, dataGridViewLogs);
        }

        private void ButtonSetArchiveFilter_Click(object sender, EventArgs e)
        {
            if (checkBoxWithOperation.Checked) // з операціями
            {
                ArchiveDTO archiveDTO = new ArchiveDTO();
                List<ArchiveDTO> filteredList = archiveDTO.GetAllListArchive();
                if (textBoxIDColourGoods.Text != "")
                {
                    filteredList = archiveDTO.FilterByIDColourGoods(filteredList, int.Parse(textBoxIDColourGoods.Text));
                    dataGridViewLogs.Rows.Clear();
                    this.FillGridViewArchive(filteredList, dataGridViewLogs);
                }
                else
                {
                    filteredList = archiveDTO.FilterArchive(filteredList, comboBoxArchiveProfile.SelectedItem, comboBoxArchiveCity.SelectedItem, comboBoxArchiveDealer.SelectedItem, comboBoxArchiveColour.SelectedItem, comboBoxArchiveUser.SelectedItem);
                    dataGridViewLogs.Rows.Clear();
                    this.FillGridViewArchive(filteredList, dataGridViewLogs);
                }
            }
            else // без операцій
            {
                ArchiveDTO archiveDTO = new ArchiveDTO();
                List<ArchiveDTO> filteredList = archiveDTO.GetListArchiveDisting();
                if (textBoxIDColourGoods.Text != "")
                {
                    filteredList = archiveDTO.FilterByIDColourGoods(filteredList, int.Parse(textBoxIDColourGoods.Text));
                    dataGridViewLogs.Rows.Clear();
                    this.FillGridViewArchive(filteredList, dataGridViewLogs);
                }
                else
                {
                    filteredList = archiveDTO.FilterArchive(filteredList, comboBoxArchiveProfile.SelectedItem, comboBoxArchiveCity.SelectedItem, comboBoxArchiveDealer.SelectedItem, comboBoxArchiveColour.SelectedItem, comboBoxArchiveUser.SelectedItem);
                    dataGridViewLogs.Rows.Clear();
                    this.FillGridViewArchive(filteredList, dataGridViewLogs);
                }
            }
            textBoxIDColourGoods.Text = "";
        }

        private void ButtonResetArchiveFilter_Click(object sender, EventArgs e)
        {
            comboBoxArchiveProfile.Enabled = true;
            comboBoxArchiveCity.Enabled = true;
            comboBoxArchiveDealer.Enabled = false;
            comboBoxArchiveColour.Enabled = true;
            comboBoxArchiveUser.Enabled = true;
            checkBoxWithOperation.Checked = false;
            this.CleareAllComponentArchiveTab();
            this.FillAllComponentArciveTab();
        }

        private void TextBoxIDColourGoods_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        private void TextBoxIDColourGoods_TextChanged(object sender, EventArgs e)
        {
            if (textBoxIDColourGoods.Text != "")
            {
                comboBoxArchiveProfile.Enabled = false;
                comboBoxArchiveCity.Enabled = false;
                comboBoxArchiveDealer.Enabled = false;
                comboBoxArchiveColour.Enabled = false;
                comboBoxArchiveUser.Enabled = false;
            }
            else
            {
                comboBoxArchiveProfile.Enabled = true;
                comboBoxArchiveCity.Enabled = true;
                comboBoxArchiveDealer.Enabled = false;
                comboBoxArchiveColour.Enabled = true;
                comboBoxArchiveUser.Enabled = true;
            }
        }
        #endregion

        private void ButtonRemoveColourGoods_Click(object sender, EventArgs e)
        {
            var currentcell = dataGridViewTehnologes.CurrentCellAddress;
            if (Role == "Ламінація")
            {
                int id = (int)dataGridViewTehnologes.Rows[currentcell.Y].Cells[0].Value;
                ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
                string messageToRemove = "Дійсно ВИДАТИТИ замовлення?";
                string caption = "Видалити інформацію з бази данних!";
                DialogResult result = MessageBox.Show(messageToRemove, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (colourGoodsDTO.RemoveGolourGoods(id))
                    {
                        MessageBox.Show("Зміни збережені до бази даних!");
                        CleareAllComponentManagersTab();
                        FillAllComponentManagersTab();
                    }
                    else
                    {
                        MessageBox.Show("Зміни не збережено до бази даних!");
                    }
                }
                else
                {
                    MessageBox.Show("Ви відмінили видалення!");
                }
            }
        }
    }
}

