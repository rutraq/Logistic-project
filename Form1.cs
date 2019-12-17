using Npgsql;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;

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
                            Weight = Convert.ToDecimal(record["Weight"]),
                            Price = Convert.ToInt32(record["Price"]),
                            Currency = Convert.ToString(record["Currency"])
                        });
                    }
                    catch (System.InvalidCastException)
                    {
                        transport.Add(new Transport
                        {
                            Number = Convert.ToInt32(record["Number"]),
                            StateNubmer = Convert.ToString(record["State number"]),
                            DateShipping = Convert.ToDateTime(record["Date shipping"]).ToShortDateString(),
                            DateShipped = Convert.ToString(record["date shipped"]),
                            Weight = Convert.ToDecimal(record["Weight"]),
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
    }
}
