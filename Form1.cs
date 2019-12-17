using Npgsql;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Globalization;

namespace LogisticProgram
{
    public partial class Form1 : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=slihduor;Password=Z3kDd9k-Hzri0TsNeXOEKYkb7jo9wClC;Database=slihduor;");
        List<Transport> transport = new List<Transport>();
        public void LoadInfo()
        {
            transport.Clear();
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("select * from Transport", conn);
            NpgsqlDataReader reader = command.ExecuteReader();

            // Таблица товары
            if (reader.HasRows)
            {
                foreach (DbDataRecord record in reader)
                {
                    try
                    {
                        transport.Add(new Transport
                        {
                            Number = Convert.ToInt32(record["Number"]),
                            StateNubmer = Convert.ToString(record["State number"]),
                            DateShipping = Convert.ToDateTime(record["Date shipping"]).ToShortDateString(),
                            DateShipped = Convert.ToDateTime(record["date shipped"]).ToShortDateString(),
                            Weight = Convert.ToDecimal(record["Weight"], CultureInfo.InvariantCulture),
                            Price = Convert.ToInt32(record["Price"]),
                            Currency = Convert.ToString(record["Currency"])
                        });
                    }
                    catch (InvalidCastException)
                    {
                        transport.Add(new Transport
                        {
                            Number = Convert.ToInt32(record["Number"]),
                            StateNubmer = Convert.ToString(record["State number"]),
                            DateShipping = Convert.ToDateTime(record["Date shipping"]).ToShortDateString(),
                            DateShipped = Convert.ToString(record["date shipped"]),
                            Weight = Convert.ToDecimal(record["Weight"], CultureInfo.InvariantCulture),
                            Price = Convert.ToInt32(record["Price"]),
                            Currency = Convert.ToString(record["Currency"])
                        });
                    }
                }
            }
            conn.Close();
        }

        public Form1()
        {
            InitializeComponent();
            panelRight.Height = buttonTransport.Height;
            panelRight.Top = buttonTransport.Top;
        }

        private void buttonTransport_Click(object sender, EventArgs e)
        {
            panelRight.Height = buttonTransport.Height;
            panelRight.Top = buttonTransport.Top;
            foreach (Control pn in this.Controls)
            {
                if (Convert.ToString(pn.Tag) == "data")
                {
                    pn.Visible = false;
                }
            }
            panelTransport.Visible = true;
        }

        private void buttonDaily_Click(object sender, EventArgs e)
        {
            panelRight.Height = buttonDaily.Height;
            panelRight.Top = buttonDaily.Top;
            foreach (Control pn in this.Controls)
            {
                if (Convert.ToString(pn.Tag) == "data")
                {
                    pn.Visible = false;
                }
            }
        }

        private void buttonRegistry_Click(object sender, EventArgs e)
        {
            panelRight.Height = buttonRegistry.Height;
            panelRight.Top = buttonRegistry.Top;
            foreach (Control pn in this.Controls)
            {
                if (Convert.ToString(pn.Tag) == "data")
                {
                    pn.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInfo();

            int i = 0;

            for (int j = 0; j < transport.Count - 1; j++)
            {
                dataGridViewTransport.Rows.Add();
            }

            foreach (Transport el in transport)
            {
                dataGridViewTransport.Rows[i].Cells[0].Value = el.Number;
                dataGridViewTransport.Rows[i].Cells[1].Value = el.StateNubmer;
                dataGridViewTransport.Rows[i].Cells[2].Value = el.DateShipping;
                if (el.DateShipped != "")
                {
                    dataGridViewTransport.Rows[i].Cells[3].Value = el.DateShipped; 
                }
                else
                {
                    dataGridViewTransport.Rows[i].Cells[3].Value = "—";
                }
                dataGridViewTransport.Rows[i].Cells[4].Value = el.Weight;
                dataGridViewTransport.Rows[i].Cells[5].Value = $"{el.Price} {el.Currency}";
                i++;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (buttonAdd.FlatAppearance.BorderSize == 0)
            {
                buttonRemove.FlatAppearance.BorderSize = 0;
                buttonChange.FlatAppearance.BorderSize = 0;
                buttonAdd.FlatAppearance.BorderSize = 1;
                buttonMake.Text = "Добавить";
                timer1.Enabled = true;
            }
            else
            {
                buttonAdd.FlatAppearance.BorderSize = 0;
                timer2.Enabled = true;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (buttonRemove.FlatAppearance.BorderSize == 0)
            {
                buttonRemove.FlatAppearance.BorderSize = 1;
                buttonChange.FlatAppearance.BorderSize = 0;
                buttonAdd.FlatAppearance.BorderSize = 0;
                buttonMake.Text = "Удалить";
                timer1.Enabled = true;
            }
            else
            {
                buttonRemove.FlatAppearance.BorderSize = 0;
                timer2.Enabled = true;
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (buttonChange.FlatAppearance.BorderSize == 0)
            {
                buttonRemove.FlatAppearance.BorderSize = 0;
                buttonChange.FlatAppearance.BorderSize = 1;
                buttonAdd.FlatAppearance.BorderSize = 0;
                buttonMake.Text = "Отредактировать";
                timer1.Enabled = true;
            }
            else
            {
                buttonChange.FlatAppearance.BorderSize = 0;
                timer2.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panelTransport.Left != 0)
            {
                while (panelTransport.Left > 0)
                {
                    panelTransport.Left -= 1; 
                }
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panelTransport.Left == 0)
            {
                while (panelTransport.Left < 278)
                {
                    panelTransport.Left += 1;
                }
                timer2.Enabled = false;
            }
            else
            {
                timer2.Enabled = false;
            }
        }

        private void textBoxNumber_Enter(object sender, EventArgs e)
        {
            if (textBoxNumber.Text == "Гос. номер")
            {
                textBoxNumber.Text = "";
                panelNumber.BackColor = Color.FromArgb(62, 120, 138);
                textBoxNumber.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxNumber.Font = new Font(textBoxNumber.Font.Name, 11, textBoxNumber.Font.Style);
            }
        }

        private void textBoxNumber_Leave(object sender, EventArgs e)
        {
            if (textBoxNumber.Text == "")
            {
                textBoxNumber.Text = "Гос. номер";
                textBoxNumber.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxNumber.Font = new Font(textBoxNumber.Font.Name, 10, textBoxNumber.Font.Style);
            }
        }

        private void textBoxShipping_Enter(object sender, EventArgs e)
        {
            if (textBoxShipping.Text == "Дата отгрузки")
            {
                textBoxShipping.Text = "";
                panelShipping.BackColor = Color.FromArgb(62, 120, 138);
                textBoxShipping.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxShipping.Font = new Font(textBoxNumber.Font.Name, 11, textBoxNumber.Font.Style);
            }
        }

        private void textBoxShipping_Leave(object sender, EventArgs e)
        {
            if (textBoxShipping.Text == "")
            {
                textBoxShipping.Text = "Дата отгрузки";
                textBoxShipping.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxShipping.Font = new Font(textBoxNumber.Font.Name, 10, textBoxNumber.Font.Style);
            }
        }

        private void textBoxShipped_Enter(object sender, EventArgs e)
        {
            if (textBoxShipped.Text == "Дата выгрузки")
            {
                textBoxShipped.Text = "";
                panelShipped.BackColor = Color.FromArgb(62, 120, 138);
                textBoxShipped.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxShipped.Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxShipped_Leave(object sender, EventArgs e)
        {
            if (textBoxShipped.Text == "")
            {
                textBoxShipped.Text = "Дата выгрузки";
                textBoxShipped.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxShipped.Font = new Font(textBoxShipped.Font.Name, 10, textBoxShipped.Font.Style);
            }
        }

        private void textBoxWeight_Enter(object sender, EventArgs e)
        {
            if (textBoxWeight.Text == "Вес отгрузки")
            {
                textBoxWeight.Text = "";
                panelWeight.BackColor = Color.FromArgb(62, 120, 138);
                textBoxWeight.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxWeight.Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxWeight_Leave(object sender, EventArgs e)
        {
            if (textBoxWeight.Text == "")
            {
                textBoxWeight.Text = "Вес отгрузки";
                textBoxWeight.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxWeight.Font = new Font(textBoxShipped.Font.Name, 10, textBoxShipped.Font.Style);
            }
        }

        private void textBoxPrice_Enter(object sender, EventArgs e)
        {
            if (textBoxPrice.Text == "Стоимость")
            {
                textBoxPrice.Text = "";
                panelPrice.BackColor = Color.FromArgb(62, 120, 138);
                textBoxPrice.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxPrice.Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            if (textBoxPrice.Text == "")
            {
                textBoxPrice.Text = "Стоимость";
                textBoxPrice.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxPrice.Font = new Font(textBoxShipped.Font.Name, 10, textBoxShipped.Font.Style);
            }
        }

        private void textBoxCurrency_Enter(object sender, EventArgs e)
        {
            if (textBoxCurrency.Text == "Валюта")
            {
                textBoxCurrency.Text = "";
                panelCurrency.BackColor = Color.FromArgb(62, 120, 138);
                textBoxCurrency.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxCurrency.Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxCurrency_Leave(object sender, EventArgs e)
        {
            if (textBoxCurrency.Text == "")
            {
                textBoxCurrency.Text = "Валюта";
                textBoxCurrency.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxCurrency.Font = new Font(textBoxShipped.Font.Name, 10, textBoxShipped.Font.Style);
            }
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            //Check textBoxes
            bool check = true;
            if (textBoxNumber.Text == "Гос. номер")
            {
                panelNumber.BackColor = Color.FromArgb(225, 50, 77);
                check = false;
            }
            if (textBoxShipping.Text == "Дата отгрузки")
            {
                panelShipping.BackColor = Color.FromArgb(225, 50, 77);
                check = false;
            }
            if (textBoxShipped.Text == "Дата выгрузки")
            {
                panelShipped.BackColor = Color.FromArgb(225, 50, 77);
                check = false;
            }
            if (textBoxWeight.Text == "Вес отгрузки")
            {
                panelWeight.BackColor = Color.FromArgb(225, 50, 77);
                check = false;
            }
            if (textBoxPrice.Text == "Стоимость")
            {
                panelPrice.BackColor = Color.FromArgb(225, 50, 77);
                check = false;
            }
            if (textBoxCurrency.Text == "Валюта")
            {
                panelCurrency.BackColor = Color.FromArgb(225, 50, 77);
                check = false;
            }

            //Add to database
            if (check)
            {
                string number = textBoxNumber.Text;
                string dateShipping = textBoxShipping.Text;
                string dateShipped = textBoxShipped.Text;
                decimal weight = Convert.ToDecimal(textBoxWeight.Text, CultureInfo.InvariantCulture);
                int price = Convert.ToInt32(textBoxPrice.Text);
                string currency = textBoxCurrency.Text;

                conn.Open();
                NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO transport VALUES (DEFAULT, '{number}', '{dateShipping}', '{dateShipped}', {weight}, {price}, '{currency}')", conn);
                command.ExecuteNonQuery();
                conn.Close();

                LoadInfo();

                int i = 0;
                dataGridViewTransport.Rows.Clear();

                for (int j = 0; j < transport.Count - 1; j++)
                {
                    dataGridViewTransport.Rows.Add();
                }

                foreach (Transport el in transport)
                {
                    dataGridViewTransport.Rows[i].Cells[0].Value = el.Number;
                    dataGridViewTransport.Rows[i].Cells[1].Value = el.StateNubmer;
                    dataGridViewTransport.Rows[i].Cells[2].Value = el.DateShipping;
                    if (el.DateShipped != "")
                    {
                        dataGridViewTransport.Rows[i].Cells[3].Value = el.DateShipped;
                    }
                    else
                    {
                        dataGridViewTransport.Rows[i].Cells[3].Value = "—";
                    }
                    dataGridViewTransport.Rows[i].Cells[4].Value = el.Weight;
                    dataGridViewTransport.Rows[i].Cells[5].Value = $"{el.Price} {el.Currency}";
                    i++;
                }

                textBoxNumber.Text = "Гос. номер";
                textBoxNumber.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxNumber.Font = new Font(textBoxNumber.Font.Name, 10, textBoxNumber.Font.Style);
            }
        }
    }
}
