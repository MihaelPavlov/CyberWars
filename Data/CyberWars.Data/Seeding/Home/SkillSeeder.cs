namespace CyberWars.Data.Seeding.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Skills;

    public class SkillSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Skills.Any())
            {
                return;
            }

            dbContext.Skills.Add(new Skill
            {
                Name = "Firewall Defence",
                Description = "Increase the chanse to defence from attacks",
                StartMoney = 120,
            });

            dbContext.Skills.Add(new Skill
            {
                Name = "Motivation",
                Description = "Motivation is the reason for people's action",
                StartMoney = 120,
            });

            dbContext.Skills.Add(new Skill
            {
                Name = "Knowledge",
                Description = "Enchances thought and speed of thinking",
                StartMoney = 120,
            });

            dbContext.Skills.Add(new Skill
            {
                Name = "Staying Power",
                Description = "Increase the hours you can stay at the computer",
                StartMoney = 120,
            });

            dbContext.Skills.Add(new Skill
            {
                Name = "Health",
                Description = "Increase the health/live points",
                StartMoney = 120,
            });

            dbContext.SaveChanges();
        }
    }
}
