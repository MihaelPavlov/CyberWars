namespace CyberWars.Services.Data.Web
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Job;
    using CyberWars.Services.Mapping;

    public class WebService : IWebService
    {
        private readonly IDeletableEntityRepository<Job> jobsReposiotry;

        public WebService(IDeletableEntityRepository<Job> jobsReposiotry)
        {
            this.jobsReposiotry = jobsReposiotry;
        }

        public async Task<IEnumerable<T>> GetRandomJobs<T>()
        {
            var randomJobs = await this.jobsReposiotry.All().To<T>().ToListAsync();

            while (randomJobs.Count() != 5)
            {
                int index = new Random().Next(0, randomJobs.Count());
                randomJobs.RemoveAt(index);
            }

            return randomJobs;
        }
    }
}
