using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    internal static class Valid
    {
        public static bool ValidateOutOfRangeForm(Point value)
        {
            return (value.X < 0 || value.X > Screen.PrimaryScreen.Bounds.Width ||
              value.Y < 0 || value.Y > Screen.PrimaryScreen.Bounds.Height);
        }
    }
}