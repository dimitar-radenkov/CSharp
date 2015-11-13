namespace _08.ExtendEmployee
{
    using _01.EntityFramework;
    using System.Data.Entity.Core.Metadata.Edm;

    public class ExtendedEmployee : Employee
    {
        public EntitySet Teritory { get; set; }
    }
}
