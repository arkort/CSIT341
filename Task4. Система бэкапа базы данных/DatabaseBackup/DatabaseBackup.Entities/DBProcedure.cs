using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBackup.Entities
{
    public class DBProcedure
    {
        public string Name
        {
            get; set;
        }

        public string Definition
        {
            get; set;
        }

        public DBProcedure(string name, string definition)
        {
            this.Name = name;
            this.Definition = definition;
        }
    }
}
