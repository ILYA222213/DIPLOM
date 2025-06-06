using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sklad1
{
    public partial class AddOrderForm : Form
    {
        private Form parentForm;

        public AddOrderForm(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm; // Сохраняем ссылку на родительскую форму
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения из текстовых полей
                int idClient = ParseInt(textBox2.Text, "ID_клиента");
                int idEmployee = ParseInt(textBox3.Text, "ID_сотрудника");
                int idService = ParseInt(textBox4.Text, "ID_услуги");
                int idPart = ParseInt(textBox5.Text, "ID_запчасти");
                int idPayment = ParseInt(textBox6.Text, "ID_оплаты");
                string problemDescription = textBox7.Text.Trim(); // Описание проблемы
                string status = textBox8.Text.Trim(); // Статус
                DateTime date = ParseDateTime(textBox9.Text); // Дата

                // Проверка на пустые обязательные поля
                if (idClient == 0 || idEmployee == 0 || idService == 0 || idPart == 0 || idPayment == 0)
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Подключение к базе данных
                string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Получаем цены услуги и запчасти
                    decimal servicePrice = GetPriceFromTable(connection, "Услуги", "Цена", idService);
                    decimal partPrice = GetPriceFromTable(connection, "Запчасти", "Цена", idPart);

                    // Рассчитываем общую сумму
                    decimal totalAmount = servicePrice + partPrice;

                    // SQL-запрос для добавления данных
                    string query = @"
                        INSERT INTO Заказы (ID_клиента, ID_сотрудника, ID_услуги, ID_запчасти, ID_оплаты, Описание_проблемы, Статус, Дата, Сумма)
                        VALUES (@ID_клиента, @ID_сотрудника, @ID_услуги, @ID_запчасти, @ID_оплаты, @Описание_проблемы, @Статус, @Дата, @Сумма)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавляем параметры
                        command.Parameters.AddWithValue("@ID_клиента", idClient);
                        command.Parameters.AddWithValue("@ID_сотрудника", idEmployee);
                        command.Parameters.AddWithValue("@ID_услуги", idService);
                        command.Parameters.AddWithValue("@ID_запчасти", idPart);
                        command.Parameters.AddWithValue("@ID_оплаты", idPayment);
                        command.Parameters.AddWithValue("@Описание_проблемы", problemDescription);
                        command.Parameters.AddWithValue("@Статус", status);
                        command.Parameters.AddWithValue("@Дата", date);
                        command.Parameters.AddWithValue("@Сумма", totalAmount);

                        // Выполняем запрос
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Заказ успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Обновляем данные в родительской форме
                            if (parentForm is GLManager glManager)
                            {
                                glManager.RefreshDataGridViewOrders();
                            }
                            else if (parentForm is ManagerForm managerForm)
                            {
                                managerForm.RefreshDataGridViewOrders();
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить заказ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            // Здесь можно добавить дополнительную логику при загрузке формы
        }

        // Метод для получения цены из таблицы
        private decimal GetPriceFromTable(SqlConnection connection, string tableName, string priceColumn, int itemId)
        {
            try
            {
                // Определяем имя колонки ID для каждой таблицы
                string idColumnName = null;

                if (tableName == "Услуги")
                {
                    idColumnName = "ID_услуги";
                }
                else if (tableName == "Запчасти")
                {
                    idColumnName = "ID_запчасти";
                }
                else
                {
                    throw new ArgumentException($"Неизвестная таблица: {tableName}");
                }

                // Формируем SQL-запрос
                string query = $"SELECT {priceColumn} FROM {tableName} WHERE {idColumnName} = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", itemId);

                    object result = command.ExecuteScalar();
                    if (result != null && decimal.TryParse(result.ToString(), out decimal price))
                    {
                        return price;
                    }
                    else
                    {
                        MessageBox.Show($"Не удалось найти запись в таблице {tableName} с ID = {itemId}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении цены из таблицы {tableName}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Вспомогательный метод для парсинга целых чисел
        private int ParseInt(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out int result))
            {
                MessageBox.Show($"Некорректное значение для поля {fieldName}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            return result;
        }

        // Вспомогательный метод для парсинга даты
        private DateTime ParseDateTime(string value)
        {
            if (string.IsNullOrEmpty(value) || !DateTime.TryParse(value, out DateTime result))
            {
                return DateTime.Now; // Возвращаем текущую дату, если значение некорректно
            }
            return result;
        }
    }
}