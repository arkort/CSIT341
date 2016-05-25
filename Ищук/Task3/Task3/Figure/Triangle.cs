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
    public class Triangle : AbstractFigure
    {
        private Point firstPoint;
        private Point secondPoint;
        private Point thirdPoint;

        public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
            this.ThirdPoint = thirdPoint;
        }

        public Triangle()
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