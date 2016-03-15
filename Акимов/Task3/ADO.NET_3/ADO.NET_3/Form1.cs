using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET_3
{
    public partial class Form1 : Form
    {
        public string k;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = openFileDialog1.FileName;
                k = textBox1.Text;
            }
            button2.Visible = true;
            button1.Visible = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!button1.Visible)
            {
                Vision.ShowOn(k, e.Graphics);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            Vision.Serial(k);
        }
    }
}
