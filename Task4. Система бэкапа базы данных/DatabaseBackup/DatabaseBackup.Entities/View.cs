namespace DatabaseBackup.Entities
{
    public class View
    {
        public string Definition { get; set; }

        public override string ToString()
        {
            return Definition;
        }
    }
}