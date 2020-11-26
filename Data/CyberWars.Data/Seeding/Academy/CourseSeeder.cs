namespace CyberWars.Data.Seeding.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
            });

            dbContext.Courses.Add(new Course
            {
                Name = "Python Web Basics",
                CourseTypeId = pythonId,
            });

            dbContext.Courses.Add(new Course
            {
                Name = "Python OOP",
                CourseTypeId = pythonId,
            });

            dbContext.Courses.Add(new Course
            {
                Name = "Python Advanced",
                CourseTypeId = pythonId,
            });

            // Java Courses
            dbContext.Courses.Add(new Course
            {
                Name = "Java Spring.MVC",
                CourseTypeId = javaId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Java Web Basics",
                CourseTypeId = javaId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Spring Data",
                CourseTypeId = javaId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "My SQL",
                CourseTypeId = javaId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Java OOP",
                CourseTypeId = javaId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Java Advanced",
                CourseTypeId = javaId,
            });

            // Js Courses

            dbContext.Courses.Add(new Course
            {
                Name = "Front-End Framework",
                CourseTypeId = javaScriptId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "HTML & CSS",
                CourseTypeId = javaScriptId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "React JS",
                CourseTypeId = javaScriptId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "JS Back-End",
                CourseTypeId = javaScriptId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "JS Application",
                CourseTypeId = javaScriptId,
            });

            dbContext.Courses.Add(new Course
            {
                Name = "JS Advanced",
                CourseTypeId = javaScriptId,
            });

            // C# Courses
            dbContext.Courses.Add(new Course
            {
                Name = "C# ASP.NET Core",
                CourseTypeId = csharpId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "C# Web Basics",
                CourseTypeId = csharpId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Entity Framework Core",
                CourseTypeId = csharpId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "MS SQL",
                CourseTypeId = csharpId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "C# OOP",
                CourseTypeId = csharpId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "C# Advanced",
                CourseTypeId = csharpId,
            });

            // Basic courses
            dbContext.Courses.Add(new Course
            {
                Name = "Fundamental",
                CourseTypeId = basicId,
            });
            dbContext.Courses.Add(new Course
            {
                Name = "Programming Basic",
                CourseTypeId = basicId,
            });

            dbContext.SaveChanges();
        }
    }
}
