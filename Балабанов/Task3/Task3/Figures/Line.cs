using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace Task3.Figures
{
    [Serializable]
    public class Line : Figure
    {
        private Point _StartPoint;
        private Point _EndPoint;

        public Line()
        { }

        public Line (Point StartPoint, Point EndPoint)
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
        }
        public Point StartPoint
        {
            get
            {
                return _StartPoint;
            }
            set
            {
                _StartPoint = value;
            }
        }

        public Point EndPoint
        {
            get
            {
                return _EndPoint;
            }
            set
            {
                _EndPoint = value;
            }
        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawLine(new Pen(Color.Black), StartPoint, EndPoint);
        }

    }
}
