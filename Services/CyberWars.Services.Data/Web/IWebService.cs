﻿namespace CyberWars.Services.Data.Web
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Job;

    public interface IWebService
    {
        public Task CompleteJob(int jobId, string userId);

        public Task<IEnumerable<T>> GetRandomJobs<T>();

        public Task<IEnumerable<PlayerJob>> GetPlayerCompleteJobs(string userId);
    }
}
