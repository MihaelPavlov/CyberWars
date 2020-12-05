namespace CyberWars.Data.Models.CompetitiveCoding
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class RandomHangfireContest : BaseDeletableModel<int>
    {
        public Contest Contest { get; set; }

        public int ContestId { get; set; }
    }
}
