using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task3
{
    public partial class drawingForm : Form
    {
        Canvas drawingCanvas;
        BinaryFormatter fileSaver;
        XmlDocument doc;
        public drawingForm()
        {
            InitializeComponent();
            fileSaver = new BinaryFormatter();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawingCanvas?.Draw(e.Graphics);
        }

        private void openXmlFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chooseDrawFileDialog.Filter = "Xml files|*.xml";
            if (chooseDrawFileDialog.ShowDialog() == DialogResult.OK)
            {
                doc = new XmlDocument();
                doc.Load(chooseDrawFileDialog.FileName);
                doc.Schemas.Add(null, "ValidateFigures.xsd");
                drawingCanvas = new Canvas(doc);
                drawingCanvas.Draw(this.CreateGraphics());
            }
            else
            {
                return;
            }
        }

        private void saveToBinaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveBinary.ShowDialog() == DialogResult.OK)
            {
                using (FileStream saveFileStream = new FileStream(saveBinary.FileName, FileMode.Create))
                {
                    fileSaver.Serialize(saveFileStream, drawingCanvas);
                }
            }
            else
            {
                return;
            }
        }

        private void loadFromBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chooseDrawFileDialog.Filter = "Binary files|*.dat";
            if (chooseDrawFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream loadFileStream = new FileStream(chooseDrawFileDialog.FileName, FileMode.Open))
                {
                    drawingCanvas = (Canvas)fileSaver.Deserialize(loadFileStream);
                    drawingCanvas.Draw(this.CreateGraphics());
                }
            }
            else
            {
                return;
            }
        }
    }
}
