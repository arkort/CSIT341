using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing;

namespace ADO.NET_3
{
    [Serializable(), XmlInclude(typeof(Figure)), XmlInclude(typeof(Circle)), XmlInclude(typeof(Rectangle)), XmlInclude(typeof(Triangle))]

    public class Circle : Figure
    {
        public Circle() { }


        public int x, y, width, height;

        public Circle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }



        public override void ShowInfo(Graphics e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            e.DrawEllipse(blackPen, x, y, width, height);
        }

    }
}
