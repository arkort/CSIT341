using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;
namespace ADO.NET_3
{
    [Serializable(), XmlInclude(typeof(Figure)), XmlInclude(typeof(Circle)), XmlInclude(typeof(Rectangle)), XmlInclude(typeof(Triangle))]
    public class Triangle : Figure
    {
        public Triangle() { }
        public int x1, y1, x2, y2, x3, y3;

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.y1 = y1;
            this.y2 = y2;
            this.y3 = y3;
        }

        public override void ShowInfo(Graphics g)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,

             };
            g.DrawPolygon(blackPen, curvePoints);

        }

    }
}
