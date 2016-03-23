using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Drawing;

namespace ADO.NET_3
{

    [Serializable(), XmlInclude(typeof(Figure)), XmlInclude(typeof(Circle)), XmlInclude(typeof(Rectangle)), XmlInclude(typeof(Triangle))]

    public abstract class Figure
    {
        protected Figure() { }


        public abstract void ShowInfo(Graphics graphics);


    }
}
