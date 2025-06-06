using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sklad1
{
    public partial class AddClient : Form
    {
        private Form parentForm;

        public AddClient(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm; // Сохраняем ссылку на родительскую форму
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения из текстовых полей
                int idClient = string.IsNullOrEmpty(textBox1.Text) ? 0 : int.Parse(textBox1.Text); // ID_клиента
                int idEquipment = string.IsNullOrEmpty(textBox2.Text) ? 0 : int.Parse(textBox2.Text); // ID_техники
                string fullName = textBox3.Text; // ФИО
                string phone = textBox4.Text; // Телефон
                string email = textBox5.Text; // Почта

                // Проверка на пустые обязательные поля
                if (idClient == 0 || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Подключение к базе данных
                string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для добавления данных
                    string query = @"
                INSERT INTO Клиенты (ID_техники, ФИО, Телефон, Почта)
                VALUES (@ID_техники, @ФИО, @Телефон, @Почта)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавляем параметры
                        command.Parameters.AddWithValue("@ID_техники", idEquipment);
                        command.Parameters.AddWithValue("@ФИО", fullName);
                        command.Parameters.AddWithValue("@Телефон", phone);
                        command.Parameters.AddWithValue("@Почта", email);

                        // Выполняем запрос
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Клиент успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Обновляем данные в родительской форме
                            if (parentForm is GLManager glManager)
                            {
                                glManager.RefreshDataGridViewClients();
                            }
                            else if (parentForm is ManagerForm managerForm)
                            {
                                managerForm.RefreshDataGridViewClients();
                            }

                            // Закрываем форму добавления клиента
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            // Здесь можно добавить дополнительную логику при загрузке формы
        }
    }
}