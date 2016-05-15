using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Solution3
{
    [Serializable()]
    public class Triangle: Figure
    {
        public PointF[] points;
        public string color;
        public Triangle()
        {
        }
        public Triangle(PointF point1, PointF point2, PointF point3, string color)
        {
            points = new PointF[3];
            points[0] = point1;
            points[1] = point2;
            points[2] = point3;
            this.color = color;
        }
        public override void Draw(Graphics g)
        {
            g.FillPolygon(new SolidBrush(Color.FromName(color)), points);
        }
    }
}
