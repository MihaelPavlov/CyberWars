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
                StartMoney = 98,
            });

            dbContext.Skills.Add(new Skill
            {
                Name = "Motivation",
                Description = "Motivation is the reason for people's action",
                StartMoney = 112,
            });

            dbContext.Skills.Add(new Skill
            {
                Name = "Cunning",
                Description = "Enhances the money of perBattle + 5",
                StartMoney = 124,
            });

            dbContext.Skills.Add(new Skill
            {
                Name = "Staying Power",
                Description = "Increase the energy + 5",
                StartMoney = 89,
            });

            dbContext.Skills.Add(new Skill
            {
                Name = "Health",
                Description = "Affects the amount of life + 10",
                StartMoney = 113,
            });

            dbContext.SaveChanges();
        }
    }
}
