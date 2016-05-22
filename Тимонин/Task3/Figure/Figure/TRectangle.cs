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
    [XmlType("Rectangle")]

    public class TRectangle : TFigure
    {
        public TRectangle() { C = new Point[2]; }
        public TRectangle(int x1, int y1, int x2, int y2)
        {
            C = new Point[2];
            C[0].X = x1; C[0].Y = y1; C[1].X = x2; C[1].Y = y2;
        }
        public override void Paint(Graphics g)
        {
            if (C == null) return;
            Pen pen = new Pen(Brushes.Black, 1);
            g.DrawRectangle(pen, new Rectangle(C[0].X, C[0].Y, C[1].X - C[0].X, C[1].Y - C[0].Y));
            pen.Dispose();
        }

        public Point LeftUpperPoint
        {
            get { return C[0]; }
            set { C[0] = value; }
        }
        public int Width
        {
            get { return C[1].X - C[0].X; }
            set { C[1].X = C[0].X + value; }
        }
        public int Height
        {
            get { return C[1].Y - C[0].Y; }
            set { C[1].Y = C[0].Y + value; }
        }

    }
}
