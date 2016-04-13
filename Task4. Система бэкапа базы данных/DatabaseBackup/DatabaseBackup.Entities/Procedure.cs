namespace DatabaseBackup.Entities
{
    public class Procedure
    {
        public string Definition { get; set; }

        public override string ToString()
        {
            return this.Definition;
        }
    }
}