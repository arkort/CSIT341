using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Task_3
{
    [Serializable]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(MyRectangle))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Triange))]

    public abstract class Figure : IDrawable
    {
        public abstract void Draw(Graphics graphics);

        protected Figure()
        { }
    }
}
