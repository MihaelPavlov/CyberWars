namespace CyberWars.Data.Models.Job
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class RandomHangfireJob : BaseDeletableModel<int>
    {
        public Job Job { get; set; }

        public int JobId { get; set; }

        public string PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
