using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        Line testLine = new Line(0,0,200,200);
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog OpenModelDialog = new OpenFileDialog();
            OpenModelDialog.InitialDirectory = "c:\\";
            OpenModelDialog.Filter = "txt files (*.txt)|*.txt";
            OpenModelDialog.FilterIndex = 1;
            OpenModelDialog.RestoreDirectory = true;

            if (OpenModelDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = OpenModelDialog.OpenFile()) != null)
                {
                    using (myStream)
                    {
                        this.Lines.Clear();
                        float x1 = 0;
                        float x2 = 0;
                        float y1 = 0;
                        float y2 = 0;

                        List<Point> Points = new List<Point>();
                        StreamReader rd = new StreamReader(myStream);

                        string point;
                        Point P1;
                        Point P2;
                        this.FinalMatrix.Unit();
                        this.FinalMatrix.Upright();
                        this.FinalMatrix.move(15f, 220f);
                        while ((point = rd.ReadLine()) != null)
                        {
                            if (point == "" || point[0] == '#')
                            {
                                continue;
                            }
                            string[] coords = point.Split(' ');
                            x1 = float.Parse(coords[0]);
                            y1 = float.Parse(coords[1]);
                            x2 = float.Parse(coords[2]);
                            y2 = float.Parse(coords[3]);
                            P1 = new Point(x1, y1, 1);
                            P2 = new Point(x2, y2, 1);
                            Points.Add(P1);
                            Points.Add(P2);
                            this.Lines.Add(new Line(P1, P2));
                        }
                        OpenFile.Visible = false;
                    }
                }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            testLine.Draw(e.Graphics);
        }
    }
}
