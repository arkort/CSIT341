using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Task3
{
    [Serializable]
    class UTriangle : IFigure
    {
        PointF lowerLeft;
        PointF top;
        PointF lowerRight;
        Color drawingColor;

        public PointF LowerLeft
        {
            get
            {
                return lowerLeft;
            }
            set
            {
                if (value.X < 0 || value.Y < 0)
                    throw new ArgumentOutOfRangeException("Coordinates of the lower left point of the triangle must be " +
                        "positive");
                else if (value.X > Screen.PrimaryScreen.Bounds.Width || value.Y > Screen.PrimaryScreen.Bounds.Height)
                    throw new ArgumentOutOfRangeException("The lower left point of the triangle must be within " +
                                                           "the screen's boundaries");
                else
                    lowerLeft = value;
            }
        }

        public PointF Top
        {
            get
            {
                return top;
            }
            set
            {
                if (value.X < 0 || value.Y < 0)
                    throw new ArgumentOutOfRangeException("Coordinates of the top point of the triangle must be " +
                        "positive");
                else if (value.X > Screen.PrimaryScreen.Bounds.Width || value.Y > Screen.PrimaryScreen.Bounds.Height)
                    throw new ArgumentOutOfRangeException("The top point of the triangle must be " +
                                                            "within the screen's boundaries");
                else
                    top = value;
            }
        }

        public PointF LowerRight
        {
            get
            {
                return lowerRight;
            }
            set
            {
                if (value.X < 0 || value.Y < 0)
                    throw new ArgumentOutOfRangeException("Coordinates of the lower right point of the triangle must be " +
                        "positive");
                else if (value.X > Screen.PrimaryScreen.Bounds.Width || value.Y > Screen.PrimaryScreen.Bounds.Height)
                    throw new ArgumentOutOfRangeException("The lower right point of the triangle must be " +
                                                            "within the screen's boundaries");
                else
                    lowerRight = value;
            }
        }

        public UTriangle(PointF lowerLeft, PointF top, PointF lowerRight, Color color)
        {
            this.LowerLeft = lowerLeft;
            this.Top = top;
            this.LowerRight = lowerRight;
            if(lowerLeft == top || top == lowerRight || lowerLeft == lowerRight)
            {
                throw new ArgumentException("Points of the triangle can't be at the same coordinates");
            }
            else if ((lowerLeft.X == top.X && top.X == lowerRight.Y) || lowerLeft.Y == top.Y && top.Y == lowerRight.Y)
            {
                throw new ArgumentException("All three points of the triangle can't be on the same line");
            }
            this.drawingColor = color;
        }

        public void Draw(Graphics g)
        {
            GraphicsPath trianglePath = new GraphicsPath(new PointF[] { lowerLeft, top, lowerRight },
                                                        new Byte[] {(Byte)PathPointType.Start,
                                                        (Byte)PathPointType.Line, (Byte)PathPointType.Line });
            g.FillPath(new SolidBrush(drawingColor), trianglePath);
        }

    }
}
