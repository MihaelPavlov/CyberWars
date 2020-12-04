namespace CyberWars.Data.Seeding.Pets_Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Pet_Food;

    public class FoodSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Foods.Any())
            {
                return;
            }

            dbContext.Foods.Add(new Food
            {
                Name = "Food +100",
                GainHealth = 100,
                GainExp = 100,
                LevelRequirement = 14,
                Price = 250.00M,
                ImageName = "Food7",
                Description = "No",
            });
            dbContext.Foods.Add(new Food
            {
                Name = "Food +80",
                GainHealth = 80,
                GainExp = 100,
                LevelRequirement = 11,
                Price = 400.00M,
                ImageName = "Food6",
                Description = "No",
            });
            dbContext.Foods.Add(new Food
            {
                Name = "Food +65",
                GainHealth = 65,
                GainExp = 100,
                LevelRequirement = 9,
                Price = 340.00M,
                ImageName = "Food5",
                Description = "No",
            });
            dbContext.Foods.Add(new Food
            {
                Name = "Food +50",
                GainHealth = 50,
                GainExp = 100,
                LevelRequirement = 7,
                Price = 250.00M,
                ImageName = "Food4",
                Description = "No",
            });

            dbContext.Foods.Add(new Food
            {
                Name = "Food +40",
                GainHealth = 40,
                GainExp = 100,
                LevelRequirement = 5,
                Price = 200.00M,
                ImageName = "Food3",
                Description = "No",
            });

            dbContext.Foods.Add(new Food
            {
                Name = "Food +20",
                GainHealth = 20,
                GainExp = 40,
                LevelRequirement = 3,
                Price = 70.00M,
                ImageName = "Food2",
                Description = "No",
            });

            dbContext.Foods.Add(new Food
            {
                Name = "Food +15",
                GainHealth = 15,
                GainExp = 20,
                LevelRequirement = 2,
                Price = 50.00M,
                ImageName = "Food1",
                Description = "No",
            });

            dbContext.SaveChanges();
        }
    }
}
