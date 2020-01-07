using Npgsql;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using Telegram.Bot.Args;
using System.IO;

namespace LogisticProgram
{
    public partial class Form1 : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=slihduor;Password=Z3kDd9k-Hzri0TsNeXOEKYkb7jo9wClC;Database=slihduor;");
        List<Transport> transport = new List<Transport>();
        List<Shipping> shipping = new List<Shipping>();
        List<Registry> registry = new List<Registry>();
        int numberForChange = new int();
        Dictionary<string, string> defaultText = new Dictionary<string, string>();
        private string userMessage = "";

        Telegram telegram = new Telegram();
        Excel ex = new Excel();
        Sql sql = new Sql();

        private void Listen(object sender, MessageEventArgs e)
        {
            userMessage += e.Message.Date + ": ";
            userMessage += e.Message.Chat.FirstName + " ";
            if (e.Message.Chat.Username != null)
            {
                userMessage += $"\"{e.Message.Chat.Username}\" ";

            }
            userMessage += $"text: {e.Message.Text}";
            userMessage += "\n";
        }

        public void LoadInfo()
        {
            transport.Clear();
            shipping.Clear();
            registry.Clear();

            // Таблица машины
            try
            {
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

                telegram.registry = registry;
                telegram.Transport = transport;
                telegram.Shipping = shipping;
                if (File.Exists("Save.xlsx"))
                {
                    File.Delete("Save.xlsx");
                }
                ex.WriteToExcel();
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("Интернет соединение отсутствует");
                Application.Exit();
            }
        }

        public Form1()
        {
            InitializeComponent();
            panelRight.Height = buttonTransport.Height;
            panelRight.Top = buttonTransport.Top;
            defaultText = DefaultTextBoxes();
            ClearSelectDataGrid();
            telegram.Bot();
            telegram.Probe(Listen);
        }

        public bool CheckTimer()
        {
            if (timerAnimateFilter.Enabled || timerAnimateTransport.Enabled || timerAnimateShipping.Enabled || timerAnimateRegistry.Enabled)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonTransport_Click(object sender, EventArgs e)
        {
            if (CheckTimer())
            {
                if (dataGridViewFilter.Top == 95)
                {
                    dataGridViewTransport.Top = 710;
                    dataGridViewShipping.Top = 1325;
                    dataGridViewRegistry.Top = 1940;
                }

                panelSearch.Visible = false;
                buttonSearchFirst.Text = "Дата отгрузки";
                buttonSearchSecond.Text = "Гос. номер";
                panelChangeButtons.Visible = true;
                panelFilterButtons.Visible = false;
                panelRight.Height = buttonTransport.Height;
                panelRight.Top = buttonTransport.Top;
                panelTransportBoxes.Visible = true;
                panelShippingBoxes.Visible = false;
                panelRegistryBoxes.Visible = false;
                timerAnimateTransport.Enabled = true;
            }
        }

        private void buttonDaily_Click(object sender, EventArgs e)
        {
            if (CheckTimer())
            {
                panelSearch.Visible = false;
                buttonSearchFirst.Text = "Дата отгрузки";
                buttonSearchSecond.Text = "Количество машин";
                panelChangeButtons.Visible = true;
                panelFilterButtons.Visible = false;
                panelRight.Height = buttonDaily.Height;
                panelRight.Top = buttonDaily.Top;
                panelTransportBoxes.Visible = false;
                panelShippingBoxes.Visible = true;
                panelRegistryBoxes.Visible = false;
                timerAnimateShipping.Enabled = true;
            }
        }

        private void buttonRegistry_Click(object sender, EventArgs e)
        {
            if (CheckTimer())
            {
                if (dataGridViewFilter.Top == 95)
                {
                    dataGridViewTransport.Top = -1750;
                    dataGridViewShipping.Top = -1135;
                    dataGridViewRegistry.Top = -520;
                }

                panelSearch.Visible = false;
                buttonSearchFirst.Text = "Диаметр";
                buttonSearchSecond.Text = "Номер трубы";
                panelChangeButtons.Visible = true;
                panelFilterButtons.Visible = false;
                panelRight.Height = buttonRegistry.Height;
                panelRight.Top = buttonRegistry.Top;
                panelTransportBoxes.Visible = false;
                panelShippingBoxes.Visible = false;
                panelRegistryBoxes.Visible = true;
                timerAnimateRegistry.Enabled = true;
            }
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

            //filter
            List<int[]> answer = sql.GetTotalShipping();
            dataGridViewFilter.Columns.Clear();
            dataGridViewFilter.Columns.AddRange(
                new DataGridViewTextBoxColumn() { Name = "Column1", HeaderText = "Отгружено машин" },
                new DataGridViewTextBoxColumn() { Name = "Column2", HeaderText = "Отгруженно, кг" },
                new DataGridViewTextBoxColumn() { Name = "Column3", HeaderText = "Отгружено труб, шт" },
                new DataGridViewTextBoxColumn() { Name = "Column4", HeaderText = "Оплачено за траспорт, BYN" }
                );

            i = 0;

            for (int j = 0; j < answer.Count - 1; j++)
            {
                dataGridViewFilter.Rows.Add();
            }

            foreach (var el in answer)
            {
                dataGridViewFilter.Rows[i].Cells[0].Value = el[0];
                dataGridViewFilter.Rows[i].Cells[1].Value = el[1];
                dataGridViewFilter.Rows[i].Cells[2].Value = el[2];
                i++;
            }

            Requests requests = new Requests();
            dataGridViewFilter.Rows[0].Cells[3].Value = requests.ConvertPrice(sql.GetTotalPrice());
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (buttonAdd.FlatAppearance.BorderSize == 0)
            {
                buttonRemove.FlatAppearance.BorderSize = 0;
                buttonChange.FlatAppearance.BorderSize = 0;
                buttonAdd.FlatAppearance.BorderSize = 1;
                buttonMake.Text = "Добавить";
                TextBoxClear();
                TextBoxEnabled(false);
                timer1.Enabled = true;
            }
            else
            {
                buttonAdd.FlatAppearance.BorderSize = 0;
                TextBoxClear();
                ClearSelectDataGrid();
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
                TextBoxClear();
                TextBoxEnabled(true);
                timer1.Enabled = true;
            }
            else
            {
                buttonRemove.FlatAppearance.BorderSize = 0;
                TextBoxClear();
                ClearSelectDataGrid();
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
                TextBoxClear();
                TextBoxEnabled(false);
                timer1.Enabled = true;
            }
            else
            {
                buttonChange.FlatAppearance.BorderSize = 0;
                TextBoxClear();
                ClearSelectDataGrid();
                timer2.Enabled = true;
            }
        }

        public void ClearSelectDataGrid()
        {
            dataGridViewRegistry.ClearSelection();
            dataGridViewTransport.ClearSelection();
            dataGridViewShipping.ClearSelection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panelTransport.Left != 0)
            {
                panelTransport.Left -= 5;
            }
            else
            {
                if (dataGridViewRegistry.Top == 95)
                {
                    panelSearch.Top = 582;
                    dataGridViewShipping.Top = 380;
                    labelNameDataBase.Visible = true;
                    dataGridViewShipping.Enabled = false;
                }
                ClearSelectDataGrid();
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (dataGridViewRegistry.Top == 95)
            {
                panelSearch.Top = 391;
                dataGridViewShipping.Top = -520;
                labelNameDataBase.Visible = false;
                dataGridViewShipping.Enabled = true;
            }
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

        public bool CheckTextBoxes()
        {
            bool check = true;

            if (dataGridViewTransport.Top == 95)
            {
                if (textBoxNumber.Text == "Гос. номер")
                {
                    panelNumber.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }
                if (textBoxShipping.Text == "Дата отгрузки" || !Regex.IsMatch(textBoxShipping.Text, @"^\d{4}-\d{2}-\d{2}$"))
                {
                    panelShipping.BackColor = Color.FromArgb(225, 50, 77);
                    if (buttonMake.Text == "Удалить" || buttonMake.Text == "Отредактировать")
                    {
                        panelShipping.BackColor = Color.FromArgb(62, 120, 138);
                    }
                    else
                    {
                        check = false;
                        errorProviderDate.SetError(textBoxShipping, "yyyy-mm-dd");
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
                    if (buttonMake.Text == "Удалить" || buttonMake.Text == "Отредактировать")
                    {
                        panelShipped.BackColor = Color.FromArgb(62, 120, 138);
                    }
                    else
                    {
                        check = false;
                        errorProviderDate.SetError(textBoxShipped, "yyyy-mm-dd");
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
            }
            else if (dataGridViewShipping.Top == 95)
            {
                if (textBoxDate.Text == "Дата" || !Regex.IsMatch(textBoxDate.Text, @"^\d{4}-\d{2}-\d{2}$"))
                {
                    panelDate.BackColor = Color.FromArgb(225, 50, 77);
                    if (buttonMake.Text == "Удалить" || buttonMake.Text == "Отредактировать")
                    {
                        panelDate.BackColor = Color.FromArgb(62, 120, 138);
                    }
                    else
                    {
                        check = false;
                        errorProviderDate.SetError(textBoxDate, "yyyy-mm-dd");
                    }
                }
                else
                {
                    string days = Convert.ToString(Regex.Match(Regex.Match(textBoxDate.Text, @"-\d+$").ToString(), @"\d+"));
                    string month = Convert.ToString(Regex.Match(Regex.Match(textBoxDate.Text, @"-\d+-").ToString(), @"\d+"));
                    if (Convert.ToInt32(month) > 12 || Convert.ToInt32(month) < 0)
                    {
                        panelDate.BackColor = Color.FromArgb(225, 50, 77);
                        check = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(days) > 31 || Convert.ToInt32(days) < 1)
                        {
                            panelDate.BackColor = Color.FromArgb(225, 50, 77);
                            check = false;
                        }
                    }
                }

                if (textBoxTrucks.Text == "Отгружено машин")
                {
                    panelTrucks.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }

                if (textBoxShippingWeight.Text == "Отгружено, кг")
                {
                    panelShippingWeight.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }

                if (textBoxPipes.Text == "Отгружено труб, шт")
                {
                    panelPipes.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }
            }
            else if (dataGridViewRegistry.Top == 95)
            {
                if (textBoxNumberShipping.Text == defaultText["textBoxNumberShipping"])
                {
                    panelNumberShipping.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }

                if (textBoxDiameter.Text == defaultText["textBoxDiameter"])
                {
                    panelDiameter.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }

                if (textBoxPipeNumber.Text == defaultText["textBoxPipeNumber"])
                {
                    panelPipeNumber.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }

                if (textBoxLength.Text == defaultText["textBoxLength"])
                {
                    panelLength.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }

                if (textBoxThickness.Text == defaultText["textBoxThickness"])
                {
                    panelThickness.BackColor = Color.FromArgb(225, 50, 77);
                    check = false;
                }
            }
            return check;
        }

        public void AddToDataBase()
        {
            if (dataGridViewTransport.Top == 95)
            {
                dataGridViewTransport.ClearSelection();

                string number = textBoxNumber.Text;
                string dateShipping = textBoxShipping.Text;
                string dateShipped = textBoxShipped.Text;
                decimal weight = Convert.ToDecimal(textBoxWeight.Text, CultureInfo.InvariantCulture);
                int price = Convert.ToInt32(textBoxPrice.Text);
                string currency = textBoxCurrency.Text.ToUpper();

                if (buttonMake.Text == "Добавить")
                {
                    try
                    {
                        conn.Open();
                        NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO transport VALUES (DEFAULT, '{number}', '{dateShipping}', '{dateShipped}', {weight}, {price}, '{currency}')", conn);
                        command.ExecuteNonQuery();
                        conn.Close();

                        LoadData();
                        TextBoxClear();
                    }
                    catch (NpgsqlException e)
                    {
                        if (Convert.ToString(Regex.Match(e.Message, @"\d+")) == "23505")
                        {
                            panelNumber.BackColor = Color.FromArgb(225, 50, 77);
                            panelShipping.BackColor = Color.FromArgb(225, 50, 77);

                            for (int i = 0; i < dataGridViewTransport.RowCount; i++)
                            {
                                if (dataGridViewTransport.Rows[i].Cells[1].Value != null)
                                {
                                    if (dataGridViewTransport.Rows[i].Cells[1].Value.ToString().Contains(textBoxNumber.Text))
                                    {
                                        DateTime checkDate = DateTime.ParseExact(textBoxShipping.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                                        if (dataGridViewTransport.Rows[i].Cells[2].Value.ToString().Contains($"{checkDate.ToShortDateString()}"))
                                        {
                                            dataGridViewTransport.Rows[i].Cells[1].Selected = true;
                                            dataGridViewTransport.Rows[i].Cells[2].Selected = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        conn.Close();
                    }
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
            else if (dataGridViewShipping.Top == 95)
            {
                dataGridViewShipping.ClearSelection();

                string date = textBoxDate.Text;
                int trucks = Convert.ToInt32(textBoxTrucks.Text);
                int weight = Convert.ToInt32(textBoxShippingWeight.Text);
                int pipes = Convert.ToInt32(textBoxPipes.Text);

                if (buttonMake.Text == "Добавить")
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO shipping VALUES (DEFAULT, '{date}', {trucks}, {weight}, {pipes})", conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    LoadData();

                    TextBoxClear();
                }
                else if (buttonMake.Text == "Удалить")
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand($"delete from shipping where \"number\" = {numberForChange}", conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    LoadData();

                    TextBoxClear();
                }
                else if (buttonMake.Text == "Отредактировать")
                {
                    DateTime dateShipping = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    int days = dateShipping.Day;
                    int month = dateShipping.Month;
                    int year = dateShipping.Year;

                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand($"update shipping set \"Date\" = '{year}-{month}-{days}', \"Truck count\" = {trucks}, \"Weight\" = {weight}, \"Pipes count\" = {pipes} where \"number\" = {numberForChange}", conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    LoadData();

                    TextBoxClear();
                }
            }
            else if (dataGridViewRegistry.Top == 95)
            {
                dataGridViewRegistry.ClearSelection();

                int number = Convert.ToInt32(textBoxNumberShipping.Text);
                int diameter = Convert.ToInt32(textBoxDiameter.Text);
                int pipeNumber = Convert.ToInt32(textBoxPipeNumber.Text);
                int length = Convert.ToInt32(textBoxLength.Text);
                int thickness = Convert.ToInt32(textBoxThickness.Text);
                int weight = Convert.ToInt32(0.02466 * thickness * (diameter - thickness) * length / 1000);

                if (buttonMake.Text == "Добавить")
                {
                    try
                    {
                        conn.Open();
                        NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO registry VALUES (DEFAULT, {number}, {diameter}, {pipeNumber}, {length}, {thickness}, {weight})", conn);
                        command.ExecuteNonQuery();
                        conn.Close();

                        LoadData();

                        TextBoxClear();
                    }
                    catch (NpgsqlException e)
                    {
                        if (Convert.ToString(Regex.Match(e.Message, @"\d+")) == "23503")
                        {
                            panelNumberShipping.BackColor = Color.FromArgb(225, 50, 77);
                        }
                        else if (Convert.ToString(Regex.Match(e.Message, @"\d+")) == "23505")
                        {
                            panelPipeNumber.BackColor = Color.FromArgb(225, 50, 77);

                            for (int i = 0; i < dataGridViewRegistry.RowCount; i++)
                            {
                                if (dataGridViewRegistry.Rows[i].Cells[3].Value != null)
                                {
                                    if (dataGridViewRegistry.Rows[i].Cells[3].Value.ToString().Contains(textBoxPipeNumber.Text))
                                    {
                                        dataGridViewRegistry.Rows[i].Cells[3].Selected = true;
                                        break;
                                    }
                                }
                            }
                        }

                        conn.Close();
                    }
                }
                else if (buttonMake.Text == "Удалить")
                {
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand($"delete from registry where \"Personal\" = {numberForChange}", conn);
                    command.ExecuteNonQuery();
                    conn.Close();

                    LoadData();

                    TextBoxClear();
                }
                else if (buttonMake.Text == "Отредактировать")
                {
                    try
                    {
                        conn.Open();
                        NpgsqlCommand command = new NpgsqlCommand($"update registry set \"number\" = {number}, \"diameter\" = {diameter}, \"Pipe number\" = {pipeNumber}, \"length\" = {length}, \"thickness\" = {thickness}, \"weight\" = {weight} where \"Personal\" = {numberForChange}", conn);
                        command.ExecuteNonQuery();
                        conn.Close();

                        LoadData();

                        TextBoxClear();
                    }
                    catch (NpgsqlException e)
                    {
                        if (Convert.ToString(Regex.Match(e.Message, @"\d+")) == "23505")
                        {
                            panelPipeNumber.BackColor = Color.FromArgb(225, 50, 77);

                            for (int i = 0; i < dataGridViewRegistry.RowCount; i++)
                            {
                                if (dataGridViewRegistry.Rows[i].Cells[3].Value != null)
                                {
                                    if (dataGridViewRegistry.Rows[i].Cells[3].Value.ToString().Contains(textBoxPipeNumber.Text))
                                    {
                                        dataGridViewRegistry.Rows[i].Cells[3].Selected = true;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (Convert.ToString(Regex.Match(e.Message, @"\d+")) == "23503")
                        {
                            panelNumberShipping.BackColor = Color.FromArgb(225, 50, 77);
                        }

                        conn.Close();
                    }
                }
            }
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                AddToDataBase();
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
                errorProviderDate.Clear();
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
                errorProviderDate.Clear();
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
                    dataGridViewFilter.Top -= 15;
                }
                else
                {
                    dataGridViewShipping.Top += 15;
                    dataGridViewTransport.Top += 15;
                    dataGridViewRegistry.Top += 15;
                    dataGridViewFilter.Top += 15;
                }
            }
            else
            {
                panelSearch.Visible = true;
                timerAnimateShipping.Enabled = false;
                red = 49;
                green = 52;
                blue = 61;
                timerFirstAnimation.Enabled = true;
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
                    dataGridViewRegistry.Top -= 15;
                    dataGridViewFilter.Top -= 15;
                }
                else
                {
                    dataGridViewShipping.Top += 15;
                    dataGridViewTransport.Top += 15;
                    dataGridViewRegistry.Top += 15;
                    dataGridViewFilter.Top += 15;
                }
            }
            else
            {
                panelSearch.Visible = true;
                timerAnimateTransport.Enabled = false;
                red = 49;
                green = 52;
                blue = 61;
                timerFirstAnimation.Enabled = true;
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
                    dataGridViewFilter.Top -= 15;
                }
                else
                {
                    dataGridViewShipping.Top += 15;
                    dataGridViewTransport.Top += 15;
                    dataGridViewRegistry.Top += 15;
                    dataGridViewFilter.Top += 15;
                }
            }
            else
            {
                panelSearch.Visible = true;
                timerAnimateRegistry.Enabled = false;
                red = 49;
                green = 52;
                blue = 61;
                timerFirstAnimation.Enabled = true;
            }
        }

        private void dataGridViewTransport_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridViewTransport.CurrentCell.RowIndex;
            int indexColumn = dataGridViewTransport.CurrentCell.ColumnIndex;

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
            ChangeToDefaultText();

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

        private void textBoxDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 45 && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelDate.BackColor = Color.FromArgb(62, 120, 138);
                errorProviderDate.Clear();
            }
        }

        private void textBoxTrucks_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelTrucks.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxShippingWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelShippingWeight.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxPipes_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelPipes.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void dataGridViewShipping_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridViewShipping.CurrentCell.RowIndex;
            numberForChange = Convert.ToInt32(dataGridViewShipping.Rows[index].Cells[0].Value);

            textBoxDate.Text = Convert.ToString(dataGridViewShipping.Rows[index].Cells[1].Value);
            textBoxTrucks.Text = Convert.ToString(dataGridViewShipping.Rows[index].Cells[2].Value);
            textBoxShippingWeight.Text = Convert.ToString(dataGridViewShipping.Rows[index].Cells[3].Value);
            textBoxPipes.Text = Convert.ToString(dataGridViewShipping.Rows[index].Cells[4].Value);

            ChangeStyleBoxes();
        }

        public Dictionary<string, string> DefaultTextBoxes()
        {
            Dictionary<string, string> defaultText = new Dictionary<string, string>();
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
                                            defaultText.Add(box.Name, box.Text);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return defaultText;
        }

        public void ChangeToDefaultText()
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
                                            box.Text = defaultText[box.Name];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void textBoxNumberShipping_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelNumberShipping.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelDiameter.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxPipeNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelPipeNumber.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelLength.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxThickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                panelThickness.BackColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void textBoxPipeWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxNumberShipping_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == defaultText[(sender as TextBox).Name])
            {
                (sender as TextBox).Text = "";
                panelNumberShipping.BackColor = Color.FromArgb(62, 120, 138);
                (sender as TextBox).ForeColor = Color.FromArgb(143, 201, 219);
                (sender as TextBox).Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxNumberShipping_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = defaultText[(sender as TextBox).Name];
                (sender as TextBox).ForeColor = Color.FromArgb(125, 125, 125);
                (sender as TextBox).Font = new Font(textBoxNumber.Font.Name, 10, textBoxNumber.Font.Style);
                dataGridViewShipping.ClearSelection();
            }
            else
            {
                string num = (sender as TextBox).Text;
                dataGridViewShipping.ClearSelection();
                for (int i = 0; i < dataGridViewShipping.RowCount; i++)
                {
                    if (dataGridViewShipping.Rows[i].Cells[0].Value != null)
                    {
                        if (dataGridViewShipping.Rows[i].Cells[0].Value.ToString().Contains(num))
                        {
                            dataGridViewShipping.Rows[i].Cells[0].Selected = true;
                            dataGridViewShipping.Rows[i].Cells[1].Selected = true;
                            dataGridViewShipping.Rows[i].Cells[2].Selected = true;
                            dataGridViewShipping.Rows[i].Cells[3].Selected = true;
                            dataGridViewShipping.Rows[i].Cells[4].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void textBoxDiameter_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == defaultText[(sender as TextBox).Name])
            {
                (sender as TextBox).Text = "";
                panelDiameter.BackColor = Color.FromArgb(62, 120, 138);
                (sender as TextBox).ForeColor = Color.FromArgb(143, 201, 219);
                (sender as TextBox).Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxDiameter_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = defaultText[(sender as TextBox).Name];
                (sender as TextBox).ForeColor = Color.FromArgb(125, 125, 125);
                (sender as TextBox).Font = new Font(textBoxNumber.Font.Name, 10, textBoxNumber.Font.Style);
            }
        }

        private void textBoxPipeNumber_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == defaultText[(sender as TextBox).Name])
            {
                (sender as TextBox).Text = "";
                panelPipeNumber.BackColor = Color.FromArgb(62, 120, 138);
                (sender as TextBox).ForeColor = Color.FromArgb(143, 201, 219);
                (sender as TextBox).Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxPipeNumber_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = defaultText[(sender as TextBox).Name];
                (sender as TextBox).ForeColor = Color.FromArgb(125, 125, 125);
                (sender as TextBox).Font = new Font(textBoxNumber.Font.Name, 10, textBoxNumber.Font.Style);
            }
        }

        private void textBoxLength_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == defaultText[(sender as TextBox).Name])
            {
                (sender as TextBox).Text = "";
                panelLength.BackColor = Color.FromArgb(62, 120, 138);
                (sender as TextBox).ForeColor = Color.FromArgb(143, 201, 219);
                (sender as TextBox).Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxLength_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = defaultText[(sender as TextBox).Name];
                (sender as TextBox).ForeColor = Color.FromArgb(125, 125, 125);
                (sender as TextBox).Font = new Font(textBoxNumber.Font.Name, 10, textBoxNumber.Font.Style);
            }
        }

        private void textBoxThickness_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == defaultText[(sender as TextBox).Name])
            {
                (sender as TextBox).Text = "";
                panelThickness.BackColor = Color.FromArgb(62, 120, 138);
                (sender as TextBox).ForeColor = Color.FromArgb(143, 201, 219);
                (sender as TextBox).Font = new Font(textBoxShipped.Font.Name, 11, textBoxShipped.Font.Style);
            }
        }

        private void textBoxThickness_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = defaultText[(sender as TextBox).Name];
                (sender as TextBox).ForeColor = Color.FromArgb(125, 125, 125);
                (sender as TextBox).Font = new Font(textBoxNumber.Font.Name, 10, textBoxNumber.Font.Style);
            }
        }

        private void textBoxPipeWeight_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBoxPipeWeight_Leave(object sender, EventArgs e)
        {
           
        }

        private void dataGridViewRegistry_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridViewRegistry.CurrentCell.RowIndex;
            numberForChange = Convert.ToInt32(dataGridViewRegistry.Rows[index].Cells[0].Value);

            for (int i = 0; i < dataGridViewShipping.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewShipping.ColumnCount; j++)
                {
                    if (dataGridViewShipping.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridViewShipping.Rows[i].Cells[j].Value.ToString().Contains(Convert.ToString(dataGridViewRegistry.Rows[index].Cells[1].Value)))
                        {
                            textBoxNumberShipping.Text = Convert.ToString(dataGridViewShipping.Rows[i].Cells[0].Value);
                        }
                    }
                }
            }

            textBoxDiameter.Text = Convert.ToString(dataGridViewRegistry.Rows[index].Cells[2].Value);
            textBoxPipeNumber.Text = Convert.ToString(dataGridViewRegistry.Rows[index].Cells[3].Value);
            textBoxLength.Text = Convert.ToString(dataGridViewRegistry.Rows[index].Cells[4].Value);
            textBoxThickness.Text = Convert.ToString(dataGridViewRegistry.Rows[index].Cells[5].Value);

            ChangeStyleBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        int red = 49, green = 52, blue = 61;
        int secondRed = 41, secondGreen = 44, secondBlue = 51;

        private void timerAnimateFilter_Tick(object sender, EventArgs e)
        {
            if (dataGridViewFilter.Top != 95)
            {
                if (dataGridViewFilter.Top > 95)
                {
                    dataGridViewShipping.Top -= 15;
                    dataGridViewTransport.Top -= 15;
                    dataGridViewRegistry.Top -= 15;
                    dataGridViewFilter.Top -= 15;
                }
                else
                {
                    dataGridViewShipping.Top += 15;
                    dataGridViewTransport.Top += 15;
                    dataGridViewRegistry.Top += 15;
                    dataGridViewFilter.Top += 15;
                }
            }
            else
            {
                panelFilterButtons.Visible = true;
                timerAnimateFilter.Enabled = false;
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if (CheckTimer())
            {
                if (dataGridViewTransport.Top == 95)
                {
                    dataGridViewFilter.Top = -520;
                }
                else if (dataGridViewShipping.Top == 95)
                {
                    dataGridViewFilter.Top = 1325;
                }
                else if (dataGridViewRegistry.Top == 95)
                {
                    dataGridViewFilter.Top = 710;
                }

                panelSearch.Visible = false;
                panelChangeButtons.Visible = false;
                panelRight.Height = buttonFilter.Height;
                panelRight.Top = buttonFilter.Top;
                panelTransportBoxes.Visible = false;
                panelShippingBoxes.Visible = false;
                panelRegistryBoxes.Visible = false;
                timerAnimateFilter.Enabled = true;
            }
        }

        private void buttonTotalShipping_Click(object sender, EventArgs e)
        {
            List<int[]> answer = sql.GetTotalShipping();
            dataGridViewFilter.Columns.Clear();
            dataGridViewFilter.Columns.AddRange(
                new DataGridViewTextBoxColumn() { Name = "Column1", HeaderText = "Отгружено машин" },
                new DataGridViewTextBoxColumn() { Name = "Column2", HeaderText = "Отгруженно, кг" },
                new DataGridViewTextBoxColumn() { Name = "Column3", HeaderText = "Отгружено труб, шт" },
                new DataGridViewTextBoxColumn() { Name = "Column4", HeaderText = "Оплачено за траспорт, BYN" }

                );

            int i = 0;

            for (int j = 0; j < answer.Count - 1; j++)
            {
                dataGridViewFilter.Rows.Add();
            }

            foreach (var el in answer)
            {
                dataGridViewFilter.Rows[i].Cells[0].Value = el[0];
                dataGridViewFilter.Rows[i].Cells[1].Value = el[1];
                dataGridViewFilter.Rows[i].Cells[2].Value = el[2];
                i++;
            }
            Requests requests = new Requests();
            dataGridViewFilter.Rows[0].Cells[3].Value = requests.ConvertPrice(sql.GetTotalPrice());
        }

        private void buttonTotalRegistry_Click(object sender, EventArgs e)
        {
            List<int[]> answer = sql.GetTotalRegistry();
            dataGridViewFilter.Columns.Clear();
            dataGridViewFilter.Columns.AddRange(
                new DataGridViewTextBoxColumn() { Name = "Column1", HeaderText = "Общая длина" },
                new DataGridViewTextBoxColumn() { Name = "Column2", HeaderText = "Общий вес" },
                new DataGridViewTextBoxColumn() { Name = "Column3", HeaderText = "Средняя длина" },
                new DataGridViewTextBoxColumn() { Name = "Column4", HeaderText = "Средняя толщина" }
                );

            int i = 0;

            for (int j = 0; j < answer.Count - 1; j++)
            {
                dataGridViewFilter.Rows.Add();
            }

            foreach (var el in answer)
            {
                dataGridViewFilter.Rows[i].Cells[0].Value = el[0];
                dataGridViewFilter.Rows[i].Cells[1].Value = el[1];
                dataGridViewFilter.Rows[i].Cells[2].Value = el[2];
                dataGridViewFilter.Rows[i].Cells[3].Value = el[3];
                i++;
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string search = "";
            if ((sender as TextBox).Text != "Поиск")
            {
                search = (sender as TextBox).Text;
            }
            if (dataGridViewTransport.Top == 95)
            {
                dataGridViewTransport.Rows.Clear();
                int i = 0;

                foreach (Transport el in transport)
                {
                    if (el.DateShipping.StartsWith(search) && buttonSearchFirst.FlatAppearance.BorderSize == 1)
                    {
                        dataGridViewTransport.Rows.Add();

                        dataGridViewTransport.Rows[i].Cells[0].Value = el.Number;
                        dataGridViewTransport.Rows[i].Cells[1].Value = el.StateNubmer;
                        dataGridViewTransport.Rows[i].Cells[2].Value = el.DateShipping;
                        dataGridViewTransport.Rows[i].Cells[3].Value = el.DateShipped;
                        dataGridViewTransport.Rows[i].Cells[4].Value = el.Weight;
                        dataGridViewTransport.Rows[i].Cells[5].Value = $"{el.Price} {el.Currency}";
                        i++;
                    }
                    else if (el.StateNubmer.StartsWith(search) && buttonSearchSecond.FlatAppearance.BorderSize == 1)
                    {
                        dataGridViewTransport.Rows.Add();

                        dataGridViewTransport.Rows[i].Cells[0].Value = el.Number;
                        dataGridViewTransport.Rows[i].Cells[1].Value = el.StateNubmer;
                        dataGridViewTransport.Rows[i].Cells[2].Value = el.DateShipping;
                        dataGridViewTransport.Rows[i].Cells[3].Value = el.DateShipped;
                        dataGridViewTransport.Rows[i].Cells[4].Value = el.Weight;
                        dataGridViewTransport.Rows[i].Cells[5].Value = $"{el.Price} {el.Currency}";
                        i++;
                    }
                }
            }
            else if (dataGridViewShipping.Top == 95)
            {
                dataGridViewShipping.Rows.Clear();
                int i = 0;

                foreach (Shipping el in shipping)
                {
                    if (el.Date.StartsWith(search) && buttonSearchFirst.FlatAppearance.BorderSize == 1)
                    {
                        dataGridViewShipping.Rows.Add();

                        dataGridViewShipping.Rows[i].Cells[0].Value = el.Number;
                        dataGridViewShipping.Rows[i].Cells[1].Value = el.Date;
                        dataGridViewShipping.Rows[i].Cells[2].Value = el.Trucks;
                        dataGridViewShipping.Rows[i].Cells[3].Value = el.Weight;
                        dataGridViewShipping.Rows[i].Cells[4].Value = el.Pipes;
                        i++;
                    }
                    else if (el.Trucks.ToString().StartsWith(search) && buttonSearchSecond.FlatAppearance.BorderSize == 1)
                    {
                        dataGridViewShipping.Rows.Add();

                        dataGridViewShipping.Rows[i].Cells[0].Value = el.Number;
                        dataGridViewShipping.Rows[i].Cells[1].Value = el.Date;
                        dataGridViewShipping.Rows[i].Cells[2].Value = el.Trucks;
                        dataGridViewShipping.Rows[i].Cells[3].Value = el.Weight;
                        dataGridViewShipping.Rows[i].Cells[4].Value = el.Pipes;
                        i++;
                    }
                }
            }
            else if (dataGridViewRegistry.Top == 95)
            {
                dataGridViewRegistry.Rows.Clear();
                int i = 0;

                foreach (Registry el in registry)
                {
                    if (el.Diameter.ToString().StartsWith(search) && buttonSearchFirst.FlatAppearance.BorderSize == 1)
                    {
                        dataGridViewRegistry.Rows.Add();

                        dataGridViewRegistry.Rows[i].Cells[0].Value = el.Number;
                        dataGridViewRegistry.Rows[i].Cells[1].Value = el.Date;
                        dataGridViewRegistry.Rows[i].Cells[2].Value = el.Diameter;
                        dataGridViewRegistry.Rows[i].Cells[3].Value = el.PipeNumber;
                        dataGridViewRegistry.Rows[i].Cells[4].Value = el.Length;
                        dataGridViewRegistry.Rows[i].Cells[5].Value = el.Thickness;
                        dataGridViewRegistry.Rows[i].Cells[6].Value = el.Weight;
                        i++; 
                    }
                    else if (el.PipeNumber.ToString().StartsWith(search) && buttonSearchSecond.FlatAppearance.BorderSize == 1)
                    {
                        dataGridViewRegistry.Rows.Add();

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
            }
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "Поиск")
            {
                (sender as TextBox).Text = "";
                (sender as TextBox).ForeColor = Color.FromArgb(143, 201, 219);
                (sender as TextBox).Font = new Font((sender as TextBox).Font.Name, 11, (sender as TextBox).Font.Style);
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = "Поиск";
                (sender as TextBox).ForeColor = Color.FromArgb(125, 125, 125);
                (sender as TextBox).Font = new Font((sender as TextBox).Font.Name, 10, (sender as TextBox).Font.Style);
            }
        }

        private void buttonSearchFirst_Click(object sender, EventArgs e)
        {
            if (buttonSearchFirst.FlatAppearance.BorderSize == 0)
            {
                buttonSearchFirst.FlatAppearance.BorderSize = 1;
                buttonSearchSecond.FlatAppearance.BorderSize = 0;
                textBoxSearch.Text = "Поиск";
                textBoxSearch.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxSearch.Font = new Font(textBoxSearch.Font.Name, 10, textBoxSearch.Font.Style);
            }
        }

        private void buttonSearchSecond_Click(object sender, EventArgs e)
        {
            if (buttonSearchSecond.FlatAppearance.BorderSize == 0)
            {
                buttonSearchFirst.FlatAppearance.BorderSize = 0;
                buttonSearchSecond.FlatAppearance.BorderSize = 1;
                textBoxSearch.Text = "Поиск";
                textBoxSearch.ForeColor = Color.FromArgb(125, 125, 125);
                textBoxSearch.Font = new Font(textBoxSearch.Font.Name, 10, textBoxSearch.Font.Style);
            }
        }

        private void buttonTotalMonths_Click(object sender, EventArgs e)
        {
            List<int[]> answer = sql.GetTotalMonthsShipping();
            dataGridViewFilter.Columns.Clear();
            dataGridViewFilter.Columns.AddRange(
                new DataGridViewTextBoxColumn() { Name = "Column", HeaderText = "Месяц" },
                new DataGridViewTextBoxColumn() { Name = "Column1", HeaderText = "Отгружено машин" },
                new DataGridViewTextBoxColumn() { Name = "Column2", HeaderText = "Отгруженно, кг" },
                new DataGridViewTextBoxColumn() { Name = "Column3", HeaderText = "Отгружено труб, шт" }

                );

            int i = 0;

            for (int j = 0; j < answer.Count - 1; j++)
            {
                dataGridViewFilter.Rows.Add();
            }

            foreach (var el in answer)
            {
                string month = "";
                if (el[0] == 1)
                {
                    month = "Январь";
                }
                else if (el[0] == 2)
                {
                    month = "Февраль";
                }
                else if (el[0] == 3)
                {
                    month = "Март";
                }
                else if (el[0] == 4)
                {
                    month = "Апрель";
                }
                else if (el[0] == 5)
                {
                    month = "Май";
                }
                else if (el[0] == 6)
                {
                    month = "Июнь";
                }
                else if (el[0] == 7)
                {
                    month = "Июль";
                }
                else if (el[0] == 8)
                {
                    month = "Август";
                }
                else if (el[0] == 9)
                {
                    month = "Сентябрь";
                }
                else if (el[0] == 10)
                {
                    month = "Октябрь";
                }
                else if (el[0] == 11)
                {
                    month = "Ноябрь";
                }
                else
                {
                    month = "Декабрь";
                }
                dataGridViewFilter.Rows[i].Cells[0].Value = month;
                dataGridViewFilter.Rows[i].Cells[1].Value = el[1];
                dataGridViewFilter.Rows[i].Cells[2].Value = el[2];
                dataGridViewFilter.Rows[i].Cells[3].Value = el[2];
                i++;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists("Save.xlsx"))
            {
                File.Delete("Save.xlsx");
            }
        }

        private void timerSecondAnimation_Tick(object sender, EventArgs e)
        {
            if (secondRed != 49)
            {
                buttonChange.BackColor = Color.FromArgb(secondRed, secondGreen, secondBlue);
                buttonRemove.BackColor = Color.FromArgb(secondRed, secondGreen, secondBlue);
                buttonAdd.BackColor = Color.FromArgb(secondRed, secondGreen, secondBlue);
                secondRed++;
                secondGreen++;
                secondBlue++;
                timerSecondAnimation.Interval = 100;
            }
            else
            {
                buttonChange.BackColor = Color.FromArgb(49, 52, 61);
                buttonRemove.BackColor = Color.FromArgb(49, 52, 61);
                buttonAdd.BackColor = Color.FromArgb(49, 52, 61);
                timerSecondAnimation.Enabled = false;
                timerFirstAnimation.Enabled = true;
            }
        }

        private void timerFirstAnimation_Tick(object sender, EventArgs e)
        {
            if (red != 41)
            {
                buttonChange.BackColor = Color.FromArgb(red, green, blue);
                buttonRemove.BackColor = Color.FromArgb(red, green, blue);
                buttonAdd.BackColor = Color.FromArgb(red, green, blue);
                red--;
                green--;
                blue--;
            }
            else
            {
                buttonChange.BackColor = Color.FromArgb(41, 44, 51);
                buttonRemove.BackColor = Color.FromArgb(41, 44, 51);
                buttonAdd.BackColor = Color.FromArgb(41, 44, 51);
                timerFirstAnimation.Enabled = false;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            timerSecondAnimation.Enabled = true;
        }
    }
}