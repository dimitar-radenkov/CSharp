namespace StudentSystemData.Migrations
{
    using StudentSystemModels;
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystemData.StudentsSystemEntities";
        }

        protected override void Seed(StudentsSystemEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            this.SeedCourses(context);
            this.SeedStudents(context);
            this.SeedHomeworks(context);
        }

        private void SeedCourses(StudentsSystemEntities context)
        {
            context.Courses.AddOrUpdate(
                new Course
                {
                    Name = "Math",
                    Description = "Mathematics",
                    MaterialsPath = "C:/Materials/Maths.pdf"
                });

            context.Courses.AddOrUpdate(
                new Course
                {
                    Name = "Phisique",
                    Description = "Phisique for dummies",
                    MaterialsPath = "C:/Materials/Phisique.pdf"
                });

            context.Courses.AddOrUpdate(
                new Course
                {
                    Name = "Chemistry",
                    Description = "Chemistry for advanced",
                    MaterialsPath = "C:/Materials/Chemistry.pdf"
                });
        }

        private void SeedStudents(StudentsSystemEntities context)
        {
            context.Students.AddOrUpdate(
                new Student
                {
                    FirstName = "Dimitar",
                    LastName = "Radenkov",
                    Number = 696969
                });

            context.Students.AddOrUpdate(
                new Student
                {
                    FirstName = "Petar",
                    LastName = "Petrov",
                    Number = 11111
                });

            context.Students.AddOrUpdate(
                new Student
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Number = 22222
                });
        }

        private void SeedHomeworks(StudentsSystemEntities context)
        {
            context.Homeworks.Add(
                new Homework
                {
                    Content = "bla bla",
                    CourseId = 1,
                    StudentId = 1,
                    TimeSent = DateTime.Now,
                });

            context.Homeworks.Add(
                new Homework
                {
                    Content = "bla bla bla",
                    CourseId = 2,
                    StudentId = 2,
                    TimeSent = new DateTime(2014, 1, 1),
                });

            context.Homeworks.Add(
                new Homework
                {
                    Content = "nice homework",
                    CourseId = 3,
                    StudentId = 3,
                    TimeSent = new DateTime(2013, 1, 1),
                });
        }
    }
}
