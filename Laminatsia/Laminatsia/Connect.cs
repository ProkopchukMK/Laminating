using Microsoft.SqlServer.Management.Smo;
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
    public partial class Connect : Form
    {
        /// <summary>
        /// 1. Створити обмежженя для введення адреси
        /// 2. Виключити пусті значення
        /// 3. Витягти скріпт з бази та додати на обробочик кнопки Створити
        /// </summary>
        public Connect()
        {
            InitializeComponent();
        }

        private void ButtonTestConnectingToServer_Click(object sender, EventArgs e)
        {

        }

        private void TabControlConnect_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControlConnect.SelectedTab == tabPageIP)
                {

                }
                else if (tabControlConnect.SelectedTab == tabPageFromList)
                {
                    //потрібно закешувати данні
                    //DataTable dataTable = SmoApplication.EnumAvailableSqlServers(false);
                    //comboBoxListServerName.ValueMember = "Name";
                    //comboBoxListServerName.DataSource = dataTable;
                }
                else if (tabControlConnect.SelectedTab == tabPageCreateDataBase)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка TabControlConnect_TabIndexChanged! Детальніше: " + ex.Message);
            }
        }

        private void ComboBoxListDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxListDataBase.Items.Clear();
            //if (comboBoxListDataBase.SelectedIndex != -1)
            //{
            //    string serverName = comboBoxListDataBase.SelectedValue.ToString();
            //    Server server = new Server("192.168.0.4");
            //    foreach (Database db in server.Databases)
            //    {
            //        comboBoxListDataBase.Items.Add(db.Name);
            //    }
            //}
        }
    }
}
