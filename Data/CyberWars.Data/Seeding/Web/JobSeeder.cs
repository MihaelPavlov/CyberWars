namespace CyberWars.Data.Seeding.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Job;

    public class JobSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Jobs.Any())
            {
                return;
            }

            var jobTypes = dbContext.JobTypes.ToList();

            var software = jobTypes.FirstOrDefault(x => x.Name == "Software").Id;
            var website = jobTypes.FirstOrDefault(x => x.Name == "Website").Id;

            dbContext.Jobs.Add(new Job
            {
                Name = "System Software",
                JobTypeId = software,
                LevelRequirement = 1,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Programming Software",
                JobTypeId = software,
                LevelRequirement = 1,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Application Software",
                JobTypeId = software,
                LevelRequirement = 1,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Driver Software",
                JobTypeId = software,
                LevelRequirement = 1,
            });


            dbContext.Jobs.Add(new Job
            {
                Name = "System Software",
                JobTypeId = software,
                LevelRequirement = 3,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Programming Software",
                JobTypeId = software,
                LevelRequirement = 3,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Application Software",
                JobTypeId = software,
                LevelRequirement = 3,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Driver Software",
                JobTypeId = software,
                LevelRequirement = 3,
            });

            dbContext.Jobs.Add(new Job
            {
                Name = "Fitness",
                JobTypeId = website,
                LevelRequirement = 1,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Food Delivery",
                JobTypeId = website,
                LevelRequirement = 1,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Date Chat",
                JobTypeId = website,
                LevelRequirement = 1,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Academy",
                JobTypeId = website,
                LevelRequirement = 1,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Shoes Shop",
                JobTypeId = website,
                LevelRequirement = 1,
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Computer Shop",
                JobTypeId = website,
                LevelRequirement = 1,
            });
            dbContext.SaveChanges();
        }
    }
}
