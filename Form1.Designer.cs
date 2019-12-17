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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panelData = new System.Windows.Forms.Panel();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.textBoxShipping = new System.Windows.Forms.TextBox();
            this.textBoxShipped = new System.Windows.Forms.TextBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.buttonMake = new System.Windows.Forms.Button();
            this.panelNumber = new System.Windows.Forms.Panel();
            this.panelShipping = new System.Windows.Forms.Panel();
            this.panelShipped = new System.Windows.Forms.Panel();
            this.panelWeight = new System.Windows.Forms.Panel();
            this.panelPrice = new System.Windows.Forms.Panel();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            this.panelCurrency = new System.Windows.Forms.Panel();
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
            this.panelData.SuspendLayout();
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
            this.panelTransport.Controls.Add(this.panelData);
            this.panelTransport.Controls.Add(this.buttonAdd);
            this.panelTransport.Controls.Add(this.buttonRemove);
            this.panelTransport.Controls.Add(this.buttonChange);
            this.panelTransport.Controls.Add(this.dataGridViewTransport);
            this.panelTransport.Location = new System.Drawing.Point(278, 0);
            this.panelTransport.Name = "panelTransport";
            this.panelTransport.Size = new System.Drawing.Size(1126, 547);
            this.panelTransport.TabIndex = 2;
            this.panelTransport.Tag = "data";
            // 
            // dataGridViewTransport
            // 
            this.dataGridViewTransport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.dataGridViewTransport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTransport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTransport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.dataGridViewTransport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTransport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewTransport.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTransport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.State_number,
            this.Date_shipping,
            this.Date_shipped,
            this.Weight,
            this.Price});
            this.dataGridViewTransport.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(77)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTransport.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTransport.EnableHeadersVisualStyles = false;
            this.dataGridViewTransport.Location = new System.Drawing.Point(19, 95);
            this.dataGridViewTransport.Name = "dataGridViewTransport";
            this.dataGridViewTransport.ReadOnly = true;
            this.dataGridViewTransport.RowHeadersVisible = false;
            this.dataGridViewTransport.RowTemplate.Height = 24;
            this.dataGridViewTransport.Size = new System.Drawing.Size(783, 248);
            this.dataGridViewTransport.TabIndex = 0;
            // 
            // buttonChange
            // 
            this.buttonChange.FlatAppearance.BorderSize = 0;
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChange.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange.Location = new System.Drawing.Point(193, 26);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(182, 63);
            this.buttonChange.TabIndex = 1;
            this.buttonChange.Tag = "change";
            this.buttonChange.Text = "Редактирование";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatAppearance.BorderSize = 0;
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemove.Location = new System.Drawing.Point(381, 26);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(182, 63);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Tag = "change";
            this.buttonRemove.Text = "Удаление";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(569, 26);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(182, 63);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Tag = "change";
            this.buttonAdd.Text = "Добавление";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.panelCurrency);
            this.panelData.Controls.Add(this.textBoxCurrency);
            this.panelData.Controls.Add(this.panelPrice);
            this.panelData.Controls.Add(this.panelWeight);
            this.panelData.Controls.Add(this.panelShipped);
            this.panelData.Controls.Add(this.panelShipping);
            this.panelData.Controls.Add(this.panelNumber);
            this.panelData.Controls.Add(this.buttonMake);
            this.panelData.Controls.Add(this.textBoxPrice);
            this.panelData.Controls.Add(this.textBoxWeight);
            this.panelData.Controls.Add(this.textBoxShipped);
            this.panelData.Controls.Add(this.textBoxShipping);
            this.panelData.Controls.Add(this.textBoxNumber);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelData.Location = new System.Drawing.Point(808, 0);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(318, 547);
            this.panelData.TabIndex = 4;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.textBoxNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNumber.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.textBoxNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.textBoxNumber.Location = new System.Drawing.Point(72, 77);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(183, 21);
            this.textBoxNumber.TabIndex = 0;
            this.textBoxNumber.Tag = "boxes";
            this.textBoxNumber.Text = "Гос. номер";
            this.textBoxNumber.Enter += new System.EventHandler(this.textBoxNumber_Enter);
            this.textBoxNumber.Leave += new System.EventHandler(this.textBoxNumber_Leave);
            // 
            // textBoxShipping
            // 
            this.textBoxShipping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.textBoxShipping.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxShipping.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.textBoxShipping.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.textBoxShipping.Location = new System.Drawing.Point(72, 130);
            this.textBoxShipping.Name = "textBoxShipping";
            this.textBoxShipping.Size = new System.Drawing.Size(183, 21);
            this.textBoxShipping.TabIndex = 1;
            this.textBoxShipping.Tag = "boxes";
            this.textBoxShipping.Text = "Дата отгрузки";
            this.textBoxShipping.Enter += new System.EventHandler(this.textBoxShipping_Enter);
            this.textBoxShipping.Leave += new System.EventHandler(this.textBoxShipping_Leave);
            // 
            // textBoxShipped
            // 
            this.textBoxShipped.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.textBoxShipped.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxShipped.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.textBoxShipped.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.textBoxShipped.Location = new System.Drawing.Point(72, 183);
            this.textBoxShipped.Name = "textBoxShipped";
            this.textBoxShipped.Size = new System.Drawing.Size(183, 21);
            this.textBoxShipped.TabIndex = 2;
            this.textBoxShipped.Tag = "boxes";
            this.textBoxShipped.Text = "Дата выгрузки";
            this.textBoxShipped.Enter += new System.EventHandler(this.textBoxShipped_Enter);
            this.textBoxShipped.Leave += new System.EventHandler(this.textBoxShipped_Leave);
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.textBoxWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxWeight.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.textBoxWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.textBoxWeight.Location = new System.Drawing.Point(72, 236);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(183, 21);
            this.textBoxWeight.TabIndex = 3;
            this.textBoxWeight.Tag = "boxes";
            this.textBoxWeight.Text = "Вес отгрузки";
            this.textBoxWeight.Enter += new System.EventHandler(this.textBoxWeight_Enter);
            this.textBoxWeight.Leave += new System.EventHandler(this.textBoxWeight_Leave);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.textBoxPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPrice.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.textBoxPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.textBoxPrice.Location = new System.Drawing.Point(72, 289);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(183, 21);
            this.textBoxPrice.TabIndex = 4;
            this.textBoxPrice.Tag = "boxes";
            this.textBoxPrice.Text = "Стоимость";
            this.textBoxPrice.Enter += new System.EventHandler(this.textBoxPrice_Enter);
            this.textBoxPrice.Leave += new System.EventHandler(this.textBoxPrice_Leave);
            // 
            // buttonMake
            // 
            this.buttonMake.FlatAppearance.BorderSize = 0;
            this.buttonMake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMake.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMake.Location = new System.Drawing.Point(72, 394);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(183, 60);
            this.buttonMake.TabIndex = 5;
            this.buttonMake.Tag = "";
            this.buttonMake.Text = "Добавить";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // panelNumber
            // 
            this.panelNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.panelNumber.Location = new System.Drawing.Point(72, 103);
            this.panelNumber.Name = "panelNumber";
            this.panelNumber.Size = new System.Drawing.Size(183, 2);
            this.panelNumber.TabIndex = 6;
            // 
            // panelShipping
            // 
            this.panelShipping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.panelShipping.Location = new System.Drawing.Point(72, 156);
            this.panelShipping.Name = "panelShipping";
            this.panelShipping.Size = new System.Drawing.Size(183, 2);
            this.panelShipping.TabIndex = 7;
            // 
            // panelShipped
            // 
            this.panelShipped.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.panelShipped.Location = new System.Drawing.Point(72, 209);
            this.panelShipped.Name = "panelShipped";
            this.panelShipped.Size = new System.Drawing.Size(183, 2);
            this.panelShipped.TabIndex = 7;
            // 
            // panelWeight
            // 
            this.panelWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.panelWeight.Location = new System.Drawing.Point(72, 262);
            this.panelWeight.Name = "panelWeight";
            this.panelWeight.Size = new System.Drawing.Size(183, 2);
            this.panelWeight.TabIndex = 7;
            // 
            // panelPrice
            // 
            this.panelPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.panelPrice.Location = new System.Drawing.Point(72, 315);
            this.panelPrice.Name = "panelPrice";
            this.panelPrice.Size = new System.Drawing.Size(183, 2);
            this.panelPrice.TabIndex = 7;
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.textBoxCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCurrency.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.textBoxCurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.textBoxCurrency.Location = new System.Drawing.Point(72, 341);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.Size = new System.Drawing.Size(183, 21);
            this.textBoxCurrency.TabIndex = 8;
            this.textBoxCurrency.Tag = "boxes";
            this.textBoxCurrency.Text = "Валюта";
            this.textBoxCurrency.Enter += new System.EventHandler(this.textBoxCurrency_Enter);
            this.textBoxCurrency.Leave += new System.EventHandler(this.textBoxCurrency_Leave);
            // 
            // panelCurrency
            // 
            this.panelCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.panelCurrency.Location = new System.Drawing.Point(72, 367);
            this.panelCurrency.Name = "panelCurrency";
            this.panelCurrency.Size = new System.Drawing.Size(183, 2);
            this.panelCurrency.TabIndex = 8;
            // 
            // Number
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(50)))), ((int)(((byte)(77)))));
            this.Number.DefaultCellStyle = dataGridViewCellStyle3;
            this.Number.FillWeight = 152.2843F;
            this.Number.HeaderText = "№";
            this.Number.MinimumWidth = 30;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // State_number
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.State_number.DefaultCellStyle = dataGridViewCellStyle4;
            this.State_number.FillWeight = 6.097285F;
            this.State_number.HeaderText = "Гос. номер";
            this.State_number.MinimumWidth = 175;
            this.State_number.Name = "State_number";
            this.State_number.ReadOnly = true;
            // 
            // Date_shipping
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.Date_shipping.DefaultCellStyle = dataGridViewCellStyle5;
            this.Date_shipping.FillWeight = 16.20349F;
            this.Date_shipping.HeaderText = "Дата отгрузки";
            this.Date_shipping.MinimumWidth = 115;
            this.Date_shipping.Name = "Date_shipping";
            this.Date_shipping.ReadOnly = true;
            // 
            // Date_shipped
            // 
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.Date_shipped.DefaultCellStyle = dataGridViewCellStyle6;
            this.Date_shipped.FillWeight = 43.8719F;
            this.Date_shipped.HeaderText = "Дата выгрузки";
            this.Date_shipped.MinimumWidth = 115;
            this.Date_shipped.Name = "Date_shipped";
            this.Date_shipped.ReadOnly = true;
            // 
            // Weight
            // 
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.Weight.DefaultCellStyle = dataGridViewCellStyle7;
            this.Weight.FillWeight = 107.3387F;
            this.Weight.HeaderText = "Вес отгрузки";
            this.Weight.MinimumWidth = 100;
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // Price
            // 
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(201)))), ((int)(((byte)(219)))));
            this.Price.DefaultCellStyle = dataGridViewCellStyle8;
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
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
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
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.TextBox textBoxShipped;
        private System.Windows.Forms.TextBox textBoxShipping;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Panel panelPrice;
        private System.Windows.Forms.Panel panelWeight;
        private System.Windows.Forms.Panel panelShipped;
        private System.Windows.Forms.Panel panelShipping;
        private System.Windows.Forms.Panel panelNumber;
        private System.Windows.Forms.Panel panelCurrency;
        private System.Windows.Forms.TextBox textBoxCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn State_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_shipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_shipped;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}

