namespace CyberWars.Data.Seeding.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Threading.Tasks;
    using CyberWars.Data.Models.Course;

    public class LectureSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Lectures.Any())
            {
                return;
            }

            /*('ADO.NET',120,1,4000 ,4,6),
('ORM Fundamentals',120,1,4000 ,4,6),
('Entity Framework Introduction',120,1,4000 ,4,6),
('Entity Relations',120,1,4000 ,4,6),
('LINQ',120,1,4000 ,4,6),
('Advanced Querying',120,1,4000 ,4,6),
('C# Auto Mapper',120,1,4000 ,4,6),
('JSON Processing',120,1,4000 ,4,6),
('XML Processing',120,1,4000 ,4,6),
('Exam',240,3,5000 ,8,6),*/
            var programmingBasicId = dbContext.Courses.FirstOrDefault(x => x.Name == "Programming Basic").Id;
            var fundamentalId = dbContext.Courses.FirstOrDefault(x => x.Name == "Fundamental").Id;
            var csharpAdvancedId = dbContext.Courses.FirstOrDefault(x => x.Name == "C# Advanced").Id;
            var chasrpOOPId = dbContext.Courses.FirstOrDefault(x => x.Name == "C# OOP").Id;
            var msSqlId = dbContext.Courses.FirstOrDefault(x => x.Name == "MS SQL").Id;
            // var entityFrameworkCoreId = dbContext.Courses.FirstOrDefault(x => x.Name == "Entity Framework Core").Id;


            // Entity FrameWork Core Lectures


            //dbContext.Lectures.Add(new Lecture
            //{
            //    Name = "ADO.NET",
            //    TimeMinutes = 120,
            //    RewardAbilityPoints = 1,
            //    RewardMoney = 4000,
            //    CourseId = msSqlId,
            //});

            // MS SQL
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                TimeMinutes = 200,
                RewardAbilityName = "MS SQL Exam",
                RewardMoney = 5000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Triggers and Transactions",
                TimeMinutes = 100,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Functions and Stored Procedures",
                TimeMinutes = 100,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Indices and Data Aggregation",
                TimeMinutes = 100,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Subqueries and Joins",
                TimeMinutes = 100,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Build in Functions",
                TimeMinutes = 100,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Tabele Ralations",
                TimeMinutes = 100,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "CRUD",
                TimeMinutes = 100,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Databases Introduction",
                TimeMinutes = 100,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });

            // C# OOP
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Exam",
                TimeMinutes = 160,
                RewardAbilityName = "C# Exam",
                RewardMoney = 4000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Design Patterns Basics",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Test Driven Development",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exception and ErrorHandling",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Reflection and Attributes",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "SOLID",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number =5,
                Name = "Polymorhism",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Interface and Abstraction",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number =3,
                Name = "Encapsulation",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Inheritance",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Abstraction",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = chasrpOOPId,
            });

            // C# Advanced
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                TimeMinutes = 60,
                RewardAbilityName = "C# Exam",
                RewardMoney = 3000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Iterators and Comparator",
                TimeMinutes = 60,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Generics",
                TimeMinutes = 60,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Defining Classes",
                TimeMinutes = 60,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Functional Programming",
                TimeMinutes = 60,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Streams,Files and Directories",
                TimeMinutes = 60,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Sets and Dictionary Advanced",
                TimeMinutes = 60,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Multidemensional Arrays",
                TimeMinutes = 60,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Stacks and Queues",
                TimeMinutes = 60,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });

            // Fundamental Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 18,
                Name = "Exam",
                TimeMinutes = 120,
                RewardAbilityName = "C# Exam",
                RewardMoney = 2000,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 17,
                Name = "Git and GitHub Basics",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 16,
                Name = "Regular Expressions",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 15,
                Name = "Databases Basics",
                TimeMinutes = 40,
                RewardAbilityName = "MS SQL",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 14,
                Name = "Text Processing",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 13,
                Name = "Computer Science Basics",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 12,
                Name = "Lambda Expressions and LINQ",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Dictionary and SortedDictionary",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Object and Classes",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Bitwise Operation",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "List",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Problem Solving",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "HTPP Basic",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Methods",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Basic CSS",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Array",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Basic HTML",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Data Types and Variables",
                TimeMinutes = 40,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });

            // Programming Basci Lecture
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Exam",
                TimeMinutes = 60,
                RewardAbilityName = "C# Exam",
                RewardMoney = 1000,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Nested-Loop",
                TimeMinutes = 20,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "While-Loop",
                TimeMinutes = 20,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "For-Loop",
                TimeMinutes = 20,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Nested Conditional Statement",
                TimeMinutes = 20,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Conditional Statement",
                TimeMinutes = 20,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });

            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Variables and Data Types Basics",
                TimeMinutes = 20,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });

            dbContext.SaveChanges();
        }
    }
}
