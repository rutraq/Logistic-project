namespace LogisticProgram
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRegistry = new System.Windows.Forms.Button();
            this.buttonDaily = new System.Windows.Forms.Button();
            this.buttonTransport = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelTransport = new System.Windows.Forms.Panel();
            this.dataGridViewTransport = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_shipping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_shipped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelTransport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransport)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRegistry);
            this.panel1.Controls.Add(this.buttonDaily);
            this.panel1.Controls.Add(this.buttonTransport);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 713);
            this.panel1.TabIndex = 0;
            // 
            // buttonRegistry
            // 
            this.buttonRegistry.FlatAppearance.BorderSize = 0;
            this.buttonRegistry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistry.ForeColor = System.Drawing.Color.White;
            this.buttonRegistry.Image = ((System.Drawing.Image)(resources.GetObject("buttonRegistry.Image")));
            this.buttonRegistry.Location = new System.Drawing.Point(0, 374);
            this.buttonRegistry.Name = "buttonRegistry";
            this.buttonRegistry.Size = new System.Drawing.Size(251, 107);
            this.buttonRegistry.TabIndex = 3;
            this.buttonRegistry.Text = "Реестр отгрузки";
            this.buttonRegistry.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonRegistry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonRegistry.UseVisualStyleBackColor = true;
            this.buttonRegistry.Click += new System.EventHandler(this.buttonRegistry_Click);
            // 
            // buttonDaily
            // 
            this.buttonDaily.FlatAppearance.BorderSize = 0;
            this.buttonDaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDaily.ForeColor = System.Drawing.Color.White;
            this.buttonDaily.Image = ((System.Drawing.Image)(resources.GetObject("buttonDaily.Image")));
            this.buttonDaily.Location = new System.Drawing.Point(0, 261);
            this.buttonDaily.Name = "buttonDaily";
            this.buttonDaily.Size = new System.Drawing.Size(251, 107);
            this.buttonDaily.TabIndex = 2;
            this.buttonDaily.Text = "Отгрузка по дням";
            this.buttonDaily.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDaily.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDaily.UseVisualStyleBackColor = true;
            this.buttonDaily.Click += new System.EventHandler(this.buttonDaily_Click);
            // 
            // buttonTransport
            // 
            this.buttonTransport.FlatAppearance.BorderSize = 0;
            this.buttonTransport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTransport.ForeColor = System.Drawing.Color.White;
            this.buttonTransport.Image = ((System.Drawing.Image)(resources.GetObject("buttonTransport.Image")));
            this.buttonTransport.Location = new System.Drawing.Point(0, 148);
            this.buttonTransport.Name = "buttonTransport";
            this.buttonTransport.Size = new System.Drawing.Size(251, 107);
            this.buttonTransport.TabIndex = 1;
            this.buttonTransport.Text = "Транспорт";
            this.buttonTransport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonTransport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonTransport.UseVisualStyleBackColor = true;
            this.buttonTransport.Click += new System.EventHandler(this.buttonTransport_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(77)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 118);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 97);
            this.label1.TabIndex = 0;
            this.label1.Text = "A&&Y";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(77)))));
            this.panelRight.Location = new System.Drawing.Point(257, 148);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(10, 107);
            this.panelRight.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(77)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1076, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 33);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelTransport
            // 
            this.panelTransport.Controls.Add(this.dataGridViewTransport);
            this.panelTransport.Location = new System.Drawing.Point(278, 0);
            this.panelTransport.Name = "panelTransport";
            this.panelTransport.Size = new System.Drawing.Size(847, 547);
            this.panelTransport.TabIndex = 2;
            this.panelTransport.Tag = "data";
            // 
            // dataGridViewTransport
            // 
            this.dataGridViewTransport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewTransport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTransport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTransport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.dataGridViewTransport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTransport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewTransport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTransport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.State_number,
            this.Date_shipping,
            this.Date_shipped,
            this.Weight,
            this.Price});
            this.dataGridViewTransport.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(115)))), ((int)(((byte)(133)))));
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTransport.DefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewTransport.EnableHeadersVisualStyles = false;
            this.dataGridViewTransport.Location = new System.Drawing.Point(19, 49);
            this.dataGridViewTransport.Name = "dataGridViewTransport";
            this.dataGridViewTransport.ReadOnly = true;
            this.dataGridViewTransport.RowHeadersVisible = false;
            this.dataGridViewTransport.RowTemplate.Height = 24;
            this.dataGridViewTransport.Size = new System.Drawing.Size(783, 248);
            this.dataGridViewTransport.TabIndex = 0;
            // 
            // Number
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(77)))));
            this.Number.DefaultCellStyle = dataGridViewCellStyle21;
            this.Number.FillWeight = 152.2843F;
            this.Number.HeaderText = "№";
            this.Number.MinimumWidth = 30;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // State_number
            // 
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.State_number.DefaultCellStyle = dataGridViewCellStyle22;
            this.State_number.FillWeight = 6.097285F;
            this.State_number.HeaderText = "Гос. номер";
            this.State_number.MinimumWidth = 175;
            this.State_number.Name = "State_number";
            this.State_number.ReadOnly = true;
            // 
            // Date_shipping
            // 
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.Date_shipping.DefaultCellStyle = dataGridViewCellStyle23;
            this.Date_shipping.FillWeight = 16.20349F;
            this.Date_shipping.HeaderText = "Дата отгрузки";
            this.Date_shipping.MinimumWidth = 115;
            this.Date_shipping.Name = "Date_shipping";
            this.Date_shipping.ReadOnly = true;
            // 
            // Date_shipped
            // 
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.Date_shipped.DefaultCellStyle = dataGridViewCellStyle24;
            this.Date_shipped.FillWeight = 43.8719F;
            this.Date_shipped.HeaderText = "Дата выгрузки";
            this.Date_shipped.MinimumWidth = 115;
            this.Date_shipped.Name = "Date_shipped";
            this.Date_shipped.ReadOnly = true;
            // 
            // Weight
            // 
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.Weight.DefaultCellStyle = dataGridViewCellStyle25;
            this.Weight.FillWeight = 107.3387F;
            this.Weight.HeaderText = "Вес отгрузки";
            this.Weight.MinimumWidth = 100;
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // Price
            // 
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.Price.DefaultCellStyle = dataGridViewCellStyle26;
            this.Price.FillWeight = 274.2044F;
            this.Price.HeaderText = "Стоимость";
            this.Price.MinimumWidth = 70;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1126, 713);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelTransport);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelTransport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTransport;
        private System.Windows.Forms.Button buttonRegistry;
        private System.Windows.Forms.Button buttonDaily;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelTransport;
        private System.Windows.Forms.DataGridView dataGridViewTransport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn State_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_shipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_shipped;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}

