using System;
using System.Drawing;
using Task_3.Figure;

namespace Task_3.Figures

{
    [Serializable]
    public class Triangle : AbstractFigure
    {
        private Point point_A;
        private Point point_B;
        private Point point_C;

        public Triangle(Point point_A, Point point_B, Point point_C)
        {
            this.Point_A = point_A;
            this.Point_B = point_B;
            this.Point_C = point_C;
        }

        public Triangle()
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
                return point_B;
            }

            set
            {
                point_B = value;
            }
        }

        public Point Point_C
        {
            get
            {
                return point_C;
            }

            set
            {
                point_C = value;
            }
        }

        public override void Draw(Graphics graphics)
        {   
            graphics.DrawLine(new Pen(Color.Black), point_A, point_B);
            graphics.DrawLine(new Pen(Color.Black), point_C, point_A);
            graphics.DrawLine(new Pen(Color.Black), point_C, point_B);
           
        }
    }
}
