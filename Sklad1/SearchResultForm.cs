using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklad1
{
    public partial class SearchResultForm : Form
    {
        // Свойство для доступа к DataGridView
        public DataGridView DataGridViewResults => dataGridViewResults;

        public SearchResultForm(DataTable data)
        {
            InitializeComponent(); // Вызываем автоматически сгенерированный метод
            LoadDataToDataGridView(data); // Загружаем данные в DataGridView
        }

        private void LoadDataToDataGridView(DataTable data)
        {
            this.dataGridViewResults.DataSource = data; // Привязываем данные к DataGridView

            // Список колонок для проверки
            List<string> columnsToCheck = new List<string> { "Количество", "Сумма", "Цена", "Роль" };

            foreach (string columnName in columnsToCheck)
            {
                if (dataGridViewResults.Columns.Contains(columnName))
                {
                    bool hasData = false;

                    foreach (DataGridViewRow row in dataGridViewResults.Rows)
                    {
                        if (row.Cells[columnName].Value != null && !string.IsNullOrEmpty(row.Cells[columnName].Value.ToString()))
                        {
                            hasData = true;
                            break;
                        }
                    }

                    // Если колонка пустая, скрываем её
                    if (!hasData)
                    {
                        dataGridViewResults.Columns[columnName].Visible = false;
                    }
                }
            }

            // Настройка автоширины колонок
            foreach (DataGridViewColumn column in dataGridViewResults.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем текущую форму
        }

        private void SearchResultForm_Load(object sender, EventArgs e)
        {
            // Здесь можно добавить дополнительные действия при загрузке формы
        }
    }
}