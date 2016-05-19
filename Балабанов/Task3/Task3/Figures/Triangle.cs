using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;

namespace Task3.Figures
{
    [Serializable]
    public class Triangle : Figure
    {
        private Point _FirstPoint;
        private Point _SecondPoint;
        private Point _ThirdPoint;

        public Triangle()
        { }

        public Triangle(Point FirstPoint, Point SecondPoint, Point ThirdPoint)
        {
            this.FirstPoint = FirstPoint;
            this.SecondPoint = SecondPoint;
            this.ThirdPoint = ThirdPoint;
        }
        public Point FirstPoint
        {
            get
            {
                return _FirstPoint;
            }
            set
            {
                _FirstPoint = value;
            }
        }

        public Point SecondPoint
        {
            get
            {
                return _SecondPoint;
            }
            set
            {
                _SecondPoint = value;
            }
        }

        public Point ThirdPoint
        {
            get
            {
                return _ThirdPoint;
            }
            set
            {
                _ThirdPoint = value;
            }
        }
        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen (Color.Black);
            graphic.DrawLine(pen, FirstPoint, SecondPoint);
            graphic.DrawLine(pen, SecondPoint, ThirdPoint);
            graphic.DrawLine(pen, ThirdPoint, FirstPoint);
        }
    }
}
