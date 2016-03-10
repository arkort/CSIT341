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
    class ULine: IFigure
    {
        PointF start;
        PointF end;
        Color drawingColor;
        Single penWidth;

        public Single PenWidth
        {
            get
            {
                return penWidth;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Pen's width must be greater than zero");
                else
                    penWidth = value;
            }
        }
        public PointF Start
        {
            get { return start; }
            set
            {
                if (value.X < 0 || value.Y < 0)
                    throw new ArgumentOutOfRangeException("Start point of the line must have positive coordinates");
                else if (value.X > Screen.PrimaryScreen.Bounds.Width || value.Y > Screen.PrimaryScreen.Bounds.Height)
                    throw new ArgumentOutOfRangeException("Start point of the line must be within the screen's boundaries");
                else
                    start = value;
            }
        }

        public PointF End
        {
            get { return end; }
            set
            {
                if (value.X < 0 || value.Y < 0)
                    throw new ArgumentOutOfRangeException("End point of the line must have positive coordinates");
                else if (value.X > Screen.PrimaryScreen.Bounds.Width || value.Y > Screen.PrimaryScreen.Bounds.Height)
                    throw new ArgumentOutOfRangeException("End point of the line must be within screen's boundaries");
                else
                    end = value;
            }
        }

        public ULine(PointF start, PointF end, Color color, Single penWidth)
        {
            this.start = start;
            this.end = end;
            this.drawingColor = color;
            this.PenWidth = penWidth;
        }
        public void Draw(Graphics g)
        {
            g.DrawLine(new Pen(drawingColor, penWidth), this.start, this.end);
        }
    }
}
