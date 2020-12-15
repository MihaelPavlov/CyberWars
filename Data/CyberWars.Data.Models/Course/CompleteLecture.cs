namespace CyberWars.Data.Models.Course
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class CompleteLecture : IDeletableEntity
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }

        public bool IsComplete { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
