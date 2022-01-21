namespace CyberWars.Data.Models.CompetitiveCoding
{
    using CyberWars.Data.Common.Models;

    public class RandomHangfireContest : BaseDeletableModel<int>
    {
        public Contest Contest { get; set; }

        public int ContestId { get; set; }
    }
}
