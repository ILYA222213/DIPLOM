using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Sklad1
{
    public partial class GLManager : Form
    {
        private string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True"; // Замените на вашу строку подключения

        public GLManager()
        {
            InitializeComponent();
            LoadDataToTabs();
            dataGridViewOrders.CellEndEdit += dataGridViewOrders_CellEndEdit;
        }
        public void RefreshDataGridViewOrders()
        {
            LoadDataToDataGridView("Заказы", dataGridViewOrders);
        }
        public void RefreshDataGridViewClients()
        {
            LoadDataToDataGridView("Клиенты", dataGridViewClients);
        }
        public void RefreshDataGridViewEquipment()
        {
            LoadDataToDataGridView("Техника", dataGridViewEquipment);
        }
        public void RefreshDataGridViewSuppliers()
        {
            LoadDataToDataGridView("Поставщики", dataGridViewSuppliers);
        }

        private void GLManager_Load(object sender, EventArgs e)
        {
            LoadDataToTabs();
            dataGridViewClients.ReadOnly = false;
            dataGridViewSuppliers.ReadOnly = false;
            dataGridViewShipments.ReadOnly = false;
            dataGridViewOrders.ReadOnly = false;
            dataGridViewEmployees.ReadOnly = false;
            dataGridViewServices.ReadOnly = false;
            dataGridViewEquipment.ReadOnly = false;
            dataGridViewPayments.ReadOnly = false;
            dataGridViewParts.ReadOnly = false;
        }

        private void LoadDataToTabs()
        {
            LoadDataToDataGridView("Заказы", dataGridViewOrders);
            LoadDataToDataGridView("Сотрудники", dataGridViewEmployees);
            LoadDataToDataGridView("Услуги", dataGridViewServices);
            LoadDataToDataGridView("Клиенты", dataGridViewClients);
            LoadDataToDataGridView("Техника", dataGridViewEquipment);
            LoadDataToDataGridView("Оплата", dataGridViewPayments);
            LoadDataToDataGridView("Поставки", dataGridViewShipments);
            LoadDataToDataGridView("Поставщики", dataGridViewSuppliers);
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
        private void dataGridViewOrders_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что изменение произошло в колонке "Количество"
            if (dataGridViewOrders.Columns[e.ColumnIndex].Name == "Количество")
            {
                // Получаем ID товара и введенное количество
                int idProduct;
                int quantity;

                // Пробуем получить значения из ячеек
                if (int.TryParse(dataGridViewOrders.Rows[e.RowIndex].Cells["ID_товара"].Value?.ToString(), out idProduct) &&
                    int.TryParse(dataGridViewOrders.Rows[e.RowIndex].Cells["Количество"].Value?.ToString(), out quantity))
                {
                    try
                    {
                        // Получаем цену товара из базы данных
                        decimal price = GetProductPriceById(idProduct);

                        // Рассчитываем сумму
                        decimal totalSum = quantity * price;

                        // Записываем сумму в колонку "Сумма"
                        dataGridViewOrders.Rows[e.RowIndex].Cells["Сумма"].Value = totalSum;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при расчете суммы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Неверные данные в колонках 'ID товара' или 'Количество'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private decimal GetProductPriceById(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Цена FROM Товары WHERE ID_товара = @ProductId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                object result = command.ExecuteScalar();

                if (result != null && decimal.TryParse(result.ToString(), out decimal price))
                {
                    return price;
                }
                else
                {
                    throw new Exception("Цена товара не найдена.");
                }
            }
        }

        

        // Новый код для поиска данных
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
                SearchInTable(resultTable, "Поставщики", "ID_поставщика", "Наименование", searchText);
                SearchInTable(resultTable, "Поставки", "ID_поставки", "Дата_поставки", searchText);
                SearchInTable(resultTable, "Заказы", "ID_заказа", "Сумма", searchText);
                SearchInTable(resultTable, "Техника", "ID_техники", "Количество", searchText);
                SearchInTable(resultTable, "Оплата", "ID_оплаты", "Способ", searchText);

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

                        case "Клиенты":
                            query = $@"
SELECT 
    '{tableName}' AS Таблица, 
    ID_клиента AS ID, 
    CONCAT(ФИО, ' (Телефон: ', Телефон, ')') AS Информация,
    ID_техники
FROM {tableName}
WHERE ФИО LIKE @SearchValue OR Телефон LIKE @SearchValue OR CAST(ID_техники AS NVARCHAR) LIKE @SearchValue";
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

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddOrder_Click_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm(this); // Передаем ссылку на GLManager
            addOrderForm.ShowDialog();
        }

        private DataGridView GetActiveDataGridView()
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: return dataGridViewClients;
                case 1: return dataGridViewEmployees;
                case 2: return dataGridViewServices;
                case 3: return dataGridViewParts;
                case 4: return dataGridViewSuppliers;
                case 5: return dataGridViewShipments;
                case 6: return dataGridViewOrders;
                case 7: return dataGridViewEquipment;
                case 8: return dataGridViewPayments;
                default: return null;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Получаем активный DataGridView
            DataGridView activeDataGridView = GetActiveDataGridView();

            if (activeDataGridView == null || activeDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (DataGridViewRow row in activeDataGridView.SelectedRows)
                {
                    activeDataGridView.Rows.Remove(row); // Удаляем строку из DataGridView
                }

                MessageBox.Show("Строка успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveChangesToDatabase(string tableName, DataGridView dataGridView)
        {
            if (dataGridView.DataSource is DataTable dataTable)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {tableName}", connection);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    // Обновляем данные в базе данных
                    adapter.Update(dataTable);
                }
            }
        }
        private bool AreAllRowsFilled()
        {
            // Список всех DataGridView на форме
            var dataGrids = new List<DataGridView>
    {
                dataGridViewClients,
                dataGridViewServices,
                dataGridViewParts,
                dataGridViewSuppliers,
                dataGridViewShipments,
                dataGridViewOrders,
                dataGridViewEquipment,
                dataGridViewPayments
    };

            foreach (var dataGridView in dataGrids)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    // Пропускаем новую пустую строку в конце DataGridView
                    if (row.IsNewRow) continue;

                    // Проверяем каждую ячейку в строке
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        {
                            return false; // Если найдена пустая ячейка, возвращаем false
                        }
                    }
                }
            }

            return true; // Все строки заполнены
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Проверяем заполненность данных
            if (!AreAllRowsFilled())
            {
                MessageBox.Show("Пожалуйста, проверьте заполнение данных. Все поля должны быть заполнены.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveChangesToDatabase("Клиенты", dataGridViewClients);
                SaveChangesToDatabase("Сотрудники", dataGridViewEmployees);
                SaveChangesToDatabase("Услуги", dataGridViewServices);
                SaveChangesToDatabase("Запчасти", dataGridViewParts);
                SaveChangesToDatabase("Поставщики", dataGridViewSuppliers);
                SaveChangesToDatabase("Поставки", dataGridViewShipments);
                SaveChangesToDatabase("Заказы", dataGridViewOrders);
                SaveChangesToDatabase("Техника", dataGridViewEquipment);
                SaveChangesToDatabase("Оплата", dataGridViewPayments);

                MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}