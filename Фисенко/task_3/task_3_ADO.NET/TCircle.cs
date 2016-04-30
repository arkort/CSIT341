using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace task_3_ADO.NET
{

    [Serializable]
    [XmlType("Circle")]
    public class TCircle : TFigure
    {
        private int r = 10;

        public int Radius
        {
            get { return r; }
            set { if (value >= 0) r = value; }
        }
        public TCircle() { C = new Point[1]; }
        public TCircle(int xc, int yc, int R)
        {
            C = new Point[1];
            C[0].X = xc; C[0].Y = yc;
            Radius = R;
        }
        public override void Paint(Graphics g)
        {
            if (C == null) return;
            Pen pen = new Pen(Brushes.Green, 1);
            g.DrawEllipse(pen, C[0].X - Radius, C[0].Y - Radius, Radius, Radius);
            pen.Dispose();
        }

        public Point Center
        {
            get { return C[0]; }
            set { C[0] = value; }
        }

    }
}
