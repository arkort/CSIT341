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
    [XmlType("Triangle")] 

    public class TTriangle : TFigure
    {
        public TTriangle() { C = new Point[3]; }
        public TTriangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            C = new Point[3];
            C[0].X = x1; C[0].Y = y1;
            C[1].X = x2; C[1].Y = y2;
            C[2].X = x3; C[2].Y = y3;
        }
        public override void Paint(Graphics g)
        {
            Pen pen = new Pen(Brushes.Red, 1);
            g.DrawLine(pen, C[0], C[1]);
            g.DrawLine(pen, C[1], C[2]);
            g.DrawLine(pen, C[2], C[0]);
            pen.Dispose();
        }
        public Point FirstPoint
        {
            get { return C[0]; }
            set { C[0] = value; }
        }
        public Point SecondPoint
        {
            get { return C[1]; }
            set { C[1] = value; }
        }
        public Point ThirdPoint
        {
            get { return C[2]; }
            set { C[2] = value; }
        }

    }
}
