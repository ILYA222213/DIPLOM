using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sklad1
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True;"; // Замените на вашу строку подключения

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            // Проверяем роль пользователя
            string role = GetUserRole(login, password);

            if (role == "Администратор")
            {
                MessageBox.Show("Авторизация успешна! Вы вошли как Администратор.");
                this.Hide();

                // Открываем окно администратора
                AdminForm adminForm = new AdminForm();
                adminForm.ShowDialog();

                this.Close();
            }
            else if (role == "Менеджер")
            {
                MessageBox.Show("Авторизация успешна! Вы вошли как Менеджер.");
                this.Hide();

                // Открываем окно кладовщика
                ManagerForm managerForm = new ManagerForm();
                managerForm.ShowDialog();

                this.Close();
            }
            else if (role == "Мастер")
            {
                MessageBox.Show("Авторизация успешна! Вы вошли как Мастер.");
                this.Hide();

                // Открываем окно кладовщика
                MasterForm masterForm = new MasterForm();
                masterForm.ShowDialog();

                this.Close();
            }
            else if (role == "Главный менеджер")
            {
                MessageBox.Show("Авторизация успешна! Вы вошли как Главный менеджер.");
                this.Hide();

                // Открываем окно кладовщика
                GLManager GLManager = new GLManager();
                GLManager.ShowDialog();

                this.Close();
            }
            else if (role == "Главный мастер")
            {
                MessageBox.Show("Авторизация успешна! Вы вошли как Главный мастер.");
                this.Hide();

                // Открываем окно кладовщика
                GLMaster GLMaster = new GLMaster();
                GLMaster.ShowDialog();

                this.Close();
            }

            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string GetUserRole(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Обновленный запрос с учетом отдельной таблицы "Роль"
                string query = @"
            SELECT r.Наименование 
            FROM Аутентификация a
            INNER JOIN Сотрудники s ON a.id_сотрудника = s.id_сотрудника
            INNER JOIN Роль r ON s.id_роли = r.id_роли
            WHERE a.логин = @login AND a.пароль = @password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    object result = command.ExecuteScalar();
                    return result?.ToString(); // Возвращаем роль пользователя или null
                }
            }
        }
    }

    
    }

