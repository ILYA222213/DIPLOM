using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sklad1
{
    public partial class MasterForm : Form
    {
        private string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True;";

        public MasterForm()
        {
            InitializeComponent();
            LoadDataToTabs();
            InitializeComboBoxStatus(); // Инициализация ComboBox со статусами
        }

        private void LoadDataToTabs()
        {
            LoadDataToDataGridView("Заказы", dataGridViewOrders);
            LoadDataToDataGridView("Запчасти", dataGridViewParts);
            LoadDataToDataGridView("Клиенты", dataGridViewClient);
            LoadDataToDataGridView("Техника", dataGridViewEquipment);
            LoadDataToDataGridView("Услуги", dataGridViewServices);
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            // Дополнительная логика при загрузке формы (если требуется)
        }

        private void LoadDataToDataGridView(string tableName, DataGridView dataGridView)
        {
            try
            {
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

        private void InitializeComboBoxStatus()
        {
            // Заполняем ComboBox возможными статусами
            comboBox1.Items.AddRange(new string[] { "Готов", "Принят", "В работе", "Отменен" });
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // Запрещаем ручной ввод
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Логика при изменении выбора в ComboBox (если требуется)
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void dataGridViewShipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click_Click(object sender, EventArgs e)
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
                SearchInTable(resultTable, "Услуги", "ID_услуги", "Наименование", searchText);
                SearchInTable(resultTable, "Запчасти", "ID_запчасти", "Наименование", searchText);
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

    }
}