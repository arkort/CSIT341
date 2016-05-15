using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace Figure
{
    [Serializable]
    [XmlType("Line")]
    public class TLine : TFigure
    {
        public TLine() { C = new Point[2]; }
        public TLine(int x1, int y1, int x2, int y2)
        {
            C = new Point[2];
            C[0].X = x1; C[0].Y = y1; C[1].X = x2; C[1].Y = y2;
        }
        public override void Paint(Graphics g)
        {
            if (C == null) return;
            Pen pen = new Pen(Brushes.Blue, 1);
            g.DrawLine(pen, C[0], C[1]);
            pen.Dispose();
        }
        [XmlElement("BeginPoint")]
        public Point Begins
        {
            get { return C[0]; }
            set { C[0] = value; }
        }
        [XmlElement("EndPoint")]
        public Point Ends
        {
            get { return C[0]; }
            set { C[0] = value; }
        }
    }
}
