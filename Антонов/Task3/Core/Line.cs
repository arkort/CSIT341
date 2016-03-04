using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Task3
{
    [Serializable]
    [XmlType("line")]
    public class Line : Figure
    {
        [XmlElement("Color")]
        public override string FillColor { get; set; }

        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        public Line() { }

        public override void Draw(Canvas context)
        {
            Color color;

            try
            {
                color = (Color)ColorConverter.ConvertFromString(FillColor);
            }
            catch (Exception)
            {
                color = (Color)ColorConverter.ConvertFromString("black");
            }

            var line = new System.Windows.Shapes.Line();
            line.X1 = X1;
            line.Y1 = Y1;
            line.X2 = X2;
            line.Y2 = Y2;

            line.StrokeThickness = 2;
            line.Stroke = new SolidColorBrush(color);

            context.Children.Add(line);
        }
    }
}
