namespace CyberWars.Data.Seeding.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Ability;

    public class AbilitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Abilities.Any())
            {
                return;
            }

            // Ability type -> Languages
            dbContext.Abilities.Add(new Ability
            {
                Name = "C#",
                Description = "Develop by Microsoft , Structured,Object-Oriented,Functional Language and more",
                AbilityTypeId = 1,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "JS",
                Description = "Script Language .Write By Student",
                AbilityTypeId = 1,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "Java",
                Description = "Develop by Oracle Corparation ,Design by James Cosling",
                AbilityTypeId = 1,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "Python",
                Description = "Develop by Python Software Foundation",
                AbilityTypeId = 1,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "HTML",
                Description = "Hyper Text Markup Language",
                AbilityTypeId = 1,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "CSS",
                Description = "Cascade Style Sheets",
                AbilityTypeId = 1,
            });

            // AbilityT Type -> Database
            dbContext.Abilities.Add(new Ability
            {
                Name = "MySQL",
                Description = "Developed by Oracle, MySQL Database Software is a client/server system",
                AbilityTypeId = 2,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "PostgreSQL",
                Description = "PostgreSQL is a powerful, open-source object-relational database system",
                AbilityTypeId = 2,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "MSSQL",
                Description = "SQL Server is a relational database management system developed by Microsoft",
                AbilityTypeId = 2,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "SQLite",
                Description = "SQLite is an in-process library that implements a self-contained, serverless, zero-configuration, transactional SQL database engine",
                AbilityTypeId = 2,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "MongoDB",
                Description = "MongoDB is a general-purpose, document-based, distributed database built for modern application developers and for the cloud era",
                AbilityTypeId = 2,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "Oracle",
                Description = "Oracle Database is a multi-model database management system to run all of the workloads more securely",
                AbilityTypeId = 2,
            });

            // Ability type -> Frameworks
            dbContext.Abilities.Add(new Ability
            {
                Name = "ASP.NETCore",
                Description = "ASP.NET Core is designed to allow runtime components, APIs, compilers and languages while providing a stable and supported platform to keep apps running",
                AbilityTypeId = 3,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "SpringFramework",
                Description = "The Spring Framework provides a comprehensive programming and configuration model for modern Java-based enterprise applications",
                AbilityTypeId = 3,
            });
            dbContext.Abilities.Add(new Ability
            {
                Name = "Django",
                Description = "Django is a high-level Python Web framework that encourages rapid development and clean, pragmatic design.",
                AbilityTypeId = 3,
            });
            dbContext.Abilities.Add(new Ability
            {
                Name = "Vue.JS",
                Description = "Vue.js is a popular JavaScript framework which achieved the 7th position at the Stack Overflow Developer Survey 2020 as the most used web framework",
                AbilityTypeId = 3,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "React.JS",
                Description = "React is a popular JavaScript library for building user interfaces",
                AbilityTypeId = 3,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "Angular",
                Description = "Angular is a TypeScript-based open-source web application framework which can be used for building mobile and desktop web applications using TypeScript or JavaScript and other programming languages",
                AbilityTypeId = 3,
            });

            dbContext.Abilities.Add(new Ability
            {
                Name = "RubyOnRails",
                Description = "Ruby on Rails is a web-application framework written in Ruby language. The framework includes everything needed to create database-backed web applications according to the Model-View-Controller (MVC) pattern",
                AbilityTypeId = 3,
            });

            dbContext.SaveChanges();
        }
    }
}
