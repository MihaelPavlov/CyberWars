namespace CyberWars.Data.Models.Course
{
    using System.Collections.Generic;

    using CyberWars.Data.Common.Models;

    public class Lecture : BaseDeletableModel<int>
    {
        public Lecture()
        {
            this.CompleteLectures = new HashSet<CompleteLecture>();
        }

        public string Name { get; set; }

        public int Number { get; set; }

        public int ExperienceToComplete { get; set; }

        public string RewardAbilityName { get; set; }

        public int RewardMoney { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public virtual ICollection<CompleteLecture> CompleteLectures { get; set; }
    }
}
