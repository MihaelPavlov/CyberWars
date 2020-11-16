namespace CyberWars.Data.Seeding.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Job;

    public class JobRequirementSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.JobRequirements.Any())
            {
                return;
            }

            var jobsLevel1 = dbContext.Jobs.Where(x => x.LevelRequirement == 1);
            var requirements = dbContext.Requirements.ToList();

            dbContext.JobRequirements.Add(new JobRequirement
            {
                JobId = jobsLevel1.FirstOrDefault(x => x.Name == "System Software").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 10).Id,
            });
            dbContext.JobRequirements.Add(new JobRequirement
            {
                JobId = jobsLevel1.FirstOrDefault(x => x.Name == "System Software").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "HTML" && x.Points == 10).Id,
            });
            dbContext.JobRequirements.Add(new JobRequirement
            {
                JobId = jobsLevel1.FirstOrDefault(x => x.Name == "System Software").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "CSS" && x.Points == 10).Id,
            });
            dbContext.SaveChanges();
        }
    }
}
