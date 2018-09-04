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
using Laminatsia.Resources;

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
            IPAddress ipAddress;
            if (IPAddress.TryParse(maskedTextBoxIPServer.Text.Trim(), out ipAddress))
            {
                if (IsConnectedToInternet(maskedTextBoxIPServer.Text.Trim()))
                {
                    Server server = new Server(maskedTextBoxIPServer.Text.Trim());
                    foreach (Database db in server.Databases)
                    {
                        comboBoxLilstDbIPServer.Items.Add(db.Name);
                    }
                    maskedTextBoxIPServer.Enabled = false;
                    comboBoxLilstDbIPServer.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Не подключается к серверу!");
                }
            }
            else
            {
                MessageBox.Show("Помилкова адреса!");
            }
        }
        public static bool IsConnectedToInternet(string ServerAddress)
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
                MessageBox.Show(ex.Message);
                return false;
            }
            //
            return false;
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

        private void buttonConnectToIPServer_Click(object sender, EventArgs e)
        {

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

        private void buttonTestConnToCreateDB_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress;
            if (IPAddress.TryParse(maskedTextBoxIpServerCreateDB.Text.Trim(), out ipAddress))
            {
                if (IsConnectedToInternet(maskedTextBoxIpServerCreateDB.Text.Trim()))
                {
                    Server server = new Server(maskedTextBoxIpServerCreateDB.Text.Trim());
                    foreach (Database db in server.Databases)
                    {
                        comboBoxLilstDbIPServer.Items.Add(db.Name);
                    }
                    maskedTextBoxIpServerCreateDB.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Не подключается к серверу!");
                }
            }
            else
            {
                MessageBox.Show("Помилкова адреса!");
            }
        }
        private void buttonCreateDB_Click(object sender, EventArgs e)
        {
            //

            #region script
            string scriptCreated = "CREATE DATABASE [Laminatsia];";
            string script = @"
USE [master];

ALTER DATABASE [Laminatsia] SET COMPATIBILITY_LEVEL = 110;

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Laminatsia].[dbo].[sp_fulltext_database] @action = 'enable'
end

ALTER DATABASE [Laminatsia] SET ANSI_NULL_DEFAULT OFF;

ALTER DATABASE [Laminatsia] SET ANSI_NULLS OFF;

ALTER DATABASE [Laminatsia] SET ANSI_PADDING OFF ;

ALTER DATABASE [Laminatsia] SET ANSI_WARNINGS OFF ;

ALTER DATABASE [Laminatsia] SET ARITHABORT OFF ;

ALTER DATABASE [Laminatsia] SET AUTO_CLOSE OFF ;

ALTER DATABASE [Laminatsia] SET AUTO_SHRINK OFF ;

ALTER DATABASE [Laminatsia] SET AUTO_UPDATE_STATISTICS ON ;

ALTER DATABASE [Laminatsia] SET CURSOR_CLOSE_ON_COMMIT OFF ;

ALTER DATABASE [Laminatsia] SET CURSOR_DEFAULT  GLOBAL ;

ALTER DATABASE [Laminatsia] SET CONCAT_NULL_YIELDS_NULL OFF ;

ALTER DATABASE [Laminatsia] SET NUMERIC_ROUNDABORT OFF ;

ALTER DATABASE [Laminatsia] SET QUOTED_IDENTIFIER OFF ;

ALTER DATABASE [Laminatsia] SET RECURSIVE_TRIGGERS OFF ;

ALTER DATABASE [Laminatsia] SET  DISABLE_BROKER ;

ALTER DATABASE [Laminatsia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF ;

ALTER DATABASE [Laminatsia] SET DATE_CORRELATION_OPTIMIZATION OFF ;

ALTER DATABASE [Laminatsia] SET TRUSTWORTHY OFF ;

ALTER DATABASE [Laminatsia] SET ALLOW_SNAPSHOT_ISOLATION OFF ;

ALTER DATABASE [Laminatsia] SET PARAMETERIZATION SIMPLE ;

ALTER DATABASE [Laminatsia] SET READ_COMMITTED_SNAPSHOT OFF ;

ALTER DATABASE [Laminatsia] SET HONOR_BROKER_PRIORITY OFF ;

ALTER DATABASE [Laminatsia] SET RECOVERY SIMPLE ;

ALTER DATABASE [Laminatsia] SET  MULTI_USER ;

ALTER DATABASE [Laminatsia] SET PAGE_VERIFY CHECKSUM  ;

ALTER DATABASE [Laminatsia] SET DB_CHAINING OFF ;

ALTER DATABASE [Laminatsia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) ;

ALTER DATABASE [Laminatsia] SET TARGET_RECOVERY_TIME = 0 SECONDS ;

USE [Laminatsia];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[Archive](
	[ID] [int] IDENTITY(1,1)  NOT NULL,
	[DateComming] [datetime] NOT NULL,
	[Profile] [nvarchar](50) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[Dealer] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[Counts] [tinyint] NOT NULL,
	[Colour] [nvarchar](50) NOT NULL,
	[DateToWork] [datetime] NOT NULL,
	[StatusProfile] [bit] NOT NULL,
	[DateReady] [datetime] NOT NULL,
	[StatusGoods] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[DataTimeChange] [datetime] NOT NULL
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[ColourGoods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateComming] [datetime] NOT NULL,
	[Profile_ID] [int] NOT NULL,
	[Dealer_ID] [int] NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[Counts] [tinyint] NOT NULL,
	[Colour_ID] [int] NOT NULL,
	[DateToWork] [datetime] NOT NULL,
	[StatusProfile] [bit] NOT NULL,
	[DateReady] [datetime] NOT NULL,
	[StatusGoods] [bit] NOT NULL,
 CONSTRAINT [PK_ColourGoods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[ColourProfile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Colour] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ColourProfile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[Dealer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DealerName] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dealer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[Profile](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameProfile] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](10) NOT NULL,
	[UserPassword] [nchar](100) NOT NULL,
	[UserPC] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [dbo].[ColourGoods]  WITH CHECK ADD  CONSTRAINT [FK_ColourGoods_ColourProfile] FOREIGN KEY([Colour_ID])
REFERENCES [dbo].[ColourProfile] ([ID]);

ALTER TABLE [dbo].[ColourGoods] CHECK CONSTRAINT [FK_ColourGoods_ColourProfile];

ALTER TABLE [dbo].[ColourGoods]  WITH CHECK ADD  CONSTRAINT [FK_ColourGoods_Dealer] FOREIGN KEY([Dealer_ID])
REFERENCES [dbo].[Dealer] ([ID]);

ALTER TABLE [dbo].[ColourGoods] CHECK CONSTRAINT [FK_ColourGoods_Dealer];

ALTER TABLE [dbo].[ColourGoods]  WITH CHECK ADD  CONSTRAINT [FK_ColourGoods_Profile] FOREIGN KEY([Profile_ID])
REFERENCES [dbo].[Profile] ([ID]);

ALTER TABLE [dbo].[ColourGoods] CHECK CONSTRAINT [FK_ColourGoods_Profile];

USE [master];

ALTER DATABASE [Laminatsia] SET  READ_WRITE ;
";
            #endregion

            try
            {
                //Server server = new Server(maskedTextBoxIpServerCreateDB.Text.Trim());
                Server server = new Server(@"LOGIST\SQLEXPRESS2012");
                using (SqlConnection sql = new SqlConnection(server.ConnectionContext.ConnectionString))
                {
                    sql.Open();
                    //SqlCommand sqlCreateDBCreated = new SqlCommand("DROP DATABASE [Laminatsia];", sql);
                    SqlCommand sqlCreateDBCreated = new SqlCommand(scriptCreated, sql);
                    sqlCreateDBCreated.ExecuteNonQuery();
                    SqlCommand sqlCreateDB = new SqlCommand(script, sql);                    
                    sqlCreateDB.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Створено!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}
