namespace CyberWars.Data.Models.CompetitiveCoding
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using CyberWars.Data.Common.Models;

    public class Contest : BaseDeletableModel<int>
    {
        public Contest()
        {
            this.PlayerContests = new HashSet<PlayerContest>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        [Range(1, 100)]
        public int Percentage { get; set; }

        public int RewardMoney { get; set; }

        public int RewardExp { get; set; }

        public int ConsumeEnergy { get; set; }

        public virtual ICollection<PlayerContest> PlayerContests { get; set; }
    }
}
