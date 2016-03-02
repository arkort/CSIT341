using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Task3
{
    [Serializable]
    class UCircle: IFigure
    {
        Single radius;
        PointF center;
        Color drawingColor;

        public Single Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Radius of the circle must be greater than zero");
                else if (value > Screen.PrimaryScreen.Bounds.Width || value > Screen.PrimaryScreen.Bounds.Height)
                    throw new ArgumentOutOfRangeException("Radius of the circle can't be greater than screen's boundaries");
                else
                    radius = value;
            }
        }

        public PointF Center
        {
            get
            {
                return center;
            }
            set
            {
                if (value.X < radius || value.Y < radius)
                    throw new ArgumentOutOfRangeException("Coordinates of the center of the circle " +
                        "must be greater than the radius");
                else if (value.X + radius > Screen.PrimaryScreen.Bounds.Width || 
                        value.Y + radius > Screen.PrimaryScreen.Bounds.Height)
                    throw new ArgumentOutOfRangeException("Circle must be within the screen's boundaries" + 
                                                           "Please change the value of the center or the radius");
                else
                    center = value;
            }
        }

        
        public UCircle(Single radius, PointF center, Color color)
        {
            this.Radius = radius;
            this.Center = center;
            this.drawingColor = color;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(drawingColor), new RectangleF(center.X - radius, center.Y - radius, 2 * radius, 2 * radius));
        }
    }
}
