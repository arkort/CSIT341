using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBackup.Entities
{
    public class Trigger
    {
        public string Definition { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Definition;
        }
    }
}