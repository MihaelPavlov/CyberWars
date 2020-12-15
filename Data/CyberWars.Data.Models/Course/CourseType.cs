namespace CyberWars.Data.Models.Course
{
    using System.Collections.Generic;

    using CyberWars.Data.Common.Models;

    public class CourseType : BaseDeletableModel<int>
    {
        public CourseType()
        {
            this.Courses = new HashSet<Course>();
        }

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
