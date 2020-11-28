namespace CyberWars.Services.Data.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Job;
    using CyberWars.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class WebService : IWebService
    {
        private readonly IDeletableEntityRepository<Job> jobsReposiotry;
        private readonly IDeletableEntityRepository<RandomHangfireJob> hangfireJobsReposiotry;

        public WebService(IDeletableEntityRepository<Job> jobsReposiotry, IDeletableEntityRepository<RandomHangfireJob> hangfireJobsReposiotry)
        {
            this.jobsReposiotry = jobsReposiotry;
            this.hangfireJobsReposiotry = hangfireJobsReposiotry;
        }

        public async Task<IEnumerable<T>> GetRandomJobs<T>()
        {
            return await this.hangfireJobsReposiotry.All().Take(5).To<T>().ToListAsync();
        }

        public async Task UpdateRandomJobs()
        {
            var randomJobs = await this.jobsReposiotry.All().ToListAsync();

            while (randomJobs.Count() != 5)
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
