using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Task3.Figure
{
    [Serializable]
    //[XmlType(nameof(MyRectangle))]
    //[XmlInclude(typeof(MyRectangle))]
    public class MyRectangle : AbstractFigure
    {
        private Point leftUpperPoint;
        private int heigth;
        private int width;

        public MyRectangle(Point leftUpperPoint, int width, int height)
        {
            this.LeftUpperPoint = leftUpperPoint;
            this.Width = width;
            this.Height = height;
        }

        public MyRectangle()
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
                if (value <= 0)
                {
                    throw new ArgumentException("The width of rectangle can't be negative!");
                }

                if (this.leftUpperPoint.X + value > Screen.PrimaryScreen.Bounds.Width)
                {
                    throw new ArgumentOutOfRangeException("The rectangle is outside form!");
                }

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
                if (value <= 0)
                {
                    throw new ArgumentException("The width of rectangle can't be negative!");
                }

                if (this.leftUpperPoint.Y + value > Screen.PrimaryScreen.Bounds.Height)
                {
                    throw new ArgumentOutOfRangeException("The rectangle is outside form!");
                }

                heigth = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.DarkRed, leftUpperPoint.X, leftUpperPoint.Y, width, heigth);
        }
    }
}