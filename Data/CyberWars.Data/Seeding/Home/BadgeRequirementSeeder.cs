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
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 5).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Student Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 5).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Student Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Java" && x.Points == 5).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Student Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Python" && x.Points == 5).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Student Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "HTML" && x.Points == 5).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Student Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "CSS" && x.Points == 5).Id,
            });

            // Junior Developer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 10).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 10).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "MSSQL" && x.Points == 10).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "ASP.NETCore" && x.Points == 5).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Junior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Angular" && x.Points == 5).Id,
            });

            // Mid Developer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Mid Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Java" && x.Points == 20).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Mid Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 20).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Mid Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "React.JS" && x.Points == 10).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Mid Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "ASP.NETCore" && x.Points == 10).Id,
            });

            // BackEnd Developer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "BackEnd Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "BackEnd Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "MSSQL" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "BackEnd Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "ASP.NETCore" && x.Points == 20).Id,
            });

            // FrontEnd Developer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "FrontEnd Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "CSS" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "FrontEnd Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "HTML" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "FrontEnd Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 30).Id,
            });

            // Full Stack Developer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Full Stack Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Full Stack Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Full Stack Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "HTML" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Full Stack Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "CSS" && x.Points == 30).Id,
            });

            // Senior Developer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Senior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Senior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Senior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Python" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Senior Developer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Java" && x.Points == 30).Id,
            });

            // Arhitect
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Arhitect").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 40).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Arhitect").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 40).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Arhitect").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Python" && x.Points == 30).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Arhitect").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "HTML" && x.Points == 25).Id,
            });

            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Arhitect").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "CSS" && x.Points == 25).Id,
            });

            // Trainer
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Trainer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 35).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Trainer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Python" && x.Points == 35).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Trainer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 35).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Trainer").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Java" && x.Points == 35).Id,
            });

            // TeamLead
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "TeamLead").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Java" && x.Points == 40).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "TeamLead").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 40).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "TeamLead").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 40).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "TeamLead").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Python" && x.Points == 40).Id,
            });

            // CTO
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "CTO").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 45).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "CTO").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 45).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "CTO").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Java" && x.Points == 45).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "CTO").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Python" && x.Points == 45).Id,
            });

            // Code Guru
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Guru").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "ASP.NETCore" && x.Points == 30).Id,
            }); 
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Guru").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "SpringFramework" && x.Points == 30).Id,
            }); 
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Guru").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Angular" && x.Points == 20).Id,
            });

            // Code Wizard
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Wizard").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 70).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Wizard").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 70).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Wizard").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Java" && x.Points == 70).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Wizard").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Python" && x.Points == 70).Id,
            });

            // Code Master
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Master").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "C#" && x.Points == 100).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Master").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "JS" && x.Points == 100).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Master").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Java" && x.Points == 100).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Master").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Python" && x.Points == 100).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Master").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Angular" && x.Points == 20).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Master").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "ASP.NETCore" && x.Points == 30).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Master").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "SpringFramework" && x.Points == 30).Id,
            });
            dbContext.BadgeRequirements.Add(new BadgeRequirement
            {
                BadgeId = badges.FirstOrDefault(x => x.Name == "Code Master").Id,
                RequirementId = requirements.FirstOrDefault(x => x.Name == "Django" && x.Points == 30).Id,
            });

            dbContext.SaveChanges();
        }
    }
}
