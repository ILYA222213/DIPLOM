namespace Sklad1
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.tabPageEmployees = new System.Windows.Forms.TabPage();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.tabPageRoles = new System.Windows.Forms.TabPage();
            this.dataGridViewRoles = new System.Windows.Forms.DataGridView();
            this.tabPageAuth = new System.Windows.Forms.TabPage();
            this.dataGridViewAuth = new System.Windows.Forms.DataGridView();
            this.tabPageServices = new System.Windows.Forms.TabPage();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.tabPageParts = new System.Windows.Forms.TabPage();
            this.dataGridViewParts = new System.Windows.Forms.DataGridView();
            this.tabPageSuppliers = new System.Windows.Forms.TabPage();
            this.dataGridViewSuppliers = new System.Windows.Forms.DataGridView();
            this.tabPageShipments = new System.Windows.Forms.TabPage();
            this.dataGridViewShipments = new System.Windows.Forms.DataGridView();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.tabPageEquipment = new System.Windows.Forms.TabPage();
            this.dataGridViewEquipment = new System.Windows.Forms.DataGridView();
            this.tabPagePayments = new System.Windows.Forms.TabPage();
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.tabPageEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.tabPageRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).BeginInit();
            this.tabPageAuth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuth)).BeginInit();
            this.tabPageServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.tabPageParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).BeginInit();
            this.tabPageSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).BeginInit();
            this.tabPageShipments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShipments)).BeginInit();
            this.tabPageOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.tabPageEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).BeginInit();
            this.tabPagePayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageClients);
            this.tabControl.Controls.Add(this.tabPageEmployees);
            this.tabControl.Controls.Add(this.tabPageRoles);
            this.tabControl.Controls.Add(this.tabPageAuth);
            this.tabControl.Controls.Add(this.tabPageServices);
            this.tabControl.Controls.Add(this.tabPageParts);
            this.tabControl.Controls.Add(this.tabPageSuppliers);
            this.tabControl.Controls.Add(this.tabPageShipments);
            this.tabControl.Controls.Add(this.tabPageOrders);
            this.tabControl.Controls.Add(this.tabPageEquipment);
            this.tabControl.Controls.Add(this.tabPagePayments);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 350);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.dataGridViewClients);
            this.tabPageClients.Location = new System.Drawing.Point(4, 22);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClients.Size = new System.Drawing.Size(792, 324);
            this.tabPageClients.TabIndex = 0;
            this.tabPageClients.Text = "Клиенты";
            this.tabPageClients.UseVisualStyleBackColor = true;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClients.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewClients.TabIndex = 0;
            this.dataGridViewClients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClients_CellContentClick);
            // 
            // tabPageEmployees
            // 
            this.tabPageEmployees.Controls.Add(this.dataGridViewEmployees);
            this.tabPageEmployees.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployees.Size = new System.Drawing.Size(792, 324);
            this.tabPageEmployees.TabIndex = 1;
            this.tabPageEmployees.Text = "Сотрудники";
            this.tabPageEmployees.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewEmployees.TabIndex = 0;
            // 
            // tabPageRoles
            // 
            this.tabPageRoles.Controls.Add(this.dataGridViewRoles);
            this.tabPageRoles.Location = new System.Drawing.Point(4, 22);
            this.tabPageRoles.Name = "tabPageRoles";
            this.tabPageRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRoles.Size = new System.Drawing.Size(792, 324);
            this.tabPageRoles.TabIndex = 2;
            this.tabPageRoles.Text = "Роли";
            this.tabPageRoles.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRoles
            // 
            this.dataGridViewRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRoles.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRoles.Name = "dataGridViewRoles";
            this.dataGridViewRoles.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewRoles.TabIndex = 0;
            // 
            // tabPageAuth
            // 
            this.tabPageAuth.Controls.Add(this.dataGridViewAuth);
            this.tabPageAuth.Location = new System.Drawing.Point(4, 22);
            this.tabPageAuth.Name = "tabPageAuth";
            this.tabPageAuth.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuth.Size = new System.Drawing.Size(792, 324);
            this.tabPageAuth.TabIndex = 3;
            this.tabPageAuth.Text = "Аутентификация";
            this.tabPageAuth.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAuth
            // 
            this.dataGridViewAuth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAuth.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAuth.Name = "dataGridViewAuth";
            this.dataGridViewAuth.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewAuth.TabIndex = 0;
            // 
            // tabPageServices
            // 
            this.tabPageServices.Controls.Add(this.dataGridViewServices);
            this.tabPageServices.Location = new System.Drawing.Point(4, 22);
            this.tabPageServices.Name = "tabPageServices";
            this.tabPageServices.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServices.Size = new System.Drawing.Size(792, 324);
            this.tabPageServices.TabIndex = 4;
            this.tabPageServices.Text = "Услуги";
            this.tabPageServices.UseVisualStyleBackColor = true;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewServices.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewServices.TabIndex = 0;
            // 
            // tabPageParts
            // 
            this.tabPageParts.Controls.Add(this.dataGridViewParts);
            this.tabPageParts.Location = new System.Drawing.Point(4, 22);
            this.tabPageParts.Name = "tabPageParts";
            this.tabPageParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParts.Size = new System.Drawing.Size(792, 324);
            this.tabPageParts.TabIndex = 5;
            this.tabPageParts.Text = "Запчасти";
            this.tabPageParts.UseVisualStyleBackColor = true;
            // 
            // dataGridViewParts
            // 
            this.dataGridViewParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewParts.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewParts.Name = "dataGridViewParts";
            this.dataGridViewParts.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewParts.TabIndex = 0;
            // 
            // tabPageSuppliers
            // 
            this.tabPageSuppliers.Controls.Add(this.dataGridViewSuppliers);
            this.tabPageSuppliers.Location = new System.Drawing.Point(4, 22);
            this.tabPageSuppliers.Name = "tabPageSuppliers";
            this.tabPageSuppliers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSuppliers.Size = new System.Drawing.Size(792, 324);
            this.tabPageSuppliers.TabIndex = 6;
            this.tabPageSuppliers.Text = "Поставщики";
            this.tabPageSuppliers.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSuppliers
            // 
            this.dataGridViewSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSuppliers.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            this.dataGridViewSuppliers.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewSuppliers.TabIndex = 0;
            // 
            // tabPageShipments
            // 
            this.tabPageShipments.Controls.Add(this.dataGridViewShipments);
            this.tabPageShipments.Location = new System.Drawing.Point(4, 22);
            this.tabPageShipments.Name = "tabPageShipments";
            this.tabPageShipments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShipments.Size = new System.Drawing.Size(792, 324);
            this.tabPageShipments.TabIndex = 7;
            this.tabPageShipments.Text = "Поставки";
            this.tabPageShipments.UseVisualStyleBackColor = true;
            // 
            // dataGridViewShipments
            // 
            this.dataGridViewShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShipments.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewShipments.Name = "dataGridViewShipments";
            this.dataGridViewShipments.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewShipments.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.dataGridViewOrders);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(792, 324);
            this.tabPageOrders.TabIndex = 8;
            this.tabPageOrders.Text = "Заказы";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOrders.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewOrders.TabIndex = 0;
            // 
            // tabPageEquipment
            // 
            this.tabPageEquipment.Controls.Add(this.dataGridViewEquipment);
            this.tabPageEquipment.Location = new System.Drawing.Point(4, 22);
            this.tabPageEquipment.Name = "tabPageEquipment";
            this.tabPageEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEquipment.Size = new System.Drawing.Size(792, 324);
            this.tabPageEquipment.TabIndex = 9;
            this.tabPageEquipment.Text = "Техника";
            this.tabPageEquipment.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEquipment
            // 
            this.dataGridViewEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEquipment.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewEquipment.Name = "dataGridViewEquipment";
            this.dataGridViewEquipment.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewEquipment.TabIndex = 0;
            // 
            // tabPagePayments
            // 
            this.tabPagePayments.Controls.Add(this.dataGridViewPayments);
            this.tabPagePayments.Location = new System.Drawing.Point(4, 22);
            this.tabPagePayments.Name = "tabPagePayments";
            this.tabPagePayments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePayments.Size = new System.Drawing.Size(792, 324);
            this.tabPagePayments.TabIndex = 10;
            this.tabPagePayments.Text = "Оплата";
            this.tabPagePayments.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPayments.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.Size = new System.Drawing.Size(786, 318);
            this.dataGridViewPayments.TabIndex = 0;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(12, 370);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(200, 20);
            this.textBoxSearch.TabIndex = 1;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(680, 365);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(100, 30);
            this.btnSaveChanges.TabIndex = 2;
            this.btnSaveChanges.Text = "Сохранить";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(570, 365);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(220, 365);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.Text = "Админ-панель";
            this.Load += new System.EventHandler(this.AdminForm_Load_1);
            this.tabControl.ResumeLayout(false);
            this.tabPageClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.tabPageEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.tabPageRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).EndInit();
            this.tabPageAuth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuth)).EndInit();
            this.tabPageServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.tabPageParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).EndInit();
            this.tabPageSuppliers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).EndInit();
            this.tabPageShipments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShipments)).EndInit();
            this.tabPageOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.tabPageEquipment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).EndInit();
            this.tabPagePayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        // Элементы управления
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;

        // Вкладки (TabPages)
        private System.Windows.Forms.TabPage tabPageClients;       // "Клиенты"
        private System.Windows.Forms.TabPage tabPageEmployees;     // "Сотрудники"
        private System.Windows.Forms.TabPage tabPageRoles;         // "Роль"
        private System.Windows.Forms.TabPage tabPageAuth;          // "Аутентификация"
        private System.Windows.Forms.TabPage tabPageServices;      // "Услуги"
        private System.Windows.Forms.TabPage tabPageParts;         // "Запчасти"
        private System.Windows.Forms.TabPage tabPageSuppliers;     // "Поставщики"
        private System.Windows.Forms.TabPage tabPageShipments;     // "Поставки"
        private System.Windows.Forms.TabPage tabPageOrders;        // "Заказы"
        private System.Windows.Forms.TabPage tabPageEquipment;     // "Техника"
        private System.Windows.Forms.TabPage tabPagePayments;

        // Таблицы данных (DataGridViews)
        private System.Windows.Forms.DataGridView dataGridViewClients;       // Таблица "Клиенты"
        private System.Windows.Forms.DataGridView dataGridViewEmployees;     // Таблица "Сотрудники"
        private System.Windows.Forms.DataGridView dataGridViewRoles;         // Таблица "Роль"
        private System.Windows.Forms.DataGridView dataGridViewAuth;          // Таблица "Аутентификация"
        private System.Windows.Forms.DataGridView dataGridViewPayments;
        private System.Windows.Forms.DataGridView dataGridViewServices;      // Таблица "Услуги"
        private System.Windows.Forms.DataGridView dataGridViewParts;         // Таблица "Запчасти"
        private System.Windows.Forms.DataGridView dataGridViewSuppliers;     // Таблица "Поставщики"
        private System.Windows.Forms.DataGridView dataGridViewShipments;     // Таблица "Поставки"
        private System.Windows.Forms.DataGridView dataGridViewOrders;        // Таблица "Заказы"
        private System.Windows.Forms.DataGridView dataGridViewEquipment;     // Таблица "Техника"

        // Основной контейнер вкладок
        private System.Windows.Forms.TabControl tabControl;
    }
}