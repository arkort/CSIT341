using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Task_3.Figure
{
    [Serializable]
    //[XmlType(nameof(Line))]
    //[XmlInclude(typeof(Line))]
    public class Line : AbstractFigure
    {
        private Point beginPoint;
        private Point endPoint;

        public Line(Point beginPoint, Point endPoint)
        {
            this.BeginPoint = beginPoint;
            this.EndPoint = endPoint;
        }

        public Line()
        { }

        public Point BeginPoint
        {
            get
            {
                return beginPoint;
            }

            set
            {
                if (Valid.ValidateOutOfRangeForm(value))
                    throw new ArgumentOutOfRangeException("The line is outside form!");

                beginPoint = value;
            }
        }

        public Point EndPoint
        {
            get
            {
                return endPoint;
            }

            set
            {
                if (Valid.ValidateOutOfRangeForm(value))
                    throw new ArgumentOutOfRangeException("The line is outside form!");

                if (this.beginPoint.X == value.X && this.beginPoint.Y == value.Y)
                    throw new ArgumentException("The Line don't exist!");

                endPoint = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black), beginPoint, endPoint);
        }
    }
}