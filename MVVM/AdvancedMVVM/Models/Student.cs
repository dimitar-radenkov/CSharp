namespace AdvancedMVVM.Models
{
    using System.Collections.Generic;

    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ISSN { get; private set; }
        public int Age { get; set; }

        public IList<string> Courses { get; private set; }
       
        public Student(string firstName, 
            string lastName,
            string issn,
            int age,
            IList<string> courses)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ISSN = issn;
            this.Age = age;

            this.Courses = courses;
        }

        public Student(string firstName,
            string lastName, 
            string issn,
            int age)
            : this(firstName, lastName, issn, age, new List<string>())
        {           
        }
    }
}
