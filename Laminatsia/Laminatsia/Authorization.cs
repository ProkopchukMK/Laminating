using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.EntityClient;
using Laminatsia.DTO;

namespace Laminatsia
{
    public partial class Authorization : Form
    {
        /// <summary>
        /// TODO:
        /// 1. Stored procedure for insert and update     
        /// </summary>
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
            comboBoxRole.Items.AddRange(new String[] { "Ламінація", "Менеджери", "Технологи", "Адміністратори"});
            //якщо такого файлу не було знайдено створюємо пустий текстовий файл
            if (!File.Exists(fileName))
            {
                using (FileStream fs = File.Open(fileName, FileMode.OpenOrCreate)) { File.WriteAllLines(fileName, new string[] { "Адміністратор", CodingASCII("1", true), "Адміністратори" }); }
            }
            userSaveData = File.ReadAllLines(fileName);
            if (userSaveData.Length > 0)
            {//якщо файл є, то ми витягуємо з нього інфу та заповнюємо текст боксами
                textBoxLogin.Text = userSaveData[0];
                textBoxPassword.Text = CodingASCII(userSaveData[1], false);
                comboBoxRole.SelectedItem = userSaveData[2];
                checkBoxSaveUserInfo.Checked = true;
            }
        }
        private void ButtonLogIn_Click(object sender, EventArgs e)
        {
            try
            {//перевіряємо конект до бази даних, якщо немає конеткту і логін і пароль та роль адмін запускаємо налаштування конекту
                if (!this.IsServerConnected())
                {
                    if (comboBoxRole.SelectedItem.ToString() == "Адміністратори" && textBoxLogin.Text.Trim() == "Адміністратор"  && textBoxPassword.Text == "1")
                    {
                        Connect connectForm = new Connect();
                        connectForm.Closed += (s, args) => this.Close();
                        connectForm.Show();
                        this.Hide();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Для налаштування зєднання, зайдіть як адміністратор!");
                        this.Close();
                    }
                }
                LaminatsiaEntities _entity = new LaminatsiaEntities();
                //не допускаємо пустий логін
                if (textBoxLogin.Text.Trim() != "")
                {   //не допускаємо пустий пароль
                    if (textBoxPassword.Text.Trim() != "")
                    {   //не допускаємо не вибрану роль 
                        if (comboBoxRole.SelectedItem != null)
                        { //перевіряємо наявність такаго юзера з такими правами доступа
                            string userName = textBoxLogin.Text.Trim();
                            string userPassword = textBoxPassword.Text.Trim();
                            string role = comboBoxRole.SelectedItem.ToString();
                            //чи існує такий логін
                            if (_entity.Users.FirstOrDefault(x => x.UserName == userName) != null)
                            {   //чи вірний пароль до логіна
                                if (_entity.Users.FirstOrDefault(x => x.UserName == userName && x.UserPassword == userPassword) != null)
                                {   //чи вірні права доступу до даного користувача
                                    if (_entity.Users.FirstOrDefault(x => x.UserName == userName && x.UserPassword == userPassword && x.Role == role) != null)
                                    {   //зберегти дані для нкаступного входу
                                        if (checkBoxSaveUserInfo.Checked)
                                        {
                                            //відправляємо пароль на шифруваня для запису в файл OperationOXR
                                            string codingUserPasword = CodingASCII(userPassword, true);
                                            File.WriteAllLines(fileName, new string[] { userName, codingUserPasword, role });
                                        }
                                        //запускаємо Ламінацію відповідно до прав користувача
                                        this.Hide();
                                        Laminatsia laminatsiaForm = new Laminatsia(userName, role);
                                        //підвязуємо закриття форми входу до форми Ламінація, тобто коли закриємо ламінацію то закриється форма входу 
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
            catch (Exception ex)
            {
                MessageBox.Show("ButtonLogIn_Click " + ex.ToString());
            }
        }
        //шифратор і дешифратор пароля, для запису і зчитування у тимчасовий файл. 
        //Перше значення для значення, а друге при true - шифрує, а при false - розшифровує.
        
        private string CodingASCII(string input, bool coding)
        {
            string output = "";
            if (coding)
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    output += inputBytes[i].ToString() + " ";
                }                               
            }
            else
            {
                string[] str = input.TrimEnd().Split(new char[] { ' ' });                
                byte[] inputBytes = new byte[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    Byte.TryParse(str[i],out inputBytes[i]);                     
                }                                
                char[] chars = System.Text.Encoding.ASCII.GetChars(inputBytes);
                output = new string (chars);
            }
            return output;
        }
        private bool IsServerConnected()
        {//цей метод перевіряє на наявність конекта до бази даних            
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LaminatsiaEntities"].ConnectionString;
                EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(connectionString);
                //витягуємо з файла конфіга строку для sql конекта
                connectionString = builder.ProviderConnectionString;

                using (var sql = new SqlConnection(connectionString)) { sql.Open(); return true; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Не можливо зєднатися з базою даних! 
Перевірте підключення до мережі або налаштуйте SQL сервер! 
Детальніше про помилку: " + ex.Message);
                return false;
            }
        }
        //кнопка для закриття програми
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
