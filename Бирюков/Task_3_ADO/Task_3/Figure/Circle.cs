using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Task_3.Figure
{
    [Serializable]
    //[XmlInclude(typeof(Circle))]
    //[XmlInclude(typeof(Line))]
    public class Circle : AbstractFigure
    {
        private Point center;
        private int radius;

        public Circle(Point center, int radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public Circle()
        { }

        public int Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius can't be negative!");
                }

                if (Valid.ValidateOutOfRangeForm(new Point(center.X + radius, center.Y + radius)))
                {
                    throw new ArgumentOutOfRangeException("The circle is outside form!");
                }

                radius = value;
            }
        }

        public Point Center
        {
            get
            {
                return center;
            }

            set
            {
                if (Valid.ValidateOutOfRangeForm(value))
                {
                    throw new ArgumentOutOfRangeException("The circle is outside form!");
                }

                center = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(Color.DarkBlue), this.center.X - this.radius / 2, this.center.Y - radius / 2, 2 * radius, 2 * radius);
        }
    }
}