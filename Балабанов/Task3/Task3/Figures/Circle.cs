using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;

namespace Task3.Figures
{
    [Serializable]
    public class Circle : Figure
    {
        private int _Xcenter;
        private int _Ycenter;
        private int _Radius;

        public Circle()
        { }

        public Circle(int Xcenter, int Ycenter, int Radius)
        {
            this.Xcenter = Xcenter;
            this.Ycenter = Ycenter;
            this.Radius = Radius;
        }
        public int Xcenter
        {
            get
            {
                return _Xcenter;
            }
            set
            {
                _Xcenter = value;
            }
        }

        public int Ycenter
        {
            get
            {
                return _Ycenter;
            }
            set
            {
                _Ycenter = value;
            }
        }

        public int Radius
        {
            get
            {
                return _Radius;
            }
            set
            {
                _Radius = value;
            }
        }
        public override void Draw(Graphics graphic)
        {
            graphic.DrawEllipse(new Pen(Color.Black), Xcenter, Ycenter, Radius, Radius);
        }
    }
}
