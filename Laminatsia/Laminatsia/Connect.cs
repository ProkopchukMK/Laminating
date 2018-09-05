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
using System.Net.NetworkInformation;
using System.Data.SqlClient;

namespace Laminatsia
{
    public partial class Connect : Form
    {
        /// <summary>
        /// 1. 
        /// 2. Виключити пусті значення
        /// </summary>
        public Connect()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private IPAddress ipAddress;
        private Server server;
        private void CleareAllComponent()
        {
            maskedTextBoxIPServer.Text = "";
            comboBoxLilstDbIPServer.Items.Clear();
            comboBoxListServerName.Items.Clear();
            comboBoxListDataBase.Items.Clear();
            maskedTextBoxIpServerCreateDB.Text = "";
        }
        private void TabControlConnect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControlConnect.SelectedTab == tabPageIP)
                {
                    maskedTextBoxIPServer.Text = "";
                    maskedTextBoxIPServer.Enabled = true;
                    comboBoxLilstDbIPServer.Items.Clear();
                    buttonConnectToIPServer.Enabled = false;
                    buttonSaveConfig.Enabled = false;
                }
                else if (tabControlConnect.SelectedTab == tabPageFromList)
                {
                    comboBoxListServerName.Items.Clear();
                    comboBoxListDataBase.Items.Clear();
                    buttonConnectToServerName.Enabled = false;
                    buttonSaveConfogServerName.Enabled = false;
                    comboBoxListDataBase.Enabled = false;

                }
                else if (tabControlConnect.SelectedTab == tabPageCreateDataBase)
                {

                    maskedTextBoxIpServerCreateDB.Text = "";
                    buttonCreateDB.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка TabControlConnect_TabIndexChanged! Детальніше: " + ex.Message);
            }
        }

        public static bool IsConnectedToServer(string ServerAddress)
        {
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(ServerAddress, 5000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Сервер недоступний по даній адресі! " + ex.Message);
                return false;
            }
            return false;
        }
        #region По ІР адресу
        private void ButtonTestConnectingToServer_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress;
            if (IPAddress.TryParse(maskedTextBoxIPServer.Text.Trim(), out ipAddress))
            {
                if (IsConnectedToServer(maskedTextBoxIPServer.Text.Trim()))
                {
                    server = new Server(maskedTextBoxIPServer.Text.Trim());
                    foreach (Database db in server.Databases)
                    {
                        comboBoxLilstDbIPServer.Items.Add(db.Name);
                    }
                    maskedTextBoxIPServer.Enabled = false;
                    comboBoxLilstDbIPServer.Enabled = true;
                    MessageBox.Show("Тест пройшов успішно! Тепер Ви можете вибрати базу даних зі списку!");
                    comboBoxLilstDbIPServer.DroppedDown = true;
                }
                else
                {
                    MessageBox.Show("Не підключається до сервера!");
                }
            }
            else
            {
                MessageBox.Show("Помилкова адреса!");
            }
        }
        private void ButtonConnectToIPServer_Click(object sender, EventArgs e)
        {
            if (comboBoxLilstDbIPServer.SelectedIndex != -1)
            {
                string database = comboBoxLilstDbIPServer.SelectedItem.ToString();
                string connection = "Data Source=" + server.Name + ";Initial Catalog=" + database + ";Integrated Security=SSPI;";
                using (SqlConnection sql = new SqlConnection(connection))
                {
                    try
                    {
                        string writeToDB = @"INSERT INTO Users (UserName, UserPassword, Role) values('Test', 'Test','Адміністратори')";
                        string updateDB = @"DELETE FROM Users WHERE UserName='Test'";
                        sql.Open();
                        SqlCommand sqlCreateUser = new SqlCommand(writeToDB, sql);
                        sqlCreateUser.ExecuteNonQuery();
                        SqlCommand sqlDeleteUser = new SqlCommand(updateDB, sql);
                        sqlDeleteUser.ExecuteNonQuery();
                        sql.Close();
                        MessageBox.Show("Запис та видалення даних пройшли успішно!");

                        buttonSaveConfig.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Сталася помилка! Детальніше: " + ex.Message);

                        buttonSaveConfig.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Виберіть базу даних!");
            }

        }
        private void ButtonSaveConfig_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Вибрати із списку
        //прогрес бар 
        private List<string> listServer;
        private List<string> listDatabases = new List<string>();
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetAllServers();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            GetAllDatabases();
        }
        private void GetAllServers()
        {
           var listServer = SmoApplication.EnumAvailableSqlServers(false).Columns[0]; // поставати false для мережевих серверів
        }
        private void GetAllDatabases()
        {
            try
            {
                foreach (Database db in server.Databases)
                {
                    listDatabases.Add(db.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка! Детальніше: " + ex.Message);
            }
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarConnectToDB.Visible = false;
            comboBoxListServerName.Enabled = true;
            comboBoxListServerName.ValueMember = "Name";
            //comboBoxListServerName.DataSource = dataTable;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarConnectToDB.Visible = false;
            comboBoxListServerName.Enabled = true;
            comboBoxListDataBase.Items.Clear();
            comboBoxListDataBase.Items.AddRange(listDatabases.ToArray());
        }
        private void ComboBoxListServerName_Click(object sender, EventArgs e)
        {
            progressBarConnectToDB.Visible = true;
            buttonSaveConfogServerName.Enabled = false;
            buttonConnectToServerName.Enabled = false;
            comboBoxListDataBase.Items.Clear();

            if (comboBoxListServerName.Items.Count == 0)
            {
                backgroundWorker.RunWorkerAsync();
                comboBoxListServerName.Enabled = false;
            }
            else { progressBarConnectToDB.Visible = false; }

        }

        private void comboBoxListServerName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                listDatabases.Clear();
                if (comboBoxListServerName.SelectedIndex != -1)
                {
                    comboBoxListDataBase.Enabled = false;
                    comboBoxListServerName.Enabled = false;
                    string serverName = comboBoxListServerName.SelectedValue.ToString();
                    server = new Server(serverName);
                    backgroundWorker1.RunWorkerAsync();
                    progressBarConnectToDB.Visible = true;
                    buttonSaveConfogServerName.Enabled = false;
                    buttonConnectToServerName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка! Детальніше: " + ex.Message);
            }
        }
        private void ButtonConnectToServerName_Click(object sender, EventArgs e)
        {
            if (comboBoxListServerName.SelectedIndex != -1 && comboBoxListDataBase.SelectedIndex != -1)
            {
                string database = comboBoxListDataBase.SelectedItem.ToString();
                string conn = "Data Source=" + server.Name + ";Initial Catalog=" + database + ";Integrated Security=SSPI;";
                using (SqlConnection sql = new SqlConnection(conn))
                {
                    try
                    {
                        string writeToDB = @"INSERT INTO Users (UserName, UserPassword, Role) values('Test', 'Test','Адміністратори')";
                        string updateDB = @"DELETE FROM Users WHERE UserName='Test'";
                        sql.Open();
                        SqlCommand sqlCreateUser = new SqlCommand(writeToDB, sql);
                        sqlCreateUser.ExecuteNonQuery();
                        SqlCommand sqlDeleteUser = new SqlCommand(updateDB, sql);
                        sqlDeleteUser.ExecuteNonQuery();
                        sql.Close();
                        MessageBox.Show("Запис та видалення даних пройшли успішно!");
                        buttonSaveConfogServerName.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        buttonSaveConfogServerName.Enabled = false;
                        MessageBox.Show("Сталася помилка! Детальніше: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Виберіть базу даних!");
            }
        }
        private void ButtonSaveConfogServerName_Click(object sender, EventArgs e)
        {

        }
        private void comboBoxListDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxListDataBase.SelectedIndex != -1)
            {
                buttonSaveConfogServerName.Enabled = false;
                buttonConnectToServerName.Enabled = true;
            }
        }
        private void comboBoxLilstDbIPServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLilstDbIPServer.SelectedIndex != -1)
            {
                buttonConnectToIPServer.Enabled = true;
                buttonSaveConfig.Enabled = false;
            }
        }
        #endregion

        #region Створити базу даних
        private void ButtonTestConnToCreateDB_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress;
            if (IPAddress.TryParse(maskedTextBoxIpServerCreateDB.Text.Trim(), out ipAddress))
            {
                if (IsConnectedToServer(maskedTextBoxIpServerCreateDB.Text.Trim()))
                {
                    Server server = new Server(maskedTextBoxIpServerCreateDB.Text.Trim());
                    foreach (Database db in server.Databases)
                    {
                        comboBoxLilstDbIPServer.Items.Add(db.Name);
                    }
                    maskedTextBoxIpServerCreateDB.Enabled = false;
                    buttonCreateDB.Enabled = true;
                    MessageBox.Show("Тест пройшов успішно!");
                }
                else
                {
                    MessageBox.Show("Не підключається до сервера!");
                }
            }
            else
            {
                MessageBox.Show("Помилкова введенна адреса!");
            }
        }
        private void ButtonCreateDB_Click(object sender, EventArgs e)
        {
            //

            #region script
            string scriptCreated = "CREATE DATABASE [Laminatsia];";
            string script = @"
USE [Laminatsia];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[Archive](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Colourods] [int] NOT NULL,
	[DateComing] [datetime] NOT NULL,
	[Profile] [nvarchar](50) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[Dealer] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[Counts] [tinyint] NOT NULL,
	[Colour] [nvarchar](50) NOT NULL,
	[DateToWork] [datetime] NOT NULL,
	[StatusProfile] [nvarchar](50) NOT NULL,
	[DateReady] [datetime] NOT NULL,
	[Statusods] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[DataTimeChange] [datetime] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Archive] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[Profile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameProfile] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[Dealer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DealerName] [nvarchar](100) NULL,
	[City] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Dealer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[ColourProfile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Colour] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ColourProfile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[Colourods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateComing] [datetime] NOT NULL,
	[Profile_ID] [int] NOT NULL,
	[Dealer_ID] [int] NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[Counts] [tinyint] NOT NULL,
	[Colour_ID] [int] NOT NULL,
	[DateToWork] [datetime] NOT NULL,
	[StatusProfile] [bit] NOT NULL,
	[DateReady] [datetime] NOT NULL,
	[Statusods] [bit] NOT NULL,
	[DateRemove] [datetime] NULL,
 CONSTRAINT [PK_Colourods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [dbo].[Colourods]  WITH CHECK ADD  CONSTRAINT [FK_Colourods_ColourProfile] FOREIGN KEY([Colour_ID])
REFERENCES [dbo].[ColourProfile] ([ID]);

ALTER TABLE [dbo].[Colourods] CHECK CONSTRAINT [FK_Colourods_ColourProfile];

ALTER TABLE [dbo].[Colourods]  WITH CHECK ADD  CONSTRAINT [FK_Colourods_Dealer] FOREIGN KEY([Dealer_ID])
REFERENCES [dbo].[Dealer] ([ID]);

ALTER TABLE [dbo].[Colourods] CHECK CONSTRAINT [FK_Colourods_Dealer];

ALTER TABLE [dbo].[Colourods]  WITH CHECK ADD  CONSTRAINT [FK_Colourods_Profile] FOREIGN KEY([Profile_ID])
REFERENCES [dbo].[Profile] ([ID]);

ALTER TABLE [dbo].[Colourods] CHECK CONSTRAINT [FK_Colourods_Profile];
";
            #endregion
            try
            {
                if (!String.IsNullOrEmpty(maskedTextBoxIpServerCreateDB.Text) && !maskedTextBoxIpServerCreateDB.Enabled)
                {
                    Server server = new Server(maskedTextBoxIpServerCreateDB.Text.Trim());
                    //Server server = new Server(@"LOGIST\SQLEXPRESS2012");
                    using (SqlConnection sql = new SqlConnection(server.ConnectionContext.ConnectionString))
                    {
                        sql.Open();
                        //SqlCommand sqlCreateDBCreated = new SqlCommand("DROP DATABASE [Laminatsia];", sql);
                        SqlCommand sqlCreateDBCreated = new SqlCommand(scriptCreated, sql);
                        sqlCreateDBCreated.ExecuteNonQuery();
                        SqlCommand sqlCreateDB = new SqlCommand(script, sql);
                        sqlCreateDB.ExecuteNonQuery();
                        sql.Close();
                        MessageBox.Show("Базу даних на сервері " + server.Name + "створено з назвою [Laminatsia] !");
                    }
                }
                else { MessageBox.Show("Введіть спочатку IP адресу!"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

    }
}
