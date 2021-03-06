﻿namespace CyberWars.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Seeding.Academy;
    using CyberWars.Data.Seeding.Home;
    using CyberWars.Data.Seeding.Pets_Food;
    using CyberWars.Data.Seeding.Web;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                              new SettingsSeeder(),
                              new LevelSeeder(),
                              new AbilityTypeSeeder(),
                              new AbilitiesSeeder(),
                              new RequirementsSeeder(),
                              new BadgeSeeder(),
                              new SkillSeeder(),
                              new BadgeRequirementSeeder(),
                              new PetSeeder(),
                              new FoodSeeder(),
                              new JobTypeSeeder(),
                              new JobSeeder(),
                              new ContestSeeder(),
                              new JobRequirementSeeder(),
                              new CourseTypeSeeder(),
                              new CourseSeeder(),
                              new LectureSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
