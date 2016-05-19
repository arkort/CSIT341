using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task3.Figures;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task3
{
    public partial class Form1 : Form
    {
        private List <Figure> AllFigures = new List<Figure>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));

            using (FileStream fileStream = new FileStream("D:/Desktop/Task3/Figures.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, AllFigures);
            }
             */


         //   this.Deserialize("XMLFile.xml");
        //    this.BinarySerialize();
            this.BinaryDeserialize();
        }

        public void Deserialize(string PathToXML)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));
            using (FileStream fileStream = new FileStream(PathToXML, FileMode.Open))
            {
                XmlReader reader = XmlReader.Create(fileStream);
                AllFigures = (List<Figure>)formatter.Deserialize(reader);
            }
        }

        public void BinaryDeserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("Figures.dat", FileMode.OpenOrCreate))
            {
                AllFigures = (List <Figure>)formatter.Deserialize(fileStream);
            }
        }
        public void BinarySerialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("Figures.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, AllFigures);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var Figure in AllFigures)
            {
                Figure.Draw(e.Graphics);
            }
        }

        
    }
}
