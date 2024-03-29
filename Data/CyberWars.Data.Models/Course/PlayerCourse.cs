﻿namespace CyberWars.Data.Models.Course
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class PlayerCourse : IDeletableEntity
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public bool IsComplete { get; set; }

        public DateTime CompleteDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
