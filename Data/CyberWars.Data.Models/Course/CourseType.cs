namespace CyberWars.Data.Models.Course
{
    using System.Collections.Generic;

    public class CourseType
    {
        public CourseType()
        {
            this.Courses = new HashSet<Course>();
        }

        public int CourseTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
