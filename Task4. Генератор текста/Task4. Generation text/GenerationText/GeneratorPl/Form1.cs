using GenerationText.BLL;
using GenerationTextMarvoc.BLL;
using System;
using System.Windows.Forms;

namespace GeneratorPl
{
    public partial class Form1 : Form
    {
        private IGenerationLogic GrahpLogic = new GenerationLogic();
        private GenMarkovText MarkovLogic = new GenMarkovText();

        private int n = 10;

        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            button1.Visible = false;
        }

        public int N
        {
            get
            {
                return n;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Is not pozitive");//исправить
                }

                n = value;
            }
        }

        private void сВыборомКолчичестваСловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var wods = ((GenerationLogic)GrahpLogic).GetWords(n);
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

        private void изФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ((GenerationLogic)GrahpLogic).AddFile(openFileDialog1.FileName);
            }
        }

        private void случайнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var wods = GrahpLogic.GetWords();
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

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void генерацияАлгоримомМарковаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var wods = MarkovLogic.GetWords();
                foreach (var item in wods)
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

        private void ввестиТекстToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void задатьКоличесвоСловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) < 0)
            {
                MessageBox.Show("Отрицательное количество слов");
                n = 10;
            }
            else
            {
                n = int.Parse(textBox1.Text);

                textBox1.Visible = false;
                button1.Visible = false;
            }
        }
    }
}