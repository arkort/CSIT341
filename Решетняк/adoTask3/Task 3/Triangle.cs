using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace adoTask3
{
    [Serializable]
     public class Triangle : Figure
    {
        private Point a;
        private Point b;
        private Point c;

        public Triangle(Point A, Point B, Point C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
        public Triangle() { }

        public Point A
        {
            get
            {
                return this.a;
            }
            set
            {
                this.a = value;
            }
        }
        public Point B
        {
            get
            {
                return this.b;
            }
            set
            {
                this.b = value;
            }
        }
        public Point C
        {
            get
            {
                return this.c;
            }
            set
            {
                this.c = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black), A, B);
            graphics.DrawLine(new Pen(Color.Black), C, B);
            graphics.DrawLine(new Pen(Color.Black), C, A);
        }
    }
}
