namespace CyberWars.Services.Data.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Badge;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Job;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Data.Models.Teams;
    using CyberWars.Data.Repositories;
    using CyberWars.Services.Data.Academy;
    using CyberWars.Services.Data.Home;
    using CyberWars.Services.Data.Tests.Helpers.TestViewModel;
    using CyberWars.Services.Data.Tests.Helpers.TestViewModel.WebViewModel;
    using CyberWars.Services.Data.Web;
    using CyberWars.Services.Mapping;
    using CyberWars.Web.ViewModels.HomeViews;
    using Microsoft.EntityFrameworkCore;

    public static class TestDataHelpers
    {
        public static async Task<HomeService> GetHomeService()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

            var playerRepositoryInMemory = new EfDeletableEntityRepository<Player>(new ApplicationDbContext(options.Options));
            var playerSkillRepositoryInMemory = new EfDeletableEntityRepository<PlayerSkill>(new ApplicationDbContext(options.Options));
            var playerAbilitiesRepositoryInMemory = new EfDeletableEntityRepository<PlayerAbility>(new ApplicationDbContext(options.Options));
            var abilityTypeRepositoryInMemory = new EfDeletableEntityRepository<AbilityType>(new ApplicationDbContext(options.Options));
            var abilitiesRepositoryInMemory = new EfDeletableEntityRepository<Ability>(new ApplicationDbContext(options.Options));
            var userRepositoryInMemory = new EfDeletableEntityRepository<ApplicationUser>(new ApplicationDbContext(options.Options));
            var badgeRepositoryInMemory = new EfDeletableEntityRepository<Badge>(new ApplicationDbContext(options.Options));
            var badgeRequirementsRepositoryInMemory = new EfDeletableEntityRepository<BadgeRequirement>(new ApplicationDbContext(options.Options));
            var requirementsRepositoryInMemory = new EfDeletableEntityRepository<Requirement>(new ApplicationDbContext(options.Options));
            var playerPetRepositoryInMemory = new EfDeletableEntityRepository<PlayerPet>(new ApplicationDbContext(options.Options));
            var foodRepositoryInMemory = new EfDeletableEntityRepository<Food>(new ApplicationDbContext(options.Options));
            var petRepositoryInMemory = new EfDeletableEntityRepository<Pet>(new ApplicationDbContext(options.Options));
            var playerFoodRepositoryInMemory = new EfDeletableEntityRepository<PlayerFood>(new ApplicationDbContext(options.Options));
            var battleRecordRepositoryInMemory = new EfDeletableEntityRepository<BattleRecord>(new ApplicationDbContext(options.Options));
            var skillRepositoryInMemory = new EfDeletableEntityRepository<Skill>(new ApplicationDbContext(options.Options));
            var randomHangfireFoodRepositoryInMemory = new EfDeletableEntityRepository<RandomHangfireFood>(new ApplicationDbContext(options.Options));
            var playerBadgeRepositoryInMemory = new EfDeletableEntityRepository<PlayerBadge>(new ApplicationDbContext(options.Options));
            var teamPlayerRepositoryInMemory = new EfDeletableEntityRepository<TeamPlayer>(new ApplicationDbContext(options.Options));
            var teamRepositoryInMemory = new EfDeletableEntityRepository<CyberWars.Data.Models.Teams.Team>(new ApplicationDbContext(options.Options));

            var player = new Player
            {
                Name = "PlayerPesho",
                Money = 1000,
                UserId = "Pesho",
                Class = "Programmer",
                MaxHealth = 1000,
                MaxEnergy = 100,
            };

            var player1 = new Player
            {
                Name = "PlayerTest",
                Money = 1000,
                UserId = "Test",
                Class = "Programmer",
                MaxHealth = 1000,
                MaxEnergy = 100,
            };

            await playerRepositoryInMemory.AddAsync(player);
            await playerRepositoryInMemory.AddAsync(player1);

            await playerRepositoryInMemory.SaveChangesAsync();

            var user = new ApplicationUser
            {
                UserName = "Test",
                Id = "Pesho",
                PlayerId = player.Id,
                Email = "Test@abv.bg",
            };
            var user1 = new ApplicationUser
            {
                UserName = "Test1",
                Id = "Test",
                PlayerId = player1.Id,
                Email = "Test@abv.bg",
            };
            await userRepositoryInMemory.AddAsync(user);
            await userRepositoryInMemory.AddAsync(user1);

            await userRepositoryInMemory.SaveChangesAsync();

            await skillRepositoryInMemory.AddAsync(new Skill
            {
                Name = "Firewall Defence",
                Description = "Increase the chanse to defence from attacks",
                StartMoney = 120,
            });

            await skillRepositoryInMemory.AddAsync(new Skill
            {
                Name = "Motivation",
                Description = "Motivation is the reason for people's action",
                StartMoney = 120,
            });
            await skillRepositoryInMemory.AddAsync(new Skill
            {
                Name = "Cunning",
                Description = "Enhances the money of perBattle + 5",
                StartMoney = 120,
            });
            await skillRepositoryInMemory.AddAsync(new Skill
            {
                Name = "Staying Power",
                Description = "Increase the energy + 5",
                StartMoney = 120,
            });
            var skill = new Skill
            {
                Name = "Health",
                Description = "Affects the amount of life + 10",
                StartMoney = 120,
            };
            await skillRepositoryInMemory.AddAsync(skill);
            await skillRepositoryInMemory.SaveChangesAsync();

            var battleRecord = new BattleRecord
            {
                Losses = 0,
                Wins = 0,
                PlayerId = player.Id,
                StealPerBattle = 50,
                StolenMoney = 0,
            };

            await battleRecordRepositoryInMemory.AddAsync(battleRecord);
            await battleRecordRepositoryInMemory.SaveChangesAsync();


            foreach (var skillInMemory in skillRepositoryInMemory.All())
            {
                await playerSkillRepositoryInMemory.AddAsync(new PlayerSkill
                {
                    PlayerId = player.Id,
                    SkillId = skillInMemory.Id,
                    Points = 1,
                    Money = 0,
                });
            }

            foreach (var skillInMemory in skillRepositoryInMemory.All())
            {
                await playerSkillRepositoryInMemory.AddAsync(new PlayerSkill
                {
                    PlayerId = player1.Id,
                    SkillId = skillInMemory.Id,
                    Points = 1,
                    Money = 0,
                });
            }

            await playerSkillRepositoryInMemory.SaveChangesAsync();


            await abilityTypeRepositoryInMemory.AddAsync(new AbilityType
            {
                Id = 3,
                Type = "Frameworks",
            });

            await abilityTypeRepositoryInMemory.AddAsync(new AbilityType
            {
                Id = 2,
                Type = "Database",
            });

            await abilityTypeRepositoryInMemory.AddAsync(new AbilityType
            {
                Id = 1,
                Type = "Languages",
            });

            await abilityTypeRepositoryInMemory.SaveChangesAsync();

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "C#",
                Description = "Develop by Microsoft , Structured,Object-Oriented,Functional Language and more",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "JS",
                Description = "Script Language .Write By Student",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Java",
                Description = "Develop by Oracle Corparation ,Design by James Cosling",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Python",
                Description = "Develop by Python Software Foundation",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "HTML",
                Description = "Hyper Text Markup Language",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "CSS",
                Description = "Cascade Style Sheets",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "MySQL",
                Description = "Developed by Oracle, MySQL Database Software is a client/server system",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "PostgreSQL",
                Description = "PostgreSQL is a powerful, open-source object-relational database system",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "MSSQL",
                Description = "SQL Server is a relational database management system developed by Microsoft",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "SQLite",
                Description = "SQLite is an in-process library that implements a self-contained, serverless, zero-configuration, transactional SQL database engine",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "MongoDB",
                Description = "MongoDB is a general-purpose, document-based, distributed database built for modern application developers and for the cloud era",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Oracle",
                Description = "Oracle Database is a multi-model database management system to run all of the workloads more securely",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "ASP.NETCore",
                Description = "ASP.NET Core is designed to allow runtime components, APIs, compilers and languages while providing a stable and supported platform to keep apps running",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "SpringFramework",
                Description = "The Spring Framework provides a comprehensive programming and configuration model for modern Java-based enterprise applications",
                AbilityTypeId = 3,
            });
            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Django",
                Description = "Django is a high-level Python Web framework that encourages rapid development and clean, pragmatic design.",
                AbilityTypeId = 3,
            });
            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Vue.JS",
                Description = "Vue.js is a popular JavaScript framework which achieved the 7th position at the Stack Overflow Developer Survey 2020 as the most used web framework",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "React.JS",
                Description = "React is a popular JavaScript library for building user interfaces",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Angular",
                Description = "Angular is a TypeScript-based open-source web application framework which can be used for building mobile and desktop web applications using TypeScript or JavaScript and other programming languages",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "RubyOnRails",
                Description = "Ruby on Rails is a web-application framework written in Ruby language. The framework includes everything needed to create database-backed web applications according to the Model-View-Controller (MVC) pattern",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.SaveChangesAsync();

            foreach (var ability in abilitiesRepositoryInMemory.All())
            {
                await playerAbilitiesRepositoryInMemory.AddAsync(new PlayerAbility
                {
                    PlayerId = player.Id,
                    AbilityId = ability.Id,
                    Points = 0,
                });
            }

            await playerAbilitiesRepositoryInMemory.SaveChangesAsync();

            await badgeRepositoryInMemory.AddAsync(new Badge
            {
                Id = 3,
                Name = "Mid Developer",
                ImageName = "03.MidDeveloper",
                Description = "You receive this badge when you have already gained solid knowledge.",
            });

            await badgeRepositoryInMemory.AddAsync(new Badge
            {
                Id = 2,
                Name = "Junior Developer",
                ImageName = "02.JuniorDeveloper",
                Description = "A badge that marks the start of your career!",
            });
            await badgeRepositoryInMemory.AddAsync(new Badge
            {
                Id = 1,
                Name = "Student Developer",
                ImageName = "01.StudentDeveloper",
                Description = "The holder of this badge is the Best Student!",
            });

            await badgeRepositoryInMemory.SaveChangesAsync();

            foreach (var ability in abilitiesRepositoryInMemory.All())
            {
                for (int i = 5; i <= 100; i += 5)
                {
                    await requirementsRepositoryInMemory.AddAsync(new Requirement
                    {
                        Name = ability.Name,
                        Points = i,
                        AbilityId = ability.Id,
                    });
                }
            }

            await requirementsRepositoryInMemory.SaveChangesAsync();

            // Student Developer Badge
            await badgeRequirementsRepositoryInMemory.AddAsync(new BadgeRequirement
            {
                BadgeId = 1,
                RequirementId = 7,
            });

            await badgeRequirementsRepositoryInMemory.AddAsync(new BadgeRequirement
            {
                BadgeId = 1,
                RequirementId = 6,
            });

            await badgeRequirementsRepositoryInMemory.AddAsync(new BadgeRequirement
            {
                BadgeId = 1,
                RequirementId = 5,
            });

            await badgeRequirementsRepositoryInMemory.AddAsync(new BadgeRequirement
            {
                BadgeId = 1,
                RequirementId = 10,
            });

            await badgeRequirementsRepositoryInMemory.SaveChangesAsync();


            await petRepositoryInMemory.AddAsync(new Pet
            {
                Id = 2,
                Name = "Dog",
                ImageName = "Dog",
                Price = 1500.00M,
                Description = "Your Best Friend",
                LevelRequirement = 4,
            });

            await petRepositoryInMemory.AddAsync(new Pet
            {
                Id = 1,
                Name = "Cat",
                ImageName = "Cat",
                Price = 200.00M,
                Description = "The Cutes Cat in the world.",
                LevelRequirement = 2,
            });

            await petRepositoryInMemory.SaveChangesAsync();

            await playerPetRepositoryInMemory.AddAsync(new PlayerPet
            {
                PetId = 1,
                PlayerId = player.Id,
                Health = 80,
                MaxHealth = 100,
                Mood = 50,
                MaxMood = 100,
                NameIt = "TestPet",
            });

            await playerPetRepositoryInMemory.SaveChangesAsync();

            await foodRepositoryInMemory.AddAsync(new Food
            {
                Id = 3,
                Name = "Food +30",
                GainHealth = 30,
                GainExp = 40,
                LevelRequirement = 3,
                Price = 70.00M,
                ImageName = "Food3",
                Description = "No",
            });

            await foodRepositoryInMemory.AddAsync(new Food
            {
                Id = 2,
                Name = "Food +20",
                GainHealth = 20,
                GainExp = 40,
                LevelRequirement = 3,
                Price = 70.00M,
                ImageName = "Food2",
                Description = "No",
            });

            await foodRepositoryInMemory.AddAsync(new Food
            {
                Id = 1,
                Name = "Food +15",
                GainHealth = 15,
                GainExp = 20,
                LevelRequirement = 2,
                Price = 50.00M,
                ImageName = "Food1",
                Description = "No",
            });

            await foodRepositoryInMemory.SaveChangesAsync();

            await randomHangfireFoodRepositoryInMemory.AddAsync(new RandomHangfireFood
            {
                PetId = 1,
                FoodId = 1,
            });

            await randomHangfireFoodRepositoryInMemory.AddAsync(new RandomHangfireFood
            {
                PetId = 1,
                FoodId = 2,
            });

            await randomHangfireFoodRepositoryInMemory.SaveChangesAsync();

            await playerFoodRepositoryInMemory.AddAsync(new PlayerFood
            {
                PlayerId = player.Id,
                FoodId = 1,
                Quantity = 2,
            });

            await playerFoodRepositoryInMemory.AddAsync(new PlayerFood
            {
                PlayerId = player.Id,
                FoodId = 3,
                Quantity = 2,
            });
            await playerFoodRepositoryInMemory.SaveChangesAsync();


            var requirement7 = await requirementsRepositoryInMemory.All().FirstOrDefaultAsync(x => x.Id == 7);
            var requirement6 = await requirementsRepositoryInMemory.All().FirstOrDefaultAsync(x => x.Id == 6);
            var requirement5 = await requirementsRepositoryInMemory.All().FirstOrDefaultAsync(x => x.Id == 5);
            var requirement10 = await requirementsRepositoryInMemory.All().FirstOrDefaultAsync(x => x.Id == 10);

            var abilitiy7 = await playerAbilitiesRepositoryInMemory.All().FirstOrDefaultAsync(x => x.AbilityId == requirement7.AbilityId);
            abilitiy7.Points = requirement7.Points;

            playerAbilitiesRepositoryInMemory.Update(abilitiy7);

            var abilitiy6 = await playerAbilitiesRepositoryInMemory.All().FirstOrDefaultAsync(x => x.AbilityId == requirement6.AbilityId);
            abilitiy6.Points = requirement6.Points;

            playerAbilitiesRepositoryInMemory.Update(abilitiy6);

            var abilitiy5 = await playerAbilitiesRepositoryInMemory.All().FirstOrDefaultAsync(x => x.AbilityId == requirement5.AbilityId);
            abilitiy5.Points = requirement5.Points;

            playerAbilitiesRepositoryInMemory.Update(abilitiy5);

            var abilitiy10 = await playerAbilitiesRepositoryInMemory.All().FirstOrDefaultAsync(x => x.AbilityId == requirement10.AbilityId);
            abilitiy10.Points = requirement10.Points;

            playerAbilitiesRepositoryInMemory.Update(abilitiy10);

            AutoMapperConfig.RegisterMappings(typeof(TestPlayerSkillViewModel).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(TestPlayerAbilityViewModel).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(TestBadgeViewModel).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(TestBagdeRequirementsViewModel).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(TestPlayerPetViewModel).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(TestFoodViewModel).Assembly);

            var homeService = new HomeService(
                playerRepositoryInMemory,
                playerSkillRepositoryInMemory,
                playerAbilitiesRepositoryInMemory,
                userRepositoryInMemory,
                badgeRepositoryInMemory,
                badgeRequirementsRepositoryInMemory,
                playerPetRepositoryInMemory,
                foodRepositoryInMemory,
                petRepositoryInMemory,
                playerFoodRepositoryInMemory,
                battleRecordRepositoryInMemory,
                skillRepositoryInMemory,
                randomHangfireFoodRepositoryInMemory,
                playerBadgeRepositoryInMemory,
                teamPlayerRepositoryInMemory,
                teamRepositoryInMemory);

            return homeService;

        }


        public static async Task<WebService> GetWebService()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

            var playerRepositoryInMemory = new EfDeletableEntityRepository<Player>(new ApplicationDbContext(options.Options));
            var playerAbilitiesRepositoryInMemory = new EfDeletableEntityRepository<PlayerAbility>(new ApplicationDbContext(options.Options));
            var abilityTypeRepositoryInMemory = new EfDeletableEntityRepository<AbilityType>(new ApplicationDbContext(options.Options));
            var abilitiesRepositoryInMemory = new EfDeletableEntityRepository<Ability>(new ApplicationDbContext(options.Options));
            var userRepositoryInMemory = new EfDeletableEntityRepository<ApplicationUser>(new ApplicationDbContext(options.Options));
            var requirementsRepositoryInMemory = new EfDeletableEntityRepository<Requirement>(new ApplicationDbContext(options.Options));
            var jobRequirementsRepositoryInMemory = new EfDeletableEntityRepository<JobRequirement>(new ApplicationDbContext(options.Options));
            var jobRepositoryInMemory = new EfDeletableEntityRepository<Job>(new ApplicationDbContext(options.Options));
            var randomHangfireJobRepositoryInMemory = new EfDeletableEntityRepository<RandomHangfireJob>(new ApplicationDbContext(options.Options));
            var playerJobRepositoryInMemory = new EfDeletableEntityRepository<PlayerJob>(new ApplicationDbContext(options.Options));
            var jobTypeRepositoryInMemory = new EfDeletableEntityRepository<JobType>(new ApplicationDbContext(options.Options));


            var player = new Player
            {
                Name = "PlayerPesho",
                Money = 1000,
                UserId = "Pesho",
                Class = "Programmer",
                MaxHealth = 1000,
                MaxEnergy = 100,
            };

            var player1 = new Player
            {
                Name = "PlayerTest",
                Money = 1000,
                UserId = "Test",
                Class = "Programmer",
                MaxHealth = 1000,
                MaxEnergy = 100,
            };

            await playerRepositoryInMemory.AddAsync(player);
            await playerRepositoryInMemory.AddAsync(player1);

            await playerRepositoryInMemory.SaveChangesAsync();


            var user = new ApplicationUser
            {
                UserName = "Test",
                Id = "Pesho",
                PlayerId = player.Id,
                Email = "Test@abv.bg",
            };
            var user1 = new ApplicationUser
            {
                UserName = "Test1",
                Id = "Test",
                PlayerId = player1.Id,
                Email = "Test@abv.bg",
            };
            await userRepositoryInMemory.AddAsync(user);
            await userRepositoryInMemory.AddAsync(user1);

            await userRepositoryInMemory.SaveChangesAsync();

            await abilityTypeRepositoryInMemory.AddAsync(new AbilityType
            {
                Id = 3,
                Type = "Frameworks",
            });

            await abilityTypeRepositoryInMemory.AddAsync(new AbilityType
            {
                Id = 2,
                Type = "Database",
            });

            await abilityTypeRepositoryInMemory.AddAsync(new AbilityType
            {
                Id = 1,
                Type = "Languages",
            });

            await abilityTypeRepositoryInMemory.SaveChangesAsync();

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "C#",
                Description = "Develop by Microsoft , Structured,Object-Oriented,Functional Language and more",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "JS",
                Description = "Script Language .Write By Student",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Java",
                Description = "Develop by Oracle Corparation ,Design by James Cosling",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Python",
                Description = "Develop by Python Software Foundation",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "HTML",
                Description = "Hyper Text Markup Language",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "CSS",
                Description = "Cascade Style Sheets",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "MySQL",
                Description = "Developed by Oracle, MySQL Database Software is a client/server system",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "PostgreSQL",
                Description = "PostgreSQL is a powerful, open-source object-relational database system",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "MSSQL",
                Description = "SQL Server is a relational database management system developed by Microsoft",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "SQLite",
                Description = "SQLite is an in-process library that implements a self-contained, serverless, zero-configuration, transactional SQL database engine",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "MongoDB",
                Description = "MongoDB is a general-purpose, document-based, distributed database built for modern application developers and for the cloud era",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Oracle",
                Description = "Oracle Database is a multi-model database management system to run all of the workloads more securely",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "ASP.NETCore",
                Description = "ASP.NET Core is designed to allow runtime components, APIs, compilers and languages while providing a stable and supported platform to keep apps running",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "SpringFramework",
                Description = "The Spring Framework provides a comprehensive programming and configuration model for modern Java-based enterprise applications",
                AbilityTypeId = 3,
            });
            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Django",
                Description = "Django is a high-level Python Web framework that encourages rapid development and clean, pragmatic design.",
                AbilityTypeId = 3,
            });
            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Vue.JS",
                Description = "Vue.js is a popular JavaScript framework which achieved the 7th position at the Stack Overflow Developer Survey 2020 as the most used web framework",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "React.JS",
                Description = "React is a popular JavaScript library for building user interfaces",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Angular",
                Description = "Angular is a TypeScript-based open-source web application framework which can be used for building mobile and desktop web applications using TypeScript or JavaScript and other programming languages",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "RubyOnRails",
                Description = "Ruby on Rails is a web-application framework written in Ruby language. The framework includes everything needed to create database-backed web applications according to the Model-View-Controller (MVC) pattern",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.SaveChangesAsync();

            foreach (var ability in abilitiesRepositoryInMemory.All())
            {
                await playerAbilitiesRepositoryInMemory.AddAsync(new PlayerAbility
                {
                    PlayerId = player.Id,
                    AbilityId = ability.Id,
                    Points = 0,
                });
            }

            await playerAbilitiesRepositoryInMemory.SaveChangesAsync();

            await jobTypeRepositoryInMemory.AddAsync(new JobType
            {
                Name = "Website",
            });
            await jobTypeRepositoryInMemory.AddAsync(new JobType
            {
                Name = "Software",
            });
            await jobTypeRepositoryInMemory.AddAsync(new JobType
            {
                Name = "Console",
            });

            await jobTypeRepositoryInMemory.SaveChangesAsync();

            var software = jobTypeRepositoryInMemory.All().FirstOrDefault(x => x.Name == "Software").Id;
            var website = jobTypeRepositoryInMemory.All().FirstOrDefault(x => x.Name == "Website").Id;
            var console = jobTypeRepositoryInMemory.All().FirstOrDefault(x => x.Name == "Console").Id;

            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 1,
                Name = "Hello World",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 50,
                RewardExp = 5,
                RewardAbilityNames = "Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 2,
                Name = "Chess Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 3,
                Name = "Timer",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 4,
                Name = "Snake Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 5,
                Name = "Tik-Toe Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 6,
                Name = "Yu-Gi-Oh Simple Card Game",
                JobTypeId = software,
                LevelRequirement = 1,
                RewardMoney = 100,
                RewardExp = 10,
                RewardAbilityNames = "Python",
            });

            // Website Level 5 C#
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 7,
                Name = "Fitness",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 500,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 8,
                Name = "Food Delivery",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 600,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 9,
                Name = "Date Chat",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 550,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 10,
                Name = "Academy",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 780,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 11,
                Name = "Shoes Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 690,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 12,
                Name = "Computer Shop",
                JobTypeId = website,
                LevelRequirement = 5,
                RewardMoney = 850,
                RewardExp = 20,
                RewardAbilityNames = "Python Python",
            });

            // Software Level 8 C#
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 13,
                Name = "System Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1000,
                RewardExp = 40,
                RewardAbilityNames = "Python Python Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 14,
                Name = "Programming Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1300,
                RewardExp = 40,
                RewardAbilityNames = "Python Python Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 15,
                Name = "Application Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1200,
                RewardExp = 40,
                RewardAbilityNames = "Python Python Python",
            });
            await jobRepositoryInMemory.AddAsync(new Job
            {
                Id = 16,
                Name = "Driver Software",
                JobTypeId = software,
                LevelRequirement = 8,
                RewardMoney = 1700,
                RewardExp = 40,
                RewardAbilityNames = "Python Python Python",
            });

            await jobRepositoryInMemory.SaveChangesAsync();

            foreach (var job in jobRepositoryInMemory.All())
            {
                await randomHangfireJobRepositoryInMemory.AddAsync(new RandomHangfireJob
                {
                    JobId = job.Id,
                    PlayerId = player.Id,
                });
            }
            await randomHangfireJobRepositoryInMemory.SaveChangesAsync();

            await playerJobRepositoryInMemory.AddAsync(new PlayerJob
            {
                PlayerId = player.Id,
                JobId = 1,
            });

            await playerJobRepositoryInMemory.SaveChangesAsync();



            AutoMapperConfig.RegisterMappings(typeof(TestJobViewModel).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(TestJobRequirementViewModel).Assembly);

            var webservice = new WebService(
                jobRepositoryInMemory,
                randomHangfireJobRepositoryInMemory,
                playerRepositoryInMemory,
                playerJobRepositoryInMemory,
                playerAbilitiesRepositoryInMemory);

            return webservice;
        }


        public static async Task<AcademyService> GetAcademyService()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());

            var playerRepositoryInMemory = new EfDeletableEntityRepository<Player>(new ApplicationDbContext(options.Options));
            var playerAbilitiesRepositoryInMemory = new EfDeletableEntityRepository<PlayerAbility>(new ApplicationDbContext(options.Options));
            var abilityTypeRepositoryInMemory = new EfDeletableEntityRepository<AbilityType>(new ApplicationDbContext(options.Options));
            var abilitiesRepositoryInMemory = new EfDeletableEntityRepository<Ability>(new ApplicationDbContext(options.Options));
            var userRepositoryInMemory = new EfDeletableEntityRepository<ApplicationUser>(new ApplicationDbContext(options.Options));
            var courseTypeRepositoryInMemory = new EfDeletableEntityRepository<CourseType>(new ApplicationDbContext(options.Options));
            var courseRepositoryInMemory = new EfDeletableEntityRepository<Course>(new ApplicationDbContext(options.Options));
            var playerCourseRepositoryInMemory = new EfDeletableEntityRepository<PlayerCourse>(new ApplicationDbContext(options.Options));
            var lectureRepositoryInMemory = new EfDeletableEntityRepository<Lecture>(new ApplicationDbContext(options.Options));
            var completeLectureRepositoryInMemory = new EfDeletableEntityRepository<CompleteLecture>(new ApplicationDbContext(options.Options));

            var player = new Player
            {
                Id = "TestId",
                Name = "PlayerPesho",
                Money = 1000,
                UserId = "Pesho",
                Class = "Programmer",
                MaxHealth = 1000,
                MaxEnergy = 100,
            };

            var player1 = new Player
            {
                Name = "PlayerTest",
                Money = 1000,
                UserId = "Test",
                Class = "Programmer",
                MaxHealth = 1000,
                MaxEnergy = 100,
            };

            await playerRepositoryInMemory.AddAsync(player);
            await playerRepositoryInMemory.AddAsync(player1);

            await playerRepositoryInMemory.SaveChangesAsync();


            var user = new ApplicationUser
            {
                UserName = "Test",
                Id = "Pesho",
                PlayerId = player.Id,
                Email = "Test@abv.bg",
            };
            var user1 = new ApplicationUser
            {
                UserName = "Test1",
                Id = "Test",
                PlayerId = player1.Id,
                Email = "Test@abv.bg",
            };
            await userRepositoryInMemory.AddAsync(user);
            await userRepositoryInMemory.AddAsync(user1);

            await userRepositoryInMemory.SaveChangesAsync();

            await abilityTypeRepositoryInMemory.AddAsync(new AbilityType
            {
                Id = 3,
                Type = "Frameworks",
            });

            await abilityTypeRepositoryInMemory.AddAsync(new AbilityType
            {
                Id = 2,
                Type = "Database",
            });

            await abilityTypeRepositoryInMemory.AddAsync(new AbilityType
            {
                Id = 1,
                Type = "Languages",
            });

            await abilityTypeRepositoryInMemory.SaveChangesAsync();

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "C#",
                Description = "Develop by Microsoft , Structured,Object-Oriented,Functional Language and more",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "JS",
                Description = "Script Language .Write By Student",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Java",
                Description = "Develop by Oracle Corparation ,Design by James Cosling",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Python",
                Description = "Develop by Python Software Foundation",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "HTML",
                Description = "Hyper Text Markup Language",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "CSS",
                Description = "Cascade Style Sheets",
                AbilityTypeId = 1,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "MySQL",
                Description = "Developed by Oracle, MySQL Database Software is a client/server system",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "PostgreSQL",
                Description = "PostgreSQL is a powerful, open-source object-relational database system",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "MSSQL",
                Description = "SQL Server is a relational database management system developed by Microsoft",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "SQLite",
                Description = "SQLite is an in-process library that implements a self-contained, serverless, zero-configuration, transactional SQL database engine",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "MongoDB",
                Description = "MongoDB is a general-purpose, document-based, distributed database built for modern application developers and for the cloud era",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Oracle",
                Description = "Oracle Database is a multi-model database management system to run all of the workloads more securely",
                AbilityTypeId = 2,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "ASP.NETCore",
                Description = "ASP.NET Core is designed to allow runtime components, APIs, compilers and languages while providing a stable and supported platform to keep apps running",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "SpringFramework",
                Description = "The Spring Framework provides a comprehensive programming and configuration model for modern Java-based enterprise applications",
                AbilityTypeId = 3,
            });
            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Django",
                Description = "Django is a high-level Python Web framework that encourages rapid development and clean, pragmatic design.",
                AbilityTypeId = 3,
            });
            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Vue.JS",
                Description = "Vue.js is a popular JavaScript framework which achieved the 7th position at the Stack Overflow Developer Survey 2020 as the most used web framework",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "React.JS",
                Description = "React is a popular JavaScript library for building user interfaces",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "Angular",
                Description = "Angular is a TypeScript-based open-source web application framework which can be used for building mobile and desktop web applications using TypeScript or JavaScript and other programming languages",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.AddAsync(new Ability
            {
                Name = "RubyOnRails",
                Description = "Ruby on Rails is a web-application framework written in Ruby language. The framework includes everything needed to create database-backed web applications according to the Model-View-Controller (MVC) pattern",
                AbilityTypeId = 3,
            });

            await abilitiesRepositoryInMemory.SaveChangesAsync();

            foreach (var ability in abilitiesRepositoryInMemory.All())
            {
                await playerAbilitiesRepositoryInMemory.AddAsync(new PlayerAbility
                {
                    PlayerId = player.Id,
                    AbilityId = ability.Id,
                    Points = 0,
                });
            }

            await playerAbilitiesRepositoryInMemory.SaveChangesAsync();

            await courseTypeRepositoryInMemory.AddAsync(new CourseType
            {
                Id = 5,
                Name = "Basic",
            });

            await courseTypeRepositoryInMemory.AddAsync(new CourseType
            {
                Id = 4,
                Name = "C#",
            });

            await courseTypeRepositoryInMemory.AddAsync(new CourseType
            {
                Id = 3,
                Name = "JS",
            });

            await courseTypeRepositoryInMemory.AddAsync(new CourseType
            {
                Id = 2,
                Name = "Java",
            });

            await courseTypeRepositoryInMemory.AddAsync(new CourseType
            {
                Id = 1,
                Name = "Python",
            });

            await courseTypeRepositoryInMemory.SaveChangesAsync();

            var pythonId = courseTypeRepositoryInMemory.All().FirstOrDefault(x => x.Name == "Python").Id;

            await courseRepositoryInMemory.AddAsync(new Course
            {
                Id = 2,
                Name = "Python OOP",
                CourseTypeId = pythonId,
                LevelToUnlock = 10,
            });

            await courseRepositoryInMemory.AddAsync(new Course
            {
                Id = 1,
                Name = "Python Advanced",
                CourseTypeId = pythonId,
                LevelToUnlock = 9,
            });
            await courseRepositoryInMemory.SaveChangesAsync();

            // Python OOP Lectures
            var pythonOOPId = courseRepositoryInMemory.All().FirstOrDefault(x => x.Name == "Python OOP").Id;

            await lectureRepositoryInMemory.AddAsync(new Lecture
            {
                Id = 1,
                Number = 1,
                Name = "Defining Classes",
                ExperienceToComplete = 80,
                RewardAbilityName = "Python",
                RewardMoney = 2000,
                CourseId = pythonOOPId,
            });

            await lectureRepositoryInMemory.SaveChangesAsync();

            var academyService = new AcademyService(
                courseRepositoryInMemory,
                lectureRepositoryInMemory,
                playerAbilitiesRepositoryInMemory,
                playerRepositoryInMemory,
                completeLectureRepositoryInMemory,
                playerCourseRepositoryInMemory);

            return academyService;
        }
    }
}