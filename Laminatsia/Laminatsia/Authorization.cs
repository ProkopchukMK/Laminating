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
namespace Laminatsia
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            comboBoxRole.Items.AddRange(new String[] { "Ламінація", "Менеджери", "Технологи", "Адміністратори" });
        }
        private LaminatsiaEntities _entity = new LaminatsiaEntities();
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text.Trim() != "")
            {
                if (textBoxPassword.Text.Trim() != "")
                {
                    if (comboBoxRole.SelectedItem != null)
                    {
                        string userName = textBoxLogin.Text.Trim();
                        string userPassword = textBoxPassword.Text.Trim();
                        string role = comboBoxRole.SelectedItem.ToString();
                        if (_entity.Users.FirstOrDefault(x => x.UserName == userName) != null)
                        {
                            if (_entity.Users.FirstOrDefault(x => x.UserName == userName && x.UserPassword == userPassword) != null)
                            {
                                if (_entity.Users.FirstOrDefault(x => x.UserName == userName && x.UserPassword == userPassword && x.Role == role) != null)
                                {
                                    this.Hide();
                                    LaminatsiaForm laminatsiaForm = new LaminatsiaForm(userName, role);
                                    laminatsiaForm.Closed += (s, args) => this.Close();
                                    laminatsiaForm.Show();
                                    
                                    //laminatsiaForm.Show();
                                    //this.Hide();                                    
                                    //Application.Run(new LaminatsiaForm (userName, role));
                                    //this.Close();                                    
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
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
