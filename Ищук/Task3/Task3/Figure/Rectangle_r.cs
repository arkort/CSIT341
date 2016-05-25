using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Task3.Figure
{
    [Serializable]
    public class Rectangle_r : AbstractFigure
    {
        private Point leftUpperPoint;
        private int heigth;
        private int width;

        public Rectangle_r(Point leftUpperPoint, int width, int height)
        {
            this.LeftUpperPoint = leftUpperPoint;
            this.Width = width;
            this.Height = height;
        }

        public Rectangle_r()
        { }

        public Point LeftUpperPoint
        {
            get
            {
                return leftUpperPoint;
            }

            set
            {
                    leftUpperPoint = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return heigth;
            }

            set
            {
                heigth = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.DarkRed, leftUpperPoint.X, leftUpperPoint.Y, width, heigth);
        }
    }
}
