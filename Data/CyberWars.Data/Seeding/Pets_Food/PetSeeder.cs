namespace CyberWars.Data.Seeding.Pets_Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Pet_Food;

    public class PetSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Pets.Any())
            {
                return;
            }

            dbContext.Pets.Add(new Pet
            {
                Name = "Bat",
                ImageName = "Bat",
                Price = 6700.00M,
                Description = "Mini Batman",
                LevelRequirement = 14,
            });

            dbContext.Pets.Add(new Pet
            {
                Name = "Turtle",
                ImageName = "Turtle",
                Price = 5500.00M,
                Description = "Slowly as .....",
                LevelRequirement = 11,
            });

            dbContext.Pets.Add(new Pet
            {
                Name = "Fish",
                ImageName = "Fish_Dori",
                Price = 4000.00M,
                Description = "Fish Go Plup plup",
                LevelRequirement = 8,
            });

            dbContext.Pets.Add(new Pet
            {
                Name = "Dog",
                ImageName = "Dog",
                Price = 1500.00M,
                Description = "Your Best Friend",
                LevelRequirement = 6,
            });

            dbContext.Pets.Add(new Pet
            {
                Name = "Cat",
                ImageName = "Cat",
                Price = 200.00M,
                Description = "The Cutes Cat in the world.",
                LevelRequirement = 2,
            });

            dbContext.SaveChanges();
        }
    }
}
