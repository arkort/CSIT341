using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace Solution3
{
    [Serializable()]
    public class Line: Figure
    {
        public PointF[] points;
        public string color;
        public Line()
        {
        }
        public Line(PointF point1, PointF point2, string color)
        {
            points = new PointF[2];
            points[0]=point1;
            points[1] = point2;
            this.color = color;
        }
        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color.FromName(color), 5),points[0], points[1]);
        }
    }
}
