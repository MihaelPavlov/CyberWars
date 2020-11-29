namespace CyberWars.Services.Data.Hangfire
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAddJobService
    {
        public Task UpdateRandomJobs();
    }
}
