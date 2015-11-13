namespace StudentSystemData
{
    using StudentSystemData.Migrations;
    using StudentSystemModels;
    using System.Data.Entity;

    public class StudentsSystemEntities : DbContext
    {
        public StudentsSystemEntities()
            :base("StudentSystemDB")
        {
            
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}
