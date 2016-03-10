using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Task3
{
    [Serializable]
    [XmlType("rectangle")]
    public class Rectangle : Figure
    {
        [XmlElement("Color")]
        public override string FillColor { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle() { }

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

            var rect = new System.Windows.Shapes.Rectangle();
            rect.Fill = new SolidColorBrush(color);
            rect.Width = Width;
            rect.Height = Height;

            Canvas.SetLeft(rect, X);
            Canvas.SetTop(rect, Y);

            context.Children.Add(rect);
        }
    }
}
