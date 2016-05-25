using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace Task3.Figure
{
        [Serializable]
        [XmlInclude(typeof(Circle))]
        [XmlInclude(typeof(Rectangle_r))]
        [XmlInclude(typeof(Line))]
        [XmlInclude(typeof(Triangle))]
    public abstract class AbstractFigure : IDrawable
    {
        public abstract void Draw(Graphics graphics);

        protected AbstractFigure()
        { }
    }
    
}