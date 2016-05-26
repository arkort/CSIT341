using System;
using System.Drawing;
using System.Xml.Serialization;
using Task_3.Figures;

namespace Task_3.Figure
{
    [Serializable]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(FigureRectangle))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Triangle))]
    public abstract class AbstractFigure : IDraw
    {
        public abstract void Draw(Graphics graphics);

        protected AbstractFigure()
        { }
    }
}