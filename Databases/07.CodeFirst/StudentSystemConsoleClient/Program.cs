namespace StudentSystemConsoleClient
{
    using StudentSystemData;
    using StudentSystemData.Migrations;
    using StudentSystemModels;

    using System;
    using System.Data.Entity;
    using System.Linq;

    class Program
    {

        /*----- IMPORTANT ---------*/
        // USING SQL EXPRESS 2014
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentsSystemEntities, Configuration>());
            var studentSystemEntities = new StudentsSystemEntities();

            Student student = new Student();
            student.FirstName = "Mitko";
            student.LastName = "Radenkov";
            student.Number = 696969;

            Course course = new Course();
            course.Name = "Computer Science";
            course.Description = "Very interesting...";
            course.MaterialsPath = "C:/Materials/IT.docx"; 

            using(studentSystemEntities)
            {
                studentSystemEntities.Students.Add(student);
                student.Courses.Add(course);   

                studentSystemEntities.SaveChanges();

                var savedstudent = studentSystemEntities.Students.First();
                Console.WriteLine(savedstudent.ToString());           
            }
        }
    }
}
