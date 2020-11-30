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
            var console = jobTypes.FirstOrDefault(x => x.Name == "Console").Id;

            // Python
            dbContext.Jobs.Add(new Job
            {
                Name = "Hello World",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 50,
                RewardExp = 5,
                RewardAbilityNames = "Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Chess Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Timer",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Snake Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Tik-Toe Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Yu-Gi-Oh Simple Card Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });

            // Website Level 5 C#
            dbContext.Jobs.Add(new Job
            {
                Name = "Fitness",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 500,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Food Delivery",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 600,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Date Chat",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 550,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Academy",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 780,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Shoes Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 690,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Computer Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 850,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });

            // Software Level 8 C#
            dbContext.Jobs.Add(new Job
            {
                Name = "System Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1000,
                RewardExp = 40,
                RewardAbilityNames = "Python Python Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Programming Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1300,
                RewardExp = 40,
                RewardAbilityNames = "Python Python Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Application Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1200,
                RewardExp = 40,
                RewardAbilityNames = "Python Python Python",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Driver Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1700,
                RewardExp = 40,
                RewardAbilityNames = "Python Python Python",
            });

            // Java
            dbContext.Jobs.Add(new Job
            {
                Name = "Hello World",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 50,
                RewardExp = 5,
                RewardAbilityNames = "Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Chess Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Timer",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Snake Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Tik-Toe Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Yu-Gi-Oh Simple Card Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Java",
            });

            // Website Level 5 C#
            dbContext.Jobs.Add(new Job
            {
                Name = "Fitness",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 500,
                RewardExp = 20,
                RewardAbilityNames = "Java Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Food Delivery",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 600,
                RewardExp = 20,
                RewardAbilityNames = "Java Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Date Chat",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 550,
                RewardExp = 20,
                RewardAbilityNames = "Java Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Academy",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 780,
                RewardExp = 20,
                RewardAbilityNames = "Java Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Shoes Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 690,
                RewardExp = 20,
                RewardAbilityNames = "Java Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Computer Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 850,
                RewardExp = 20,
                RewardAbilityNames = "Java Java",
            });

            // Software Level 8 C#
            dbContext.Jobs.Add(new Job
            {
                Name = "System Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1000,
                RewardExp = 40,
                RewardAbilityNames = "Java Java Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Programming Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1300,
                RewardExp = 40,
                RewardAbilityNames = "Java Java Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Application Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1200,
                RewardExp = 40,
                RewardAbilityNames = "Java Java Java",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Driver Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1700,
                RewardExp = 40,
                RewardAbilityNames = "Java Java Java",
            });

            // JS
            dbContext.Jobs.Add(new Job
            {
                Name = "Hello World",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 50,
                RewardExp = 5,
                RewardAbilityNames = "JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Chess Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Timer",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Snake Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Tik-Toe Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Yu-Gi-Oh Simple Card Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "JS",
            });

            // Website Level 5 C#
            dbContext.Jobs.Add(new Job
            {
                Name = "Fitness",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 500,
                RewardExp = 20,
                RewardAbilityNames = "JS JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Food Delivery",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 600,
                RewardExp = 20,
                RewardAbilityNames = "JS JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Date Chat",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 550,
                RewardExp = 20,
                RewardAbilityNames = "JS JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Academy",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 780,
                RewardExp = 20,
                RewardAbilityNames = "JS JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Shoes Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 690,
                RewardExp = 20,
                RewardAbilityNames = "JS JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Computer Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 850,
                RewardExp = 20,
                RewardAbilityNames = "JS JS",
            });

            // Software Level 8 C#
            dbContext.Jobs.Add(new Job
            {
                Name = "System Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1000,
                RewardExp = 40,
                RewardAbilityNames = "JS JS JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Programming Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1300,
                RewardExp = 40,
                RewardAbilityNames = "JS JS JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Application Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1200,
                RewardExp = 40,
                RewardAbilityNames = "JS JS JS",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Driver Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1700,
                RewardExp = 40,
                RewardAbilityNames = "JS JS JS",
            });

            // Console Level 1 C#
            dbContext.Jobs.Add(new Job
            {
                Name = "Hello World",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 50,
                RewardExp = 5,
                RewardAbilityNames = "C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Chess Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Timer",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Snake Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Tik-Toe Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Yu-Gi-Oh Simple Card Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "C#",
            });

            // Website Level 5 C#
            dbContext.Jobs.Add(new Job
            {
                Name = "Fitness",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 500,
                RewardExp = 20,
                RewardAbilityNames = "C# C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Food Delivery",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 600,
                RewardExp = 20,
                RewardAbilityNames = "C# C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Date Chat",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 550,
                RewardExp = 20,
                RewardAbilityNames = "C# C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Academy",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 780,
                RewardExp = 20,
                RewardAbilityNames = "C# C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Shoes Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 690,
                RewardExp = 20,
                RewardAbilityNames = "C# C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Computer Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 850,
                RewardExp = 20,
                RewardAbilityNames = "C# C#",
            });

            // Software Level 8 C#
            dbContext.Jobs.Add(new Job
            {
                Name = "System Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1000,
                RewardExp = 40,
                RewardAbilityNames = "C# C# C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Programming Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1300,
                RewardExp = 40,
                RewardAbilityNames = "C# C# C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Application Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1200,
                RewardExp = 40,
                RewardAbilityNames = "C# C# C#",
            });
            dbContext.Jobs.Add(new Job
            {
                Name = "Driver Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1700,
                RewardExp = 40,
                RewardAbilityNames = "C# C# C#",
            });
            dbContext.SaveChanges();
        }
    }
}
