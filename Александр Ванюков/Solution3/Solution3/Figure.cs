using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Solution3
{
    [Serializable()]
    public abstract class Figure
    {
        public abstract void Draw(Graphics g);

    }
}
