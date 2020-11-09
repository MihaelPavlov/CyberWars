namespace CyberWars.Data.Models.Course
{
    using System.Collections.Generic;

    public class Course
    {
        public Course()
        {
            this.Lectures = new HashSet<Lecture>();
            this.PlayerCourses = new HashSet<PlayerCourse>();
        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }

        public virtual ICollection<PlayerCourse> PlayerCourses { get; set; }
    }
}
