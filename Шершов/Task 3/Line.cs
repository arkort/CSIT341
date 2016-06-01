using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Task_3
{
    [Serializable]
    public class Line : Figure
    {
        private Point A;
        private Point B;

        public Line(Point a, Point b)
        {
            this.A = a;
            this.B = b;
        }

        public Line()
        { }



    }
}
