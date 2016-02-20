namespace AdvancedMVVM.Models.ViewModels
{
    using Microsoft.Practices.Prism.Mvvm;
    using System.Collections.Generic;

    public class StudentViewModel : BindableBase
    {
        private string name;
        private string issn;
        private int age;
        private IEnumerable<string> courses;

        public StudentViewModel()
        { }

        public StudentViewModel(Student student)
        {
            this.Name = string.Format(
                "{0} {1}",
                student.FirstName,
                student.LastName);

            this.ISSN = student.ISSN;
            this.Age = student.Age;
            this.Courses = student.Courses;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    base.OnPropertyChanged(nameof(this.Name));
                }
            }
        }

        public string ISSN
        {
            get
            {
                return this.issn;
            }

            set
            {
                if (this.issn != value)
                {
                    this.issn = value;
                    base.OnPropertyChanged(nameof(this.ISSN));
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    base.OnPropertyChanged(nameof(this.Age));
                }
            }
        }

        public IEnumerable<string> Courses
        {
            get
            {
                return this.courses;               
            }

            set
            {
                if (this.courses != value)
                {
                    this.courses = value;
                    base.OnPropertyChanged(nameof(this.Courses));
                }
            }
        }
    }
}
