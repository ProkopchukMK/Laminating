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
        private DealerDTO dealerDTO = new DealerDTO();
        private ColourDTO colourDTO = new ColourDTO();
        private ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO();
        private ProfileDTO profileDTO = new ProfileDTO();
        private UsersDTO users = new UsersDTO();

        private List<DateTime> listDateComing = new List<DateTime>();
        private List<string> listProfile = new List<string>();
        private List<string> listCity = new List<string>();
        private List<string> listDealer = new List<string>();
        private List<string> listColour = new List<string>();
        private List<DateTime> listDateToWork = new List<DateTime>();
        private List<string> listStatusProfile = new List<string>();
        private List<DateTime> listDateReady = new List<DateTime>();
        private List<string> listStatusGoods = new List<string>();

        private void LaminatsiaForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'laminatsiaDataSet.ColourGoods' table. You can move, or remove it, as needed.
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.Bounds.Size;
        }
        public LaminatsiaForm()
        {
            InitializeComponent();
            FillAlComponent();
            dataGridViewManagers.DataSource = colourGoodsDTO.GetListColourGoods();
        }
        private void FillAlComponent()
        {
            listProfile = profileDTO.GetListProfile();
            listColour = colourDTO.GetListColour();
            listCity = dealerDTO.GetListCity();
            //заповнення ламінації комбобоксів
            ComboBoxProfile.Items.AddRange(listProfile.ToArray());
            //comboBoxDealer.Items.AddRange(dealerDTO.GetListDealer().ToArray());                   заповнюється відповідно до вибраного міста
            ComboBoxDealer.Enabled = false;
            ComboBoxCity.Items.AddRange(listCity.ToArray());
            comboBoxColour.Items.AddRange(listColour.ToArray());
            comboBoxStatusProfile.Items.AddRange(new object[] { "ГОТОВИЙ", "НЕ ГОТОВИЙ" });
            comboBoxStatusGoods.Items.AddRange(new object[] { "В РОБОТІ", "НЕ В РОБОТІ" });
            //заповнення додати\видалити комбобоксів
            сomboxAddCity.Items.AddRange(listCity.ToArray());
            comboBoxRemoveCity.Items.AddRange(listCity.ToArray());
            //comboBoxRemoveDealer.Items.AddRange(dealerDTO.GetListDealer().ToArray());              заповнюється відповідно до вибраного міста
            comboBoxRemoveDealer.Enabled = false;
            comboBoxRemoveProfile.Items.AddRange(listProfile.ToArray());
            comboBoxRemoveColour.Items.AddRange(listColour.ToArray());

        }
        private void CleareAllComponent()
        {
            //очищення вкладки ламінація(додати нове замовлення)
            dateTimePickerDateComing.Value = DateTime.Now;
            ComboBoxProfile.Items.Clear();
            ComboBoxCity.Items.Clear();
            ComboBoxDealer.Items.Clear();
            textBoxNotes.Text = "";
            textBoxCounts.Text = "";
            comboBoxColour.Items.Clear();
            dateTimePickerDateToWork.Value = DateTime.Now;
            comboBoxStatusProfile.Items.Clear();
            dateTimePickerDateReady.Value = DateTime.Now;
            comboBoxStatusGoods.Items.Clear();

            //очищення вкладки додати\видалити(додати нове знчення)
            сomboxAddCity.Items.Clear();
            textBoxAddDealer.Text = "";
            textBoxAddProfile.Text = "";
            textBoxAddColour.Text = "";

            comboBoxRemoveCity.Items.Clear();
            comboBoxRemoveDealer.Items.Clear();
            comboBoxRemoveProfile.Items.Clear();
            comboBoxRemoveColour.Items.Clear();
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
            if (addDealer != "")
            {
                DealerDTO newDealer = new DealerDTO();
                string message = newDealer.AddDealer(сomboxAddCity.SelectedItem.ToString(), addDealer);
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Дилера!");
            }
            this.CleareAllComponent();
            this.FillAlComponent();
        }
        //додати новий профіль до бази даних
        private void Add_NewProfile_Click(object sender, EventArgs e)
        {
            if (textBoxAddProfile.Text.Trim() != "")
            {
                ProfileDTO newProfile = new ProfileDTO();
                string message = newProfile.AddProfile(textBoxAddProfile.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Профіля!");
            }
            this.CleareAllComponent();
            this.FillAlComponent();
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
            this.CleareAllComponent();
            this.FillAlComponent();
        }

        #region Видалення інформації з бази данних
        private void ComboBoxRemoveCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRemoveDealer.Items.Clear();
            DealerDTO dealerDTO = new DealerDTO();
            string removeCityName = comboBoxRemoveCity.SelectedItem.ToString();
            var listDealerByCity = dealerDTO.GetListDealerByCity(removeCityName).ToArray();
            comboBoxRemoveDealer.Enabled = true;
            comboBoxRemoveDealer.Items.AddRange(listDealerByCity);
        }
        private void ButtonRemoveDealer_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveCity.SelectedItem != null)
            {
                if (comboBoxRemoveDealer.SelectedItem != null)
                {
                    string messageToRemove = "Дійсно видалити Дилера " + comboBoxRemoveCity.SelectedItem.ToString() + " - " + comboBoxRemoveDealer.SelectedItem.ToString() + " ?";
                    string caption = "Видалення з бази данних!";
                    DialogResult result = MessageBox.Show(messageToRemove, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DealerDTO newDealer = new DealerDTO();
                        string message = newDealer.RemoveDealer(comboBoxRemoveCity.SelectedItem.ToString(), comboBoxRemoveDealer.SelectedItem.ToString());
                        MessageBox.Show(message);
                        this.CleareAllComponent();
                        this.FillAlComponent();
                        comboBoxRemoveDealer.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Ви відмінили операцію видалення!");
                    }
                    this.CleareAllComponent();
                    this.FillAlComponent();
                }
                else
                {
                    MessageBox.Show("Потрібно вибрати Дилера!");
                }
            }
            else
            {
                MessageBox.Show("Потрібно вибрати Місто!");
                this.CleareAllComponent();
                this.FillAlComponent();
            }
        }
        private void ButtonRemoveProfile_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveProfile.SelectedItem.ToString() != null)
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
                    this.CleareAllComponent();
                    this.FillAlComponent();
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
            this.CleareAllComponent();
            this.FillAlComponent();
        }
        private void ButtonRemoveColour_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveColour.SelectedItem.ToString() != null)
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
                    this.CleareAllComponent();
                    this.FillAlComponent();
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
            this.CleareAllComponent();
            this.FillAlComponent();
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
                            if (comboBoxColour.SelectedItem != null)
                            {
                                if (comboBoxStatusProfile.SelectedItem != null)
                                {
                                    DateTime dateComing = dateTimePickerDateComing.Value;
                                    string profile = ComboBoxProfile.SelectedItem.ToString();
                                    string city = ComboBoxCity.SelectedItem.ToString();
                                    string dealer = ComboBoxDealer.SelectedItem.ToString();
                                    string notes = textBoxNotes.Text;
                                    byte counts = Byte.Parse(textBoxCounts.Text.TrimStart(new Char[] { '0' }));
                                    string colour = comboBoxColour.SelectedItem.ToString();
                                    DateTime dateToWork = dateTimePickerDateToWork.Value;
                                    // перевадимо в булеве значення
                                    bool statusProfile = false;
                                    if (comboBoxStatusProfile.SelectedIndex == 0)
                                    {
                                        statusProfile = true;
                                    }
                                    DateTime dateReady = dateTimePickerDateReady.Value;
                                    ColourGoodsDTO colourGoods = new ColourGoodsDTO();
                                    string message = colourGoods.AddColourGoods(dateComing, profile, city, dealer, notes, counts, colour, dateToWork, statusProfile, dateReady);
                                    MessageBox.Show(message);
                                    this.CleareAllComponent();
                                    this.FillAlComponent();
                                }
                                else
                                {
                                    MessageBox.Show("Ви не вказали Статус профілю!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ви не вказали Колір профілю!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ви не вказали Кількість виробів!!");
                            textBoxCounts.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ви не вказали Дилера!");
                    }
                }
                else
                {
                    MessageBox.Show("Ви не вказали Місто!");
                }
            }
            else
            {
                MessageBox.Show("Ви не вказали профіль!");
            }

        }

        //введення кількості конструкцій
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

        #endregion
    }
}
