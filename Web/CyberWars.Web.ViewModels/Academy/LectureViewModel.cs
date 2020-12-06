namespace CyberWars.Web.ViewModels.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Course;
    using CyberWars.Services.Mapping;

    public class LectureViewModel : IMapFrom<Lecture>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ExperienceToComplete { get; set; }

        public int PlayerExperience { get; set; }

        public string RewardAbilityName { get; set; }

        public int RewardMoney { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }
    }
}
