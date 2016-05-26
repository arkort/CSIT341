using System;
using System.Drawing;
using System.Windows.Forms;
using Task_3.Figure;

namespace Task_3.Figures
{

    [Serializable]
    public class FigureRectangle : AbstractFigure
    {
        private Point leftPoint;
        private int height;
        private int width;

        public FigureRectangle(Point LeftPoint,int wifth, int height)
        {
            this.LeftPoint = leftPoint;
            this.Width = width;
            this.Height = height;
          
        }

        public FigureRectangle()
        { }

        public Point LeftPoint
        {
            get
            {
                return leftPoint;
            }

            set
            {
                     leftPoint = value;
             }

        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
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

                if (this.leftPoint.X + value > Screen.PrimaryScreen.Bounds.Width)
                {
                    throw new ArgumentOutOfRangeException("The rectangle is outside form!");
                }

                width = value;
            }
        }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Black, leftPoint.X, leftPoint.Y, width, height);
        }
    }
}
