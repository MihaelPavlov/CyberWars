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
                TimeMinutes = 240,
                RewardAbilityName = "Django End",
                RewardMoney = 10000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Deployment",
                TimeMinutes = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Django Rest Framework",
                TimeMinutes = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "CBV'S",
                TimeMinutes = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "User Form Registration and Login",
                TimeMinutes = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Authentication",
                TimeMinutes = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Media Files",
                TimeMinutes = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Templates Advanced",
                TimeMinutes = 120,
                RewardAbilityName = "Django",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "PostgreSQL",
                TimeMinutes = 120,
                RewardAbilityName = "PostgreSQL End",
                RewardMoney = 5000,
                CourseId = pythonFrameworkId,
            });

            // Python Web Basics Lectures

            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                TimeMinutes = 200,
                RewardAbilityName = "Django Exam",
                RewardMoney = 5000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Unit and Integration Testing",
                TimeMinutes = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Model Forms",
                TimeMinutes = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Forms",
                TimeMinutes = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Models and MTV Pattern",
                TimeMinutes = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Database Basics",
                TimeMinutes = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "HTTP Protocol",
                TimeMinutes = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "URL'S and Templates",
                TimeMinutes = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Introduction to Django",
                TimeMinutes = 100,
                RewardAbilityName = "Django",
                RewardMoney = 3000,
                CourseId = pythonWebBasicsId,
            });

            // Python OOP Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 12,
                Name = "Exam",
                TimeMinutes = 160,
                RewardAbilityName = "Python Exam",
                RewardMoney = 4000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Design Patterns",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Testing",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Decorators",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Iterators and Generators",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "SOLID",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Polymorphism and Magic Methods",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Inheritance",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Encapsulation",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Attributes and Methods",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Classes and Instances",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Defining Classes",
                TimeMinutes = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });


            // Python Advanced Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                TimeMinutes = 120,
                RewardAbilityName = "Python Exam",
                RewardMoney = 3000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Error Handling",
                TimeMinutes = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Modules",
                TimeMinutes = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "File Handling",
                TimeMinutes = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Functions Advanced",
                TimeMinutes = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Comprehension",
                TimeMinutes = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Multidimensional Lists",
                TimeMinutes = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Tuples and Sets",
                TimeMinutes = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Lists as Stacks and Queues",
                TimeMinutes = 60,
                RewardAbilityName = "Python",
                RewardMoney = 1000,
                CourseId = pythonAdvancedId,
            });

            // Front-End Framework Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exam",
                TimeMinutes = 280,
                RewardAbilityName = "Angular End",
                RewardMoney = 10000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "State Management",
                TimeMinutes = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Pipes, Interceptors and Subject",
                TimeMinutes = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Forms",
                TimeMinutes = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Modules and Routing",
                TimeMinutes = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Di,Intro to RXJS,Services",
                TimeMinutes = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Components",
                TimeMinutes = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Intro to Angular and Typescript",
                TimeMinutes = 140,
                RewardAbilityName = "Angular",
                RewardMoney = 6000,
                CourseId = frontEndFrameworkId,
            });

            // HTML & CSS Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exam",
                TimeMinutes = 240,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 7000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Media Queries",
                TimeMinutes = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Flexbox",
                TimeMinutes = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Position & Float",
                TimeMinutes = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "CSS Box Model",
                TimeMinutes = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "CSS & Typography",
                TimeMinutes = 120,
                RewardAbilityName = "CSS Exam",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "HTML Structure",
                TimeMinutes = 120,
                RewardAbilityName = "HTML End",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Introduction To HTML & CSS",
                TimeMinutes = 120,
                RewardAbilityName = "HTML End",
                RewardMoney = 5000,
                CourseId = htmlAndCssId,
            });

            // React Js Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                TimeMinutes = 240,
                RewardAbilityName = "React.JS Exam",
                RewardMoney = 6000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Advanced Techniques",
                TimeMinutes = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Authentication",
                TimeMinutes = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "React Hooks",
                TimeMinutes = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Forms",
                TimeMinutes = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Routing",
                TimeMinutes = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Components: Deep Dive",
                TimeMinutes = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Components: Basic Idea",
                TimeMinutes = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Intro to React and JSK",
                TimeMinutes = 120,
                RewardAbilityName = "React.JS",
                RewardMoney = 4000,
                CourseId = reactJSId,
            });


            // JS Back-End
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exam",
                TimeMinutes = 200,
                RewardAbilityName = "JS Exam",
                RewardMoney = 5000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Rest API",
                TimeMinutes = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Validation and Error Handling",
                TimeMinutes = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Session and Authentication",
                TimeMinutes = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "NOSQL AND MongoDB",
                TimeMinutes = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "ExpressJs and Templating",
                TimeMinutes = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Node.Js Streams and Utilities",
                TimeMinutes = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Intro To Node.Js",
                TimeMinutes = 100,
                RewardAbilityName = "JS",
                RewardMoney = 3000,
                CourseId = jsBackEndId,
            });

            // JS Application Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Exam",
                TimeMinutes = 160,
                RewardAbilityName = "JS Exam",
                RewardMoney = 4000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Project Arhitecture",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Custom Components",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Design Patterns and Best Practices",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Single Page Application",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Routing",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Templating",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Removete Databases",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Asynchronous Programming",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Rest Services and Ajax",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Unit Testing and Modules",
                TimeMinutes = 80,
                RewardAbilityName = "JS",
                RewardMoney = 2000,
                CourseId = jsApplicationId,
            });

            // JS Advanced Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Exam",
                TimeMinutes = 120,
                RewardAbilityName = "JS Exam",
                RewardMoney = 3000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Prototypes and Inheritance",
                TimeMinutes = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Object Composition",
                TimeMinutes = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Advanced Functions",
                TimeMinutes = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Function Context",
                TimeMinutes = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "DOM Manipulations",
                TimeMinutes = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "DOM",
                TimeMinutes = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Objects & Classes",
                TimeMinutes = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Arrays",
                TimeMinutes = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Syntax, Functions and Statements",
                TimeMinutes = 60,
                RewardAbilityName = "JS",
                RewardMoney = 1000,
                CourseId = jsAdvancedId,
            });




            // Spring Advanced Lectures 
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Exam",
                TimeMinutes = 320,
                RewardAbilityName = "Spring Framework End",
                RewardMoney = 10000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Deployment, Hosting and Monitoring",
                TimeMinutes = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Reactive Programming with Webflux",
                TimeMinutes = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Unit and Intergration Testing",
                TimeMinutes = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Aspect Oriented Programming AOP",
                TimeMinutes = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Events",
                TimeMinutes = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Error Handling",
                TimeMinutes = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Hateoas",
                TimeMinutes = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Spring Security",
                TimeMinutes = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Web API and Rest Controllers",
                TimeMinutes = 160,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 6000,
                CourseId = springAdvancedId,
            });

            // Spring Fundamentals Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                TimeMinutes = 280,
                RewardAbilityName = "Spring Framework Exam",
                RewardMoney = 7000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Bootstrap,Front-End Basics",
                TimeMinutes = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Thymeleaf and Validations",
                TimeMinutes = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Spring Essentials",
                TimeMinutes = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Spring Introduction(MVC)",
                TimeMinutes = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Spring Boot Introduction",
                TimeMinutes = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "State Management",
                TimeMinutes = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "HTTP Protocol",
                TimeMinutes = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });

            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Internet Explained",
                TimeMinutes = 140,
                RewardAbilityName = "Spring Framework",
                RewardMoney = 5000,
                CourseId = springFundamentalsId,
            });

            // Spring Data Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Exam",
                TimeMinutes = 240,
                RewardAbilityName = "My SQL Exam",
                RewardMoney = 6000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "XML Processing",
                TimeMinutes = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "JSON Processing",
                TimeMinutes = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Spring Data Auto Mapping Objects",
                TimeMinutes = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Spring Data Advanced Quering",
                TimeMinutes = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Spring Data Intro",
                TimeMinutes = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Hibernate Code First",
                TimeMinutes = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Introduction to Hibernate",
                TimeMinutes = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "ORM Fundametals",
                TimeMinutes = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "DB Apps Introduction",
                TimeMinutes = 120,
                RewardAbilityName = "My SQL",
                RewardMoney = 4000,
                CourseId = springDataID,
            });

            // MY SQL
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                TimeMinutes = 200,
                RewardAbilityName = "My SQL Exam",
                RewardMoney = 5000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Database Programmability and Transactions",
                TimeMinutes = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Functions and Stored Procedures",
                TimeMinutes = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Indices and Data Aggregation",
                TimeMinutes = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Subqueries and Joins",
                TimeMinutes = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Build in Functions",
                TimeMinutes = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Table Ralations",
                TimeMinutes = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Basic CRUD",
                TimeMinutes = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Databases Introduction Data Definition and Datatypes",
                TimeMinutes = 100,
                RewardAbilityName = "My SQL",
                RewardMoney = 3000,
                CourseId = mySqlId,
            });

            // Java OOP Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 13,
                Name = "Exam",
                TimeMinutes = 160,
                RewardAbilityName = "Java Exam",
                RewardMoney = 4000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 12,
                Name = "Design Patterns",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Test Driven Development",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Unit Testing",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Debugging Techniques",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exception and ErrorHandling",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Reflection and Annotation",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "SOLID",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Polymorhism",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Interface and Abstraction",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Encapsulation",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Inheritance",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Abstraction",
                TimeMinutes = 80,
                RewardAbilityName = "Java",
                RewardMoney = 2000,
                CourseId = javaOOPid,
            });

            // Java Advanced Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                TimeMinutes = 120,
                RewardAbilityName = "Java Exam",
                RewardMoney = 3000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Functional Programming",
                TimeMinutes = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Iterators and Comparator",
                TimeMinutes = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Generics",
                TimeMinutes = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Defining Classes",
                TimeMinutes = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Streams,Files and Directories",
                TimeMinutes = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Sets and Maps Advanced",
                TimeMinutes = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Multidemensional Arrays",
                TimeMinutes = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = csharpAdvancedId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Stacks and Queues",
                TimeMinutes = 60,
                RewardAbilityName = "Java",
                RewardMoney = 1000,
                CourseId = javaAdvancedId,
            });

            // ASP.NET Core Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 13,
                Name = "Exam",
                TimeMinutes = 320,
                RewardAbilityName = "ASP.NET Core End",
                RewardMoney = 10000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 12,
                Name = "Blazor",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 11,
                Name = "Azure,Deployment & CI",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "SignalR",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Advanced Topics",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Project Arhitecture",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Testing",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Security and Identity",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Web API",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Working with Data",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Application Flow,Filters & Middleware",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Razor Views",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Asp.Net Core Introduction",
                TimeMinutes = 160,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 6000,
                CourseId = aspNetCoreId,
            });

            // C# Web Basic Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Exam",
                TimeMinutes = 280,
                RewardAbilityName = "ASP.NET Core Exam",
                RewardMoney = 7000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "MVC Advanced - IOC and Data Binding",
                TimeMinutes = 140,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "MVC Advanced - View Engine",
                TimeMinutes = 140,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "MVC Introduction",
                TimeMinutes = 140,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Web-Server - State Management",
                TimeMinutes = 140,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Web-Server - Asynchronous Processing",
                TimeMinutes = 140,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Web-Server - HTTP Protocol",
                TimeMinutes = 140,
                RewardAbilityName = "ASP.NET Core",
                RewardMoney = 5000,
                CourseId = csharpWebBasicId,
            });

            // Entity FrameWork Core Lectures
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Exam",
                TimeMinutes = 240,
                RewardAbilityName = "MS SQL Exam",
                RewardMoney = 6000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "XML Processing",
                TimeMinutes = 120,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "JSON Processing",
                TimeMinutes = 120,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "C# Auto Mapper",
                TimeMinutes = 120,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "Advanced Querying",
                TimeMinutes = 120,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "LINQ",
                TimeMinutes = 120,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Entity Relations",
                TimeMinutes = 120,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Entity Framework Introduction",
                TimeMinutes = 120,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "ORM Fundamentals",
                TimeMinutes = 120,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "ADO.NET",
                TimeMinutes = 120,
                RewardAbilityName = "MS SQL",
                RewardMoney = 4000,
                CourseId = entityFrameworkCoreId,
            });

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
                Name = "Table Ralations",
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
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 10,
                Name = "Design Patterns Basics",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Test Driven Development",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 8,
                Name = "Exception and ErrorHandling",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 7,
                Name = "Reflection and Attributes",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 6,
                Name = "SOLID",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 5,
                Name = "Polymorhism",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 4,
                Name = "Interface and Abstraction",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 3,
                Name = "Encapsulation",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 2,
                Name = "Inheritance",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });
            dbContext.Lectures.Add(new Lecture
            {
                Number = 1,
                Name = "Abstraction",
                TimeMinutes = 80,
                RewardAbilityName = "C#",
                RewardMoney = 2000,
                CourseId = csharpOOPId,
            });

            // C# Advanced
            dbContext.Lectures.Add(new Lecture
            {
                Number = 9,
                Name = "Exam",
                TimeMinutes = 120,
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
