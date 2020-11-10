namespace CyberWars.Data.Models.Course
{
    using System;

    using CyberWars.Data.Models.Player;

    public class PlayerCourse
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public bool IsComplete { get; set; }

        public DateTime CompleteDate { get; set; }
    }
}
