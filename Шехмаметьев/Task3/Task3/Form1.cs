using System;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Schema;
using System.Drawing;

namespace Task3
{
    public partial class drawingForm : Form
    {
        Canvas drawingCanvas;
        BinaryFormatter fileSaver;
        public drawingForm()
        {
            InitializeComponent();
            fileSaver = new BinaryFormatter();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (drawingCanvas != null)
            {
                drawingCanvas.Draw(e.Graphics);
            }
        }

        private void openXmlFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chooseDrawFileDialog.Filter = "Xml files|*.xml";
            chooseDrawFileDialog.InitialDirectory = Path.GetFullPath(@"..\..\");
            XmlDocument doc = new XmlDocument();
            if (chooseDrawFileDialog.ShowDialog() == DialogResult.OK)
            {
                doc.Load(chooseDrawFileDialog.FileName);
                doc.Schemas.Add(null, "ValidateFigures.xsd");
                try
                {
                    doc.Validate((o, a) => { if (a.Severity == XmlSeverityType.Error) throw a.Exception; });
                }
                catch (XmlSchemaValidationException a)
                {
                    MessageBox.Show("Error in XMLFile:\n" + a.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    drawingCanvas = new Canvas(doc);
                }
                catch(Exception exc)
                {
                    if (exc is ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("Error in XML file: " + exc.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (exc is ArgumentException)
                    {
                        MessageBox.Show("Error in XML file: " + exc.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error: " + exc.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                drawingCanvas.Draw(g);
            }
            else
            {
                return;
            }
        }

        private void saveToBinaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveBinary.InitialDirectory = Path.GetFullPath(@"..\..\Save files");
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
            chooseDrawFileDialog.InitialDirectory = Path.GetFullPath(@"..\..\Save files");
            if (chooseDrawFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream loadFileStream = new FileStream(chooseDrawFileDialog.FileName, FileMode.Open))
                {
                    try
                    {
                        drawingCanvas = (Canvas)fileSaver.Deserialize(loadFileStream);
                    }
                    catch (Exception exc)
                    {
                        if (exc is SerializationException)
                        {
                            MessageBox.Show("Error: the safe file is uncompatible with the application", 
                                null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Error: " + exc.Message,
                                null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                    Graphics g = this.CreateGraphics();
                    g.Clear(this.BackColor);
                    drawingCanvas.Draw(g);
                }
            }
            else
            {
                return;
            }
        }
    }
}
