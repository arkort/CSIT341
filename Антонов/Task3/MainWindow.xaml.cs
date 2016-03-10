using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Xml.Serialization;

namespace Task3
{
    public partial class MainWindow : Window
    {
        List<Figure> figures;
        XmlSerializer xmlSerializer;
        string inputFile = "input.xml";
        string outputFile = "output.dat";

        public MainWindow()
        {
            InitializeComponent();

            figures = new List<Figure>();
            xmlSerializer = new XmlSerializer(typeof(List<Figure>), new XmlRootAttribute("figures"));

            deserializeXML();
            drawFigures();
            serializeToBinary(figures);
        }

        private void deserializeXML()
        {
            using (FileStream fileStream = new FileStream(inputFile, FileMode.Open))
            {
                try
                {
                    figures = (List<Figure>)xmlSerializer.Deserialize(fileStream);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void drawFigures()
        {
            foreach (var figure in figures)
            {
                try
                {
                    figure.Draw(mainCanvas);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void serializeToBinary(List<Figure> figures)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream(outputFile, FileMode.OpenOrCreate))
            {
                try
                {
                    binFormatter.Serialize(fileStream, figures);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
