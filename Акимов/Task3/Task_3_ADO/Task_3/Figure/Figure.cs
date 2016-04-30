using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Task_3.Figure
{
    [Serializable]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(MyRectangle))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Triange))]
    public abstract class AbstractFigure 
    {
        public abstract void Draw(Graphics graphics);

       
    }
}