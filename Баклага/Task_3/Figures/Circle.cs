using System;
using System.Drawing;
using Task_3.Figure;

namespace Task_3.Figures
{   [Serializable]
    public class Circle : AbstractFigure
    {
        private Point center;
        private int radius;

        public Circle(Point center, int radius)
        {
            this.center = center;
            this.radius = radius;
        }
        public Circle()
        { }
        
        public Point Center
        {
            get
            {
                return center;
            }
            set
            {
                center = value;
            }
        }
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(Color.Black), this.center.X - this.radius / 2, this.center.Y - radius / 2, 2 * radius, 2 * radius);
        }

    }
}
