using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace adoTask3
{
    [Serializable]
    public class Rectangle : Figure
    {
        private Point startPoint;
        private int width;
        private int heigth;
        
        public Rectangle(Point startPoint, int width, int heigth)
        {
            this.startPoint = startPoint;
            this.width = width;
            this.heigth = heigth;            
        }
        public Rectangle() { }

        public Point StartPoint
        {
            get
            {
                return this.startPoint;
            }
            set
            {
                this.startPoint = value;
            }
        }
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
        public int Heigth
        {
            get
            {
                return this.heigth;
            }
            set
            {
                this.heigth = value;
            }
        }
                
        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Gold, startPoint.X, startPoint.Y, width, heigth);
        }
    }
}
