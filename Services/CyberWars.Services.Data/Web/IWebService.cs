namespace CyberWars.Services.Data.Web
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Job;

    public interface IWebService
    {
        /// <summary>
        /// Use this method to complete a job.
        /// </summary>
        /// <param name="jobId">A integer representing the job Id.</param>
        /// <param name="userId">A string representing the user Id.</param>
        public Task CompleteJob(int jobId, string userId);

        /// <summary>
        /// Use this method to get random jobs.
        /// </summary>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> GetRandomJobs<T>();

        /// <summary>
        /// Use this method to get collection of jobs that player completed.
        /// </summary>
        /// <param name="userId">A string representing the user Id.</param>
        /// <returns>A collection of <see cref="PlayerJob"/>.</returns>
        public Task<IEnumerable<PlayerJob>> GetPlayerCompleteJobs(string userId);
    }
}
