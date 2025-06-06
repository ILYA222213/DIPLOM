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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Sklad1
{
    public partial class AdminForm : Form
    {
        private string connectionString = "Server=(local);Database=ServiceBD;Trusted_Connection=True"; // Замените на вашу строку подключения

        public AdminForm()
        {
            InitializeComponent();
            LoadDataToTabs();
        }

        private void LoadDataToTabs()
        {
            // Загружаем данные для каждой таблицы
            LoadDataToDataGridView("Клиенты", dataGridViewClients);
            AdjustColumnWidths(dataGridViewClients);

            LoadDataToDataGridView("Сотрудники", dataGridViewEmployees);
            AdjustColumnWidths(dataGridViewEmployees);

            LoadDataToDataGridView("Роль", dataGridViewRoles);
            AdjustColumnWidths(dataGridViewRoles);

            LoadDataToDataGridView("Аутентификация", dataGridViewAuth);
            AdjustColumnWidths(dataGridViewAuth);

            LoadDataToDataGridView("Услуги", dataGridViewServices);
            AdjustColumnWidths(dataGridViewServices);

            LoadDataToDataGridView("Запчасти", dataGridViewParts);
            AdjustColumnWidths(dataGridViewParts);

            LoadDataToDataGridView("Поставщики", dataGridViewSuppliers);
            AdjustColumnWidths(dataGridViewSuppliers);

            LoadDataToDataGridView("Поставки", dataGridViewShipments);
            AdjustColumnWidths(dataGridViewShipments);

            LoadDataToDataGridView("Заказы", dataGridViewOrders);
            AdjustColumnWidths(dataGridViewOrders);

            LoadDataToDataGridView("Техника", dataGridViewEquipment);
            AdjustColumnWidths(dataGridViewEquipment);

            LoadDataToDataGridView("Оплата", dataGridViewPayments);
            AdjustColumnWidths(dataGridViewPayments);

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

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

       

        private bool AreAllRowsFilled()
        {
            // Список всех DataGridView на форме
            var dataGrids = new List<DataGridView>
    {
                dataGridViewClients,
                dataGridViewEmployees,
                dataGridViewRoles,
                dataGridViewAuth,
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

       
        private DataGridView GetActiveDataGridView()
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: return dataGridViewClients;
                case 1: return dataGridViewEmployees;
                case 2: return dataGridViewRoles;
                case 3: return dataGridViewAuth;
                case 4: return dataGridViewServices;
                case 5: return dataGridViewParts;
                case 6: return dataGridViewSuppliers;
                case 7: return dataGridViewShipments;
                case 8: return dataGridViewOrders;
                case 9: return dataGridViewEquipment;
                case 10: return dataGridViewPayments;
                default: return null;
            }
        }

        
        private void AdjustColumnWidths(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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

                        case "Техника":
                            query = $@"
                        SELECT 
                        '{tableName}' AS Таблица, 
                         {idColumn} AS ID, 
                         CONCAT(Описание, ' (Количество: ', Количество, ')') AS Информация
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

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавляем параметры
                    if (int.TryParse(searchText, out _) || decimal.TryParse(searchText, out _))
                    {
                        command.Parameters.AddWithValue("@SearchValue", int.TryParse(searchText, out _) ? (object)searchText : (object)decimal.Parse(searchText));
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@SearchValue", $"%{searchText}%");
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = resultTable.NewRow();
                            row["Таблица"] = reader["Таблица"];
                            row["ID"] = reader["ID"];
                            row["Информация"] = reader["Информация"];

                            // Добавляем дополнительные столбцы, если они есть
                            if (reader.FieldCount > 3)
                            {
                                for (int i = 3; i < reader.FieldCount; i++)
                                {
                                    string columnName = reader.GetName(i);

                                    // Проверяем, существует ли колонка в resultTable
                                    if (!resultTable.Columns.Contains(columnName))
                                    {
                                        resultTable.Columns.Add(columnName, reader.GetFieldType(i));
                                    }

                                    row[columnName] = reader[columnName];
                                }
                            }

                            resultTable.Rows.Add(row);
                        }
                    }
                }
            }
        }
        

        private void AdminForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnSaveChanges_Click_1(object sender, EventArgs e)
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
                SaveChangesToDatabase("Роль", dataGridViewRoles);
                SaveChangesToDatabase("Аутентификация", dataGridViewAuth);
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

        private void btnDelete_Click_1(object sender, EventArgs e)
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
                SearchInTable(resultTable, "Роль", "ID_роли", "Наименование", searchText);
                SearchInTable(resultTable, "Аутентификация", "ID_аутентификации", "Логин", searchText);
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

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


