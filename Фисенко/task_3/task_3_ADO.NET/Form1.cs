using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace task_3_ADO.NET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BinaryFormatter BiFormatter = new BinaryFormatter();
        List<TFigure> LF = new List<TFigure>();

        private void PaintLF()
        {
            Graphics G = pictureBox1.CreateGraphics();
            foreach (var lf in LF) lf.Paint(G);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1_Resize(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextReader reader;
            XmlSerializer serializer;
            serializer = new XmlSerializer(typeof(List<TFigure>));
            reader = new StreamReader("figure.xml");
            try
            {
                List<TFigure> deserial = (List<TFigure>)serializer.Deserialize(reader);
                LF = deserial;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не прочиталось" + ex.ToString());
            };
            reader.Close();
            PaintLF();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("1.dat", FileMode.Create, FileAccess.Write))
            {
                BiFormatter.Serialize(fs, LF);
                fs.Close();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = Width - pictureBox1.Left;
            pictureBox1.Height = Height - pictureBox1.Top;
        }
    }
}
