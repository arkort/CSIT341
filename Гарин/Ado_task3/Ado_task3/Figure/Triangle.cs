using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Ado_task3.Figure
{
    [Serializable]
    //[XmlType(nameof(Triange))]
    //[XmlInclude(typeof(Triange))]
    public class Triange : AbstractFigure
    {
        private Point firstPoint;
        private Point secondPoint;
        private Point thirdPoint;

        public Triange(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
            this.ThirdPoint = thirdPoint;
        }

        public Triange()
        { }

        public Point FirstPoint
        {
            get
            {
                return firstPoint;
            }

            set
            {
                if (Valid.ValidateOutOfRangeForm(value))
                {
                    firstPoint = value;
                }
            }
        }

        public Point SecondPoint
        {
            get
            {
                return firstPoint;
            }

            set
            {
                if (Valid.ValidateOutOfRangeForm(value))
                {
                    throw new ArgumentOutOfRangeException("The triangle is outside form!");
                }

                if (this.firstPoint.X == value.X && this.firstPoint.Y == value.Y)
                {
                    throw new ArgumentException("Triange don't exist!");
                }

                secondPoint = value;
            }
        }

        public Point ThirdPoint
        {
            get
            {
                return firstPoint;
            }

            set
            {
                if (Valid.ValidateOutOfRangeForm(value))
                {
                    throw new ArgumentOutOfRangeException("The triangle is outside form!");
                }

                if (this.firstPoint.X == this.secondPoint.X && this.firstPoint.X == value.X || (this.firstPoint.Y == this.secondPoint.Y && this.firstPoint.Y == value.Y))
                {
                    throw new ArgumentException("Triange don't exist!");
                }

                thirdPoint = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black), firstPoint, secondPoint);
            graphics.DrawLine(new Pen(Color.Black), thirdPoint, secondPoint);
            graphics.DrawLine(new Pen(Color.Black), thirdPoint, firstPoint);
        }
    }
}