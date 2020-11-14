namespace CyberWars.Data.Seeding.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Badge;

    public class RequirementsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Requirements.Any())
            {
                return;
            }

            var allAbilities = dbContext.Abilities.ToList();

            foreach (var ability in allAbilities)
            {
                for (int i = 5; i <= 100; i += 5)
                {
                    dbContext.Requirements.Add(new Requirement
                    {
                        Name = ability.Name,
                        Points = i,
                        AbilityId = ability.Id,
                    });
                }
            }

            dbContext.SaveChanges();
        }
    }
}
