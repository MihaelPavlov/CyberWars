namespace CyberWars.Data.Seeding.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Job;

    public class JobTypeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.JobTypes.Any())
            {
                return;
            }

            dbContext.JobTypes.Add(new JobType
            {
                Name = "Website",
            });

            dbContext.JobTypes.Add(new JobType
            {
                Name = "Software",
            });

            dbContext.JobTypes.Add(new JobType
            {
                Name = "Console",
            });

            dbContext.SaveChanges();
        }
    }
}
