namespace CyberWars.Data.Seeding.Academy
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Course;

    public class CourseSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Courses.Any())
            {
                return;
            }

            var basicId = dbContext.CourseTypes.FirstOrDefault(x => x.Name == "Basic").Id;

            var csharpId = dbContext.CourseTypes.FirstOrDefault(x => x.Name == "C#").Id;

            var javaScriptId = dbContext.CourseTypes.FirstOrDefault(x => x.Name == "JS").Id;

            var javaId = dbContext.CourseTypes.FirstOrDefault(x => x.Name == "Java").Id;

            var pythonId = dbContext.CourseTypes.FirstOrDefault(x => x.Name == "Python").Id;

            // Python Courses
            dbContext.Courses.Add(new Course
            {
                Name = "Python Web Framework",
                CourseTypeId = pythonId,
                LevelToUnlock = 12,
            });

            dbContext.Courses.Add(new Course
            {
                Name = "Python Web Basics",
                CourseTypeId = pythonId,
                LevelToUnlock = 11,
            });

            dbContext.Courses.Add(new Course
            {
                Name = "Python OOP",
                CourseTypeId = pythonId,
                LevelToUnlock = 10,
            });

            dbContext.Courses.Add(new Course
            {
                Name = "Python Advanced",
                CourseTypeId = pythonId,
                LevelToUnlock = 9,
            });

            // Java Courses
            dbContext.Courses.Add(new Course
            {
                Name = "Spring Advanced",
                CourseTypeId = javaId,
                LevelToUnlock = 11,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Spring Fundamentals",
                CourseTypeId = javaId,
                LevelToUnlock = 10,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Spring Data",
                CourseTypeId = javaId,
                LevelToUnlock = 8,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "My SQL",
                CourseTypeId = javaId,
                LevelToUnlock = 7,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Java OOP",
                CourseTypeId = javaId,
                LevelToUnlock = 5,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Java Advanced",
                CourseTypeId = javaId,
                LevelToUnlock = 5,
            });

            // Js Courses
            dbContext.Courses.Add(new Course
            {
                Name = "Front-End Framework",
                CourseTypeId = javaScriptId,
                LevelToUnlock = 9,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "HTML & CSS",
                CourseTypeId = javaScriptId,
                LevelToUnlock = 8,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "React JS",
                CourseTypeId = javaScriptId,
                LevelToUnlock = 7,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "JS Back-End",
                CourseTypeId = javaScriptId,
                LevelToUnlock = 6,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "JS Application",
                CourseTypeId = javaScriptId,
                LevelToUnlock = 5,
            });

            dbContext.Courses.Add(new Course
            {
                Name = "JS Advanced",
                CourseTypeId = javaScriptId,
                LevelToUnlock = 4,
            });

            // C# Courses
            dbContext.Courses.Add(new Course
            {
                Name = "C# ASP.NET Core",
                CourseTypeId = csharpId,
                LevelToUnlock = 8,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "C# Web Basics",
                CourseTypeId = csharpId,
                LevelToUnlock = 7,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Entity Framework Core",
                CourseTypeId = csharpId,
                LevelToUnlock = 6,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "MS SQL",
                CourseTypeId = csharpId,
                LevelToUnlock = 6,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "C# OOP",
                CourseTypeId = csharpId,
                LevelToUnlock = 4,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "C# Advanced",
                CourseTypeId = csharpId,
                LevelToUnlock = 3,
            });

            // Basic courses
            dbContext.Courses.Add(new Course
            {
                Name = "Fundamental",
                CourseTypeId = basicId,
                LevelToUnlock = 2,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Programming Basic",
                CourseTypeId = basicId,
                LevelToUnlock = 1,
            });

            dbContext.SaveChanges();
        }
    }
}
