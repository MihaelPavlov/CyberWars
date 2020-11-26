namespace CyberWars.Data.Models.Course
{
    using CyberWars.Data.Common.Models;
    using System.Collections.Generic;

    public class Lecture : BaseDeletableModel<int>
    {
        public Lecture()
        {
            this.CompleteLectures = new HashSet<CompleteLecture>();
        }

        public string Name { get; set; }

        public int Number { get; set; }

        public int TimeMinutes { get; set; }

        public string RewardAbilityName { get; set; }

        public int RewardMoney { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public virtual ICollection<CompleteLecture> CompleteLectures { get; set; }
    }
}
