using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Task_3
{
    [Serializable]

    public class Rectangle : Figure
    {
        private Point beginPoint;
        private int width;
        private int heigth;
        
        public Rectangle(Point beginPoint, int width, int heigth)
        {
            this.beginPoint = beginPoint;
            this.width = width;
            this.heigth = heigth;            
        }
        public Rectangle() { }

        public Point BeginPoint
        {
            get
            {
                return this.beginPoint;
            }
            set
            {
                this.beginPoint = value;
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
            graphics.DrawRectangle(Pens.Gold, beginPoint.X, beginPoint.Y, width, heigth);
        }
    }
}
