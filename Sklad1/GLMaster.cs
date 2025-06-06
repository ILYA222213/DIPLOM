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
    public partial class GLMaster : Form
    {
        private string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True"; // Замените на вашу строку подключения
        public GLMaster()
        {
            InitializeComponent();
            LoadDataToTabs();
            LoadMastersToComboBox(); // Загружаем данные в ComboBox
            LoadDataToDataGridView("Заказы", dataGridViewOrders);
            InitializeComboBoxStatus();
        }

        private void GLManager_Load(object sender, EventArgs e)
        {
            LoadDataToTabs();
            dataGridViewClients.ReadOnly = false;
            dataGridViewShipments.ReadOnly = false;
            dataGridViewOrders.ReadOnly = false;
            dataGridViewEmployees.ReadOnly = false;
            dataGridViewServices.ReadOnly = false;
            dataGridViewEquipment.ReadOnly = false;
            dataGridViewParts.ReadOnly = false;
        }

        private void InitializeComboBoxStatus()
        {
            // Заполняем ComboBox возможными статусами
            comboBox1.Items.AddRange(new string[] { "Готов", "Принят", "В работе", "Отменен" });
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Запрещаем ручной ввод
        }

        private void LoadDataToTabs()
        {
            LoadDataToDataGridView("Заказы", dataGridViewOrders);
            LoadDataToDataGridView("Сотрудники", dataGridViewEmployees);
            LoadDataToDataGridView("Услуги", dataGridViewServices);
            LoadDataToDataGridView("Клиенты", dataGridViewClients);
            LoadDataToDataGridView("Техника", dataGridViewEquipment);
            LoadDataToDataGridView("Поставки", dataGridViewShipments);
            LoadDataToDataGridView("Запчасти", dataGridViewParts);
        }

        private void LoadDataToDataGridView(string tableName, DataGridView dataGridView)
        {
            try
            {
                string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM {tableName}";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("Таблица", typeof(string));
            resultTable.Columns.Add("ID", typeof(int));
            resultTable.Columns.Add("Информация", typeof(string));

            try
            {
                SearchInTable(resultTable, "Клиенты", "ID_клиента", "ФИО", searchText);
                SearchInTable(resultTable, "Сотрудники", "ID_сотрудника", "ФИО", searchText);
                SearchInTable(resultTable, "Услуги", "ID_услуги", "Наименование", searchText);
                SearchInTable(resultTable, "Запчасти", "ID_запчасти", "Наименование", searchText);
                SearchInTable(resultTable, "Поставки", "ID_поставки", "Дата_поставки", searchText);
                SearchInTable(resultTable, "Заказы", "ID_заказа", "Сумма", searchText);
                SearchInTable(resultTable, "Техника", "ID_техники", "Количество", searchText);

                if (resultTable.Rows.Count == 0)
                {
                    MessageBox.Show("Данные не найдены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SearchResultForm resultForm = new SearchResultForm(resultTable);
                resultForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchInTable(DataTable resultTable, string tableName, string idColumn, string infoColumn, string searchText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query;

                // Если введено число, ищем по ID или числовым полям
                if (int.TryParse(searchText, out int searchId) || decimal.TryParse(searchText, out decimal searchDecimal))
                {
                    switch (tableName)
                    {
                        case "Услуги":
                            query = $@"
                        SELECT '{tableName}' AS Таблица, {idColumn} AS ID, {infoColumn} AS Информация, Цена
                        FROM {tableName}
                        WHERE {idColumn} = @SearchValue OR Цена = @SearchValue";
                            break;

                        case "Запчасти":
                            query = $@"
                        SELECT '{tableName}' AS Таблица, {idColumn} AS ID, {infoColumn} AS Информация, Количество, Цена
                        FROM {tableName}
                        WHERE {idColumn} = @SearchValue OR Количество = @SearchValue OR Цена = @SearchValue";
                            break;

                        case "Заказы":
                            query = $@"
                        SELECT '{tableName}' AS Таблица, {idColumn} AS ID, Сумма AS Информация
                        FROM {tableName}
                        WHERE {idColumn} = @SearchValue OR Сумма = @SearchValue";
                            break;

                        default:
                            query = $@"
                        SELECT '{tableName}' AS Таблица, {idColumn} AS ID, {infoColumn} AS Информация
                        FROM {tableName}
                        WHERE {idColumn} = @SearchValue";
                            break;
                    }
                }
                else
                {
                    // Если введена строка, ищем по текстовым полям
                    switch (tableName)
                    {
                        case "Услуги":
                            query = $@"
                        SELECT '{tableName}' AS Таблица, {idColumn} AS ID, {infoColumn} AS Информация
                        FROM {tableName}
                        WHERE {infoColumn} LIKE @SearchValue OR Описание LIKE @SearchValue";
                            break;

                        case "Запчасти":
                            query = $@"
                        SELECT '{tableName}' AS Таблица, {idColumn} AS ID, {infoColumn} AS Информация
                        FROM {tableName}
                        WHERE {infoColumn} LIKE @SearchValue OR Описание LIKE @SearchValue";
                            break;

                        case "Заказы":
                            query = $@"
                        SELECT '{tableName}' AS Таблица, {idColumn} AS ID, Сумма AS Информация
                        FROM {tableName}
                        WHERE Сумма LIKE @SearchValue OR Описание_проблемы LIKE @SearchValue";
                            break;

                        default:
                            query = $@"
                        SELECT '{tableName}' AS Таблица, {idColumn} AS ID, {infoColumn} AS Информация
                        FROM {tableName}
                        WHERE {infoColumn} LIKE @SearchValue";
                            break;
                    }
                }

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchValue", int.TryParse(searchText, out _) ? (object)searchText : $"%{searchText}%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable tempTable = new DataTable();
                adapter.Fill(tempTable);

                // Добавляем результаты в общую таблицу
                foreach (DataRow row in tempTable.Rows)
                {
                    resultTable.ImportRow(row);
                }
            }
        }

        private void LoadMastersToComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для получения ID сотрудников с ролью "Мастер"
                    string query = @"
                        SELECT Сотрудники.ID_сотрудника, Сотрудники.ФИО 
                        FROM Сотрудники
                        INNER JOIN Роль ON Сотрудники.ID_роли = Роль.ID_роли
                        WHERE Роль.Наименование = 'Мастер'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxMasters.Items.Add($"{reader["ID_сотрудника"]} - {reader["ФИО"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrderStatus(int orderId, string newStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Заказы SET Статус = @NewStatus WHERE ID_заказа = @OrderID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewStatus", newStatus);
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбрана ли строка в DataGridView
                if (dataGridViewOrders.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите заказ для обновления статуса.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Получаем ID выбранного заказа
                int selectedOrderId = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells["ID_заказа"].Value);

                // Получаем новый статус из ComboBox
                string newStatus = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(newStatus))
                {
                    MessageBox.Show("Пожалуйста, выберите новый статус.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Обновляем статус в базе данных
                UpdateOrderStatus(selectedOrderId, newStatus);

                // Обновляем данные в DataGridView
                LoadDataToDataGridView("Заказы", dataGridViewOrders);

                MessageBox.Show("Статус заказа успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении статуса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssignMaster_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, выбран ли мастер
                if (comboBoxMasters.SelectedItem == null)
                {
                    MessageBox.Show("Выберите мастера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Получаем ID выбранного мастера
                string selectedItem = comboBoxMasters.SelectedItem.ToString();
                int selectedMasterId = int.Parse(selectedItem.Split('-')[0].Trim());

                // Проверяем, выбран ли заказ
                if (dataGridViewOrders.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите заказ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int orderId = int.Parse(dataGridViewOrders.SelectedRows[0].Cells["ID_заказа"].Value.ToString());

                // Обновляем запись в таблице "Заказы"
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        UPDATE Заказы 
                        SET ID_сотрудника = @ID_сотрудника 
                        WHERE ID_заказа = @ID_заказа";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID_сотрудника", selectedMasterId);
                        command.Parameters.AddWithValue("@ID_заказа", orderId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Мастер успешно назначен на заказ.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Обновляем DataGridView
                            LoadDataToDataGridView("Заказы", dataGridViewOrders);
                        }
                        else
                        {
                            MessageBox.Show("Не удалось назначить мастера на заказ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxMasters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
