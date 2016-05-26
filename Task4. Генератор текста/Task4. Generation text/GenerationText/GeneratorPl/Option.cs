using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorPl
{
    public partial class Option : Form
    {
        private Form1 form1;
        private string path;
        public Option(Form1 f1)
        {
            InitializeComponent();
            form1 = f1;
        }

        private void Option_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            numericUpDown1.Value = form1.N;
            numericUpDown1.Maximum = 32;
            numericUpDown1.Minimum = 1;
        }

        private void Option_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if(openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                path = openFileDialog1.FileName;
                listBox1.Items.Clear();
                listBox1.Items.Add(path);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            form1.N = (int)numericUpDown1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
