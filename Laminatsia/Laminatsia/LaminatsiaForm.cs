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
        private CityDTO cityDTO = new CityDTO();
        public LaminatsiaForm()
        {
            InitializeComponent();
            comboBoxStatusProfile.Items.Add("ГОТОВИЙ");
            comboBoxStatusProfile.Items.Add("НЕ ГОТОВИЙ");

            comboBoxStatusGoods.Items.Add("В РОБОТІ");
            comboBoxStatusGoods.Items.Add("НЕ В РОБОТІ");
            var listCity = cityDTO.GetListCity().ToArray();
            comboBoxCity.Items.AddRange(listCity);
            comboxCityDealer.Items.AddRange(listCity);
            comboBoxColour.Items.AddRange(ColourDTO.GetListColour().ToArray());
            comboBoxDealer.Items.AddRange(DealerDTO.GetListDealer().ToArray());
            comboBoxProfile.Items.AddRange(ProfileDTO.GetListProfile().ToArray());
        }
        //очиста текстбоксов
        private void Clear()
        {
            textBoxCity.Text = "";
            textBoxDealer.Text = "";
            textBoxColour.Text = "";
            textBoxProfile.Text = "";
        }
        private void LaminatsiaForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;
        }
        //потрібно ввести спочатку місто а потім і
        private void comboxCityDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDealer.Enabled = true;
        }
        #region   ВКЛАДКА   Додати
        //додати нове місто до бази даних
        private void Add_NewCity_Click(object sender, EventArgs e)
        {
            string messageCity;
            if (textBoxCity.Text.Trim() != "")
            {
                CityDTO newCity = new CityDTO();
                messageCity = newCity.AddCity(textBoxCity.Text.Trim());
                comboxCityDealer.Items.Clear();
                comboBoxCity.Items.Clear();
                comboxCityDealer.Items.AddRange(newCity.GetListCity().ToArray());
                comboBoxCity.Items.AddRange(newCity.GetListCity().ToArray());
                MessageBox.Show(messageCity);
            }
            else
            {
                textBoxCity.Text = "";
                MessageBox.Show("Потрібно написати назву міста!");
            }
            this.Clear();
        }
        //додати нового диллера до бази даних
        private void Add_NewDealer_Click(object sender, EventArgs e)
        {
            string message;
            if (textBoxDealer.Text.Trim() != "")
            {
                DealerDTO newCity = new DealerDTO();
                message = newCity.AddDealer(comboxCityDealer.SelectedItem.ToString(), textBoxDealer.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Дилера!");
            }
            this.Clear();
        }
        //додати новий профіль до бази даних
        private void Add_NewProfile_Click(object sender, EventArgs e)
        {
            string message;
            if (textBoxProfile.Text.Trim() != "")
            {
                ProfileDTO newProfile = new ProfileDTO();
                message = newProfile.AddProfile(textBoxProfile.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Профіля!");
            }
            this.Clear();
        }
        //додати новий колір до бази даних
        private void Add_NewColour_Click(object sender, EventArgs e)
        {
            string message;
            if (textBoxColour.Text.Trim() != "")
            {
                ColourDTO newColour = new ColourDTO();
                message = newColour.AddColour(textBoxColour.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Кольору!");
            }
            this.Clear();
        }
        #endregion

        #region   ВКЛАДКА   Ламінація
        //додати нове замовлення до бази даних
        private void SaveColourGoods_Click(object sender, EventArgs e)
        {
            DateTime dateComing = dateTimePickerDateComing.Value;
            string profile = comboBoxProfile.SelectedItem.ToString();
            string city = comboBoxCity.SelectedItem.ToString();
            string dealer = comboBoxDealer.SelectedItem.ToString();
            string notes = textBoxNotes.Text;
            byte counts =  Byte.Parse(textBoxCounts.Text.TrimStart(new Char[] { '0' }));
            string colour = comboBoxColour.SelectedItem.ToString();
            DateTime dateToWork = dateTimePickerDateToWork.Value;
            // потрібно перевести в булеве значення
            string statusProfile = comboBoxStatusProfile.SelectedItem.ToString();
            DateTime dateReady = dateTimePickerDateReady.Value;
        }

        //введення кількості конструкцій
        private void textBoxCounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        //фільтрування диллерів по місту
        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDealer.Items.Clear();
            DealerDTO dealerDTO = new DealerDTO();
            string cityName = comboBoxCity.SelectedItem.ToString();
            var listDealer = dealerDTO.GetListDealerByCity(cityName).ToArray();
            if (listDealer.Length == 0)
            {
                comboBoxDealer.Enabled = false;
                comboBoxDealer.Items.Add("Відсутні дилери");
                comboBoxDealer.SelectedIndex = 0;
            }
            else
            {
                comboBoxDealer.Enabled = true;
                comboBoxDealer.Items.AddRange(listDealer);
            }
        }
        #endregion
        
    }
}
