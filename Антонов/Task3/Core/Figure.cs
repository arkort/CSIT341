using System;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Task3
{
    [Serializable]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [XmlType(TypeName = "figure")]
    public abstract class Figure
    {
        public abstract void Draw(Canvas context);

        [XmlElement("Color")]
        public abstract string FillColor { get; set; }
    }
}
