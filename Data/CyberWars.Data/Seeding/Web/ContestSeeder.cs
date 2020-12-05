namespace CyberWars.Data.Seeding.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.CompetitiveCoding;

    public class ContestSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Contests.Any())
            {
                return;
            }

            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "Cyber Wars",
                ConsumeEnergy = 20,
                RewardExp = 100,
                RewardMoney = 10000,
                Percentage = 1,
                ImageName = "CyberWars",
            });
            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "International Collegiate Contest",
                ConsumeEnergy = 5,
                RewardExp = 20,
                RewardMoney = 1000,
                Percentage = 10,
                ImageName = "InternationalCollegiateContest",
            });

            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "International Olympiad Contest",
                ConsumeEnergy = 5,
                RewardExp = 10,
                RewardMoney = 200,
                Percentage = 15,
                ImageName = "InternationalOlympiadContest",
            });
            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "Code Chef",
                ConsumeEnergy = 10,
                RewardExp = 10,
                RewardMoney = 220,
                Percentage = 35,
                ImageName = "CodeChef",
            });
            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "Code Force",
                ConsumeEnergy = 3,
                RewardExp = 10,
                RewardMoney = 110,
                Percentage = 40,
                ImageName = "CodeForces",
            });
            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "Facebook Hacker Cup",
                ConsumeEnergy = 5,
                RewardExp = 5,
                RewardMoney = 50,
                Percentage = 50,
                ImageName = "FacebookHackerCup",
            });
            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "Hacker Rank",
                ConsumeEnergy = 5,
                RewardExp = 5,
                RewardMoney = 50,
                Percentage = 50,
                ImageName = "HackerRank",
            });
            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "Google Code Jam",
                ConsumeEnergy = 3,
                RewardExp = 3,
                RewardMoney = 60,
                Percentage = 55,
                ImageName = "GoogleCodeJam",
            });
            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "IEEEXtreme Programming",
                ConsumeEnergy = 4,
                RewardExp = 8,
                RewardMoney = 80,
                Percentage = 50,
                ImageName = "IEEEXtremeProgramming",
            });
            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "Topcoder Open",
                ConsumeEnergy = 2,
                RewardExp = 4,
                RewardMoney = 50,
                Percentage = 70,
                ImageName = "TopCoder",
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
