namespace CyberWars.Data.Seeding.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Badge;

    public class BadgeRequirementSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BadgeRequirements.Any())
            {
                return;
            }

            var requirements = dbContext.Requirements.ToList();
            var badges = dbContext.Badges.ToList();
            // Student Developer Badge
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Student Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 20).Id,
            }) ;

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Student Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 20).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Student Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "HTML" && x.Points == 15).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Student Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "CSS" && x.Points == 15).Id,
            });

            // Junior Developer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 40).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "MSSQL" && x.Points == 25).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "ASP.NET Core" && x.Points == 20).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Angular" && x.Points == 20).Id,
            });

            // Mid Developer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Mid Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 50).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Mid Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 40).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Mid Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "React.JS" && x.Points == 40).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Mid Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "ASP.NET Core" && x.Points == 40).Id,
            });

            // BackEnd Developer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "BackEnd Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 70).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "BackEnd Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "MSSQL" && x.Points == 60).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "BackEnd Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "ASP.NET Core" && x.Points == 60).Id,
            });

            dbContext.SaveChanges();
        }
    }
}
