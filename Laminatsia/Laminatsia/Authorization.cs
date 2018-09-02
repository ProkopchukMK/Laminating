using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Configuration;
using System.Threading;
using System.IO;
using Laminatsia.Properties;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;

namespace Laminatsia
{
    public partial class Authorization : Form
    {
        private string[] userSaveData = null;
        //виставити розташування файлу в папці з програмою, де записуються дані останього збереженого користувача
        private string fileName = Directory.GetCurrentDirectory() + @"\UserData.txt";
        public Authorization()
        {
            InitializeComponent();
            FillAllAuthorization();
        }
        private void FillAllAuthorization()
        {
            comboBoxRole.Items.AddRange(new String[] { "Ламінація", "Менеджери", "Технологи", "Адміністратори" });
            //якщо такого файлу не було знайдено створюємо пустий текстовий файл
            if (!File.Exists(fileName))
            {
                using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate)) { }
            }
            userSaveData = File.ReadAllLines(fileName);
            if (userSaveData.Length > 0)
            {
                textBoxLogin.Text = userSaveData[0];
                textBoxPassword.Text = OperationOXR(userSaveData[1], false);
                comboBoxRole.SelectedItem = userSaveData[2];
                checkBoxSaveUserInfo.Checked = true;
            }
        }
        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                string userName;
                string userPassword;
                string role;
                LaminatsiaEntities _entity = new LaminatsiaEntities();

                if (textBoxLogin.Text.Trim() != "")
                {
                    if (textBoxPassword.Text.Trim() != "")
                    {
                        if (comboBoxRole.SelectedItem != null)
                        {
                            //перевіряємо конект до бази даних
                            //IsServerConnected();
                            userName = textBoxLogin.Text.Trim();
                            userPassword = textBoxPassword.Text.Trim();
                            role = comboBoxRole.SelectedItem.ToString();

                            if (_entity.Users.FirstOrDefault(x => x.UserName == userName) != null)
                            {
                                if (_entity.Users.FirstOrDefault(x => x.UserName == userName && x.UserPassword == userPassword) != null)
                                {
                                    if (_entity.Users.FirstOrDefault(x => x.UserName == userName && x.UserPassword == userPassword && x.Role == role) != null)
                                    {
                                        if (checkBoxSaveUserInfo.Checked)
                                        {
                                            //відправляємо пароль на шифруваня для запису в файл OperationOXR
                                            string codingUserPasword = OperationOXR(userPassword, true);
                                            File.WriteAllLines(fileName, new string[] { userName, codingUserPasword, role });
                                        }
                                        this.Hide();
                                        Laminatsia laminatsiaForm = new Laminatsia(userName, role);
                                        laminatsiaForm.Closed += (s, args) => this.Close();
                                        laminatsiaForm.Show();
                                    }
                                    else { MessageBox.Show("Не вірні права!"); }
                                }
                                else { MessageBox.Show("Не вірний пароль!"); textBoxPassword.Text = ""; }
                            }
                            else
                            {
                                MessageBox.Show("Не вірний логін!");
                                textBoxLogin.Text = "";
                                textBoxPassword.Text = "";
                            }
                        }
                        else { MessageBox.Show("Виберіть права доступу!"); }
                    }
                    else { MessageBox.Show("Введіть пароль!"); }
                }
                else { MessageBox.Show("Введіть логін!"); }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ButtonLogIn_Click " + ex.ToString() );
            }
        }
        //шифратор і дешифратор пароля, для запису і зчитування у тимчасовий файл. 
        //Перше значення для значення, а друге при true - шифрує, а при false - розшифровує.
        private string OperationOXR(string input, bool coding)
        {
            const string key = "2018";
            string output = "";
            if (coding)
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] res = new byte[inputBytes.Length];

                for (int i = 0; i < inputBytes.Length; i++)
                {
                    res[i] = (byte)(inputBytes[i] ^ key[i % key.Length]);
                }
                output = System.Text.Encoding.UTF8.GetString(res);
            }
            else
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] res = new byte[inputBytes.Length];

                for (int i = 0; i < inputBytes.Length; i++)
                {
                    res[i] = (byte)(inputBytes[i] ^ key[i % key.Length]);
                }
                output = System.Text.Encoding.UTF8.GetString(res);
            }
            return output;
        }
        //private void IsServerConnected()
        //{
        //    string connectionString = "";
        //    try
        //    {
        //        connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringToLaminatsiaEntities"].ConnectionString;
        //    }
        //    catch
        //    {
        //        if (string.IsNullOrEmpty(connectionString))
        //        {
        //            //this.Hide();
        //            Connect connectForm = new Connect();
        //            //connectForm.Closed += (s, args) => 
        //            connectForm.Show();
        //            this.Close();
        //        }
        //        else
        //        {
        //            using (var connecting = new SqlConnection(connectionString))
        //            {
        //                try
        //                {
        //                    connecting.Open();
        //                }
        //                catch (SqlException sqlEx)
        //                {
        //                    MessageBox.Show(sqlEx.Message);
        //                    this.Hide();
        //                    Connect connectForm = new Connect();
        //                    connectForm.Closed += (s, args) => this.Close();
        //                    connectForm.Show();
        //                }
        //            }
        //        }
        //    }
        //
        //}
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
