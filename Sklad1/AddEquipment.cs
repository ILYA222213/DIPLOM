using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sklad1
{
    public partial class AddEquipment : Form
    {
        private Form parentForm;

        public AddEquipment(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm; // Сохраняем ссылку на родительскую форму
        }

        private void AddEquipment_Load(object sender, EventArgs e)
        {
            // Здесь можно добавить дополнительную логику при загрузке формы
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения из текстовых полей
                int idEquipment = string.IsNullOrEmpty(textBox1.Text) ? 0 : int.Parse(textBox1.Text); // ID_техники
                string description = textBox2.Text; // Описание
                int quantity = string.IsNullOrEmpty(textBox3.Text) ? 0 : int.Parse(textBox3.Text); // Количество

                // Проверка на пустые обязательные поля
                if (idEquipment == 0 || string.IsNullOrEmpty(description) || quantity == 0)
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
                INSERT INTO Техника (Описание, Количество)
                VALUES (@Описание, @Количество)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавляем параметры
                        command.Parameters.AddWithValue("@Описание", description);
                        command.Parameters.AddWithValue("@Количество", quantity);

                        // Выполняем запрос
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Техника успешно добавлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Обновляем данные в родительской форме
                            if (parentForm is GLManager glManager)
                            {
                                glManager.RefreshDataGridViewEquipment();
                            }
                            else if (parentForm is ManagerForm managerForm)
                            {
                                managerForm.RefreshDataGridViewEquipment();
                            }

                            // Закрываем форму добавления техники
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить технику.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}