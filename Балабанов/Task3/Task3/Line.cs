using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task3
{
    class Line : Figure
    {
        private Point StartPoint;
        private Point EndPoint;

        public Line() { }

        public Line (int x1, int y1, int x2, int y2)
        {
            this.StartPoint.X = x1;
            this.StartPoint.Y = y1;
            this.EndPoint.X = x2;
            this.EndPoint.Y = y2;
        }

        public void Draw (Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black), StartPoint, EndPoint);
        }
    }
}
