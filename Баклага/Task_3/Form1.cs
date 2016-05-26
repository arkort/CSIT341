using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using Task_3.Figure;

namespace Task_3
{
    public partial class Form1 : Form
    {
        private IList<AbstractFigure> figures;

        public Form1()
        {
            InitializeComponent();
        }

     

        public void XmlDeserializeData(string nameOfFile)
        {
            XmlSerializer read = new XmlSerializer(typeof(List<AbstractFigure>));
            XmlReader reader = XmlReader.Create(new FileStream(nameOfFile, FileMode.Open));
            figures = (List<AbstractFigure>)read.Deserialize(reader);
        }

        public void BinarySerializeData()
        {
            BinaryFormatter write = new BinaryFormatter();
            write.Serialize(new FileStream("figures.dat", FileMode.OpenOrCreate), figures);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            foreach (var figure in figures)
            {
                figure.Draw(gr);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Location = new Point(0, 0);
            this.figures = new List<AbstractFigure>();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.XmlDeserializeData("Figures.xml");
            this.BinarySerializeData();
        }
    }
}