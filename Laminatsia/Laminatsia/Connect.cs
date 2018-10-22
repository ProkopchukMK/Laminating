using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.EntityClient;
using System.IO;

namespace Laminatsia
{
    public partial class Connect : Form
    {
        public Connect()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }
        private Server server;
        //переключення по вкладкам таб контрола 
        private void TabControlConnect_SelectedIndexChanged(object sender, EventArgs e)
        {//очищаємо вміст при переході на дану вкладку
            if (tabControlConnect.SelectedTab == tabPageIP)
            {
                maskedTextBoxIPServer.Text = "";
                maskedTextBoxIPServer.Enabled = true;
                comboBoxLilstDbIPServer.Items.Clear();
                comboBoxLilstDbIPServer.Enabled = false;
                buttonConnectToIPServer.Enabled = false;
                buttonSaveConfig.Enabled = false;
            }
            else if (tabControlConnect.SelectedTab == tabPageFromList)
            {
                comboBoxListServerName.Items.Clear();
                comboBoxListDataBase.Items.Clear();
                comboBoxListServerName.Enabled = false;
                comboBoxListDataBase.Enabled = false;
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
        //перевіряємо чи доступний сервер
        public static bool IsConnectedToServer(string ServerAddress)
        {
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(ServerAddress, 5000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch (ArgumentNullException argEx)
            {
                MessageBox.Show("IP Серверу не може бути пустим! " + argEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сервер недоступний по даній адресі! " + ex.Message);
                return false;
            }
            return false;
        }
        //підключення по ір адресі, якщо сервер не доступний або не включення обнаружение в сети
        #region По ІР адресу
        //тест на зєднання до серверу
        private void ButtonTestConnectingToServer_Click(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(maskedTextBoxIPServer.Text.Trim(), out IPAddress ipAddress))
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
        //перевіряємо доступність вибраної бази даних
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
                        //string writeToDB = @"INSERT INTO Users (UserName, UserPassword, Role) values('Test', 'Test','Адміністратори')";
                        //string updateDB = @"DELETE FROM Users WHERE UserName='Test'";
                        sql.Open();
                        //SqlCommand sqlCreateUser = new SqlCommand(writeToDB, sql);
                        //sqlCreateUser.ExecuteNonQuery();
                        //SqlCommand sqlDeleteUser = new SqlCommand(updateDB, sql);
                        //sqlDeleteUser.ExecuteNonQuery();
                        //sql.Close();
                        //MessageBox.Show("Запис та видалення даних пройшли успішно!");
                        MessageBox.Show("База даних доступна!");
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
        //зберігаємо конфігурації налаштування 
        private void ButtonSaveConfig_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["LaminatsiaEntities"].ConnectionString)
            {
                ProviderConnectionString = "data source=" + maskedTextBoxIPServer.Text + ";initial catalog=" + comboBoxLilstDbIPServer.SelectedItem.ToString() + ";integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"
            };
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["LaminatsiaEntities"].ConnectionString = builder.ConnectionString;

            ConfigurationManager.RefreshSection("connectionStrings");
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            MessageBox.Show("Конфігурацію збережено! Детальніше: " + ConfigurationManager.ConnectionStrings["LaminatsiaEntities"].ConnectionString);
        }
        //при виборці бази даних вкл кнопки
        private void ComboBoxLilstDbIPServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLilstDbIPServer.SelectedIndex != -1)
            {
                buttonConnectToIPServer.Enabled = true;
                buttonSaveConfig.Enabled = false;
            }
        }
        #endregion
        //вибираємо зі списку доступних серверів
        #region Вибрати із списку        
        private List<string> listServers = new List<string>();
        private List<string> listDatabases = new List<string>();
        //асинхронні метод для заповнення листу серверів
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetAllServers();
        }
        //асинхроний метод для заповнення баз даних
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            GetAllDatabases();
        }
        private void GetAllServers()
        {
            listServers = SmoApplication.EnumAvailableSqlServers(false).AsEnumerable().Select(x => x.Field<string>("Name")).ToList(); // поставати false для мережевих серверів
        }
        private void GetAllDatabases()
        {
            try
            {
                listDatabases = new List<string>();
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
        //при завершенні асинхроних методів
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarConnectToDB.Visible = false;
            comboBoxListServerName.Enabled = true;
            comboBoxListServerName.Items.AddRange(listServers.ToArray());
            tabControlConnect.Enabled = true;
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarConnectToDB.Visible = false;
            comboBoxListServerName.Enabled = true;
            comboBoxListDataBase.Items.Clear();
            comboBoxListDataBase.Items.AddRange(listDatabases.ToArray());
        }
        //кнопка для пошуку доступних серверів
        private void ButtonSearchServers_Click(object sender, EventArgs e)
        {
            progressBarConnectToDB.Visible = true;
            buttonSaveConfogServerName.Enabled = false;
            buttonConnectToServerName.Enabled = false;
            comboBoxListDataBase.Items.Clear();
            comboBoxListServerName.Items.Clear();
            tabControlConnect.Enabled = false;
            backgroundWorker.RunWorkerAsync();
        }
        //заповнення листу баз даних до вибраного серверу
        private void ComboBoxListServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxListServerName.SelectedItem.ToString() != null)
                {
                    comboBoxListDataBase.Enabled = true;
                    string serverName = comboBoxListServerName.SelectedItem.ToString();
                    server = new Server(serverName);
                    backgroundWorker1.RunWorkerAsync();
                    progressBarConnectToDB.Visible = true;
                    buttonSaveConfogServerName.Enabled = false;
                    buttonConnectToServerName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                comboBoxListDataBase.Items.Clear();
                comboBoxListDataBase.Enabled = false;
                MessageBox.Show("Сталася помилка! Детальніше: " + ex.Message);
            }
        }
        //перевірка зєднання до серверу
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
                        sql.Open();
                        MessageBox.Show("Дана база даних доступна!");
                        buttonSaveConfogServerName.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        buttonSaveConfogServerName.Enabled = false;
                        MessageBox.Show("Сталася помилка! Детальніше: " + ex.Message);
                    }
                    finally
                    {
                        sql.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Виберіть базу даних!");
            }
        }
        //збереження конфігурації
        private void ButtonSaveConfogServerName_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["LaminatsiaEntities"].ConnectionString)
            {
                ProviderConnectionString = "data source=" + comboBoxListServerName.SelectedItem.ToString() + ";initial catalog=" + comboBoxListDataBase.SelectedItem.ToString() + ";integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"
            };
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["LaminatsiaEntities"].ConnectionString = builder.ConnectionString;

            ConfigurationManager.RefreshSection("connectionStrings");
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
            MessageBox.Show("Конфігурацію збережено! Детальніше: " + ConfigurationManager.ConnectionStrings["LaminatsiaEntities"].ConnectionString);
        }
        //при вибору бази даних 
        private void ComboBoxListDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxListDataBase.SelectedIndex != -1)
            {
                buttonSaveConfogServerName.Enabled = false;
                buttonConnectToServerName.Enabled = true;
            }
        }
        #endregion
        //створюємо чисту базу даних для роботи програми
        #region Створити базу даних
        //тест на підключення до серверу
        private void ButtonTestConnToCreateDB_Click(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(maskedTextBoxIpServerCreateDB.Text.Trim(), out IPAddress ipAddress))
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
        //створити базу даних
        private void ButtonCreateDB_Click(object sender, EventArgs e)
        {
            try
            {
                string pathScriptFile = Directory.GetCurrentDirectory() + @"\SQL\";
                string[] scripts = new string[] {
            "CREATE DATABASE [Laminatsia];",
            File.ReadAllText(pathScriptFile + "CreateDataBaseLaminatsia.sql").ToString(),
            File.ReadAllText(pathScriptFile + "CreateViewGetAllArchive.sql").ToString(),
            File.ReadAllText(pathScriptFile + "CreateViewGetAllColour.sql").ToString(),
            File.ReadAllText(pathScriptFile + "CreateViewGetAllColourGoods.sql").ToString(),
            File.ReadAllText(pathScriptFile + "CreateViewGetAllDealer.sql").ToString(),
            File.ReadAllText(pathScriptFile + "CreateViewGetAllProfile.sql").ToString(),
            File.ReadAllText(pathScriptFile + "CreateViewGetAllUsers.sql").ToString(),
            File.ReadAllText(pathScriptFile + "CreateProcedureGetColourGoodsByNotes.sql").ToString()
            };
                if (!String.IsNullOrEmpty(maskedTextBoxIpServerCreateDB.Text) && !maskedTextBoxIpServerCreateDB.Enabled)
                {
                    Server server = new Server(maskedTextBoxIpServerCreateDB.Text.Trim());
                    using (SqlConnection sql = new SqlConnection(server.ConnectionContext.ConnectionString))
                    {
                        sql.Open();
                        for (int i = 0; i < scripts.Length; i++)
                        {
                            SqlCommand sqlScript = new SqlCommand(scripts[i], sql);
                            sqlScript.ExecuteNonQuery();
                        }
                        sql.Close();
                        MessageBox.Show("Базу даних на сервері " + server.Name + "створено з назвою [Laminatsia] !");
                    }
                    //виставити розташування файлу в папці з програмою, де записуються дані останього збереженого користувача
                    string fileName = Directory.GetCurrentDirectory() + @"\UserData.txt";
                    //якщо такого файлу не було знайдено створюємо пустий текстовий файл
                    if (!File.Exists(fileName))
                    {
                        using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate)) { }
                    }
                    byte[] inputBytes = Encoding.ASCII.GetBytes("1");
                    string output = "";
                    for (int i = 0; i < inputBytes.Length; i++)
                    {
                        output += inputBytes[i].ToString() + " ";
                    }
                    File.WriteAllLines(fileName, new string[] { "Адміністратор", output, "Адміністратори" });
                }
                else { MessageBox.Show("Введіть спочатку IP адресу!"); }
            }
            catch (SqlException sqlEx)
            {
                string path = Directory.GetCurrentDirectory() + @"\SQL\ScriptForManadgmentStudio.txt";
                MessageBox.Show(@"Помилка на рівні доступу до бази даних! 
1. Перевірте на наявність дозволу на створення бази даних на сервері користувачем.
2. Запустіть програму на компютері де знаходиться серер SQL.
3. Скористайтеся скріптом з файла " + path + @" запустивши його, як запит на SQL сервері від користувача який має дозвіл на створення баз даних. 
                                    Детальніше: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Сталася помилка!
                                    Детальніше: " + ex.Message);
            }
        }
        #endregion

    }
}
