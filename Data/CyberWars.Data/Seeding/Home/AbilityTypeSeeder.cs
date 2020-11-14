namespace CyberWars.Data.Seeding.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Ability;

    public class AbilityTypeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.AbilityTypes.Any())
            {
                return;
            }

            dbContext.AbilityTypes.Add(new AbilityType
            {
                Type = "Frameworks",
            });

            dbContext.AbilityTypes.Add(new AbilityType
            {
                Type = "Database",
            });

            dbContext.AbilityTypes.Add(new AbilityType
            {
                Type = "Languages",
            });

            dbContext.SaveChanges();
        }

    }
}
