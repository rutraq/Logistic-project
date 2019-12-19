using Npgsql;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LogisticProgram
{
    public partial class Form1 : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=slihduor;Password=Z3kDd9k-Hzri0TsNeXOEKYkb7jo9wClC;Database=slihduor;");
        List<Transport> transport = new List<Transport>();
        List<Shipping> shipping = new List<Shipping>();
        List<Registry> registry = new List<Registry>();
        int numberForChange = new int();
        public void LoadInfo()
        {
            transport.Clear();
            shipping.Clear();
            registry.Clear();

            // Таблица машины
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("select * from Transport", conn);
            NpgsqlDataReader reader = command.ExecuteReader();

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

            //Таблица отгрузка
            conn.Open();
            command = new NpgsqlCommand("select * from Shipping", conn);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                foreach (DbDataRecord record in reader)
                {
                    shipping.Add(new Shipping
                    {
                        Number = Convert.ToInt32(record["Number"]),
                        Date = Convert.ToDateTime(record["Date"]).ToShortDateString(),
                        Trucks = Convert.ToInt32(record["Truck count"]),
                        Weight = Convert.ToInt32(record["Weight"]),
                        Pipes = Convert.ToInt32(record["Pipes count"]),
                    });
                }
            }
            conn.Close();

            //Таблица реестр
            conn.Open();
            command = new NpgsqlCommand("select \"Personal\", \"Date\", Diameter, \"Pipe number\", Length, Thickness, Registry.Weight from Registry join Shipping using (Number)", conn);
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                foreach (DbDataRecord record in reader)
                {
                    registry.Add(new Registry
                    {
                        Number = Convert.ToInt32(record["Personal"]),
                        Date = Convert.ToDateTime(record["Date"]).ToShortDateString(),
                        Diameter = Convert.ToInt32(record["Diameter"]),
                        PipeNumber = Convert.ToInt32(record["Pipe number"]),
                        Length = Convert.ToInt32(record["Length"]),
                        Thickness = Convert.ToInt32(record["Thickness"]),
                        Weight = Convert.ToInt32(record["Weight"])
                    });
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
            panelTransportBoxes.Visible = true;
            panelShippingBoxes.Visible = false;
            timerAnimateTransport.Enabled = true;
        }

        private void buttonDaily_Click(object sender, EventArgs e)
        {
            panelRight.Height = buttonDaily.Height;
            panelRight.Top = buttonDaily.Top;
            panelTransportBoxes.Visible = false;
            panelShippingBoxes.Visible = true;
            timerAnimateShipping.Enabled = true;
        }

        private void buttonRegistry_Click(object sender, EventArgs e)
        {
            panelRight.Height = buttonRegistry.Height;
            panelRight.Top = buttonRegistry.Top;
            timerAnimateRegistry.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            LoadInfo();
            dataGridViewTransport.Rows.Clear();
            dataGridViewShipping.Rows.Clear();
            dataGridViewRegistry.Rows.Clear();

            //transport
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

            //shipping
            i = 0;

            for (int j = 0; j < shipping.Count - 1; j++)
            {
                dataGridViewShipping.Rows.Add();
            }

            foreach (Shipping el in shipping)
            {
                dataGridViewShipping.Rows[i].Cells[0].Value = el.Number;
                dataGridViewShipping.Rows[i].Cells[1].Value = el.Date;
                dataGridViewShipping.Rows[i].Cells[2].Value = el.Trucks;
                dataGridViewShipping.Rows[i].Cells[3].Value = el.Weight;
                dataGridViewShipping.Rows[i].Cells[4].Value = el.Pipes;
                i++;
            }

            //registry
            i = 0;

            for (int j = 0; j < registry.Count - 1; j++)
            {
                dataGridViewRegistry.Rows.Add();
            }

            foreach (Registry el in registry)
            {
                dataGridViewRegistry.Rows[i].Cells[0].Value = el.Number;
                dataGridViewRegistry.Rows[i].Cells[1].Value = el.Date;
                dataGridViewRegistry.Rows[i].Cells[2].Value = el.Diameter;
                dataGridViewRegistry.Rows[i].Cells[3].Value = el.PipeNumber;
                dataGridViewRegistry.Rows[i].Cells[4].Value = el.Length;
                dataGridViewRegistry.Rows[i].Cells[5].Value = el.Thickness;
                dataGridViewRegistry.Rows[i].Cells[6].Value = el.Weight;
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
                TextBoxEnabled(false);
                timer1.Enabled = true;
            }
            else
            {
                buttonAdd.FlatAppearance.BorderSize = 0;
                TextBoxClear();
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
                TextBoxEnabled(true);
                timer1.Enabled = true;
            }
            else
            {
                buttonRemove.FlatAppearance.BorderSize = 0;
                TextBoxClear();
                TextBoxEnabled(false);
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
                TextBoxEnabled(false);
                timer1.Enabled = true;
            }
            else
            {
                buttonChange.FlatAppearance.BorderSize = 0;
                TextBoxClear();
                timer2.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panelTransport.Left != 0)
            {
                panelTransport.Left -= 5;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panelTransport.Left != 275)
            {
                panelTransport.Left += 5;
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
            if (textBoxShipping.Text == "Дата отгрузки" || !Regex.IsMatch(textBoxShipping.Text, @"^\d{4}-\d{2}-\d{2}$"))
            {
                panelShipping.BackColor = Color.FromArgb(225, 50, 77);
                check = false;
                if (buttonMake.Text == "Удалить" || buttonMake.Text == "Отредактировать")
                {
                    panelShipping.BackColor = Color.FromArgb(62, 120, 138);
                    check = true;
                }
            }
            else
            {
                string text = Convert.ToString(Regex.Match(textBoxShipping.Text, @"-\d+-"));
                string month = Convert.ToString(Regex.Match(text, @"\d+"));

                string days = Convert.ToString(Regex.Match(Regex.Match(textBoxShipping.Text, @"-\d+$").ToString(), @"\d+"));

                if (Convert.ToInt32(month) > 12 || Convert.ToInt32(month) < 0)
                {
                    panelShipping.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }
                else
                {
                    if (Convert.ToInt32(days) > 31 || Convert.ToInt32(days) < 1)
                    {
                        panelShipping.BackColor = Color.FromArgb(225, 50, 77);
                        check = false;
                    }
                }
            }
            if (textBoxShipped.Text == "Дата выгрузки" || !Regex.IsMatch(textBoxShipped.Text, @"^\d{4}-\d{2}-\d{2}$"))
            {
                panelShipped.BackColor = Color.FromArgb(225, 50, 77);
                check = false;
                if (buttonMake.Text == "Удалить" || buttonMake.Text == "Отредактировать")
                {
                    panelShipped.BackColor = Color.FromArgb(62, 120, 138);
                    check = true;
                }
            }
            else
            {
                string days = Convert.ToString(Regex.Match(Regex.Match(textBoxShipped.Text, @"-\d+$").ToString(), @"\d+"));
                string month = Convert.ToString(Regex.Match(Regex.Match(textBoxShipped.Text, @"-\d+-").ToString(), @"\d+"));
                if (Convert.ToInt32(month) > 12 || Convert.ToInt32(month) < 0)
                {
                    panelShipped.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }
                else
                {
                    if (Convert.ToInt32(days) > 31 || Convert.ToInt32(days) < 1)
                    {
                        panelShipping.BackColor = Color.FromArgb(225, 50, 77);
                        check = false;
                    }
                }
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

            if (check)
            {
                //Add to database
                string number = textBoxNumber.Text;
                string dateShipping = textBoxShipping.Text;
                string dateShipped = textBoxShipped.Text;
                decimal weight = Convert.ToDecimal(textBoxWeight.Text, CultureInfo.InvariantCulture);
                int price = Convert.ToInt32(textBoxPrice.Text);
                string currency = textBoxCurrency.Text;

                if (buttonMake.Text == "Добавить")
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO transport VALUES (DEFAULT, '{number}', '{dateShipping}', '{dateShipped}', {weight}, {price}, '{currency}')", conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    LoadData();

                    TextBoxClear();
                }
                else if (buttonMake.Text == "Удалить")
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand($"delete from transport where \"number\" = {numberForChange}", conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    LoadData();

                    TextBoxClear();
                }
                else if (buttonMake.Text == "Отредактировать")
                {
                    DateTime date = DateTime.ParseExact(dateShipping, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    int days = date.Day;
                    int month = date.Month;
                    int year = date.Year;

                    DateTime date2 = DateTime.ParseExact(dateShipped, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    int days2 = date2.Day;
                    int month2 = date2.Month;
                    int year2 = date2.Year;

                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand($"update transport set \"State number\" = '{number}', \"Date shipping\" = '{year}-{month}-{days}', \"Date shipped\" = '{year2}-{month2}-{days2}', \"Weight\" = {weight}, \"price\" = {price}, \"currency\" = '{currency}' where \"number\" = {numberForChange}", conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    LoadData();

                    TextBoxClear();
                }
            }
        }

        private void textBoxWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
            else
            {
                panelWeight.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelPrice.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelCurrency.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxShipping_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
            else
            {
                panelShipping.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxShipped_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
            else
            {
                panelShipped.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && !Char.IsLetter(ch) && ch != 47 && ch != 32 && ch != 45)
            {
                e.Handled = true;
            }
            else
            {
                panelNumber.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void timerAnimate_Tick(object sender, EventArgs e)
        {
            if (dataGridViewShipping.Top != 95)
            {
                if (dataGridViewShipping.Top > 95)
                {
                    dataGridViewShipping.Top -= 15;
                    dataGridViewTransport.Top -= 15;
                    dataGridViewRegistry.Top -= 15;
                }
                else
                {
                    dataGridViewShipping.Top += 15;
                    dataGridViewTransport.Top += 15;
                    dataGridViewRegistry.Top += 15;
                }
            }
            else
            {
                timerAnimateShipping.Enabled = false;
            }
        }

        private void timerAnimateTransport_Tick(object sender, EventArgs e)
        {
            if (dataGridViewTransport.Top != 95)
            {
                if (dataGridViewTransport.Top > 95)
                {
                    dataGridViewShipping.Top -= 15;
                    dataGridViewTransport.Top -= 15;
                }
                else
                {
                    dataGridViewShipping.Top += 15;
                    dataGridViewTransport.Top += 15;
                    dataGridViewRegistry.Top += 15;
                }
            }
            else
            {
                timerAnimateTransport.Enabled = false;
            }
        }

        private void timerAnimateRegistry_Tick(object sender, EventArgs e)
        {
            if (dataGridViewRegistry.Top != 95)
            {
                if (dataGridViewRegistry.Top > 95)
                {
                    dataGridViewShipping.Top -= 15;
                    dataGridViewTransport.Top -= 15;
                    dataGridViewRegistry.Top -= 15;
                }
                else
                {
                    dataGridViewShipping.Top += 15;
                    dataGridViewTransport.Top += 15;
                    dataGridViewRegistry.Top += 15;
                }
            }
            else
            {
                timerAnimateRegistry.Enabled = false;
            }
        }

        private void dataGridViewTransport_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridViewTransport.CurrentCell.RowIndex;
            numberForChange = Convert.ToInt32(dataGridViewTransport.Rows[index].Cells[0].Value);

            textBoxNumber.Text = Convert.ToString(dataGridViewTransport.Rows[index].Cells[1].Value);
            textBoxShipping.Text = Convert.ToString(dataGridViewTransport.Rows[index].Cells[2].Value);
            textBoxShipped.Text = Convert.ToString(dataGridViewTransport.Rows[index].Cells[3].Value);
            textBoxWeight.Text = Convert.ToString(dataGridViewTransport.Rows[index].Cells[4].Value);

            string price = Convert.ToString(dataGridViewTransport.Rows[index].Cells[5].Value);
            textBoxPrice.Text = Convert.ToString(Regex.Match(price, @"\d+"));
            textBoxCurrency.Text = Convert.ToString(Regex.Match(price, @"[а-яА-Яa-zA-Z]+"));

            ChangeStyleBoxes();
        }

        public void ChangeStyleBoxes()
        {
            foreach (Control pn in Controls)
            {
                if (pn is Panel)
                {
                    foreach (Control el in pn.Controls)
                    {
                        if (el is Panel)
                        {
                            foreach (Control pn2 in el.Controls)
                            {
                                if (pn2 is Panel)
                                {
                                    foreach (Control box in pn2.Controls)
                                    {
                                        if (Convert.ToString(box.Tag) == "boxes")
                                        {
                                            box.ForeColor = Color.FromArgb(143, 201, 219);
                                            box.Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void textBoxDate_Enter(object sender, EventArgs e)
        {
            if (textBoxDate.Text == "Дата")
            {
                textBoxDate.Text = "";
                panelDate.BackColor = Color.FromArgb(62, 120, 138);
                textBoxDate.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxDate.Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxDate_Leave(object sender, EventArgs e)
        {
            if (textBoxDate.Text == "")
            {
                textBoxDate.Text = "Дата";
                textBoxDate.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxDate.Font = new Font(textBoxShipped.Font.Name, 10, textBoxShipped.Font.Style);
            }
        }

        private void textBoxTrucks_Enter(object sender, EventArgs e)
        {
            if (textBoxTrucks.Text == "Отгружено машин")
            {
                textBoxTrucks.Text = "";
                panelTrucks.BackColor = Color.FromArgb(62, 120, 138);
                textBoxTrucks.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxTrucks.Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxTrucks_Leave(object sender, EventArgs e)
        {
            if (textBoxTrucks.Text == "")
            {
                textBoxTrucks.Text = "Отгружено машин";
                textBoxTrucks.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxTrucks.Font = new Font(textBoxShipped.Font.Name, 10, textBoxShipped.Font.Style);
            }
        }

        private void textBoxShippingWeight_Enter(object sender, EventArgs e)
        {
            if (textBoxShippingWeight.Text == "Отгружено, кг")
            {
                textBoxShippingWeight.Text = "";
                panelShippingWeight.BackColor = Color.FromArgb(62, 120, 138);
                textBoxShippingWeight.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxShippingWeight.Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxShippingWeight_Leave(object sender, EventArgs e)
        {
            if (textBoxShippingWeight.Text == "")
            {
                textBoxShippingWeight.Text = "Отгружено, кг";
                textBoxShippingWeight.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxShippingWeight.Font = new Font(textBoxShipped.Font.Name, 10, textBoxShipped.Font.Style);
            }
        }

        private void textBoxPipes_Enter(object sender, EventArgs e)
        {
            if (textBoxPipes.Text == "Отгружено труб, шт")
            {
                textBoxPipes.Text = "";
                panelPipes.BackColor = Color.FromArgb(62, 120, 138);
                textBoxPipes.ForeColor = Color.FromArgb(143, 201, 219);
                textBoxPipes.Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxPipes_Leave(object sender, EventArgs e)
        {
            if (textBoxPipes.Text == "")
            {
                textBoxPipes.Text = "Отгружено труб, шт";
                textBoxPipes.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxPipes.Font = new Font(textBoxShipped.Font.Name, 10, textBoxShipped.Font.Style);
            }
        }

        public void TextBoxClear()
        {
            textBoxNumber.Text = "Гос. номер";
            textBoxShipping.Text = "Дата отгрузки";
            textBoxShipped.Text = "Дата выгрузки";
            textBoxWeight.Text = "Вес отгрузки";
            textBoxPrice.Text = "Стоимость";
            textBoxCurrency.Text = "Валюта";

            foreach (Control pn in Controls)
            {
                if (pn is Panel)
                {
                    foreach (Control el in pn.Controls)
                    {
                        if (el is Panel)
                        {
                            foreach (Control pn2 in el.Controls)
                            {
                                if (pn2 is Panel)
                                {
                                    foreach (Control box in pn2.Controls)
                                    {
                                        if (Convert.ToString(box.Tag) == "boxes")
                                        {
                                            box.ForeColor = Color.FromArgb(125, 125, 125);
                                            box.Font = new Font(textBoxShipped.Font.Name, 10, textBoxShipped.Font.Style);
                                        }
                                        if (box is Panel)
                                        {
                                            box.BackColor = Color.FromArgb(62, 120, 138);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void TextBoxEnabled(bool enabled)
        {
            foreach (Control pn in Controls)
            {
                if (pn is Panel)
                {
                    foreach (Control el in pn.Controls)
                    {
                        if (el is Panel)
                        {
                            foreach (Control pn2 in el.Controls)
                            {
                                if (pn2 is Panel)
                                {
                                    foreach (Control box in pn2.Controls)
                                    {
                                        if (Convert.ToString(box.Tag) == "boxes")
                                        {
                                            ((TextBox)box).ReadOnly = enabled;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dataGridViewTransport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}