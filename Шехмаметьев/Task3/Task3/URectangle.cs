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
    class URectangle: IFigure
    {
        Color drawingColor;
        Single height;
        Single width;
        PointF upperLeftCorner;

        public Single Height
        {
            get
            {
                return height;
            }
            set
            {
                if(value <= 0)
                    throw new ArgumentOutOfRangeException("Height of the rectangle must be greater than zero");
                else if(value > Screen.PrimaryScreen.Bounds.Height)
                    throw new ArgumentOutOfRangeException("Height of the rectangle must be" + 
                                                            "lesser than the screen's height");
                else
                    height = value;
            }
        }
        public Single Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Width of the rectangle must be greater than zero");
                else if (value > Screen.PrimaryScreen.Bounds.Width)
                    throw new ArgumentOutOfRangeException("Width of the rectangle must " +
                                                            "be lesser than the screen's width");
                else
                    width = value;
            }
        }

        public PointF UpperLeftCorner
        {
            get
            {
                return upperLeftCorner;
            }
            set
            {
                if(value.X < 0 || value.Y < 0)
                    throw new ArgumentOutOfRangeException("Coordinates of the upper left corner of the rectangle " +
                                                            "must be positive");
                else if(value.X + width > Screen.PrimaryScreen.Bounds.Width || 
                        value.Y + height > Screen.PrimaryScreen.Bounds.Height)
                    throw new ArgumentOutOfRangeException("The rectangle must be within the screen boundaries. " + 
                                                           "Please change the coordinates of the upper left corner or " +
                                                           "the size of the rectangle");
                
                else
                    upperLeftCorner = value;
            }
        }

        public URectangle(PointF upperLeftCorner, Single height, Single width, Color color)
        {
            this.Height = height;
            this.Width = width;
            this.drawingColor = color;
            this.UpperLeftCorner = upperLeftCorner;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(drawingColor), this.upperLeftCorner.X, this.upperLeftCorner.Y, width, height);
        }
    }
}
