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
            string message;
            if (textBoxCity.Text.Trim() != "")
            {
                CityDTO newCity = new CityDTO();
                message = newCity.AddCity(textBoxCity.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                textBoxCity.Text = "";
                MessageBox.Show("Потрібно написати назву міста!");
            }
        }

        private void Add_NewDealer_Click(object sender, EventArgs e)
        {
            string message;
            if (textBoxDealer.Text.Trim() != "")
            {
                CityDTO newCity = new CityDTO();
                message = newCity.AddCity(textBoxDealer.Text.Trim());
                MessageBox.Show(message);
            }
            else
            {
                textBoxDealer.Text = "";
                MessageBox.Show("Потрібно написати назву Дилера!");
            }
        }
    }
}
