using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace adoTask3
{
    public partial class Form1 : Form
    {
        private IList<Figure> figures;

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            figures = new List<Figure>();            
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = new Point(0, 0);         

            this.XmlDeserializeData("figures.xml");
            this.BinarySerializeData();

        }

        public void XmlDeserializeData(string nameOfFile)
        {
            XmlSerializer read = new XmlSerializer(typeof(List<Figure>));
            XmlReader reader = XmlReader.Create(new FileStream(nameOfFile, FileMode.Open));
            figures = (List<Figure>)read.Deserialize(reader);
        }

        public void BinarySerializeData()
        {
            BinaryFormatter write = new BinaryFormatter();
            write.Serialize(new FileStream("figures.dat", FileMode.OpenOrCreate), figures);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var figure in this.figures)
            {
                figure.Draw(g);
            }
        }        
    }
}
