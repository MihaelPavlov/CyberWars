namespace CyberWars.Web.ViewModels.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Course;
    using CyberWars.Services.Mapping;

    public class LectureViewModel : IMapFrom<Lecture>
    {
        public string Name { get; set; }

        public int TimeMinutes { get; set; }

        public int RewardAbilityPoints { get; set; }

        public int RewardMoney { get; set; }

        public int RewardSkill { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }
    }
}
