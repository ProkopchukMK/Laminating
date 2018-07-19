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

            comboBoxCity.Items.AddRange(cityDTO.GetListCity().ToArray());
            comboBoxColour.Items.AddRange(ColourDTO.GetListColour().ToArray());
            comboBoxDealer.Items.AddRange(DealerDTO.GetListDealer().ToArray());
            comboBoxProfile.Items.AddRange(ProfileDTO.GetListProfile().ToArray());
            ComboxCityDealer.Items.AddRange(cityDTO.GetListCity().ToArray());

        }
        //очиста текстбоксов
        private void Clear()
        {
            textBoxCity.Text = "";
            textBoxDealer.Text = "";
            textBoxColour.Text = "";
            textBoxProfile.Text = "";
        }
        private void FillUpdateComponent()
        {
            //this.Clear();
            //comboBoxCity.Items.AddRange(CityDTO.GetListCity().ToArray());
            //comboBoxColour.Items.AddRange(ColourDTO.GetListColour().ToArray());
            
            //comboBoxProfile.Items.AddRange(ProfileDTO.GetListProfile().ToArray());
            //ComboxCityDealer.Items.Clear();
            //ComboxCityDealer.DataSource = CityDTO.GetListCity();
        }

        private void LaminatsiaForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Add_NewCity_Click(object sender, EventArgs e)
        {
            string messageCity;
            if (textBoxCity.Text.Trim() != "")
            {
                CityDTO newCity = new CityDTO();
                messageCity = newCity.AddCity(textBoxCity.Text.Trim());
                ComboxCityDealer.Items.Clear();
                ComboxCityDealer.Items.AddRange(newCity.GetListCity().ToArray());
                MessageBox.Show(messageCity);
            }
            else
            {
                textBoxCity.Text = "";
                MessageBox.Show("Потрібно написати назву міста!");
            }
            this.Clear();
        }

        private void Add_NewDealer_Click(object sender, EventArgs e)
        {            
            string message;
            if (textBoxDealer.Text.Trim() != "")
            {
                DealerDTO newCity = new DealerDTO();
                message = newCity.AddDealer(ComboxCityDealer.SelectedItem.ToString(), textBoxDealer.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Потрібно написати назву Дилера!");
            }
            this.Clear();
        }      

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

        private void textBoxCounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if(!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void SaveColourGoods_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboxCityDealer.Items.Clear();
            DealerDTO dealerDTO = new DealerDTO();
            comboBoxDealer.DataSource = dealerDTO.GetListDealerByCity(comboBoxCity.SelectedItem.ToString());            
            //this.FillUpdateComponent();
        }
    }
}
