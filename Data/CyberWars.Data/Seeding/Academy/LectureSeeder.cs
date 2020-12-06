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

            // Basic Courses
            var programmingBasicId = dbContext.Courses.FirstOrDefault(x => x.Name == "Programming Basic").Id;
            var fundamentalId = dbContext.Courses.FirstOrDefault(x => x.Name == "Fundamental").Id;

            // C# Courses
            var csharpAdvancedId = dbContext.Courses.FirstOrDefault(x => x.Name == "C# Advanced").Id;
            var csharpOOPId = dbContext.Courses.FirstOrDefault(x => x.Name == "C# OOP").Id;
            var msSqlId = dbContext.Courses.FirstOrDefault(x => x.Name == "MS SQL").Id;
            var entityFrameworkCoreId = dbContext.Courses.FirstOrDefault(x => x.Name == "Entity Framework Core").Id;
            var csharpWebBasicId = dbContext.Courses.FirstOrDefault(x => x.Name == "C# Web Basics").Id;
            var aspNetCoreId = dbContext.Courses.FirstOrDefault(x => x.Name == "C# ASP.NET Core").Id;

            // Java Courses
            var javaAdvancedId = dbContext.Courses.FirstOrDefault(x => x.Name == "Java Advanced").Id;
            var javaOOPid = dbContext.Courses.FirstOrDefault(x => x.Name == "Java OOP").Id;
            var mySqlId = dbContext.Courses.FirstOrDefault(x => x.Name == "My SQL").Id;
            var springDataID = dbContext.Courses.FirstOrDefault(x => x.Name == "Spring Data").Id;
            var springFundamentalsId = dbContext.Courses.FirstOrDefault(x => x.Name == "Spring Fundamentals").Id;
            var springAdvancedId = dbContext.Courses.FirstOrDefault(x => x.Name == "Spring Advanced").Id;

            // JS Courses
            var jsAdvancedId = dbContext.Courses.FirstOrDefault(x => x.Name == "JS Advanced").Id;
            var jsApplicationId = dbContext.Courses.FirstOrDefault(x => x.Name == "JS Application").Id;
            var jsBackEndId = dbContext.Courses.FirstOrDefault(x => x.Name == "JS Back-End").Id;
            var reactJSId = dbContext.Courses.FirstOrDefault(x => x.Name == "React JS").Id;
            var htmlAndCssId = dbContext.Courses.FirstOrDefault(x => x.Name == "HTML & CSS").Id;
            var frontEndFrameworkId = dbContext.Courses.FirstOrDefault(x => x.Name == "Front-End Framework").Id;

            // Python Courses
            var pythonAdvancedId = dbContext.Courses.FirstOrDefault(x => x.Name == "Python Advanced").Id;
            var pythonOOPId = dbContext.Courses.FirstOrDefault(x => x.Name == "Python OOP").Id;
            var pythonWebBasicsId = dbContext.Courses.FirstOrDefault(x => x.Name == "Python Web Basics").Id;
            var pythonFrameworkId = dbContext.Courses.FirstOrDefault(x => x.Name == "Python Web Framework").Id;

            // Python Web Framework
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                ExperienceToComplete = 240,
                RewardAbilityName = "Django End",
                RewardMoney = 10000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Deployment",
                ExperienceToComplete = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Django Rest Framework",
                ExperienceToComplete = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "CBV'S",
                ExperienceToComplete = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "User Form Registration and Login",
                ExperienceToComplete = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Authentication",
                ExperienceToComplete = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Media Files",
                ExperienceToComplete = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Templates Advanced",
                ExperienceToComplete = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "PostgreSQL",
                ExperienceToComplete = 120,
                RewardAbilityName = "PostgreSQL End",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });

            // Python Web Basics Lectures

            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                ExperienceToComplete = 200,
                RewardAbilityName = "Django Exam",
                RewardMoney = 5000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Unit and Integration Testing",
                ExperienceToComplete = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Model Forms",
                ExperienceToComplete = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Forms",
                ExperienceToComplete = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Models and MTV Pattern",
                ExperienceToComplete = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Database Basics",
                ExperienceToComplete = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "HTTP Protocol",
                ExperienceToComplete = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "URL'S and Templates",
                ExperienceToComplete = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Introduction to Django",
                ExperienceToComplete = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });

            // Python OOP Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 12,
                Name = "Exam",
                ExperienceToComplete = 160,
                RewardAbilityName = "Python Exam",
                RewardMoney = 4000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Design Patterns",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Testing",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Decorators",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Iterators and Generators",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "SOLID",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Polymorphism and Magic Methods",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Inheritance",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Encapsulation",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Attributes and Methods",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Classes and Instances",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Defining Classes",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });


            // Python Advanced Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                ExperienceToComplete = 120,
                RewardAbilityName = "Python Exam",
                RewardMoney = 3000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Error Handling",
                ExperienceToComplete = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Modules",
                ExperienceToComplete = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "File Handling",
                ExperienceToComplete = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Functions Advanced",
                ExperienceToComplete = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Comprehension",
                ExperienceToComplete = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Multidimensional Lists",
                ExperienceToComplete = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Tuples and Sets",
                ExperienceToComplete = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Lists as Stacks and Queues",
                ExperienceToComplete = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });

            // Front-End Framework Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exam",
                ExperienceToComplete = 280,
                RewardAbilityName = "Angular End",
                RewardMoney = 10000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "State Management",
                ExperienceToComplete = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Pipes, Interceptors and Subject",
                ExperienceToComplete = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Forms",
                ExperienceToComplete = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Modules and Routing",
                ExperienceToComplete = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Di,Intro to RXJS,Services",
                ExperienceToComplete = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Components",
                ExperienceToComplete = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Intro to Angular and Typescript",
                ExperienceToComplete = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });

            // HTML & CSS Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exam",
                ExperienceToComplete = 240,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 7000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Media Queries",
                ExperienceToComplete = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Flexbox",
                ExperienceToComplete = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Position & Float",
                ExperienceToComplete = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "CSS Box Model",
                ExperienceToComplete = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "CSS & Typography",
                ExperienceToComplete = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "HTML Structure",
                ExperienceToComplete = 120,
                RewardAbilityName = "HTML End",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Introduction To HTML & CSS",
                ExperienceToComplete = 120,
                RewardAbilityName = "HTML End",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });

            // React Js Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                ExperienceToComplete = 240,
                RewardAbilityName = "React.JS Exam",
                RewardMoney = 6000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Advanced Techniques",
                ExperienceToComplete = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Authentication",
                ExperienceToComplete = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "React Hooks",
                ExperienceToComplete = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Forms",
                ExperienceToComplete = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Routing",
                ExperienceToComplete = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Components: Deep Dive",
                ExperienceToComplete = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Components: Basic Idea",
                ExperienceToComplete = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Intro to React and JSK",
                ExperienceToComplete = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });


            // JS Back-End
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exam",
                ExperienceToComplete = 200,
                RewardAbilityName = "JS Exam",
                RewardMoney = 5000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Rest API",
                ExperienceToComplete = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Validation and Error Handling",
                ExperienceToComplete = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Session and Authentication",
                ExperienceToComplete = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "NOSQL AND MongoDB",
                ExperienceToComplete = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "ExpressJs and Templating",
                ExperienceToComplete = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Node.Js Streams and Utilities",
                ExperienceToComplete = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Intro To Node.Js",
                ExperienceToComplete = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });

            // JS Application Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Exam",
                ExperienceToComplete = 160,
                RewardAbilityName = "JS Exam",
                RewardMoney = 4000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Project Arhitecture",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Custom Components",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Design Patterns and Best Practices",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Single Page Application",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Routing",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Templating",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Removete Databases",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Asynchronous Programming",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Rest Services and Ajax",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Unit Testing and Modules",
                ExperienceToComplete = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });

            // JS Advanced Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Exam",
                ExperienceToComplete = 120,
                RewardAbilityName = "JS Exam",
                RewardMoney = 3000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Prototypes and Inheritance",
                ExperienceToComplete = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Object Composition",
                ExperienceToComplete = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Advanced Functions",
                ExperienceToComplete = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Function Context",
                ExperienceToComplete = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "DOM Manipulations",
                ExperienceToComplete = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "DOM",
                ExperienceToComplete = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Objects & Classes",
                ExperienceToComplete = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Arrays",
                ExperienceToComplete = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Syntax, Functions and Statements",
                ExperienceToComplete = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });




            // Spring Advanced Lectures 
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Exam",
                ExperienceToComplete = 320,
                RewardAbilityName = "Spring Framework End",
                RewardMoney = 10000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Deployment, Hosting and Monitoring",
                ExperienceToComplete = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Reactive Programming with Webflux",
                ExperienceToComplete = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Unit and Intergration Testing",
                ExperienceToComplete = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Aspect Oriented Programming AOP",
                ExperienceToComplete = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Events",
                ExperienceToComplete = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Error Handling",
                ExperienceToComplete = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Hateoas",
                ExperienceToComplete = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Spring Security",
                ExperienceToComplete = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Web API and Rest Controllers",
                ExperienceToComplete = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });

            // Spring Fundamentals Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                ExperienceToComplete = 280,
                RewardAbilityName = "Spring Framework Exam",
                RewardMoney = 7000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Bootstrap,Front-End Basics",
                ExperienceToComplete = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Thymeleaf and Validations",
                ExperienceToComplete = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Spring Essentials",
                ExperienceToComplete = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Spring Introduction(MVC)",
                ExperienceToComplete = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Spring Boot Introduction",
                ExperienceToComplete = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "State Management",
                ExperienceToComplete = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "HTTP Protocol",
                ExperienceToComplete = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });

            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Internet Explained",
                ExperienceToComplete = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });

            // Spring Data Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Exam",
                ExperienceToComplete = 240,
                RewardAbilityName = "My SQL Exam",
                RewardMoney = 6000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "XML Processing",
                ExperienceToComplete = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "JSON Processing",
                ExperienceToComplete = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Spring Data Auto Mapping Objects",
                ExperienceToComplete = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Spring Data Advanced Quering",
                ExperienceToComplete = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Spring Data Intro",
                ExperienceToComplete = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Hibernate Code First",
                ExperienceToComplete = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Introduction to Hibernate",
                ExperienceToComplete = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "ORM Fundametals",
                ExperienceToComplete = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "DB Apps Introduction",
                ExperienceToComplete = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });

            // MY SQL
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                ExperienceToComplete = 200,
                RewardAbilityName = "My SQL Exam",
                RewardMoney = 5000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Database Programmability and Transactions",
                ExperienceToComplete = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Functions and Stored Procedures",
                ExperienceToComplete = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Indices and Data Aggregation",
                ExperienceToComplete = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Subqueries and Joins",
                ExperienceToComplete = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Build in Functions",
                ExperienceToComplete = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Table Ralations",
                ExperienceToComplete = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Basic CRUD",
                ExperienceToComplete = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Databases Introduction Data Definition and Datatypes",
                ExperienceToComplete = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });

            // Java OOP Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 13,
                Name = "Exam",
                ExperienceToComplete = 160,
                RewardAbilityName = "Java Exam",
                RewardMoney = 4000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 12,
                Name = "Design Patterns",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Test Driven Development",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Unit Testing",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Debugging Techniques",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exception and ErrorHandling",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Reflection and Annotation",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "SOLID",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Polymorhism",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Interface and Abstraction",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Encapsulation",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Inheritance",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Abstraction",
                ExperienceToComplete = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });

            // Java Advanced Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                ExperienceToComplete = 120,
                RewardAbilityName = "Java Exam",
                RewardMoney = 3000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Functional Programming",
                ExperienceToComplete = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Iterators and Comparator",
                ExperienceToComplete = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Generics",
                ExperienceToComplete = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Defining Classes",
                ExperienceToComplete = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Streams,Files and Directories",
                ExperienceToComplete = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Sets and Maps Advanced",
                ExperienceToComplete = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Multidemensional Arrays",
                ExperienceToComplete = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Stacks and Queues",
                ExperienceToComplete = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });

            // ASP.NET Core Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 13,
                Name = "Exam",
                ExperienceToComplete = 1800,
                RewardAbilityName = "ASP.NET Core End",
                RewardMoney = 10000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 12,
                Name = "Blazor",
                ExperienceToComplete = 1700,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Azure,Deployment & CI",
                ExperienceToComplete = 1650,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "SignalR",
                ExperienceToComplete = 1600,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Advanced Topics",
                ExperienceToComplete = 1550,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Project Arhitecture",
                ExperienceToComplete = 1500,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Testing",
                ExperienceToComplete = 1450,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Security and Identity",
                ExperienceToComplete = 1400,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Web API",
                ExperienceToComplete = 1350,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Working with Data",
                ExperienceToComplete = 1300,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Application Flow,Filters & Middleware",
                ExperienceToComplete = 1250,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Razor Views",
                ExperienceToComplete = 1200,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Asp.Net Core Introduction",
                ExperienceToComplete = 1150,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });

            // C# Web Basic Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Exam",
                ExperienceToComplete = 1100,
                RewardAbilityName = "ASP.NET Core Exam",
                RewardMoney = 7000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "MVC Advanced - IOC and Data Binding",
                ExperienceToComplete = 1080,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "MVC Advanced - View Engine",
                ExperienceToComplete = 1040,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "MVC Introduction",
                ExperienceToComplete = 1000,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Web-Server - State Management",
                ExperienceToComplete = 960,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Web-Server - Asynchronous Processing",
                ExperienceToComplete = 920,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Web-Server - HTTP Protocol",
                ExperienceToComplete = 880,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });

            // Entity FrameWork Core Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Exam",
                ExperienceToComplete = 840,
                RewardAbilityName = "MS SQL Exam",
                RewardMoney = 6000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "XML Processing",
                ExperienceToComplete = 820,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "JSON Processing",
                ExperienceToComplete = 800,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "C# Auto Mapper",
                ExperienceToComplete = 780,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Advanced Querying",
                ExperienceToComplete = 760,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "LINQ",
                ExperienceToComplete = 740,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Entity Relations",
                ExperienceToComplete = 720,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Entity Framework Introduction",
                ExperienceToComplete = 700,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "ORM Fundamentals",
                ExperienceToComplete = 680,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "ADO.NET",
                ExperienceToComplete = 660,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });

            // MS SQL
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                ExperienceToComplete = 640,
                RewardAbilityName = "MS SQL Exam",
                RewardMoney = 5000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Triggers and Transactions",
                ExperienceToComplete = 590,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Functions and Stored Procedures",
                ExperienceToComplete = 580,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Indices and Data Aggregation",
                ExperienceToComplete = 570,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Subqueries and Joins",
                ExperienceToComplete = 560,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Build in Functions",
                ExperienceToComplete = 550,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Table Ralations",
                ExperienceToComplete = 540,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "CRUD",
                ExperienceToComplete = 530,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Databases Introduction",
                ExperienceToComplete = 520,
                RewardAbilityName = "MS SQL",
                RewardMoney = 3000,
                CourseId = msSqlId,
            });

            // C# OOP
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Exam",
                ExperienceToComplete = 500,
                RewardAbilityName = "C# Exam",
                RewardMoney = 4000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Design Patterns Basics",
                ExperienceToComplete = 480,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Test Driven Development",
                ExperienceToComplete = 470,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exception and ErrorHandling",
                ExperienceToComplete = 460,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Reflection and Attributes",
                ExperienceToComplete = 450,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "SOLID",
                ExperienceToComplete = 440,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Polymorhism",
                ExperienceToComplete = 430,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Interface and Abstraction",
                ExperienceToComplete = 420,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Encapsulation",
                ExperienceToComplete = 410,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Inheritance",
                ExperienceToComplete = 400,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Abstraction",
                ExperienceToComplete = 390,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });

            // C# Advanced
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                ExperienceToComplete = 360,
                RewardAbilityName = "C# Exam",
                RewardMoney = 3000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Iterators and Comparator",
                ExperienceToComplete = 350,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Generics",
                ExperienceToComplete = 340,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Defining Classes",
                ExperienceToComplete = 330,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Functional Programming",
                ExperienceToComplete = 320,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Streams,Files and Directories",
                ExperienceToComplete = 310,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Sets and Dictionary Advanced",
                ExperienceToComplete = 300,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Multidemensional Arrays",
                ExperienceToComplete = 290,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Stacks and Queues",
                ExperienceToComplete = 280,
                RewardAbilityName = "C#",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });

            // Fundamental Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 18,
                Name = "Exam",
                ExperienceToComplete = 250,
                RewardAbilityName = "C# Exam",
                RewardMoney = 2000,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 17,
                Name = "Git and GitHub Basics",
                ExperienceToComplete = 240,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 16,
                Name = "Regular Expressions",
                ExperienceToComplete = 230,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 15,
                Name = "Databases Basics",
                ExperienceToComplete = 220,
                RewardAbilityName = "MS SQL",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 14,
                Name = "Text Processing",
                ExperienceToComplete = 210,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 13,
                Name = "Computer Science Basics",
                ExperienceToComplete = 200,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 12,
                Name = "Lambda Expressions and LINQ",
                ExperienceToComplete = 190,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Dictionary and SortedDictionary",
                ExperienceToComplete = 180,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Object and Classes",
                ExperienceToComplete = 170,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Bitwise Operation",
                ExperienceToComplete = 160,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "List",
                ExperienceToComplete = 150,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Problem Solving",
                ExperienceToComplete = 140,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "HTPP Basic",
                ExperienceToComplete = 130,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Methods",
                ExperienceToComplete = 120,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Basic CSS",
                ExperienceToComplete = 110,
                RewardAbilityName = "CSS",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Array",
                ExperienceToComplete = 100,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Basic HTML",
                ExperienceToComplete = 95,
                RewardAbilityName = "HTML",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Data Types and Variables",
                ExperienceToComplete = 90,
                RewardAbilityName = "C#",
                RewardMoney = 500,
                CourseId = fundamentalId,
            });

            // Programming Basic Lecture
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Exam",
                ExperienceToComplete = 70,
                RewardAbilityName = "C# Exam",
                RewardMoney = 1000,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Nested-Loop",
                ExperienceToComplete = 60,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "While-Loop",
                ExperienceToComplete = 50,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "For-Loop",
                ExperienceToComplete = 40,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Nested Conditional Statement",
                ExperienceToComplete = 30,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Conditional Statement",
                ExperienceToComplete = 20,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });

            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Variables and Data Types Basics",
                ExperienceToComplete = 10,
                RewardAbilityName = "C#",
                RewardMoney = 200,
                CourseId = programmingBasicId,
            });

            dbContext.SaveChanges();
        }
    }
}
