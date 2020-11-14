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
                Name = "Other Food",
                GainHealth = 100,
                GainExp = 100,
                LevelRequirement = 7,
                Price = 250.00M,
                ImageName = "Food2",
                Description = "For all Animals",
            });

            dbContext.Foods.Add(new Food
            {
                Name = "Dog,Cat Food",
                GainHealth = 100,
                GainExp = 100,
                LevelRequirement = 5,
                Price = 200.00M,
                ImageName = "Food",
                Description = "Animals for Cats and Dogs! Yummy !",
            });

            dbContext.Foods.Add(new Food
            {
                Name = "Fish",
                GainHealth = 55,
                GainExp = 44,
                LevelRequirement = 3,
                Price = 100.00M,
                ImageName = "fish",
                Description = "Smelly !!",
            });

            dbContext.Foods.Add(new Food
            {
                Name = "Pizza",
                GainHealth = 80,
                GainExp = 20,
                LevelRequirement = 2,
                Price = 70.00M,
                ImageName = "pizza",
                Description = "That tasy pizza !",
            });

            dbContext.SaveChanges();
        }
    }
}
