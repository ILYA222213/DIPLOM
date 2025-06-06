namespace Sklad1
{
    partial class GLMaster
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.tabPageEquipment = new System.Windows.Forms.TabPage();
            this.dataGridViewEquipment = new System.Windows.Forms.DataGridView();
            this.tabPageShipments = new System.Windows.Forms.TabPage();
            this.dataGridViewShipments = new System.Windows.Forms.DataGridView();
            this.tabPageParts = new System.Windows.Forms.TabPage();
            this.dataGridViewParts = new System.Windows.Forms.DataGridView();
            this.tabPageEmployees = new System.Windows.Forms.TabPage();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.tabPageServices = new System.Windows.Forms.TabPage();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxMasters = new System.Windows.Forms.ComboBox();
            this.btnAssignMaster = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.tabPageEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).BeginInit();
            this.tabPageShipments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShipments)).BeginInit();
            this.tabPageParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).BeginInit();
            this.tabPageEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            this.tabPageServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl.Controls.Add(this.tabPageOrders);
            this.tabControl.Controls.Add(this.tabPageClients);
            this.tabControl.Controls.Add(this.tabPageEquipment);
            this.tabControl.Controls.Add(this.tabPageShipments);
            this.tabControl.Controls.Add(this.tabPageParts);
            this.tabControl.Controls.Add(this.tabPageEmployees);
            this.tabControl.Controls.Add(this.tabPageServices);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 283);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.dataGridViewOrders);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(792, 257);
            this.tabPageOrders.TabIndex = 0;
            this.tabPageOrders.Text = "Заказы";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOrders.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.Size = new System.Drawing.Size(786, 251);
            this.dataGridViewOrders.TabIndex = 0;
            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.dataGridViewClients);
            this.tabPageClients.Location = new System.Drawing.Point(4, 22);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClients.Size = new System.Drawing.Size(792, 257);
            this.tabPageClients.TabIndex = 1;
            this.tabPageClients.Text = "Клиенты";
            this.tabPageClients.UseVisualStyleBackColor = true;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClients.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.Size = new System.Drawing.Size(786, 251);
            this.dataGridViewClients.TabIndex = 0;
            // 
            // tabPageEquipment
            // 
            this.tabPageEquipment.Controls.Add(this.dataGridViewEquipment);
            this.tabPageEquipment.Location = new System.Drawing.Point(4, 22);
            this.tabPageEquipment.Name = "tabPageEquipment";
            this.tabPageEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEquipment.Size = new System.Drawing.Size(792, 257);
            this.tabPageEquipment.TabIndex = 2;
            this.tabPageEquipment.Text = "Техника";
            this.tabPageEquipment.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEquipment
            // 
            this.dataGridViewEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEquipment.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewEquipment.Name = "dataGridViewEquipment";
            this.dataGridViewEquipment.Size = new System.Drawing.Size(786, 251);
            this.dataGridViewEquipment.TabIndex = 0;
            // 
            // tabPageShipments
            // 
            this.tabPageShipments.Controls.Add(this.dataGridViewShipments);
            this.tabPageShipments.Location = new System.Drawing.Point(4, 22);
            this.tabPageShipments.Name = "tabPageShipments";
            this.tabPageShipments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShipments.Size = new System.Drawing.Size(792, 257);
            this.tabPageShipments.TabIndex = 3;
            this.tabPageShipments.Text = "Поставки";
            this.tabPageShipments.UseVisualStyleBackColor = true;
            // 
            // dataGridViewShipments
            // 
            this.dataGridViewShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShipments.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewShipments.Name = "dataGridViewShipments";
            this.dataGridViewShipments.Size = new System.Drawing.Size(786, 251);
            this.dataGridViewShipments.TabIndex = 0;
            // 
            // tabPageParts
            // 
            this.tabPageParts.Controls.Add(this.dataGridViewParts);
            this.tabPageParts.Location = new System.Drawing.Point(4, 22);
            this.tabPageParts.Name = "tabPageParts";
            this.tabPageParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParts.Size = new System.Drawing.Size(792, 257);
            this.tabPageParts.TabIndex = 4;
            this.tabPageParts.Text = "Запчасти";
            this.tabPageParts.UseVisualStyleBackColor = true;
            // 
            // dataGridViewParts
            // 
            this.dataGridViewParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewParts.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewParts.Name = "dataGridViewParts";
            this.dataGridViewParts.Size = new System.Drawing.Size(786, 251);
            this.dataGridViewParts.TabIndex = 0;
            // 
            // tabPageEmployees
            // 
            this.tabPageEmployees.Controls.Add(this.dataGridViewEmployees);
            this.tabPageEmployees.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployees.Size = new System.Drawing.Size(792, 257);
            this.tabPageEmployees.TabIndex = 5;
            this.tabPageEmployees.Text = "Сотрудники";
            this.tabPageEmployees.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new System.Drawing.Size(786, 251);
            this.dataGridViewEmployees.TabIndex = 0;
            // 
            // tabPageServices
            // 
            this.tabPageServices.Controls.Add(this.dataGridViewServices);
            this.tabPageServices.Location = new System.Drawing.Point(4, 22);
            this.tabPageServices.Name = "tabPageServices";
            this.tabPageServices.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServices.Size = new System.Drawing.Size(792, 257);
            this.tabPageServices.TabIndex = 6;
            this.tabPageServices.Text = "Услуги";
            this.tabPageServices.UseVisualStyleBackColor = true;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewServices.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.Size = new System.Drawing.Size(786, 251);
            this.dataGridViewServices.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(12, 305);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(200, 20);
            this.textBoxSearch.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(541, 300);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(681, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Изменить статус";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxMasters
            // 
            this.comboBoxMasters.FormattingEnabled = true;
            this.comboBoxMasters.Location = new System.Drawing.Point(541, 344);
            this.comboBoxMasters.Name = "comboBoxMasters";
            this.comboBoxMasters.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMasters.TabIndex = 5;
            this.comboBoxMasters.SelectedIndexChanged += new System.EventHandler(this.comboBoxMasters_SelectedIndexChanged);
            // 
            // btnAssignMaster
            // 
            this.btnAssignMaster.Location = new System.Drawing.Point(681, 342);
            this.btnAssignMaster.Name = "btnAssignMaster";
            this.btnAssignMaster.Size = new System.Drawing.Size(75, 23);
            this.btnAssignMaster.TabIndex = 6;
            this.btnAssignMaster.Text = "Назначить";
            this.btnAssignMaster.UseVisualStyleBackColor = true;
            this.btnAssignMaster.Click += new System.EventHandler(this.btnAssignMaster_Click);
            // 
            // GLMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAssignMaster);
            this.Controls.Add(this.comboBoxMasters);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl);
            this.Name = "GLMaster";
            this.Text = "Главный мастер";
            this.tabControl.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.tabPageClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.tabPageEquipment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).EndInit();
            this.tabPageShipments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShipments)).EndInit();
            this.tabPageParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).EndInit();
            this.tabPageEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            this.tabPageServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.TabPage tabPageEquipment;
        private System.Windows.Forms.DataGridView dataGridViewEquipment;
        private System.Windows.Forms.TabPage tabPageShipments;
        private System.Windows.Forms.DataGridView dataGridViewShipments;
        private System.Windows.Forms.TabPage tabPageParts;
        private System.Windows.Forms.DataGridView dataGridViewParts;
        private System.Windows.Forms.TabPage tabPageEmployees;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.TabPage tabPageServices;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxMasters;
        private System.Windows.Forms.Button btnAssignMaster;
    }
}