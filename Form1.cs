using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticProgram
{
    public partial class Form1 : Form
    {
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
        }

        private void buttonDaily_Click(object sender, EventArgs e)
        {
            panelRight.Height = buttonDaily.Height;
            panelRight.Top = buttonDaily.Top;
        }

        private void buttonRegistry_Click(object sender, EventArgs e)
        {
            panelRight.Height = buttonRegistry.Height;
            panelRight.Top = buttonRegistry.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
