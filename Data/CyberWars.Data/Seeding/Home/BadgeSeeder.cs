namespace CyberWars.Data.Seeding.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Badge;

    public class BadgeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Badges.Any())
            {
                return;
            }

            dbContext.Badges.Add(new Badge
            {
                Name = "Code Master",
                ImageName = "14.Code",
                Description = "Master",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "Code Wizard",
                ImageName = "13.CodeWizard",
                Description = "Programmer or Wizard. Or you are a Code Wizard!",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "Code Guru",
                ImageName = "12.CodeGuru",
                Description = "This badge is given to the Guru, a person who is balanced and knows what he is doing every second.",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "CTO",
                ImageName = "11.CTO",
                Description = "One word technology chef or CTO(Chief technology Officer).",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "TeamLead",
                ImageName = "10.TeamLead",
                Description = "This badge is taken when you can lead a team,make difficult decisions,guide your people and more.",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "Trainer",
                ImageName = "09.Trainer",
                Description = "A badge is given to a person with a lot of knowledge who is ready to pass on all these skills to people willing to learn.",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "Arhitect",
                ImageName = "08.Arhitect",
                Description = "This badge is given to a real architect, a person who has an eye and a mind and can create something wonderful!",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "Senior Developer",
                ImageName = "07.SeniorDeveloper",
                Description = "To acquire this badge you must be able to manage a team of Junior Developers, to watch over all projects.",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "Full Stack Developer",
                ImageName = "06.FullStackDeveloper",
                Description = "This badge is taken when you can do UI Design on a website and Server client Requirements and you can navigate boldly with databases.ONE MAN ARMY!",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "FrontEnd Developer",
                ImageName = "05.FrontEndDeveloper",
                Description = "This badge is given to the UI Master,a person who has an eye for beauty!",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "BackEnd Developer",
                ImageName = "04.BackEndDeveloper",
                Description = "You get this badge when you are on the server side of the development, where you are focused mainly on how the site works.",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "Mid Developer",
                ImageName = "03.MidDeveloper",
                Description = "You receive this badge when you have already gained solid knowledge.",
            });

            dbContext.Badges.Add(new Badge
            {
                Name = "Junior Developer",
                ImageName = "02.JuniorDeveloper",
                Description = "A badge that marks the start of your career!",
            });
            dbContext.Badges.Add(new Badge
            {
                Name = "Student Developer",
                ImageName = "01.StudentDeveloper",
                Description = "The holder of this badge is the Best Student!",
            });

            dbContext.SaveChanges();
        }
    }
}
