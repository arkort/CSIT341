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

                endPoint = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black), beginPoint, endPoint);
        }
    }
}