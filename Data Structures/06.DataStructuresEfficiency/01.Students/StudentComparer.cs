namespace _01.Students
{
    using System.Collections.Generic;

    public class StudnetComparer : Comparer<Student>
    {
        public override int Compare(Student x, Student y)
        {
            var firstNameComparer = x.FirstName.CompareTo(y.FirstName);
            var lastNameComparer = x.LastName.CompareTo(y.LastName);

            if (lastNameComparer != 0)
            {
                return lastNameComparer;
            }

            return firstNameComparer;
        }
    }
}
