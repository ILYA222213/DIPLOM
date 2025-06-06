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
    public partial class ManagerForm : Form
    {
        private string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True"; // Замените на вашу строку подключения
        public ManagerForm()
        {
            InitializeComponent();
            LoadDataToTabs();
        }
        private void LoadDataToTabs()
        {
            // Загружаем данные для каждой таблицы
            LoadDataToDataGridView("Клиенты", dataGridViewClients);
            AdjustColumnWidths(dataGridViewClients);

            LoadDataToDataGridView("Услуги", dataGridViewServices);
            AdjustColumnWidths(dataGridViewServices);

            LoadDataToDataGridView("Заказы", dataGridViewOrders);
            AdjustColumnWidths(dataGridViewOrders);

            LoadDataToDataGridView("Техника", dataGridViewEquipment);
            AdjustColumnWidths(dataGridViewEquipment);

            LoadDataToDataGridView("Оплата", dataGridViewPayments);
            AdjustColumnWidths(dataGridViewPayments);

            LoadDataToDataGridView("Запчасти", dataGridViewParts);
            AdjustColumnWidths(dataGridViewParts);


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

        public void RefreshDataGridViewOrders()
        {
            LoadDataToDataGridView("Заказы", dataGridViewOrders);
        } 
        
        public void RefreshDataGridViewEquipment()
        {
            try
            {
                string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Техника"; // Запрос для загрузки данных из таблицы "Техника"
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewEquipment.DataSource = dataTable; // Обновляем источник данных DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdjustColumnWidths(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm(this); // Передаем ссылку на ManagerForm
            addOrderForm.ShowDialog();
        }

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void RefreshDataGridViewClients()
        {
            LoadDataToDataGridView("Клиенты", dataGridViewClients);
        }
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient (this); // Передаем ссылку на ManagerForm
            addClient.ShowDialog();
        }

        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            AddEquipment addEquipment = new AddEquipment(this); // Передаем ссылку на ManagerForm
            addEquipment.ShowDialog();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

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
    }
    }

