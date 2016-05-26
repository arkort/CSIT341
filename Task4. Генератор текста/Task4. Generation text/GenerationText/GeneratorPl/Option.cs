using System;
using System.Windows.Forms;

namespace GeneratorPl
{
    public partial class Option : Form
    {
        private Form1 form1;
        private string tempPath;
        private int tempCountWords;

        public Option(Form1 f1)
        {
            InitializeComponent();
            form1 = f1;
        }

        private void Option_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            tempCountWords = form1.N;
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
            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                tempPath = openFileDialog1.FileName;
                listBox1.Items.Clear();
                listBox1.Items.Add(tempPath);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tempCountWords = (int)numericUpDown1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.N = tempCountWords;
            Common.GrahpLogic.AddFile(tempPath);
            MessageBox.Show("Текст успешно добавлен");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}