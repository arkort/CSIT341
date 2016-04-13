using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Solution3
{
    public partial class Form1 : Form
    {
        List<Figure> figures;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Figure i in figures)
            {
                i.Draw(g);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            figures =(List<Figure>)(new XmlSerializer(typeof(List<Figure>), new Type[] { typeof(Line), typeof(Triangle), typeof(Cicle), typeof(Square) })).Deserialize(new StreamReader("input.xml"));
            SerializeFigures();
        }
        private void SerializeFigures()
        {
            BinaryFormatter ser = new BinaryFormatter();
            using (FileStream wr=new FileStream("output.bin",FileMode.Create))
            {
                foreach (Figure i in figures)
                {
                    ser.Serialize(wr, i);
                }
            }
        }
    }
}
