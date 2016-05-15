using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Ado_task3.Figure
{
    [Serializable]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(MyRectangle))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Triange))]
    public abstract class AbstractFigure : IDrawable
    {
        public abstract void Draw(Graphics graphics);

        protected AbstractFigure()
        { }
    }
}