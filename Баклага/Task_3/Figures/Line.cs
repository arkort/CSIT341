using System;
using Task_3.Figure;
using System.Drawing;

namespace Task_3.Figures
{   [Serializable]
    public class Line: AbstractFigure
    {
        private Point point_A;
        private Point point_B;

        public Line(Point point_A, Point point_B)
        {
            this.Point_A = point_A;
            this.Point_B = point_A;
        }

        public Line()
        { }

        public Point Point_A
        {
            get
            {
                return point_A;
            }

            set
            {
               point_A = value;
            }
        }

        public Point Point_B
        {
            get
            {
                return point_A;
            }

            set
            {
                point_B = value;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black), point_A, point_B);
        }
    }
}
