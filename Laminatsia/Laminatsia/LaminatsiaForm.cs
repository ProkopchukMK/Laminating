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


        public LaminatsiaForm()
        {
            InitializeComponent();
            FillAlComponent();
        }
        private void FillAlComponent()
        {
            comboBoxStatusProfile.Items.AddRange(new object[] { "ГОТОВИЙ", "НЕ ГОТОВИЙ" });
            comboBoxStatusGoods.Items.AddRange(new object[] { "В РОБОТІ", "НЕ В РОБОТІ" });
            listCity = cityDTO.GetListCity();
            listProfile = profileDTO.GetListProfile();
            listColour = colourDTO.GetListColour();

            comboBoxCity.Items.AddRange(listCity.ToArray());
            comboxCityDealer.Items.AddRange(listCity.ToArray());
            comboBoxRemoveCity.Items.AddRange(listCity.ToArray());
            comboBoxRemoveCityDealer.Items.AddRange(listCity.ToArray());


            comboBoxColour.Items.AddRange(listColour.ToArray());
            comboBoxRemoveColour.Items.AddRange(listColour.ToArray());
            comboBoxDealer.Items.AddRange(dealerDTO.GetListDealer().ToArray());
            comboBoxProfile.Items.AddRange(listProfile.ToArray());
            comboBoxRemoveProfile.Items.AddRange(listProfile.ToArray());
        }
        private void CleareAllComponent()
        {
            dateTimePickerDateComing.Value = DateTime.Now;
            comboBoxProfile.Items.Clear();
            comboBoxCity.Items.Clear();
            comboxCityDealer.Items.Clear();
            textBoxNotes.Text = "";
            textBoxCounts.Text = "";
            comboBoxColour.Items.Clear();
            dateTimePickerDateToWork.Value = DateTime.Now;
            comboBoxDealer.Items.Clear();
            comboBoxStatusProfile.Items.Clear();
            dateTimePickerDateReady.Value = DateTime.Now;
            comboBoxStatusGoods.Items.Clear();
            textBoxCity.Text = "";
            textBoxDealer.Text = "";
            textBoxColour.Text = "";
            textBoxProfile.Text = "";
            comboBoxRemoveCity.Items.Clear();
            comboBoxRemoveCityDealer.Items.Clear();
            comboBoxRemoveDealer.Items.Clear();
            comboBoxRemoveProfile.Items.Clear();
            comboBoxRemoveColour.Items.Clear();


        }
        private void LaminatsiaForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;
        }
        //потрібно ввести спочатку місто а потім і
        private void comboxCityDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDealer.Enabled = true;
        }
        #region   ВКЛАДКА   Додати\Видалити        
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
                MessageBox.Show(messageCity);
                comboxCityDealer.Items.AddRange(newCity.GetListCity().ToArray());
                comboBoxCity.Items.AddRange(newCity.GetListCity().ToArray());

            }
            else
            {
                textBoxCity.Text = "";
                MessageBox.Show("Потрібно написати назву міста!");
            }
            this.CleareAllComponent();
        }
        //додати нового диллера до бази даних
        private void Add_NewDealer_Click(object sender, EventArgs e)
        {
            string message;
            if (textBoxDealer.Text.Trim() != "")
            {
                DealerDTO newDealer = new DealerDTO();
                message = newDealer.AddDealer(comboxCityDealer.SelectedItem.ToString(), textBoxDealer.Text.Trim());
                MessageBox.Show(message);
                this.CleareAllComponent();
                this.FillAlComponent();
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Дилера!");
            }
            this.CleareAllComponent();
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
            this.CleareAllComponent();
            this.FillAlComponent();
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
            this.CleareAllComponent();
        }

        #region Видалення інформації з бази данних
        private void buttonRemoveDealer_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveCityDealer.SelectedItem != null)
            {
                if (comboBoxRemoveDealer.SelectedItem != null && comboBoxRemoveDealer.SelectedItem.ToString() != "Відсутні дилери")
                {
                    DealerDTO newDealer = new DealerDTO();
                    string messageToRemove = "Дійсно видалити Дилера " + comboBoxRemoveCityDealer.SelectedItem.ToString() + " - " + comboBoxRemoveDealer.SelectedItem.ToString() + " ?";
                    string caption = "Видалення з бази данних!";
                    DialogResult result = MessageBox.Show(messageToRemove, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string message = newDealer.RemoveDealer(comboBoxRemoveCityDealer.SelectedItem.ToString(), comboBoxRemoveDealer.SelectedItem.ToString());
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
                    this.CleareAllComponent();
                    this.FillAlComponent();
                }
            }
            else
            {
                MessageBox.Show("Потрібно вибрати Місто!");
                this.CleareAllComponent();
                this.FillAlComponent();
            }
        }
        private void comboBoxRemoveCityDealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRemoveDealer.Items.Clear();
            DealerDTO dealerDTO = new DealerDTO();
            string removeCityName = comboBoxRemoveCityDealer.SelectedItem.ToString();
            var listDealerByCity = dealerDTO.GetListDealerByCity(removeCityName).ToArray();
            if (listDealerByCity.Length == 0)
            {
                comboBoxRemoveDealer.Enabled = false;
                comboBoxRemoveDealer.Items.Add("Відсутні дилери");
                comboBoxRemoveDealer.SelectedIndex = 0;
            }
            else
            {
                comboBoxRemoveDealer.Enabled = true;
                comboBoxRemoveDealer.Items.AddRange(listDealerByCity);
            }
        }
        private void buttonRemoveCity_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveCity.SelectedItem != null)
            {
                var listDealerByCity = dealerDTO.GetListDealerByCity(comboBoxRemoveCity.SelectedItem.ToString());
                if (listDealerByCity.Count == 0)
                {
                    CityDTO removeCity = new CityDTO();
                    string messageToRemove = "Дійсно видалити місто " + comboBoxRemoveCity.SelectedItem.ToString() + " ?";
                    string caption = "Видалення з бази данних!";
                    DialogResult result = MessageBox.Show(messageToRemove, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string message = removeCity.RemoveCity(comboBoxRemoveCity.SelectedItem.ToString());
                        MessageBox.Show(message);
                        this.CleareAllComponent();
                        this.FillAlComponent();
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
                    MessageBox.Show("Потрібно видалити всіх Дилерів цього міста!");
                    this.CleareAllComponent();
                    this.FillAlComponent();
                }
            }
            else
            {
                MessageBox.Show("Потрібно вибрати Місто!");
            }
        }
        private void buttonRemoveProfile_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveProfile.SelectedItem.ToString() != null)
            {
                ProfileDTO removeProfile = new ProfileDTO();
                string messageToRemove = "Дійсно видалити профіль " + comboBoxRemoveProfile.SelectedItem.ToString() + " ?";
                string caption = "Видалення з бази данних!";
                DialogResult result = MessageBox.Show(messageToRemove, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
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
        private void buttonRemoveColour_Click(object sender, EventArgs e)
        {
            if (comboBoxRemoveColour.SelectedItem.ToString() != null)
            {
                ColourDTO removeColour = new ColourDTO();
                string messageToRemove = "Дійсно видалити колір " + comboBoxRemoveColour.SelectedItem.ToString() + " ?";
                string caption = "Видалення з бази данних!";
                DialogResult result = MessageBox.Show(messageToRemove, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
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
            DateTime dateComing = dateTimePickerDateComing.Value;
            string profile = comboBoxProfile.SelectedItem.ToString();
            string city = comboBoxCity.SelectedItem.ToString();
            string dealer = comboBoxDealer.SelectedItem.ToString();
            string notes = textBoxNotes.Text;
            byte counts = Byte.Parse(textBoxCounts.Text.TrimStart(new Char[] { '0' }));
            string colour = comboBoxColour.SelectedItem.ToString();
            DateTime dateToWork = dateTimePickerDateToWork.Value;
            // потрібно перевести в булеве значення
            bool statusProfile = false;
            if (comboBoxStatusProfile.SelectedIndex == 0)
            {
                statusProfile = true;
            }
            else if (comboBoxStatusProfile.SelectedIndex == 1)
            {
                statusProfile = false;
            }
            DateTime dateReady = dateTimePickerDateReady.Value;

            ColourGoodsDTO colourGoods = new ColourGoodsDTO();

            colourGoods.AddColourGoods(dateComing, profile, city, dealer, notes, counts, colour, dateToWork, statusProfile, dateReady);
            this.CleareAllComponent();
            this.FillAlComponent();
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
            var listDealerByCity = dealerDTO.GetListDealerByCity(cityName).ToArray();
            if (listDealerByCity.Length == 0)
            {
                comboBoxDealer.Enabled = false;
                comboBoxDealer.Items.Add("Відсутні дилери");
                comboBoxDealer.SelectedIndex = 0;
            }
            else
            {
                comboBoxDealer.Enabled = true;
                comboBoxDealer.Items.AddRange(listDealerByCity);
            }
        }




        #endregion


    }
}
