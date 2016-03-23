using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.figures = new List<AbstractFigure>();
            //this.figures = new List<AbstractFigure>()
            //{
            //    new Circle(new Point(100, 250), 50),
            //    new MyRectangle(new Point(400, 400), 150, 300),
            //    new Line(new Point(450, 300), new Point(100, 850)),
            //    new Triange(new Point(450, 300), new Point(85, 700), new Point(20, 30)),
            //};
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.XmlDeserializeData("figure.xml");
            this.BinarySerializeData();
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
    }
}