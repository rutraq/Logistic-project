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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTransport = new System.Windows.Forms.Button();
            this.buttonDaily = new System.Windows.Forms.Button();
            this.buttonRegistry = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(251, 598);
            this.panel1.TabIndex = 0;
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
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 97);
            this.label1.TabIndex = 0;
            this.label1.Text = "A&&Y";
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
            this.button1.Location = new System.Drawing.Point(956, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 33);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1007, 598);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
    }
}

