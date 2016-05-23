using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Mycomparer : IComparer<KeyValuePair<string, double>>
    {
        public int Compare(KeyValuePair<string, double> x, KeyValuePair<string, double> y)
        {
            if (x.Value - y.Value > 0.0001 )
            {
                return 1;
            }
            else
            {
                if (x.Value != y.Value)
                {
                    return -1;
                }
            }

            return string.Compare(x.Key, y.Key);
        }
    }
}
