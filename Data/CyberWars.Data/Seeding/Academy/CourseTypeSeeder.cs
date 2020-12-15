namespace CyberWars.Data.Seeding.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Course;

    public class CourseTypeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CourseTypes.Any())
            {
                return;
            }

            dbContext.CourseTypes.Add(new CourseType
            {
                Name = "Basic",
            });

            dbContext.CourseTypes.Add(new CourseType
            {
                Name = "C#",
            });

            dbContext.CourseTypes.Add(new CourseType
            {
                Name = "JS",
            });

            dbContext.CourseTypes.Add(new CourseType
            {
                Name = "Java",
            });

            dbContext.CourseTypes.Add(new CourseType
            {
                Name = "Python",
            });

            dbContext.SaveChanges();
        }
    }
}
