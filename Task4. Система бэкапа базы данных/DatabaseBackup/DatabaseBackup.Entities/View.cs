using System.Collections.Generic;

namespace DatabaseBackup.Entities
{
    public class View
    {
        public string Definition { get; set; }
        public string Name { get; set; }
        public string Schema { get; set; }
        public IEnumerable<Trigger> Triggers { get; set; }

        public override string ToString()
        {
            return Definition;
        }
    }
}