using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;

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
        private void tabControlConnect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //    if (tabControlConnect.SelectedTab == tabPageIP)
                //    {

                //    }
                //    else 
                if (tabControlConnect.SelectedTab == tabPageFromList)
                {
                    //потрібно закешувати данні
                    //DataTable dataTable = SmoApplication.EnumAvailableSqlServers(true); // поставати false для мережевих серверів
                    //comboBoxListServerName.ValueMember = "Name";
                    //comboBoxListServerName.DataSource = dataTable;
                }
                //else if (tabControlConnect.SelectedTab == tabPageCreateDataBase)
                //{

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка TabControlConnect_TabIndexChanged! Детальніше: " + ex.Message);
            }
        }



        #region По ІР адресу

        private void comboBoxLilstDbIPServer_Click(object sender, EventArgs e)
        {
            comboBoxLilstDbIPServer.Items.Clear();
            if (true)
            {
                string serverName = maskedTextBoxIPServer.Text;
                //Server server = new Server(serverName);
                Server server = new Server(@"DESKTOP-0GHRJOV\SQLEXPRESS");
                foreach (Database db in server.Databases)
                {
                    comboBoxLilstDbIPServer.Items.Add(db.Name);
                }
                maskedTextBoxIPServer.Enabled = false;
            }
        }
        #endregion

        #region Вибрати із списку
        private void comboBoxListServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxListDataBase.Items.Clear();
            if (comboBoxListServerName.SelectedIndex != -1)
            {
                comboBoxListDataBase.Enabled = true;
                string serverName = comboBoxListServerName.SelectedValue.ToString();
                Server server = new Server(serverName);
                foreach (Database db in server.Databases)
                {
                    comboBoxListDataBase.Items.Add(db.Name);
                }
            }
        }
        private void comboBoxListServerName_Click(object sender, EventArgs e)
        {
            progressBarConnectToDB.Visible = true;
            DataTable dataTable = SmoApplication.EnumAvailableSqlServers(true); // поставати false для мережевих серверів
            comboBoxListServerName.ValueMember = "Name";
            comboBoxListServerName.DataSource = dataTable;
        }
        private void buttonConnectToServerName_Click(object sender, EventArgs e)
        {

        }
        private void buttonSaveConfogServerName_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Створити базу даних

        #endregion

        private void maskedTextBoxIPServer_Leave(object sender, EventArgs e)
        {
            IPAddress ipAddress;
            if (IPAddress.TryParse(maskedTextBoxIPServer.Text, out ipAddress))
            {
                MessageBox.Show(maskedTextBoxIPServer.Text.Trim());
            }
            else
            {
                MessageBox.Show("Сталася помилка TabControlConnect_TabIndexChanged! Детальніше: ");
            }
        }
    }
}
