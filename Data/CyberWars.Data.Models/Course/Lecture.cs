namespace CyberWars.Data.Models.Course
{
    using System.Collections.Generic;

    public class Lecture
    {
        public Lecture()
        {
            this.CompleteLectures = new HashSet<CompleteLecture>();
        }

        public int LectureId { get; set; }

        public string Name { get; set; }

        public int TimeMinutes { get; set; }

        public int RewardAbilityPoints { get; set; }

        public int RewardMoney { get; set; }

        public int RewardSkill { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public virtual ICollection<CompleteLecture> CompleteLectures { get; set; }
    }
}
