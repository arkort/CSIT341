using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;

namespace Task3.Figure
{
    [Serializable]
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
