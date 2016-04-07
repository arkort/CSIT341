using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace Solution3
{
    [Serializable()]
    public class Square: Figure
    {
        public class CompareSquare : IComparer
        {
            int IComparer.Compare(Object a, Object b)
            {
                if (((PointF)a).X == ((PointF)b).X)
                {
                    if (((PointF)a).Y < ((PointF)b).Y)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                if (((PointF)a).X < ((PointF)b).X)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
        public PointF[] points;
        public string color;
        public Square()
        {
        }
        public Square(PointF point1, PointF point2, PointF point3, PointF point4,string color)
        {
            points = new PointF[4];
            points[0] = point1;
            points[1] = point2;
            points[2] = point3;
            points[3] = point4;
            this.color = color;
        }

        public override void Draw(Graphics g)
        {
            Array.Sort(points,new CompareSquare());
            PointF temp = points[3];
            points[3] = points[2];
            points[2] = temp;
            g.FillPolygon(new SolidBrush(Color.FromName(color)),points);
        }
    }
}
