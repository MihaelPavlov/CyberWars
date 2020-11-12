namespace CyberWars.Data.Models.Course
{
    using CyberWars.Data.Common.Models;
    using System.Collections.Generic;

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
