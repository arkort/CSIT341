using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Drawing;

namespace Task3.Figures
{
    [Serializable]
    public class Rectangle : Figure
    {
        private Point _CenterPoint;
        private int _Width;
        private int _Height;
        
        public Rectangle()
        { }

        public Rectangle (Point CenterPoint, int Width, int Height)
        {
            this.CenterPoint = CenterPoint;
            this.Width = Width;
            this.Height = Height;
        }
        public Point CenterPoint
        {
            get
            {
                return _CenterPoint;
            }
            set
            {
                _CenterPoint = value;
            }
        }

        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }

        public int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
            }
        }
        public override void Draw(Graphics graphic)
        {
            graphic.DrawRectangle(new Pen(Color.Black), CenterPoint.X, CenterPoint.Y, Width, Height);
        }
    }
}
