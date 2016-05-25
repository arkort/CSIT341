using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace adoTask3
{
    [Serializable]
    public class Circle : Figure
    {
        private Point center;
        private int radius; 

        public Circle(Point center, int radius)
        {
            this.center = center;
            this.radius = radius;
        }
        public Circle() { }    
        
        public Point Center
        {
            get
            {
                return this.center;
            }
            set
            {
                this.center = value;
            }
        }    
        public int Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.radius = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(Color.Green), this.center.X - this.radius / 2, this.center.Y - radius / 2, 2 * radius, 2 * radius);
        }
    }
}
