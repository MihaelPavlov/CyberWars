namespace CyberWars.Data.Models.Job
{
    using System;

    using CyberWars.Data.Models.Player;

    public class PlayerJob
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int JobId { get; set; }

        public Job Job { get; set; }

        public DateTime DateOfComplete { get; set; }

        public bool IsComplete { get; set; }
    }
}
