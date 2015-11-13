namespace StudentSystemModels
{
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }

        [Required]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(160)]
        public string Description { get; set; }

        public string MaterialsPath { get; set; }


        //this property is for testing migrations
        //public double HoursPerWeek { get; set; }
        //////////////////////////////////////////


        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
