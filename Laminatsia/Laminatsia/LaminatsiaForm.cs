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
        public LaminatsiaForm()
        {
            InitializeComponent();
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
                message = newCity.AddDealer(textBoxDealer.Text.Trim());
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

        //очиста текстбоксов
        private void Clear()
        {
            textBoxCity.Text = "";
            textBoxDealer.Text = "";
            textBoxColour.Text = "";
            textBoxProfile.Text = "";
        }
    }
}
