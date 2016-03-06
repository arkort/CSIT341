using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Task3
{
    [Serializable]
    [XmlType("circle")]
    public class Circle : Figure
    {
        [XmlElement("Color")]
        public override string FillColor { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }

        public Circle() { }

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
            
            var circle = new System.Windows.Shapes.Ellipse();
            circle.Fill = new SolidColorBrush(color);
            circle.Width = Radius;
            circle.Height = Radius;

            Canvas.SetLeft(circle, X);
            Canvas.SetTop(circle, Y);

            context.Children.Add(circle);
        }
    }
}
