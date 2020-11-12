namespace CyberWars.Data.Models.Course
{
    using System.Collections.Generic;

    using CyberWars.Data.Common.Models;

    public class Course : BaseDeletableModel<int>
    {
        public Course()
        {
            this.Lectures = new HashSet<Lecture>();
            this.PlayerCourses = new HashSet<PlayerCourse>();
        }

        public string Name { get; set; }

        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }

        public virtual ICollection<PlayerCourse> PlayerCourses { get; set; }
    }
}
