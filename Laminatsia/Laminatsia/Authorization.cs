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

namespace Laminatsia
{
    public partial class Authorization : Form
    {
        private string[] userSaveData = null;
        //виставити розташування файлу де записуються дані останього збереженого користувача
        private string fileName = @"C:\Users\Логист\Desktop\Ламінація\Laminatsia\Laminatsia\Resources\UserData.txt";     
        //private string fileName = @"D:\Ламінація\Laminatsia\Laminatsia\Resources\UserData.txt";
        public Authorization()
        {
            InitializeComponent();
            comboBoxRole.Items.AddRange(new String[] { "Ламінація", "Менеджери", "Технологи", "Адміністратори" });
            //якщо такого файлу не було знайдено створюємо пустий текстовий файл
            using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate )) { }
            userSaveData = File.ReadAllLines(fileName);
            if (userSaveData.Length > 0)
            {
                textBoxLogin.Text = userSaveData[0];
                textBoxPassword.Text = userSaveData[1];
                comboBoxRole.SelectedItem = userSaveData[2];
                checkBoxSaveUserInfo.Checked = true;
            }
        }
        private LaminatsiaEntities _entity = new LaminatsiaEntities();
        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            string userName;
            string userPassword;
            string role;

            if (textBoxLogin.Text.Trim() != "")
            {
                if (textBoxPassword.Text.Trim() != "")
                {
                    if (comboBoxRole.SelectedItem != null)
                    {
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
                                        //string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                                        File.WriteAllLines(fileName, new string[] { userName, userPassword, role });
                                    }
                                    this.Hide();
                                    LaminatsiaForm laminatsiaForm = new LaminatsiaForm(userName, role);
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
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
