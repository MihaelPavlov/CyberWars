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
                Name = "International Collegiate Programming Contest",
                ConsumeEnergy = 3,
                RewardExp = 4,
                RewardMoney = 50,
                Percentage = 30,
            });

            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "Topcoder Open",
                ConsumeEnergy = 2,
                RewardExp = 4,
                RewardMoney = 50,
                Percentage = 70,
            });

            await dbContext.Contests.AddAsync(new Contest
            {
                Name = "Google Code Jam",
                ConsumeEnergy = 3,
                RewardExp = 3,
                RewardMoney = 60,
                Percentage = 55,
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
