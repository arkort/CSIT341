using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Solution3
{
    [Serializable()]
    public class Cicle:Figure
    {
        public PointF[] points;
        public string color;
        public float radius;
        public Cicle()
        {
        }
        public Cicle(PointF point1,float radius,string color)
        {
            points = new PointF[1];
            point1.X -= radius;
            point1.Y -= radius;
            points[0] = point1;
            this.color = color;
            this.radius = radius;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.FromName(color)),points[0].X, points[0].Y,radius*2,radius*2);
        }
    }
}
