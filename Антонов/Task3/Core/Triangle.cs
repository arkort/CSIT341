using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Task3
{
    [Serializable]
    [XmlType("triangle")]
    public class Triangle : Figure
    {
        [XmlElement("Color")]
        public override string FillColor { get; set; }

        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }

        public Triangle() { }

        public override void Draw(Canvas context)
        {
            Color color;

            try
            {
                color = (Color)ColorConverter.ConvertFromString(FillColor);
            }
            catch (Exception)
            {
                color = Colors.Black;
            }

            var triangle = new System.Windows.Shapes.Polygon();
            triangle.Fill = new SolidColorBrush(color);
            triangle.Points = new PointCollection() { new Point(X1, Y1), new Point(X2, Y2), new Point(X3, Y3) };

            context.Children.Add(triangle);
        }
    }
}
