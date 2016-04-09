namespace DatabaseBackup.Entities
{
    public class Function
    {
        public string Definition { get; set; }

        public override string ToString()
        {
            return Definition;
        }
    }
}