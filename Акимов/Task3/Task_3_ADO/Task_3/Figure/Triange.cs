using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Task_3.Figure
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
              
                    firstPoint = value;

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