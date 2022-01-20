namespace CyberWars.Services.Data.Hangfire
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Job;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// A custom implementation of <see cref="IAddJobService"/>.
    /// </summary>
    public class AddJobService : IAddJobService
    {
        private readonly IDeletableEntityRepository<Job> jobsReposiotry;
        private readonly IDeletableEntityRepository<RandomHangfireJob> hangfireJobsReposiotry;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddJobService"/> class.
        /// </summary>
        public AddJobService(IDeletableEntityRepository<Job> jobsReposiotry, IDeletableEntityRepository<RandomHangfireJob> hangfireJobsReposiotry)
        {
            this.jobsReposiotry = jobsReposiotry ?? throw new ArgumentNullException(nameof(jobsReposiotry));
            this.hangfireJobsReposiotry = hangfireJobsReposiotry ?? throw new ArgumentNullException(nameof(hangfireJobsReposiotry));
        }

        /// <inheritdoc/>
        public async Task UpdateRandomJobs()
        {
            var randomJobs = await this.jobsReposiotry.All().ToListAsync();

            while (randomJobs.Count() != 15)
            {
                int index = new Random().Next(0, randomJobs.Count());
                randomJobs.RemoveAt(index);
            }

            // Remove Jobs from HangireJobsTable
            var hangfireJobs = await this.hangfireJobsReposiotry.All().ToListAsync();

            foreach (var job in hangfireJobs)
            {
                this.hangfireJobsReposiotry.Delete(job);
            }

            foreach (var job in randomJobs)
            {
                await this.hangfireJobsReposiotry.AddAsync(new RandomHangfireJob
                {
                    Job = job,
                    JobId = job.Id,
                });
            }

            await this.hangfireJobsReposiotry.SaveChangesAsync();
        }
    }
}
