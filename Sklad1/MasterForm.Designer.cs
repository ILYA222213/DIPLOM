namespace Sklad1
{
    partial class MasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.tabPageParts = new System.Windows.Forms.TabPage();
            this.dataGridViewParts = new System.Windows.Forms.DataGridView();
            this.tabPageClient = new System.Windows.Forms.TabPage();
            this.dataGridViewClient = new System.Windows.Forms.DataGridView();
            this.tabPageEquipment = new System.Windows.Forms.TabPage();
            this.dataGridViewEquipment = new System.Windows.Forms.DataGridView();
            this.tabPageServices = new System.Windows.Forms.TabPage();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.btnSearch_Click = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.tabPageParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).BeginInit();
            this.tabPageClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).BeginInit();
            this.tabPageEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).BeginInit();
            this.tabPageServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOrders);
            this.tabControl.Controls.Add(this.tabPageParts);
            this.tabControl.Controls.Add(this.tabPageClient);
            this.tabControl.Controls.Add(this.tabPageEquipment);
            this.tabControl.Controls.Add(this.tabPageServices);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.textBoxSearch);
            this.tabPageOrders.Controls.Add(this.btnSearch_Click);
            this.tabPageOrders.Controls.Add(this.button1);
            this.tabPageOrders.Controls.Add(this.comboBox1);
            this.tabPageOrders.Controls.Add(this.dataGridViewOrders);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(792, 424);
            this.tabPageOrders.TabIndex = 0;
            this.tabPageOrders.Text = "Заказы";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Изменить статус";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(499, 297);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.Size = new System.Drawing.Size(786, 260);
            this.dataGridViewOrders.TabIndex = 0;
            // 
            // tabPageParts
            // 
            this.tabPageParts.Controls.Add(this.dataGridViewParts);
            this.tabPageParts.Location = new System.Drawing.Point(4, 22);
            this.tabPageParts.Name = "tabPageParts";
            this.tabPageParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParts.Size = new System.Drawing.Size(792, 424);
            this.tabPageParts.TabIndex = 1;
            this.tabPageParts.Text = "Запчасти";
            this.tabPageParts.UseVisualStyleBackColor = true;
            // 
            // dataGridViewParts
            // 
            this.dataGridViewParts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParts.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewParts.Name = "dataGridViewParts";
            this.dataGridViewParts.Size = new System.Drawing.Size(786, 260);
            this.dataGridViewParts.TabIndex = 0;
            // 
            // tabPageClient
            // 
            this.tabPageClient.Controls.Add(this.dataGridViewClient);
            this.tabPageClient.Location = new System.Drawing.Point(4, 22);
            this.tabPageClient.Name = "tabPageClient";
            this.tabPageClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClient.Size = new System.Drawing.Size(792, 424);
            this.tabPageClient.TabIndex = 2;
            this.tabPageClient.Text = "Клиенты";
            this.tabPageClient.UseVisualStyleBackColor = true;
            // 
            // dataGridViewClient
            // 
            this.dataGridViewClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClient.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewClient.Name = "dataGridViewClient";
            this.dataGridViewClient.Size = new System.Drawing.Size(786, 260);
            this.dataGridViewClient.TabIndex = 0;
            // 
            // tabPageEquipment
            // 
            this.tabPageEquipment.Controls.Add(this.dataGridViewEquipment);
            this.tabPageEquipment.Location = new System.Drawing.Point(4, 22);
            this.tabPageEquipment.Name = "tabPageEquipment";
            this.tabPageEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEquipment.Size = new System.Drawing.Size(792, 424);
            this.tabPageEquipment.TabIndex = 3;
            this.tabPageEquipment.Text = "Техника";
            this.tabPageEquipment.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEquipment
            // 
            this.dataGridViewEquipment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEquipment.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewEquipment.Name = "dataGridViewEquipment";
            this.dataGridViewEquipment.Size = new System.Drawing.Size(786, 260);
            this.dataGridViewEquipment.TabIndex = 0;
            // 
            // tabPageServices
            // 
            this.tabPageServices.Controls.Add(this.dataGridViewServices);
            this.tabPageServices.Location = new System.Drawing.Point(4, 22);
            this.tabPageServices.Name = "tabPageServices";
            this.tabPageServices.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServices.Size = new System.Drawing.Size(792, 424);
            this.tabPageServices.TabIndex = 4;
            this.tabPageServices.Text = "Услуги";
            this.tabPageServices.UseVisualStyleBackColor = true;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.Size = new System.Drawing.Size(786, 260);
            this.dataGridViewServices.TabIndex = 0;
            // 
            // btnSearch_Click
            // 
            this.btnSearch_Click.Location = new System.Drawing.Point(226, 288);
            this.btnSearch_Click.Name = "btnSearch_Click";
            this.btnSearch_Click.Size = new System.Drawing.Size(111, 40);
            this.btnSearch_Click.TabIndex = 3;
            this.btnSearch_Click.Text = "Найти";
            this.btnSearch_Click.UseVisualStyleBackColor = true;
            this.btnSearch_Click.Click += new System.EventHandler(this.btnSearch_Click_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(8, 297);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(200, 20);
            this.textBoxSearch.TabIndex = 4;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MasterForm";
            this.Text = "Мастер";
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            this.tabPageOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.tabPageParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).EndInit();
            this.tabPageClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClient)).EndInit();
            this.tabPageEquipment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEquipment)).EndInit();
            this.tabPageServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.TabPage tabPageParts;
        private System.Windows.Forms.DataGridView dataGridViewParts;
        private System.Windows.Forms.TabPage tabPageClient;
        private System.Windows.Forms.DataGridView dataGridViewClient;
        private System.Windows.Forms.TabPage tabPageEquipment;
        private System.Windows.Forms.DataGridView dataGridViewEquipment;
        private System.Windows.Forms.TabPage tabPageServices;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSearch_Click;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}