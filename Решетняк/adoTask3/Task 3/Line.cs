using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace adoTask3
{
    [Serializable]
    public class Line : Figure
    {
        private Point a;
        private Point b; 

        public Line(Point A, Point B)
        {
            this.A = A;
            this.B = B;
        }
        public Line() { }    
        
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

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Red), A, B);
        }
    }
}
