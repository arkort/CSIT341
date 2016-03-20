using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;

namespace ADO.NET_3
{
    [Serializable(), XmlInclude(typeof(Figure)), XmlInclude(typeof(Circle)), XmlInclude(typeof(Rectangle)), XmlInclude(typeof(Triangle))]
    public class Rectangle : Figure
    {
        public Rectangle() { }
        public int x1, y1, x2, y2;

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override void ShowInfo(Graphics e)

        {
            Pen blackPen = new Pen(Color.Black, 3);
            e.DrawRectangle(blackPen, x1, y1, x2, y2);
        }

    }

}
