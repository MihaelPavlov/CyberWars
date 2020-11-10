namespace CyberWars.Data.Models.Course
{
    using CyberWars.Data.Models.Player;

    public class CompleteLecture
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }

        public bool IsComplete { get; set; }
    }
}
