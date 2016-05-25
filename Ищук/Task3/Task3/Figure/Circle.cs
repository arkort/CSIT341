using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Task3.Figure
{
    [Serializable]
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
                center = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(Color.DarkBlue), this.center.X - this.radius / 2, this.center.Y - radius / 2, 2 * radius, 2 * radius);
        }
    }
}
