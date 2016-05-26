using System;
using System.Windows.Forms;
using GenerationText.BLL;

namespace GeneratorPl
{
    public partial class Form1 : Form
    {
        private Form option;
        private int countWords = 10;

        public Form1()
        {
            InitializeComponent();
        }

        public int N
        {
            get
            {
                return countWords;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Is not pozitive");//исправить
                }

                countWords = value;
            }
        }

        private void изФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ((GenerationLogic)Common.GrahpLogic).AddFile(openFileDialog1.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void случайнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var wods = ((GenerationLogic)Common.GrahpLogic).GetWords(countWords);
                foreach (var item in wods)
                {
                    listBox1.Items.Add(item);
                }

                listBox1.Items.Add("-----------");
            }
            catch
            {
            }
        }

        private void алгоритмомМарковаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var words = Common.MarkovLogic.GetWords(countWords);
                foreach (var item in words)
                {
                    listBox1.Items.Add(item);
                }

                listBox1.Items.Add("-----------");
            }
            catch
            {
                listBox1.Items.Add("Не хватает мощности текста");
                listBox1.Items.Add("-----------");
            }
        }

        //!!!
        private void текстСОпределеннымКоличествомСловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var words = ((GenerationLogic)Common.GrahpLogic).GetWords(countWords);
                foreach (var item in words)
                {
                    listBox1.Items.Add(item);
                }

                listBox1.Items.Add("-----------");
            }
            catch
            {
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option = new Option(this);
            Hide();
            option.FormClosed += (object o, FormClosedEventArgs evnt) => { Show(); };
            option.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
    }
}