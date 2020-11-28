namespace CyberWars.Data.Models.Job
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Common.Models;

    public class RandomHangfireJob : BaseDeletableModel<int>
    {
        public Job Job { get; set; }

        public int JobId { get; set; }
    }
}
