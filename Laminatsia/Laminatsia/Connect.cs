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
        public Connect()
        {
            InitializeComponent();
        }

        private void buttonTestConnectingToServer_Click(object sender, EventArgs e)
        {
            //private void GetAllServersSQL()
            //{
            //    DataTable dataTable = SmoApplication.EnumAvailableSqlServers(false);
            //    comboBoxListServer.ValueMember = "Name"; 
            //    comboBoxListServer.DataSource = dataTable;

            //}
            //private void comboBoxListServer_SelectedIndexChanged(object sender, EventArgs e)
            //{
            //    comboBoxListDataBase.Items.Clear();
            //    if (comboBoxListServer.SelectedIndex != -1)
            //    {
            //        string serverName = comboBoxListServer.SelectedValue.ToString();
            //        Server server = new Server("192.168.0.4");
            //        foreach (Database db in server.Databases)
            //        {
            //            comboBoxListDataBase.Items.Add(db.Name);
            //        }
            //    }
            //}
        }
    }
}
