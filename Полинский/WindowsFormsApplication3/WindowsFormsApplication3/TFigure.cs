using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace WindowsFormsApplication3
{
    [Serializable]
    [XmlInclude(typeof(TRectangle))]
    [XmlInclude(typeof(TTriangle))]
    [XmlInclude(typeof(TCircle))]
    [XmlInclude(typeof(TLine))]
    [XmlType("AbstractFigure")]

    public class TFigure
    {
        protected Point[] C = null;
        public TFigure() { }
        public virtual void Paint(Graphics g) { }
    }
}
